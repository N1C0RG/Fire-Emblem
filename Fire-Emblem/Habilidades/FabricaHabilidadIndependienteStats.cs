using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class FabricaHabilidadIndependienteStats : FabricaHabilidad
{
    public FabricaHabilidadIndependienteStats(string nombreHabilidad, Personaje jugador, Personaje rival) 
        : base(nombreHabilidad, jugador, rival) {}

    public override void crearHabilidad()
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
                new List<IEfecto> { new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), 
                    new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Close Def")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(8), new ResUp(8), new AplicarCancelacionAtk(),
                    new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes() },
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
            var habilidades = new List<Habilidad>
            {
                new Habilidad(
                    new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6), 
                        new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), 
                        new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                    new List<ICondicion> { new CondicionNoInicia() },
                    _jugador,
                    _rival),
                new Habilidad(
                    new List<IEfecto> { new AtkUp(6), new SpdUp(6), new DefUp(6),
                        new ResUp(6),  new AplicarCancelacionAtk(), new AplicarCancelacionSpd(), 
                        new AplicarCancelacionDef(), new AplicarCancelacionRes() },
                    new List<ICondicion> { new CondicionRivalHP75(), new CondicionInicioCombate() },
                    _jugador,
                    _rival)
            };
            _habilidad = new HabilidadCompuesta(habilidades, _jugador, _rival);
            
            
        }
        else if (_nombre_habilidad == "Ignis")
        {
            _habilidad = new Ignis(
                new List<IEfecto> { },
                new List<ICondicion> { },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "Sandstorm")
        {
            _habilidad = new Sandstorm(
                new List<IEfecto> { },
                new List<ICondicion> { },
                _jugador,
                _rival);
            
        }
        else if (_nombre_habilidad == "HP +15")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new HpUp() }, 
                new List<ICondicion> { new CondicionHpUp()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Fort. Def/Res")
        {
            _habilidad = new Habilidad(
                new List<IEfecto> { new DefUp(6), new ResUp(6), new AtkUp(-2) },
                new List<ICondicion> { new NoHayCondicion() },
                _jugador, _rival); 

        }
        else if (_nombre_habilidad == "Life and Death")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new SpdUp(6), new DefUp(-5), 
                    new ResUp(-5)}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalDefUp(-3), 
                    new AplicarCancelacionAtk(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Spd")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalSpdUp(-3),
                    new AplicarCancelacionAtk(), new AplicarCancelacionSpd()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Atk/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalAtkUp(-3), new RivalResUp(-3), 
                    new AplicarCancelacionAtk(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Spd/Def")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalDefUp(-3),
                    new AplicarCancelacionSpd(), new AplicarCancelacionDef()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Spd/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalSpdUp(-3), new RivalResUp(-3),
                    new AplicarCancelacionSpd(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Lull Def/Res")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalDefUp(-3), new RivalResUp(-3),
                    new AplicarCancelacionDef(), new AplicarCancelacionRes()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Solid Ground")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> {new AtkUp(6), new DefUp(6), new ResUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Soulblade")
        {   //TODO; mover esto a efecto ? 
            int cantidad = ((_rival.def + _rival.res) / 2);
            _habilidad = new Habilidad (
                new List<IEfecto> {new RivalResUp(cantidad - _rival.res), 
                    new RivalDefUp(cantidad - _rival.def)}, 
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
            var habilidades = new List<Habilidad>
            {
                new Habilidad (
                    new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                    new List<ICondicion> { new CondicionNoInicia()}, 
                    _jugador, 
                    _rival), 
                new Habilidad (
                    new List<IEfecto> {new RivalAtkUp(-5), new RivalDefUp(-5) }, 
                    new List<ICondicion> { new CondicionFullVidaRival(), new CondicionInicioCombate()}, 
                    _jugador, 
                    _rival) 
            };
            _habilidad = new HabilidadCompuesta(habilidades, _jugador, _rival);
            
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
                    new RivalDefUp(-5), new RivalResUp(-5), new AplicarCancelacionAtk(),
                    new AplicarCancelacionSpd(), new AplicarCancelacionDef(), new AplicarCancelacionRes(),
                    new AplicarCancelacionPenalty()}, 
                new List<ICondicion> { new NoHayCondicion()}, 
                _jugador, 
                _rival);
            
        }
        else if (_nombre_habilidad == "Luna") 
        {
            _habilidad = new Luna (new List<IEfecto> { }, new List<ICondicion> { }, _jugador, _rival);
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
                new List<ICondicion> { new CondicionRivalBow() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Axe Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalAxe() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Magic Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalMagic() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Lance Guard")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionRivalLance() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Sympathetic")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new CondicionNoInicia(), new HpMenos50() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Bravery")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoDanoExtra(5, ( ) => -1)}, 
                new List<ICondicion> { new NoHayCondicion() },  
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Laguz Friend")
        {
            //TODO: crear una logica separada 
            int def = -(int)(_jugador.def * 0.5);
            int res = -(int)(_jugador.res * 0.5);
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(def), new ResUp(res), new AplicarCancelacionDefJugador(),
                    new AplicarCancelacionResJugador(), new ReduccionDanoPorcentual(0.5m)}, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Chivalry")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoAbsoluta(-2), new EfectoDanoExtra(2, ( ) => -1) }, 
                new List<ICondicion> { new CondicionInicioCombate(), new CondicionFullVidaRival() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Swift Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(6), new ResUp(6), 
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Bracing Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(6), new ResUp(6),
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Golden Lotus")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.5m)}, 
                new List<ICondicion> { new NoTieneMagicRival() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Guard Bearing")
        {
            _habilidad = new GuardBearing(new List<IEfecto> { }, new List<ICondicion> { }, _jugador, 
                _rival);
        }
        if (_nombre_habilidad == "Dodge")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualSpd()}, 
                new List<ICondicion> { new CondicionSpdDanoPorcentual() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Dragon Wall")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualRes()}, 
                new List<ICondicion> { new CondicionDiferenciaStats(Stat.Res, Stat.Res) }, 
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
        else if (_nombre_habilidad == "Lunar Brace")
        {
            _habilidad = new LunarBrace (new List<IEfecto> {}, new List<ICondicion> {}, _jugador,
                _rival);

        }
        else if (_nombre_habilidad == "Back at You")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoBackAtYou()}, 
                new List<ICondicion> { new CondicionNoInicia() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Blue Skies")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoDanoExtra(5, ( ) => -1), new ReduccionDanoAbsoluta(-5)}, 
                new List<ICondicion> { new NoHayCondicion() },   
                _jugador, 
                _rival);
        }
        
        else if (_nombre_habilidad == "Aegis Shield")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(6), new ResUp(3),
                    new ReduccionDanoPorcentualPrimerAtaque(0.5m)}, 
                new List<ICondicion> { new NoHayCondicion() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Sparrow")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new SpdUp(7),
                    new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Mirror")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new ResUp(10),
                    new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Remote Sturdy")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(7), new DefUp(10),
                    new ReduccionDanoPorcentualPrimerAtaque(0.3m)}, 
                new List<ICondicion> { new CondicionInicioCombate() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Fierce Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(8), new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Darting Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(8), new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Steady Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(8), new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Warding Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ResUp(8), new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Kestrel Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new SpdUp(6),
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Sturdy Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new DefUp(6), 
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Mirror Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new ResUp(6),
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Steady Posture")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(6), new DefUp(6),
                    new ReduccionDanoPorcentualFollowUp(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Poetic Justice")
        {
            _habilidad = new PoeticJustice(new List<IEfecto> { }, new List<ICondicion> {}, _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Dragon's Wrath")
        {
            _habilidad = new DragonsWrath ( _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Prescience")
        {
            var habilidades = new List<Habilidad>
            {
                new Habilidad (
                    new List<IEfecto> { new RivalAtkUp(-5), new RivalResUp(-5) }, 
                    new List<ICondicion> { new NoHayCondicion() }, 
                    _jugador, 
                    _rival),
                new Habilidad (
                    new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.3m) }, 
                    new List<ICondicion> { new CondicionInicioCombate() }, 
                    _jugador, 
                    _rival),
                new Habilidad (
                    new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.3m) }, 
                    new List<ICondicion> { new CondicionDistant(), new CondicionNoInicia() }, 
                    _jugador, 
                    _rival)
            };
            _habilidad = new HabilidadCompuesta(habilidades, _jugador, _rival);
        }
        else if (_nombre_habilidad == "Extra Chivalry")
        {
            _habilidad = new ExtraChivalry (new List<IEfecto> { }, new List<ICondicion> {}, _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Bushido")
        {
            var habilidades = new List<Habilidad>
            {
                new Habilidad(
                    new List<IEfecto> { new EfectoDanoExtra(7, ( ) => -1) },
                    new List<ICondicion> { new NoHayCondicion() },
                    _jugador,
                    _rival),
                new Habilidad(
                    new List<IEfecto> { new ReduccionDanoPorcentualSpd() },
                    new List<ICondicion> { new CondicionSpdDanoPorcentual() },
                    _jugador,
                    _rival)
            };
            _habilidad = new HabilidadCompuesta(habilidades, _jugador, _rival);
        }
        else if (_nombre_habilidad == "Divine Recreation")
        {
            _habilidad = _habilidad = new DivineRecreation(_jugador, _rival);
        }
        else if (_nombre_habilidad == "Moon-Twin Wing")
        {
            _habilidad = new MoonTwinWing( _jugador,
                _rival);
        }
    }
}
