namespace Fire_Emblem.Habilidades;
using Fire_Emblem.Encapsulado;
public class EfectoDragonsWrath : IEfecto
{
    private int cantidad;
    private string tipoAtaque;
    private int ataqueJugador;
    private int resistenciaRival; 
    public EfectoDragonsWrath(int cantidad, string tipoAtaque)
    {
        this.cantidad = cantidad;
        this.tipoAtaque = tipoAtaque;
    }

    public void efecto(Personaje jugador, Personaje rival)
    {
        calcularAtaqueResitencia(jugador, rival);
        calcularDanoExtra(); 
        if (ataqueJugador > resistenciaRival)
        {
            jugador.dataReduccionExtraStats.DanoAdicionalDictionary[tipoAtaque] += cantidad;
        } 
    }
    public Prioridad getPrioridad()
    {
        return Prioridad.reduccionPorcentual; 
    }
    private void calcularDanoExtra()
    {
        cantidad = (ataqueJugador - resistenciaRival)/4;
    }
    private void calcularAtaqueResitencia(Personaje jugador, Personaje rival)
    {
        ataqueJugador = jugador.atk + jugador.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            Stat.Atk.ToString()); 
        resistenciaRival = rival.res + rival.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
            Stat.Res.ToString());
    }
}