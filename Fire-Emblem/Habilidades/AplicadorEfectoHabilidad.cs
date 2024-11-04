namespace Fire_Emblem.Habilidades;

public class AplicadorEfectoHabilidad
{
    public Habilidad _habilidad; //TODO: cambie esto a publico 

    public AplicadorEfectoHabilidad(Habilidad habilidad)
    {
        _habilidad = habilidad;
    }

    public void aplicarHabilidad()
    {
        _habilidad.aplicarHabilidad();
    }
}