namespace Fire_Emblem.Habilidades;
using Encapsulado; 
public class Sandstorm : Habilidad
{
    public Sandstorm(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        int ataque = calcularAtaqueFollow(jugador); 
        
        if (ataque > 0)
        {
            jugador.addDataHabilidadStat(NombreDiccionario.followBonus.ToString(), Stat.Atk.ToString(), 
                ataque);
        }
        else if (ataque <  0)
        {
            jugador.addDataHabilidadStat(NombreDiccionario.followPenalty.ToString(), Stat.Atk.ToString(), 
                ataque);        }
    }
    private int calcularAtaqueFollow(Personaje jugador)
     {
         return (int)Math.Floor(Convert.ToDecimal(jugador.def) * 1.5m) - jugador.atk;
     }
}