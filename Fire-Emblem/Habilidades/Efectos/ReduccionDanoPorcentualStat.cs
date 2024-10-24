namespace Fire_Emblem.Habilidades;

public class ReduccionDanoPorcentualStat
{
    
}
public class ReduccionDanoPorcentualSpd : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        //TODO: cambiar la forma en que proceso habilidades, hay habilidades en esta entrega que tengo que aplicar sobre los stats de unaunidad normal, hay que hacer cambios (parche temporal)
        int spd = jugador.spd; 
        spd += jugador.dataHabilidadStats.postEfecto.ContainsKey("Spd") ? jugador.dataHabilidadStats.postEfecto["Spd"] : 0;
        
        int speedRival = rival.spd + rival.dataHabilidadStats.postEfecto["Spd"];
        decimal reduccionDano = ((spd - speedRival) * 4) / 100m > 0.4m ? 0.4m : ((spd - speedRival) * 4) / 100m;
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);

    }
}

public class ReduccionDanoPorcentualRes : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int res = jugador.res;
        res += jugador.dataHabilidadStats.postEfecto.ContainsKey("Res") ? jugador.dataHabilidadStats.postEfecto["Res"] : 0;
        int r_res = rival.res + rival.dataHabilidadStats.postEfecto["Res"];
        
        decimal reduccionDano = ((res - r_res) * 4) / 100m > 0.4m ? 0.4m : ((res - r_res) * 4) / 100m;
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);
    }
}

public class ReduccionDanoSpd : IEfecto
{
    private int spdRival;
    private int spdJugador; 
    public ReduccionDanoSpd(int spdRival, int spdJugador)
    {
        this.spdRival = spdRival;
        this.spdJugador = spdJugador; 
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        //TODO: cambiar la forma en que proceso habilidades, hay habilidades en esta entrega que tengo que aplicar sobre los stats de unaunidad normal, hay que hacer cambios (parche temporal)
        int spd = jugador.spd; 
        spd += jugador.dataHabilidadStats.postEfecto.ContainsKey("Spd") ? jugador.dataHabilidadStats.postEfecto["Spd"] : 0;
        
        int speedRival = rival.spd + rival.dataHabilidadStats.postEfecto["Spd"];
        
        decimal reduccionDano = ((spd - speedRival) * 4) / 100m > 0.4m ? 0.4m : ((spd - speedRival) * 4) / 100m;
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);

    }
}