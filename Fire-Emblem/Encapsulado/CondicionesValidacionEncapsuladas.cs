namespace FireEmblem.Encapsulado;
using Fire_Emblem;
public class CondicionesValidacionEncapsuladas
{
    private bool condicionValidacionLargo(Player jugador, Player rival)
    {
        bool condicion = jugador.equipo.Count > 3 || jugador.equipo.Count < 1 || rival.equipo.Count > 3 ||
                         rival.equipo.Count < 1;
        return condicion; 
    }
    private bool validacionRepetidosYCantidadHabilidad(Player jugador) 
    { 
        foreach (Personaje personaje in jugador.equipo)
        {
            if (condicionCantidadHabilidades(personaje))
            {
                return false; 
            }
            if (condicionCantidadHabilidadesYRepetidos(personaje))
            {
                return false; 
            }
        }
        return true; 
    }
    private bool condicionCantidadHabilidades(Personaje jugador)
    {
        bool condicion = jugador.habilidades.Length > 2;
        return condicion; 
    }
    private bool condicionCantidadHabilidadesYRepetidos(Personaje jugador)
    {
        bool condicion = jugador.habilidades.Length == 2 && jugador.habilidades[0] == jugador.habilidades[1]; 
        return condicion; 
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
    public bool validarEquipoCompleto(Player jugador, Player rival)
    {
        return !condicionValidacionLargo(jugador, rival)
               && validacionRepetidosYCantidadHabilidad(jugador)
               && validacionRepetidosYCantidadHabilidad(rival)
               && validacionRepetidosNombre(jugador)
               && validacionRepetidosNombre(rival);
    }
}