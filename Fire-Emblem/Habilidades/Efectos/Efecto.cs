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
    public Prioridad getPrioridad()
    {
        return Prioridad.neutralizacionPenalty;
    }
}
public class HpUp : IEfecto
{
    public  void efecto(Personaje jugador, Personaje rival) 
    {
        jugador.HP += 15;
        jugador.habilidadHpUp = false;
    }
    public Prioridad getPrioridad()
    {
        return Prioridad.bonus;
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
    public Prioridad getPrioridad()
    {
        return Prioridad.danoExtra;
    }
}


