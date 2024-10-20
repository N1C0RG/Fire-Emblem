using Fire_Emblem_View;
using Fire_Emblem.Habilidades;

namespace Fire_Emblem
{
    public class Game
    {
        private readonly View _view;
        private readonly string _teamsFolder;
        private int _turno;
        private Personaje _playerPersonaje;
        private Personaje _rivalPersonaje;
        private Batalla _batalla;
        private Player _jugadorPlayer;
        private Player _rivalPlayer;

        public Game(View view, string teamsFolder)
        {
            _view = view;
            _teamsFolder = teamsFolder;
        }

        public void Play()
        {
            inicializacionPlay();
            var validacion = new Validacion(_jugadorPlayer, _rivalPlayer);
            if (!validacion.EquipoValido())
            {
                _view.WriteLine("Archivo de equipos no válido");
                return;
            }

            _turno = 1;
            while (true)
            {
                ejecutarTurno();
                if (_jugadorPlayer.Perdio())
                {
                    _view.WriteLine("Player 2 ganó");
                    break;
                }
                if (_rivalPlayer.Perdio())
                {
                    _view.WriteLine("Player 1 ganó");
                    break;
                }
                _turno++;
            }
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
            _batalla.realizarAtaque(_playerPersonaje, _rivalPersonaje, _batalla.AtaqueJugador);
            if (_rivalPersonaje.HP == 0)
            {
                finRonda();
                return;
            }
            _batalla.realizarAtaque(_rivalPersonaje, _playerPersonaje, _batalla.AtaqueRival);
            _batalla.definirAtaque();
            if (_playerPersonaje.HP == 0)
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
            printOpciones(jugadorActual, jugadorActual.tipo);
            int jugadorActualInput = Convert.ToInt32(_view.ReadLine());

            printOpciones(rival, rival.tipo);
            int rivalInput = Convert.ToInt32(_view.ReadLine());

            _playerPersonaje = jugadorActual.equipo[jugadorActualInput];
            _rivalPersonaje = rival.equipo[rivalInput];

            _view.WriteLine($"Round {_turno}: {_playerPersonaje.name} (Player {jugadorActual.tipo}) comienza");
        }

        private void inicializarBatalla(Player jugadorActual, Player rival)
        {
            _batalla = new Batalla(_playerPersonaje, _rivalPersonaje, _view, jugadorActual, rival);
            _batalla.calcularVentajas();
            _batalla.printVentaja();
        }

        private void aplicarHabilidades()
        {
            _playerPersonaje.inicia_round = true;
            _playerPersonaje.resetearContenedoresDeStats();
            _rivalPersonaje.resetearContenedoresDeStats();

            var manejadorHabilidades = new HabilidadManager(_playerPersonaje, _rivalPersonaje, _view);
            manejadorHabilidades.aplicarTodo();
            
            _playerPersonaje.calcularNetosStats();
            _rivalPersonaje.calcularNetosStats();
            _playerPersonaje.inicia_round = false;
        }

        private void finRonda()
        {
            _batalla.printVidaEndRound();
            _batalla.removerJugador();
        }

        private void resetearValoresPersonajeTurno()
        {
            _playerPersonaje.first_atack = 1;
            _rivalPersonaje.first_atack = 1;
            _playerPersonaje.oponente_previo = _rivalPersonaje.name;
            _rivalPersonaje.oponente_previo = _playerPersonaje.name;
        }

        private void printEquipos()
        {
            _view.WriteLine("Elige un archivo para cargar los equipos");
            string[] teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
            for (int i = 0; i < teamFiles.Length; i++)
            {
                _view.WriteLine($"{i}: {Path.GetFileName(teamFiles[i])}");
            }
        }

        private void printOpciones(Player player, int playerNumber)
        {
            _view.WriteLine($"Player {playerNumber} selecciona una opción");
            for (int i = 0; i < player.equipo.Count; i++)
            {
                _view.WriteLine($"{i}: {player.equipo[i].name}");
            }
        }
    }
}