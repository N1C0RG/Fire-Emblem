namespace Fire_Emblem.Habilidades;

public class GuardBearing : Habilidad
{
    public GuardBearing(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }
    public override void aplicarHabilidad()
    {

        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);
        
        if ((jugador.primerCombateInicia == false && new CondicionInicioCombate().condicionHabilidad(jugador, rival)) ||
            (jugador.primeraVexDefiende == false && new CondicionNoInicia().condicionHabilidad(jugador, rival)))
        {
            new ReduccionDanoPorcentual(0.6m).efecto(jugador, rival);
        }
        else
        {
            new ReduccionDanoPorcentual(0.3m).efecto(jugador, rival); 
        }
    }
}