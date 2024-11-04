namespace Fire_Emblem.Habilidades;

public class GuardBearing : Habilidad
{
    public GuardBearing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        agregarEfectos();
    }
    public override void aplicarHabilidad()
    {

        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);
        
        if (condicionHabilidad())
        {
            new ReduccionDanoPorcentual(0.6m).efecto(jugador, rival);
        }
        else
        {
            new ReduccionDanoPorcentual(0.3m).efecto(jugador, rival); 
        }
    }

    private void agregarEfectos()
    {
        var e = new RivalSpdUp(-4);
        var e2 = new RivalDefUp(-4);
        efecto.Add(e);
        efecto.Add(e2);
        if (condicionHabilidad())
        {
            efecto.Add(new ReduccionDanoPorcentual(0.6m));
        }
        else
        {
            efecto.Add(new ReduccionDanoPorcentual(0.3m)); 
        }
    } 

    private bool condicionHabilidad()
    {
        bool condicion = (jugador.primerCombateInicia == false &&
                          new CondicionInicioCombate().condicionHabilidad(jugador, rival)) ||
                         (jugador.primeraVexDefiende == false &&
                          new CondicionNoInicia().condicionHabilidad(jugador, rival));
        return condicion; 
    }
}