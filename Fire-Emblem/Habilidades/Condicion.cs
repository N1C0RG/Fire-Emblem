namespace Fire_Emblem.Habilidades;

public interface ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival); 
}
public abstract class CondicionArma : ICondicion
{
    protected string Weapon; 
    protected CondicionArma(string weapon)
    {
        Weapon = weapon; 
    }
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.weapon == Weapon)
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
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.HP <= (int)Math.Floor(Convert.ToDecimal(jugador.hp_original) * Hp))
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
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (rival.hp_original == rival.HP)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionNoVidaCompletaJugador : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.HP != jugador.hp_original)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHPvsJugadorHP : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.HP >= rival.HP + 3)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHP75 : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
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
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.inicia_round)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionNoInicia : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.inicia_round == false)
        {
            return true; 
        }
        return false;
    }
}
public class NoHayCondicion : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return true; 
    }
}
public class CondicionChaos : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if ((jugador.weapon != "Magic" && rival.weapon == "Magic") ||
            (rival.weapon != "Magic" && jugador.weapon == "Magic"))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionClose : ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
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
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
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
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.first_atack == 1)
        {
            jugador.habilidad_first_atack.Add("Atk"); 
            return true; 
        }
        return false;
    }
}
public class CondicionRivalPrevio : ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.oponente_previo == rival.name)
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalEsHombre: ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (rival.gender == "Male")
        {
            return true; 
        }
        return false;
    }
}





