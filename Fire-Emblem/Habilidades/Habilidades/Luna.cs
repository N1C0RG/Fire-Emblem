using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Habilidades;

public class Luna: Habilidad
{
    public Luna(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
        : base(efecto, condicion, jugador, rival)
    {
        var efectoDef = new EfectoStatPrimerAtaqueRival(Stat.Def.ToString(), -calcularDef());
        var efectoRes = new EfectoStatPrimerAtaqueRival(Stat.Res.ToString(), -calcularRes());
        efecto.Add(efectoDef);
        efecto.Add(efectoRes);
    }
    public override void aplicarHabilidad()
    {
        // rival.addDataHabilidadStat(
        //     NombreDiccionario.primerAtaquePenalty.ToString(), Stat.Def.ToString(), -calcularDef()); 
        // rival.addDataHabilidadStat(
        //     NombreDiccionario.primerAtaquePenalty.ToString(), Stat.Res.ToString(), -calcularRes()); 
    }
    private int calcularRes()
    {
        return (int)Math.Floor(Convert.ToDecimal(rival.res) * 0.5m);
    }

    private int calcularDef()
    {
        return (int)Math.Floor(Convert.ToDecimal(rival.def) * 0.5m);
    }
}