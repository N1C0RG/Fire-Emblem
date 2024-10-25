namespace Fire_Emblem.Habilidades;

public class MoonTwinWing : Habilidad
{
    private int descunto = 0; 
    public MoonTwinWing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        if (new HpMas25().condicionHabilidad(jugador, rival))
        {
            new RivalAtkUp(-5).efecto(jugador, rival);
            new RivalSpdUp(-5).efecto(jugador, rival);
            descunto = -0;
            
        }
        rival.dataHabilidadStats.calcularPostEfecto();
        if (jugador.spd + jugador.dataHabilidadStats.postEfecto["Spd"]> rival.spd + rival.dataHabilidadStats.postEfecto["Spd"])
        {
            if (new HpMas25().condicionHabilidad(jugador, rival))
            {
                new ReduccionDanoSpd(descunto, descunto).efecto(jugador, rival);
            }
        }
    }
}