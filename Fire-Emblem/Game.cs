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
    
    public void Turno(Player jugador, Player rival, int n_player, int n_rival, int turno)
    {
        
        PrintOpcion(jugador, n_player);
        int jugador_input = Convert.ToInt32(_view.ReadLine());
        
        PrintOpcion(rival, n_rival);
        int rival_input = Convert.ToInt32(_view.ReadLine());
        
        var jugador_equipo = jugador.equipo[jugador_input];
        var rival_equipo = rival.equipo[rival_input]; 
        
        _view.WriteLine($"Round {turno}: {jugador_equipo.name} (Player {n_player}) comienza");
        
        Batalla batalla = new Batalla(jugador_equipo, rival_equipo, _view, jugador, rival);
        
        batalla.Ventajas();
        batalla.PrintVida();

        // la parte de true de empieza
        //TODO: arreglar a clena code 
        jugador_equipo.inicia_round = true; 
        jugador_equipo.bonus_stats = new Dictionary<string, int>(); 
        rival_equipo.bonus_stats = new Dictionary<string, int>(); 
        if (jugador_equipo.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in jugador_equipo.habilidades)
            {
                AplicadorHabilidad aplicador_habilidad = 
                    new AplicadorHabilidad(nombre_habilidad, jugador_equipo, rival_equipo, _view); 
                aplicador_habilidad.ConstructorHabilidad();
            }
            foreach (var i in jugador_equipo.bonus_stats)
            {
                if (i.Value > 0)
                {
                    _view.WriteLine($"{jugador_equipo.name} obtiene {i.Key}+{i.Value}");
                }
                else
                {
                    _view.WriteLine($"{jugador_equipo.name} obtiene {i.Key}-{i.Value}");
                }
            }
        }
        
        if (rival_equipo.habilidades.Length != 0)
        {
            foreach (var nombre_habilidad in rival_equipo.habilidades)
            {
                AplicadorHabilidad aplicador_habilidad2 = 
                    new AplicadorHabilidad(nombre_habilidad, rival_equipo, jugador_equipo, _view); 
                aplicador_habilidad2.ConstructorHabilidad();
            }
            foreach (var i in rival_equipo.bonus_stats)
            {
                if (i.Value > 0)
                {
                    _view.WriteLine($"{rival_equipo.name} obtiene {i.Key}+{i.Value}");
                }
                else
                {
                    _view.WriteLine($"{rival_equipo.name} obtiene {i.Key}-{i.Value}");
                }
            }
        }
        
        batalla.DefinirAtack();
        
        int d1 = batalla.ATK_PLAYER; 
        batalla.Atack(jugador_equipo, rival_equipo, d1);
        
        if (rival_equipo.HP == 0)
        {
            batalla.VidaEndRound();
            batalla.RemovePlayer();
            return;
        }
        else
        {
            int d2 = batalla.ATK_RIVAL;
            batalla.Atack(rival_equipo, jugador_equipo, d2);
                
            if (jugador_equipo.HP == 0)
            {
                batalla.VidaEndRound();
                batalla.RemovePlayer();
            }
            else
            {
                batalla.PrintFollowUp();
                batalla.FollowUp();
                batalla.VidaEndRound();
                batalla.RemovePlayer();
            }
        }
        //seteo a false de nuevo el inicia round 
        //TODO: arreglar esto 
        jugador_equipo.inicia_round = false;
        return; 
    }
    public void Play()
    {
        PrintTeams();
        
        ManejoArchivos archivo_jugador = new ManejoArchivos(_view); //TODO: arreglar el view de prueba 
        ManejoArchivos archivo_rival = new ManejoArchivos(_view); 
        
        var tupla= archivo_jugador.GuardarEquipo(_view.ReadLine(), _teamsFolder);
        
        Player jugador = new Player(archivo_jugador.CrearEquipo(LoadJson(), tupla.Item1), _view, 1);
        Player rival = new Player(archivo_rival.CrearEquipo(LoadJson(), tupla.Item2), _view, 2);
        
        Validacion valido = new Validacion(jugador, rival); 
        
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
                    Turno(jugador, rival, 1, 2, turno);
                }
                else
                {
                    Turno(rival, jugador, 2, 1, turno);
                }
                if (jugador.Perdio())
                {
                    _view.WriteLine("Player 2 ganó");
                    break; 
                }
                else if (rival.Perdio())
                {
                    _view.WriteLine("Player 1 ganó");
                    break; 
                }
                turno += 1;
            }

            
        }
    }
}

