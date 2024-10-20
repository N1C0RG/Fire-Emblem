using Fire_Emblem_View;
using Fire_Emblem.Habilidades;
namespace Fire_Emblem;

public class Batalla
{
    public Personaje jugador;
    public Personaje rival;
    private View _view;
    public Player equipoJugador;
    public Player equipoRival;
    private Ventaja _ventaja;
    private ImpresoraVentajaVidaAtaque _impresoraVentajaVidaAtaque;
    private ManejadorDeAtaques _manejadorDeAtaques;
    private ManejadorFollowUp _manejadorFollowUp;
    private RemoverJugador _removerJugador;
    
    private int _ataqueJugador;
    public int AtaqueJugador
    {
        get { return _ataqueJugador; }
        private set { _ataqueJugador = value < 0 ? 0 : value; }
    }
    private int _ataqueRival;
    public int AtaqueRival
    {
        get { return _ataqueRival; }
        private set { _ataqueRival = value < 0 ? 0 : value; }
    }
    public Batalla(Personaje player, Personaje rival, View view, Player equipoJugador, Player equipoRival)
    {
        this.jugador = player;
        this.rival = rival;
        _view = view;
        this.equipoJugador = equipoJugador;
        this.equipoRival = equipoRival;
        _ventaja = new Ventaja();
        _impresoraVentajaVidaAtaque = new ImpresoraVentajaVidaAtaque(view);
        _manejadorDeAtaques = new ManejadorDeAtaques();
        _manejadorFollowUp = new ManejadorFollowUp();
        _removerJugador = new RemoverJugador();
    }

    public void calcularVentajas()
    {
        _ventaja.calcularVentaja(jugador, rival);
    }

    public void printVentaja()
    {
        _impresoraVentajaVidaAtaque.printVentaja(jugador, rival, _ventaja.ventajaJugador);
    }

    public void printVidaEndRound()
    {
        _impresoraVentajaVidaAtaque.printVidaEndRound(jugador, rival);
    }
    
    public void printFollowUp()
    {
        _impresoraVentajaVidaAtaque.printFollowUp(_manejadorFollowUp, jugador, rival);
    }

    public void definirAtaque()  
    
    {
        AtaqueJugador = _manejadorDeAtaques.calcularAtaque(jugador, rival, _ventaja.ventajaJugador);
        AtaqueRival = _manejadorDeAtaques.calcularAtaque(rival, jugador, _ventaja.ventajaRival);
    }
    
    public void realizarAtaque(Personaje jugador, Personaje rival, int dano)
    {
        _manejadorDeAtaques.accionAtacar(jugador, rival, dano);
        _impresoraVentajaVidaAtaque.printAtaque(jugador, rival, dano);
    }

    public void realizarFollowUp()
    {
        _manejadorFollowUp.realizarFollowUp(jugador, rival, AtaqueJugador, AtaqueRival);
    }

    public void removerJugador()
    {
        _removerJugador.removerJugador(jugador, rival, equipoJugador, equipoRival);
    }
}
public class ImpresoraVentajaVidaAtaque
{
    private View _view;

    public ImpresoraVentajaVidaAtaque(View view)
    {
        _view = view;
    }

    public void printVentaja(Personaje jugador, Personaje rival, decimal ventajaJugador)
    {
        if (ventajaJugador == 1.2m)
        {
            _view.WriteLine($"{jugador.name} ({jugador.weapon}) tiene ventaja con respecto a {rival.name} ({rival.weapon})");
        }
        else if (ventajaJugador == 0.8m)
        {
            _view.WriteLine($"{rival.name} ({rival.weapon}) tiene ventaja con respecto a {jugador.name} ({jugador.weapon})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public void printVidaEndRound(Personaje jugador, Personaje rival)
    {
        _view.WriteLine($"{jugador.name} ({jugador.HP}) : {rival.name} ({rival.HP})");
    }

    public void printFollowUp(ManejadorFollowUp follow, Personaje jugador, Personaje rival)
    {
        if (follow.spdFollowJugador >= follow.spdFollowRival + follow.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{jugador.name} ataca a {rival.name} con {follow.AtkFollowJugador} de daño");
        }
        else if (follow.spdFollowJugador + follow.velocidadAdicionalFollowUp <= follow.spdFollowRival)
        {
            _view.WriteLine($"{rival.name} ataca a {jugador.name} con {follow.AtkFollowRival} de daño");
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up"); 
        }
    }
    public void printAtaque(Personaje jugador, Personaje rival, int dano)
    {
        _view.WriteLine($"{jugador.name} ataca a {rival.name} con {dano} de daño");
    }
}
public class Ventaja
{
    public decimal ventajaJugador { get; private set; } = 1;
    public decimal ventajaRival { get; private set; } = 1;
    
    public decimal multiplicadorVentaja { get; private set; } = 1.2m;
    
    public decimal multiplicadorDesventaja { get; private set; } = 0.8m;
    
    public decimal multiplicadorDefault { get; private set; } = 1m;

    public void calcularVentaja(Personaje jugador, Personaje rival)
    {
        if (jugador.weapon == Armas.Sword.ToString() && rival.weapon == Armas.Axe.ToString() || //TODO: solamente usar el enum para las armas 
            jugador.weapon == Armas.Lance.ToString() && rival.weapon == Armas.Sword.ToString() ||
            jugador.weapon == Armas.Axe.ToString() && rival.weapon == Armas.Lance.ToString())
        {
            ventajaJugador = multiplicadorVentaja;
            ventajaRival = multiplicadorDesventaja;
        }
        else if (rival.weapon == Armas.Sword.ToString() && jugador.weapon == Armas.Axe.ToString() ||
                 rival.weapon == Armas.Lance.ToString() && jugador.weapon == Armas.Sword.ToString() ||
                 rival.weapon == Armas.Axe.ToString() && jugador.weapon == Armas.Lance.ToString())
        {
            ventajaJugador = multiplicadorDesventaja;
            ventajaRival = multiplicadorVentaja;
        }
        else
        {
            ventajaJugador = multiplicadorDefault;
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
    public void realizarFollowUp(Personaje jugador, Personaje rival, int ataqueJugador, int ataqueRival)
    {
        definirFollowUpAtk(jugador, rival, ataqueJugador, ataqueRival);
        definirFollowUpSpd(jugador, rival);
        
        if (spdFollowJugador >= spdFollowRival + velocidadAdicionalFollowUp)
        {
            rival.HP -= AtkFollowJugador;
        }
        else if (spdFollowJugador + velocidadAdicionalFollowUp <= spdFollowRival)
        {
            jugador.HP -= AtkFollowRival;
        }
    }
    private void definirFollowUpAtk(Personaje jugador, Personaje rival, int ataque_player, int ataque_rival)
    {
        AtkFollowJugador = ataque_player + jugador.atk_follow;
        AtkFollowRival = ataque_rival + rival.atk_follow;
    }
    private void definirFollowUpSpd(Personaje jugador, Personaje rival)
    {
        spdFollowJugador = jugador.spd;
        spdFollowRival = rival.spd;
        
        if (jugador.netos_stats.ContainsKey("Spd"))
        {
            spdFollowJugador += jugador.netos_stats["Spd"];
        }
        if (rival.netos_stats.ContainsKey("Spd"))
        {
            spdFollowRival += rival.netos_stats["Spd"];
        }
    }
}
public class RemoverJugador
{
    public void removerJugador(Personaje jugador, Personaje rival, Player euqipoJugador, Player equipoRival)
    {
        if (jugador.HP == 0)
        {
            euqipoJugador.equipo.Remove(jugador);
        }
        else if (rival.HP == 0)
        {
            equipoRival.equipo.Remove(rival);
        }
    }
}
