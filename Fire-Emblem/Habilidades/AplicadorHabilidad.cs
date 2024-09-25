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
                new List<ICondition> { new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Def +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new DefUp(5)}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bracing Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Atk/Res +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new ResUp(5)}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Attack +6")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6) },
                new List<ICondition> { new ConditionNula() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new SpdUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new DefUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Brazen Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Chaos Style")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(3) }, 
                new List<ICondition> { new ConditionChaos(), new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Darting Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Deadly Blade")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8),  new SpdUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate(), new ConditionSword()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Death Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Defense +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(5) }, 
                new List<ICondition> { new ConditionNula() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Earth Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6) }, 
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fair Fight")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new RivalAtkUp(6) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fire Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6) }, 
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Mirror Strike")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Perceptive")
        {
            int cantidad = 12 + (jugador.spd / 4);
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(cantidad) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resistance +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new ResUp(5) }, 
                new List<ICondition> { new ConditionNula() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Resolve")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(7), new ResUp(7) }, 
                new List<ICondition> { new HpMenos75() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Spd/Res +5")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(5), new ResUp(5) },
                new List<ICondition> { new ConditionNula() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Speed +5")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(5) },
                new List<ICondition> { new ConditionNula() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Steady Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6), new DefUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sturdy Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new DefUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Sparrow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Swift Strike")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6), new ResUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Tome Precision")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6) }, 
                new List<ICondition> { new ConditionMagic() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Warding Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new ResUp(8) },
                new List<ICondition> { new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Water Boost")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new ResUp(6) },
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Will to Win")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(8) },
                new List<ICondition> { new HpMenos50() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wind Boost")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6) },
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Wrath")
        {
            int cantidad = jugador.hp_original - jugador.HP > 30 ? 30 : jugador.hp_original - jugador.HP;
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(cantidad), new SpdUp(cantidad) },
                new List<ICondition> { new ConditionNotFullVidaPlayer() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Beorc's Blessing")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionNula() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionClose(), new ConditionNoInicia() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionDistant(), new ConditionNoInicia() },
                jugador,
                rival); 
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionNoInicia() },
                jugador,
                rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionRivalHP75(), new ConditionInicioCombate() },
                jugador,
                rival);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Ignis")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new Up50Atack() },
                new List<ICondition> { new ConditionFirstAtk() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sandstorm")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new Sandstorm() },
                new List<ICondition> { new ConditionNula() },
                jugador,
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "HP +15")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new HpUp() }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Fort. Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new AtkUp(-2)}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Life and Death")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6), new DefUp(-5), new ResUp(-5)}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalDefUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalSpdUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionSpd()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalResUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalDefUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalResUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalDefUp(-3), new RivalResUp(-3), new AplicarCancelacionDef(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Solid Ground")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new DefUp(6) }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new ResUp(-5) }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Soulblade")
        {
            int cantidad = ((rival.def + rival.res) / 2);
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalResUp(cantidad - rival.res), new RivalDefUp(cantidad - rival.def)}, 
                new List<ICondition> { new ConditionSword()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Still Water")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6), new DefUp(-5) }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionSword()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new DefUp(-10) }, 
                new List<ICondition> { new ConditionSword()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Sword Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new ResUp(-10) }, 
                new List<ICondition> { new ConditionSword()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Belief in Love")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondition> { new ConditionNoInicia()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondition> { new ConditionFullVidaRival(), new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad2.Aplicar();
        }
        
        else if (nombre_habilidad == "Agnea's Arrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AplicarCancelacionPenalty() }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Blinding Flash")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-4) }, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Charmer")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-3), new RivalSpdUp(-3) }, 
                new List<ICondition> { new ConditionPreviousRival()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Single-Minded")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(8) }, 
                new List<ICondition> { new ConditionPreviousRival()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Disarming Sigh")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-8) }, 
                new List<ICondition> { new ConditionRivalEsHombre()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Stunning Smile")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-8) }, 
                new List<ICondition> { new ConditionRivalEsHombre()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Not *Quite*")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-4) }, 
                new List<ICondition> { new ConditionNoInicia()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Axe Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondition> { new ConditionAxe()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lance Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionLance()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lance Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondition> { new ConditionLance()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bow Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(-10)}, 
                new List<ICondition> { new ConditionBow()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Bow Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionBow()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Light and Dark")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-5), new RivalSpdUp(-5), 
                    new RivalDefUp(-5), new RivalResUp(-5), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes(),
                    new AplicarCancelacionPenalty()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
    }
}

public class AplicadorHabilidadMixta : AplicadorHabilidad //TODO: tengo codigo repetdo aca 
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
                new List<ICondition> { new ConditionNula() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<ICondition> { new ConditionClose(), new ConditionNoInicia() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<ICondition> { new ConditionDistant(), new ConditionNoInicia() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<ICondition> { new ConditionNoInicia() }, 
                jugador, 
                rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd() }, 
                new List<ICondition> { new ConditionInicioCombate(), new ConditionRivalHP75() }, 
                jugador, 
                rival);
            habilidad2.Aplicar();
        }
        else if (nombre_habilidad == "Agnea's Arrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SandstormNeutraliza(), new NeutralizarPenalty() }, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Light and Dark")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new NeutralizarPenalty(), new CancelAtk(), new CancelDef(), new CancelRes(), new CancelSpd()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelAtk(), new CancelDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelAtk(), new CancelSpd()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelAtk(), new CancelRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelSpd(), new CancelDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelSpd(), new CancelRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
        else if (nombre_habilidad == "Lull Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new CancelDef(), new CancelRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                jugador, 
                rival);
            habilidad.Aplicar();
        }
    }
}