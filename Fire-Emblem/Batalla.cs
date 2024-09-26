using Fire_Emblem_View;
using Fire_Emblem.Habilidades;

namespace Fire_Emblem;

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
    private RealizarFollowUp _seguidorDeAtaque;
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
        _seguidorDeAtaque = new RealizarFollowUp();
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
        _calculadoraDeAtaque.AccionAtacar(player, rival, dano);
        _Impresora.PrintAtaque(player, rival, dano);
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
public class Impresora
{
    private View _view;

    public Impresora(View view)
    {
        _view = view;
    }

    public void PrintVentaja(Personaje player, Personaje rival, decimal ventaja_player)
    {
        if (ventaja_player == 1.2m)
        {
            _view.WriteLine($"{player.name} ({player.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})");
        }
        else if (ventaja_player == 0.8m)
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

    public void PrintFollowUp(RealizarFollowUp follow, Personaje player, Personaje rival)
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
    public void PrintAtaque(Personaje player, Personaje rival, int dano)
    {
        _view.WriteLine($"{player.name} ataca a {rival.name} con {dano} de daño");
    }
}
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
public class CalculadoraDeAtaque
{
    public int CalcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        
        //TODO: arreglar esto
        atacante.ResetearStatsPorFirstAtack();
        defensor.ResetearStatsPorFirstAtack(); 

        int def = (atacante.weapon == "Magic") ? defensor.res : defensor.def;
        if (atacante.weapon != "Magic" && defensor.netos_stats.ContainsKey("Def"))
        {
            def += defensor.netos_stats["Def"];
        }
        if (atacante.weapon == "Magic" && defensor.netos_stats.ContainsKey("Res"))
        {
            def += defensor.netos_stats["Res"];
        }
        
        return (int)Math.Floor(Convert.ToDecimal(atacante.atk + (atacante.netos_stats.ContainsKey("Atk") ? atacante.netos_stats["Atk"] : 0)) * ventaja) - def;
    }
    public void AccionAtacar(Personaje atacante, Personaje defensor, int dano)
    {
        defensor.HP -= dano;
        atacante.first_atack += 1;
    }
}
public class RealizarFollowUp
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
        
        if (player.netos_stats.ContainsKey("Spd"))
        {
            follow_spd_jugador += player.netos_stats["Spd"];
        }
        if (rival.netos_stats.ContainsKey("Spd"))
        {
            follow_spd_rival += rival.netos_stats["Spd"];
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
