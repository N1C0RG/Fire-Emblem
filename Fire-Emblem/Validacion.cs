namespace Fire_Emblem;

using Fire_Emblem_View;

public class Validacion
{
    public Player player;
    public Player rival;
    public Validacion(Player player, Player rival)
    {
        this.player = player;
        this.rival = rival; 
    }
    public bool ValidacionLargo()
    {
        if (player.equipo.Count > 3 || player.equipo.Count < 1 || rival.equipo.Count > 3 || rival.equipo.Count < 1)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
    public bool ValidacionRepetidosHabilidad(Player player) 
    { 
        foreach (Personaje personaje in player.equipo)
        {
            if (personaje.habilidades.Length > 2)
            {
                return false; 
            }
            if (personaje.habilidades.Length == 2 && personaje.habilidades[0] == personaje.habilidades[1])
            {
                return false; 
            }
        }
        return true; 
    }
    
    public bool ValidacionRepetidosNombre(Player player) 
    {
        List<string> lista = new List<string>(); 
        foreach (Personaje personaje in player.equipo)
        {
            lista.Add(personaje.name);
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
    public bool EquipoValido()
    {
        if (ValidacionLargo() == false || ValidacionRepetidosHabilidad(player) == false 
                                       || ValidacionRepetidosHabilidad(rival) == false
                                             || ValidacionRepetidosNombre(player) == false
                                             || ValidacionRepetidosNombre(rival) == false)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
}