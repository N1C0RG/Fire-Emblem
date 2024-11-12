namespace Fire_Emblem.Habilidades;

public class ExtraChivalry: Habilidad
{
    private int ataqueJugador;
    private int resistenciaRival; 
    
    public ExtraChivalry(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        agregarEfecto();
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
    public void agregarEfecto()
    {
        if (new CondicionRivalHP50().condicionHabilidad(jugador, rival))
        {
            efecto.Add(new RivalAtkUp(-5));
            efecto.Add(new RivalSpdUp(-5));
            efecto.Add(new RivalDefUp(-5));
        }

        if ((calcularDano()) != 0)
        {
            efecto.Add(new ReduccionDanoPorcentual((calcularDano())));
        }
        
    }

    private decimal calcularDano()
    {
        int porcentajeDano = (int)Math.Floor((rival.HP / (decimal)rival.hpOriginal) * 100);
        
        int danoMitad = porcentajeDano / 2;

        return danoMitad * 0.01m;
    }
}