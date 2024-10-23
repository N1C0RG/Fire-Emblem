using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;

public class CalculadorFollowUp : CalculadorDeAtaque
{
    private int calcularFollowUp(Personaje atacante, Personaje defensor, decimal ventaja) 
    {
        var ataque = calcularAtaque(atacante, defensor, ventaja);
        return ataque; 
    }
    
    public DataFollowUp obtenerDatosFollowUp(Personaje jugador, Personaje rival, decimal ventaja) 
    {
        var dataFollowUp = new DataFollowUp
        {
            velocidadFollowJugador = jugador.spd + (jugador.getNetoStats("Spd")),
            velocidadFollowRival = rival.spd + (rival.getNetoStats("Spd")),
            AtkFollowJugador = calcularFollowUp(jugador, rival, ventaja),
            AtkFollowRival = calcularFollowUp(rival, jugador, ventaja),
            velocidadAdicionalFollowUp = 5
        };

        return dataFollowUp;
    }
}