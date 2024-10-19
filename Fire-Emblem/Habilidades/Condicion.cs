using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public interface ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival); 
}

//TOOD: cambiar el nombre de esta clase
public abstract class CondicionGenerica : ICondicion 
{
    protected CondicionesHabilidadEncapsuladas condicion = new CondicionesHabilidadEncapsuladas();
    public abstract bool condicionHabilidad(Personaje jugador, Personaje rival);
}

public abstract class CondicionArma : CondicionGenerica
{
    protected string Weapon; 
    protected CondicionArma(string weapon)
    {
        Weapon = weapon; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneArmaWeapon(jugador, Weapon))
        {
            return true; 
        }
        return false;
    }
}
public abstract class CondicionVida : CondicionGenerica
{
    protected decimal Hp; 
    protected CondicionVida(decimal hp)
    {
        Hp = hp; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.cantidadVidaMenorIgualOriginal(jugador, Hp))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionSword : CondicionArma
{
    public CondicionSword() : base(Armas.Sword.ToString()){}
}
public class CondicionLance : CondicionArma
{
    public CondicionLance() : base(Armas.Lance.ToString()){}
}
public class CondicionAxe : CondicionArma
{
    public CondicionAxe() : base(Armas.Axe.ToString()){}
}
public class CondicionBow : CondicionArma
{
    public CondicionBow() : base(Armas.Bow.ToString()){}
}
public class CondicionMagic : CondicionArma
{
    public CondicionMagic() : base(Armas.Magic.ToString()){}
}
public class HpMenos75 : CondicionVida
{
    public HpMenos75() : base(TipoVida.Values["Hp75%"]){}
}
public class HpMenos50 : CondicionVida
{
    public HpMenos50() : base(TipoVida.Values["Hp50%"]){}
}
public class HpMenos80 : CondicionVida
{
    public HpMenos80() : base(TipoVida.Values["Hp80%"]){}
}
public class CondicionFullVidaRival : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneFullVidaRival(rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionNoVidaCompletaJugador : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneNoVidaCompletaJugador(jugador))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHPvsJugadorHP : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneRivalHPvsJugadorHP(jugador, rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalHP75 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneRivalHP75(rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionInicioCombate : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.inicioCombate(jugador))
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
public class CondicionChaos : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.tieneChaos(jugador, rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionClose : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.ataqueClose(rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionDistant : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.ataqueDistant(rival))
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
public class CondicionRivalPrevio : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.esRivalPrevio(jugador, rival))
        {
            return true; 
        }
        return false;
    }
}
public class CondicionRivalEsHombre: CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (condicion.rivalEsHombre(rival))
        {
            return true; 
        }
        return false;
    }
}





