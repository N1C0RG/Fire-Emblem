namespace Fire_Emblem.Encapsulado.Stats;

public class Stats : IStats
{
    private readonly Dictionary<string, int> _stats = new Dictionary<string, int>();

    public void add(string stat, int value)
    {
        if (_stats.ContainsKey(stat))
            _stats[stat] += value;
        else
            _stats[stat] = value;
    }

    public void remove(string stat)
    {
        _stats.Remove(stat);
    }

    public int get(string stat)
    {
        return _stats.ContainsKey(stat) ? _stats[stat] : 0;
    }

    public Dictionary<string, int> getAll()
    {
        return _stats;
    }
    
    public void clear()
    {
        _stats.Clear();
    }

    public void set(string stat, int value)
    {
        _stats[stat] += value;
    }
}