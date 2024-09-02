using Fire_Emblem_View;
namespace Fire_Emblem;
using Fire_Emblem;
using static View;
public class Batalla
{
    public Personaje player;
    public Personaje rival;
    public int t = 0;
    public bool? v_player = null;
    public bool? v_rival = null;
    private View _view; 
    public Batalla(Personaje player, Personaje rival, View view)
    {
        this.player = player;
        this.rival = rival;
        _view = view;
    }
    public void ventajas()
    {
        if (player.weapon == "Sword" && rival.weapon == "Axe" ||
            player.weapon == "Lance" && rival.weapon == "Sword" ||
            player.weapon == "Axe" && rival.weapon == "Lance")
        {
            v_player = true;
            v_rival = false; 

        }
        else if (rival.weapon == "Sword" && player.weapon == "Axe" ||
                 rival.weapon == "Lance" && player.weapon == "Sword" ||
                 rival.weapon == "Axe" && player.weapon == "Lance")
        {
            v_player = false;
            v_rival = true; 
        }
        else
        {
            v_player = null;
            v_rival = null; 
        }
    }
    public void print_vida()
    {
        if (v_player == true)
        {
            _view.WriteLine(
                $"{player.name} ({player.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})"); 
        }
        else if (v_player == false)
        {
            _view.WriteLine(
                $"{rival.name} ({rival.weapon}) tiene ventaja con respecto a {player.name} ({player.weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra"); 
        }
    }
    public void vida()
    {
        _view.WriteLine($"{player.name} ({player.HP}) : {rival.name} ({rival.HP})");
    }
    public void turno()
    {
    }
    public string follow_up()
    {
        if (player.spd >= rival.spd + 5)
        {
            return $"{player.name} ataca a {rival.name} con de daño";
        }
        else if (player.spd + 5 <= rival.spd)
        {
            return $"{rival.name} ataca a {player.name} con de daño";
        }
        else
        {
            return "Ninguna unidad puede hacer un follow up";
        }
    }
}