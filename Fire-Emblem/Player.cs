using System.Reflection.Metadata.Ecma335;

namespace Fire_Emblem;

public class Player
{
    public List<Personaje> equipo;
    
    public Player(List<Personaje> equipo)
    {
        this.equipo = equipo; 
    }

    public bool perdio()
    {
        List<string> muertos = new List<string>();   
        foreach (Personaje i in equipo)
        {
            if (i.HP == 0)
            {
                muertos.Add(i.name);
            }
        }

        if (muertos.Count() == equipo.Count())
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
