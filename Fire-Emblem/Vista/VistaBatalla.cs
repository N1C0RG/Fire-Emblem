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
            _view.WriteLine($"{jugador.getNombre()} tiene ventaja sobre {rival.getNombre()}");
        }
        else if (ventajaJugador == 0.8m)
        {
            _view.WriteLine($"{jugador.getNombre()} tiene desventaja contra {rival.getNombre()}");
        }
        else
        {
            _view.WriteLine($"{jugador.getNombre()} y {rival.getNombre()} están equilibrados");
        }
    }

    public void mostrarVidaEndRound(Personaje jugador, Personaje rival)
    {
        _view.WriteLine($"{jugador.getNombre()} ({jugador.getHp()}) : {rival.getNombre()} ({rival.getHp()})");
    }

    public void MostrarFollowUp(DataFollowUp dataFollowUp, Personaje jugador, Personaje rival)
    {
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{jugador.getNombre()} realiza un follow-up contra {rival.getNombre()}");
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            _view.WriteLine($"{rival.getNombre()} realiza un follow-up contra {jugador.getNombre()}");
        }
        else
        {
            _view.WriteLine("No hay follow-up");
        }
    }

    public void mostrarAtaque(Personaje atacante, Personaje defensor, int dano)
    {
        _view.WriteLine($"{atacante.getNombre()} ataca a {defensor.getNombre()} con {dano} de daño");
    }
}