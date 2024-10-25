namespace Fire_Emblem.Habilidades;
public class ReduccionDanoPorcentualSpd : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int spd = CalcularSpd(jugador);
        int speedRival = CalcularSpd(rival);
        decimal reduccionDano = calcularReduccionDano(spd, speedRival);
        aplicarReduccionDano(jugador, reduccionDano);
    }

    private int CalcularSpd(Personaje jugador)
    {
        int spd = jugador.spd;
        spd += jugador.dataHabilidadStats.postEfecto.ContainsKey("Spd") 
            ? jugador.dataHabilidadStats.postEfecto["Spd"] : 0;
        return spd;
    }

    private decimal calcularReduccionDano(int spd, int speedRival)
    {
        decimal reduccionDano = ((spd - speedRival) * 4) / 100m;
        return reduccionDano > 0.4m ? 0.4m : reduccionDano;
    }

    private void aplicarReduccionDano(Personaje jugador, decimal reduccionDano)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 
            1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) 
            * (1 - reduccionDano);
    }
}