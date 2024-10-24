namespace Fire_Emblem;


public class dataHabilidadStats
{
    public Dictionary<string, int> bonusStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> penaltyStats { get; private set; } = new Dictionary<string, int>();
    public Dictionary<string, int> netosStats { get; private set; } = new Dictionary<string, int>();
    public List<string> bonusNeutralizados { get; private set; } = new List<string>();
    public List<string> penaltyNeutralizados { get; private set; } = new List<string>();

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

    public void resetearContenedoresDeStats()
    {
        bonusStats.Clear();
        penaltyStats.Clear();
        netosStats.Clear();
        bonusNeutralizados.Clear();
        penaltyNeutralizados.Clear();
    }
}