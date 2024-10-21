namespace Fire_Emblem;

public class RemoverJugador
{
    public void removerJugador(Personaje jugador, Player euqipoJugador)
    {
        if (jugador.getHp() == 0)
        {
            euqipoJugador.eliminarPersonaje(jugador);
        }
    }
}
