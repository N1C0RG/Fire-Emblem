using Fire_Emblem.Encapsulado;

namespace Fire_Emblem.Vista;
using Fire_Emblem_View;

public class VistaStatsEfectosHabilidades
{
    private readonly View _view;

    public VistaStatsEfectosHabilidades(View view)
    {
        _view = view;
    }
    public void printTodoBonusPenaltyNeutralizaciones(Personaje jugador, Personaje rival)
    {
        printFollowUpAtk(jugador);
        printFollowUpAtk(rival);
        printJugadorBonus(jugador);
        printJugadorPenalty(jugador);
        printBonusPenaltyNeutralizados(jugador);
        printDanoExtra(jugador);
        printDanoExtraPrimerAtaque(jugador);
        printDanoExtraFollowUp(jugador);
        printReduccionDanoPorcentual(jugador); 
        printReduccionDanoPorcentualPrimerAtaque(jugador); 
        printReduccionDanoPorcentualFollowUp(jugador);
        printReduccionDanoAbsoluto(jugador);
        printJugadorBonus(rival);
        printJugadorPenalty(rival);
        printBonusPenaltyNeutralizados(rival);
        printDanoExtra(rival);
        printDanoExtraPrimerAtaque(rival);
        printDanoExtraFollowUp(rival);
        printReduccionDanoPorcentual(rival);
        printReduccionDanoPorcentualPrimerAtaque(rival);
        printReduccionDanoPorcentualFollowUp(rival);
        printReduccionDanoAbsoluto(rival);
    }
    private void printJugadorBonus(Personaje jugador)
    {
        foreach (var stat in jugador.bonusStats)
        {
            printBonusPenalty(jugador, stat, stat.Value > 0 ? "+" : "");
        }

        
    }
    private void printJugadorPenalty(Personaje jugador)
    {
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

    private void printReduccionDanoPorcentual(Personaje jugador)
    {
        if (jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño de los ataques del rival en un {Math.Truncate(jugador.ReduccionDanoPorcentualDictionary["todosAtaques"] * 100)}%");
        }
    }
    private void printReduccionDanoAbsoluto(Personaje jugador)
        {
            if (jugador.reduccionDanoAbsoluta != 0)
            {
                _view.WriteLine($"{jugador.name} recibirá {jugador.reduccionDanoAbsoluta} daño en cada ataque");
            }
        }

    private void printDanoExtra(Personaje jugador)
    {
        if (jugador.DanoAdicionalDictionary["todosAtaques"] != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +{jugador.DanoAdicionalDictionary["todosAtaques"]} daño extra en cada ataque");
        }
    }
    private void printReduccionDanoPorcentualPrimerAtaque(Personaje jugador)
    {
        
        if (jugador.ReduccionDanoPorcentualDictionary["primerAtaque"] > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño del primer ataque del rival en un {Math.Truncate(jugador.ReduccionDanoPorcentualDictionary["primerAtaque"] * 100)}%");
        }
    }
    private void printReduccionDanoPorcentualFollowUp(Personaje jugador)
    {

        if (jugador.ReduccionDanoPorcentualDictionary["followUp"] > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño del Follow-Up del rival en un {Math.Truncate(jugador.ReduccionDanoPorcentualDictionary["followUp"] * 100)}%");
        }
    }
    private void printDanoExtraPrimerAtaque(Personaje jugador)
    {
        if (jugador.DanoAdicionalDictionary["primerAtaque"] != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +{jugador.DanoAdicionalDictionary["primerAtaque"]} daño extra en su primer ataque");
        }
    }
    private void printDanoExtraFollowUp(Personaje jugador)
    {
        if (jugador.DanoAdicionalDictionary["followUp"] != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +{jugador.DanoAdicionalDictionary["followUp"]} daño extra en su Follow-Up");
        }
    }
}