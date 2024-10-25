using Fire_Emblem.Habilidades;

namespace Fire_Emblem;

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
    
    public int contadorAtaques = 1;
    public List<string> habilidadPrimerAtaque = new List<string>();
    public int ataqueFollow = 0;
    public string oponentePrevio = "";

    public bool primerCombateInicia = false;
    public bool primeraVexDefiende = false; 
    

    public int reduccionDanoAbsoluta = 0; 
    public bool habilidadHpUp = true;  //TODO: arreglaar esto 
    
    public DataHabilidadStats dataHabilidadStats = new DataHabilidadStats();
    public DataReduccionExtraStats dataReduccionExtraStats = new DataReduccionExtraStats(); 

    

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
        return dataHabilidadStats.netosStats.ContainsKey(stat) ? dataHabilidadStats.netosStats[stat] : 0;
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
        dataHabilidadStats.penaltyNeutralizados.Add(stat); 
    }
    
    public void addHabilidadPrimerAtaque(string stat)
    {
        habilidadPrimerAtaque.Add(stat); 
    }
   
    
    public void resetearContenedoresDeStats()
    {
        dataHabilidadStats.resetearContenedoresDeStats();
        habilidadPrimerAtaque.Clear();
        
    }
    
    public void resetearStatsPorFirstAtack()
    {
        foreach (var stat in habilidadPrimerAtaque)
        {
            if (contadorAtaques == 2)
            { 
                dataHabilidadStats.netosStats[stat] = 0; 
            }
        }
    }
    
    //mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm 
    
    public int getDataHabilidadStat(string dictionaryName, string key)
    {
        return dictionaryName switch
        {
            "bonusStats" => dataHabilidadStats.bonusStats.ContainsKey(key) ? dataHabilidadStats.bonusStats[key] : 0,
            "penaltyStats" => dataHabilidadStats.penaltyStats.ContainsKey(key) 
                ? dataHabilidadStats.penaltyStats[key] : 0,
            "netosStats" => dataHabilidadStats.netosStats.ContainsKey(key) ? dataHabilidadStats.netosStats[key] : 0,
        };
    }
    public Dictionary<string, int> getSpecificDyctionaryDataHabilidadStat(string dictionaryName)
    {
        return dictionaryName switch
        {
            "bonusStats" => dataHabilidadStats.bonusStats,
            "penaltyStats" => dataHabilidadStats.penaltyStats,
            "netosStats" => dataHabilidadStats.netosStats
        };
    }


    public void setDataHabilidadStat(string dictionaryName, string key, int value)
    {
        switch (dictionaryName)
        {
            case "bonusStats":
                dataHabilidadStats.bonusStats[key] = value;
                break;
            case "penaltyStats":
                dataHabilidadStats.penaltyStats[key] = value;
                break;
            case "netosStats":
                dataHabilidadStats.netosStats[key] = value;
                break;
        }
    }
    public void sumarDataHabilidadStat(string dictionaryName, string key, int value)
    {
        switch (dictionaryName)
        {
            case "bonusStats":
                dataHabilidadStats.bonusStats[key] += value;
                break;
            case "penaltyStats":
                dataHabilidadStats.penaltyStats[key] += value;
                break;
            case "netosStats":
                dataHabilidadStats.netosStats[key] += value;
                break;
        }
    }
    public List<string> getSpecificArrayDataHabilidadStat(string dictionaryName)
    {
        return dictionaryName switch
        {
            "bonusNeutralizados" => dataHabilidadStats.bonusNeutralizados,
            "penaltyNeutralizados" => dataHabilidadStats.penaltyNeutralizados,
        };
    }
}


