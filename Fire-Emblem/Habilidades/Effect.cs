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