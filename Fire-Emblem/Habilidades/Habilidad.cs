namespace Fire_Emblem.Habilidades;

public class Habilidad 
{
    public List<IEfecto> efecto;
    public List<ICondicion> condicion;
    public Personaje jugador;
    public Personaje rival;
    private bool cumple_todas_condicion = true;
    public Habilidad(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
    {
        this.efecto = efecto;
        this.condicion = condicion;
        this.jugador = jugador;
        this.rival = rival;
    }

    public virtual void aplicarHabilidad()
    {
        foreach (var i in  condicion)
        {
            if (i.condicionHabilidad(jugador, rival) == false)
            {
                cumple_todas_condicion = false; 
            }
        }

        if (cumple_todas_condicion)
        {
            foreach (var i in efecto)
            {
                i.efecto(jugador, rival);
            }
        }
    }
    
}

public class MoonTwinWing : Habilidad
{
    private bool cumple_todas_condicion = true;
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
            descunto = -5; 
        }
        if (jugador.spd >= rival.spd)
        {
            if (new HpMas25().condicionHabilidad(jugador, rival))
            {
                new ReduccionDanoSpd(descunto, descunto).efecto(jugador, rival);
            }
        }
    }
}
public class GuardBearing : Habilidad
{
    private bool cumple_todas_condicion = true;
    private int descunto = 0; 
    public GuardBearing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {

        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);

        // if ((jugador.primerCombateInicia == false && new CondicionInicioCombate().condicionHabilidad(jugador, rival)) ||
        //     (rival.primerCombateInicia == false && new CondicionNoInicia().condicionHabilidad(jugador, rival)))
        if ((jugador.primerCombateInicia == false && new CondicionInicioCombate().condicionHabilidad(jugador, rival)) ||
            (jugador.primeraVexDefiende == false && new CondicionNoInicia().condicionHabilidad(jugador, rival)))
        {
            new ReduccionDanoPorcentual(0.6m).efecto(jugador, rival);
        }
        else
        {
            new ReduccionDanoPorcentual(0.3m).efecto(jugador, rival); 
        }
    }
}