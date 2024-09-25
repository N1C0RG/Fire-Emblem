namespace Fire_Emblem.Habilidades;
public interface IEffect
{
    public void Bonus(Personaje player, Personaje rival, int aumento); 
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

    public void Bonus(Personaje player, Personaje rival, int aumento)
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
    public void Bonus(Personaje player, Personaje rival, int aumento)
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

public abstract class NeutralizacionBonus : IEffect
{
    protected string StatKey;
    protected NeutralizacionBonus(string statKey)
    {
        StatKey = statKey;
    }
    public void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.bonus_stats.ContainsKey(StatKey))
        {
            rival.bonus_stats[StatKey] = 0;
        }
        rival.bonus_neutralizados.Add(StatKey);
    }
}
public abstract class NeutralizacionPenalty : IEffect
{
    protected string StatKey;
    protected NeutralizacionPenalty(string statKey)
    {
        StatKey = statKey;
    }
    public void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.penalty_stats.ContainsKey(StatKey))
        {
            player.penalty_stats[StatKey] = 0;
        }
        player.penalty_neutralizados.Add(StatKey);
    }
}

//TODO: en vez de hacer que cada una se encargue para una cantidad especifica de un stat hago que reciban un valor 
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

public class FairAtkdUp : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Atk"))
        {
            player.bonus_stats["Atk"] += aumento;
        }
        else
        {
            player.bonus_stats.Add("Atk", aumento);
        } 
        if (rival.bonus_stats.ContainsKey("Atk"))
        {
            rival.bonus_stats["Atk"] += aumento;
        }
        else
        {
            rival.bonus_stats.Add("Atk", aumento);
        } 
    }
}

public class PerceptiveSpddUp : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Spd"))
        {
            player.bonus_stats["Spd"] += aumento + (player.spd / 4);
        }
        else
        {
            player.bonus_stats.Add("Spd", aumento + (player.spd / 4));
        } 
    }
}

public class WrathAtkUp : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        int bonus = player.hp_original - player.HP;
        if (bonus > 30)
        {
            bonus = 30; 
        }
        if (player.bonus_stats.ContainsKey("Atk"))
        {
            player.bonus_stats["Atk"] += aumento + bonus;
        }
        else
        {
            player.bonus_stats.Add("Atk", aumento + bonus);
        } 
        if (player.bonus_stats.ContainsKey("Spd"))
        {
            player.bonus_stats["Spd"] += aumento + bonus;
        }
        else
        {
            player.bonus_stats.Add("Spd", aumento + bonus);
        } 
    }
}

public class Neutralizapenalty : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        
        foreach (var i in player.bonus_stats)
        {
            if (i.Value < 0)
            {
                player.bonus_stats[i.Key] = 0; 
            }
        }
    }
}

public class CancelAtk : NeutralizacionBonus
{
    public CancelAtk() : base("Atk") { }
}
public class CancelDef : NeutralizacionBonus
{
    public CancelDef() : base("Def") { }
}
public class CancelRes : NeutralizacionBonus
{
    public CancelRes() : base("Res") { }
}
public class CancelSpd : NeutralizacionBonus
{
    public CancelSpd() : base("Spd") { }
}
public class CancelPenaltyAtk : NeutralizacionPenalty
{
    public CancelPenaltyAtk() : base("Atk") { }
}
public class CancelPenaltyDef : NeutralizacionPenalty
{
    public CancelPenaltyDef() : base("Def") { }
}
public class CancelarPenaltyRes : NeutralizacionPenalty
{
    public CancelarPenaltyRes() : base("Res") { }
}
public class CancelPenaltySpd : NeutralizacionPenalty
{
    public CancelPenaltySpd() : base("Spd") { }
}

//TODO: no es un efecto 
public class AplicarCancelacion : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        rival.bonus_neutralizados.Add("Atk");
        rival.bonus_neutralizados.Add("Spd");
        rival.bonus_neutralizados.Add("Def");
        rival.bonus_neutralizados.Add("Res");
    }
}
public class AplicarCancelacionPenalty : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.penalty_neutralizados.Add("Atk");
        player.penalty_neutralizados.Add("Spd");
        player.penalty_neutralizados.Add("Def");
        player.penalty_neutralizados.Add("Res");
    }
}

public class Up50Atack: IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
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
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.atk_follow = (int)Math.Floor(Convert.ToDecimal(player.def) * 1.5m) - player.atk;
        
    }
}

public class SandstormNeutraliza : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.atk_follow > 0)
        {
            rival.atk_follow = 0;
        }
        
    }
}

public class HpUp : IEffect
{
    public  void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.HP += 15; 
    }
}

