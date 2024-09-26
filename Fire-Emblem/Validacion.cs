namespace Fire_Emblem;

using Fire_Emblem_View;

public class Validacion
{
    private Player _player;
    private Player _rival;
    public Validacion(Player player, Player rival)
    {
        _player = player;
        _rival = rival; 
    }
    private bool ValidacionLargo()
    {
        if (_player.equipo.Count > 3 || _player.equipo.Count < 1 || _rival.equipo.Count > 3 || _rival.equipo.Count < 1)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
    private bool ValidacionRepetidosYCantidadHabilidad(Player player) 
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
    
    private bool ValidacionRepetidosNombre(Player player) 
    {
        List<string> prueba = new List<string>(); 
        
        foreach (Personaje personaje in player.equipo) 
        {
            if (prueba.Contains(personaje.name))
            {
                return false; 
            }
            prueba.Add(personaje.name);
        }
        return true; 
    }
    public bool EquipoValido()
    {
        if (ValidacionLargo() == false 
            || ValidacionRepetidosYCantidadHabilidad(_player) == false 
            || ValidacionRepetidosYCantidadHabilidad(_rival) == false
            || ValidacionRepetidosNombre(_player) == false
            || ValidacionRepetidosNombre(_rival) == false)
        {
            return false; 
        }
        return true; 
    }
}