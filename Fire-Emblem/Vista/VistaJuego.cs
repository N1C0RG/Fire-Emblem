namespace Fire_Emblem.Vista;
using Fire_Emblem_View;

public class VistaJuego
{
    private readonly View _view;

    public VistaJuego(View view)
    {
        _view = view;
    }

    public void mensajeElegirArchivo()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
    }

    public void mensajeTodosArchivos(string[] filesEquipo)
    {
        for (int i = 0; i < filesEquipo.Length; i++)
        {
            _view.WriteLine($"{i}: {Path.GetFileName(filesEquipo[i])}");
        }
    }

    public void mensajeEquipoInvalido()
    {
        _view.WriteLine("Archivo de equipos no válido");
    }

    public void mensajeJugadorGanador(int numeroJugador)
    {
        _view.WriteLine($"Player {numeroJugador} ganó");
    }

    public void mensajeInicioTurno(int turno, string personaje, int numeroJugador)
    {
        _view.WriteLine($"Round {turno}: {personaje} (Player {numeroJugador}) comienza");
    }

    public void mensajeOpciones(Player jugador, int numeroJugador)
    {
        _view.WriteLine($"Player {numeroJugador} selecciona una opción");
        List<string> nombresPersonajes = jugador.getNombrePersonajes();
        for (int i = 0; i < nombresPersonajes.Count; i++)
        {
            _view.WriteLine($"{i}: {nombresPersonajes[i]}");
        }
    }
}

