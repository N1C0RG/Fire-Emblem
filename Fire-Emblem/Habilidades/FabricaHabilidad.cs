namespace Fire_Emblem.Habilidades;
using Fire_Emblem_View; 

public class FabricaHabilidad //TODO: dividir esto en mas claes 
{
    private string _nombre_habilidad;
    private Personaje _jugador;
    private Personaje _rival;
    private Habilidad _habilidad;
    private Habilidad _habilidadSegundaCondicion;
    public FabricaHabilidad(string nombreHabilidad, Personaje jugador, Personaje rival)
    {
        _nombre_habilidad = nombreHabilidad;
        _jugador = jugador;
        _rival = rival;
    }
    public AplicadorHabilidad crearAplicador()
    {
        return new AplicadorHabilidad(_habilidad, _habilidadSegundaCondicion);
    }
    public void crearHabilidad()
    {
        if (_nombre_habilidad == "Armored Blow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Atk/Def +5")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(5), new DefUp(5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Bracing Blow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(6), new ResUp(6)}, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Atk/Res +5")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(5), new ResUp(5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Attack +6")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Atk/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Atk/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Atk/Spd")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new SpdUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Def/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Spd/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(10), new DefUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Brazen Spd/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(10), new ResUp(10)}, 
                new List<ICondicion> { new HpMenos80()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Chaos Style")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(3) }, 
                new List<ICondicion> { new CondicionChaos(), new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Darting Blow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Deadly Blade")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(8),  new SpdUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate(), new CondicionSword()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Death Blow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(8) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Defense +5")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(5) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Earth Boost")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(6) }, 
                new List<ICondicion> { new CondicionRivalHPvsJugadorHP() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Fair Fight")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new RivalAtkUp(6) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Fire Boost")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6) }, 
                new List<ICondicion> { new CondicionRivalHPvsJugadorHP() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Mirror Strike")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new ResUp(6)}, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Perceptive")
        {
            int cantidad = 12 + (_jugador.spd / 4);
            _habilidad = new Habilidad (
                new List<IEfecto> {new SpdUp(cantidad) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Resistance +5")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new ResUp(5) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Resolve")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(7), new ResUp(7) }, 
                new List<ICondicion> { new HpMenos75() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Spd/Res +5")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(5), new ResUp(5) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Speed +5")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(5) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Steady Blow")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6), new DefUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Sturdy Blow")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new DefUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Swift Sparrow")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Swift Strike")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6), new ResUp(6) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Tome Precision")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new SpdUp(6) }, 
                new List<ICondicion> { new CondicionMagic() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Warding Blow")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new ResUp(8) },
                new List<ICondicion> { new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Water Boost")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new ResUp(6) },
                new List<ICondicion> { new CondicionRivalHPvsJugadorHP() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Will to Win")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(8) },
                new List<ICondicion> { new HpMenos50() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Wind Boost")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new SpdUp(6) },
                new List<ICondicion> { new CondicionRivalHPvsJugadorHP() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Wrath")
        {
            //TODO; mover esto a efecto ? 
            int cantidad = _jugador.getHpOriginal() - _jugador.HP > 30 ? 30 : _jugador.getHpOriginal() - _jugador.HP;
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(cantidad), new SpdUp(cantidad) },
                new List<ICondicion> { new CondicionNoVidaCompletaJugador() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Beorc's Blessing")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Close Def")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionClose(), new CondicionNoInicia() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Distant Def")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionDistant(), new CondicionNoInicia() },
                _jugador,
                _rival); 
            
        }
        else if (_nombre_habilidad == "Dragonskin")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionNoInicia() },
                _jugador,
                _rival);
            
            _habilidadSegundaCondicion = new Habilidad(
                new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6), new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new CondicionRivalHP75(), new CondicionInicioCombate() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Ignis")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new Up50Atack() },
                new List<ICondicion> { new CondicionFirstAtk() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Sandstorm")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new Sandstorm() },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "HP +15")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new HpUp() }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Fort. Def/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new DefUp(6), new ResUp(6)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> {new AtkUp(-2)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Life and Death")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new SpdUp(6), new DefUp(-5), new ResUp(-5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalDefUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Spd")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalSpdUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionSpd()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalResUp(-3), new AplicarCancelacionAtk(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Spd/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalDefUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Spd/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalResUp(-3), new AplicarCancelacionSpd(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Def/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalDefUp(-3), new RivalResUp(-3), new AplicarCancelacionDef(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Solid Ground")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new DefUp(6) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> {new ResUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Soulblade")
        {   //TODO; mover esto a efecto ? 
            int cantidad = ((_rival.def + _rival.res) / 2);
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalResUp(cantidad - _rival.res), new RivalDefUp(cantidad - _rival.def)}, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Still Water")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new ResUp(6), new DefUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Sword Agility")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Sword Power")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(10), new DefUp(-10) }, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Sword Focus")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(10), new ResUp(-10) }, 
                new List<ICondicion> { new CondicionSword()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Belief in Love")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondicion> { new CondicionNoInicia()}, 
                _jugador, 
                _rival);
            
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                new List<ICondicion> { new CondicionFullVidaRival(), new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        
        else if (_nombre_habilidad == "Agnea's Arrow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AplicarCancelacionPenalty() }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Blinding Flash")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalSpdUp(-4) }, 
                new List<ICondicion> { new CondicionInicioCombate()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Charmer")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-3), new RivalSpdUp(-3) }, 
                new List<ICondicion> { new CondicionRivalPrevio()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Single-Minded")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(8) }, 
                new List<ICondicion> { new CondicionRivalPrevio()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Disarming Sigh")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-8) }, 
                new List<ICondicion> { new CondicionRivalEsHombre()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Stunning Smile")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalSpdUp(-8) }, 
                new List<ICondicion> { new CondicionRivalEsHombre()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Not *Quite*")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-4) }, 
                new List<ICondicion> { new CondicionNoInicia()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Axe Power")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondicion> { new CondicionAxe()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lance Agility")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionLance()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lance Power")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new DefUp(-10)}, 
                new List<ICondicion> { new CondicionLance()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Bow Focus")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(10), new ResUp(-10)}, 
                new List<ICondicion> { new CondicionBow()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Bow Agility")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(12), new AtkUp(-6)}, 
                new List<ICondicion> { new CondicionBow()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Light and Dark")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-5), new RivalSpdUp(-5), 
                    new RivalDefUp(-5), new RivalResUp(-5), new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes(),
                    new AplicarCancelacionPenalty()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Luna") //TODO: numeros que entrego 
        {
            int res = (int)Math.Floor(Convert.ToDecimal(_rival.res) * 0.5m); 
            int def = (int)Math.Floor(Convert.ToDecimal(_rival.def) * 0.5m);
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalDefUp(-def), new RivalResUp(-res), new EfectoLuna() }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Dodge")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentual()}, 
                new List<ICondicion> { new CondicionSpdDanoPorcentual() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Dragon Wall")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualRes()}, 
                new List<ICondicion> { new CondicionResDanoPorcentual() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Gentility")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Arms Shield")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-7)}, 
                new List<ICondicion> { new CondicionTieneVentaja() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Bow Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalArma(Armas.Bow) }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Axe Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalArma(Armas.Axe) }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Magic Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalArma(Armas.Magic) }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Lance Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalArma(Armas.Lance) }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Sympathetic")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionNoInicia(), new HpMenos50() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        
        // habilidades dano extra 
        
        else if (_nombre_habilidad == "Bravery")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoDanoExtra(5)}, 
                new List<ICondicion> { new CondicionNoTienArma(Armas.Magic) }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Lunar Brace")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoLunarBrace()}, 
                new List<ICondicion> { new CondicionNoTienArma(Armas.Magic), new CondicionInicioCombate() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Back at You")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoBackAtYou()}, 
                new List<ICondicion> { new CondicionNoInicia() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        //hibridas 
        else if (_nombre_habilidad == "Blue Skies")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoDanoExtra(5), new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new NoHayCondicion() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        
        else if (_nombre_habilidad == "Aegis Shield")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(6), new ResUp(3), new ReduccionDanoPorcentualPrimerAtaque(0.5m)}, 
                new List<ICondicion> { new NoHayCondicion() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Sparrow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new SpdUp(7), new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Mirror")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new ResUp(10), new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Sturdy")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new DefUp(10), new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() }, //TODO: arreglar la logica de las otras condiciones de arma  
                _jugador, 
                _rival);
        }
    }
}
