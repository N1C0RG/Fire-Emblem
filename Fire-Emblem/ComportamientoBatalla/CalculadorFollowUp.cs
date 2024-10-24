using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;

public class CalculadorFollowUp : CalculadorDeAtaque
{
    private int calcularFollowUp(Personaje atacante, Personaje defensor, decimal ventaja, View view) 
    {
        
        var calculadorAtaque = calcularAtaque(atacante, defensor, ventaja);
        
        var ataque = _ataque + atacante.getAtaqueFollow();
        
        //view.WriteLine($"  {atacante.name}  el ataque con ventaja    {(ataque * _ventaja) - _defensa}");
        int ataqueFinal = (int)Math.Floor(ataque * _ventaja) - _defensa + _atacante.DanoAdicionalDictionary["todosAtaques"] + _atacante.DanoAdicionalDictionary["followUp"];
        
        var reduccionTotal = _reduccionTotal * (1 - defensor.ReduccionDanoPorcentualDictionary["followUp"]);
        //view.WriteLine($"{reduccionTotal}");
        //.WriteLine($"  {atacante.name}  el ataque con ventaja    {(int)(ataqueFinal * reduccionTotal) + _defensor.reduccionDanoAbsoluta}");
        return (int)(ataqueFinal * reduccionTotal) + _defensor.reduccionDanoAbsoluta;
    }
    public DataFollowUp obtenerDatosFollowUp(Personaje jugador, Personaje rival, decimal ventajaJugador, decimal ventajaRival, View view) 
    {
        var dataFollowUp = new DataFollowUp
        {
            velocidadFollowJugador = jugador.spd + (jugador.getNetoStats("Spd")),
            velocidadFollowRival = rival.spd + (rival.getNetoStats("Spd")),
            AtkFollowJugador = calcularFollowUp(jugador, rival, ventajaJugador, view),
            AtkFollowRival = calcularFollowUp(rival, jugador, ventajaRival, view),
            velocidadAdicionalFollowUp = 5
        };

        return dataFollowUp;
    }
}