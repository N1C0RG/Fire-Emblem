namespace Fire_Emblem.Habilidades;

public class ReduccionDanoAbsoluta : IEfecto
{
    private int cantidad;
    public ReduccionDanoAbsoluta(int cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.reduccionDanoAbsoluta += cantidad;
    }

    public Prioridad getPrioridad()
    {
        return Prioridad.reduccionAbsoluta; 
    }
}