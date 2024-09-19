namespace Fire_Emblem.Habilidades;

public abstract class Condition
{
    public abstract bool CondicionHabilidad(Personaje player); 
}

public class ConditionInicioCombate : Condition
{
    public override bool CondicionHabilidad(Personaje player)
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
    public override bool CondicionHabilidad(Personaje player)
    {
        return true; 
    }
}

public class ConditionVida80 : Condition
{
    public override bool CondicionHabilidad(Personaje player)
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