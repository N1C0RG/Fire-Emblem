namespace Fire_Emblem.Habilidades;
using Fire_Emblem_View; 

public class AplicadorHabilidad //TODO: dividir esto en mas claes 
{
    private string _nombre_habilidad;
    private Personaje _jugador;
    private Personaje _rival;
    public AplicadorHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival)
    {
        _nombre_habilidad = nombreHabilidad;
        _jugador = jugador;
        _rival = rival;
    }
    public void ConstructorHabilidad()
    {
        if (_nombre_habilidad == "Armored Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Atk/Def +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new DefUp(5)}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Bracing Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Atk/Res +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(5), new ResUp(5)}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Attack +6")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6) },
                new List<ICondition> { new ConditionNula() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new SpdUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new DefUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new DefUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Brazen Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(10), new ResUp(10)}, 
                new List<ICondition> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Chaos Style")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(3) }, 
                new List<ICondition> { new ConditionChaos(), new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Darting Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Deadly Blade")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8),  new SpdUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate(), new ConditionSword()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Death Blow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(8) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Defense +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(5) }, 
                new List<ICondition> { new ConditionNula() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Earth Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6) }, 
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Fair Fight")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new RivalAtkUp(6) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Fire Boost")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6) }, 
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Mirror Strike")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Perceptive")
        {
            int cantidad = 12 + (_jugador.spd / 4);
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(cantidad) }, 
                new List<ICondition> { new ConditionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Resistance +5")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new ResUp(5) }, 
                new List<ICondition> { new ConditionNula() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Resolve")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(7), new ResUp(7) }, 
                new List<ICondition> { new HpMenos75() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Spd/Res +5")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(5), new ResUp(5) },
                new List<ICondition> { new ConditionNula() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Speed +5")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(5) },
                new List<ICondition> { new ConditionNula() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Steady Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6), new DefUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Sturdy Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new DefUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Swift Sparrow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Swift Strike")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6), new ResUp(6) },
                new List<ICondition> { new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Tome Precision")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6) }, 
                new List<ICondition> { new ConditionMagic() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Warding Blow")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new ResUp(8) },
                new List<ICondition> { new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Water Boost")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new ResUp(6) },
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Will to Win")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(8) },
                new List<ICondition> { new HpMenos50() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Wind Boost")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new SpdUp(6) },
                new List<ICondition> { new ConditionRivalHPvsPlayerHP() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Wrath")
        {
            //TODO; mover esto a efecto ? 
            int cantidad = _jugador.hp_original - _jugador.HP > 30 ? 30 : _jugador.hp_original - _jugador.HP;
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(cantidad), new SpdUp(cantidad) },
                new List<ICondition> { new ConditionNotFullVidaPlayer() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Beorc's Blessing")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionNula() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Close Def")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionClose(), new ConditionNoInicia() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Distant Def")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionDistant(), new ConditionNoInicia() },
                _jugador,
                _rival); 
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Dragonskin")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionNoInicia() },
                _jugador,
                _rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability(
                new List<IEffect> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondition> { new ConditionRivalHP75(), new ConditionInicioCombate() },
                _jugador,
                _rival);
            habilidad2.Aplicar();
        }
        else if (_nombre_habilidad == "Ignis")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new Up50Atack() },
                new List<ICondition> { new ConditionFirstAtk() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Sandstorm")
        {
            Ability habilidad = new Ability(
                new List<IEffect> { new Sandstorm() },
                new List<ICondition> { new ConditionNula() },
                _jugador,
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "HP +15")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new HpUp() }, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Fort. Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new DefUp(6), new ResUp(6)}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new AtkUp(-2)}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad2.Aplicar();
        }
        else if (_nombre_habilidad == "Life and Death")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new SpdUp(6), new DefUp(-5), new ResUp(-5)}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Atk/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalDefUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Atk/Spd")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalSpdUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionSpd()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Atk/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-3), new RivalResUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Spd/Def")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalDefUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionDef()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Spd/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalSpdUp(-3), new RivalResUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lull Def/Res")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalDefUp(-3), new RivalResUp(-3), new AplicarCancelacionDef(), new AplicarCancelacionRes()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Solid Ground")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new DefUp(6) }, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new ResUp(-5) }, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad2.Aplicar();
        }
        else if (_nombre_habilidad == "Soulblade")
        {   //TODO; mover esto a efecto ? 
            int cantidad = ((_rival.def + _rival.res) / 2);
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalResUp(cantidad - _rival.res), new RivalDefUp(cantidad - _rival.def)}, 
                new List<ICondition> { new ConditionSword()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Still Water")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(6), new ResUp(6), new DefUp(-5) }, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Sword Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionSword()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Sword Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new DefUp(-10) }, 
                new List<ICondition> { new ConditionSword()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Sword Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new AtkUp(10), new ResUp(-10) }, 
                new List<ICondition> { new ConditionSword()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Belief in Love")
        {
            Ability habilidad = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondition> { new ConditionNoInicia()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
            Ability habilidad2 = new Ability (
                new List<IEffect> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondition> { new ConditionFullVidaRival(), new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad2.Aplicar();
        }
        
        else if (_nombre_habilidad == "Agnea's Arrow")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AplicarCancelacionPenalty() }, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Blinding Flash")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-4) }, 
                new List<ICondition> { new ConditionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Charmer")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-3), new RivalSpdUp(-3) }, 
                new List<ICondition> { new ConditionPreviousRival()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Single-Minded")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(8) }, 
                new List<ICondition> { new ConditionPreviousRival()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Disarming Sigh")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-8) }, 
                new List<ICondition> { new ConditionRivalEsHombre()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Stunning Smile")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalSpdUp(-8) }, 
                new List<ICondition> { new ConditionRivalEsHombre()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Not *Quite*")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-4) }, 
                new List<ICondition> { new ConditionNoInicia()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Axe Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondition> { new ConditionAxe()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lance Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionLance()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Lance Power")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondition> { new ConditionLance()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Bow Focus")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new AtkUp(10), new ResUp(-10)}, 
                new List<ICondition> { new ConditionBow()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Bow Agility")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondition> { new ConditionBow()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Light and Dark")
        {
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalAtkUp(-5), new RivalSpdUp(-5), 
                    new RivalDefUp(-5), new RivalResUp(-5), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes(),
                    new AplicarCancelacionPenalty()}, 
                new List<ICondition> { new ConditionNula()}, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
        else if (_nombre_habilidad == "Luna") //TODO: numeros que entrego 
        {
            int res = (int)Math.Floor(Convert.ToDecimal(_rival.res) * 0.5m); 
            int def = (int)Math.Floor(Convert.ToDecimal(_rival.def) * 0.5m);
            Ability habilidad = new Ability (
                new List<IEffect> { new RivalDefUp(-def), new RivalResUp(-res), new EfectoLuna() }, 
                new List<ICondition> { new ConditionNula() }, 
                _jugador, 
                _rival);
            habilidad.Aplicar();
        }
    }
}
