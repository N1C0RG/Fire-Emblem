using Fire_Emblem_View;
namespace Fire_Emblem;
using Fire_Emblem;
using static View;
// public class Batalla
// {
//     public Personaje player;
//     public Personaje rival;
//     public decimal v_player = 1;
//     public decimal v_rival = 1;
//     private View _view; 
//     private int _atk_player = 0;
//     private int _atk_rival = 0;
//     public Player player_team;
//     public Player rival_team;               
//     public Batalla(Personaje player, Personaje rival, View view, Player player_team, Player rival_team)
//     {
//         this.player = player;
//         this.rival = rival;
//         _view = view;
//         this.player_team = player_team;
//         this.rival_team = rival_team;
//     }
//     public int ATK_PLAYER
//     {
//         get { return _atk_player;  }
//         set
//         {
//             if (value < 0)
//             {
//                 _atk_player = 0; 
//             }
//             else
//             {
//                 _atk_player = value; 
//             }
//         }
//     }
//     public int ATK_RIVAL
//     {
//         get { return _atk_rival;  }
//         set
//         {
//             if (value < 0)
//             {
//                 _atk_rival = 0; 
//             }
//             else
//             {
//                 _atk_rival = value; 
//             }
//         }
//     }
//     public void Ventajas()
//     {
//         if (player.weapon == "Sword" && rival.weapon == "Axe" ||
//             player.weapon == "Lance" && rival.weapon == "Sword" ||
//             player.weapon == "Axe" && rival.weapon == "Lance")
//         {
//             v_player = 1.2m;
//             v_rival = 0.8m; 
//
//         }
//         else if (rival.weapon == "Sword" && player.weapon == "Axe" ||
//                  rival.weapon == "Lance" && player.weapon == "Sword" ||
//                  rival.weapon == "Axe" && player.weapon == "Lance")
//         {
//             v_player = 0.8m;
//             v_rival = 1.2m; 
//         }
//         else
//         {
//             v_player = 1;
//             v_rival = 1; 
//         }
//     }
//     public void PrintVentaja()
//     {
//         if (v_player == 1.2m)
//         {
//             _view.WriteLine(
//                 $"{player.name} ({player.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})"); 
//         }
//         else if (v_player == 0.8m)
//         {
//             _view.WriteLine(
//                 $"{rival.name} ({rival.weapon}) tiene ventaja con respecto a {player.name} ({player.weapon})");
//         }
//         else
//         {
//             _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra"); 
//         }
//     }
//     public void VidaEndRound()
//     {
//         _view.WriteLine($"{player.name} ({player.HP}) : {rival.name} ({rival.HP})");
//     }
//
//     public void DefinirAtack()
//     {
//         //TODO: arreglar esto creawr una clase o metodo que se encarge de aplicar los efectos al personaje 
//         int def_rival = (player.weapon == "Magic") ? rival.res : rival.def; 
//         int def_player = (rival.weapon == "Magic") ? player.res : player.def;
//         // _view.WriteLine($"{(int)Math.Floor(Convert.ToDecimal(player.atk) * v_player) - def_rival}");
//         // _view.WriteLine($"{(int)Math.Floor(Convert.ToDecimal(rival.atk) * v_rival) - def_player}");
//         if (player.weapon != "Magic" && rival.bonus_stats.ContainsKey("Def"))
//         {
//             def_rival += rival.bonus_stats["Def"]; 
//         }
//         if (player.weapon == "Magic" && rival.bonus_stats.ContainsKey("Res"))
//         {
//             def_rival += rival.bonus_stats["Res"]; 
//         }
//         if (rival.weapon != "Magic" && player.bonus_stats.ContainsKey("Def"))
//         {
//             def_player += player.bonus_stats["Def"]; 
//         }
//         if (rival.weapon == "Magic" && player.bonus_stats.ContainsKey("Res"))
//         {
//             def_player += player.bonus_stats["Res"]; 
//         }
//         
//         if (player.first_atack == 2 && player.habilidad_fa)
//         {
//             
//             player.bonus_stats["Atk"] = 0; 
//         }
//
//         if (rival.first_atack == 2 && rival.habilidad_fa)
//         {
//             rival.bonus_stats["Atk"] = 0; 
//         }
//         
//         ATK_PLAYER = (int)Math.Floor(Convert.ToDecimal(player.atk + (player.bonus_stats.ContainsKey("Atk") ? player.bonus_stats["Atk"] : 0)) * v_player) - def_rival; 
//         ATK_RIVAL = (int)Math.Floor(Convert.ToDecimal(rival.atk + (rival.bonus_stats.ContainsKey("Atk") ? rival.bonus_stats["Atk"] : 0)) * v_rival) - def_player;
//     }
//     
//
//     public void Atack(Personaje player, Personaje rival, int dano)
//     {
//         _view.WriteLine($"{player.name} ataca a {rival.name} con {dano} de daño");
//         rival.HP -= dano;
//         player.first_atack += 1; 
//     }
//     public void FollowUp()//TODO: arreglar esto 
//     {
//         int a = ATK_PLAYER + player.atk_follow;
//         int b = ATK_RIVAL + rival.atk_follow;
//         if (a < 0)
//         {
//             a = 0; 
//         }
//
//         if (b < 0)
//         {
//             b = 0; 
//         }
//          //TODO: arreglar esto 
//          int p_s = player.spd; 
//          int r_s = rival.spd; 
//          if (player.bonus_stats.ContainsKey("Spd"))
//          {
//              p_s = player.spd + player.bonus_stats["Spd"]; 
//          }
//          if (rival.bonus_stats.ContainsKey("Spd"))
//          {
//              r_s = rival.spd + rival.bonus_stats["Spd"]; 
//          }
//          if (p_s >= r_s + 5)
//          {
//              rival.HP -= a;
//          }
//          else if (p_s + 5 <= r_s)
//          {
//              player.HP -= b;
//          }
//     }
//     public void PrintFollowUp()//TODO: arreglar esto 
//     {
//         int a = ATK_PLAYER + player.atk_follow;
//         int b = ATK_RIVAL + rival.atk_follow;
//         if (a < 0)
//         {
//             a = 0; 
//         }
//
//         if (b < 0)
//         {
//             b = 0; 
//         }
//         //TODO: arreglar esto 
//         int p_s = player.spd; 
//         int r_s = rival.spd; 
//         if (player.bonus_stats.ContainsKey("Spd"))
//         {
//             p_s = player.spd + player.bonus_stats["Spd"]; 
//         }
//         if (rival.bonus_stats.ContainsKey("Spd"))
//         {
//             r_s = rival.spd + rival.bonus_stats["Spd"]; 
//         }
//
//         if (p_s >= r_s + 5)
//         {
//             _view.WriteLine($"{player.name} ataca a {rival.name} con {a} de daño");
//                  
//         }
//         else if (p_s + 5 <= r_s)
//         {
//             _view.WriteLine($"{rival.name} ataca a {player.name} con {b} de daño");
//         }
//         else
//         {
//             _view.WriteLine("Ninguna unidad puede hacer un follow up");
//         }
//     }
//     public void RemovePlayer()
//     {
//         if (player.HP == 0)
//         {
//             player_team.equipo.Remove(player);
//         }
//         else if (rival.HP == 0)
//         {
//             rival_team.equipo.Remove(rival);
//         }
//     }
// }

public class Ventaja
{
    public decimal ventaja_player { get; private set; } = 1;
    public decimal ventaj_rival { get; private set; } = 1;

    public void CalcularVentaja(Personaje player, Personaje rival)
    {
        if (player.weapon == "Sword" && rival.weapon == "Axe" ||
            player.weapon == "Lance" && rival.weapon == "Sword" ||
            player.weapon == "Axe" && rival.weapon == "Lance")
        {
            ventaja_player = 1.2m;
            ventaj_rival = 0.8m;
        }
        else if (rival.weapon == "Sword" && player.weapon == "Axe" ||
                 rival.weapon == "Lance" && player.weapon == "Sword" ||
                 rival.weapon == "Axe" && player.weapon == "Lance")
        {
            ventaja_player = 0.8m;
            ventaj_rival = 1.2m;
        }
        else
        {
            ventaja_player = 1;
            ventaj_rival = 1;
        }
    }
}
public class Impresora
{
    private View _view;

    public Impresora(View view)
    {
        _view = view;
    }

    public void PrintVentaja(Personaje player, Personaje rival, decimal v_player)
    {
        if (v_player == 1.2m)
        {
            _view.WriteLine($"{player.name} ({player.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})");
        }
        else if (v_player == 0.8m)
        {
            _view.WriteLine($"{rival.name} ({rival.weapon}) tiene ventaja con respecto a {player.name} ({player.weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public void PrintVida(Personaje player, Personaje rival)
    {
        _view.WriteLine($"{player.name} ({player.HP}) : {rival.name} ({rival.HP})");
    }

    public void PrintFollowUp(SeguidorDeAtaque follow, Personaje player, Personaje rival)
    {
        if (follow.follow_spd_jugador >= follow.follow_spd_rival + 5)
        {
            _view.WriteLine($"{player.name} ataca a {rival.name} con {follow.AtkFollowJugador} de daño");
        }
        else if (follow.follow_spd_jugador + 5 <= follow.follow_spd_rival)
        {
            _view.WriteLine($"{rival.name} ataca a {player.name} con {follow.AtkFollowRival} de daño");
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up"); 
        }
    }
}

public class CalculadoraDeAtaque
{
    public int CalcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        int def = (atacante.weapon == "Magic") ? defensor.res : defensor.def;
        if (atacante.weapon != "Magic" && defensor.bonus_stats.ContainsKey("Def"))
        {
            def += defensor.bonus_stats["Def"];
        }
        if (atacante.weapon == "Magic" && defensor.bonus_stats.ContainsKey("Res"))
        {
            def += defensor.bonus_stats["Res"];
        }
        return (int)Math.Floor(Convert.ToDecimal(atacante.atk + (atacante.bonus_stats.ContainsKey("Atk") ? atacante.bonus_stats["Atk"] : 0)) * ventaja) - def;
    }
}

public class SeguidorDeAtaque
{
    private int _atk_follow_jugador;
    public int AtkFollowJugador
    {
        get { return _atk_follow_jugador; }
        private set { _atk_follow_jugador = value < 0 ? 0 : value; }
    }
    private int _atk_follow_rival;
    public int AtkFollowRival
    {
        get { return _atk_follow_rival; }
        private set { _atk_follow_rival = value < 0 ? 0 : value; }
    }
    public int follow_spd_jugador { get; private set; }
    public int follow_spd_rival { get; private set; }
    public void FollowUp(Personaje player, Personaje rival, int atk_player, int atk_rival)
    {
        DefinirFollowUpAtk(player, rival, atk_player, atk_rival);
        DefinirFollowUpSpd(player, rival);
        if (follow_spd_jugador >= follow_spd_rival + 5)
        {
            rival.HP -= AtkFollowJugador;
        }
        else if (follow_spd_jugador + 5 <= follow_spd_rival)
        {
            player.HP -= AtkFollowRival;
        }
    }
    private void DefinirFollowUpAtk(Personaje player, Personaje rival, int atk_player, int atk_rival)
    {
        AtkFollowJugador = atk_player + player.atk_follow;
        AtkFollowRival = atk_rival + rival.atk_follow;
    }
    private void DefinirFollowUpSpd(Personaje player, Personaje rival)
    {
        follow_spd_jugador = player.spd;
        follow_spd_rival = rival.spd;
        if (player.bonus_stats.ContainsKey("Spd"))
        {
            follow_spd_jugador = player.bonus_stats["Spd"];
        }
        if (rival.bonus_stats.ContainsKey("Spd"))
        {
            follow_spd_rival = rival.bonus_stats["Spd"];
        }
    }
}

public class RemoverJugador
{
    public void RemovePlayer(Personaje player, Personaje rival, Player player_team, Player rival_team)
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
public class Batalla
{
    public Personaje player;
    public Personaje rival;
    private View _view;
    public Player player_team;
    public Player rival_team;
    private Ventaja _ventaja;
    private Impresora _Impresora;
    private CalculadoraDeAtaque _calculadoraDeAtaque;
    private SeguidorDeAtaque _seguidorDeAtaque;
    private RemoverJugador _removerJugador;
    
    private int _atkPlayer;
    public int AtkPlayer
    {
        get { return _atkPlayer; }
        private set { _atkPlayer = value < 0 ? 0 : value; }
    }
    private int _atkRival;
    public int AtkRival
    {
        get { return _atkRival; }
        private set { _atkRival = value < 0 ? 0 : value; }
    }
    public Batalla(Personaje player, Personaje rival, View view, Player player_team, Player rival_team)
    {
        this.player = player;
        this.rival = rival;
        _view = view;
        this.player_team = player_team;
        this.rival_team = rival_team;
        _ventaja = new Ventaja();
        _Impresora = new Impresora(view);
        _calculadoraDeAtaque = new CalculadoraDeAtaque();
        _seguidorDeAtaque = new SeguidorDeAtaque();
        _removerJugador = new RemoverJugador();
    }

    public void Ventajas()
    {
        _ventaja.CalcularVentaja(player, rival);
    }

    public void PrintVentaja()
    {
        _Impresora.PrintVentaja(player, rival, _ventaja.ventaja_player);
    }

    public void VidaEndRound()
    {
        _Impresora.PrintVida(player, rival);
    }
    
    public void PrintFollowUp()
    {
        _Impresora.PrintFollowUp(_seguidorDeAtaque, player, rival);
    }

    public void DefinirAtack()  
    
    {
        AtkPlayer = _calculadoraDeAtaque.CalcularAtaque(player, rival, _ventaja.ventaja_player);
        AtkRival = _calculadoraDeAtaque.CalcularAtaque(rival, player, _ventaja.ventaj_rival);
    }

    public void Atack(Personaje player, Personaje rival, int dano)
    {
        _view.WriteLine($"{player.name} ataca a {rival.name} con {dano} de daño");
        rival.HP -= dano;
        player.first_atack += 1;
    }

    public void FollowUp()
    {
        _seguidorDeAtaque.FollowUp(player, rival, AtkPlayer, AtkRival);
    }

    public void RemovePlayer()
    {
        _removerJugador.RemovePlayer(player, rival, player_team, rival_team);
    }
}