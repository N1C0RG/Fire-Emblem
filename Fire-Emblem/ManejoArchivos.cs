using System.Runtime.CompilerServices;
using System.IO; 
namespace Fire_Emblem;
using Fire_Emblem_View;
public class ManejoArchivos
{
    public List<Personaje> player_team = new List<Personaje>();  
    private View _view;
    private string _team_folder;
    private string archivo_seleccionado;
    public List<string> jugadorTeam = new List<string>(); 
    public List<string> rivalTeam = new List<string>(); 

    public ManejoArchivos(View view, String team_folder, String archivo_seleccionado)
    {
        this._view = view; //TODO: arreglar este view de prueba 
        this._team_folder = team_folder;
        this.archivo_seleccionado = archivo_seleccionado; 
    }
    public void GuardarEquipo() //TODO: hacer que este en clean code 
    {
        bool cambiar_p2 = false;
        foreach (string personaje in LeerArchivo())
        {
            if (personaje == "Player 2 Team" || cambiar_p2 == true)
            {
                cambiar_p2 = true; 
                rivalTeam.Add(personaje);
            }
            else
            {
                jugadorTeam.Add(personaje);
            }
        }
        jugadorTeam.RemoveAt(0);
        rivalTeam.RemoveAt(0);
    }
    public string[] LeerArchivo()
    {
        string numero_file = archivo_seleccionado.ToString().PadLeft(3, '0'); 
        var path_completo_file = Directory.GetFiles(_team_folder).
            Where(file => Path.GetFileName(file).Contains(numero_file));
        return File.ReadAllLines(path_completo_file.ElementAt(0)); 
    }
    public List<Personaje> CrearEquipo(List<JsonContent> todos_personajes, List<string> player)
    {
        foreach (string personaje in player)
        {
            if (personaje.Contains("("))
            {
                var tupla = Slicing(personaje);
                DatosJson(todos_personajes, tupla.Item1, tupla.Item2);
            }
            else
            {
                var tupla = Slicing(personaje);
                DatosJson(todos_personajes, tupla.Item1, []);
            }
        }
        return player_team;  
    }

    public (string, string[]) Slicing(string personaje)
    {
        int inicio_indice = personaje.IndexOf('(');
        int fin_indice = personaje.IndexOf(')');
        
        if (inicio_indice == -1 || fin_indice == -1)
        {
            string nombre = personaje.Trim();
            return (nombre, new string[0]);
        }
        else
        {
            string nombre = personaje.Substring(0, inicio_indice).Trim();
            string habilidades_sin_separar = personaje.Substring(inicio_indice + 1, fin_indice - inicio_indice - 1);
            string[] habilidades = habilidades_sin_separar.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (nombre, habilidades);
        }
    }

    public void DatosJson(List<JsonContent> todos_personajes, string nombre, string[] habilidaes)
    {
        foreach (JsonContent i in todos_personajes)
        {
            if (nombre == i.Name)
            {
                player_team.Add(new Personaje(i.Name, i.Weapon, i.Gender, i.DeathQuote, 
                    Convert.ToInt32(i.HP), Convert.ToInt32(i.Atk), Convert.ToInt32(i.Spd), 
                    Convert.ToInt32(i.Def), Convert.ToInt32(i.Res), habilidaes, Convert.ToInt32(i.HP)));
            }
        }
    }
}