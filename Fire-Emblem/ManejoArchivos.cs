using System.Runtime.CompilerServices;

namespace Fire_Emblem;

public class ManejoArchivos
{
    private List<Personaje> player_team = new List<Personaje>();  
    public (List<string>, List<string>) GuardarEquipo(string archivo_seleccionado, string team_folder) //TODO: hacer que este en clean code 
    {
        List<string> player1Team = new List<string>(); 
        List<string> player2Team = new List<string>();
        bool cambiar_p2 = false;
        foreach (string personaje in LeerArchivo(archivo_seleccionado, team_folder))
        {
            if (personaje == "Player 2 Team" || cambiar_p2 == true)
            {
                cambiar_p2 = true; 
                player2Team.Add(personaje);
            }
            else
            {
                player1Team.Add(personaje);
            }
        }
        player1Team.RemoveAt(0);
        player2Team.RemoveAt(0);
        return (player1Team, player2Team); 
    }
    public string[] LeerArchivo(string archivo_seleccionado, string team_folder)
    {
        string equipo_seleccionado = archivo_seleccionado;
        string filename = $"{equipo_seleccionado.ToString().PadLeft(3, '0')}.txt";
        string fullPath = Path.Combine(team_folder, filename);
        return File.ReadAllLines(fullPath); 
    }
    
    public List<List<string>> PersonajesHabilidades(List<string> player_team)//TODO: esto no deberia ir en manejo de archivos, metorlo en una clase adecuada 
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
    
    //########################################################################################################
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
                    Convert.ToInt32(i.Def), Convert.ToInt32(i.Res), habilidaes));
            }
        }
    }
}