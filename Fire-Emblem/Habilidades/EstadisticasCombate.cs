namespace Fire_Emblem.Habilidades;

public struct EstadisticasCombate
{
    private int hp;
    public int atk;
    public int spd;
    public int def;
    public int res;

    public EstadisticasCombate(int hp, int atk, int spd, int def, int res)
    {
        this.hp = hp;
        this.atk = atk;
        this.spd = spd;
        this.def = def;
        this.res = res;
    }

    public void ResetStats()
    {
        hp = 0;
        atk = 0;
        spd = 0;
        def = 0;
        res = 0; 
    }
}