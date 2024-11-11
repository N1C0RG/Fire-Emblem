namespace Fire_Emblem.Habilidades;
using Encapsulado; 

public class CondicionDiferenciaStats : CondicionGenerica
{
    private Stat _statJugador;
    private Stat _statRival;
    public CondicionDiferenciaStats(Stat statJugador, Stat statRival)
    {
        _statJugador = statJugador; 
        _statRival = statRival; 
    }
    public override bool condicionHabilidad(Personaje jugador, Personaje rival)
    {
        
        return jugador.getStat(_statJugador) + jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), _statJugador.ToString()) >
               rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), _statRival.ToString()) +  rival.getStat(_statRival);
    }
}