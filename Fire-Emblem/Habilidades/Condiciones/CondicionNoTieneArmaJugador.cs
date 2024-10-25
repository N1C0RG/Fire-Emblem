namespace Fire_Emblem.Habilidades;

public abstract class CondicionNoTieneArmaJugador : CondicionGenerica
{
    protected string arma;
    protected CondicionNoTieneArmaJugador(string arma)
    {
        this.arma = arma;
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return !condicion.tieneArmaWeapon(jugador, arma);
    }
}

public class NoTieneMagic : CondicionNoTieneArmaJugador
{
    public NoTieneMagic() : base(Armas.Magic.ToString()){}
}


