namespace Fire_Emblem.Habilidades;

public class CondicionRivalHp
{
    
}

public class CondicionRivalHP50 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return rival.HP >= (int)Math.Floor(Convert.ToDecimal(rival.getHpOriginal()) * 0.5m); 
    }
}
public class CondicionRivalHP75 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneRivalHP75(rival); 
    }
}