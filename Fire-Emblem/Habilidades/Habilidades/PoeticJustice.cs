using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class PoeticJustice : Habilidad
{
    public PoeticJustice(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        new RivalSpdUp(-4).efecto(jugador, rival);
        new EfectoDanoExtra(calcularDanoExtra()).efecto(jugador, rival);
        
    }
    private int calcularDanoExtra()
    {
        int cantidad = (int)(calcularAtaqueRival() * 0.15);
        return cantidad; 
    }
    private int calcularAtaqueRival()
    {
        int cantiadad = rival.atk + rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            Stat.Atk.ToString());
        return cantiadad; 
    }

}