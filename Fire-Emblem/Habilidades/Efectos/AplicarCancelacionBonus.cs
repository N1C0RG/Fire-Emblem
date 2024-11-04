using Fire_Emblem.Encapsulado;
using static Fire_Emblem.Habilidades.Prioridad; 
namespace Fire_Emblem.Habilidades;

public abstract class AplicarCancelacionBonus : IEfecto
{
    protected string StatKey;
    protected AplicarCancelacionBonus(string statKey)
    {
        StatKey = statKey;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        rival.dataHabilidadStats.bonusNeutralizados.Add(StatKey);
    }
    public Prioridad getPrioridad()
    {
        return Prioridad.neutralizacionBonus;
    }
}

public class AplicarCancelacionAtk : AplicarCancelacionBonus
{
    public AplicarCancelacionAtk() : base(Stat.Atk.ToString()) { }
}
public class AplicarCancelacionSpd : AplicarCancelacionBonus
{
    public AplicarCancelacionSpd() : base(Stat.Spd.ToString()) { }
}
public class AplicarCancelacionDef : AplicarCancelacionBonus
{
    public AplicarCancelacionDef() : base(Stat.Def.ToString()) { }
}
public class AplicarCancelacionRes : AplicarCancelacionBonus
{
    public AplicarCancelacionRes() : base(Stat.Res.ToString()) { }
}
