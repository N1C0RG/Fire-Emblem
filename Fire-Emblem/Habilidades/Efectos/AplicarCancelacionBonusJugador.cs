using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public abstract class AplicarCancelacionBonusJugador : IEfecto
{
    protected string StatKey;
    protected AplicarCancelacionBonusJugador(string statKey)
    {
        StatKey = statKey;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataHabilidadStats.bonusNeutralizados.Add(StatKey);
        //jugador.setDataHabilidadStat(NombreDiccionario.bonusStats.ToString(), StatKey, 0);
    }
    public Prioridad getPrioridad()
    {
        return Prioridad.neutralizacionBonus;
    }
}
public class AplicarCancelacionDefJugador : AplicarCancelacionBonusJugador
{
    public AplicarCancelacionDefJugador() : base(Stat.Def.ToString()) { }
}
public class AplicarCancelacionResJugador : AplicarCancelacionBonusJugador
{
    public AplicarCancelacionResJugador() : base(Stat.Res.ToString()) { }
}