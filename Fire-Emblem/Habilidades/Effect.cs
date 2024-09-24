using Fire_Emblem_View;

namespace Fire_Emblem.Habilidades;
public abstract class Effect
{
    public abstract void Bonus(Personaje player, Personaje rival, int aumento); 
}

//TODO: en vez de hacer que cada una se encargue para una cantidad especifica de un stat hago que reciban un valor 
public class AtkUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Atk"))
        {
            player.bonus_stats["Atk"] += aumento;
        }
        else
        {
            player.bonus_stats.Add("Atk", aumento);
        } 
    }
}
public class DefUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Def"))
        {
            player.bonus_stats["Def"] += aumento;
        }
        else
        {
            player.bonus_stats.Add("Def", aumento);
        } 
    }
}

public class ResUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Res"))
        {
            player.bonus_stats["Res"] += aumento;
        }
        else
        {
            player.bonus_stats.Add("Res", aumento);
        } 
    }
}
public class SpdUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (player.bonus_stats.ContainsKey("Spd"))
        {
            player.bonus_stats["Spd"] += aumento;
        }
        else
        {
            player.bonus_stats.Add("Spd", aumento);
        } 
    }
}

public class FairAtkdUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
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

public class PerceptiveSpddUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
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

public class WrathAtkUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
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
public class NeutralizaBonus : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        
        foreach (var i in rival.bonus_stats)
        {
            if (i.Value > 0)
            {
                rival.bonus_stats[i.Key] = 0; 
            }
        }
    }
}
public class Neutralizapenalty : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
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

public class CancelAtk : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.bonus_stats["Atk"] > 0)
        {
            rival.bonus_stats["Atk"] = 0; 
        }
        rival.bonus_neutralizados.Add("Atk");
    }
}
public class CancelDef : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {

        if (rival.bonus_stats["Def"] > 0)
        {
            rival.bonus_stats["Def"] = 0; 
        }
        rival.bonus_neutralizados.Add("Def");
    }
}
public class CancelRes : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {

        if (rival.bonus_stats["Res"] > 0)
        {
            rival.bonus_stats["Res"] = 0; 
        }
        rival.bonus_neutralizados.Add("Res");
    }
}
public class CancelSpd : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {

        if (rival.bonus_stats["Spd"] > 0)
        {
            rival.bonus_stats["Spd"] = 0; 
        }
        rival.bonus_neutralizados.Add("Spd");
    }
}




//TODO: no es un efecto 
public class AplicarCancelacion : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        rival.bonus_neutralizados.Add("Atk");
        rival.bonus_neutralizados.Add("Spd");
        rival.bonus_neutralizados.Add("Def");
        rival.bonus_neutralizados.Add("Res");
    }
}
public class AplicarCancelacionPenalty : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.penalty_neutralizados.Add("Atk");
        player.penalty_neutralizados.Add("Spd");
        player.penalty_neutralizados.Add("Def");
        player.penalty_neutralizados.Add("Res");
    }
}

public class Up50Atack: Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
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

public class Sandstorm : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.atk_follow = (int)Math.Floor(Convert.ToDecimal(player.def) * 1.5m) - player.atk;
        
    }
}

public class SandstormNeutraliza : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.atk_follow > 0)
        {
            rival.atk_follow = 0;
        }
        
    }
}

public class HpUp : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        player.HP += 15; 
    }
}

public class RivalAtkDown : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
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
public class RivalDefDown : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.bonus_stats.ContainsKey("Def"))
        {
            rival.bonus_stats["Def"] += aumento;
        }
        else
        {
            rival.bonus_stats.Add("Def", aumento);
        } 
    }
}
public class RivalSpdDown : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.bonus_stats.ContainsKey("Spd"))
        {
            rival.bonus_stats["Spd"] += aumento;
        }
        else
        {
            rival.bonus_stats.Add("Spd", aumento);
        } 
    }
}
public class RivalResDown : Effect
{
    public override void Bonus(Personaje player, Personaje rival, int aumento)
    {
        if (rival.bonus_stats.ContainsKey("Res"))
        {
            rival.bonus_stats["Res"] += aumento;
        }
        else
        {
            rival.bonus_stats.Add("Res", aumento);
        } 
    }
}

