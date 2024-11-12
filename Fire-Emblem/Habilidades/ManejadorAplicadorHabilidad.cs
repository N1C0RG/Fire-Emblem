using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;
using Fire_Emblem.EnumVariables;

namespace Fire_Emblem.Habilidades;

public class ManejadorAplicadorHabilidad
{
    private Personaje _jugador;
    private Personaje _rival;
    private List<(IEfecto efectos, List<ICondicion> condiciones)> _efectosPrioritariosJugador = new List<(IEfecto efectos, List<ICondicion> condiciones)>();
    private List<(IEfecto efectos, List<ICondicion> condiciones)> _efectosPrioritariosRival = new List<(IEfecto efectos, List<ICondicion> condiciones)>();
    private View view;
    private Dictionary<string, int> bonus = new Dictionary<string, int>(); 
    private Dictionary<string, int> bonusPrimer = new Dictionary<string, int>(); 
    private Dictionary<string, int> bonusFollow = new Dictionary<string, int>(); 
    private Dictionary<string, int> penalty = new Dictionary<string, int>(); 
    private Dictionary<string, int> penaltyPrimer = new Dictionary<string, int>(); 
    private Dictionary<string, int> penaltyFollow = new Dictionary<string, int>(); 
    private Dictionary<string, int> bonusNeutra = new Dictionary<string, int>(); 
    private Dictionary<string, int> penaltyNeutra = new Dictionary<string, int>(); 
    private int extra = 0; 
    private int extraPrimer = 0; 
    private int extraFollow = 0; 
    private decimal reduccion = 0; 
    private decimal reduccionPrimer = 0; 
    private decimal reduccionFollow = 0;
    private int reduccionAbsoluta = 0;
    

    


    public ManejadorAplicadorHabilidad(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        this.view = view; 
    }

    public void aplicarHabilidades()
    {
        aplicarHabilidadesIndependientes(_jugador, _rival);
        //aplicarHabilidadesIndependientes(_rival, _jugador);

        _jugador.calcularPostEfecto();
        _rival.calcularPostEfecto();

        aplicarHabilidadesDependientes(_jugador, _rival);
        aplicarHabilidadesDependientes(_rival, _jugador);
    }
    public void aplicarHabilidadesIndependientes(Personaje jugador, Personaje rival)
    {

        // Recopilar efectos de cada habilidad del jugador y rival
        recopilarEfectos(_jugador, _rival, "jugador");
        recopilarEfectos(_rival, _jugador, "rival");

        // Ordenar los efectos globalmente por prioridad
        // var efectosOrdenadosJygadro = _efectosPrioritariosJugador
        //     .OrderByDescending(e => e.getPrioridad())
        //     .ToList();
        // var efectosOrdenadosRivalo = _efectosPrioritariosRival
        //     .OrderByDescending(e => e.getPrioridad())
        //     .ToList();

        // Aplicar los efectos en orden de prioridad

        for (int i = 1; i < 9; i++)
        {
            foreach (var efecto in _efectosPrioritariosRival)
            {
                if ((int)efecto.Item1.getPrioridad() == i)
                {
                    bool cumple = true;
                    foreach (var condicion in efecto.condiciones)
                    {
                        if (!condicion.condicionHabilidad(rival, jugador))
                        {
                            cumple = false;
                        }
                    }
                    if (cumple) {efecto.Item1.efecto(_rival, _jugador);}
                }
            }
            _jugador.calcularPostEfecto();//calculo el post efecto al final de cada prioridad
            _rival.calcularPostEfecto();
            foreach (var efecto in _efectosPrioritariosJugador)
            {
                if ((int)efecto.Item1.getPrioridad() == i)
                {
                    bool cumple = true;
                    foreach (var condicion in efecto.condiciones)
                    {
                        if (!condicion.condicionHabilidad(jugador, rival))
                        {
                            cumple = false;
                        }
                    }
                    if (cumple) {efecto.Item1.efecto(_jugador, _rival);}
                }
                
            }
            // Console.WriteLine($"post efecto {_rival.name} spd { _rival.getDataReduccionExtraStat<decimal>(NombreDiccionario.danoAdicional.ToString(),
            //     Llave.primerAtaque.ToString())}");
            // Console.WriteLine($"post efecto {_jugador.name} spd { _jugador.getDataReduccionExtraStat<decimal>(NombreDiccionario.danoAdicional.ToString(),
            //     Llave.primerAtaque.ToString())}");
            _jugador.calcularPostEfecto();//calculo el post efecto al final de cada prioridad
            _rival.calcularPostEfecto();
            // view.WriteLine($"post efecto {_rival.name} spd { _rival.res + _rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            //     Stat.Res.ToString())}");
            // view.WriteLine($"post efecto {_jugador.name} spd {_jugador.atk + _jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            //     Stat.Atk.ToString())}");
            // if (_rival.res + _rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            //         Stat.Res.ToString()) < _jugador.atk + _jugador.getDataHabilidadStat(
            //         NombreDiccionario.postEfecto.ToString(),
            //         Stat.Atk.ToString()))
            // {
            //     view.WriteLine("cumple condicion");
            // }
        }
    }
    private void recopilarEfectos(Personaje personaje, Personaje rival, string tipoJugador)
    {
        foreach (var habilidad in personaje.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadIndependienteStats(habilidad, personaje, 
                personaje == _jugador ? _rival : _jugador);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var habilidadAplicador = fabricaHabilidad.crearAplicador();

                bool cumple = true;
                // foreach (var condicion in habilidadAplicador._habilidad.condicion)
                // {
                //     if (!condicion.condicionHabilidad(personaje, rival))
                //     {
                //         cumple = false;
                //     }
                // }

                if (habilidadAplicador._habilidad is HabilidadCompuesta habilidadCompuesta)
                {
                    foreach (var h in habilidadCompuesta._habilidades)
                    {
                        bool si = true; 
                        // foreach (var condicion in h.condicion)
                        // {
                        //     if (!condicion.condicionHabilidad(personaje, rival))
                        //     {
                        //         si = false;
                        //     }
                        // }
                        if (si)
                        {
                            foreach (var efecto in h.efecto)
                            {
                                if (tipoJugador == "jugador")
                                {
                                    _efectosPrioritariosJugador.Add((efecto,h.condicion));
                                }
                                else
                                {
                                    _efectosPrioritariosRival.Add((efecto,h.condicion));
                                }
                            }
                        }
                    }
                }
                if (cumple)
                {
                    {
                        foreach (var efecto in habilidadAplicador._habilidad.efecto)
                        {
                            if (tipoJugador == "jugador")
                            {
                                _efectosPrioritariosJugador.Add((efecto,habilidadAplicador._habilidad.condicion));
                               
                            }
                            else
                            {
                                _efectosPrioritariosRival.Add((efecto,habilidadAplicador._habilidad.condicion));
                            }
                        }
                    }
                }

            }
            catch { /* Manejo de errores opcional */ }
        }
    }

    private void aplicarHabilidadesDependientes(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadesDependientesStats(habilidad, jugador, rival);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
                aplicadorHabilidad.aplicarHabilidad();
            }
            catch { }
        }
    }
}

