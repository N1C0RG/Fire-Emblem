// namespace Fire_Emblem.Habilidades;
//
// public class DivineRecreation : Habilidad
// {
//     public DivineRecreation(List<IEfecto> efecto, List<ICondicion> condicion, Personaje jugador, Personaje rival)
//         : base(efecto, condicion, jugador, rival)
//     {
//     }
//
//     public override void aplicarHabilidad()
//     {
//         if (condicionHabilidadStats());
//         {
//             new RivalAtkUp(-4).efecto(jugador, rival);
//             new RivalSpdUp(-4).efecto(jugador, rival);
//             new RivalDefUp(-4).efecto(jugador, rival);
//             new RivalResUp(-4).efecto(jugador, rival);
//         }
//
//
//        modificarPostEfecto();
//         
//         new ReduccionDanoPorcentualPrimerAtaque(0.3m).efecto(jugador, rival);
//
//         int danoExtra = calcularDano(); 
//         
//         if (condicionDanoExtra())
//         {
//             new EfectoDanoExtraFollowUp(danoExtra, () => -1).efecto(jugador, rival);
//         }
//         else
//         {
//             new EfectoDanoExtraPrimerAtaque(danoExtra, () => -1).efecto(jugador, rival);
//         }
//     }
//     
//
//     private bool condicionHabilidadStats()
//     {
//         bool condicion = new CondicionRivalHP50().condicionHabilidad(jugador, rival);
//         return condicion; 
//     }
//
//     private int calcularDano()
//     {
//         var calculadorAtaque = new CalculadorDeAtaque();
//         var ventaja = new Ventaja(); 
//         ventaja.calcularVentaja(jugador, rival); 
//         var ataque = calculadorAtaque.calcularAtaque(rival, jugador, ventaja.ventajaRival);
//         int cantidad = ataque - jugador.reduccionDanoAbsoluta;
//         
//         return (int)(cantidad * 0.3m);
//     }
//
//     private bool condicionDanoExtra()
//     {
//         bool condicion = new CondicionInicioCombate().condicionHabilidad(jugador, rival);
//         return condicion; 
//     }
//
//     private void modificarPostEfecto()
//     {
//         rival.dataHabilidadStats.postEfecto["Atk"] += -4; 
//         foreach (var i in rival.dataHabilidadStats.postEfecto)
//         {
//             rival.dataHabilidadStats.postEfecto.Add(i.Key, i.Value);
//         }
//     }
// }
using Fire_Emblem.Encapsulado;
using Fire_Emblem.EnumVariables;

namespace Fire_Emblem.Habilidades;

public class DivineRecreation : HabilidadCompuesta
{
    public DivineRecreation(Personaje jugador, Personaje rival)
        : base(new List<Habilidad>(), jugador, rival)
    {
        agregarEfectos();
    }
    public override void aplicarHabilidad()
    {

        new ReduccionDanoPorcentualPrimerAtaque(0.25m).efecto(jugador, rival);
        
    }
    public void agregarEfectos()
    {
       
        var habilidades = new List<Habilidad>()
        {
            new Habilidad(
                new List<IEfecto> { new RivalAtkUp(-4), new RivalSpdUp(-4), 
                    new RivalDefUp(-4), new RivalResUp(-4) },
                new List<ICondicion> {  new CondicionRivalHP50() },
                _jugador,
                _rival),
            new Habilidad(
                new List<IEfecto> { new ReduccionDanoPorcentualPrimerAtaque(0.3m), efectoDanoExtra() },
                new List<ICondicion> {new CondicionRivalHP50() },
                _jugador,
                _rival)
        }; 
        _habilidades = habilidades;
    }
    private int calcularDano()
     {
         var calculadorAtaque = new CalculadorDeAtaque();
         var ventaja = new Ventaja(); 
         ventaja.calcularVentaja(jugador, rival); 
         var ataque = calculadorAtaque.calcularAtaque(rival, jugador, ventaja.ventajaRival);
         decimal cantidad = (int)(calculadorAtaque.calcularReduccion()); 
         //Console.WriteLine($"cantidad de ataque {cantidad}");
         //Console.WriteLine($"el ataque final {ataque}");
         //Console.WriteLine($" reduccion {rival.name} {rival.getDataReduccionExtraStat<decimal>(NombreDiccionario.reduccionPorcentual.ToString(), Llave.primerAtaque.ToString())}");
         //Console.WriteLine($"{ataque} - {cantidad} = {ataque - cantidad}");
         return (int)(cantidad  - ataque);
     }

    private IEfecto efectoDanoExtra()
    {
         //int danoExtra = calcularDano(); 
         
         if (new CondicionInicioCombate().condicionHabilidad(jugador, rival))
         {
             return new DivineFollow(0, calcularDano);
         }
         return new DivinePrimerAtaque(0, calcularDano);
    }

}


