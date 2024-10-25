namespace Fire_Emblem.Habilidades;

public class ExtraChivalry: Habilidad
{
    private int ataqueJugador;
    private int resistenciaRival; 
    
    public ExtraChivalry(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        if (new CondicionRivalHP50().condicionHabilidad(jugador, rival))
        {
            new RivalAtkUp(-5).efecto(jugador, rival);
            new RivalSpdUp(-5).efecto(jugador, rival);
            new RivalDefUp(-5).efecto(jugador, rival);
        }
        new ReduccionDanoPorcentual(calcularDano()).efecto(jugador, rival);
    }

    private decimal calcularDano()
    {
        decimal porcentajeHP = Math.Floor((rival.HP / (decimal)rival.hpOriginal) * 100);
        return (porcentajeHP * 0.5m) / 100m;
    }
}