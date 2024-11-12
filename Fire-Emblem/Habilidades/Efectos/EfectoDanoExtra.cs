namespace Fire_Emblem.Habilidades;

public delegate int UpdateDamageDelegate();//TODO: mover esto 
public abstract class EfectoDanoExtraBase : IEfecto
{
    protected int cantidad;
    protected string tipoAtaque;
    protected UpdateDamageDelegate updateDamage;

    protected EfectoDanoExtraBase(int cantidad, string tipoAtaque, UpdateDamageDelegate updateDamage)
    {
        this.cantidad = cantidad;
        this.tipoAtaque = tipoAtaque;
        this.updateDamage = updateDamage;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        cantidad = updateDamage() == -1 ? cantidad : updateDamage();
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary[tipoAtaque] += cantidad;
    }

    public Prioridad getPrioridad()
    {
        return Prioridad.danoExtra; 
    }
}

public class EfectoDanoExtra : EfectoDanoExtraBase
{
    public EfectoDanoExtra(int cantidad, UpdateDamageDelegate updateDamage) : 
        base(cantidad, "todosAtaques", updateDamage) { }
}

public class EfectoDanoExtraPrimerAtaque : EfectoDanoExtraBase
{
    public EfectoDanoExtraPrimerAtaque(int cantidad, UpdateDamageDelegate updateDamage) 
        : base(cantidad, "primerAtaque", updateDamage) { }
}

public class EfectoDanoExtraFollowUp : EfectoDanoExtraBase
{
    public EfectoDanoExtraFollowUp(int cantidad, UpdateDamageDelegate updateDamage) 
        : base(cantidad, "followUp", updateDamage) { }
}

public abstract class EfectoDivneRecreation : IEfecto //TODO hacer algo con esto 
{
    protected int cantidad;
    protected string tipoAtaque;
    protected UpdateDamageDelegate updateDamage;

    protected EfectoDivneRecreation(int cantidad, string tipoAtaque, UpdateDamageDelegate updateDamage)
    {
        this.cantidad = cantidad;
        this.tipoAtaque = tipoAtaque;
        this.updateDamage = updateDamage;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        cantidad = updateDamage() == -1 ? cantidad : updateDamage();
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary[tipoAtaque] += cantidad;
    }

    public Prioridad getPrioridad()
    {
        return Prioridad.divineRecreation; 
    }
}
public class DivinePrimerAtaque : EfectoDivneRecreation
{
    public DivinePrimerAtaque(int cantidad, UpdateDamageDelegate updateDamage) 
        : base(cantidad, "primerAtaque", updateDamage) { }
}

public class DivineFollow : EfectoDivneRecreation
{
    public DivineFollow(int cantidad, UpdateDamageDelegate updateDamage) 
        : base(cantidad, "followUp", updateDamage) { }
}
