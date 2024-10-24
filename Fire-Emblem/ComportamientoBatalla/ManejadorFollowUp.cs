using Fire_Emblem.Encapsulado;
using Fire_Emblem_View;
namespace Fire_Emblem;
public class ManejadorFollowUp
{
    public void realizarFollowUp(Personaje jugador, Personaje rival, int ataque_jugador, int ataque_rival, DataFollowUp dataFollowUp, View view) //TODO: sacar el view 
    {
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            rival.recivirDano(dataFollowUp.AtkFollowJugador);
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            jugador.recivirDano(dataFollowUp.AtkFollowRival);
        }
    }
}