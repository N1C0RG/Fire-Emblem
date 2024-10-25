namespace Fire_Emblem.Habilidades;

public class DivineRecreation : Habilidad
{
    public DivineRecreation(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
    }

    public override void aplicarHabilidad()
    {
        if (condicionHabilidadStats());
        {
            new RivalAtkUp(-4).efecto(jugador, rival);
            new RivalSpdUp(-4).efecto(jugador, rival);
            new RivalDefUp(-4).efecto(jugador, rival);
            new RivalResUp(-4).efecto(jugador, rival);
        }


       modificarPostEfecto();
        
        new ReduccionDanoPorcentualPrimerAtaque(0.3m).efecto(jugador, rival);

        int danoExtra = calcularDano(); 
        
        if (condicionDanoExtra())
        {
            new EfectoDanoExtraFollowUp(danoExtra).efecto(jugador, rival);
        }
        else
        {
            new EfectoDanoExtraPrimerAtaque(danoExtra).efecto(jugador, rival);
        }
    }

    private bool condicionHabilidadStats()
    {
        bool condicion = new CondicionRivalHP50().condicionHabilidad(jugador, rival);
        return condicion; 
    }

    private int calcularDano()
    {
        var calculadorAtaque = new CalculadorDeAtaque();
        var ventaja = new Ventaja(); 
        ventaja.calcularVentaja(jugador, rival); 
        var ataque = calculadorAtaque.calcularAtaque(rival, jugador, ventaja.ventajaRival);
        int cantidad = ataque - jugador.reduccionDanoAbsoluta;
        
        return (int)(cantidad * 0.3m);
    }

    private bool condicionDanoExtra()
    {
        bool condicion = new CondicionInicioCombate().condicionHabilidad(jugador, rival);
        return condicion; 
    }

    private void modificarPostEfecto()
    {
        rival.dataHabilidadStats.postEfecto["Atk"] += -4; 
        foreach (var i in rival.dataHabilidadStats.postEfecto)
        {
            rival.dataHabilidadStats.postEfecto.Add(i.Key, i.Value);
        }
    }
}
