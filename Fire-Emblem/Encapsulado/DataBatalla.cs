namespace Fire_Emblem.Encapsulado;

public class DataBatalla
{
    public Personaje jugador;
    public Personaje rival;
    public decimal ventajaJugador;
    public int ataqueJugador;
    public int ataqueRival;
    public DataFollowUp dataFollowUp;

    public DataBatalla(Personaje jugador, Personaje rival, decimal ventajaJugador, int ataqueJugador, int ataqueRival, DataFollowUp dataFollowUp)
    {
        this.jugador = jugador;
        this.rival = rival;
        this.ventajaJugador = ventajaJugador;
        this.ataqueJugador = ataqueJugador;
        this.ataqueRival = ataqueRival;
        this.dataFollowUp = dataFollowUp;
    }
}