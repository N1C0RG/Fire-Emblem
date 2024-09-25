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
                new List<IEffect> { new DefUp(8) }, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Def +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new DefUp(5)}, 
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
                new List<IEffect> { new DefUp(6), new ResUp(6)}, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Res +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new ResUp(5)}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Attack +6")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(6)}, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new SpdUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(10), new ResUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new DefUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new ResUp(10)}, 
                new List<Condition> { new ConditionVida80()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Chaos Style")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(3) }, 
                new List<Condition> { new ConditionChaos(), new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Darting Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(8) }, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Deadly Blade")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8),  new SpdUp(8) }, 
                new List<Condition> { new ConditionInicioCombate(), new ConditionEspada()}, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Death Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Defense +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(5) }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Earth Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6) }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fair Fight")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new FairAtkdUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fire Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6) }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Mirror Strike")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6)}, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Perceptive")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new PerceptiveSpddUp() }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                12);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resistance +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new ResUp(5) }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resolve")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(7), new ResUp(7) }, 
                new List<Condition> { new ConditionHP75() }, 
                jugador, 
                rival, 
                7);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Spd/Res +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(5), new ResUp(5) }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Speed +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(5) }, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                5);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Steady Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(6), new DefUp(6) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sturdy Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new DefUp(6) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Sparrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Strike")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(6), new ResUp(6) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Tome Precision")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6) }, 
                new List<Condition> { new ConditionMagia() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Warding Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new ResUp(8) }, 
                new List<Condition> { new ConditionInicioCombate() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Water Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new ResUp(6) }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Will to Win")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8) }, 
                new List<Condition> { new ConditionHP50() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wind Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(6) }, 
                new List<Condition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wrath")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new WrathAtkUp() }, 
                new List<Condition> { new ConditionWrath() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Beorc's Blessing")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AplicarCancelacion() }, 
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
                new List<IEffect> {new DefUp(8), new ResUp(8), new AplicarCancelacion()}, 
                new List<Condition> { new ConditionClose(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(8), new ResUp(8), new AplicarCancelacion() }, 
                new List<Condition> { new ConditionDistant(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6), new AplicarCancelacion() }, 
                new List<Condition> {  new ConditionNoInicia() }, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6), new AplicarCancelacion()}, 
                new List<Condition> { new ConditionRivalHP75(), new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                6);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Ignis")
        {
            Ability habilidad2 = new Ability (
                new List<IEffect> {new Up50Atack()}, 
                new List<Condition> { new ConditionFirstAtk()}, 
                jugador, 
                rival, 
                0);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Sandstorm")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new Sandstorm() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "HP +15")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new HpUp() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fort. Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6), new ResUp(6)}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new AtkUp(-2)}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -2);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Life and Death")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6), new DefUp(-5), new ResUp(-5)}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalDefUp(-3), new CancelAtk(), new CancelDef()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalSpdUp(-3), new CancelAtk(), new CancelSpd()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalResUp(-3), new CancelAtk(), new CancelRes()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalDefUp(-3), new CancelSpd(), new CancelDef()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalResUp(-3), new CancelSpd(), new CancelRes()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalDefUp(-3), new RivalResUp(-3), new CancelDef(), new CancelRes()}, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Solid Ground")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new DefUp(6) }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new ResUp(-5) }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                -5);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Soulblade")
        {
            int cantidad = ((rival.def + rival.res) / 2);
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalResUp(cantidad - rival.res), new RivalDefUp(cantidad - rival.def)}, 
                new List<Condition> { new ConditionEspada()}, 
                jugador, 
                rival, 
                cantidad - rival.res);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Still Water")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6), new DefUp(-5) }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                6);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(12), new AtkUp(-6)}, 
                new List<Condition> { new ConditionEspada()}, 
                jugador, 
                rival, 
                12);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new DefUp(-10) }, 
                new List<Condition> { new ConditionEspada()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new ResUp(-10) }, 
                new List<Condition> { new ConditionEspada()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Belief in Love")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<Condition> { new ConditionNoInicia()}, 
                jugador, 
                rival, 
                -5);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<Condition> { new ConditionFullVidaRival(), new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                -5);
            habilidad2.Aplicar();
        }
        
        else if (nombre_habilidad == "Agnea's Arrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AplicarCancelacionPenalty() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Blinding Flash")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-4) }, 
                new List<Condition> { new ConditionInicioCombate()}, 
                jugador, 
                rival, 
                -4);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Charmer")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-3), new RivalSpdUp(-3) }, 
                new List<Condition> { new ConditionPreviousRival()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Single-Minded")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(8) }, 
                new List<Condition> { new ConditionPreviousRival()}, 
                jugador, 
                rival, 
                -3);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Disarming Sigh")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-8) }, 
                new List<Condition> { new ConditionRivalEsHombre()}, 
                jugador, 
                rival, 
                -8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Stunning Smile")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-8) }, 
                new List<Condition> { new ConditionRivalEsHombre()}, 
                jugador, 
                rival, 
                -8);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Not *Quite*")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-4) }, 
                new List<Condition> { new ConditionNoInicia()}, 
                jugador, 
                rival, 
                -4);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Axe Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<Condition> { new ConditionTieneAxe()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lance Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<Condition> { new ConditionTieneLanza()}, 
                jugador, 
                rival, 
                12);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lance Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<Condition> { new ConditionTieneLanza()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bow Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(-10)}, 
                new List<Condition> { new ConditionTieneBow()}, 
                jugador, 
                rival, 
                10);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bow Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<Condition> { new ConditionTieneBow()}, 
                jugador, 
                rival, 
                12);
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
                new List<IEffect> {new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd()}, 
                new List<Condition> { new ConditionNula() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<Condition> { new ConditionClose(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<Condition> { new ConditionDistant(), new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<Condition> { new ConditionNoInicia() }, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<Condition> { new ConditionInicioCombate(), new ConditionRivalHP75() }, 
                jugador, 
                rival, 
                0);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Agnea's Arrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelarPenaltyRes(), new CancelPenaltyAtk(), new CancelPenaltyDef(), new CancelPenaltySpd() }, 
                new List<Condition> { new ConditionNula()}, 
                jugador, 
                rival, 
                0);
            habilidad.Aplicar();
        }
    }
}