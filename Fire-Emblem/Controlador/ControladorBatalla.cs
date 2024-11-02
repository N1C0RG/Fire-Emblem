using Fire_Emblem_View;
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
    public void iniciarBatalla()
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
        
        //todo: cambiar esto 
        
        _dataBatalla.jugador.dataHabilidadStats.primerAtaquePenalty.Clear();
        _dataBatalla.jugador.dataHabilidadStats.primerAtaqueBonus.Clear();
        _dataBatalla.rival.dataHabilidadStats.primerAtaquePenalty.Clear();
        _dataBatalla.rival.dataHabilidadStats.primerAtaqueBonus.Clear();
        
        if (_dataBatalla.jugador.getHp() == 0)
        {
            finRonda();
        }
        else
        {
            actualizarDataBatalla();
            _batalla.realizarFollowUp();
            
            _vistaBatalla.MostrarFollowUp(_dataBatalla.dataFollowUp, _dataBatalla.jugador, _dataBatalla.rival);
            finRonda();
        }
        
    }
    private void finRonda()
    {
        _vistaBatalla.mostrarVidaEndRound(_dataBatalla.jugador, _dataBatalla.rival);
        _batalla.removerJugador();
    }
}