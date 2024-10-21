namespace Fire_Emblem.Controlador;
using Fire_Emblem.Vista;

public class ControladorBatalla
{
    private readonly Batalla _batalla;
    private readonly VistaBatalla _vistaBatalla;
    private Personaje _personajeJugador; 
    private Personaje _personajeRival;

    public ControladorBatalla(Batalla batalla, VistaBatalla vistaBatalla, Personaje personajeJugador, Personaje personajeRival)
    {
        _batalla = batalla;
        _vistaBatalla = vistaBatalla;
        _personajeJugador = personajeJugador; 
        _personajeRival = personajeRival;
    }

    public void IniciarBatalla()
    {
        _batalla.calcularVentajas();
        _vistaBatalla.mostrarVentaja(_batalla.jugador, _batalla.rival, _batalla._ventaja.ventajaJugador); //TODO: rompo ley de demeter
        _batalla.definirAtaque();
    }

    public void combateBatalla()
    {
        _batalla.realizarAtaque(_personajeJugador, _personajeRival, _batalla.AtaqueJugador);
        
        if (_personajeRival.getHp() == 0)
        {
            finRonda();
            return;
        }
        
        _batalla.realizarAtaque(_personajeRival, _personajeJugador, _batalla.AtaqueRival);
        
        _batalla.definirAtaque();
        
        if (_personajeJugador.getHp() == 0)
        {
            finRonda();
        }
        else
        {
            _batalla.realizarFollowUp();
            
            _batalla.printFollowUp();
            
            finRonda();
        }
        
    }
    private void finRonda()
    {
        _batalla.printVidaEndRound();
        _batalla.removerJugador();
    }
}