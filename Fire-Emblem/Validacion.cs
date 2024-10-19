using FireEmblem.Encapsulado;

namespace Fire_Emblem;

public class Validacion
{
    private Player _jugador;
    private Player _rival;
    private CondicionesValidacionEncapsuladas _condicion = new CondicionesValidacionEncapsuladas(); //TODO: ver si encapsular la logica tiene sentido 

    public Validacion(Player jugador, Player rival)
    {
        _jugador = jugador;
        _rival = rival;
    }

    public bool EquipoValido()
    {
        return _condicion.validarEquipoCompleto(_jugador, _rival);
    }
}