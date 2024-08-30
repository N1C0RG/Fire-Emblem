namespace Fire_Emblem;

public class ManejoArchivos
{
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
}