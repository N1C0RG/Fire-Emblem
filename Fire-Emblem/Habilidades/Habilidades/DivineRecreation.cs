namespace Fire_Emblem.Habilidades;

public class DivineRecreation : Habilidad
{
    public DivineRecreation(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }

    public override void aplicarHabilidad()
    {
        if (new CondicionRivalHP50().condicionHabilidad(jugador, rival))
            new RivalAtkUp(-4).efecto(jugador, rival);
        new RivalSpdUp(-4).efecto(jugador, rival);
        new RivalDefUp(-4).efecto(jugador, rival);
        new RivalResUp(-4).efecto(jugador, rival);


        rival.dataHabilidadStats.postEfecto["Atk"] += -4; 
        foreach (var i in rival.dataHabilidadStats.postEfecto)
        {
            rival.dataHabilidadStats.postEfecto.Add(i.Key, i.Value);
        }

        var c = new CalculadorDeAtaque();
        var v = new Ventaja(); 
        v.calcularVentaja(jugador, rival); 
        var atk = c.calcularAtaque(rival, jugador, v.ventajaRival);

        int cantidad = atk - jugador.reduccionDanoAbsoluta;
        int result = (int)(cantidad * 0.3m);
        
        new ReduccionDanoPorcentualPrimerAtaque(0.3m).efecto(jugador, rival);

        if (new CondicionInicioCombate().condicionHabilidad(jugador, rival))
        {
            new EfectoDanoExtraFollowUp(result).efecto(jugador, rival);
        }
        else
        {
            new EfectoDanoExtraPrimerAtaque(result).efecto(jugador, rival);
        }
    }
}
