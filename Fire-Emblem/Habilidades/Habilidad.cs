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
        rival.SumarBonusYPenaltyEnPostEfecto();
        if (jugador.spd + jugador.postEfecto["Spd"]> rival.spd + rival.postEfecto["Spd"])
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
    public GuardBearing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {

        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);
        
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

public class DivineRecreation : Habilidad
{
    public DivineRecreation(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }

    public override void aplicarHabilidad()
    {
        if (new CondicionRivalHP50().condicionHabilidad(jugador, rival))
            new RivalAtkUp(-4).efecto(jugador, rival);
        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);
        new RivalResUp(-4).efecto(jugador, rival);


        rival.postEfecto["Atk"] += -4; 
        foreach (var i in rival.postEfecto)
        {
            rival.netosStats.Add(i.Key, i.Value);
        }

        var c = new CalculadorDeAtaque();
        var v = new Ventaja(); 
        v.calcularVentaja(jugador, rival); 
        var atk = c.calcularAtaque(rival, jugador, v.ventajaRival);

        int cantidad = atk - jugador.reduccionDanoAbsoluta;
        int result = (int)(cantidad * 0.3m);
        
        new ReduccionDanoPorcentualPrimerAtaque(0.3m).efecto(jugador, rival);

        if (new CondicionInicioCombate().condicionHabilidad(jugador, rival))
        {
            new EfectoDanoExtraFollowUp(result).efecto(jugador, rival);
        }
        else
        {
            new EfectoDanoExtraPrimerAtaque(result).efecto(jugador, rival);
        }
    }
}
