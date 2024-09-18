namespace Fire_Emblem.Habilidades;
using Fire_Emblem_View; 
using Fire_Emblem.Habilidades;
public class AplicadorHabilidad
{
    private string nombre_habilidad;
    private Personaje jugador;
    private Personaje rival; 
    private View _view;
    public AplicadorHabilidad(string nombreHabilidad,  Personaje jugador, Personaje rival, View view)
    {
        this.nombre_habilidad = nombreHabilidad;
        this.jugador = jugador;
        this.rival = rival;
        this._view = view; 
    }
 
    public void ConstructorHabilidad()
    {
        if (nombre_habilidad == "Armored Blow")
        {
            Ability<Def8Up, ConditionInicioCombate> habilidad =
                new Ability<Def8Up, ConditionInicioCombate>(new Def8Up(), new ConditionInicioCombate(), jugador, rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Def +5")
        {
            Ability<Atk5Up, ConditionNula> habilidad =
                new Ability<Atk5Up, ConditionNula>(new Atk5Up(), new ConditionNula(), jugador, rival);
            Ability<Def5Up, ConditionNula> habilidad2 =
                new Ability<Def5Up, ConditionNula>(new Def5Up(), new ConditionNula(), jugador, rival);
            habilidad.Aplicar();
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Bracing Blow")
        {
            
        }
    }
}