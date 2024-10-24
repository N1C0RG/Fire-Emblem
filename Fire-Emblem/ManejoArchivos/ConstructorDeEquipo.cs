namespace Fire_Emblem;

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
