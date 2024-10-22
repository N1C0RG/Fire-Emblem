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
    public  void efecto(Personaje jugador, Personaje rival)
    {
        jugador.HP += 15; 
    }
}

public class ReduccionDanoPorcentual : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        decimal reduccionDano = ((jugador.spd - rival.spd) * 4) / 100m > 0.4m ? 0.4m : ((jugador.spd - rival.spd) * 4) / 100m;
        jugador.reduccionDanoPorcentual += reduccionDano;
    }
}

public class ReduccionDanoPorcentualRes : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        decimal reduccionDano = ((jugador.res - rival.res) * 4) / 100m > 0.4m ? 0.4m : ((jugador.res - rival.res) * 4) / 100m;
        jugador.reduccionDanoPorcentual += reduccionDano;
    }
}


