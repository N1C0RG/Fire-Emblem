namespace Fire_Emblem.Habilidades;

public abstract class ReduccionDanoPorcentualBase : IEfecto
{
    protected decimal cantidad;
    protected string tipoAtaque;

    protected ReduccionDanoPorcentualBase(decimal cantidad, string tipoAtaque)
    {
        this.cantidad = cantidad;
        this.tipoAtaque = tipoAtaque;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary[tipoAtaque] = 
            1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary[tipoAtaque]) * (1 - cantidad);
    }
    public Prioridad getPrioridad()
    {
        return Prioridad.reduccionPorcentual; 
    }
}

public class ReduccionDanoPorcentual : ReduccionDanoPorcentualBase
{
    public ReduccionDanoPorcentual(decimal cantidad) : base(cantidad, "todosAtaques") { }
}

public class ReduccionDanoPorcentualPrimerAtaque : ReduccionDanoPorcentualBase
{
    public ReduccionDanoPorcentualPrimerAtaque(decimal cantidad) : base(cantidad, "primerAtaque") { }
}

public class ReduccionDanoPorcentualFollowUp : ReduccionDanoPorcentualBase
{
    public ReduccionDanoPorcentualFollowUp(decimal cantidad) : base(cantidad, "followUp") { }
}