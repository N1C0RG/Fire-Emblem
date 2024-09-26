using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;
public class EjecucionAplicadorHabilidad
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view;

    public EjecucionAplicadorHabilidad(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view;
    }

    public void AplicarTodo()
    {
        AplicarHabilidades(_jugador, _rival);
        AplicarHabilidades(_rival, _jugador);
        PrintAllAbilities();
        AplicarNeutralizadores(_jugador);
        AplicarNeutralizadores(_rival);
    }

    private void AplicarHabilidades(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var aplicador = new AplicadorHabilidad(habilidad, jugador, rival);
            aplicador.ConstructorHabilidad();
        }
    }

    private void AplicarNeutralizadores(Personaje player)
    {
        NeutralizarBonusPenalty(player);
        NeutralizarFollowBonusPenalty(player);
    }
    private void NeutralizarBonusPenalty(Personaje player)
    {
        foreach (var stat in player.bonus_neutralizados)
        {
            player.bonus_stats[stat] = 0;
        }
        foreach (var stat in player.penalty_neutralizados)
        {
            player.penalty_stats[stat] = 0;
        }
    }
    private void NeutralizarFollowBonusPenalty(Personaje player)
    {
        if (player.atk_follow > 0 && player.bonus_neutralizados.Contains("Atk"))
        {
            player.atk_follow = 0;
        }
        if (player.atk_follow < 0 && player.penalty_neutralizados.Contains("Atk"))
        {
            player.atk_follow = 0;
        }
    }

    private void PrintAllAbilities()
    {
        PrintFollowUpAtk(_jugador);
        PrintFollowUpAtk(_rival);
        PrintPlayerAbilities(_jugador);
        PrintNeutralizations(_jugador);
        PrintPlayerAbilities(_rival);
        PrintNeutralizations(_rival);
    }

    private void PrintFollowUpAtk(Personaje player)
    {
        if (player.atk_follow != 0)
        {
            var sign = player.atk_follow > 0 ? "+" : "";
            _view.WriteLine($"{player.name} obtiene Atk{sign}{player.atk_follow} en su Follow-Up");
        }
    }

    private void PrintPlayerAbilities(Personaje player)
    {
        //Todo: mover tal vez esto a el personaje 
        var orderedBonuses = OrdenarStats(player.bonus_stats);
        var orderedPenalties = OrdenarStats(player.penalty_stats);

        foreach (var stat in orderedBonuses)
        {
            PrintAbility(player, stat, stat.Value > 0 ? "+" : "");
        }

        foreach (var stat in orderedPenalties)
        {
            if (stat.Value < 0)
            {
                PrintAbility(player, stat, "");
            }
        }
    }

    private void PrintAbility(Personaje player, KeyValuePair<string, int> stat, string sign)
    {
        var mensaje = (player.first_atack == 1 && player.habilidad_first_atack.Contains(stat.Key))
            ? $"{player.name} obtiene {stat.Key}{sign}{stat.Value} en su primer ataque"
            : $"{player.name} obtiene {stat.Key}{sign}{stat.Value}";

        _view.WriteLine(mensaje);
    }

    private void PrintNeutralizations(Personaje player)
    {   
        //TODO; mover esto a el personaje
        var ordenBonusNeutralizados = OrdenarNeutralizaciones(player.bonus_neutralizados);
        var ordenPenaltyNeutralizado = OrdenarNeutralizaciones(player.penalty_neutralizados);
        
        foreach (var bonus in ordenBonusNeutralizados)
        {
            _view.WriteLine($"Los bonus de {bonus} de {player.name} fueron neutralizados");
        }

        foreach (var penalty in ordenPenaltyNeutralizado)
        {
            _view.WriteLine($"Los penalty de {penalty} de {player.name} fueron neutralizados");
        }
    }
    
    private IEnumerable<KeyValuePair<string, int>> OrdenarStats(Dictionary<string, int> stats)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(stats.ContainsKey).Select(key => new KeyValuePair<string, int>(key, stats[key]));
    }
    private IEnumerable<string> OrdenarNeutralizaciones(IEnumerable<string> neutralizations)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(neutralizations.Contains);
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
    

}