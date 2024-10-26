namespace Fire_Emblem.Encapsulado;

public class CondicionesHabilidadEncapsuladas
{
    public bool tieneHP75(Personaje jugador)
    {
        bool condicion = jugador.HP >= (int)Math.Floor(Convert.ToDecimal(jugador.getHpOriginal()) * 0.75m); 
        return condicion;
    }
    public bool tieneRivalHPvsJugadorHP(Personaje jugador, Personaje rival)
    {
        bool condicion = jugador.HP >= rival.HP + 3; 
        return condicion;
    }
    public bool tieneChaos(Personaje jugador, Personaje rival)
    {
        bool condicion = (jugador.weapon != Armas.Magic.ToString() && rival.weapon == Armas.Magic.ToString()) ||
                         (rival.weapon != Armas.Magic.ToString() && jugador.weapon == Armas.Magic.ToString()); 
        return condicion; 
    }
    public bool tieneNoVidaCompletaJugador(Personaje jugador)
    {
        bool condicion = jugador.HP < jugador.getHpOriginal(); 
        return condicion; 
    }

    public bool tieneFullVida(Personaje jugador)
    {
        bool condicion = jugador.HP == jugador.getHpOriginal();
        return condicion; 
    }
    public bool inicioCombate(Personaje jugador)
    {
        bool condicion = jugador.getIniciaTurno(); 
        return condicion; 
    }

    public bool ataqueClose(Personaje jugador)
    {
        bool condicion = jugador.getArma() != Armas.Magic.ToString() && jugador.getArma() != Armas.Bow.ToString();
        return condicion; 
    }
    public bool ataqueDistant(Personaje jugador)
    {
        bool condicion = jugador.getArma() == Armas.Magic.ToString() || jugador.getArma() == Armas.Bow.ToString();
        return condicion; 
    }
    public bool esRivalPrevio(Personaje jugador, Personaje rival)
    {
        bool condicion = jugador.getOponentePrevio() == rival.getNombre(); 
        return condicion; 
    }

    public bool esHombre(Personaje jugador)
    {
        bool condicion = jugador.getGenero() == "Male";
        return condicion; 
    }

    public bool cantidadVidaMenorIgualOriginal(Personaje jugador, decimal Hp)
    {
        bool condicion = jugador.HP <= (int)Math.Floor(Convert.ToDecimal(jugador.getHpOriginal()) * Hp);
        return condicion; 
    }
    public bool tieneArmaWeapon(Personaje jugador, string weapon)
    {
        bool condicion = jugador.getArma() == weapon;
        return condicion; 
    }
    public bool jugadorIniciaRound(Personaje jugador)
    {
        bool condicion = jugador.getIniciaTurno();
        return condicion; 
    }
    public bool tieneVentajaArma(Personaje jugador, Personaje rival)
    {
        var ventaja = new Ventaja(); 
        ventaja.calcularVentaja(jugador, rival);
        bool condicion = ventaja.ventajaJugador == 1.2m; 
        return condicion; 
    }
    
    public bool tieneHpUp(Personaje jugador)
    {
        bool condicion = jugador.habilidadHpUp; 
        return condicion; 
    }
    
}