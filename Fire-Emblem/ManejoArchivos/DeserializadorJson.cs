namespace Fire_Emblem;
using System.Text.Json;

public class DeserializadorJson
{
    public List<ContenidoJson> LoadJsonCharacter()
    {
        string directorioPath = AppDomain.CurrentDomain.BaseDirectory;
        string jsonArchivoPath = Path.Combine(directorioPath, "characters.json");
        string jsonTodosPersonajeString = File.ReadAllText(jsonArchivoPath);
        List<ContenidoJson> todosPersonajes = JsonSerializer.Deserialize<List<ContenidoJson>>(jsonTodosPersonajeString);
        return todosPersonajes;
    }
}