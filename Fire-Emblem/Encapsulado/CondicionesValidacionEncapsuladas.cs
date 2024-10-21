namespace FireEmblem.Encapsulado;
using Fire_Emblem;
public class CondicionesValidacionEncapsuladas
{
    private bool condicionValidacionLargo(Player jugador, Player rival)
    {
        bool condicion = jugador.getEquipo().Count > 3 || jugador.getEquipo().Count < 1 || rival.getEquipo().Count > 3 ||
                         rival.getEquipo().Count < 1;
        return condicion; 
    }
    private bool validacionRepetidosYCantidadHabilidad(Player jugador) 
    { 
        foreach (Personaje personaje in jugador.getEquipo())
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
        bool condicion = jugador.getHabilidades().Length > 2;
        return condicion; 
    }
    private bool condicionCantidadHabilidadesYRepetidos(Personaje jugador)
    {
        bool condicion = jugador.getHabilidades().Length == 2 && jugador.getHabilidades()[0] == jugador.getHabilidades()[1]; 
        return condicion; 
    }
    private bool validacionRepetidosNombre(Player jugador) 
    {
        List<string> nombreNoRepetidos = new List<string>(); 
        
        foreach (Personaje personaje in jugador.getEquipo()) 
        {
            if (nombreNoRepetidos.Contains(personaje.getNombre()))
            {
                return false; 
            }
            nombreNoRepetidos.Add(personaje.getNombre());
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