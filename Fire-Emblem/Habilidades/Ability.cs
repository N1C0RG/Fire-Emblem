namespace Fire_Emblem.Habilidades;

public class Ability 
{
    public List<Effect> efecto;
    public List<Condition> condicion;
    public Personaje jugador;
    public Personaje rival;
    private int aumento;
    private bool cumple_todas_condicion = true;
    private bool cumple_una_condicion = true; 
    public Ability(List<Effect> efecto, List<Condition> condicion, Personaje jugador, Personaje rival, int aumento)
    {
        this.efecto = efecto;
        this.condicion = condicion;
        this.jugador = jugador;
        this.rival = rival;
        this.aumento = aumento; 
    }

    public void Aplicar()
    {
        foreach (var i in  condicion)
        {
            if (i.CondicionHabilidad(jugador, rival) == false)
            {
                cumple_todas_condicion = false; 
            }
        }

        if (cumple_todas_condicion)
        {
            foreach (var i in efecto)
            {
               i.Bonus(jugador, rival, aumento);
            }
        }
    }
    
}