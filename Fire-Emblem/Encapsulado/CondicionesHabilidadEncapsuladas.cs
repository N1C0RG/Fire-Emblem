namespace Fire_Emblem.Encapsulado;

public class CondicionesHabilidadEncapsuladas
{
    public bool tieneRivalHP75(Personaje rival)
    {
        bool condicion = rival.HP >= (int)Math.Floor(Convert.ToDecimal(rival.hp_original) * 0.75m); 
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
        bool condicion = jugador.HP < jugador.hp_original; 
        return condicion; 
    }

    public bool tieneFullVidaRival(Personaje rival)
    {
        bool condicion = rival.HP == rival.hp_original;
        return condicion; 
    }
    public bool inicioCombate(Personaje jugador)
    {
        bool condicion = jugador.inicia_round; 
        return condicion; 
    }

    public bool CondicionClose(Personaje rival)
    {
        bool condicion = rival.weapon == Armas.Magic.ToString() || rival.weapon == Armas.Bow.ToString();
        return condicion; 
    }
}