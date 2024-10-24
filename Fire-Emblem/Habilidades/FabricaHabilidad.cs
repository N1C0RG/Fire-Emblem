namespace Fire_Emblem.Habilidades;

public abstract class FabricaHabilidad 
{
    protected string _nombre_habilidad;
    protected Personaje _jugador;
    protected Personaje _rival;
    protected Habilidad _habilidad;
    protected Habilidad _habilidadSegundaCondicion;
    protected Habilidad _habilidadTerceraCondicion;

    public FabricaHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival)
    {
        _nombre_habilidad = nombreHabilidad;
        _jugador = jugador;
        _rival = rival;
    }

    public AplicadorHabilidad crearAplicador()
    {
        return new AplicadorHabilidad(_habilidad, _habilidadSegundaCondicion, _habilidadTerceraCondicion);
    }

    public abstract void crearHabilidad();
}