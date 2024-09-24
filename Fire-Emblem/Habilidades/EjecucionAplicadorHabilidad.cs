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
        foreach (var i in player.bonus_stats)
        {
            if (i.Value > 0)//TODO: no comtemplo el caso un bonus 0
            {
                ContenidoPrintAbility(player, i, "+"); 
            }
        }
        foreach (var i in player.bonus_stats)
        {
            if (i.Value < 0)//TODO: no comtemplo el caso un bonus 0
            {
                ContenidoPrintAbility(player, i, ""); 
            }
        }
    }
    private void ContenidoPrintAbility(Personaje player, KeyValuePair<string, int> diccionario, string signo)
    {
        if (player.first_atack == 1 && diccionario.Key == "Atk" && player.habilidad_fa)
        {
            _view.WriteLine($"{player.name} obtiene {diccionario.Key}{signo}{diccionario.Value} en su primer ataque");
        }
        else
        {
            _view.WriteLine($"{player.name} obtiene {diccionario.Key}{signo}{diccionario.Value}");
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
    
    }
}