namespace Fire_Emblem.Habilidades;
using Encapsulado; 
public class ReduccionDanoPorcentualRes : IEfecto
{
    public void efecto(Personaje jugador, Personaje rival)
    {
        int res = calcularRes(jugador);
        int resRival = calcularRes(rival);
        decimal reduccionDano = calcularReduccionDano(res, resRival);
        aplicarReduccionDano(jugador, reduccionDano);
    }
    private int calcularRes(Personaje jugador)
    {
        int res = jugador.res;
        res += jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), Stat.Res.ToString());
        return res;
    }

    private decimal calcularReduccionDano(int res, int resRival)
    {
        decimal reduccionDano = ((res - resRival) * 4) / 100m;
        reduccionDano = reduccionDano < 0 ? 0 : reduccionDano;
        return reduccionDano > 0.4m ? 0.4m : reduccionDano;
    }

    private void aplicarReduccionDano(Personaje jugador, decimal reduccionDano)
    {
        decimal reduccion = 1 - (1 - jugador.getDataReduccionExtraStat<decimal>(
                NombreDiccionario.reduccionPorcentual.ToString(), "todosAtaques"))
            * (1 - reduccionDano); 
        jugador.setDataReduccionExtraStat(NombreDiccionario.reduccionPorcentual.ToString(), 
            "todosAtaques", reduccion);
    }

    public Prioridad getPrioridad()
    {
        return Prioridad.reduccionPorcentual; 
    }
}