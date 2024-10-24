namespace Fire_Emblem.Habilidades;

public class AplicarCancelacionPenalty : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.addPenaltyNeutralizados("Atk");
        jugador.addPenaltyNeutralizados("Spd");
        jugador.addPenaltyNeutralizados("Def");
        jugador.addPenaltyNeutralizados("Res");
    }
}
public class Up50Atack: IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival)
    {
        if (jugador.dataHabilidadStats.bonusStats.ContainsKey("Atk"))
        {
            jugador.dataHabilidadStats.bonusStats["Atk"] += (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m);
        }
        else
        {
            jugador.dataHabilidadStats.bonusStats.Add("Atk", (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m));
        } 
    }
}

public class Sandstorm : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival) //TODO: no considero el caso de multiples sumas al follow 
    {
        jugador.ataqueFollow = (int)Math.Floor(Convert.ToDecimal(jugador.def) * 1.5m) - jugador.atk; //TODO: ver esto 
    }
}

public class EfectoLuna : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival)
    {
        rival.habilidadPrimerAtaque.Add("Def"); //TODO: ver esto 
        rival.habilidadPrimerAtaque.Add("Res");
    }
}

public class HpUp : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival) //TODO: arreglar esto, mala practica 
    {
        if (jugador.habilidadHpUp)
        {
            jugador.HP += 15;
            jugador.habilidadHpUp = false;
        } 
    }
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

public class ReduccionDanoAbsoluta : IEfecto
{
    private int cantidad;
    public ReduccionDanoAbsoluta(int cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.reduccionDanoAbsoluta += cantidad;
    }
}


public class EfectoLunarBrace : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int def = rival.dataHabilidadStats.postEfecto.ContainsKey("Def") ? rival.def + rival.dataHabilidadStats.postEfecto["Def"] : rival.def; 
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary["todosAtaques"] += (int)((def * 0.3m)); 
    }
}



public class EfectoBackAtYou : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary["todosAtaques"] += (jugador.hpOriginal - jugador.HP)/2; 
    }
}

public class ReduccionDanoPorcentualPrimerAtaque : IEfecto
{
    private decimal cantidad;
    public ReduccionDanoPorcentualPrimerAtaque(decimal cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["primerAtaque"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["primerAtaque"]) * (1 - cantidad);
    }
}

public class ReduccionDanoPorcentualFollowUo : IEfecto
{
    private decimal cantidad;
    public ReduccionDanoPorcentualFollowUo(decimal cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["followUp"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["followUp"]) * (1 - cantidad);
    }
}

//TODO: arreglar toda esta part ede las cancelacion de los bonus del jugador 


public class ReduccionDanoPorcentual : IEfecto
{
    private decimal cantidad;
    public ReduccionDanoPorcentual(decimal cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - cantidad);
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