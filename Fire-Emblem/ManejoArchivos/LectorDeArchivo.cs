namespace Fire_Emblem;
using System.Text.Json;
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
