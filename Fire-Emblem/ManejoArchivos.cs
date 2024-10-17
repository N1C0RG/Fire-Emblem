namespace Fire_Emblem;
using System.Text.Json;
public class ManejoArchivos
{
    private LectorDeArchivo _leactorDeArchivo;
    private ConstructorDeEquipo _constructorDeEquipo;
    private ManejadorDeEquipo _manejadorDeEquipo;

    public ManejoArchivos(string carpetaEquipo, string archivoSeleccionado)
    {
        _leactorDeArchivo = new LectorDeArchivo(carpetaEquipo, archivoSeleccionado);
        _constructorDeEquipo = new ConstructorDeEquipo();
        _manejadorDeEquipo = new ManejadorDeEquipo();
    }

    public void guardarEquipo()
    {
        var lineasArchivo = _leactorDeArchivo.leerArchivo();
        _manejadorDeEquipo.guardarEquipos(lineasArchivo);
    }

    public List<Personaje> crearEquipo(bool isPlayerTeam)
    {
        var dataEquipo = isPlayerTeam ? _manejadorDeEquipo.getPlayerTeam() : _manejadorDeEquipo.getRivalTeam();
        return _constructorDeEquipo.crearEquipo(_leactorDeArchivo.LoadJsonCharacter(), dataEquipo);
    }
}

public class LectorDeArchivo
{
    private string _carpetaEquipo;
    private string _archivoSeleccionado;

    public LectorDeArchivo(string carpetaEquipo, string archivoSeleccionado)
    {
        _carpetaEquipo = carpetaEquipo;
        _archivoSeleccionado = archivoSeleccionado;
    }

    public string[] leerArchivo()
    {
        string fileNumber = _archivoSeleccionado.PadLeft(3, '0');
        var fullPath = Directory.GetFiles(_carpetaEquipo)
            .FirstOrDefault(file => Path.GetFileName(file).Contains(fileNumber));
        return fullPath != null ? File.ReadAllLines(fullPath) : Array.Empty<string>();
    }
    public List<JsonContent> LoadJsonCharacter()
    {
        string directorio_path = AppDomain.CurrentDomain.BaseDirectory; 
        string jsonFilePath = Path.Combine(directorio_path, "characters.json");
        string jsonString = File.ReadAllText(jsonFilePath);
        List<JsonContent> todos_personajes = JsonSerializer.Deserialize<List<JsonContent>>(jsonString);
        return todos_personajes; 
    }
}
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

public class ConstructorDeEquipo
{
    public List<Personaje> crearEquipo(List<JsonContent> todosPersonajes, List<string> dataJugador)
    {
        var equipo = new List<Personaje>();
        foreach (string lineaPersonajeArchivo in dataJugador)
        {
            var (nombre, habilidades) = sliceHabilidadesPerosnaje(lineaPersonajeArchivo);
            agregarPersonajeEquipo(todosPersonajes, nombre, habilidades, equipo);
        }
        return equipo;
    }
    private (string, string[]) sliceHabilidadesPerosnaje(string personaje)
    {
        int startIndex = personaje.IndexOf('(');
        int endIndex = personaje.IndexOf(')');

        if (startIndex == -1 || endIndex == -1)
        {
            string name = personaje.Trim();
            return (name, Array.Empty<string>());
        }
        else
        {
            string nombre = personaje.Substring(0, startIndex).Trim();
            string stringConHabilidades = personaje.Substring(startIndex + 1, endIndex - startIndex - 1);
            string[] habilidades = stringConHabilidades.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (nombre, habilidades);
        }
    }
    private void agregarPersonajeEquipo(List<JsonContent> todosPersonajes, string nombre, string[] habilidades, List<Personaje> equipo)
    {
        var dataPersonajes = todosPersonajes.FirstOrDefault(c => c.Name == nombre);
        if (dataPersonajes != null)
        {
            equipo.Add(new Personaje(dataPersonajes.Name, dataPersonajes.Weapon, dataPersonajes.Gender, dataPersonajes.DeathQuote,
                Convert.ToInt32(dataPersonajes.HP), Convert.ToInt32(dataPersonajes.Atk), Convert.ToInt32(dataPersonajes.Spd),
                Convert.ToInt32(dataPersonajes.Def), Convert.ToInt32(dataPersonajes.Res), habilidades));
        }
    }
}


