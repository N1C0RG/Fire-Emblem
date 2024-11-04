using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class Ignis : Habilidad
{
    public Ignis(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        EfectoStatPrimerAtaque efectoIgnis = new EfectoStatPrimerAtaque(Stat.Atk.ToString(), calcularAtk());
        efecto.Add(efectoIgnis); 
    }
    public override void aplicarHabilidad()
    {
        // jugador.addDataHabilidadStat(
        //     NombreDiccionario.primerAtaqueBonus.ToString(), Stat.Atk.ToString(), calcularAtk()); 
        EfectoStatPrimerAtaque efectoIgnis = new EfectoStatPrimerAtaque(Stat.Atk.ToString(), calcularAtk());
        efecto.Add(efectoIgnis); 
    }
    private int calcularAtk()
    {
        return (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m);
    }
    
}