namespace Fire_Emblem.Habilidades;

public class NeutralizadorEfectos
{
    private Personaje _jugador;
    private Personaje _rival; 
    public NeutralizadorEfectos(Personaje jugador, Personaje rival)
    {
        _jugador = jugador;
        _rival = rival; 
    }
    public void aplicarNeutralizadores()
    {
        neutralizarBonusPenalty(_jugador);
        neutralizarFollowBonusPenalty(_jugador);
        neutralizarBonusPenalty(_rival);
        neutralizarFollowBonusPenalty(_rival);
    }
    private void neutralizarBonusPenalty(Personaje jugador) 
    {
        foreach (var stat in jugador.dataHabilidadStats.bonusNeutralizados)
        {
            jugador.dataHabilidadStats.bonusStats[stat] = 0;
        }
        foreach (var stat in jugador.dataHabilidadStats.penaltyNeutralizados)
        {
            jugador.dataHabilidadStats.penaltyStats[stat] = 0;
        }
    }
    private void neutralizarFollowBonusPenalty(Personaje jugador)
    {
        if (jugador.getAtaqueFollow() > 0 && jugador.dataHabilidadStats.bonusNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }
        if (jugador.getAtaqueFollow() < 0 && jugador.dataHabilidadStats.penaltyNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }

    }
}
