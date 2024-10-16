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
            InicializacionPlay();
            var validation = new Validacion(_jugadorPlayer, _rivalPlayer);
            if (!validation.EquipoValido())
            {
                _view.WriteLine("Archivo de equipos no válido");
                return;
            }

            _turno = 1;
            while (true)
            {
                EjecutarTurno();
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

        private void InicializacionPlay()
        {
            PrintEquipos();
            string selectedFile = _view.ReadLine();
            var fileHandler = new ManejoArchivos(_teamsFolder, selectedFile);
            fileHandler.GuardarEquipo();
            _jugadorPlayer = new Player(fileHandler.CrearEquipo(true), 1);
            _rivalPlayer = new Player(fileHandler.CrearEquipo(false), 2);
        }

        private void EjecutarTurno()
        {
            if (_turno % 2 != 0)
            {
                ProcesarTurno(_jugadorPlayer, _rivalPlayer);
            }
            else
            {
                ProcesarTurno(_rivalPlayer, _jugadorPlayer);
            }
        }

        private void ProcesarTurno(Player currentPlayer, Player opponent)
        {
            IniciarTurno(currentPlayer, opponent);
            _batalla.realizarAtaque(_playerPersonaje, _rivalPersonaje, _batalla.AtkPlayer);
            if (_rivalPersonaje.HP == 0)
            {
                EndRound();
                return;
            }
            _batalla.realizarAtaque(_rivalPersonaje, _playerPersonaje, _batalla.AtkRival);
            _batalla.definirAtaque();
            if (_playerPersonaje.HP == 0)
            {
                EndRound();
            }
            else
            {
                _batalla.realizarFollowUp();
                _batalla.printFollowUp();
                EndRound();
            }

            ResetearValoresPersonajeTurno();
        }

        private void IniciarTurno(Player currentPlayer, Player opponent)
        {
            InicializarTurno(currentPlayer, opponent);
            InicializarBatalla(currentPlayer, opponent);
            AplicarAbilities();
            _batalla.definirAtaque();
        }

        private void InicializarTurno(Player currentPlayer, Player opponent)
        {
            PrintOpciones(currentPlayer, currentPlayer.tipo);
            int playerInput = Convert.ToInt32(_view.ReadLine());

            PrintOpciones(opponent, opponent.tipo);
            int opponentInput = Convert.ToInt32(_view.ReadLine());

            _playerPersonaje = currentPlayer.equipo[playerInput];
            _rivalPersonaje = opponent.equipo[opponentInput];

            _view.WriteLine($"Round {_turno}: {_playerPersonaje.name} (Player {currentPlayer.tipo}) comienza");
        }

        private void InicializarBatalla(Player currentPlayer, Player opponent)
        {
            _batalla = new Batalla(_playerPersonaje, _rivalPersonaje, _view, currentPlayer, opponent);
            _batalla.calcularVentajas();
            _batalla.printVentaja();
        }

        private void AplicarAbilities()
        {
            _playerPersonaje.inicia_round = true;
            _playerPersonaje.ResetearContenedoresDeStats();
            _rivalPersonaje.ResetearContenedoresDeStats();

            var abilityExecutor = new HabilidadManager(_playerPersonaje, _rivalPersonaje, _view);
            abilityExecutor.aplicarTodo();
            
            _playerPersonaje.CalcularNetosStats();
            _rivalPersonaje.CalcularNetosStats();
            _playerPersonaje.inicia_round = false;
        }

        private void EndRound()
        {
            _batalla.printVidaEndRound();
            _batalla.removerJugador();
        }

        private void ResetearValoresPersonajeTurno()
        {
            _playerPersonaje.first_atack = 1;
            _rivalPersonaje.first_atack = 1;
            _playerPersonaje.oponente_previo = _rivalPersonaje.name;
            _rivalPersonaje.oponente_previo = _playerPersonaje.name;
        }

        private void PrintEquipos()
        {
            _view.WriteLine("Elige un archivo para cargar los equipos");
            string[] teamFiles = Directory.GetFiles(_teamsFolder, "*.txt");
            for (int i = 0; i < teamFiles.Length; i++)
            {
                _view.WriteLine($"{i}: {Path.GetFileName(teamFiles[i])}");
            }
        }

        private void PrintOpciones(Player player, int playerNumber)
        {
            _view.WriteLine($"Player {playerNumber} selecciona una opción");
            for (int i = 0; i < player.equipo.Count; i++)
            {
                _view.WriteLine($"{i}: {player.equipo[i].name}");
            }
        }
    }
}