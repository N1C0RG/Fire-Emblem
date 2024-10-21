using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;
public class HabilidadManager
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view;
    private NeutralizadorEfectos _neutralizadorEfectos;
    private ImpresoraBonusPenaltyNeutralizaciones _impresoraHabilidades;

    public HabilidadManager(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view;
        _neutralizadorEfectos = new NeutralizadorEfectos(jugador, rival);
        _impresoraHabilidades = new ImpresoraBonusPenaltyNeutralizaciones(jugador, rival, view);
    }

    public void aplicarTodo()
    {
        aplicarHabilidades(_jugador, _rival);
        aplicarHabilidades(_rival, _jugador);
        ordenarBonusEnDiccionarioListas();
        _impresoraHabilidades.printTodoBonusPenaltyNeutralizaciones();
        _neutralizadorEfectos.aplicarNeutralizadores();
    }

    private void aplicarHabilidades(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidad(habilidad, jugador, rival);
            fabricaHabilidad.crearHabilidad();
            var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
            aplicadorHabilidad.aplicarHabilidad();
        }
    }

    private void ordenarBonusEnDiccionarioListas()
    {
        _jugador.ordenarContenedores();
        _rival.ordenarContenedores();
    }
}


public class NeutralizadorEfectos
{
    private Personaje _jugador;
    private Personaje _rival; 
    public NeutralizadorEfectos(Personaje jugador, Personaje rival)
    {
        _jugador = jugador;
        _rival = rival; 
    }
    public void aplicarNeutralizadores()
    {
        neutralizarBonusPenalty(_jugador);
        neutralizarFollowBonusPenalty(_jugador);
        neutralizarBonusPenalty(_rival);
        neutralizarFollowBonusPenalty(_rival);
    }
    private void neutralizarBonusPenalty(Personaje jugador) //TODO ver esto 
    {
        foreach (var stat in jugador.bonusNeutralizados)
        {
            jugador.bonusStats[stat] = 0;
        }
        foreach (var stat in jugador.penaltyNeutralizados)
        {
            jugador.penaltyStats[stat] = 0;
        }
    }
    private void neutralizarFollowBonusPenalty(Personaje jugador)
    {
        if (jugador.getAtaqueFollow() > 0 && jugador.bonusNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }
        if (jugador.getAtaqueFollow() < 0 && jugador.penaltyNeutralizados.Contains("Atk"))
        {
            jugador.ataqueFollow = 0;
        }
    }
}

public class ImpresoraBonusPenaltyNeutralizaciones
{
    private Personaje _jugador;
    private Personaje _rival;
    private View _view; 
    public ImpresoraBonusPenaltyNeutralizaciones(Personaje jugador, Personaje rival, View view)
    {
        _jugador = jugador;
        _rival = rival;
        _view = view; 
    }
    public void printTodoBonusPenaltyNeutralizaciones()
    {
        printFollowUpAtk(_jugador);
        printFollowUpAtk(_rival);
        printJugadorBonusPenalty(_jugador);
        printBonusPenaltyNeutralizados(_jugador);
        printJugadorBonusPenalty(_rival);
        printBonusPenaltyNeutralizados(_rival);
    }

    private void printJugadorBonusPenalty(Personaje jugador)
    {
        foreach (var stat in jugador.bonusStats)
        {
            printBonusPenalty(jugador, stat, stat.Value > 0 ? "+" : "");
        }

        foreach (var stat in jugador.penaltyStats)
        {
            if (stat.Value < 0)
            {
                printBonusPenalty(jugador, stat, "");
            }
        }
    }

    private void printBonusPenalty(Personaje jugador, KeyValuePair<string, int> stat, string sign)
    {
        var mensaje = (jugador.getContadorAtaques() == 1 && jugador.habilidadPrimerAtaque.Contains(stat.Key))
            ? $"{jugador.name} obtiene {stat.Key}{sign}{stat.Value} en su primer ataque"
            : $"{jugador.name} obtiene {stat.Key}{sign}{stat.Value}";

        _view.WriteLine(mensaje);
    }
    
    private void printBonusPenaltyNeutralizados(Personaje jugador)
    {  
        foreach (var bonus in jugador.bonusNeutralizados)
        {
            _view.WriteLine($"Los bonus de {bonus} de {jugador.name} fueron neutralizados");
        }

        foreach (var penalty in jugador.penaltyNeutralizados)
        {
            _view.WriteLine($"Los penalty de {penalty} de {jugador.name} fueron neutralizados");
        }
    }
    private void printFollowUpAtk(Personaje jugador)
    {
        if (jugador.getAtaqueFollow() != 0)
        {
            var sign = jugador.getAtaqueFollow() > 0 ? "+" : "";
            _view.WriteLine($"{jugador.name} obtiene Atk{sign}{jugador.getAtaqueFollow()} en su Follow-Up");
        }
    }
    
}