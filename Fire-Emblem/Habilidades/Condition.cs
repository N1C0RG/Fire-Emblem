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