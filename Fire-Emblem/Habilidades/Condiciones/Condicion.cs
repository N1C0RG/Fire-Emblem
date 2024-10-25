using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public interface ICondicion
{
    public bool condicionHabilidad(Personaje jugador, Personaje rival); 
}

public abstract class CondicionGenerica : ICondicion 
{
    protected CondicionesHabilidadEncapsuladas condicion = new CondicionesHabilidadEncapsuladas();
    public abstract bool condicionHabilidad(Personaje jugador, Personaje rival);
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

public class CondicionTieneVentaja : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneVentajaArma(jugador, rival); 
    }
}

public class HpMas25 : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return Math.Round((double)jugador.HP / jugador.hpOriginal, 2) >= 0.25;
    }
}


public class CondicionHpUp : CondicionGenerica
{
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.tieneHpUp(jugador);
    }
}
