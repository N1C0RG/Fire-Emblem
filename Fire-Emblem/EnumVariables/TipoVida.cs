namespace Fire_Emblem;
using System.Collections.Generic;

public static class TipoVida
{
    public static readonly Dictionary<string, decimal> Values = new Dictionary<string, decimal>
    {
        { "Hp80%", 0.8m },
        { "Hp75%", 0.75m },
        { "Hp50%", 0.5m }
    };
}
