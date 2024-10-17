namespace Fire_Emblem;

using Fire_Emblem_View;

public class Validacion
{
    private Player _jugador;
    private Player _rival;
    public Validacion(Player jugador, Player rival)
    {
        _jugador = jugador;
        _rival = rival; 
    }
    private bool validacionLargo()
    {
        if (_jugador.equipo.Count > 3 || _jugador.equipo.Count < 1 || _rival.equipo.Count > 3 || _rival.equipo.Count < 1)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
    private bool validacionRepetidosYCantidadHabilidad(Player jugador) 
    { 
        foreach (Personaje personaje in jugador.equipo)
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
    
    private bool validacionRepetidosNombre(Player jugador) 
    {
        List<string> nombreNoRepetidos = new List<string>(); 
        
        foreach (Personaje personaje in jugador.equipo) 
        {
            if (nombreNoRepetidos.Contains(personaje.name))
            {
                return false; 
            }
            nombreNoRepetidos.Add(personaje.name);
        }
        return true; 
    }
    public bool EquipoValido()
    {
        if (validacionLargo() == false 
            || validacionRepetidosYCantidadHabilidad(_jugador) == false 
            || validacionRepetidosYCantidadHabilidad(_rival) == false
            || validacionRepetidosNombre(_jugador) == false
            || validacionRepetidosNombre(_rival) == false)
        {
            return false; 
        }
        return true; 
    }
}