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
    public int atk;
    public int spd;
    public int def;
    public int res;
    public string[] habilidades; 

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

    public int defensa(Personaje p2)
    {
        if (weapon == "Magic")
        {
            return p2.res; 
        }
        else
        {
            return p2.def; 
        }
    }
    public int atacar(Personaje p2, bool? multiplicador)
    {
        int ataque = 0; 
        if (multiplicador == true)
        {
           ataque = (int)Math.Floor(Convert.ToDecimal(atk) * 1.2m) - defensa(p2); 
        }
        else if (multiplicador == false)
        {
            ataque = (int)(Math.Floor(Convert.ToDecimal(atk) * 0.8m) - p2.def); 
        }
        else
        {
            ataque = atk - defensa(p2); 
        }

        if (ataque < 0)
        {
            return 0; 
        }
        else
        {
            return ataque; 
        }
    }
    
    
    
}


