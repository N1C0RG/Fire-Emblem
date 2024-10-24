namespace Fire_Emblem;

public class ManejadorDeEquipo
{
    private List<string> _playerTeam = new List<string>();
    private List<string> _rivalTeam = new List<string>();

    public void guardarEquipos(string[] fileLines)
    {
        bool cambiar_otro_equipo = false;
        foreach (string line in fileLines)
        {
            if (line == "Player 2 Team" || cambiar_otro_equipo)
            {
                cambiar_otro_equipo = true;
                _rivalTeam.Add(line);
            }
            else
            {
                _playerTeam.Add(line);
            }
        }
        _playerTeam.RemoveAt(0);
        _rivalTeam.RemoveAt(0);
    }

    public List<string> getPlayerTeam() => _playerTeam;
    public List<string> getRivalTeam() => _rivalTeam;
}