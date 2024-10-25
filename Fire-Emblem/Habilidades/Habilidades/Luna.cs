using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class Luna: Habilidad
{
    public Luna(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        new RivalDefUp(-calcularDef()).efecto(jugador, rival);
        new RivalResUp(-calcularRes()).efecto(jugador, rival);
        
        rival.habilidadPrimerAtaque.Add(Stat.Def.ToString()); 
        rival.habilidadPrimerAtaque.Add(Stat.Res.ToString());
    }
    private int calcularRes()
    {
        return (int)Math.Floor(Convert.ToDecimal(rival.res) * 0.5m);
    }

    private int calcularDef()
    {
        return (int)Math.Floor(Convert.ToDecimal(rival.def) * 0.5m);
    }
}