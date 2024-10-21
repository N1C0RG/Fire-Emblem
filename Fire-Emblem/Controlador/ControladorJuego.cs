using Fire_Emblem.Vista;

namespace Fire_Emblem.Controlador;
using Fire_Emblem_View;
using Fire_Emblem.Habilidades;
public class ControladorJuego
{
    private View _view;
    private string _teamsFolder;
    
    private Player _jugadorPlayer;
    private Player _rivalPlayer;

    private VistaJuego vistaJuego;

    private ControladorTurno _controladorTurno;  

    public ControladorJuego(View view, Player jugadorActual, Player rival)
    {
        this._view = view;
        this._jugadorPlayer = jugadorActual; 
        this._rivalPlayer = rival;
        
        vistaJuego = new VistaJuego(view);
        _controladorTurno = new ControladorTurno(view, jugadorActual, rival); 
    }
    public void Play()
    {
        var validacion = new Validacion(_jugadorPlayer, _rivalPlayer);
        
        if (!validacion.EquipoValido())
        {
            vistaJuego.mensajeEquipoInvalido();
            return;
        }
        
        while (true)
        {
            _controladorTurno.ejecutarTurno();
            if (_jugadorPlayer.Perdio())
            {
                vistaJuego.mensajeJugadorGanador(2);
                break;
            }
            if (_rivalPlayer.Perdio())
            {
                vistaJuego.mensajeJugadorGanador(1);
                break;
            }
        }
    }
}