using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public abstract class EfectoStatRival : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatRival(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        var stats = Cantidad > 0 ? rival.dataHabilidadStats.bonusStats : rival.dataHabilidadStats.penaltyStats;

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

public class RivalAtkUp : EfectoStatRival
{
    public RivalAtkUp(int cantidad) : base(Stat.Atk.ToString(), cantidad) { }
}
public class RivalSpdUp : EfectoStatRival
{
    public RivalSpdUp(int cantidad) : base(Stat.Spd.ToString(), cantidad) { }
}
public class RivalDefUp : EfectoStatRival
{
    public RivalDefUp(int cantidad) : base(Stat.Def.ToString(), cantidad) { }
}
public class RivalResUp : EfectoStatRival
{
    public RivalResUp(int cantidad) : base(Stat.Res.ToString(), cantidad) { }
}