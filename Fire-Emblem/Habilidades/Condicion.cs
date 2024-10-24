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
        return condicion.tieneArmaWeapon(jugador, Weapon); 
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
        return condicion.cantidadVidaMenorIgualOriginal(jugador, Hp); 
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
        return condicion.tieneFullVidaRival(rival); 
    }
}
public class CondicionNoVidaCompletaJugador : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneNoVidaCompletaJugador(jugador); 
    }
}
public class CondicionRivalHPvsJugadorHP : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneRivalHPvsJugadorHP(jugador, rival); 
    }
}
public class CondicionRivalHP75 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneRivalHP75(rival); 
    }
}
public class CondicionInicioCombate : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.inicioCombate(jugador); 
    }
}
public class CondicionNoInicia : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return !condicion.inicioCombate(jugador); 
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
        return condicion.tieneChaos(jugador, rival); 
    }
}
public class CondicionClose : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.ataqueClose(rival); 
    }
}
public class CondicionDistant : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.ataqueDistant(rival); 
    }
}
public class CondicionFirstAtk : ICondicion//TODO: arreglar esto 
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        if (jugador.getContadorAtaques() == 1)
        {
            jugador.addHabilidadPrimerAtaque("Atk");
            return true; 
        }
        return false;
    }
}
public class CondicionRivalPrevio : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.esRivalPrevio(jugador, rival); 
    }
}
public class CondicionRivalEsHombre: CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.rivalEsHombre(rival); 
    }
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

public class CondicionTieneVentaja : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneVentajaArma(jugador, rival); 
    }
}

public class CondicionRivalArma : CondicionGenerica
{
    private Armas arma; 
    public CondicionRivalArma(Armas arma)
    {
        this.arma = arma; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneArmaWeapon(rival, arma.ToString()); 
    }
}

public class CondicionRivalNoTienArma : CondicionGenerica
{
    private Armas arma; 
    public CondicionRivalNoTienArma(Armas arma)
    {
        this.arma = arma; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return !condicion.tieneArmaWeapon(rival, arma.ToString()); 
    }
}


public class CondicionNoTienArma : CondicionGenerica
{
    private Armas arma; 
    public CondicionNoTienArma(Armas arma)
    {
        this.arma = arma; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return !condicion.tieneArmaWeapon(jugador, arma.ToString()); 
    }
}

public class CondicionFullVidaJugador : CondicionGenerica 
{
    //TODO: meter esta logica en el encapsulado 
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return jugador.HP == jugador.hpOriginal; 
    }
}

public class CondicionRivalHP50 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return rival.HP >= (int)Math.Floor(Convert.ToDecimal(rival.getHpOriginal()) * 0.5m); 
    }
}

public class HpMas25 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return Math.Round((double)jugador.HP / jugador.hpOriginal, 2) >= 0.25;
    }
}

public class JugadorMasSpd : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return jugador.spd > rival.spd; 
    }
}
