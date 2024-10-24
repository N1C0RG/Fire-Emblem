using Fire_Emblem.Vista;
using Fire_Emblem.Habilidades;
using Fire_Emblem_View;
namespace Fire_Emblem.Controlador
{
    public class ControladorHabilidades
    {
        private Personaje _jugador;
        private Personaje _rival;
        private VistaStatsEfectosHabilidades _vista;
        private NeutralizadorEfectos _neutralizadorEfectos;
        private ManejadorAplicadorHabilidad _aplicadorHabilidades;

        public ControladorHabilidades(Personaje jugador, Personaje rival, View view)
        {
            _jugador = jugador;
            _rival = rival;
            _vista = new VistaStatsEfectosHabilidades(view);
            _neutralizadorEfectos = new NeutralizadorEfectos(jugador, rival);
            _aplicadorHabilidades = new ManejadorAplicadorHabilidad(jugador, rival);
        }

        public void aplicarTodo()
        {
            _aplicadorHabilidades.aplicarHabilidades();
            ordenarBonusEnDiccionarioListas();
            _vista.printTodoBonusPenaltyNeutralizaciones(_jugador, _rival);
            _neutralizadorEfectos.aplicarNeutralizadores();
        }

        private void ordenarBonusEnDiccionarioListas()
        {
            _jugador.dataHabilidadStats.ordenarContenedores();
            _rival.dataHabilidadStats.ordenarContenedores();
        }
    }
}