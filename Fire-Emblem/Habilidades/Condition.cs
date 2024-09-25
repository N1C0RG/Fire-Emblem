namespace Fire_Emblem.Habilidades;

public interface ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival); 
}

public abstract class CondicionArma : ICondition
{
    protected string Weapon; 
    protected CondicionArma(string weapon)
    {
        Weapon = weapon; 
    }
    public bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.weapon == Weapon)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
public class ConditionSword : CondicionArma
{
    public ConditionSword() : base("Sword"){}
}
public class ConditionLance : CondicionArma
{
    public ConditionLance() : base("Lance"){}
}
public class ConditionAxe : CondicionArma
{
    public ConditionAxe() : base("Axe"){}
}
public class ConditionBow : CondicionArma
{
    public ConditionBow() : base("Bow"){}
}
public class ConditionMagic : CondicionArma
{
    public ConditionMagic() : base("Magic"){}
}



public class ConditionInicioCombate : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.inicia_round)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}

public class ConditionNula : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        return true; 
    }
}

public class ConditionVida80 : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionChaos : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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


public class ConditionRivalHPvsPlayerHP : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionHP75 : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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


public class ConditionHP50 : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionWrath : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionNoInicia : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionClose : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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
public class ConditionDistant : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionRivalHP75 : ICondition
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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
public class ConditionFirstAtk : ICondition//TODO: arreglar esto 
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionFullVidaRival : ICondition//TODO: arreglar esto 
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
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

public class ConditionPreviousRival : ICondition//TODO: arreglar esto 
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.oponente_previo == rival.name)
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
public class ConditionRivalEsHombre: ICondition//TODO: arreglar esto 
{
    public bool CondicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.gender == "Male")
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}





