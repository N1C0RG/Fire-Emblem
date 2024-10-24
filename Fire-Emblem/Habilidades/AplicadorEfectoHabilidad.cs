namespace Fire_Emblem.Habilidades;

public class AplicadorEfectoHabilidad
{
    private Habilidad _habilidad;
    private Habilidad _habilidadSegundaCondicion;
    private Habilidad _habilidadTerceraCondicion;

    public AplicadorEfectoHabilidad(Habilidad habilidad, Habilidad habilidadSegundaCondicion = null, Habilidad habilidadTerceraCondicion = null)
    {
        _habilidad = habilidad;
        _habilidadSegundaCondicion = habilidadSegundaCondicion;
        _habilidadTerceraCondicion = habilidadTerceraCondicion; 
    }

    public void aplicarHabilidad()
    {
        _habilidad.aplicarHabilidad();
        if (_habilidadSegundaCondicion != null)
        {
            _habilidadSegundaCondicion.aplicarHabilidad();
        }
        if (_habilidadTerceraCondicion != null)
        {
            _habilidadTerceraCondicion.aplicarHabilidad();
        }
    }
}