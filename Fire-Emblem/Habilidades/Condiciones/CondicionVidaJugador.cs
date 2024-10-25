namespace Fire_Emblem.Habilidades;

public abstract class CondicionVidaJugador : CondicionGenerica
{
    protected decimal Hp; 
    protected CondicionVidaJugador(decimal hp)
    {
        Hp = hp; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return condicion.cantidadVidaMenorIgualOriginal(jugador, Hp); 
    }
}

public class HpMenos75 : CondicionVidaJugador
{
    public HpMenos75() : base(TipoVida.Values["Hp75%"]){}
}
public class HpMenos50 : CondicionVidaJugador
{
    public HpMenos50() : base(TipoVida.Values["Hp50%"]){}
}
public class HpMenos80 : CondicionVidaJugador
{
    public HpMenos80() : base(TipoVida.Values["Hp80%"]){}
}