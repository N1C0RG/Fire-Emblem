namespace Fire_Emblem.Habilidades;
public interface IEfecto
{
    public void efecto(Personaje jugador, Personaje rival); 
}
public abstract class EfectoStatJugador : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatJugador(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        var stats = Cantidad > 0 ? jugador.bonusStats : jugador.penaltyStats;

        if (stats.ContainsKey(StatKey))
        {
            stats[StatKey] += Cantidad;
        }
        else
        {
            stats.Add(StatKey, Cantidad);
        }
    }
}
public abstract class EfectoStatRival : IEfecto
{
    protected string StatKey;
    protected int Cantidad; 
    protected EfectoStatRival(string statKey, int cantidad)
    {
        StatKey = statKey;
        this.Cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        var stats = Cantidad > 0 ? rival.bonusStats : rival.penaltyStats;

        if (stats.ContainsKey(StatKey))
        {
            stats[StatKey] += Cantidad;
        }
        else
        {
            stats.Add(StatKey, Cantidad);
        }
    }
}
public abstract class AplicarCancelacionBonus : IEfecto
{
    protected string StatKey;
    protected AplicarCancelacionBonus(string statKey)
    {
        StatKey = statKey;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        rival.bonusNeutralizados.Add(StatKey);
    }
}
public class AtkUp : EfectoStatJugador
{
    public AtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class SpdUp : EfectoStatJugador
{
    public SpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class DefUp : EfectoStatJugador
{
    public DefUp(int cantidad) : base("Def", cantidad) { }
}
public class ResUp : EfectoStatJugador
{
    public ResUp(int cantidad) : base("Res", cantidad) { }
}
public class RivalAtkUp : EfectoStatRival
{
    public RivalAtkUp(int cantidad) : base("Atk", cantidad) { }
}
public class RivalSpdUp : EfectoStatRival
{
    public RivalSpdUp(int cantidad) : base("Spd", cantidad) { }
}
public class RivalDefUp : EfectoStatRival
{
    public RivalDefUp(int cantidad) : base("Def", cantidad) { }
}
public class RivalResUp : EfectoStatRival
{
    public RivalResUp(int cantidad) : base("Res", cantidad) { }
}
public class AplicarCancelacionAtk : AplicarCancelacionBonus
{
    public AplicarCancelacionAtk() : base("Atk") { }
}
public class AplicarCancelacionDef : AplicarCancelacionBonus
{
    public AplicarCancelacionDef() : base("Def") { }
}
public class AplicarCancelacionRes : AplicarCancelacionBonus
{
    public AplicarCancelacionRes() : base("Res") { }
}
public class AplicarCancelacionSpd : AplicarCancelacionBonus
{
    public AplicarCancelacionSpd() : base("Spd") { }
}

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
        if (jugador.bonusStats.ContainsKey("Atk"))
        {
            jugador.bonusStats["Atk"] += (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m);
        }
        else
        {
            jugador.bonusStats.Add("Atk", (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m));
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
        spd += jugador.postEfecto.ContainsKey("Spd") ? jugador.postEfecto["Spd"] : 0;
        
        
        decimal reduccionDano = ((spd - rival.spd) * 4) / 100m > 0.4m ? 0.4m : ((spd - rival.spd) * 4) / 100m;
        jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);

    }
}

public class ReduccionDanoPorcentualRes : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int res = jugador.res;
        res += jugador.postEfecto.ContainsKey("Res") ? jugador.postEfecto["Res"] : 0;
        
        decimal reduccionDano = ((res - rival.res) * 4) / 100m > 0.4m ? 0.4m : ((res - rival.res) * 4) / 100m;
        jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);
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
        int def = rival.postEfecto.ContainsKey("Def") ? rival.def + rival.postEfecto["Def"] : rival.def; 
        jugador.DanoAdicionalDictionary["todosAtaques"] += (int)((def * 0.3m)); 
    }
}

public class EfectoDanoExtra : IEfecto
{
    private int cantidad; 
    public EfectoDanoExtra(int cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.DanoAdicionalDictionary["todosAtaques"] += cantidad; 
    }
}

public class EfectoBackAtYou : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.DanoAdicionalDictionary["todosAtaques"] += (jugador.hpOriginal - jugador.HP)/2; 
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
        jugador.ReduccionDanoPorcentualDictionary["primerAtaque"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["primerAtaque"]) * (1 - cantidad);
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
        jugador.ReduccionDanoPorcentualDictionary["followUp"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["followUp"]) * (1 - cantidad);
    }
}

//TODO: arreglar toda esta part ede las cancelacion de los bonus del jugador 
public abstract class AplicarCancelacionBonusJugador : IEfecto
{
    protected string StatKey;
    protected AplicarCancelacionBonusJugador(string statKey)
    {
        StatKey = statKey;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.bonusNeutralizados.Add(StatKey);
    }
}
public class AplicarCancelacionDefJugador : AplicarCancelacionBonusJugador
{
    public AplicarCancelacionDefJugador() : base("Def") { }
}
public class AplicarCancelacionResJugador : AplicarCancelacionBonusJugador
{
    public AplicarCancelacionResJugador() : base("Res") { }
}

public class ReduccionDanoPorcentual : IEfecto
{
    private decimal cantidad;
    public ReduccionDanoPorcentual(decimal cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - cantidad);
    }
}

public class EfectoDanoExtraPrimerAtaque : IEfecto
{
    private int cantidad; 
    public EfectoDanoExtraPrimerAtaque(int cantidad)
    {
        this.cantidad = cantidad;
    }
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.DanoAdicionalDictionary["primerAtaque"] += cantidad; 
    }
}

public class DivineRecreation : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.HP = jugador.hpOriginal; 
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
        spd += jugador.postEfecto.ContainsKey("Spd") ? jugador.postEfecto["Spd"] : 0;
        
        int speedRival = rival.spd + spdRival;
        
        decimal reduccionDano = ((spd - speedRival) * 4) / 100m > 0.4m ? 0.4m : ((spd - speedRival) * 4) / 100m;
        jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] = 1 - (1 - jugador.ReduccionDanoPorcentualDictionary["todosAtaques"]) * (1 - reduccionDano);

    }
}