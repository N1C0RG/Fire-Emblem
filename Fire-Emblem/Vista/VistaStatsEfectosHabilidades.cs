using Fire_Emblem.Encapsulado;
using Fire_Emblem.EnumVariables;
using Fire_Emblem.Habilidades;

namespace Fire_Emblem.Vista;
using Fire_Emblem_View;
using NombreDiccionario = Fire_Emblem.NombreDiccionario;
public class VistaStatsEfectosHabilidades
{
    private readonly View _view;

    public VistaStatsEfectosHabilidades(View view)
    {
        _view = view;
    }
    public void printTodoBonusPenaltyNeutralizaciones(Personaje jugador, Personaje rival)
    {
        printJugadorBonus(jugador);
        primerAtaqueBonus(jugador);
        printFollowUpBonus(jugador);
        
        printJugadorPenalty(jugador);
        primerAtaquePenalty(jugador);
        printFollowUpPenalty(jugador);
        
        printBonusPenaltyNeutralizados(jugador);
        
        printDanoExtra(jugador);
        printDanoExtraPrimerAtaque(jugador);
        printDanoExtraFollowUp(jugador);
        
        printReduccionDanoPorcentual(jugador); 
        printReduccionDanoPorcentualPrimerAtaque(jugador); 
        printReduccionDanoPorcentualFollowUp(jugador);
        
        printReduccionDanoAbsoluto(jugador);
        
        printJugadorBonus(rival);
        primerAtaqueBonus(rival);
        printFollowUpBonus(rival);
        
        printJugadorPenalty(rival);
        primerAtaquePenalty(rival);
        printFollowUpPenalty(rival);
        
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
        foreach (var stat in 
                 jugador.getSpecificDyctionaryDataHabilidadStat(NombreDiccionario.bonusStats.ToString()))
        {
            printBonusPenalty(jugador, stat, stat.Value > 0 ? "+" : "");
        }
    }
    private void printJugadorPenalty(Personaje jugador)
    {
        foreach (var stat in 
                 jugador.getSpecificDyctionaryDataHabilidadStat(NombreDiccionario.penaltyStats.ToString())) 
        {
            if (stat.Value < 0)
            {
                printBonusPenalty(jugador, stat, "");
            }
        }
    }

    private void printBonusPenalty(Personaje jugador, KeyValuePair<string, int> stat, string sign)
    {
        var mensaje = $"{jugador.name} obtiene {stat.Key}{sign}{stat.Value}";

        _view.WriteLine(mensaje);
    }

    private void primerAtaqueBonus(Personaje jugador)
    {
        foreach (var i in jugador.getSpecificDyctionaryDataHabilidadStat(
                     NombreDiccionario.primerAtaqueBonus.ToString()))
        {
            _view.WriteLine($"{jugador.name} obtiene {i.Key}+{i.Value} en su primer ataque");
        }
    }
    private void primerAtaquePenalty(Personaje jugador)
    {
        foreach (var i in jugador.getSpecificDyctionaryDataHabilidadStat(
                     NombreDiccionario.primerAtaquePenalty.ToString()))
        {
            _view.WriteLine($"{jugador.name} obtiene {i.Key}{i.Value} en su primer ataque");
        }
    }
    
    private void printBonusPenaltyNeutralizados(Personaje jugador)
    {  
        foreach (var bonus in
                 jugador.getSpecificArrayDataHabilidadStat(
                     NombreDiccionario.bonusNeutralizados.ToString()))
        {
            _view.WriteLine($"Los bonus de {bonus} de {jugador.name} fueron neutralizados");
        }

        foreach (var penalty in 
                 jugador.getSpecificArrayDataHabilidadStat(
                     NombreDiccionario.penaltyNeutralizados.ToString()))
        {
            _view.WriteLine($"Los penalty de {penalty} de {jugador.name} fueron neutralizados");
        }
    }
    private void printFollowUpPenalty(Personaje jugador)
    {
        foreach (var i in jugador.getSpecificDyctionaryDataHabilidadStat(
                     NombreDiccionario.followPenalty.ToString()))
        {
            if (i.Value != 0)
            { 
                _view.WriteLine($"{jugador.name} obtiene {i.Key}{i.Value} en su Follow-Up");
            }

        }
    }
    private void printFollowUpBonus(Personaje jugador)
    {
        foreach (var i in jugador.getSpecificDyctionaryDataHabilidadStat(
                     NombreDiccionario.followBonus.ToString()))
        {
            if (i.Value != 0)
            { 
                _view.WriteLine($"{jugador.name} obtiene {i.Key}+{i.Value} en su Follow-Up");
            }
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
        if (jugador.getDataReduccionExtraStat<int>(NombreDiccionario.danoAdicional.ToString(),
                Llave.todosAtaques.ToString()) != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +" +
                            $"{jugador.getDataReduccionExtraStat<int>(
                                NombreDiccionario.danoAdicional.ToString(), 
                                Llave.todosAtaques.ToString())} daño extra en cada ataque");
        }
    }
    private void printReduccionDanoPorcentual(Personaje jugador)
    {
        if (jugador.getDataReduccionExtraStat<decimal>(NombreDiccionario.reduccionPorcentual.ToString(),
                Llave.todosAtaques.ToString()) > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño de los ataques del rival en un " +
                            $"{Math.Round(jugador.getDataReduccionExtraStat<decimal>(
                                NombreDiccionario.reduccionPorcentual.ToString(),
                                Llave.todosAtaques.ToString()) * 100)}%");
        }
    }
    private void printReduccionDanoPorcentualPrimerAtaque(Personaje jugador)
    {
        
        if (jugador.getDataReduccionExtraStat<decimal>(NombreDiccionario.reduccionPorcentual.ToString(),
                Llave.primerAtaque.ToString()) > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño del primer ataque del rival en un " +
                            $"{Math.Round(jugador.getDataReduccionExtraStat<decimal>(
                                NombreDiccionario.reduccionPorcentual.ToString(),
                                Llave.primerAtaque.ToString()) * 100)}%");
        }
    }
    private void printReduccionDanoPorcentualFollowUp(Personaje jugador)
    {

        if (jugador.getDataReduccionExtraStat<decimal>(NombreDiccionario.reduccionPorcentual.ToString(), 
                Llave.followUp.ToString()) > 0)
        {
            _view.WriteLine($"{jugador.name} reducirá el daño del Follow-Up del rival en un" +
                            $" {Math.Round(jugador.getDataReduccionExtraStat<decimal>(
                                NombreDiccionario.reduccionPorcentual.ToString(), 
                                Llave.followUp.ToString()) * 100)}%");
        }
    }
    private void printDanoExtraPrimerAtaque(Personaje jugador)
    {
        if (jugador.getDataReduccionExtraStat<int>(NombreDiccionario.danoAdicional.ToString(),
                Llave.primerAtaque.ToString()) != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +" +
                            $"{jugador.getDataReduccionExtraStat<int>(
                                NombreDiccionario.danoAdicional.ToString(), 
                                Llave.primerAtaque.ToString())} daño extra en su primer ataque");
        }
    }
    private void printDanoExtraFollowUp(Personaje jugador)
    {
        if (jugador.getDataReduccionExtraStat<int>(NombreDiccionario.danoAdicional.ToString(), 
                Llave.followUp.ToString()) != 0)
        {
            _view.WriteLine($"{jugador.name} realizará +{jugador.getDataReduccionExtraStat<int>(
                NombreDiccionario.danoAdicional.ToString(), 
                Llave.followUp.ToString())} daño extra en su Follow-Up");
        }
    }
}
