namespace Fire_Emblem.Habilidades;

public class HabilidadCompuesta: Habilidad
{
    public  List<Habilidad> _habilidades;

    public HabilidadCompuesta(List<Habilidad> habilidades)
        : base(new List<IEfecto>(), new List<ICondicion>(), null, null)
    {
        _habilidades = habilidades;
    }

    public override void aplicarHabilidad()
    {
        foreach (var habilidad in _habilidades)
        {
            habilidad.aplicarHabilidad();
        }
    }
}