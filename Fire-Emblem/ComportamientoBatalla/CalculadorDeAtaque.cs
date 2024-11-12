using System.Security.Cryptography;
using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;


public class CalculadorDeAtaque
{
    protected decimal _ataque;
    protected decimal _ventaja;
    protected int _defensa;
    protected Personaje _atacante;
    protected decimal _reduccionTotal;
    protected Personaje _defensor;
    protected int _ataqueSinReducciones; 

    public int calcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        _atacante = atacante;
        _defensor = defensor;
        _ventaja = ventaja;

        calcularAtaqueBase();
        calcularDefensa();
        calcularReduccionTotal();

        return calcularAtaqueFinal();
        
    }

    private void calcularAtaqueBase()
    {
        int _primerAtaqueBonus = _atacante.getDataHabilidadStat(NombreDiccionario.primerAtaqueBonus.ToString(),
            Stat.Atk.ToString());
        int _primerAtaquePenalty = _atacante.getDataHabilidadStat(NombreDiccionario.primerAtaquePenalty.ToString(),
            Stat.Atk.ToString());
        _ataque = Convert.ToDecimal(_atacante.getAtaque() + _primerAtaquePenalty + _primerAtaqueBonus +  
                                    _atacante.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
                                        Stat.Atk.ToString()));
    }
    private void calcularDefensa()
    {
        bool esAtaqueMagico = _atacante.getArma() == Armas.Magic.ToString();
        int _primerAtaqueBonus =  esAtaqueMagico ? _defensor.getDataHabilidadStat
                (NombreDiccionario.primerAtaqueBonus.ToString(),
            Stat.Res.ToString()) : _defensor.getDataHabilidadStat(NombreDiccionario.primerAtaqueBonus.ToString(),
            Stat.Def.ToString());
        int _primerAtaquePenalty =  esAtaqueMagico ? _defensor.getDataHabilidadStat
                (NombreDiccionario.primerAtaquePenalty.ToString(),
            Stat.Res.ToString()) : _defensor.getDataHabilidadStat(NombreDiccionario.primerAtaquePenalty.ToString(),
            Stat.Def.ToString());
        _defensa = esAtaqueMagico ? 
            _defensor.getResistencia() + _defensor.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(), 
                Stat.Res.ToString()) + _primerAtaqueBonus + _primerAtaquePenalty
            : _defensor.getDefensa() + _defensor.getDataHabilidadStat(NombreDiccionario.postEfecto.ToString(),
                Stat.Def.ToString())+ _primerAtaqueBonus + _primerAtaquePenalty;
    }

    private void calcularReduccionTotal()
    {
        decimal reduccionTotal = 1;
        foreach (var reduccion 
                 in _defensor.dataReduccionExtraStats.ReduccionDanoPorcentualDictionary)
        {
            if (reduccion.Key == "primerAtaque" && _atacante.contadorAtaques == 1)
            {
                reduccionTotal *= (1 - reduccion.Value);
            }
            else if (reduccion.Key == "todosAtaques")
            {
                reduccionTotal *= (1 - reduccion.Value);
            }
        }

        _reduccionTotal =  reduccionTotal;
    }

    private int calcularAtaqueFinal()
    {
        int ataqueFinal = (int)Math.Floor(_ataque * _ventaja) - _defensa < 0 ? 0 : (int)Math.Floor(_ataque * _ventaja) - _defensa;
        ataqueFinal += _atacante.dataReduccionExtraStats.DanoAdicionalDictionary["todosAtaques"]; 
        if (_atacante.contadorAtaques == 1)
        {
            ataqueFinal += _atacante.dataReduccionExtraStats.DanoAdicionalDictionary["primerAtaque"];
        }
        _ataqueSinReducciones = ataqueFinal;//TODO: cambiar asto
        //Console.WriteLine($"{_atacante.name} ataque final {ataqueFinal}");
        ataqueFinal = (int)(ataqueFinal * _reduccionTotal) + _defensor.reduccionDanoAbsoluta;
        // Console.WriteLine($"{_atacante.name} ataque final {ataqueFinal}");
        // Console.WriteLine($"{_defensor.name} ataque final {_reduccionTotal}");
        //Console.WriteLine($"la reduccion total de {_defensor.name} : {_reduccionTotal}");
        //Console.WriteLine($"el ataque total de {_atacante.name} : {ataqueFinal}");
        return ataqueFinal < 0 ? 0 : ataqueFinal;
        
    }

    public decimal calcularReduccion()
    {
        return _ataqueSinReducciones; 
    }
}
