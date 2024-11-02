using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class Ignis : Habilidad
{
    public Ignis(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        
        rival.addDataHabilidadStat(
            NombreDiccionario.primerAtaqueBonus.ToString(), Stat.Atk.ToString(), calcularAtk()); 
    }
    private int calcularAtk()
    {
        return (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 1.5m);
    }
    
}