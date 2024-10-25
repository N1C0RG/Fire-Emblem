using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;

public class CalculadorFollowUp : CalculadorDeAtaque
{
    private int calcularFollowUp(Personaje atacante, Personaje defensor, decimal ventaja) 
    {
        
        var calculadorAtaque = calcularAtaque(atacante, defensor, ventaja);
        
        var ataque = _ataque + atacante.getAtaqueFollow();
        
        int ataqueFinal = (int)Math.Floor(ataque * _ventaja) - _defensa + 
                          _atacante.dataReduccionExtraStats.DanoAdicionalDictionary["todosAtaques"] 
                          + _atacante.dataReduccionExtraStats.DanoAdicionalDictionary["followUp"];
        
        var reduccionTotal = _reduccionTotal * 
                             (1 - defensor.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary["followUp"]);

        return (int)(ataqueFinal * reduccionTotal) + _defensor.reduccionDanoAbsoluta;
    }
    public DataFollowUp obtenerDatosFollowUp(Personaje jugador, Personaje rival, decimal ventajaJugador,
        decimal ventajaRival) 
    {
        var dataFollowUp = new DataFollowUp
        {
            velocidadFollowJugador = jugador.spd + (jugador.getDataHabilidadStat(
                NombreDiccionario.netosStats.ToString(), Stat.Spd.ToString())),
            
            velocidadFollowRival = rival.spd + (rival.getDataHabilidadStat(
                NombreDiccionario.netosStats.ToString(), Stat.Spd.ToString())),
            
            AtkFollowJugador = calcularFollowUp(jugador, rival, ventajaJugador),
            AtkFollowRival = calcularFollowUp(rival, jugador, ventajaRival),
            velocidadAdicionalFollowUp = 5
        };

        return dataFollowUp;
    }
}