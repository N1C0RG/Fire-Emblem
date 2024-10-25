namespace Fire_Emblem.Habilidades;

public class CondicionNoTieneArmaRival : CondicionGenerica
{
    protected string arma;
    
    protected CondicionNoTieneArmaRival(string arma)
    {
        this.arma = arma;
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        return !condicion.tieneArmaWeapon(rival, arma);
    }
}

public class NoTieneMagicRival : CondicionNoTieneArmaRival
{
    public NoTieneMagicRival() : base(Armas.Magic.ToString()){}
}


