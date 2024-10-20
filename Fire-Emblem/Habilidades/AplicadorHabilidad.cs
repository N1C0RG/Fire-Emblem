namespace Fire_Emblem.Habilidades;

public class AplicadorHabilidad
{
    private Habilidad _habilidad;
    private Habilidad _habilidadSegundaCondicion;

    public AplicadorHabilidad(Habilidad habilidad, Habilidad habilidadSegundaCondicion = null)
    {
        _habilidad = habilidad;
        _habilidadSegundaCondicion = habilidadSegundaCondicion;
    }

    public void aplicarHabilidad()
    {
        _habilidad.aplicarHabilidad();
        if (_habilidadSegundaCondicion != null)
        {
            _habilidadSegundaCondicion.aplicarHabilidad();
        }
    }
}