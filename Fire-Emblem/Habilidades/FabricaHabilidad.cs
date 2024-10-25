namespace Fire_Emblem.Habilidades;

public abstract class FabricaHabilidad 
{
    protected string _nombre_habilidad;
    protected Personaje _jugador;
    protected Personaje _rival;
    protected Habilidad _habilidad;

    public FabricaHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival)
    {
        _nombre_habilidad = nombreHabilidad;
        _jugador = jugador;
        _rival = rival;
    }

    public AplicadorEfectoHabilidad crearAplicador()
    {
        return new AplicadorEfectoHabilidad(_habilidad);
    }

    public abstract void crearHabilidad();
}