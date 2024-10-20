using System.Reflection.Metadata.Ecma335;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class Player
{
    public List<Personaje> equipo;
    public int tipo;
    public Player(List<Personaje> equipo, int tipo)
    {
        this.equipo = equipo;
        this.tipo = tipo;
    }

    public bool Perdio()
    {
        if (0 == equipo.Count())
        {
            return true; 
        }
        return false; 
    }
    
    public void eliminarPersonaje(Personaje personaje)
    {
        equipo.Remove(personaje);
    }

    public int getTipo()
    {
        return tipo; 
    }

    public Personaje getPersonaje(int indice)
    {
        return equipo[indice];
    }
    public string getNombrePersonaje(int indice)
    {
        return equipo[indice].getNombre();
    }

    public List<Personaje> getEquipo()
    {
        return equipo; 
    }
}
