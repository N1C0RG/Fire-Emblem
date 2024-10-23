using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;
using Fire_Emblem_View;
public class ManejadorDeAtaques
{
   
    public int calcularAtaque(Personaje atacante, Personaje defensor, decimal ventaja) 
    {
        //TODO: modificar lo de la recuccion del dano 
        //TODO: arreglar esto
        atacante.ResetearStatsPorFirstAtack();
        defensor.ResetearStatsPorFirstAtack(); 
        
        decimal ataque = Convert.ToDecimal(atacante.getAtaque() + atacante.getNetoStats("Atk"));
        bool esAtaqueMagico = atacante.getArma() == Armas.Magic.ToString();
        int defensa = esAtaqueMagico ? defensor.getResistencia() + defensor.getNetoStats("Res") 
            : defensor.getDefensa() + defensor.getNetoStats("Def");
    
        //TODO: arreglar esta logica 
        decimal reduccionTotal = 1;
    
        foreach (var reduccion in defensor.ReduccionDanoPorcentualDictionary)
        {
            if (reduccion.Key == "primerAtaque")
            {
                if (atacante.contadorAtaques == 1)
                {
                    reduccionTotal *= (1 - reduccion.Value);
                }
            }
            else if(reduccion.Key == "todosAtaques")
            {
                reduccionTotal *= (1 - reduccion.Value);
            }
        }
        //me podria traer problemaas el orden en que aplicos los 3 nuevos tipos de efectos 
        int ataqueFinal = (int)Math.Floor(ataque * ventaja) - defensa + atacante.DanoAdicionalDictionary["todosAtaques"];
        
        if (atacante.contadorAtaques == 1)
        {
            ataqueFinal += atacante.DanoAdicionalDictionary["primerAtaque"];
        }
        
        ataqueFinal = (int)(ataqueFinal * (reduccionTotal)) + defensor.reduccionDanoAbsoluta;
    
        return ataqueFinal < 0 ? 0 : ataqueFinal;
    }
    
    public void accionAtacar(Personaje atacante, Personaje defensor, int dano)//sacar view y comentario
    {
        defensor.recivirDano(dano);
        atacante.incrementarAtaques(); 
    }
}