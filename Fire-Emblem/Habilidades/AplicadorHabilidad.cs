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
        // if (nombre_habilidad == "Armored Blow")
        // {
        //     Ability<Def8Up, ConditionInicioCombate> habilidad =
        //         new Ability<Def8Up, ConditionInicioCombate>(new Def8Up(), new ConditionInicioCombate(), jugador, rival);
        //     habilidad.Aplicar();
        // }
        // else if (nombre_habilidad == "Atk/Def +5")
        // {
        //     Ability<Atk5Up, ConditionNula> habilidad =
        //         new Ability<Atk5Up, ConditionNula>(new Atk5Up(), new ConditionNula(), jugador, rival);
        //     Ability<Def5Up, ConditionNula> habilidad2 =
        //         new Ability<Def5Up, ConditionNula>(new Def5Up(), new ConditionNula(), jugador, rival);
        //     habilidad.Aplicar();
        //     habilidad2.Aplicar();
        // }
        //Todo: de esta forma paso de 84 -> 83 no se porque 
        if (nombre_habilidad == "Armored Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new DefUp() }, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Def +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp(), new DefUp()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bracing Blow")
        {
            //TODO: la parte de los multiples efectos usar una lista de efectos para la clase ability 
            Ability habilidad = new Ability (
                new List<Effect> { new DefUp(), new ResUp()}, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Res +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp(), new ResUp()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Attack +6")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp()}, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp(), new DefUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp(), new ResUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AtkUp(), new SpdUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Def/Res")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new DefUp(), new ResUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new SpdUp(), new DefUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new SpdUp(), new ResUp()}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        
    }
}