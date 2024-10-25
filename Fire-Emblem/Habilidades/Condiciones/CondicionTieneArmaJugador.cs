namespace Fire_Emblem.Habilidades;

public abstract class CondicionTieneArmaJugador : CondicionGenerica
{
    protected string Weapon; 
    protected CondicionTieneArmaJugador(string weapon)
    {
        Weapon = weapon; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneArmaWeapon(jugador, Weapon); 
    }
}

public class CondicionSword : CondicionTieneArmaJugador
{
    public CondicionSword() : base(Armas.Sword.ToString()){}
}
public class CondicionLance : CondicionTieneArmaJugador
{
    public CondicionLance() : base(Armas.Lance.ToString()){}
}
public class CondicionAxe : CondicionTieneArmaJugador
{
    public CondicionAxe() : base(Armas.Axe.ToString()){}
}
public class CondicionBow : CondicionTieneArmaJugador
{
    public CondicionBow() : base(Armas.Bow.ToString()){}
}
public class CondicionMagic : CondicionTieneArmaJugador
{
    public CondicionMagic() : base(Armas.Magic.ToString()){}
}
