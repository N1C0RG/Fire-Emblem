using System.Security.Cryptography.X509Certificates;
using Fire_Emblem_View;

namespace Fire_Emblem.Habilidades;

public class EjecucionAplicadorHabilidad
{
    private Personaje jugador;
    private Personaje rival;
    private View _view;

    public EjecucionAplicadorHabilidad(Personaje jugador, Personaje rival, View view)
    {
        this.jugador = jugador;
        this.rival = rival;
        this._view = view; 
    }
    private void AplicarBonusPenalty(Personaje jugador, Personaje rival)//TODO: arreglar esto 
    {
        if (jugador.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in jugador.habilidades)
            {
                AplicadorHabilidadBonus aplicador_habilidad = 
                    new AplicadorHabilidadBonus(nombre_habilidad, jugador, rival, _view); 
                aplicador_habilidad.ConstructorHabilidad();
            }
        }
    }
    private void AplicarNeutralizador(Personaje jugador, Personaje rival)//TODO: arreglar esto no deberia hacer algo aparte en la logica del juego 
    {
        if (jugador.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in jugador.habilidades)
            {
                AplicadorHabilidadMixta aplicador_habilidad_neutralizador = 
                    new AplicadorHabilidadMixta(nombre_habilidad, jugador, rival, _view);
                aplicador_habilidad_neutralizador.ConstructorHabilidad();
            }
        }
    }
    private void PrintFollowAtkUp(Personaje player)
    {
        if (player.atk_follow > 0)
        {
            _view.WriteLine($"{player.name} obtiene Atk+{player.atk_follow} en su Follow-Up");
        }
        if (player.atk_follow < 0)
        {
            _view.WriteLine($"{player.name} obtiene Atk{player.atk_follow} en su Follow-Up");
        }
    }
    private void PrintPlayerAbility(Personaje player)
    {
        //lo que modifico (un diccionario ordenado acorde a las claves)
        string[] order = { "Atk", "Spd", "Def", "Res" };
        var bonus_ordenados = order
            .Where(key => player.bonus_stats.ContainsKey(key))
            .Select(key => new { Key = key, Value = player.bonus_stats[key] });

        // Filter and order penalty stats
        var penalty_ordenados = order
            .Where(key => player.penalty_stats.ContainsKey(key))
            .Select(key => new { Key = key, Value = player.penalty_stats[key] });
        
        foreach (var i in bonus_ordenados)
        {
            //_view.WriteLine($"{i}");
            ContenidoPrintAbility(player, (i.Key, i.Value), "+"); 
            
        }
        foreach (var i in bonus_ordenados)
        {
            if (i.Value < 0)//TODO: no comtempvlo el caso un bonus 0
            {
                ContenidoPrintAbility(player, (i.Key, i.Value), ""); 
            }
        }
        foreach (var i in penalty_ordenados)
        {
            ContenidoPrintAbility(player, (i.Key, i.Value), ""); 
        }
    }
    private void ContenidoPrintAbility(Personaje player, (string Key, int Value) diccionario, string s)
    {
        if (player.first_atack == 1 && diccionario.Key == "Atk" && player.habilidad_fa)
        {
            _view.WriteLine($"{player.name} obtiene {diccionario.Key}{s}{diccionario.Value} en su primer ataque");
        }
        else
        {
            _view.WriteLine($"{player.name} obtiene {diccionario.Key}{s}{diccionario.Value}");
        }
    }
    private void PrintNeutralizacion(Personaje player)
    {
        if (player.bonus_neutralizados.Count > 0)
        {
            foreach (var i in player.bonus_neutralizados)
            {
                _view.WriteLine($"Los bonus de {i} de {player.name} fueron neutralizados");
            }
        }
        if (player.penalty_neutralizados.Count > 0)
        {
            foreach (var i in player.penalty_neutralizados)
            {
                _view.WriteLine($"Los penalty de {i} de {player.name} fueron neutralizados");
            }
        }
    }
    private void PrintTodoAbility()
    {
        PrintFollowAtkUp(jugador);
        PrintFollowAtkUp(rival);
        PrintPlayerAbility(jugador);
        PrintNeutralizacion(jugador);
        PrintPlayerAbility(rival);
        PrintNeutralizacion(rival);
    }
    public void AplicarTodo()
    {
        AplicarBonusPenalty(jugador, rival);
        AplicarBonusPenalty(rival, jugador);
        PrintTodoAbility();
        AplicarNeutralizador(jugador, rival);
        AplicarNeutralizador(rival, jugador);
        
        //TODO: meter esto donde corresponda 
        jugador.CalcularNetosStats();
        rival.CalcularNetosStats();
    
    }
}