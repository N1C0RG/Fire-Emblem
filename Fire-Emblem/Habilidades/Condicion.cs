namespace Fire_Emblem.Habilidades;

public interface ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival); 
}
public abstract class CondicionArma : ICondicion
{
    protected string Weapon; 
    protected CondicionArma(string weapon)
    {
        Weapon = weapon; 
    }
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.weapon == Weapon)
        {
            return true; 
        }
        return false;
    }
}
public abstract class CondicionVida : ICondicion
{
    protected decimal Hp; 
    protected CondicionVida(decimal hp)
    {
        Hp = hp; 
    }
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP <= (int)Math.Floor(Convert.ToDecimal(player.hp_original) * Hp))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionSword : CondicionArma
{
    public CondicionSword() : base("Sword"){}
}
public class CondicionLance : CondicionArma
{
    public CondicionLance() : base("Lance"){}
}
public class CondicionAxe : CondicionArma
{
    public CondicionAxe() : base("Axe"){}
}
public class CondicionBow : CondicionArma
{
    public CondicionBow() : base("Bow"){}
}
public class CondicionMagic : CondicionArma
{
    public CondicionMagic() : base("Magic"){}
}
public class HpMenos75 : CondicionVida
{
    public HpMenos75() : base(0.75m){}
}
public class HpMenos50 : CondicionVida
{
    public HpMenos50() : base(0.5m){}
}
public class HpMenos80 : CondicionVida
{
    public HpMenos80() : base(0.8m){}
}
public class CondicionFullVidaRival : ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.hp_original == rival.HP)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionNotFullVidaPlayer : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP != player.hp_original)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHPvsPlayerHP : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.HP >= rival.HP + 3)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHP75 : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.HP >= (int)Math.Floor(Convert.ToDecimal(rival.hp_original) * 0.75m))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionInicioCombate : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.inicia_round)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionNoInicia : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.inicia_round == false)
        {
            return true; 
        }
        return false;
    }
}
public class NoHayCondicion : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        return true; 
    }
}
public class CondicionChaos : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if ((player.weapon != "Magic" && rival.weapon == "Magic") ||
            (rival.weapon != "Magic" && player.weapon == "Magic"))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionClose : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.weapon != "Magic" && rival.weapon != "Bow")
        {
            return true; 
        }
        return false;
    }
}
public class CondicionDistant : ICondicion
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.weapon == "Magic" || rival.weapon == "Bow")
        {
            return true; 
        }
        return false;
    }
}
public class CondicionFirstAtk : ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.first_atack == 1)
        {
            player.habilidad_first_atack.Add("Atk"); 
            return true; 
        }
        return false;
    }
}
public class CondicionPreviousRival : ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (player.oponente_previo == rival.name)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalEsHombre: ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje player, Personaje rival)
    {
        if (rival.gender == "Male")
        {
            return true; 
        }
        return false;
    }
}





