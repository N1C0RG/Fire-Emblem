namespace Fire_Emblem.Habilidades;

public class ReduccionDanoPorcentualRes : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int res = calcularRes(jugador);
        int resRival = calcularRes(rival);
        decimal reduccionDano = calcularReduccionDano(res, resRival);
        aplicarReduccionDano(jugador, reduccionDano);
    }
    private int calcularRes(Personaje personaje)
    {
        int res = personaje.res;
        res += personaje.dataHabilidadStats.postEfecto.ContainsKey("Res") ? personaje.dataHabilidadStats.postEfecto["Res"] : 0;
        return res;
    }

    private decimal calcularReduccionDano(int res, int resRival)
    {
        decimal reduccionDano = ((res - resRival) * 4) / 100m;
        return reduccionDano > 0.4m ? 0.4m : reduccionDano;
    }

    private void aplicarReduccionDano(Personaje jugador, decimal reduccionDano)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 
            1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) 
            * (1 - reduccionDano);
    }
}