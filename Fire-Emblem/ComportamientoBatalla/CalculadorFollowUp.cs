using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;

public class CalculadorFollowUp : CalculadorDeAtaque
{
    private int calcularFollowUp(Personaje atacante, Personaje defensor, decimal ventaja) 
    {
        var calculadorAtaque = calcularAtaque(atacante, defensor, ventaja);
        
        var ataque = _ataque + atacante.getAtaqueFollow();
        
        int ataqueFinal = (int)Math.Floor(ataque * _ventaja) - _defensa + _atacante.DanoAdicionalDictionary["todosAtaques"] + _atacante.DanoAdicionalDictionary["followUp"];
        
        var reduccionTotal = _reduccionTotal * (1 - atacante.ReduccionDanoPorcentualDictionary["followUp"]);
        
        return (int)(ataqueFinal * reduccionTotal) + _defensor.reduccionDanoAbsoluta;
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