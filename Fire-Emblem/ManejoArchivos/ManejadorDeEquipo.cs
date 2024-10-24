namespace Fire_Emblem;

public class ManejadorDeEquipo
{
    private List<string> _equipoJugador = new List<string>();
    private List<string> _equipoRival = new List<string>();

    public void guardarEquipos(string[] fileLines)
    {
        bool cambiarOtroEquipo = false;
        foreach (string line in fileLines)
        {
            if (line == "Player 2 Team" || cambiarOtroEquipo)
            {
                cambiarOtroEquipo = true;
                _equipoRival.Add(line);
            }
            else
            {
                _equipoJugador.Add(line);
            }
        }
        _equipoJugador.RemoveAt(0);
        _equipoRival.RemoveAt(0);
    }

    public List<string> getEquipoJugador() => _equipoJugador;
    public List<string> getEquipoRival() => _equipoRival;
}