using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;
public class HabilidadManager
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view;
    private NeutralizadorEfectos _neutralizadorEfectos;
    private ImpresoraBonusPenaltyNeutralizaciones _impresoraHabilidades;

    public HabilidadManager(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view;
        _neutralizadorEfectos = new NeutralizadorEfectos(jugador, rival);
        _impresoraHabilidades = new ImpresoraBonusPenaltyNeutralizaciones(jugador, rival, view);
    }

    public void aplicarTodo()
    {
        aplicarHabilidades(_jugador, _rival);
        aplicarHabilidades(_rival, _jugador);
        ordenarBonusEnDiccionarioListas();
        _impresoraHabilidades.printTodoBonusPenaltyNeutralizaciones();
        _neutralizadorEfectos.aplicarNeutralizadores();
    }

    private void aplicarHabilidades(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var aplicador = new FabricaHabilidad(habilidad, jugador, rival);
            aplicador.crearHabilidad();
        }
    }

    private void ordenarBonusEnDiccionarioListas()
    {
        _jugador.ordenarContenedores();
        _rival.ordenarContenedores();
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
    private void neutralizarBonusPenalty(Personaje player)
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
    private void neutralizarFollowBonusPenalty(Personaje player)
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

public class ImpresoraBonusPenaltyNeutralizaciones
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view; 
    public ImpresoraBonusPenaltyNeutralizaciones(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view; 
    }
    public void printTodoBonusPenaltyNeutralizaciones()
    {
        printFollowUpAtk(_jugador);
        printFollowUpAtk(_rival);
        printJugadorBonusPenalty(_jugador);
        printBonusPenaltyNeutralizados(_jugador);
        printJugadorBonusPenalty(_rival);
        printBonusPenaltyNeutralizados(_rival);
    }

    private void printJugadorBonusPenalty(Personaje player)
    {
        foreach (var stat in player.bonus_stats)
        {
            printBonusPenalty(player, stat, stat.Value > 0 ? "+" : "");
        }

        foreach (var stat in player.penalty_stats)
        {
            if (stat.Value < 0)
            {
                printBonusPenalty(player, stat, "");
            }
        }
    }

    private void printBonusPenalty(Personaje player, KeyValuePair<string, int> stat, string sign)
    {
        var mensaje = (player.first_atack == 1 && player.habilidad_first_atack.Contains(stat.Key))
            ? $"{player.name} obtiene {stat.Key}{sign}{stat.Value} en su primer ataque"
            : $"{player.name} obtiene {stat.Key}{sign}{stat.Value}";

        _view.WriteLine(mensaje);
    }
    
    private void printBonusPenaltyNeutralizados(Personaje player)
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
    private void printFollowUpAtk(Personaje player)
    {
        if (player.atk_follow != 0)
        {
            var sign = player.atk_follow > 0 ? "+" : "";
            _view.WriteLine($"{player.name} obtiene Atk{sign}{player.atk_follow} en su Follow-Up");
        }
    }
    
}