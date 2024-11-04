using Fire_Emblem_View;
using Fire_Emblem.EnumVariables;

namespace Fire_Emblem.Habilidades;

public class ManejadorAplicadorHabilidad
{
    private Personaje _jugador;
    private Personaje _rival;
    private List<IEfecto> _efectosPrioritariosJugador = new List<IEfecto>();
    private List<IEfecto> _efectosPrioritariosRival = new List<IEfecto>();
    private View view; 

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

    // private void aplicarHabilidadesIndependientes(Personaje jugador, Personaje rival)
    // {
    //     foreach (var habilidad in jugador.habilidades)
    //     {
    //         var fabricaHabilidad = new FabricaHabilidadIndependienteStats(habilidad, jugador, rival);
    //         try
    //         {
    //             fabricaHabilidad.crearHabilidad();
    //             var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
    //             aplicadorHabilidad.aplicarHabilidad();
    //         }
    //         catch { }
    //     }
    // }
    public void aplicarHabilidadesIndependientes(Personaje jugador, Personaje rival)
    {

        // Recopilar efectos de cada habilidad del jugador y rival
        recopilarEfectos(_jugador, _rival, "jugador");
        recopilarEfectos(_rival, _jugador, "rival");

        // Ordenar los efectos globalmente por prioridad
        var efectosOrdenadosJygadro = _efectosPrioritariosJugador
            .OrderByDescending(e => e.getPrioridad())
            .ToList();
        var efectosOrdenadosRivalo = _efectosPrioritariosRival
            .OrderByDescending(e => e.getPrioridad())
            .ToList();

        // Aplicar los efectos en orden de prioridad

        for (int i = 1; i < 8; i++)
        {
            foreach (var efecto in efectosOrdenadosJygadro)
            {
                if ((int)efecto.getPrioridad() == i)
                {
                    efecto.efecto(_jugador, _rival);
                }
            }
            foreach (var efecto in efectosOrdenadosRivalo)
            {
                if ((int)efecto.getPrioridad() == i)
                {
                    efecto.efecto(_rival, _jugador);
                }
            }
            
            // if (i < efectosOrdenadosJygadro.Count)
            // {
            //     var efectoJugador = efectosOrdenadosJygadro[i];
            //     efectoJugador.efecto(_jugador, _rival);
            // }
            // if (i < efectosOrdenadosRivalo.Count)
            // {
            //     var efectoRival = efectosOrdenadosRivalo[i];
            //     efectoRival.efecto(_rival, _jugador);
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
                foreach (var condicion in habilidadAplicador._habilidad.condicion)
                {
                    if (!condicion.condicionHabilidad(personaje, rival))
                    {
                        cumple = false;
                    }
                }

                if (habilidadAplicador._habilidad is HabilidadCompuesta habilidadCompuesta)
                {
                    foreach (var h in habilidadCompuesta._habilidades)
                    {
                        bool si = true; 
                        foreach (var condicion in h.condicion)
                        {
                            if (!condicion.condicionHabilidad(personaje, rival))
                            {
                                si = false;
                            }
                        }

                        if (si)
                        {
                            foreach (var efecto in h.efecto)
                            {
                                if (tipoJugador == "jugador")
                                {
                                    _efectosPrioritariosJugador.Add(efecto);
                                }
                                else
                                {
                                    _efectosPrioritariosRival.Add(efecto);
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
                                _efectosPrioritariosJugador.Add(efecto);
                            }
                            else
                            {
                                _efectosPrioritariosRival.Add(efecto);
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

