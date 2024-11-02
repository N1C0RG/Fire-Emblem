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
// public class Up50Atack : IEfecto
// {
//     public void efecto(Personaje jugador, Personaje rival)
//     {
//         int bonusAtk = calcularBonusAtk(jugador);
//         if (contieneBonus(jugador))
//         {
//             jugador.sumarDataHabilidadStat(NombreDiccionario.bonusStats.ToString(), Stat.Atk.ToString(), bonusAtk);
//         }
//         else
//         {
//             jugador.dataHabilidadStats.bonusStats.Add(Stat.Atk.ToString(), bonusAtk);
//         }
//     }
//
//     private int calcularBonusAtk(Personaje jugador)
//     {
//         return (int)Math.Floor(Convert.ToDecimal(jugador.atk) * 0.5m);
//     }
//
//     private bool contieneBonus(Personaje jugador)
//     {
//         bool condicion = jugador.dataHabilidadStats.bonusStats.ContainsKey(Stat.Atk.ToString());
//         return condicion; 
//     }
// }

// public class Sandstorm : IEfecto
// {
//     public void efecto(Personaje jugador, Personaje rival)
//     {
//         jugador.ataqueFollow = calcularAtaqueFollow(jugador);
//     }
//
//     private int calcularAtaqueFollow(Personaje jugador)
//     {
//         return (int)Math.Floor(Convert.ToDecimal(jugador.def) * 1.5m) - jugador.atk;
//     }
// }
public class HpUp : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival) 
    {
        jugador.HP += 15;
        jugador.habilidadHpUp = false;
    }
}

public class EfectoBackAtYou : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        jugador.dataReduccionExtraStats.DanoAdicionalDictionary["todosAtaques"] += calcularDanoAdicional(jugador);
    }

    private int calcularDanoAdicional(Personaje jugador)
    {
        int cantidad = (jugador.hpOriginal - jugador.HP) / 2;
        return cantidad; 
    }
}


