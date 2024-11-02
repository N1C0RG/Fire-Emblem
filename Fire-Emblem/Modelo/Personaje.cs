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
    //public List<string> habilidadPrimerAtaque = new List<string>();
    public int ataqueFollow = 0;
    public string oponentePrevio = "";
    public bool primerCombateInicia = false;
    public bool primeraVexDefiende = false; 
    public int reduccionDanoAbsoluta = 0; 
    public bool habilidadHpUp = true; 
    
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
    public string getOponentePrevio()
    {
        return oponentePrevio; 
    }
    public int getHpOriginal()
    {
        return hpOriginal; 
    }
    public bool getIniciaTurno()
    {
        return iniciaRound; 
    }
    public string getGenero()
    {
        return gender; 
    }
    public void addPenaltyNeutralizados(string stat)
    {
        dataHabilidadStats.penaltyNeutralizados.Add(stat); 
    }
    public void calcularPostEfecto()
    {
        dataHabilidadStats.calcularPostEfecto();
    }
    public void calcularNetosStats()
    {
        dataHabilidadStats.calcularNetosStats();
    }
    public void ordenarContenedores()
    {
        dataHabilidadStats.ordenarContenedores();
    }
    public void resetearContenedoresDeStats()
    {
        dataHabilidadStats.resetearContenedoresDeStats();
        
    }
    public void addDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        dataHabilidadStats.addDataHabilidadStat(nombreDiccionario, key, value);
    }
    public int getDataHabilidadStat(string nombreDiccionario, string key)
    {
        return dataHabilidadStats.getDataHabilidadStat(nombreDiccionario, key);
    }
    public Dictionary<string, int> getSpecificDyctionaryDataHabilidadStat(string nombreDiccionario)
    {
        return dataHabilidadStats.getSpecificDyctionaryDataHabilidadStat(nombreDiccionario);
    }
    public void setDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        dataHabilidadStats.setDataHabilidadStat(nombreDiccionario, key, value);
    }
    public void sumarDataHabilidadStat(string nombreDiccionario, string key, int value)
    {
        dataHabilidadStats.sumarDataHabilidadStat(nombreDiccionario, key, value);
    }
    public bool contieneStatNeutralizado(string nombreDiccionario, string key)
    {
        return dataHabilidadStats.contieneStatNeutralizado(nombreDiccionario, key); 
    }
    public List<string> getSpecificArrayDataHabilidadStat(string nombreDiccionario)
    {
        return dataHabilidadStats.getSpecificArrayDataHabilidadStat(nombreDiccionario); 
    }
    public Dictionary<string, T> getDiccionarioReduccionExtraStat<T>(string nombreDiccionario)
    {
        return dataReduccionExtraStats.getDiccionarioReduccionExtraStat<T>(nombreDiccionario);
    }
    public T getDataReduccionExtraStat<T>(string nombreDiccionario, string key)
    {
        return dataReduccionExtraStats.getDataReduccionExtraStat<T>(nombreDiccionario, key);
    }

    public void setDataReduccionExtraStat(string dictionaryName, string key, decimal value)
    {
        dataReduccionExtraStats.setDataReduccionExtraStat(dictionaryName, key, value);
    }
    
}


