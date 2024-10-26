namespace Fire_Emblem;

public class Ventaja
{
    public decimal ventajaJugador { get; private set; } = 1;
    public decimal ventajaRival { get; private set; } = 1;
    
    public decimal multiplicadorVentaja { get; private set; } = 1.2m;
    
    public decimal multiplicadorDesventaja { get; private set; } = 0.8m;
    
    public decimal multiplicadorDefault { get; private set; } = 1m;

    public void calcularVentaja(Personaje jugador, Personaje rival)
    {
        if (jugador.getArma() == Armas.Sword.ToString() && rival.getArma() == Armas.Axe.ToString() || 
            jugador.getArma() == Armas.Lance.ToString() && rival.getArma() == Armas.Sword.ToString() ||
            jugador.getArma() == Armas.Axe.ToString() && rival.getArma() == Armas.Lance.ToString())
        {
            ventajaJugador = multiplicadorVentaja;
            ventajaRival = multiplicadorDesventaja;
        }
        else if (rival.getArma() == Armas.Sword.ToString() && jugador.getArma() == Armas.Axe.ToString() ||
                 rival.getArma() == Armas.Lance.ToString() && jugador.getArma() == Armas.Sword.ToString() ||
                 rival.getArma() == Armas.Axe.ToString() && jugador.getArma() == Armas.Lance.ToString())
        {
            ventajaJugador = multiplicadorDesventaja;
            ventajaRival = multiplicadorVentaja;
        }
        else
        {
            ventajaJugador = multiplicadorDefault;
            ventajaRival = multiplicadorDefault;
        }
    }
}