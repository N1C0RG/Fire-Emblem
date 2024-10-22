namespace Fire_Emblem;
using Fire_Emblem_View;
public class ManejadorDeAtaques
{
    private int _defensa; 
    
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
        
        int ataqueFinal = (int)Math.Floor(ataque * ventaja) - defensa;
        ataqueFinal = (int)(ataqueFinal * (1 - defensor.reduccionDanoPorcentual)) + defensor.reduccionDanoAbsoluta;

        return ataqueFinal < 0 ? 0 : ataqueFinal;
    }
    public void accionAtacar(Personaje atacante, Personaje defensor, int dano)//sacar view y comentario
    {
        defensor.recivirDano(dano);
        atacante.incrementarAtaques(); 
    }
}