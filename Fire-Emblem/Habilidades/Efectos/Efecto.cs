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




