using Fire_Emblem.Habilidades;

namespace Fire_Emblem;
public class JsonContent
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public string HP { get; set; }
    public string Atk { get; set; }
    public string Spd { get; set; }
    public string Def { get; set; }
    public string Res { get; set; }
}
public class Personaje
{
    public string name;
    public string weapon;
    public string gender;
    public string deathQuote;
    private int hp;
    public int hpOriginal; 
    public int atk;
    public int spd;
    public int def;
    public int res;
    public string[] habilidades;
    public bool iniciaRound = false;
    public List<string> bonusNeutralizados = new List<string>(); 
    public List<string> penaltyNeutralizados = new List<string>(); 
    public Dictionary<string, int> bonusStats= new Dictionary<string, int>();
    public Dictionary<string, int> penaltyStats= new Dictionary<string, int>();
    public Dictionary<string, int> netosStats= new Dictionary<string, int>();
    public int contadorAtaques = 1;
    public List<string> habilidadPrimerAtaque = new List<string>();
    public int ataqueFollow = 0;
    public string oponentePrevio = "";
    
    
    public decimal reduccionDanoPorcentual = 0m;
    public int reduccionDanoAbsoluta = 0; 
    public bool habilidadHpUp = true;  //TODO: arreglaar esto 
    public int danoAdicional = 0;
    public Dictionary<string, decimal> ReduccionDanoPorcentualDictionary = new Dictionary<string, decimal>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} }; //TODO: aplicar esto a la logica del juego 
    public Dictionary<string, int> DanoAdicionalDictionary = new Dictionary<string, int>{ {"primerAtaque", 0}, {"followUp", 0}, {"todosAtaques", 0} };

    public Personaje(string name, string weapon, string gender, string deathQuote, int hp, int atk, int spd, 
        int def, int res, string[] habilidades)
    {
        this.name = name;
        this.weapon = weapon;
        this.gender = gender;
        this.deathQuote = deathQuote;
        this.hp = hp;
        this.atk = atk;
        this.spd = spd;
        this.def = def;
        this.res = res;
        this.habilidades = habilidades;
        hpOriginal = hp; 
    }

    public int HP
    {
        get { return hp;  }
        set
        {
            if (value < 0)
            {
                hp = 0; 
            }
            else
            {
                hp = value; 
            }
        }
    }
    //TODO: ver este metodo, la clase tiene muchos metodos publicos 

    public string[] getHabilidades()
    {
        return habilidades; 
    }

    public void recivirDano(int cantidad)
    {
        HP -= cantidad; 
    }public int getAtaque()
    {
        return atk; 
    }
    public int getResistencia()
    {
        return res; 
    }
    public int getDefensa()
    {
        return def; 
    }
    public int getNetoStats(string stat)
    {
        return netosStats.ContainsKey(stat) ? netosStats[stat] : 0;
    }

    public string getArma()
    {
        return weapon; 
    }

    public string getNombre()
    {
        return name; 
    }
    public int getHp()
    {
        return hp; 
    }
    public void incrementarAtaques()
    {
        contadorAtaques += 1;
    }

    public void setIniciaTurno(bool valor)
    {
        iniciaRound = valor; 
    }
    
    public int getAtaqueFollow()
    {
        return ataqueFollow; 
    }

    public void setContadorAtaques(int cantidad)
    {
        contadorAtaques = cantidad; 
    }
    public int getContadorAtaques()
    {
        return contadorAtaques; 
    }

    public void setOponentePrevio(string oponente)
    {
        oponentePrevio = oponente; 
    }

    public int getHpOriginal()
    {
        return hpOriginal; 
    }
    
    public bool getIniciaTurno()
    {
        return iniciaRound; 
    }

    public string getOponentePrevio()
    {
        return oponentePrevio; 
    }

    public string getGenero()
    {
        return gender; 
    }
    public void addPenaltyNeutralizados(string stat)
    {
        penaltyNeutralizados.Add(stat); 
    }
    
    public void addHabilidadPrimerAtaque(string stat)
    {
        habilidadPrimerAtaque.Add(stat); 
    }
    public void calcularNetosStats()
    {
        netosStats.Clear();

        foreach (var stat in bonusStats.Keys)
        {
            int bonus = bonusStats.ContainsKey(stat) ? bonusStats[stat] : 0;
            int penalty = penaltyStats.ContainsKey(stat) ? penaltyStats[stat] : 0;
            netosStats[stat] = bonus + penalty;
        }

        foreach (var stat in penaltyStats.Keys)
        {
            if (!netosStats.ContainsKey(stat))
            {
                int penalty = penaltyStats.ContainsKey(stat) ? penaltyStats[stat] : 0;
                netosStats[stat] = penalty;
            }
        }
    }
    
    public void resetearContenedoresDeStats()
    {
        bonusStats.Clear();
        penaltyStats.Clear();
        netosStats.Clear();
        bonusNeutralizados.Clear();
        penaltyNeutralizados.Clear();
        habilidadPrimerAtaque.Clear();
    }
    
    public void ResetearStatsPorFirstAtack()
    {
        foreach (var stat in habilidadPrimerAtaque)
        {
            if (contadorAtaques == 2)
            { 
                netosStats[stat] = 0; 
            }
        }
    }
    public void ordenarContenedores()
    {
        bonusStats = ordenarStats(bonusStats).ToDictionary(x => x.Key, x => x.Value);
        penaltyStats = ordenarStats(penaltyStats).ToDictionary(x => x.Key, x => x.Value);
        bonusNeutralizados = ordenarNeutralizaciones(bonusNeutralizados).ToList();
        penaltyNeutralizados = ordenarNeutralizaciones(penaltyNeutralizados).ToList();
    }
    private IEnumerable<KeyValuePair<string, int>> ordenarStats(Dictionary<string, int> stats)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(stats.ContainsKey).Select(key => new KeyValuePair<string, int>(key, stats[key]));
    }
    private IEnumerable<string> ordenarNeutralizaciones(IEnumerable<string> neutralizations)
    {
        string[] orden = { "Atk", "Spd", "Def", "Res" };
        return orden.Where(neutralizations.Contains);
    }
    
}


