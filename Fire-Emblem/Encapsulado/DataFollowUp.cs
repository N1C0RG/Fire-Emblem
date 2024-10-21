namespace Fire_Emblem.Encapsulado;

public class DataFollowUp
{
    public int velocidadFollowJugador { get; set; }
    public int velocidadFollowRival { get; set; } = 5; 
    public int velocidadAdicionalFollowUp { get; set; }
    private int _atkFollowJugador;
    public int AtkFollowJugador
    {
        get { return _atkFollowJugador; }
        set { _atkFollowJugador = value < 0 ? 0 : value; }
    }
    private int _atkFollowRival;
    public int AtkFollowRival
    {
        get { return _atkFollowRival; }
        set { _atkFollowRival = value < 0 ? 0 : value; }
    }
}