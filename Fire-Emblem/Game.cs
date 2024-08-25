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
        int contador = 0;  
        foreach (string nombre in archivos_equipos)
        {
            contador ++; 
        }
        for (int numero = 0; numero < contador; numero++)
        {
            if (numero < 10)
            {
                string c = numero + ": 00" + numero + ".txt";  
                _view.WriteLine(c);
            }
            else if (numero < 100)
            {
                string c = numero + ": 0"  + numero + ".txt";
                _view.WriteLine(c);
                
            }
            else
            {
                string c = numero + ": " + numero + ".txt";
                _view.WriteLine(c);
            }
        }
    }
    public (List<string>, List<string>) ReadTeam()
    {
        string filename = ""; 
        string equipo_seleccionado = _view.ReadLine();
        if (equipo_seleccionado.Length == 1)
        {
            filename = "00" + equipo_seleccionado + ".txt"; 
        }
        else if (equipo_seleccionado.Length == 2)
        {
            filename = "0" + equipo_seleccionado + ".txt";
        }
        else
        {
            filename = equipo_seleccionado + ".txt";
        }
        string fullPath = Path.Combine(_teamsFolder, filename);
        string[] lines = File.ReadAllLines(fullPath);
        List<string> p1 = new List<string>(); 
        List<string> p2 = new List<string>();
        bool cambiar_p2 = false;
        foreach (string l in lines)
        {
            if (l == "Player 2 Team" || cambiar_p2 == true)
            {
                cambiar_p2 = true; 
                p2.Add(l);
            }
            else
            {
                p1.Add(l);
            }
        }
        p2.RemoveAt(0);
        p1.RemoveAt(0);
        return (p1, p2); 
    }

    public Boolean ValidacionLargo(List<string> p1, List<string> p2)
    {
        if (p1.Count > 3 || p1.Count < 1 || p2.Count > 3 || p2.Count < 1)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }

    public Boolean ValidacionRepetidosH(List<List<string>> player) 
    { 
        foreach (List<string> l in player)
        {
            if (l.Count > 2 && l[1] == l[2])
            {
                return false; 
            }
        }
        return true; 
    }
    
    public Boolean ValidacionRepetidosN(List<string> player) //siempre es falso esta mal 
    {
        List<string> lista = new List<string>(); 
        foreach (string i in player)
        {
            if (i.Contains("("))
            {
                int startIndex = i.IndexOf('(') + 1;
                lista.Add(i.Substring(0, startIndex-2));
            }
            else
            {
                lista.Add(i);
            }
        }

        List<string> prueba = new List<string>(); 
        foreach (string s in lista) 
        {
            if (prueba.Contains(s))
            {
                return false; 
            }
            else
            {
                prueba.Add(s);
            }
        }
        return true; 
    }

    public Boolean ValidacionHabilidades(List<List<string>> player)
    {
        if (player[0].Count > 3)
        {
            return false; 
        }

        return true; 
    }

    public List<List<string>> PersonajesHabilidades(List<string> player_team)
    {
        List<List<string>> player = new List<List<string>>();
        foreach (string i in player_team)
        {
            List<string> lista = new List<string>(); 
            if (i.Contains("("))
            {
                int startIndex = i.IndexOf('(') + 1;
                int endIndex = i.IndexOf(')');
                lista.Add(i.Substring(0, startIndex-2));
                string subcadena = i.Substring(startIndex, endIndex - startIndex);
                string[] habilidades = subcadena.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in habilidades)
                {
                    lista.Add(s.Trim());
                }
            }
            else
            {
                lista.Add(i); 
            }
            player.Add(lista);
        }
        return player; 
    }

    public List<Personaje> completar_personaje(List<JsonContent> todos_personajes, List<List<string>> player)
    {
        List<Personaje> lista = new List<Personaje>(); 
        foreach (List<string> l in player)
        {
            foreach (JsonContent i in todos_personajes) 
            {
                List<string> hd = new List<string>();  
                if (i.Name == l[0])
                {
                    if (l.Count > 1)
                    {
                        hd = l.GetRange(1, l.Count - 1); 
                    }
                    lista.Add(new Personaje(i.Name, i.Weapon, i.Gender, i.DeathQuote, Convert.ToInt32(i.HP),
                        Convert.ToInt32(i.Atk), Convert.ToInt32(i.Spd), Convert.ToInt32(i.Def), 
                        Convert.ToInt32(i.Res), hd));
                    
                }
                    
            }
        }
        return lista; 
    }
    
    public List<JsonContent> LoadJson()
    {
        string directorio_path = AppDomain.CurrentDomain.BaseDirectory; 
        string jsonFilePath = Path.Combine(directorio_path, "characters.json");
        string jsonString = File.ReadAllText(jsonFilePath);

        List<JsonContent> todos_personajes = JsonSerializer.Deserialize<List<JsonContent>>(jsonString);
        // foreach (JsonContent i in todos_personajes)
        // {
        //     _view.WriteLine(i.Hp);
        // }
        return todos_personajes; 
    }

    public void ShowTeam(Player player)
    {
        for (int i = 0; i < player.equipo.Count; i++)
        {
            if (player.equipo[i].HP > 0)
            {
                _view.WriteLine($"{i}: " + player.equipo[i].name);
            }
        }
    }

    public bool? Ventajas(Personaje player1, Personaje player2)
    {
        if (player1.weapon == "Sword" && player2.weapon == "Axe" ||
            player1.weapon == "Lance" && player2.weapon == "Sword" ||
            player1.weapon == "Axe" && player2.weapon == "Lance")
        {
            return true;

        }
        else if (player2.weapon == "Sword" && player1.weapon == "Axe" ||
                 player2.weapon == "Lance" && player1.weapon == "Sword" ||
                 player2.weapon == "Axe" && player1.weapon == "Lance")
        {
            return false;
        }
        else
        {
            return null;
        }

    }

    public void printV(Personaje p1, Personaje p2, bool? v)
    {
        if (v == true)
        {
            _view.WriteLine($"{p1.name} ({p1.weapon})" +
                            $" tiene ventaja con respecto a " +
                            $"{p2.name} ({p2.weapon})");
        }
        else if (v == false)
        {
            _view.WriteLine($"{p2.name} ({p2.weapon}) " +
                            $"tiene ventaja con respecto a " +
                            $"{p1.name} ({p1.weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public void Play()
    {
        PrintTeams();
        var tupla= ReadTeam();
        List<string> p1 = tupla.Item1;
        List<string> p2 = tupla.Item2;
        List<List<string>> player1 = PersonajesHabilidades(p1);
        List<List<string>> player2 = PersonajesHabilidades(p2);
        if (ValidacionLargo(p1, p2) == false || ValidacionRepetidosH(player1) == false || ValidacionRepetidosH(player2) == false
            || ValidacionHabilidades(player1) == false || ValidacionHabilidades(player2) == false || ValidacionRepetidosN(p1) == false || ValidacionRepetidosN(p2) == false)
        {
            _view.WriteLine("Archivo de equipos no válido");
        }
        else
        {
            List<JsonContent> todos_los_personajes = LoadJson();

            Player jugador1 = new Player(completar_personaje(todos_los_personajes, player1));
            Player jugador2 = new Player(completar_personaje(todos_los_personajes, player2));
            bool stop = false;
            int turno = 1; 
            while (stop == false)
            {
                int input1 = 0;
                int input2 = 0;
                int d1 = 0;
                int d2 = 0; 
                if (turno % 2 != 0)
                {
                    _view.WriteLine("Player 1 selecciona una opción");
                    ShowTeam(jugador1);
                    input1 = Convert.ToInt32(_view.ReadLine());
                    _view.WriteLine("Player 2 selecciona una opción");
                    ShowTeam(jugador2);
                    input2 = Convert.ToInt32(_view.ReadLine());
                    _view.WriteLine($"Round {turno}: {jugador1.equipo[input1].name} (Player 1) comienza");
                    bool? v1 = Ventajas(jugador1.equipo[input1], jugador2.equipo[input2]);
                    bool? v2 = Ventajas(jugador2.equipo[input2], jugador1.equipo[input1]);
                    printV(jugador1.equipo[input1], jugador2.equipo[input2], v1);
                    d1 = jugador1.equipo[input1].atacar(jugador2.equipo[input2], v1);
                    _view.WriteLine($"{jugador1.equipo[input1].name} ataca a" +
                                    $" {jugador2.equipo[input2].name} con {d1} de daño");
                    jugador2.equipo[input2].HP -= d1;
                    if (jugador2.perdio())
                    {
                        _view.WriteLine($"{jugador1.equipo[input1].name} ({jugador1.equipo[input1].HP}) : " +
                                $"{jugador2.equipo[input2].name} ({jugador2.equipo[input2].HP})");
                        _view.WriteLine("Player 1 ganó");
                        return; 
                    }
                    d2 = jugador2.equipo[input2].atacar(jugador1.equipo[input1], v2);
                    _view.WriteLine($"{jugador2.equipo[input2].name} ataca a" +
                                    $" {jugador1.equipo[input1].name} con {d2} de daño");
                    jugador1.equipo[input1].HP -= d2;
                }
                else
                {
                    _view.WriteLine("Player 2 selecciona una opción");
                    ShowTeam(jugador2);
                    input2 = Convert.ToInt32(_view.ReadLine());
                    _view.WriteLine("Player 1 selecciona una opción");
                    ShowTeam(jugador1);
                    input1 = Convert.ToInt32(_view.ReadLine());
                    _view.WriteLine($"Round {turno}: {jugador2.equipo[input2].name} (Player 2) comienza");
                    bool? v1 = Ventajas(jugador1.equipo[input1], jugador2.equipo[input2]);
                    bool? v2 = Ventajas(jugador2.equipo[input2], jugador1.equipo[input1]);
                    printV(jugador1.equipo[input1], jugador2.equipo[input2], v1);
                    d2 = jugador2.equipo[input2].atacar(jugador1.equipo[input1], v2);
                    _view.WriteLine($"{jugador2.equipo[input2].name} ataca a" +
                                    $" {jugador1.equipo[input1].name} con {d2} de daño");
                    jugador1.equipo[input1].HP -= d2;
                    
                    if (jugador1.perdio())
                    {
                        _view.WriteLine($"{jugador2.equipo[input2].name} ({jugador2.equipo[input2].HP}) : " +
                                        $"{jugador1.equipo[input1].name} ({jugador1.equipo[input1].HP})");
                        _view.WriteLine("Player 2 ganó");
                        return; 
                    }
                    d1 = jugador1.equipo[input1].atacar(jugador2.equipo[input2], v1);
                    _view.WriteLine($"{jugador1.equipo[input1].name} ataca a" +
                                    $" {jugador2.equipo[input2].name} con {d1} de daño");
                    jugador2.equipo[input2].HP -= d1;
                }
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
                if (turno % 2 != 0)
                {
                    _view.WriteLine($"{jugador1.equipo[input1].name} ({jugador1.equipo[input1].HP}) : " +
                                    $"{jugador2.equipo[input2].name} ({jugador2.equipo[input2].HP})");
                }
                else
                {
                    _view.WriteLine($"{jugador2.equipo[input2].name} ({jugador2.equipo[input2].HP}) : " +
                                    $"{jugador1.equipo[input1].name} ({jugador1.equipo[input1].HP})");
                }
                if (jugador1.perdio())
                {
                    _view.WriteLine("Player 2 ganó");
                    return; 
                }
                else if (jugador2.perdio())
                {
                    _view.WriteLine("Player 1 ganó");
                    return; 
                }

                if (jugador1.equipo[input1].HP == 0)
                {
                    jugador1.equipo.RemoveAt(input1);
                }
                else if (jugador2.equipo[input2].HP == 0)
                {
                    jugador2.equipo.RemoveAt(input2);
                }
                turno += 1;
            }

            
        }
    }
}

