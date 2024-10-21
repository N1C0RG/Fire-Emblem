namespace Fire_Emblem.Habilidades;
public interface IEfecto
{
    public void efecto(Personaje jugador, Personaje rival); 
}
public abstract class EfectoStatJugador : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatJugador(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }

    public void efecto(Personaje player, Personaje rival)
    {
        var stats = Cantidad > 0 ? player.bonusStats : player.penaltyStats;

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
public abstract class EfectoStatRival : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatRival(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }
    public void efecto(Personaje player, Personaje rival)
    {
        var stats = Cantidad > 0 ? rival.bonusStats : rival.penaltyStats;

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
public abstract class AplicarCancelacionBonus : IEfecto
{
    protected string StatKey;
    protected AplicarCancelacionBonus(string statKey)
    {
        StatKey = statKey;
    }
    public void efecto(Personaje player, Personaje rival)
    {
        rival.bonusNeutralizados.Add(StatKey);
    }
}
public class AtkUp : EfectoStatJugador
{
    public AtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class SpdUp : EfectoStatJugador
{
    public SpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class DefUp : EfectoStatJugador
{
    public DefUp(int cantidad) : base("Def", cantidad) { }
}
public class ResUp : EfectoStatJugador
{
    public ResUp(int cantidad) : base("Res", cantidad) { }
}
public class RivalAtkUp : EfectoStatRival
{
    public RivalAtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class RivalSpdUp : EfectoStatRival
{
    public RivalSpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class RivalDefUp : EfectoStatRival
{
    public RivalDefUp(int cantidad) : base("Def", cantidad) { }
}
public class RivalResUp : EfectoStatRival
{
    public RivalResUp(int cantidad) : base("Res", cantidad) { }
}
public class AplicarCancelacionAtk : AplicarCancelacionBonus
{
    public AplicarCancelacionAtk() : base("Atk") { }
}
public class AplicarCancelacionDef : AplicarCancelacionBonus
{
    public AplicarCancelacionDef() : base("Def") { }
}
public class AplicarCancelacionRes : AplicarCancelacionBonus
{
    public AplicarCancelacionRes() : base("Res") { }
}
public class AplicarCancelacionSpd : AplicarCancelacionBonus
{
    public AplicarCancelacionSpd() : base("Spd") { }
}

public class AplicarCancelacionPenalty : IEfecto
{
    public void efecto(Personaje player, Personaje rival)
    {
        player.addPenaltyNeutralizados("Atk");
        player.addPenaltyNeutralizados("Spd");
        player.addPenaltyNeutralizados("Def");
        player.addPenaltyNeutralizados("Res");
    }
}
public class Up50Atack: IEfecto
{
    public  void efecto(Personaje player, Personaje rival)
    {
        if (player.bonusStats.ContainsKey("Atk"))
        {
            player.bonusStats["Atk"] += (int)Math.Floor(Convert.ToDecimal(player.atk) * 0.5m);
        }
        else
        {
            player.bonusStats.Add("Atk", (int)Math.Floor(Convert.ToDecimal(player.atk) * 0.5m));
        } 
    }
}

public class Sandstorm : IEfecto
{
    public  void efecto(Personaje player, Personaje rival) //TODO: no considero el caso de multiples sumas al follow 
    {
        player.ataqueFollow = (int)Math.Floor(Convert.ToDecimal(player.def) * 1.5m) - player.atk; //TODO: ver esto 
    }
}

public class EfectoLuna : IEfecto
{
    public  void efecto(Personaje player, Personaje rival)
    {
        rival.habilidadPrimerAtaque.Add("Def"); //TODO: ver esto 
        rival.habilidadPrimerAtaque.Add("Res");
    }
}

public class HpUp : IEfecto
{
    public  void efecto(Personaje player, Personaje rival)
    {
        player.HP += 15; 
    }
}

