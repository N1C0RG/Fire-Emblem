using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;
using Fire_Emblem.Habilidades;
namespace Fire_Emblem;

public class Batalla 
{
    public Personaje jugador;
    public Personaje rival;
    public Player equipoJugador;
    public Player equipoRival;
    public Ventaja _ventaja;
    private CalculadorDeAtaque _calculadorDeAtaque;
    private ManejadorDeAtaques _manejadorDeAtaques;
    public ManejadorFollowUp _manejadorFollowUp;
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
    public Batalla(Personaje jugador, Personaje rival, Player equipoJugador, Player equipoRival)
    {
        this.jugador = jugador;
        this.rival = rival;
        this.equipoJugador = equipoJugador;
        this.equipoRival = equipoRival;
        _ventaja = new Ventaja();
        _manejadorDeAtaques = new ManejadorDeAtaques();
        _manejadorFollowUp = new ManejadorFollowUp();
        _removerJugador = new RemoverJugador();

        _calculadorDeAtaque = new CalculadorDeAtaque(); 
    }

    public void calcularVentajas()
    {
        _ventaja.calcularVentaja(jugador, rival);
    }
    public void definirAtaque()  
    {
        AtaqueJugador = _calculadorDeAtaque.calcularAtaque(jugador, rival, _ventaja.ventajaJugador);
        AtaqueRival = _calculadorDeAtaque.calcularAtaque(rival, jugador, _ventaja.ventajaRival);
    }
    
    public void realizarAtaque(Personaje jugador, Personaje rival, int dano)
    {
        _manejadorDeAtaques.accionAtacar(jugador, rival, dano);
    }
    
    public void realizarFollowUp()
    {
        var calculadorFollowUp = new CalculadorFollowUp();
        var dataFollowUp = calculadorFollowUp.obtenerDatosFollowUp(jugador, rival, _ventaja.ventajaJugador,
            _ventaja.ventajaRival); 
        _manejadorFollowUp.realizarFollowUp(jugador, rival, dataFollowUp);
    }

    public void removerJugador()
    {
        _removerJugador.removerJugador(jugador, equipoJugador);
        _removerJugador.removerJugador(rival, equipoRival);
    }

    public DataBatalla obtenerDataBatalla()
    {
        var calculadorFollowUp = new CalculadorFollowUp();
        var dataFollowUp = calculadorFollowUp.obtenerDatosFollowUp(jugador, rival, _ventaja.ventajaJugador, 
            _ventaja.ventajaRival); 
        return new DataBatalla(jugador, rival, _ventaja.ventajaJugador, dataFollowUp);
    }
}






