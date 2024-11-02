using Fire_Emblem.Encapsulado;
using Fire_Emblem.Encapsulado.Stats;

namespace Fire_Emblem.Habilidades;

public class NeutralizadorEfectos
{
    private Personaje _jugador;
    private Personaje _rival; 
    string bonusNeutralizados = NombreDiccionario.bonusNeutralizados.ToString(); 
    string penaltyNeutralizados = NombreDiccionario.penaltyNeutralizados.ToString();
    public NeutralizadorEfectos(Personaje jugador, Personaje rival)
    {
        _jugador = jugador;
        _rival = rival; 
    }
    public void aplicarNeutralizadores()
    {
        neutralizarBonusPenalty(_jugador);
        neutralizarFollowBonusPenalty(_jugador);
        neutralizarPrimerAtaque(_jugador);
        neutralizarBonusPenalty(_rival);
        neutralizarFollowBonusPenalty(_rival);
        neutralizarPrimerAtaque(_rival);
    }
    private void neutralizarBonusPenalty(Personaje jugador)
    {
        foreach (var stat in
                 jugador.getSpecificArrayDataHabilidadStat(bonusNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.bonusStats.ToString(), stat, 0);
        }
        foreach (var stat in jugador.getSpecificArrayDataHabilidadStat(penaltyNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.penaltyStats.ToString(), stat, 0);
        }
    }

    private void neutralizarPrimerAtaque(Personaje jugador)
    {
        foreach (var stat in
                 jugador.getSpecificArrayDataHabilidadStat(bonusNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.primerAtaqueBonus.ToString(), stat, 0);
        }
        foreach (var stat in jugador.getSpecificArrayDataHabilidadStat(penaltyNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.primerAtaquePenalty.ToString(), stat, 0);
        }
    }
    private void neutralizarFollowBonusPenalty(Personaje jugador)
    {
        foreach (var stat in
                 jugador.getSpecificArrayDataHabilidadStat(bonusNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.followBonus.ToString(), stat, 0);
        }
        foreach (var stat in jugador.getSpecificArrayDataHabilidadStat(penaltyNeutralizados))
        {
            jugador.setDataHabilidadStat(NombreDiccionario.followPenalty.ToString(), stat, 0);
        }
    }
}
