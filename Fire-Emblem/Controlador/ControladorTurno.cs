namespace Fire_Emblem.Controlador;
using Fire_Emblem_View;
using Fire_Emblem.Habilidades;
using Fire_Emblem.Vista;
public class ControladorTurno
{
    private View _view; 
    private readonly VistaJuego _vistaJuego;
    private readonly Player _jugadorPlayer;
    private readonly Player _rivalPlayer;
    private Personaje _personajeJugador;
    private Personaje _personajeRival;
    private Batalla _batalla;
    private int _turno;

    private ControladorBatalla _controladorBatalla; 
    
    public ControladorTurno(View view, Player jugadorPlayer, Player rivalPlayer) 
    {
        _view = view; 
        _vistaJuego = new VistaJuego(view); 
        _jugadorPlayer = jugadorPlayer;
        _rivalPlayer = rivalPlayer;
        _turno = 1; 
    }
    public void ejecutarTurno()
    {
        if (_turno % 2 != 0)
        {
            procesarTurno(_jugadorPlayer, _rivalPlayer);
        }
        else
        {
            procesarTurno(_rivalPlayer, _jugadorPlayer);
        }

        _turno++; 
    }

    private void procesarTurno(Player jugadorActual, Player rival)
    {
        iniciarTurno(jugadorActual, rival);
        
        _controladorBatalla.combateBatalla();
        
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
        _vistaJuego.mensajeOpciones(jugadorActual, jugadorActual.getTipo());
        int jugadorActualInput = Convert.ToInt32(_vistaJuego.leerInput());

        _vistaJuego.mensajeOpciones(rival, rival.getTipo());
        int rivalInput = Convert.ToInt32(_vistaJuego.leerInput());

        _personajeJugador = jugadorActual.getPersonaje(jugadorActualInput);
        _personajeRival = rival.getPersonaje(rivalInput);

        _vistaJuego.mensajeInicioTurno(_turno, _personajeJugador.getNombre(), jugadorActual.getTipo());
    }

    private void inicializarBatalla(Player jugadorActual, Player rival)
    {
        _batalla = new Batalla(_personajeJugador, _personajeRival, jugadorActual, rival);
        var vistaBatalla = new VistaBatalla(_view);
        _controladorBatalla = new ControladorBatalla(_batalla, vistaBatalla);
        _controladorBatalla.iniciarBatalla();
    }

    private void aplicarHabilidades()
    {
        _personajeJugador.setIniciaTurno(true);
        
        _personajeJugador.resetearContenedoresDeStats();
        _personajeRival.resetearContenedoresDeStats();

        var controladorHabilidades = new ControladorHabilidades(_personajeJugador, _personajeRival, _view);
        controladorHabilidades.aplicarTodo();
        
        _personajeJugador.calcularNetosStats();
        _personajeRival.calcularNetosStats();
        
        _personajeJugador.setIniciaTurno(false);
    }
    
    private void resetearValoresPersonajeTurno()
    {
        _personajeJugador.setContadorAtaques(1);
        _personajeRival.setContadorAtaques(1);
        _personajeJugador.setOponentePrevio(_personajeRival.getNombre()); 
        _personajeRival.setOponentePrevio(_personajeJugador.getNombre());
        
        _personajeJugador.reduccionDanoAbsoluta = 0;
        _personajeRival.reduccionDanoAbsoluta = 0;

        _personajeJugador.dataReduccionExtraStats.resetearAdicional();
        _personajeRival.dataReduccionExtraStats.resetearAdicional();
        _personajeJugador.dataReduccionExtraStats.resetearPorcentual();
        _personajeRival.dataReduccionExtraStats.resetearPorcentual();
        
        _personajeJugador.dataHabilidadStats.resetearPostEfecto();
        _personajeRival.dataHabilidadStats.resetearPostEfecto();
        
        _personajeJugador.primerCombateInicia = true;
        _personajeRival.primeraVexDefiende = true; 
    }
}
