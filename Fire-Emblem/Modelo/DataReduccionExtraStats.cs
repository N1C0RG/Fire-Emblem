namespace Fire_Emblem;

public class DataReduccionExtraStats
{
    public Dictionary<string, decimal> ReduccionDanoPorcentualDictionary = new Dictionary<string, decimal>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} }; //TODO: aplicar esto a la logica del juego 
    public Dictionary<string, int> DanoAdicionalDictionary = new Dictionary<string, int>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };

    public void resetearPorcentual()
    {
        ReduccionDanoPorcentualDictionary = new Dictionary<string, decimal>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} }; 
    }
    public void resetearAdicional()
    {
        DanoAdicionalDictionary = new Dictionary<string, int>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };
    }
}