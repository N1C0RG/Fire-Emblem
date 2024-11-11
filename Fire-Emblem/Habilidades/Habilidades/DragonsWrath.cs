using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class DragonsWrath : Habilidad
{
    private int ataqueJugador;
    private int resistenciaRival; 
    public DragonsWrath(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
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
        calcularAtaqueResitencia(); 
        efecto.Add(new ReduccionDanoPorcentualPrimerAtaque(0.25m));
        
        if (ataqueJugador > resistenciaRival)
        {
            efecto.Add(new EfectoDanoExtraPrimerAtaque(calcularDanoExtra(), () => -1));
        }
    }
    private int calcularDanoExtra()
    {
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