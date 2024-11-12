using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class MoonTwinWing : HabilidadCompuesta
{
    private int ataqueJugador;
    private int resistenciaRival; 
    public MoonTwinWing(Personaje jugador, Personaje rival)
        : base(new List<Habilidad>(), jugador, rival)
    {
        agregarEfectos();
    }
    public override void aplicarHabilidad()
    {

        new ReduccionDanoPorcentualPrimerAtaque(0.25m).efecto(jugador, rival);
        
        if (ataqueJugador > resistenciaRival)
        {
        }
    }
    public void agregarEfectos()
    {
       
        var habilidades = new List<Habilidad>()
        {
            new Habilidad(
                new List<IEfecto> { new RivalAtkUp(-5), new RivalSpdUp(-5) },
                new List<ICondicion> { new HpMas25() },
                _jugador,
                _rival),
            new Habilidad(
                new List<IEfecto> { new ReduccionDanoPorcentualSpd() },
                new List<ICondicion> { new CondicionDiferenciaStats(Stat.Spd, Stat.Spd), new HpMas25() },
                _jugador,
                _rival)
        }; 
        _habilidades = habilidades;
    }

}

