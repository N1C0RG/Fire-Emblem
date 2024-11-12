using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;
using Fire_Emblem.EnumVariables;
using Fire_Emblem.Habilidades;

namespace Fire_Emblem;

public class CalculadorFollowUp : CalculadorDeAtaque
{
    private int calcularFollowUp(Personaje atacante, Personaje defensor, decimal ventaja) 
    {
        
        var calculadorAtaque = calcularAtaque(atacante, defensor, ventaja);
        
        var ataque = _ataque + atacante.getDataHabilidadStat(NombreDiccionario.followBonus.ToString(), 
            Stat.Atk.ToString()) + atacante.getDataHabilidadStat(NombreDiccionario.followPenalty.ToString(), 
            Stat.Atk.ToString());
        
        int ataqueFinal = (int)Math.Floor(ataque * _ventaja) - _defensa < 0 ? 0 : 
            (int)Math.Floor(ataque * _ventaja) - _defensa;
        ataqueFinal += _atacante.getDataReduccionExtraStat<int>(
                            NombreDiccionario.danoAdicional.ToString(),
                            Llave.todosAtaques.ToString()) 
                        + _atacante.getDataReduccionExtraStat<int>(
                            NombreDiccionario.danoAdicional.ToString(), 
                            Llave.followUp.ToString()) ;
        
        var reduccionTotal = _reduccionTotal * 
                             (1 - defensor.getDataReduccionExtraStat<decimal>(
                                 NombreDiccionario.reduccionPorcentual.ToString(), 
                                 Llave.followUp.ToString()));

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