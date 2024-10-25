namespace Fire_Emblem.Habilidades;

public class CondicionFullVida
{
    
}

public class CondicionFullVidaJugador : CondicionGenerica 
{
    //TODO: meter esta logica en el encapsulado 
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return jugador.HP == jugador.hpOriginal; 
    }
}

public class CondicionFullVidaRival : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneFullVidaRival(rival); 
    }
}