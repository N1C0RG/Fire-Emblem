using Fire_Emblem.Vista;

namespace Fire_Emblem.Controlador;
using Fire_Emblem_View;
using Fire_Emblem.Habilidades;
public class ControladorJuego
{
    private readonly View _view;
    private readonly string _teamsFolder;
    private int _turno;
    private Personaje _personajeJugador;
    private Personaje _personajeRival;
    private Batalla _batalla;
    private Player _jugadorPlayer;
    private Player _rivalPlayer;

    private VistaJuego vistaJuego; 

    public ControladorJuego(View view, Player jugadorActual, Player rival, Personaje personajeJugador, Personaje personajeRival)
    {
        this._view = view;
        this._personajeJugador = personajeJugador;
        this._personajeRival = personajeRival;
        this._jugadorPlayer = jugadorActual; 
        this._rivalPlayer = rival;
        vistaJuego = new VistaJuego(view); 
    }
    public void Play()
    {
        var validacion = new Validacion(_jugadorPlayer, _rivalPlayer);
        
        if (!validacion.EquipoValido())
        {
            vistaJuego.mensajeEquipoInvalido();
            return;
        }

        _turno = 1;
        while (true)
        {
            ejecutarTurno();
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
            _turno++;
        }
    }
    private void ejecutarTurno()
    {
        if (_turno % 2 != 0)
        {
            procesarTurno(_jugadorPlayer, _rivalPlayer);
        }
        else
        {
            procesarTurno(_rivalPlayer, _jugadorPlayer);
        }
    }

    private void procesarTurno(Player jugadorActual, Player rival)
    {
        iniciarTurno(jugadorActual, rival);
        
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
        
        resetearValoresPersonajeTurno();
    }

    private void iniciarTurno(Player jugadorActual, Player rival)
    {
        inicializarTurno(jugadorActual, rival);
        
        inicializarBatalla(jugadorActual, rival);
        
        aplicarHabilidades();
        
        _batalla.definirAtaque();
    }

    private void inicializarTurno(Player jugadorActual, Player rival)
    {
        vistaJuego.mensajeOpciones(jugadorActual, jugadorActual.getTipo());
        int jugadorActualInput = Convert.ToInt32(_view.ReadLine());

        vistaJuego.mensajeOpciones(rival, rival.getTipo());
        int rivalInput = Convert.ToInt32(_view.ReadLine());

        _personajeJugador = jugadorActual.getPersonaje(jugadorActualInput);
        _personajeRival = rival.getPersonaje(rivalInput);

        vistaJuego.mensajeInicioTurno(_turno, _personajeJugador.getNombre(), jugadorActual.getTipo());
    }

    private void inicializarBatalla(Player jugadorActual, Player rival)
    {
        _batalla = new Batalla(_personajeJugador, _personajeRival, _view, jugadorActual, rival);
        _batalla.calcularVentajas();
        _batalla.printVentaja();
    }

    private void aplicarHabilidades()
    {
        _personajeJugador.setIniciaTurno(true);
        _personajeJugador.resetearContenedoresDeStats();
        _personajeRival.resetearContenedoresDeStats();

        var manejadorHabilidades = new HabilidadManager(_personajeJugador, _personajeRival, _view);
        manejadorHabilidades.aplicarTodo();
        
        _personajeJugador.calcularNetosStats();
        _personajeRival.calcularNetosStats();
        _personajeJugador.setIniciaTurno(false);
    }

    private void finRonda()
    {
        _batalla.printVidaEndRound();
        _batalla.removerJugador();
    }

    private void resetearValoresPersonajeTurno()
    {
        _personajeJugador.first_atack = 1;
        _personajeRival.first_atack = 1;
        _personajeJugador.oponente_previo = _personajeRival.name;
        _personajeRival.oponente_previo = _personajeJugador.name;
    }
}