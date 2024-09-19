namespace Fire_Emblem.Habilidades;
public abstract class Effect
{
    public abstract void Bonus(Personaje player, int aumento); 
}

// public class Def8Up : Effect
// {
//     public override void Bonus(Personaje player)
//     {
//         if (player.bonus_stats.ContainsKey("Def"))
//         {
//             player.bonus_stats["Def"] += 8;
//         }
//         else
//         {
//             player.bonus_stats.Add("Def", 8);
//         }
//     }
//     
// }
// public class Def5Up : Effect
// {
//     public override void Bonus(Personaje player)
//     {
//         if (player.bonus_stats.ContainsKey("Def"))
//         {
//             player.bonus_stats["Def"] += 5;
//         }
//         else
//         {
//             player.bonus_stats.Add("Def", 5);
//         }
//     }
//     
// }
// public class Atk5Up : Effect
// {
//     public override void Bonus(Personaje player)
//     {
//         if (player.bonus_stats.ContainsKey("Atk"))
//         {
//             player.bonus_stats["Atk"] += 5;
//         }
//         else
//         {
//             player.bonus_stats.Add("Atk", 5);
//         } 
//     }
// }
//TODO: en vez de hacer que cada una se encargue para una cantidad especifica de un stat hago que reciban un valor 
public class AtkUp : Effect
{
    public override void Bonus(Personaje player, int aumento)
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
    public override void Bonus(Personaje player, int aumento)
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
    public override void Bonus(Personaje player, int aumento)
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
    public override void Bonus(Personaje player, int aumento)
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