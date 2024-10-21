namespace Fire_Emblem.Controlador;
using Fire_Emblem.Vista;

public class ControladorBatalla
{
    private readonly Batalla _batalla;
    private readonly VistaBatalla _vistaBatalla;

    public ControladorBatalla(Batalla batalla, VistaBatalla vistaBatalla)
    {
        _batalla = batalla;
        _vistaBatalla = vistaBatalla;
    }

    public void IniciarBatalla()
    {
        _batalla.calcularVentajas();
        _vistaBatalla.mostrarVentaja(_batalla.jugador, _batalla.rival, _batalla._ventaja.ventajaJugador);
        _batalla.definirAtaque();
    }

    public void EjecutarAtaque()
    {
        _batalla.realizarAtaque(_batalla.jugador, _batalla.rival, _batalla.AtaqueJugador);
        _vistaBatalla.mostrarAtaque(_batalla.jugador, _batalla.rival, _batalla.AtaqueJugador);

        if (_batalla.rival.getHp() == 0)
        {
            _batalla.removerJugador();
            return;
        }

        _batalla.realizarAtaque(_batalla.rival, _batalla.jugador, _batalla.AtaqueRival);
        _vistaBatalla.mostrarAtaque(_batalla.rival, _batalla.jugador, _batalla.AtaqueRival);

        if (_batalla.jugador.getHp() == 0)
        {
            _batalla.removerJugador();
        }
        else
        {
            _batalla.realizarFollowUp();
            _vistaBatalla.MostrarFollowUp(_batalla._manejadorFollowUp.obtenerDatosFollowUp(_batalla.jugador, _batalla.rival), _batalla.jugador, _batalla.rival);
        }

        _vistaBatalla.mostrarVidaEndRound(_batalla.jugador, _batalla.rival);
    }
}