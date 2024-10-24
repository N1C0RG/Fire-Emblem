namespace Fire_Emblem.Habilidades;

public class FabricaHabilidadesDependientesStats : FabricaHabilidad
{
    public FabricaHabilidadesDependientesStats(string nombreHabilidad, Personaje jugador, Personaje rival) 
        : base(nombreHabilidad, jugador, rival){}

    public override void crearHabilidad()
    {
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
        else if (_nombre_habilidad == "Fierce Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(8), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Darting Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(8), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Steady Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new DefUp(8), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Warding Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new ResUp(8), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Kestrel Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new SpdUp(6), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Sturdy Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new DefUp(6), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() },   
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Mirror Stance")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new AtkUp(6), new ResUp(6), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Steady Posture")
        {
            _habilidad = new Habilidad (
                new List<IEfecto> { new SpdUp(6), new DefUp(6), new ReduccionDanoPorcentualFollowUo(0.1m)}, 
                new List<ICondicion> { new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Poetic Justice")
        {
            //TODO: crear una logica separa para la habilidad 
            int cantidad = (int)(_rival.atk * 0.15); 
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalSpdUp(-4), new EfectoDanoExtra(cantidad)}, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Dragon's Wrath")
        {
            //TODO: crear una logica separada 
            int cantidad = 0; 
            if (_jugador.atk + _jugador.postEfecto["Atk"] > _rival.res + _rival.postEfecto["Res"])
            {
                cantidad = (int)(((_jugador.atk + _jugador.postEfecto["Atk"]) - (_rival.res + _rival.postEfecto["Res"]))/4);
            }
            _habilidad = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.25m), new EfectoDanoExtraPrimerAtaque(cantidad) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Prescience")
        {
            //TODO: crear una logica separada 
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-5), new RivalResUp(-5) }, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.3m) }, 
                new List<ICondicion> { new CondicionInicioCombate() }, 
                _jugador, 
                _rival);
            _habilidadTerceraCondicion = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.3m) }, 
                new List<ICondicion> { new CondicionDistant(), new CondicionNoInicia() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Extra Chivalry")
        {
            //TODO: crear una logica separada 
            _habilidad = new Habilidad (
                new List<IEfecto> { new RivalAtkUp(-5), new RivalSpdUp(-5), new RivalDefUp(-5) }, 
                new List<ICondicion> { new CondicionRivalHP50() }, 
                _jugador, 
                _rival);
            decimal porcentajeHP = Math.Floor((_rival.HP / (decimal)_rival.hpOriginal) * 100);
            decimal cantidad = (porcentajeHP * 0.5m) / 100m;
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentual(cantidad)}, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Bushido")
        {
            //TODO: crear una logica separada 
            _habilidad = new Habilidad (
                new List<IEfecto> { new EfectoDanoExtra(7)}, 
                new List<ICondicion> { new NoHayCondicion() }, 
                _jugador, 
                _rival);
            _habilidadSegundaCondicion = new Habilidad (
                new List<IEfecto> { new ReduccionDanoPorcentualSpd() }, 
                new List<ICondicion> { new CondicionSpdDanoPorcentual() }, 
                _jugador, 
                _rival);
        }
        else if (_nombre_habilidad == "Divine Recreation")
        {
            _habilidad = _habilidad = new DivineRecreation(new List<IEfecto> {}, new List<ICondicion> {}, _jugador, _rival);
        }
        else if (_nombre_habilidad == "Moon-Twin Wing")
        {
            _habilidad = new MoonTwinWing(new List<IEfecto> {}, new List<ICondicion> {}, _jugador, _rival);
        }
    }
}