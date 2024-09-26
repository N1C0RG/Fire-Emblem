using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;
public class HabilidadManager
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view;
    private NeutralizadorEfectos _neutralizadorEfectos;
    private ImpresoraHabilidades _impresoraHabilidades;

    public HabilidadManager(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view;
        _neutralizadorEfectos = new NeutralizadorEfectos(jugador, rival);
        _impresoraHabilidades = new ImpresoraHabilidades(jugador, rival, view);
    }

    public void AplicarTodo()
    {
        AplicarHabilidades(_jugador, _rival);
        AplicarHabilidades(_rival, _jugador);
        OrdenarBonusEnDiccionarioListas();
        _impresoraHabilidades.PrintAllAbilities();
        _neutralizadorEfectos.AplicarNeutralizadores();
    }

    private void AplicarHabilidades(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var aplicador = new AplicadorHabilidad(habilidad, jugador, rival);
            aplicador.ConstructorHabilidad();
        }
    }

    private void OrdenarBonusEnDiccionarioListas()
    {
        _jugador.OrdenarContenedores();
        _rival.OrdenarContenedores();
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
    public void AplicarNeutralizadores()
    {
        NeutralizarBonusPenalty(_jugador);
        NeutralizarFollowBonusPenalty(_jugador);
        NeutralizarBonusPenalty(_rival);
        NeutralizarFollowBonusPenalty(_rival);
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
}

public class ImpresoraHabilidades
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view; 
    public ImpresoraHabilidades(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view; 
    }
    public void PrintAllAbilities()
    {
        PrintFollowUpAtk(_jugador);
        PrintFollowUpAtk(_rival);
        PrintPlayerAbilities(_jugador);
        PrintNeutralizations(_jugador);
        PrintPlayerAbilities(_rival);
        PrintNeutralizations(_rival);
    }

    private void PrintPlayerAbilities(Personaje player)
    {
        foreach (var stat in player.bonus_stats)
        {
            PrintAbility(player, stat, stat.Value > 0 ? "+" : "");
        }

        foreach (var stat in player.penalty_stats)
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
        foreach (var bonus in player.bonus_neutralizados)
        {
            _view.WriteLine($"Los bonus de {bonus} de {player.name} fueron neutralizados");
        }

        foreach (var penalty in player.penalty_neutralizados)
        {
            _view.WriteLine($"Los penalty de {penalty} de {player.name} fueron neutralizados");
        }
    }
    private void PrintFollowUpAtk(Personaje player)
    {
        if (player.atk_follow != 0)
        {
            var sign = player.atk_follow > 0 ? "+" : "";
            _view.WriteLine($"{player.name} obtiene Atk{sign}{player.atk_follow} en su Follow-Up");
        }
    }
    
}