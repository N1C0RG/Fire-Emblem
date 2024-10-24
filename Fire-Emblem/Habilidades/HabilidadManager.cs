using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;

public class AplicadorHabilidades
{
    private Personaje _jugador;
    private Personaje _rival;

    public AplicadorHabilidades(Personaje jugador, Personaje rival)
    {
        _jugador = jugador;
        _rival = rival;
    }

    public void aplicarHabilidades()
    {
        aplicarHabilidadesIndependientes(_jugador, _rival);
        aplicarHabilidadesIndependientes(_rival, _jugador);

        _jugador.SumarBonusYPenaltyEnPostEfecto();
        _rival.SumarBonusYPenaltyEnPostEfecto();

        aplicarHabilidadesDependientes(_jugador, _rival);
        aplicarHabilidadesDependientes(_rival, _jugador);
    }

    private void aplicarHabilidadesIndependientes(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadIndependienteStats(habilidad, jugador, rival);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
                aplicadorHabilidad.aplicarHabilidad();
            }
            catch { }
        }
    }

    private void aplicarHabilidadesDependientes(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadesDependientesStats(habilidad, jugador, rival);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
                aplicadorHabilidad.aplicarHabilidad();
            }
            catch { }
        }
    }
}

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
    private void neutralizarBonusPenalty(Personaje jugador) //TODO ver esto 
    {
        foreach (var stat in jugador.bonusNeutralizados)
        {
            jugador.bonusStats[stat] = 0;
        }
        foreach (var stat in jugador.penaltyNeutralizados)
        {
            jugador.penaltyStats[stat] = 0;
        }
    }
    private void neutralizarFollowBonusPenalty(Personaje jugador)
    {
        if (jugador.getAtaqueFollow() > 0 && jugador.bonusNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }
        if (jugador.getAtaqueFollow() < 0 && jugador.penaltyNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }

    }
}
