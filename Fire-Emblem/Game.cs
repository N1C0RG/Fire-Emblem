using Fire_Emblem_View;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Fire_Emblem;
using Fire_Emblem.Habilidades;
using System.IO; 
using Fire_Emblem; 

public class Game
{
    private View _view;
    private string _teamsFolder;
    private int turno = 0;
    private Personaje personaje_jugador;
    private Personaje personaje_rival;
    private Batalla batalla;
    private Player rival_metodo_play;
    private Player jugador_metodo_play; 
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    public void PrintTeams()
    {
        _view.WriteLine(message:"Elige un archivo para cargar los equipos");
        string[] archivos_equipos = Directory.GetFiles(_teamsFolder, "*.txt");
        int contador = 0; 
        foreach (var i in archivos_equipos)
        {
            _view.WriteLine($"{contador}: {Path.GetFileName(i)}");
            contador += 1; 
        }
    }
    // para hacer este metodo use stack overflow 
    public List<JsonContent> LoadJson()
    {
        string directorio_path = AppDomain.CurrentDomain.BaseDirectory; 
        string jsonFilePath = Path.Combine(directorio_path, "characters.json");
        string jsonString = File.ReadAllText(jsonFilePath);
        List<JsonContent> todos_personajes = JsonSerializer.Deserialize<List<JsonContent>>(jsonString);
        return todos_personajes; 
    }
    public void ShowTeam(Player player)
    {
        for (int i = 0; i < player.equipo.Count; i++)
        {
            _view.WriteLine($"{i}: " + player.equipo[i].name);
        }
    }

    private void PrintOpcion(Player player, int n)
    {
        _view.WriteLine($"Player {n} selecciona una opción");
        ShowTeam(player);
    }

    private void AplicarBonusPenalty(Personaje player, Personaje rival)//TODO: arreglar esto 
    {
        if (player.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in player.habilidades)
            {
                AplicadorHabilidadBonus aplicador_habilidad = 
                    new AplicadorHabilidadBonus(nombre_habilidad, player, rival, _view); 
                aplicador_habilidad.ConstructorHabilidad();
            }
        }
        
    }
    private void AplicarNeutralizador(Personaje player, Personaje rival)//TODO: arreglar esto no deberia hacer algo aparte en la logica del juego 
    {
        if (player.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in player.habilidades)
            {
                AplicadorHabilidadMixta aplicador_habilidad_neutralizador = 
                    new AplicadorHabilidadMixta(nombre_habilidad, player, rival, _view);
                aplicador_habilidad_neutralizador.ConstructorHabilidad();
            }
        }
        
    }

    private void PrintBonus(Personaje player, Personaje rival)//TODO: arreglar esto 
    {
        if (player.atk_follow > 0)
        {
            _view.WriteLine($"{player.name} obtiene Atk+{player.atk_follow} en su Follow-Up");
        }
        if (player.atk_follow < 0)
        {
            _view.WriteLine($"{player.name} obtiene Atk{player.atk_follow} en su Follow-Up");
        }
        if (rival.atk_follow > 0)
        {
            _view.WriteLine($"{rival.name} obtiene Atk+{rival.atk_follow} en su Follow-Up");
        }
        if (rival.atk_follow < 0)
        {
            _view.WriteLine($"{rival.name} obtiene Atk{rival.atk_follow} en su Follow-Up");
        }
        foreach (var i in player.bonus_stats)
        {
            if (i.Value > 0)//TODO: no comtemplo el caso un bonus 0
            {
                if (player.first_atack == 1 && i.Key == "Atk" && player.habilidad_fa)
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}+{i.Value} en su primer ataque");
                }
                else if (player.atk_follow > 0 && i.Key == "Atk")
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}+{player.atk_follow} en su primer ataque");
                }
                else
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}+{i.Value}");
                }
                
            }
            else if (i.Value < 0)
            {
                if (player.first_atack == 1 && i.Key == "Atk" && player.habilidad_fa)
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}-{i.Value} en su primer ataque");
                }
                else if (player.atk_follow < 0 && i.Key == "Atk")
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}-{player.atk_follow} en su primer ataque");
                }
                else
                {
                    _view.WriteLine($"{player.name} obtiene {i.Key}-{i.Value}");
                }
            }
        }
        if (player.tiene_bonus == false)
        {
            _view.WriteLine($"Los bonus de Atk de {player.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Spd de {player.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Def de {player.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Res de {player.name} fueron neutralizados");
        }
        foreach (var i in rival.bonus_stats)
        {
            if (i.Value > 0)//TODO: no comtemplo el caso un bonus 0
            {
                if (rival.first_atack == 1 && i.Key == "Atk" && rival.habilidad_fa == true)
                {
                    _view.WriteLine($"{rival.name} obtiene {i.Key}+{i.Value} en su primer ataque"); 
                }
                else
                {
                    _view.WriteLine($"{rival.name} obtiene {i.Key}+{i.Value}");
                }
            }
            else if (i.Value < 0)
            {
                if (rival.first_atack == 1 && i.Key == "Atk" && rival.habilidad_fa == true)
                {
                    _view.WriteLine($"{rival.name} obtiene {i.Key}-{i.Value} en su primer ataque");
                }
                else
                {
                    _view.WriteLine($"{rival.name} obtiene {i.Key}-{i.Value}");
                }
            }
        }
        if (rival.tiene_bonus == false)
        {
            _view.WriteLine($"Los bonus de Atk de {rival.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Spd de {rival.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Def de {rival.name} fueron neutralizados");
            _view.WriteLine($"Los bonus de Res de {rival.name} fueron neutralizados");
        }
    }

    private void InicializacionTurno(Player jugador, Player rival)
    {
        PrintOpcion(jugador, jugador.tipo);
        int jugador_input = Convert.ToInt32(_view.ReadLine());
        
        PrintOpcion(rival, rival.tipo);
        int rival_input = Convert.ToInt32(_view.ReadLine());
        
        personaje_jugador = jugador.equipo[jugador_input];
        personaje_rival = rival.equipo[rival_input]; 
        
        _view.WriteLine($"Round {turno}: {personaje_jugador.name} (Player {jugador.tipo}) comienza");
    }

    private void InicializacionBatalla(Player jugador, Player rival)
    {
        batalla = new Batalla(personaje_jugador, personaje_rival, _view, jugador, rival);
        
        batalla.Ventajas();
        batalla.PrintVida();
    }

    private void StarTurno(Player jugador, Player rival)//TODO: arreglar el problema que tengo entre alternanr entre el jugador y el rival 
    {
        InicializacionTurno(jugador, rival);
        InicializacionBatalla(jugador, rival);
        SetUpHabilidades();
        batalla.DefinirAtack();
    }

    private void SetUpHabilidades()
    {
        // la parte de true de empieza
        //TODO: arreglar a clena code 
        personaje_jugador.inicia_round = true; 
        personaje_jugador.bonus_stats = new Dictionary<string, int>(); 
        personaje_rival.bonus_stats = new Dictionary<string, int>(); 
        
        AplicarBonusPenalty(personaje_jugador, personaje_rival);
        AplicarBonusPenalty(personaje_rival, personaje_jugador);
        PrintBonus(personaje_jugador, personaje_rival);
        AplicarNeutralizador(personaje_jugador, personaje_rival); 
        AplicarNeutralizador(personaje_rival, personaje_jugador);
        
    }

    private void EndRound()
    {
        batalla.VidaEndRound();
        batalla.RemovePlayer();
    }
    public void Turno(Player jugador, Player rival)
    {
        
        StarTurno(jugador, rival);
        //seteo a false de nuevo el inicia round 
        //TODO: arreglar esto 
        personaje_jugador.inicia_round = false;
        personaje_jugador.tiene_bonus = true;
        personaje_rival.tiene_bonus = true; 
        
        batalla.Atack(personaje_jugador, personaje_rival, batalla.ATK_PLAYER);
        if (personaje_rival.HP == 0)
        {
            EndRound();
            return;
        }
        batalla.Atack(personaje_rival, personaje_jugador, batalla.ATK_RIVAL);
        batalla.DefinirAtack();
        if (personaje_jugador.HP == 0)
        {
            EndRound();
        }
        else
        {
            batalla.PrintFollowUp();
            batalla.FollowUp();
            EndRound();
        }

        personaje_jugador.first_atack = 1; 
        personaje_rival.first_atack = 1; 
        return; 
    }

    private void InicializadorPlay()
    {
        //TODO: arreglar lo del rival y jugadorr play
        PrintTeams();
        string archivo_seleccionado = _view.ReadLine(); 
        ManejoArchivos archivo_jugador = new ManejoArchivos(_view, _teamsFolder, archivo_seleccionado); //TODO: arreglar el view de prueba 
        archivo_jugador.GuardarEquipo();
        jugador_metodo_play = new Player(archivo_jugador.CrearEquipo(LoadJson(), archivo_jugador.jugadorTeam), _view, 1);
        archivo_jugador.player_team = new List<Personaje>();
        rival_metodo_play = new Player(archivo_jugador.CrearEquipo(LoadJson(), archivo_jugador.rivalTeam), _view, 2);
        
    }
    public void Play()
    {
        InicializadorPlay();
        Validacion valido = new Validacion(jugador_metodo_play, rival_metodo_play); 
        if (valido.EquipoValido() == false)
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        else
        {
            turno = 1; 
            while (true)
            {
                if (turno % 2 != 0)
                {
                    Turno(jugador_metodo_play, rival_metodo_play);
                }
                else
                {
                    Turno(rival_metodo_play, jugador_metodo_play);
                }
                if (jugador_metodo_play.Perdio())
                {
                    _view.WriteLine("Player 2 ganó");
                    break; 
                }
                else if (rival_metodo_play.Perdio())
                {
                    _view.WriteLine("Player 1 ganó");
                    break; 
                }
                turno += 1;
            }

            
        }
    }
}

