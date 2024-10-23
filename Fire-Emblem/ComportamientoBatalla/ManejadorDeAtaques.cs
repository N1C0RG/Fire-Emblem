using Fire_Emblem.Encapsulado;

namespace Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem.Encapsulado;
using Fire_Emblem_View;

public class ManejadorDeAtaques
{
    public void accionAtacar(Personaje atacante, Personaje defensor, int dano)
    {
        defensor.recivirDano(dano);
        atacante.incrementarAtaques();
    }
}