namespace Fire_Emblem.Habilidades;
public interface IEffect
{
    public void Bonus(Personaje player, Personaje rival); 
}
public abstract class StatEffectPlayer : IEffect
{
    protected string StatKey;
    protected int Cantidad; 
    protected StatEffectPlayer(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }

    public void Bonus(Personaje player, Personaje rival)
    {
        var stats = Cantidad > 0 ? player.bonus_stats : player.penalty_stats;

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
public abstract class StatEffectRival : IEffect
{
    protected string StatKey;
    protected int Cantidad; 
    protected StatEffectRival(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }
    public void Bonus(Personaje player, Personaje rival)
    {
        var stats = Cantidad > 0 ? rival.bonus_stats : rival.penalty_stats;

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
public abstract class AplicarCancelacionBonus : IEffect
{
    protected string StatKey;
    protected AplicarCancelacionBonus(string statKey)
    {
        StatKey = statKey;
    }
    public void Bonus(Personaje player, Personaje rival)
    {
        rival.bonus_neutralizados.Add(StatKey);
    }
}
public class AtkUp : StatEffectPlayer
{
    public AtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class SpdUp : StatEffectPlayer
{
    public SpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class DefUp : StatEffectPlayer
{
    public DefUp(int cantidad) : base("Def", cantidad) { }
}
public class ResUp : StatEffectPlayer
{
    public ResUp(int cantidad) : base("Res", cantidad) { }
}
public class RivalAtkUp : StatEffectRival
{
    public RivalAtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class RivalSpdUp : StatEffectRival
{
    public RivalSpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class RivalDefUp : StatEffectRival
{
    public RivalDefUp(int cantidad) : base("Def", cantidad) { }
}
public class RivalResUp : StatEffectRival
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

public class AplicarCancelacionPenalty : IEffect
{
    public void Bonus(Personaje player, Personaje rival)
    {
        player.penalty_neutralizados.Add("Atk");
        player.penalty_neutralizados.Add("Spd");
        player.penalty_neutralizados.Add("Def");
        player.penalty_neutralizados.Add("Res");
    }
}
public class Up50Atack: IEffect
{
    public  void Bonus(Personaje player, Personaje rival)
    {
        if (player.bonus_stats.ContainsKey("Atk"))
        {
            player.bonus_stats["Atk"] += (int)Math.Floor(Convert.ToDecimal(player.atk) * 0.5m);
        }
        else
        {
            player.bonus_stats.Add("Atk", (int)Math.Floor(Convert.ToDecimal(player.atk) * 0.5m));
        } 
    }
}

public class Sandstorm : IEffect
{
    public  void Bonus(Personaje player, Personaje rival) //TODO: no considero el caso de multiples sumas al follow 
    {
        player.atk_follow = (int)Math.Floor(Convert.ToDecimal(player.def) * 1.5m) - player.atk;
    }
}

public class EfectoLuna : IEffect
{
    public  void Bonus(Personaje player, Personaje rival)
    {
        rival.habilidad_first_atack.Add("Def");
        rival.habilidad_first_atack.Add("Res");
    }
}

public class HpUp : IEffect
{
    public  void Bonus(Personaje player, Personaje rival)
    {
        player.HP += 15; 
    }
}

