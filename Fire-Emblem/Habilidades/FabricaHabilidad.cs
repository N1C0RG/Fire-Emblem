namespace Fire_Emblem.Habilidades;
using Fire_Emblem_View; 

public class FabricaHabilidad //TODO: dividir esto en mas claes 
{
    private string _nombre_habilidad;
    private Personaje _jugador;
    private Personaje _rival;
    public FabricaHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival)
    {
        _nombre_habilidad = nombreHabilidad;
        _jugador = jugador;
        _rival = rival;
    }
    public void crearHabilidad()
    {
        if (_nombre_habilidad == "Armored Blow")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Atk/Def +5")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(5), new DefUp(5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Bracing Blow")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(6), new ResUp(6)}, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Atk/Res +5")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(5), new ResUp(5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Attack +6")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Atk/Def")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Atk/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Atk/Spd")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new SpdUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Def/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Spd/Def")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(10), new DefUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Brazen Spd/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Chaos Style")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(3) }, 
                new List<ICondicion> { new CondicionChaos(), new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Darting Blow")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Deadly Blade")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(8),  new SpdUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate(), new CondicionSword()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Death Blow")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Defense +5")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(5) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Earth Boost")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(6) }, 
                new List<ICondicion> { new CondicionRivalHPvsPlayerHP() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Fair Fight")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new RivalAtkUp(6) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Fire Boost")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6) }, 
                new List<ICondicion> { new CondicionRivalHPvsPlayerHP() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Mirror Strike")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new ResUp(6)}, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Perceptive")
        {
            int cantidad = 12 + (_jugador.spd / 4);
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new SpdUp(cantidad) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Resistance +5")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new ResUp(5) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Resolve")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(7), new ResUp(7) }, 
                new List<ICondicion> { new HpMenos75() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Spd/Res +5")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(5), new ResUp(5) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Speed +5")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(5) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Steady Blow")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6), new DefUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Sturdy Blow")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new DefUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Swift Sparrow")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Swift Strike")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6), new ResUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Tome Precision")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new SpdUp(6) }, 
                new List<ICondicion> { new CondicionMagic() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Warding Blow")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new ResUp(8) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Water Boost")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new ResUp(6) },
                new List<ICondicion> { new CondicionRivalHPvsPlayerHP() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Will to Win")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(8) },
                new List<ICondicion> { new HpMenos50() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Wind Boost")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6) },
                new List<ICondicion> { new CondicionRivalHPvsPlayerHP() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Wrath")
        {
            //TODO; mover esto a efecto ? 
            int cantidad = _jugador.hp_original - _jugador.HP > 30 ? 30 : _jugador.hp_original - _jugador.HP;
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(cantidad), new SpdUp(cantidad) },
                new List<ICondicion> { new CondicionNotFullVidaPlayer() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Beorc's Blessing")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Close Def")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionClose(), new CondicionNoInicia() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Distant Def")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionDistant(), new CondicionNoInicia() },
                _jugador,
                _rival); 
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Dragonskin")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionNoInicia() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
            Habilidad habilidad_segunda_condicion = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionRivalHP75(), new CondicionInicioCombate() },
                _jugador,
                _rival);
            habilidad_segunda_condicion.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Ignis")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new Up50Atack() },
                new List<ICondicion> { new CondicionFirstAtk() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Sandstorm")
        {
            Habilidad habilidad = new Habilidad(
                new List<IEfecto> { new Sandstorm() },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "HP +15")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new HpUp() }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Fort. Def/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(6), new ResUp(6)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
            Habilidad habilidad_segunda_condicion = new Habilidad (
                new List<IEfecto> {new AtkUp(-2)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad_segunda_condicion.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Life and Death")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new SpdUp(6), new DefUp(-5), new ResUp(-5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Atk/Def")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalDefUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Atk/Spd")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalSpdUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionSpd()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Atk/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalResUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Spd/Def")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalDefUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Spd/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalResUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lull Def/Res")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalDefUp(-3), new RivalResUp(-3), new AplicarCancelacionDef(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Solid Ground")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new DefUp(6) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
            Habilidad habilidad_segunda_condicion = new Habilidad (
                new List<IEfecto> {new ResUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad_segunda_condicion.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Soulblade")
        {   //TODO; mover esto a efecto ? 
            int cantidad = ((_rival.def + _rival.res) / 2);
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalResUp(cantidad - _rival.res), new RivalDefUp(cantidad - _rival.def)}, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Still Water")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new ResUp(6), new DefUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Sword Agility")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Sword Power")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(10), new DefUp(-10) }, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Sword Focus")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(10), new ResUp(-10) }, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Belief in Love")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondicion> { new CondicionNoInicia()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
            Habilidad habilidad_segunda_condicion = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondicion> { new CondicionFullVidaRival(), new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad_segunda_condicion.aplicarHabilidad();
        }
        
        else if (_nombre_habilidad == "Agnea's Arrow")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AplicarCancelacionPenalty() }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Blinding Flash")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalSpdUp(-4) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Charmer")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-3), new RivalSpdUp(-3) }, 
                new List<ICondicion> { new CondicionPreviousRival()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Single-Minded")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(8) }, 
                new List<ICondicion> { new CondicionPreviousRival()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Disarming Sigh")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-8) }, 
                new List<ICondicion> { new CondicionRivalEsHombre()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Stunning Smile")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalSpdUp(-8) }, 
                new List<ICondicion> { new CondicionRivalEsHombre()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Not *Quite*")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-4) }, 
                new List<ICondicion> { new CondicionNoInicia()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Axe Power")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondicion> { new CondicionAxe()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lance Agility")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionLance()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Lance Power")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondicion> { new CondicionLance()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Bow Focus")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new ResUp(-10)}, 
                new List<ICondicion> { new CondicionBow()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Bow Agility")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionBow()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Light and Dark")
        {
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-5), new RivalSpdUp(-5), 
                    new RivalDefUp(-5), new RivalResUp(-5), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes(),
                    new AplicarCancelacionPenalty()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
        else if (_nombre_habilidad == "Luna") //TODO: numeros que entrego 
        {
            int res = (int)Math.Floor(Convert.ToDecimal(_rival.res) * 0.5m); 
            int def = (int)Math.Floor(Convert.ToDecimal(_rival.def) * 0.5m);
            Habilidad habilidad = new Habilidad (
                new List<IEfecto> { new RivalDefUp(-def), new RivalResUp(-res), new EfectoLuna() }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            habilidad.aplicarHabilidad();
        }
    }
}
