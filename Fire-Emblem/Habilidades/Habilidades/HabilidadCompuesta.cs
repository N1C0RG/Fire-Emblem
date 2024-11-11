namespace Fire_Emblem.Habilidades;

public class HabilidadCompuesta: Habilidad
{
    public  List<Habilidad> _habilidades;
    public Personaje _jugador;
    public Personaje _rival;
    public HabilidadCompuesta(List<Habilidad> habilidades, Personaje jugador, Personaje rival)
        : base(new List<IEfecto>(), new List<ICondicion>(), jugador, rival)
    {
        _habilidades = habilidades;
        _jugador = jugador;
        _rival = rival;
    }

    public override void aplicarHabilidad()
    {
        foreach (var habilidad in _habilidades)
        {
            habilidad.aplicarHabilidad();
        }
    }
}