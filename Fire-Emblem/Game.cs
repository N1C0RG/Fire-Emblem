using Fire_Emblem_View;
using Fire_Emblem.Controlador;
using Fire_Emblem.Habilidades;
using Fire_Emblem.Vista;

namespace Fire_Emblem
{
    public class Game
    {
        private readonly View _view;
        private readonly string _teamsFolder;
        
        private Player _jugadorPlayer;
        private Player _rivalPlayer;

        private VistaJuego vistaJuego; 

        public Game(View view, string teamsFolder)
        {
            _view = view;
            _teamsFolder = teamsFolder;
            vistaJuego = new VistaJuego(view); 
        }

        public void Play()
        {
            inicializacionPlay();
            
            var controladorJuego =
                new ControladorJuego(_view, _jugadorPlayer, _rivalPlayer); 
            controladorJuego.Play();
        }
        private void inicializacionPlay()
        {
            printEquipos();
            
            string erchivoSeleccionado = _view.ReadLine();
            
            var manejoArchivos = new ManejoArchivos(_teamsFolder, erchivoSeleccionado);
            manejoArchivos.guardarEquipo();
            
            _jugadorPlayer = new Player(manejoArchivos.crearEquipo(true), 1);
            _rivalPlayer = new Player(manejoArchivos.crearEquipo(false), 2);
        }
        private void printEquipos()
        {
            vistaJuego.mensajeElegirArchivo();
            string[] filesEquipo = Directory.GetFiles(_teamsFolder, "*.txt");
            vistaJuego.mensajeTodosArchivos(filesEquipo);
        }
    }
}