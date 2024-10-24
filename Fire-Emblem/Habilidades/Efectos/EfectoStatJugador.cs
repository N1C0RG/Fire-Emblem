using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public abstract class EfectoStatJugador : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatJugador(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        var stats = Cantidad > 0 ? jugador.dataHabilidadStats.bonusStats : jugador.dataHabilidadStats.penaltyStats;

        if (stats.ContainsKey(StatKey))
        {
            stats[StatKey] += Cantidad;
        }
        else
        {
            stats.Add(StatKey, Cantidad);
        }
    }
}

public class AtkUp : EfectoStatJugador
{
    public AtkUp(int cantidad) : base(Stat.Atk.ToString(), cantidad) { }
}
public class SpdUp : EfectoStatJugador
{
    public SpdUp(int cantidad) : base(Stat.Spd.ToString(), cantidad) { }
}
public class DefUp : EfectoStatJugador
{
    public DefUp(int cantidad) : base(Stat.Def.ToString(), cantidad) { }
}
public class ResUp : EfectoStatJugador
{
    public ResUp(int cantidad) : base(Stat.Res.ToString(), cantidad) { }
}