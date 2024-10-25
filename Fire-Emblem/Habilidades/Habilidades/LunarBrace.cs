using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class LunarBrace : Habilidad
{
    public LunarBrace(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {
        if (cumpleCondiciones())
        {
            new EfectoDanoExtra(calcularDanoExtra()).efecto(jugador, rival);
        }
    }
    private int calcularDanoExtra()
    {
        int def = rival.dataHabilidadStats.postEfecto.ContainsKey(Stat.Def.ToString()) ? rival.def + rival.dataHabilidadStats.postEfecto[Stat.Def.ToString()] : rival.def; 

        return (int)(def * 0.3m); 
    }
    private bool cumpleCondiciones()
    {
        bool condicion = new CondicionInicioCombate().condicionHabilidad(jugador, rival) &&
                         new NoTieneMagic().condicionHabilidad(jugador, rival);
        return condicion; 
    }

}