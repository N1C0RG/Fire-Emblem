namespace Fire_Emblem.Habilidades;

public class CondicionStatJugadorVsRival
{
    
}

public class CondicionSpdDanoPorcentual: CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return jugador.spd > rival.spd; 
    }
}


public class CondicionResDanoPorcentual: CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return jugador.res > rival.res; 
    }
}
