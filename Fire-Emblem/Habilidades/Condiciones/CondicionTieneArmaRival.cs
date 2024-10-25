namespace Fire_Emblem.Habilidades;

public abstract class CondicionTieneArmaRival : CondicionGenerica
{
    protected string Weapon;
    protected CondicionTieneArmaRival(string weapon)
    {
        Weapon = weapon;
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneArmaWeapon(rival, Weapon);
    }
}

public class CondicionRivalSword : CondicionTieneArmaRival
{
    public CondicionRivalSword() : base(Armas.Sword.ToString()){}
}

public class CondicionRivalAxe : CondicionTieneArmaRival
{
    public CondicionRivalAxe() : base(Armas.Axe.ToString()){}
}

public class CondicionRivalLance : CondicionTieneArmaRival
{
    public CondicionRivalLance() : base(Armas.Lance.ToString()){}
}

public class CondicionRivalMagic : CondicionTieneArmaRival
{
    public CondicionRivalMagic() : base(Armas.Magic.ToString()){}
}

public class CondicionRivalBow : CondicionTieneArmaRival
{
    public CondicionRivalBow() : base(Armas.Bow.ToString()){}
}

