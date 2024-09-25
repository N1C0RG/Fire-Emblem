namespace Fire_Emblem;
using System.Text.Json;
public class ManejoArchivos
{
    private FileReader _fileReader;
    private TeamBuilder _teamBuilder;
    private TeamManager _teamManager;

    public ManejoArchivos(string teamFolder, string selectedFile)
    {
        _fileReader = new FileReader(teamFolder, selectedFile);
        _teamBuilder = new TeamBuilder();
        _teamManager = new TeamManager();
    }

    public void GuardarEquipo()
    {
        var fileLines = _fileReader.ReadFile();
        _teamManager.SaveTeams(fileLines);
    }

    public List<Personaje> CrearEquipo(bool isPlayerTeam)
    {
        var teamData = isPlayerTeam ? _teamManager.GetPlayerTeam() : _teamManager.GetRivalTeam();
        return _teamBuilder.CreateTeam(_fileReader.LoadJsonCharacter(), teamData);
    }
}

public class FileReader
{
    private string _teamFolder;
    private string _selectedFile;

    public FileReader(string teamFolder, string selectedFile)
    {
        _teamFolder = teamFolder;
        _selectedFile = selectedFile;
    }

    public string[] ReadFile()
    {
        string fileNumber = _selectedFile.PadLeft(3, '0');
        var fullPath = Directory.GetFiles(_teamFolder)
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
public class TeamManager
{
    private List<string> _playerTeam = new List<string>();
    private List<string> _rivalTeam = new List<string>();

    public void SaveTeams(string[] fileLines)
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

    public List<string> GetPlayerTeam() => _playerTeam;
    public List<string> GetRivalTeam() => _rivalTeam;
}

public class TeamBuilder
{
    public List<Personaje> CreateTeam(List<JsonContent> all_characters, List<string> player_data)
    {
        var team = new List<Personaje>();
        foreach (string character in player_data)
        {
            var (name, abilities) = SliceCharacterData(character);
            AddCharacterToTeam(all_characters, name, abilities, team);
        }
        return team;
    }
    private (string, string[]) SliceCharacterData(string character)
    {
        int start_index = character.IndexOf('(');
        int end_index = character.IndexOf(')');

        if (start_index == -1 || end_index == -1)
        {
            string name = character.Trim();
            return (name, Array.Empty<string>());
        }
        else
        {
            string name = character.Substring(0, start_index).Trim();
            string abilitiesString = character.Substring(start_index + 1, end_index - start_index - 1);
            string[] abilities = abilitiesString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (name, abilities);
        }
    }
    private void AddCharacterToTeam(List<JsonContent> allCharacters, string name, string[] abilities, List<Personaje> team)
    {
        var characterData = allCharacters.FirstOrDefault(c => c.Name == name);
        if (characterData != null)
        {
            team.Add(new Personaje(characterData.Name, characterData.Weapon, characterData.Gender, characterData.DeathQuote,
                Convert.ToInt32(characterData.HP), Convert.ToInt32(characterData.Atk), Convert.ToInt32(characterData.Spd),
                Convert.ToInt32(characterData.Def), Convert.ToInt32(characterData.Res), abilities));
        }
    }
}


