using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Controlador;
using Fire_Emblem.Vista;

public class ControladorBatalla
{
    private readonly Batalla _batalla;
    private readonly VistaBatalla _vistaBatalla;
    private DataBatalla _dataBatalla; 

    public ControladorBatalla(Batalla batalla, VistaBatalla vistaBatalla)
    {
        _batalla = batalla;
        _vistaBatalla = vistaBatalla;
    }

    private void actualizarDataBatalla()
    {
        _dataBatalla = _batalla.obtenerDataBatalla();
    }
    public void IniciarBatalla()
    {
        _batalla.calcularVentajas();
        actualizarDataBatalla();
        _vistaBatalla.mostrarVentaja(_dataBatalla.jugador, _dataBatalla.rival, _dataBatalla.ventajaJugador); //TODO: rompo ley de demeter
        _batalla.definirAtaque();
    }

    public void combateBatalla()
    {
        actualizarDataBatalla();
        _batalla.realizarAtaque(_dataBatalla.jugador, _dataBatalla.rival, _batalla.AtaqueJugador);
        _vistaBatalla.mostrarAtaque(_dataBatalla.jugador, _dataBatalla.rival, _batalla.AtaqueJugador);
        if (_dataBatalla.rival.getHp() == 0)
        {
            finRonda();
            return;
        }
        actualizarDataBatalla();
        _batalla.realizarAtaque(_dataBatalla.rival, _dataBatalla.jugador, _batalla.AtaqueRival);
        _vistaBatalla.mostrarAtaque(_dataBatalla.rival, _dataBatalla.jugador, _batalla.AtaqueRival);
        _batalla.definirAtaque();
        
        if (_dataBatalla.jugador.getHp() == 0)
        {
            finRonda();
        }
        else
        {
            _batalla.realizarFollowUp();
            
            var dataFollow = _batalla._manejadorFollowUp.obtenerDatosFollowUp(_dataBatalla.jugador, _dataBatalla.rival);
            _batalla._manejadorFollowUp.actualizarDanoFollowUp(_batalla.AtaqueJugador, _batalla.AtaqueRival, dataFollow, _dataBatalla.jugador, _dataBatalla.rival);
            _vistaBatalla.MostrarFollowUp(dataFollow, _dataBatalla.jugador, _dataBatalla.rival);
            finRonda();
        }
        
    }
    private void finRonda()
    {
        _vistaBatalla.mostrarVidaEndRound(_dataBatalla.jugador, _dataBatalla.rival);
        _batalla.removerJugador();
    }
}