namespace Fire_Emblem.Habilidades;

public struct EstadisticasCombate
{
    private int hp;
    public int atk;
    public int spd;
    public int def;
    public int res;
    public bool inicia_round = false;
    public List<string> bonus_neutralizados = new List<string>(); 
    public List<string> penalty_neutralizados = new List<string>(); 
    public Dictionary<string, int> bonus_stats = new Dictionary<string, int>();
    public Dictionary<string, int> penalty_stats = new Dictionary<string, int>();
    public Dictionary<string, int> stats_netos = new Dictionary<string, int>();
    public int numero_ataque = 1;
    public bool habilidad_first_atack = false;
    public int atk_follow = 0; 
    public string oponente_previo = ""; 
    public EstadisticasCombate(int hp, int atk, int spd, int def, int res)
    {
        this.hp = hp;
        this.atk = atk;
        this.spd = spd;
        this.def = def;
        this.res = res;
    }
    public void netos()
    {
        foreach (var i in bonus_stats)
        {
            
        }
        foreach (var i in penalty_stats)
        {
            
        }
    }
}