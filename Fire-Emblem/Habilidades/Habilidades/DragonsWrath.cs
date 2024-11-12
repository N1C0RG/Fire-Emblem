using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class DragonsWrath : HabilidadCompuesta
{
    private int ataqueJugador;
    private int resistenciaRival; 
    public DragonsWrath(Personaje jugador, Personaje rival)
        : base(new List<Habilidad>(), jugador, rival)
    {
        agregarEfectos();
    }
    public override void aplicarHabilidad()
    {
        calcularAtaqueResitencia(); 
        new ReduccionDanoPorcentualPrimerAtaque(0.25m).efecto(jugador, rival);
        
        if (ataqueJugador > resistenciaRival)
        {
            new EfectoDanoExtraPrimerAtaque(calcularDanoExtra(), () => -1).efecto(jugador, rival);
        }
    }
    public void agregarEfectos()
    {
       
        var habilidades = new List<Habilidad>()
        {
            new Habilidad(
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.25m) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival),
            new Habilidad(
                new List<IEfecto> { new EfectoDanoExtraPrimerAtaque(calcularDanoExtra(), calcularDanoExtra) },
                new List<ICondicion> { new CondicionDiferenciaStats(Stat.Atk, Stat.Res) },
                _jugador,
                _rival)
        }; 
        _habilidades = habilidades;
    }
    private int calcularDanoExtra()
    {
        calcularAtaqueResitencia();
        return (ataqueJugador - resistenciaRival)/4;
    }
    private void calcularAtaqueResitencia()
    {
        ataqueJugador = jugador.atk + jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            Stat.Atk.ToString()); 
        resistenciaRival = rival.res + rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            Stat.Res.ToString());
    }
}

