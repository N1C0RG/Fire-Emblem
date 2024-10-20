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
        //TODO: tengo que qrreglar lo del metodo del dano del follow up 
        var dataFollow = _manejadorFollowUp.obtenerDatosFollowUp(jugador, rival);
        _manejadorFollowUp.actualizarDanoFollowUp(AtaqueJugador, AtaqueRival, dataFollow, jugador, rival); //parte con error no quitar 
        _impresoraVentajaVidaAtaque.printFollowUp(dataFollow, jugador, rival);
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
        var dataFollow = _manejadorFollowUp.obtenerDatosFollowUp(jugador, rival); 
        _manejadorFollowUp.realizarFollowUp(jugador, rival, AtaqueJugador, AtaqueRival, dataFollow, _view);
    }

    public void removerJugador()
    {
        _removerJugador.removerJugador(jugador, equipoJugador);
        _removerJugador.removerJugador(rival, equipoRival);
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

    public void printFollowUp(DataFollowUp dataFollowUp, Personaje jugador, Personaje rival)
    {
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{jugador.name} ataca a {rival.name} con {dataFollowUp.AtkFollowJugador} de daño");
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            _view.WriteLine($"{rival.name} ataca a {jugador.name} con {dataFollowUp.AtkFollowRival} de daño");
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

public class DataFollowUp
{
    public int velocidadFollowJugador { get; set; }
    public int velocidadFollowRival { get; set; } = 5; 
    public int velocidadAdicionalFollowUp { get; set; }
    private int _atkFollowJugador;
    public int AtkFollowJugador
    {
        get { return _atkFollowJugador; }
        set { _atkFollowJugador = value < 0 ? 0 : value; }
    }
    private int _atkFollowRival;
    public int AtkFollowRival
    {
        get { return _atkFollowRival; }
        set { _atkFollowRival = value < 0 ? 0 : value; }
    }
}

public class ManejadorFollowUp
{
    
    public DataFollowUp obtenerDatosFollowUp(Personaje player, Personaje rival)
    {
        var dataFollowUp = new DataFollowUp
        {
            velocidadFollowJugador = player.spd + (player.netos_stats.ContainsKey("Spd") ? player.netos_stats["Spd"] : 0),
            velocidadFollowRival = rival.spd + (rival.netos_stats.ContainsKey("Spd") ? rival.netos_stats["Spd"] : 0),
            AtkFollowJugador = 0,
            AtkFollowRival = 0, 
            velocidadAdicionalFollowUp = 5
        };

        return dataFollowUp;
    }
    public void actualizarDanoFollowUp(int ataqueJugador, int ataqueRival, DataFollowUp dataFollowUp, Personaje jugador, Personaje rival)
    {
        dataFollowUp.AtkFollowJugador = ataqueJugador + jugador.atk_follow;
        dataFollowUp.AtkFollowRival = ataqueRival + rival.atk_follow;
    }
    public void realizarFollowUp(Personaje player, Personaje rival, int ataque_player, int ataque_rival, DataFollowUp dataFollowUp, View view)
    {
        actualizarDanoFollowUp(ataque_player, ataque_rival, dataFollowUp, player, rival);
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            rival.recivirDano(dataFollowUp.AtkFollowJugador);
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            player.recivirDano(dataFollowUp.AtkFollowRival);
        }
    }
}
public class RemoverJugador
{
    public void removerJugador(Personaje jugador, Player euqipoJugador)
    {
        if (jugador.estaMuerto())
        {
            euqipoJugador.eliminarPersonaje(jugador);
        }
    }
}
