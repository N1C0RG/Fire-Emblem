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
            _view.WriteLine($"{jugador.getNombre()} ({jugador.getArma()}) tiene ventaja con respecto a {rival.getNombre()} ({rival.getArma()})");
        }
        else if (ventajaJugador == 0.8m)
        {
            _view.WriteLine($"{rival.getNombre()} ({rival.getArma()}) tiene ventaja con respecto a {jugador.getNombre()} ({jugador.getArma()})");
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
        //TODO: arreglar esto con lo de la parte de manejo follow 
        int ataqueRival = (int)((dataFollowUp.AtkFollowRival - jugador.reduccionDanoAbsoluta) * (1 - jugador.ReduccionDanoPorcentualDictionary["followUp"])) + jugador.reduccionDanoAbsoluta; 
        int ataqueJugador = (int)((dataFollowUp.AtkFollowJugador - rival.reduccionDanoAbsoluta) * (1 - rival.ReduccionDanoPorcentualDictionary["followUp"])) + rival.reduccionDanoAbsoluta; 
        
        if (dataFollowUp.velocidadFollowJugador >= dataFollowUp.velocidadFollowRival + dataFollowUp.velocidadAdicionalFollowUp)
        {
            _view.WriteLine($"{jugador.getNombre()} ataca a {rival.getNombre()} con {ataqueJugador} de daño");
        }
        else if (dataFollowUp.velocidadFollowJugador + dataFollowUp.velocidadAdicionalFollowUp <= dataFollowUp.velocidadFollowRival)
        {
            _view.WriteLine($"{rival.getNombre()} ataca a {jugador.getNombre()} con {ataqueRival} de daño");
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
}