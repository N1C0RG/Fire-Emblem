﻿using Fire_Emblem_View;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace Fire_Emblem;
using Fire_Emblem; 

public class Game
{
    private View _view;
    private string _teamsFolder;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }
    public void PrintTeams()
    {
        _view.WriteLine(message:"Elige un archivo para cargar los equipos");
        string[] archivos_equipos = Directory.GetFiles(_teamsFolder, "*.txt");
        for (int numero = 0; numero < archivos_equipos.Length; numero++)
        {
            string equipo = $"{numero}: {numero.ToString().PadLeft(3, '0')}.txt";
            _view.WriteLine(equipo);
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
    
    public void Turno(Player jugador, Player rival, int n1, int n2, int turno)
    {
        _view.WriteLine($"Player {n1} selecciona una opción");
        
        ShowTeam(jugador);
        
        int jugador_input = Convert.ToInt32(_view.ReadLine());
        
        _view.WriteLine($"Player {n2} selecciona una opción");
        
        ShowTeam(rival);
        
        int rival_input = Convert.ToInt32(_view.ReadLine());
        
        var jugador_equipo = jugador.equipo[jugador_input];
        var rival_equipo = rival.equipo[rival_input]; 
        
        _view.WriteLine($"Round {turno}: {jugador_equipo.name} (Player {n1}) comienza");
        
        Batalla batalla = new Batalla(jugador_equipo, rival_equipo, _view, jugador, rival);
        
        batalla.Ventajas();
        batalla.PrintVida();
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
                batalla.FollowUp();
                batalla.VidaEndRound();
                batalla.RemovePlayer();
            }
        }
        return; 
    }
    public void Play()
    {
        PrintTeams();
        
        ManejoArchivos archivo_jugador = new ManejoArchivos(); 
        ManejoArchivos archivo_rival = new ManejoArchivos(); 
        
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
            int turno = 1; 
            
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

