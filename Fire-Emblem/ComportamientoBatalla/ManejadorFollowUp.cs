using Fire_Emblem.Encapsulado;
using Fire_Emblem_View;
namespace Fire_Emblem;
using Fire_Emblem.ExcepcionesJuego;
public class ManejadorFollowUp
{
    public void realizarFollowUp(Personaje jugador, Personaje rival, DataFollowUp dataFollowUp)  
    {
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival 
            + dataFollowUp.velocidadAdicionalFollowUp)
        {
            if (dataFollowUp.AtkFollowJugador < 0)
            {
                throw new ExcepcionDanoValido();
            }
            rival.recivirDano(dataFollowUp.AtkFollowJugador);
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp 
                 <= dataFollowUp.velocidadFollowRival)
        {
            if (dataFollowUp.AtkFollowRival < 0)
            {
                throw new ExcepcionDanoValido();
            }
            jugador.recivirDano(dataFollowUp.AtkFollowRival);
        }
    }
}