namespace Fire_Emblem.Habilidades;

public abstract class Condition
{
    public abstract bool CondicionHabilidad(Personaje player, Personaje rival); 
}

public class ConditionInicioCombate : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.inicia_round == true)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionNula : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        return true; 
    }
}

public class ConditionVida80 : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if ((int)Math.Floor(Convert.ToDecimal(player.hp_original) * 0.8m) >= player.HP)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionChaos : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if ((player.weapon != "Magic" && rival.weapon == "Magic") ||
            (rival.weapon != "Magic" && player.weapon == "Magic"))
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionEspada : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.weapon == "Sword")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionRivalHPvsPlayerHP : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP >= rival.HP + 3)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}