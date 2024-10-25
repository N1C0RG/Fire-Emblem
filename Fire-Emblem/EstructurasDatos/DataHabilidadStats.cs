namespace Fire_Emblem;


public class DataHabilidadStats
{
    public Dictionary<string, int> bonusStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> penaltyStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> netosStats { get; private set; } = new Dictionary<string, int>();
    public List<string> bonusNeutralizados { get; private set; } = new List<string>();
    public List<string> penaltyNeutralizados { get; private set; } = new List<string>();
    
    public Dictionary<string, int> postEfecto =  new Dictionary<string, int>{ {"Atk", 0}, {"Spd", 0}, {"Def", 0}, {"Res", 0}  };

    public void resetearPostEfecto()
    {
        postEfecto["Atk"] = 0;
        postEfecto["Spd"] = 0;
        postEfecto["Def"] = 0;
        postEfecto["Res"] = 0;
    }
    public void calcularPostEfecto()
    {
        //jugador.postEfecto.Clear(); // Asegúrate de que el diccionario esté vacío antes de sumar

        foreach (var bonus in bonusStats)
        {
            if (!postEfecto.ContainsKey(bonus.Key))
            {
                postEfecto[bonus.Key] = 0;
            }
            if (!bonusNeutralizados.Contains(bonus.Key))
            {
                postEfecto[bonus.Key] += bonus.Value;
            }
            
        }

        foreach (var penalty in penaltyStats)
        {
            if (!postEfecto.ContainsKey(penalty.Key))
            {
                postEfecto[penalty.Key] = 0;
            }
            if (!penaltyNeutralizados.Contains(penalty.Key))
            {
                postEfecto[penalty.Key] += penalty.Value;
            }
        }
    }

    public void calcularNetosStats()
    {
        netosStats.Clear();
        foreach (var stat in bonusStats.Keys)
        {
            int bonus = bonusStats.ContainsKey(stat) ? bonusStats[stat] : 0;
            int penalty = penaltyStats.ContainsKey(stat) ? penaltyStats[stat] : 0;
            netosStats[stat] = bonus + penalty;
        }

        foreach (var stat in penaltyStats.Keys)
        {
            if (!netosStats.ContainsKey(stat))
            {
                int penalty = penaltyStats.ContainsKey(stat) ? penaltyStats[stat] : 0;
                netosStats[stat] = penalty;
            }
        }
    }
    public void ordenarContenedores()
    {
        bonusStats = ordenarStats(bonusStats).ToDictionary(x => x.Key, x => x.Value);
        penaltyStats = ordenarStats(penaltyStats).ToDictionary(x => x.Key, x => x.Value);
        bonusNeutralizados = ordenarNeutralizaciones(bonusNeutralizados).ToList();
        penaltyNeutralizados = ordenarNeutralizaciones(penaltyNeutralizados).ToList();
    }
    private IEnumerable<KeyValuePair<string, int>> ordenarStats(Dictionary<string, int> stats)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(stats.ContainsKey).Select(key => new KeyValuePair<string, int>(key, stats[key]));
    }
    private IEnumerable<string> ordenarNeutralizaciones(IEnumerable<string> neutralizations)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(neutralizations.Contains);
    }
    public void resetearContenedoresDeStats()
    {
        bonusStats.Clear();
        penaltyStats.Clear();
        netosStats.Clear();
        bonusNeutralizados.Clear();
        penaltyNeutralizados.Clear();
    }
}