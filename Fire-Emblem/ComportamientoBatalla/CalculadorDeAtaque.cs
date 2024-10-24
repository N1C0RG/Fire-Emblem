using System.Security.Cryptography;

namespace Fire_Emblem;

public class CalculadorDeAtaque
{
    protected decimal _ataque;
    protected decimal _ventaja;
    protected int _defensa;
    protected Personaje _atacante;
    protected decimal _reduccionTotal;
    protected Personaje _defensor;

    public int calcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        _atacante = atacante;
        _defensor = defensor;
        _ventaja = ventaja;

        _atacante.resetearStatsPorFirstAtack();
        _defensor.resetearStatsPorFirstAtack();

        calcularAtaqueBase();
        calcularDefensa();
        calcularReduccionTotal();

        return calcularAtaqueFinal();
        
    }

    private void calcularAtaqueBase()
    {
        _ataque = Convert.ToDecimal(_atacante.getAtaque() + _atacante.getNetoStats("Atk"));
    }

    private void calcularDefensa()
    {
        bool esAtaqueMagico = _atacante.getArma() == Armas.Magic.ToString();
        _defensa = esAtaqueMagico ? _defensor.getResistencia() + _defensor.getNetoStats("Res")
                              : _defensor.getDefensa() + _defensor.getNetoStats("Def");
    }

    private void calcularReduccionTotal()
    {
        decimal reduccionTotal = 1;

        foreach (var reduccion in _defensor.ReduccionDanoPorcentualDictionary)
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
        int ataqueFinal = (int)Math.Floor(_ataque * _ventaja) - _defensa + _atacante.DanoAdicionalDictionary["todosAtaques"];

        if (_atacante.contadorAtaques == 1)
        {
            ataqueFinal += _atacante.DanoAdicionalDictionary["primerAtaque"];
        }

        ataqueFinal = (int)(ataqueFinal * _reduccionTotal) + _defensor.reduccionDanoAbsoluta;

        return ataqueFinal < 0 ? 0 : ataqueFinal;
    }
}

