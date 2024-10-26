using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Vista;
using Fire_Emblem_View;

public class VistaBatalla
{
    private readonly View _view;

    public VistaBatalla(View view)
    {
        _view = view;
    }

    public void mostrarVentaja(Personaje jugador, Personaje rival, decimal ventajaJugador)
    {
        if (ventajaJugador == 1.2m)
        {
            _view.WriteLine($"{jugador.getNombre()} ({jugador.getArma()}) tiene ventaja con respecto a " +
                            $"{rival.getNombre()} ({rival.getArma()})");
        }
        else if (ventajaJugador == 0.8m)
        {
            _view.WriteLine($"{rival.getNombre()} ({rival.getArma()}) tiene ventaja con respecto a" +
                            $" {jugador.getNombre()} ({jugador.getArma()})");
        }
        else
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
    }

    public void mostrarVidaEndRound(Personaje jugador, Personaje rival)
    {
        _view.WriteLine($"{jugador.getNombre()} ({jugador.getHp()}) : {rival.getNombre()} ({rival.getHp()})");
    }

    public void MostrarFollowUp(DataFollowUp dataFollowUp, Personaje jugador, Personaje rival)
    {

        if (dataFollowUp.velocidadFollowJugador >= 
            dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{jugador.getNombre()} ataca a {rival.getNombre()} " +
                            $"con {dataFollowUp.AtkFollowJugador} de daño");
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp
                 <= dataFollowUp.velocidadFollowRival)
        {
            _view.WriteLine($"{rival.getNombre()} ataca a {jugador.getNombre()} " +
                            $"con {dataFollowUp.AtkFollowRival} de daño");
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    public void mostrarAtaque(Personaje atacante, Personaje defensor, int dano)
    {
        _view.WriteLine($"{atacante.getNombre()} ataca a {defensor.getNombre()} con {dano} de daño");
    }
    
    public void vistaPrueba(string texto)
    {
        _view.WriteLine(texto);
    }
}