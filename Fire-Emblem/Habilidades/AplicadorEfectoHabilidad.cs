namespace Fire_Emblem.Habilidades;

public class AplicadorEfectoHabilidad
{
    private Habilidad _habilidad;

    public AplicadorEfectoHabilidad(Habilidad habilidad)
    {
        _habilidad = habilidad;
    }

    public void aplicarHabilidad()
    {
        _habilidad.aplicarHabilidad();
    }
}