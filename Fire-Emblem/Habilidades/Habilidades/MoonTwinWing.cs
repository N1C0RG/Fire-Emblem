using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class MoonTwinWing : Habilidad
{
    public MoonTwinWing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        agregarEfectos();
    }
    public override void aplicarHabilidad()
    {
        if (condicinoEfectosStat())
        {
            new RivalAtkUp(-5).efecto(jugador, rival);
            new RivalSpdUp(-5).efecto(jugador, rival);
            
        }
        rival.calcularPostEfecto();
        
        if (condicionReduccionDanoPorcentual())
        {
            new ReduccionDanoPorcentualSpd().efecto(jugador, rival);
        }
    }
    public void agregarEfectos()
    {
        if (condicinoEfectosStat())
        {
            efecto.Add(new RivalAtkUp(-5));
            efecto.Add(new RivalSpdUp(-5));
            
        }
        rival.calcularPostEfecto();
        
        if (condicionReduccionDanoPorcentual())
        {
            efecto.Add(new ReduccionDanoPorcentualSpd());
        }
    }


    private bool condicinoEfectosStat()
    {
        bool condicio = new HpMas25().condicionHabilidad(jugador, rival);
        return condicio; 
    }

    private bool condicionReduccionDanoPorcentual()
    {
        bool condicion = (jugador.spd +
                          jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), Stat.Spd.ToString())
                          > rival.spd + rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), 
                              Stat.Spd.ToString()))
                         && new HpMas25().condicionHabilidad(jugador, rival); 
        return condicion; 
    }
}