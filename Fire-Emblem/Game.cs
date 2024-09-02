using Fire_Emblem_View;
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
            string c = $"{numero}: {numero.ToString().PadLeft(3, '0')}.txt";
            _view.WriteLine(c);
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
    public void ShowTeam(Player player)//TODO: arreglar esto
    {
        for (int i = 0; i < player.equipo.Count; i++)
        {
            _view.WriteLine($"{i}: " + player.equipo[i].name);
        }
    }
    public bool Turno(Player jugador1, Player jugador2, int n1, int n2, int turno)
    {
        _view.WriteLine($"Player {n1} selecciona una opción");
        ShowTeam(jugador1);
        int input1 = Convert.ToInt32(_view.ReadLine());
        _view.WriteLine($"Player {n2} selecciona una opción");
        ShowTeam(jugador2);
        int input2 = Convert.ToInt32(_view.ReadLine());
        _view.WriteLine($"Round {turno}: {jugador1.equipo[input1].name} (Player {n1}) comienza");
        // bool? v1 = Ventajas(jugador1.equipo[input1], jugador2.equipo[input2]);
        // bool? v2 = Ventajas(jugador2.equipo[input2], jugador1.equipo[input1]);
        // printV(jugador1.equipo[input1], jugador2.equipo[input2], v1);
        Batalla batalla = new Batalla(jugador1.equipo[input1], jugador2.equipo[input2], _view);
        batalla.ventajas();
        batalla.print_vida();
        int d1 = jugador1.equipo[input1].atacar(jugador2.equipo[input2], batalla.v_player);
        _view.WriteLine($"{jugador1.equipo[input1].name} ataca a" +
                        $" {jugador2.equipo[input2].name} con {d1} de daño");
        jugador2.equipo[input2].HP -= d1;
        if (jugador2.perdio())
        {
            _view.WriteLine($"{jugador1.equipo[input1].name} ({jugador1.equipo[input1].HP}) : " +
                            $"{jugador2.equipo[input2].name} ({jugador2.equipo[input2].HP})");
            _view.WriteLine($"Player {n1} ganó");
            return true; 
        }
        if (jugador2.equipo[input2].HP == 0)
        {
            //PrintVida(jugador1, jugador2, input1, input2, turno);
            batalla.vida();
            jugador2.equipo.RemoveAt(input2);
        }
        else
        {
            int d2 = jugador2.equipo[input2].atacar(jugador1.equipo[input1], batalla.v_rival);
            _view.WriteLine($"{jugador2.equipo[input2].name} ataca a" +
                            $" {jugador1.equipo[input1].name} con {d2} de daño");
            jugador1.equipo[input1].HP -= d2;
            if (jugador1.equipo[input1].HP == 0)
            {
                //PrintVida(jugador1, jugador2, input1, input2, turno);
                batalla.vida();
                jugador1.equipo.RemoveAt(input1);
            }
            else
            {
                if (jugador1.equipo[input1].spd >= jugador2.equipo[input2].spd + 5)
                {
                    _view.WriteLine($"{jugador1.equipo[input1].name} ataca a" +
                                    $" {jugador2.equipo[input2].name} con {d1} de daño");
                    jugador2.equipo[input2].HP -= d1;
                }
                else if (jugador1.equipo[input1].spd + 5 <= jugador2.equipo[input2].spd)
                {
                    _view.WriteLine($"{jugador2.equipo[input2].name} ataca a" +
                                    $" {jugador1.equipo[input1].name} con {d2} de daño");
                    jugador1.equipo[input1].HP -= d2;
                }
                else
                {
                    _view.WriteLine("Ninguna unidad puede hacer un follow up");
                }

                //PrintVida(jugador1, jugador2, input1, input2, turno);
                batalla.vida();
                if (jugador1.equipo[input1].HP == 0)
                {
                    
                    jugador1.equipo.RemoveAt(input1);
                }
                else if (jugador2.equipo[input2].HP == 0)
                {
                    
                    jugador2.equipo.RemoveAt(input2);
                }
            }
        }
        return false; 
    }
    public void Play()
    {
        PrintTeams();
        ManejoArchivos archivo = new ManejoArchivos(); 
        ManejoArchivos archivo2 = new ManejoArchivos(); 
        var tupla= archivo.GuardarEquipo(_view.ReadLine(), _teamsFolder);
        List<string> p1 = tupla.Item1;
        List<string> p2 = tupla.Item2;
        Player jugador1 = new Player(archivo.crear_equipo(LoadJson(), p1));
        Player jugador2 = new Player(archivo2.crear_equipo(LoadJson(), p2));
        Validacion valido = new Validacion(jugador1, jugador2); 
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
                    bool c = Turno(jugador1, jugador2, 1, 2, turno);
                    if (c == true)
                    {
                        break;
                    }
                }
                else
                {
                    bool c = Turno(jugador2, jugador1, 2, 1, turno);
                    if (c == true)
                    {
                        break;
                    }
                }
                if (jugador1.perdio())
                {
                    _view.WriteLine("Player 2 ganó");
                    break; 
                }
                else if (jugador2.perdio())
                {
                    _view.WriteLine("Player 1 ganó");
                    break; 
                }
                turno += 1;
            }

            
        }
    }
}

