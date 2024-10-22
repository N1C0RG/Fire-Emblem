namespace Fire_Emblem.Habilidades;

public class Habilidad 
{
    public List<IEfecto> efecto;
    public List<ICondicion> condicion;
    public Personaje jugador;
    public Personaje rival;
    private bool cumple_todas_condicion = true;
    public Habilidad(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
    {
        this.efecto = efecto;
        this.condicion = condicion;
        this.jugador = jugador;
        this.rival = rival;
    }

    public void aplicarHabilidad()
    {
        foreach (var i in  condicion)
        {
            if (i.condicionHabilidad(jugador, rival) == false)
            {
                cumple_todas_condicion = false; 
            }
        }

        if (cumple_todas_condicion)
        {
            foreach (var i in efecto)
            {
                i.efecto(jugador, rival);
            }
        }
    }
    
}


public class HabilidadesPostEfectosNormales : Habilidad
{
    public HabilidadesPostEfectosNormales(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival) : base(efecto, condicion, jugador, rival)
    {
    }
}