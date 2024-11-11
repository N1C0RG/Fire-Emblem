namespace Fire_Emblem;


public class DataHabilidadStats
{
    public Dictionary<string, int> bonusStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> penaltyStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> netosStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> primerAtaqueBonus { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> primerAtaquePenalty { get; private set; } = new Dictionary<string, int>();
    
    public Dictionary<string, int> followBonus { get; private set; } = new Dictionary<string, int>();
    
    public Dictionary<string, int> followPenalty { get; private set; } = new Dictionary<string, int>();
    public List<string> bonusNeutralizados { get; private set; } = new List<string>();
    public List<string> penaltyNeutralizados { get; private set; } = new List<string>();
    
    public Dictionary<string, int> postEfecto = 
        new Dictionary<string, int>{ {"Atk", 0}, {"Spd", 0}, {"Def", 0}, {"Res", 0}  };

    public void resetearPostEfecto()
    {
        postEfecto["Atk"] = 0;
        postEfecto["Spd"] = 0;
        postEfecto["Def"] = 0;
        postEfecto["Res"] = 0;
    }
    public void calcularPostEfecto()
    {
        postEfecto = 
            new Dictionary<string, int>{ {"Atk", 0}, {"Spd", 0}, {"Def", 0}, {"Res", 0}  };

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
        bonusStats = ordenarStats(bonusStats).ToDictionary(x 
            => x.Key, x => x.Value);
        penaltyStats = ordenarStats(penaltyStats).ToDictionary(x
            => x.Key, x => x.Value);
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
        primerAtaqueBonus.Clear();
        primerAtaquePenalty.Clear();
        followBonus.Clear();
        followPenalty.Clear();
    }
    public int getDataHabilidadStat(string nombreDiccionario, string key)
    {
        return nombreDiccionario switch
        {
            "bonusStats" => bonusStats.ContainsKey(key) ? bonusStats[key] : 0,
            "penaltyStats" => penaltyStats.ContainsKey(key) 
                ? penaltyStats[key] : 0,
            "netosStats" => netosStats.ContainsKey(key) ? netosStats[key] : 0,
            "postEfecto" => postEfecto.ContainsKey(key) ? postEfecto[key] : 0,
            "primerAtaqueBonus" =>  primerAtaqueBonus.ContainsKey(key) ? primerAtaqueBonus[key] : 0,
            "primerAtaquePenalty" =>  primerAtaquePenalty.ContainsKey(key) ? primerAtaquePenalty[key] : 0,
            "followBonus" => followBonus.ContainsKey(key) ? followBonus[key] : 0,
            "followPenalty" => followPenalty.ContainsKey(key) ? followPenalty[key] : 0,
        };
    }
    public Dictionary<string, int> getSpecificDyctionaryDataHabilidadStat(string nombreDiccionario)
    {
        return nombreDiccionario switch
        {
            "bonusStats" => bonusStats,
            "penaltyStats" => penaltyStats,
            "netosStats" => netosStats, 
            "primerAtaqueBonus" => primerAtaqueBonus,
            "primerAtaquePenalty" => primerAtaquePenalty,
            "followBonus" => followBonus,
            "followPenalty" => followPenalty,
        };
    }
    
    public void setDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        switch (nombreDiccionario)
        {
            case "bonusStats":
                bonusStats[key] = value;
                break;
            case "penaltyStats":
                penaltyStats[key] = value;
                break;
            case "netosStats":
                netosStats[key] = value;
                break;
            case "primerAtaqueBonus":
                primerAtaqueBonus[key] = value;
                break;
            case "primerAtaquePenalty":
                primerAtaquePenalty[key] = value;
                break;
            case "followBonus":
                followBonus[key] = value;
                break;
            case "followPenalty":
                followPenalty[key] = value;
                break; 
        }
    }
    public void addDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        switch (nombreDiccionario)
        {
            case "bonusStats":
                bonusStats.Add(key, value);
                break;
            case "penaltyStats":
                penaltyStats.Add(key, value);
                break;
            case "netosStats":
                netosStats.Add(key, value);
                break;
            case "primerAtaqueBonus":
                primerAtaqueBonus.Add(key, value);
                break;
            case "primerAtaquePenalty":
                primerAtaquePenalty.Add(key, value);
                break;
            case "followBonus":
                followBonus.Add(key, value);
                break; 
            case "followPenalty":
                followPenalty.Add(key, value);
                break;
        }
    }
    public void sumarDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        switch (nombreDiccionario)
        {
            case "bonusStats":
                bonusStats[key] += value;
                break;
            case "penaltyStats":
                penaltyStats[key] += value;
                break;
            case "netosStats":
                netosStats[key] += value;
                break;
            case "primerAtaqueBonus":
                primerAtaqueBonus[key] += value;
                break;
            case "primerAtaquePenalty":
                primerAtaquePenalty[key] += value;
                break;
            case "followBonus":
                followBonus[key] += value;
                break;
            case "followPenalty":
                followPenalty[key] += value;
                break;
        }
    }
    public bool contieneStatNeutralizado(string nombreDiccionario, string key)
    {
        return nombreDiccionario switch
        {
            "bonusNeutralizados" => bonusNeutralizados.Contains(key),
            "penaltyNeutralizados" => penaltyNeutralizados.Contains(key),
            _ => false
        };
    }
    public List<string> getSpecificArrayDataHabilidadStat(string nombreDiccionario)
    {
        return nombreDiccionario switch
        {
            "bonusNeutralizados" => bonusNeutralizados,
            "penaltyNeutralizados" => penaltyNeutralizados,
        };
    }
}