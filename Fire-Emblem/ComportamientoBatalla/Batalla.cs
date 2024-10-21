using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;
using Fire_Emblem.Habilidades;
namespace Fire_Emblem;

public class Batalla //TODO: batalla hace muchas cosas sin razon alguna 
{
    public Personaje jugador;
    public Personaje rival;
    private View _view;
    public Player equipoJugador;
    public Player equipoRival;
    public Ventaja _ventaja;
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
    public Batalla(Personaje player, Personaje rival, View view, Player equipoJugador, Player equipoRival)
    {
        this.jugador = player;
        this.rival = rival;
        _view = view;
        this.equipoJugador = equipoJugador;
        this.equipoRival = equipoRival;
        _ventaja = new Ventaja();
        _manejadorDeAtaques = new ManejadorDeAtaques();
        _manejadorFollowUp = new ManejadorFollowUp();
        _removerJugador = new RemoverJugador();
    }

    public void calcularVentajas()
    {
        _ventaja.calcularVentaja(jugador, rival);
    }
    public void definirAtaque()  
    
    {
        AtaqueJugador = _manejadorDeAtaques.calcularAtaque(jugador, rival, _ventaja.ventajaJugador);
        AtaqueRival = _manejadorDeAtaques.calcularAtaque(rival, jugador, _ventaja.ventajaRival);
    }
    
    public void realizarAtaque(Personaje jugador, Personaje rival, int dano)
    {
        _manejadorDeAtaques.accionAtacar(jugador, rival, dano);
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

    public DataBatalla obtenerDataBatalla()
    {
        var dataFollow = _manejadorFollowUp.obtenerDatosFollowUp(jugador, rival);
        return new DataBatalla(jugador, rival, _ventaja.ventajaJugador, AtaqueJugador, AtaqueRival, dataFollow);
    }
}





