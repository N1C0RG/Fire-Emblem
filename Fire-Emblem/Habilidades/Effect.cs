namespace Fire_Emblem.Habilidades;
public abstract class Effect
{
    public abstract void Bonus(Personaje player); 
}

public class Def8Up : Effect
{
    public override void Bonus(Personaje player)
    {
        if (player.bonus_stats.ContainsKey("Def"))
        {
            player.bonus_stats["Def"] += 8;
        }
        else
        {
            player.bonus_stats.Add("Def", 8);
        }
    }
    
}
public class Def5Up : Effect
{
    public override void Bonus(Personaje player)
    {
        if (player.bonus_stats.ContainsKey("Def"))
        {
            player.bonus_stats["Def"] += 5;
        }
        else
        {
            player.bonus_stats.Add("Def", 5);
        }
    }
    
}
public class Atk5Up : Effect
{
    public override void Bonus(Personaje player)
    {
        if (player.bonus_stats.ContainsKey("Atk"))
        {
            player.bonus_stats["Atk"] += 5;
        }
        else
        {
            player.bonus_stats.Add("Atk", 5);
        } 
    }
    
}
