namespace Fire_Emblem.Encapsulado;

public class DataBatalla
{
    public Personaje jugador;
    public Personaje rival;
    public decimal ventajaJugador;
    public DataFollowUp dataFollowUp;

    public DataBatalla(Personaje jugador, Personaje rival, decimal ventajaJugador, DataFollowUp dataFollowUp)
    {
        this.jugador = jugador;
        this.rival = rival;
        this.ventajaJugador = ventajaJugador;
        this.dataFollowUp = dataFollowUp;
    }
}