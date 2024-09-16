using Fire_Emblem_View;
namespace Fire_Emblem;
using Fire_Emblem;
using static View;
public class Batalla
{
    public Personaje player;
    public Personaje rival;
    public decimal v_player = 1;
    public decimal v_rival = 1;
    private View _view; 
    private int _atk_player = 0;
    private int _atk_rival = 0;
    public Player player_team;
    public Player rival_team; 
    public Batalla(Personaje player, Personaje rival, View view, Player player_team, Player rival_team)
    {
        this.player = player;
        this.rival = rival;
        _view = view;
        this.player_team = player_team;
        this.rival_team = rival_team;
    }

    public int ATK_PLAYER
    {
        get { return _atk_player;  }
        set
        {
            if (value < 0)
            {
                _atk_player = 0; 
            }
            else
            {
                _atk_player = value; 
            }
        }
    }
    public int ATK_RIVAL
    {
        get { return _atk_rival;  }
        set
        {
            if (value < 0)
            {
                _atk_rival = 0; 
            }
            else
            {
                _atk_rival = value; 
            }
        }
    }
    public void Ventajas()
    {
        if (player.weapon == "Sword" && rival.weapon == "Axe" ||
            player.weapon == "Lance" && rival.weapon == "Sword" ||
            player.weapon == "Axe" && rival.weapon == "Lance")
        {
            v_player = 1.2m;
            v_rival = 0.8m; 

        }
        else if (rival.weapon == "Sword" && player.weapon == "Axe" ||
                 rival.weapon == "Lance" && player.weapon == "Sword" ||
                 rival.weapon == "Axe" && player.weapon == "Lance")
        {
            v_player = 0.8m;
            v_rival = 1.2m; 
        }
        else
        {
            v_player = 1;
            v_rival = 1; 
        }
    }
    public void PrintVida()
    {
        if (v_player == 1.2m)
        {
            _view.WriteLine(
                $"{player.name} ({player.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})"); 
        }
        else if (v_player == 0.8m)
        {
            _view.WriteLine(
                $"{rival.name} ({rival.weapon}) tiene ventaja con respecto a {player.name} ({player.weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra"); 
        }
    }
    public void VidaEndRound()
    {
        _view.WriteLine($"{player.name} ({player.HP}) : {rival.name} ({rival.HP})");
    }

    public void DefinirAtack()
    {
        int def_rival = (player.weapon == "Magic") ? rival.res : rival.def; 
        int def_player = (rival.weapon == "Magic") ? player.res : player.def; 
        ATK_PLAYER = (int)Math.Floor(Convert.ToDecimal(player.atk) * v_player) - def_rival; 
        ATK_RIVAL = (int)Math.Floor(Convert.ToDecimal(rival.atk) * v_rival) - def_player; 
    }

    public void Atack(Personaje player, Personaje rival, int dano)
    {
        _view.WriteLine($"{player.name} ataca a {rival.name} con {dano} de daño");
        rival.HP -= dano; 
    }
    public void FollowUp()
    {
        if (player.spd >= rival.spd + 5)
        {
            _view.WriteLine($"{player.name} ataca a {rival.name} con {ATK_PLAYER} de daño");
            rival.HP -= ATK_PLAYER;
            
        }
        else if (player.spd + 5 <= rival.spd)
        {
            _view.WriteLine($"{rival.name} ataca a {player.name} con {ATK_RIVAL} de daño");
            player.HP -= ATK_RIVAL;
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }
    public void RemovePlayer()
    {
        if (player.HP == 0)
        {
            player_team.equipo.Remove(player);
        }
        else if (rival.HP == 0)
        {
            rival_team.equipo.Remove(rival);
        }
    }
}