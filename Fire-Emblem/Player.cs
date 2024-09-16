using System.Reflection.Metadata.Ecma335;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class Player
{
    public List<Personaje> equipo;
    private View _view;
    public int tipo; 
    public Player(List<Personaje> equipo, View view, int tipo)
    {
        this.equipo = equipo;
        this._view = view;
        this.tipo = tipo; 
    }

    public bool Perdio()
    {
        if (0 == equipo.Count())
        {
            return true; 
        }
        else
        {
            return false; 
        }
    }
}
