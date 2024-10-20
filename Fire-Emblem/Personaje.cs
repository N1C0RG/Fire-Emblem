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
    public string death_quote;
    private int hp;
    public int hp_original; 
    public int atk;
    public int spd;
    public int def;
    public int res;
    public string[] habilidades;
    public bool inicia_round = false;
    public List<string> bonus_neutralizados = new List<string>(); 
    public List<string> penalty_neutralizados = new List<string>(); 
    public Dictionary<string, int> bonus_stats= new Dictionary<string, int>();
    public Dictionary<string, int> penalty_stats= new Dictionary<string, int>();
    public Dictionary<string, int> netos_stats= new Dictionary<string, int>();
    public int first_atack = 1;
    public List<string> habilidad_first_atack = new List<string>();
    public int atk_follow = 0;
    public string oponente_previo = ""; 

    public Personaje(string name, string weapon, string gender, string death_quote, int hp, int atk, int spd, 
        int def, int res, string[] habilidades)
    {
        this.name = name;
        this.weapon = weapon;
        this.gender = gender;
        this.death_quote = death_quote;
        this.hp = hp;
        this.atk = atk;
        this.spd = spd;
        this.def = def;
        this.res = res;
        this.habilidades = habilidades;
        this.hp_original = hp; 
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
    public bool estaMuerto()
    {
        return HP == 0; 
    }

    public void recivirDano(int cantidad)
    {
        HP -= cantidad; 
    }
    public int obtenerAtaqueConVentaja(decimal ventaja)//TODO ver este metodo 
    {
        return (int)Math.Floor(Convert.ToDecimal(atk + obtenerBonoAtaque()) * ventaja);
    }

    public int obtenerBonoAtaque()
    {
        return netos_stats.ContainsKey("Atk") ? netos_stats["Atk"] : 0;
    }

    public int obtenerDefensa(bool esAtaqueMagico)
    {
        return esAtaqueMagico ? res : def + (netos_stats.ContainsKey("Def") ? netos_stats["Def"] : 0);
    }

    public int obtenerResistencia()
    {
        return netos_stats.ContainsKey("Res") ? netos_stats["Res"] : res;
    }

    public void incrementarAtaques()
    {
        first_atack += 1;
    }
    

    public void calcularNetosStats()
    {
        netos_stats.Clear();

        foreach (var stat in bonus_stats.Keys)
        {
            int bonus = bonus_stats.ContainsKey(stat) ? bonus_stats[stat] : 0;
            int penalty = penalty_stats.ContainsKey(stat) ? penalty_stats[stat] : 0;
            netos_stats[stat] = bonus + penalty;
        }

        foreach (var stat in penalty_stats.Keys)
        {
            if (!netos_stats.ContainsKey(stat))
            {
                int penalty = penalty_stats.ContainsKey(stat) ? penalty_stats[stat] : 0;
                netos_stats[stat] = penalty;
            }
        }
    }
    
    public void resetearContenedoresDeStats()
    {
        bonus_stats.Clear();
        penalty_stats.Clear();
        netos_stats.Clear();
        bonus_neutralizados.Clear();
        penalty_neutralizados.Clear();
        habilidad_first_atack.Clear();
    }
    
    public void ResetearStatsPorFirstAtack()
    {
        foreach (var stat in habilidad_first_atack)
        {
            if (first_atack == 2)
            { 
                netos_stats[stat] = 0; 
            }
        }
    }
    public void ordenarContenedores()
    {
        bonus_stats = ordenarStats(bonus_stats).ToDictionary(x => x.Key, x => x.Value);
        penalty_stats = ordenarStats(penalty_stats).ToDictionary(x => x.Key, x => x.Value);
        bonus_neutralizados = ordenarNeutralizaciones(bonus_neutralizados).ToList();
        penalty_neutralizados = ordenarNeutralizaciones(penalty_neutralizados).ToList();
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


