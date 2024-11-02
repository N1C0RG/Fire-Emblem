namespace Fire_Emblem;

public class DataReduccionExtraStats
{
    public Dictionary<string, decimal> ReduccionDanoPorcentualDictionary = 
        new Dictionary<string, decimal>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };
    public Dictionary<string, int> DanoAdicionalDictionary = 
        new Dictionary<string, int>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };

    public void resetearPorcentual()
    {
        ReduccionDanoPorcentualDictionary = 
            new Dictionary<string, decimal>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} }; 
    }
    public void resetearAdicional()
    {
        DanoAdicionalDictionary =
            new Dictionary<string, int>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };
    }
    public T getDataReduccionExtraStat<T>(string dictionaryName, string key)
    {
        return dictionaryName switch
        {
            "reduccionPorcentual" => ReduccionDanoPorcentualDictionary.ContainsKey(key)
                ? (T)Convert.ChangeType(ReduccionDanoPorcentualDictionary[key], typeof(T))
                : default,
            "danoAdicional" => DanoAdicionalDictionary.ContainsKey(key)
                ? (T)Convert.ChangeType(DanoAdicionalDictionary[key], typeof(T))
                : default,
        };
    }

    public void setDataReduccionExtraStat(string dictionaryName, string key, decimal value)
    {
        switch (dictionaryName)
        {
            case "reduccionPorcentual":
                ReduccionDanoPorcentualDictionary[key] = value;
                break;
            case "danoAdicional":
                DanoAdicionalDictionary[key] = (int)value;
                break;
        }
    }
    public Dictionary<string, T> getDiccionarioReduccionExtraStat<T>(string nombreDiccionario)
    {
        return nombreDiccionario switch
        {
            "reduccionPorcentual" => ReduccionDanoPorcentualDictionary as Dictionary<string, T>,
            "penaldanoAdicionaltyStats" => DanoAdicionalDictionary as Dictionary<string, T>,
        };
    }
}