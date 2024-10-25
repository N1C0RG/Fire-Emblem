namespace Fire_Emblem.Habilidades;

public class DragonsWrath : Habilidad
{
    private int ataqueJugador;
    private int resistenciaRival; 
    public DragonsWrath(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        calcularAtaqueResitencia(); 
        new ReduccionDanoPorcentualPrimerAtaque(0.25m).efecto(jugador, rival);
        
        if (ataqueJugador > resistenciaRival)
        {
            new EfectoDanoExtraPrimerAtaque(calcularDanoExtra()).efecto(jugador, rival);
        }
    }
    private int calcularDanoExtra()
    {

        return (int)((ataqueJugador - resistenciaRival)/4);
    }
    private void calcularAtaqueResitencia()
    {
        ataqueJugador = jugador.atk + jugador.dataHabilidadStats.postEfecto["Atk"]; 
        resistenciaRival = rival.res + rival.dataHabilidadStats.postEfecto["Res"];
    }
}