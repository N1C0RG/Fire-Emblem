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
    private ImpresoraVentajaVidaAtaque _impresoraVentajaVidaAtaque;
    private ManejadorDeAtaques _manejadorDeAtaques;
    private ManejadorFollowUp _manejadorFollowUp;
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
        _impresoraVentajaVidaAtaque = new ImpresoraVentajaVidaAtaque(view);
        _manejadorDeAtaques = new ManejadorDeAtaques();
        _manejadorFollowUp = new ManejadorFollowUp();
        _removerJugador = new RemoverJugador();
    }

    public void calcularVentajas()
    {
        _ventaja.calcularVentaja(player, rival);
    }

    public void printVentaja()
    {
        _impresoraVentajaVidaAtaque.printVentaja(player, rival, _ventaja.ventajaPlayer);
    }

    public void printVidaEndRound()
    {
        _impresoraVentajaVidaAtaque.printVidaEndRound(player, rival);
    }
    
    public void printFollowUp()
    {
        _impresoraVentajaVidaAtaque.printFollowUp(_manejadorFollowUp, player, rival);
    }

    public void definirAtaque()  
    
    {
        AtkPlayer = _manejadorDeAtaques.calcularAtaque(player, rival, _ventaja.ventajaPlayer);
        AtkRival = _manejadorDeAtaques.calcularAtaque(rival, player, _ventaja.ventajaRival);
    }
    
    public void realizarAtaque(Personaje player, Personaje rival, int dano)
    {
        _manejadorDeAtaques.accionAtacar(player, rival, dano);
        _impresoraVentajaVidaAtaque.printAtaque(player, rival, dano);
    }

    public void realizarFollowUp()
    {
        _manejadorFollowUp.realizarFollowUp(player, rival, AtkPlayer, AtkRival);
    }

    public void removerJugador()
    {
        _removerJugador.removerJugador(player, rival, player_team, rival_team);
    }
}
public class ImpresoraVentajaVidaAtaque
{
    private View _view;

    public ImpresoraVentajaVidaAtaque(View view)
    {
        _view = view;
    }

    public void printVentaja(Personaje player, Personaje rival, decimal ventaja_player)
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

    public void printVidaEndRound(Personaje player, Personaje rival)
    {
        _view.WriteLine($"{player.name} ({player.HP}) : {rival.name} ({rival.HP})");
    }

    public void printFollowUp(ManejadorFollowUp follow, Personaje player, Personaje rival)
    {
        if (follow.spdFollowJugador >= follow.spdFollowRival + follow.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{player.name} ataca a {rival.name} con {follow.AtkFollowJugador} de daño");
        }
        else if (follow.spdFollowJugador + follow.velocidadAdicionalFollowUp <= follow.spdFollowRival)
        {
            _view.WriteLine($"{rival.name} ataca a {player.name} con {follow.AtkFollowRival} de daño");
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up"); 
        }
    }
    public void printAtaque(Personaje player, Personaje rival, int dano)
    {
        _view.WriteLine($"{player.name} ataca a {rival.name} con {dano} de daño");
    }
}
public class Ventaja
{
    public decimal ventajaPlayer { get; private set; } = 1;
    public decimal ventajaRival { get; private set; } = 1;
    
    public decimal multiplicadorVentaja { get; private set; } = 1.2m;
    
    public decimal multiplicadorDesventaja { get; private set; } = 0.8m;
    
    public decimal multiplicadorDefault { get; private set; } = 1m;

    public void calcularVentaja(Personaje player, Personaje rival)
    {
        if (player.weapon == Armas.Sword.ToString() && rival.weapon == Armas.Axe.ToString() || //TODO: solamente usar el enum para las armas 
            player.weapon == Armas.Lance.ToString() && rival.weapon == Armas.Sword.ToString() ||
            player.weapon == Armas.Axe.ToString() && rival.weapon == Armas.Lance.ToString())
        {
            ventajaPlayer = multiplicadorVentaja;
            ventajaRival = multiplicadorDesventaja;
        }
        else if (rival.weapon == Armas.Sword.ToString() && player.weapon == Armas.Axe.ToString() ||
                 rival.weapon == Armas.Lance.ToString() && player.weapon == Armas.Sword.ToString() ||
                 rival.weapon == Armas.Axe.ToString() && player.weapon == Armas.Lance.ToString())
        {
            ventajaPlayer = multiplicadorDesventaja;
            ventajaRival = multiplicadorVentaja;
        }
        else
        {
            ventajaPlayer = multiplicadorDefault;
            ventajaRival = multiplicadorDefault;
        }
    }
}
public class ManejadorDeAtaques
{
    private int _defensa; 
    
    public int calcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        
        //TODO: arreglar esto
        atacante.ResetearStatsPorFirstAtack();
        defensor.ResetearStatsPorFirstAtack(); 
        
        calcularDefensa(atacante, defensor);

        int ataque =
            (int)Math.Floor(Convert.ToDecimal(atacante.atk +
                              (atacante.netos_stats.ContainsKey("Atk")
                                  ? atacante.netos_stats["Atk"]
                                  : 0)) * ventaja) - _defensa;
        return ataque;
    }

    private void calcularDefensa(Personaje atacante, Personaje defensor)
    {
        _defensa = (atacante.weapon == Armas.Magic.ToString()) ? defensor.res : defensor.def;
        
        if (atacante.weapon != Armas.Magic.ToString() && defensor.netos_stats.ContainsKey("Def"))
        {
            _defensa += defensor.netos_stats["Def"];
        }
        if (atacante.weapon == Armas.Magic.ToString() && defensor.netos_stats.ContainsKey("Res"))
        {
            _defensa += defensor.netos_stats["Res"];
        }
    }
    
    public void accionAtacar(Personaje atacante, Personaje defensor, int dano)
    {
        defensor.HP -= dano;
        atacante.first_atack += 1;
    }
}
public class ManejadorFollowUp
{
    private int _atkFollowJugador;
    public int AtkFollowJugador
    {
        get { return _atkFollowJugador; }
        private set { _atkFollowJugador = value < 0 ? 0 : value; }
    }
    private int _atkFollowRival;
    public int AtkFollowRival
    {
        get { return _atkFollowRival; }
        private set { _atkFollowRival = value < 0 ? 0 : value; }
    }
    public int spdFollowJugador { get; private set; }
    public int spdFollowRival { get; private set; }

    public int velocidadAdicionalFollowUp { get; private set; } = 5; 
    public void realizarFollowUp(Personaje player, Personaje rival, int ataque_player, int ataque_rival)
    {
        definirFollowUpAtk(player, rival, ataque_player, ataque_rival);
        definirFollowUpSpd(player, rival);
        
        if (spdFollowJugador >= spdFollowRival + velocidadAdicionalFollowUp)
        {
            rival.HP -= AtkFollowJugador;
        }
        else if (spdFollowJugador + velocidadAdicionalFollowUp <= spdFollowRival)
        {
            player.HP -= AtkFollowRival;
        }
    }
    private void definirFollowUpAtk(Personaje player, Personaje rival, int ataque_player, int ataque_rival)
    {
        AtkFollowJugador = ataque_player + player.atk_follow;
        AtkFollowRival = ataque_rival + rival.atk_follow;
    }
    private void definirFollowUpSpd(Personaje player, Personaje rival)
    {
        spdFollowJugador = player.spd;
        spdFollowRival = rival.spd;
        
        if (player.netos_stats.ContainsKey("Spd"))
        {
            spdFollowJugador += player.netos_stats["Spd"];
        }
        if (rival.netos_stats.ContainsKey("Spd"))
        {
            spdFollowRival += rival.netos_stats["Spd"];
        }
    }
}
public class RemoverJugador
{
    public void removerJugador(Personaje player, Personaje rival, Player playerTeam, Player rivalTeam)
    {
        if (player.HP == 0)
        {
            playerTeam.equipo.Remove(player);
        }
        else if (rival.HP == 0)
        {
            rivalTeam.equipo.Remove(rival);
        }
    }
}
