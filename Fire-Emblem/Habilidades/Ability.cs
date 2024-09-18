namespace Fire_Emblem.Habilidades;

public class Ability<TipoEfecto, TipoCondicion> 
    where TipoCondicion : Condition
    where TipoEfecto : Effect
{
    public TipoEfecto efecto;
    public TipoCondicion condicion;
    public Personaje jugador;
    public Personaje rival; 
    public Ability(TipoEfecto efecto, TipoCondicion condicion, Personaje jugador, Personaje rival)
    {
        this.efecto = efecto;
        this.condicion = condicion;
        this.jugador = jugador;
        this.rival = rival; 
    }

    public void Aplicar()
    {
        if (condicion.CondicionHabilidad(jugador))
        {
            efecto.Bonus(jugador); 
        }
    }
}