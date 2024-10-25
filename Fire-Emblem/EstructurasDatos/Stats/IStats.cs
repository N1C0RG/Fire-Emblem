namespace Fire_Emblem.Encapsulado.Stats;

public interface IStats
{
    void add(string stat, int value);
    void remove(string stat);
    int get(string stat);
    Dictionary<string, int> getAll();
    void clear();
    void set(string stat, int value);
}