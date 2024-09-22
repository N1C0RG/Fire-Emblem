namespace Fire_Emblem.Habilidades;
using Fire_Emblem_View; 

public abstract class AplicadorHabilidad
{
    protected string nombre_habilidad;
    protected Personaje jugador;
    protected Personaje rival;
    protected View _view;
    public AplicadorHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival, View view)
    {
        this.nombre_habilidad = nombreHabilidad;
        this.jugador = jugador;
        this.rival = rival;
        this._view = view;
    }
    public abstract void ConstructorHabilidad();
}


public class AplicadorHabilidadBonus : AplicadorHabilidad
{
    public AplicadorHabilidadBonus(string nombreHabilidad, Personaje jugador, Personaje rival, View view)
        : base(nombreHabilidad, jugador, rival, view) 
    {
    }
    public override void ConstructorHabilidad()
    {
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
        else if (nombre_habilidad == "Chaos Style")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new SpdUp() }, 
                new List<Condition> { new ConditionChaos(), new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Darting Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new SpdUp() }, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Deadly Blade")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(),  new SpdUp() }, 
                new List<Condition> { new ConditionInicioCombate(), new ConditionEspada()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Death Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Defense +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new DefUp() }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Earth Boost")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new DefUp() }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fair Fight")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new FairAtkdUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fire Boost")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp() }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Mirror Strike")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(), new ResUp()}, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Perceptive")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new PerceptiveSpddUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                12);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resistance +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new ResUp() }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resolve")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new DefUp(), new ResUp() }, 
                new List<Condition> { new ConditionHP75() }, 
                jugador, 
                rival, 
                7);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Spd/Res +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new SpdUp(), new ResUp() }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Speed +5")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new SpdUp() }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Steady Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new SpdUp(), new DefUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sturdy Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(), new DefUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Sparrow")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(), new SpdUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Strike")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new SpdUp(), new ResUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Tome Precision")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(), new SpdUp() }, 
                new List<Condition> { new ConditionMagia() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Warding Blow")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new ResUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Water Boost")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new ResUp() }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Will to Win")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp() }, 
                new List<Condition> { new ConditionHP50() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wind Boost")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new SpdUp() }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wrath")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new WrathAtkUp() }, 
                new List<Condition> { new ConditionWrath() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Beorc's Blessing")
        {
            Ability habilidad = new Ability (
                new List<Effect> { new AplicarCancelacion() }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        //mixta 
        else if (nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new DefUp(), new ResUp(), new AplicarCancelacion()}, 
                new List<Condition> { new ConditionClose(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new DefUp(), new ResUp(), new AplicarCancelacion() }, 
                new List<Condition> { new ConditionDistant(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new AtkUp(), new SpdUp(), new DefUp(), new ResUp(), new AplicarCancelacion() }, 
                new List<Condition> {  new ConditionNoInicia() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<Effect> {new AtkUp(), new SpdUp(), new DefUp(), new ResUp(), new AplicarCancelacion()}, 
                new List<Condition> { new ConditionRivalHP75(), new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                6);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Ignis")
        {
            Ability habilidad2 = new Ability (
                new List<Effect> {new Up50Atack()}, 
                new List<Condition> { new ConditionFirstAtk()}, 
                jugador, 
                rival, 
                0);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Sandstorm")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new Sandstorm() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "HP +15")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new HpUp() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
    }
}

public class AplicadorHabilidadMixta : AplicadorHabilidad
{
    public AplicadorHabilidadMixta(string nombreHabilidad, Personaje jugador, Personaje rival, View view)
        : base(nombreHabilidad, jugador, rival, view) 
    {
    }

    public override void ConstructorHabilidad()
    {
        if (nombre_habilidad == "Beorc's Blessing")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new NeutralizaBonus(), new SandstormNeutraliza()}, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new NeutralizaBonus(), new SandstormNeutraliza() }, 
                new List<Condition> { new ConditionClose(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new NeutralizaBonus(), new SandstormNeutraliza() }, 
                new List<Condition> { new ConditionDistant(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability (
                new List<Effect> {new NeutralizaBonus(), new SandstormNeutraliza() }, 
                new List<Condition> { new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<Effect> {new NeutralizaBonus(), new SandstormNeutraliza() }, 
                new List<Condition> { new ConditionInicioCombate(), new ConditionRivalHP75() }, 
                jugador, 
                rival, 
                0);
            habilidad2.Aplicar();
        }
        
    }
}