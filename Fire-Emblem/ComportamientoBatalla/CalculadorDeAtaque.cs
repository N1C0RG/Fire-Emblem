namespace Fire_Emblem;

public class CalculadorDeAtaque
{
    private decimal _ataque;
    private decimal _ventaja;
    private int _defensa;
    private Personaje _atacante;
    private decimal _reduccionTotal;
    private Personaje _defensor;

    public int calcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja)
    {
        _atacante = atacante;
        _defensor = defensor;
        _ventaja = ventaja;

        _atacante.ResetearStatsPorFirstAtack();
        _defensor.ResetearStatsPorFirstAtack();

        _ataque = calcularAtaqueBase();
        _defensa = calcularDefensa();
        _reduccionTotal = calcularReduccionTotal();

        return calcularAtaqueFinal();
        
    }

    private decimal calcularAtaqueBase()
    {
        return Convert.ToDecimal(_atacante.getAtaque() + _atacante.getNetoStats("Atk"));
    }

    private int calcularDefensa()
    {
        bool esAtaqueMagico = _atacante.getArma() == Armas.Magic.ToString();
        return esAtaqueMagico ? _defensor.getResistencia() + _defensor.getNetoStats("Res")
                              : _defensor.getDefensa() + _defensor.getNetoStats("Def");
    }

    private decimal calcularReduccionTotal()
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

        return reduccionTotal;
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