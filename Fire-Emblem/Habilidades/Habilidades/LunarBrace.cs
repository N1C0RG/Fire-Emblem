using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class LunarBrace : Habilidad
{
    public LunarBrace(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        agregarEfecto();
    }
    public void agregarEfecto()
    {
        if (cumpleCondiciones())
        {
            efecto.Add(new EfectoDanoExtra(calcularDanoExtra(), actualizarDanoExtra));
        }
    }
    private int calcularDanoExtra()
    {
        int def = rival.dataHabilidadStats.postEfecto.ContainsKey(Stat.Def.ToString()) ? rival.def + rival.dataHabilidadStats.postEfecto[Stat.Def.ToString()] : rival.def; 

        return (int)(def * 0.3m); 
    }
    private int actualizarDanoExtra()
    {
        int def = rival.def + rival.getDataHabilidadStat(NombreDiccionario.bonusStats.ToString(), Stat.Def.ToString()) + rival.getDataHabilidadStat(NombreDiccionario.penaltyStats.ToString(), Stat.Def.ToString());
        return (int)(def * 0.3m);
    }
    private bool cumpleCondiciones()
    {
        bool condicion = new CondicionInicioCombate().condicionHabilidad(jugador, rival) &&
                         new NoTieneMagic().condicionHabilidad(jugador, rival);
        return condicion; 
    }

}