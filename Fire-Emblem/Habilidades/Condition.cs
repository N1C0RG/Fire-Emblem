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

public class ConditionHP75 : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP <= (int)Math.Floor(Convert.ToDecimal(player.hp_original) * 0.75m))
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionMagia : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.weapon == "Magic")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
public class ConditionHP50 : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP <= (int)Math.Floor(Convert.ToDecimal(player.hp_original) * 0.5m))
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionWrath : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP != player.hp_original)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionNoInicia : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.inicia_round == false)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionClose : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.weapon != "Magic" && rival.weapon != "Bow")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
public class ConditionDistant : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.weapon == "Magic" || rival.weapon == "Bow")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionRivalHP75 : Condition
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.HP >= (int)Math.Floor(Convert.ToDecimal(rival.hp_original) * 0.75m))
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
public class ConditionFirstAtk : Condition//TODO: arreglar esto 
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.first_atack == 1)
        {
            player.habilidad_fa = true; 
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionFullVidaRival : Condition//TODO: arreglar esto 
{
    public override bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.hp_original == rival.HP)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}



