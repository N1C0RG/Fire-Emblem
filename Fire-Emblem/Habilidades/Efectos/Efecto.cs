using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class AplicarCancelacionPenalty : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.addPenaltyNeutralizados(Stat.Atk.ToString());
        jugador.addPenaltyNeutralizados(Stat.Spd.ToString());
        jugador.addPenaltyNeutralizados(Stat.Def.ToString());
        jugador.addPenaltyNeutralizados(Stat.Res.ToString());
    }
}
public class Up50Atack: IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival)
    {
        if (jugador.dataHabilidadStats.bonusStats.ContainsKey(Stat.Atk.ToString()))
        {
            jugador.dataHabilidadStats.bonusStats[Stat.Atk.ToString()] += (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m);
        }
        else
        {
            jugador.dataHabilidadStats.bonusStats.Add(Stat.Atk.ToString(), (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m));
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

public class HpUp : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival) 
    {
        jugador.HP += 15;
        jugador.habilidadHpUp = false;
    }
}

public class EfectoLunarBrace : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int def = rival.dataHabilidadStats.postEfecto.ContainsKey(Stat.Def.ToString()) ? rival.def + rival.dataHabilidadStats.postEfecto[Stat.Def.ToString()] : rival.def; 
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




