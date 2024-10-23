using Fire_Emblem.Encapsulado;
using Fire_Emblem_View;
namespace Fire_Emblem;
public class ManejadorFollowUp
{
    
    public DataFollowUp obtenerDatosFollowUp(Personaje jugador, Personaje rival)
    {
        var dataFollowUp = new DataFollowUp
        {
            velocidadFollowJugador = jugador.spd + (jugador.getNetoStats("Spd")),
            velocidadFollowRival = rival.spd + (rival.getNetoStats("Spd")),
            AtkFollowJugador = 0,
            AtkFollowRival = 0, 
            velocidadAdicionalFollowUp = 5
        };

        return dataFollowUp;
    }
    public void actualizarDanoFollowUp(int ataqueJugador, int ataqueRival, DataFollowUp dataFollowUp, Personaje jugador, Personaje rival)
    {
        dataFollowUp.AtkFollowJugador = ataqueJugador + jugador.getAtaqueFollow();
        dataFollowUp.AtkFollowRival = ataqueRival + rival.getAtaqueFollow();
    }
    public void realizarFollowUp(Personaje jugador, Personaje rival, int ataque_jugador, int ataque_rival, DataFollowUp dataFollowUp, View view) //TODO: sacar el view 
    {
        actualizarDanoFollowUp(ataque_jugador, ataque_rival, dataFollowUp, jugador, rival);
        //TODO: cambiar esto para que no se acceda directamente a la info del rival y jugador metiendolo a follow up data o algo asi 
        int ataqueRival = (int)(dataFollowUp.AtkFollowRival * (1 - jugador.ReduccionDanoPorcentualDictionary["followUp"])); 
        int ataqueJugador = (int)(dataFollowUp.AtkFollowJugador * (1 - rival.ReduccionDanoPorcentualDictionary["followUp"])); 
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            rival.recivirDano(ataqueJugador);
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            jugador.recivirDano(ataque_rival);
        }
    }
}