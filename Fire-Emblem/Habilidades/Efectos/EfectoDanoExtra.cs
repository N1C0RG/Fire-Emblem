namespace Fire_Emblem.Habilidades;

public abstract class EfectoDanoExtraBase : IEfecto
{
    protected int cantidad;
    protected string tipoAtaque;

    protected EfectoDanoExtraBase(int cantidad, string tipoAtaque)
    {
        this.cantidad = cantidad;
        this.tipoAtaque = tipoAtaque;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary[tipoAtaque] += cantidad;
    }
}

public class EfectoDanoExtra : EfectoDanoExtraBase
{
    public EfectoDanoExtra(int cantidad) : base(cantidad, "todosAtaques") { }
}

public class EfectoDanoExtraPrimerAtaque : EfectoDanoExtraBase
{
    public EfectoDanoExtraPrimerAtaque(int cantidad) : base(cantidad, "primerAtaque") { }
}

public class EfectoDanoExtraFollowUp : EfectoDanoExtraBase
{
    public EfectoDanoExtraFollowUp(int cantidad) : base(cantidad, "followUp") { }
}