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

    private void aplicar_h(Personaje player, Personaje rival)//TODO: arreglar esto 
    {
        if (player.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in player.habilidades)
            {
                AplicadorHabilidad aplicador_habilidad = 
                    new AplicadorHabilidad(nombre_habilidad, player, rival, _view); 
                aplicador_habilidad.ConstructorHabilidad();
            }
        }
        foreach (var i in player.bonus_stats)
        {
            if (i.Value > 0)
            {
                _view.WriteLine($"{player.name} obtiene {i.Key}+{i.Value}");
            }
            else
            {
                _view.WriteLine($"{player.name} obtiene {i.Key}-{i.Value}");
            }
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
        
        aplicar_h(personaje_jugador, personaje_rival);
        aplicar_h(personaje_rival, personaje_jugador);
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
        batalla.Atack(personaje_jugador, personaje_rival, batalla.ATK_PLAYER);
        if (personaje_rival.HP == 0)
        {
            EndRound();
            return;
        }
        batalla.Atack(personaje_rival, personaje_jugador, batalla.ATK_RIVAL);
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

