namespace Fire_Emblem;

public class Validacion
{
    public bool ValidacionLargo(List<string> p1, List<string> p2)
    {
        if (p1.Count > 3 || p1.Count < 1 || p2.Count > 3 || p2.Count < 1)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
    public bool ValidacionRepetidosHabilidad(List<List<string>> player) 
    { 
        foreach (List<string> personaje in player)
        {
            if (personaje.Count > 2 && personaje[1] == personaje[2])
            {
                return false; 
            }
        }
        return true; 
    }
    
    public bool ValidacionRepetidosNombre(List<string> player) 
    {
        List<string> lista = new List<string>(); 
        foreach (string i in player)
        {
            if (i.Contains("("))
            {
                int startIndex = i.IndexOf('(') + 1;
                lista.Add(i.Substring(0, startIndex-2));
            }
            else
            {
                lista.Add(i);
            }
        }

        List<string> prueba = new List<string>(); 
        foreach (string s in lista) 
        {
            if (prueba.Contains(s))
            {
                return false; 
            }
            else
            {
                prueba.Add(s);
            }
        }
        return true; 
    }
    
    public bool ValidacionHabilidades(List<List<string>> player)
    {
        if (player[0].Count > 3)
        {
            return false; 
        }

        return true; 
    }

    public bool EquipoValido(List<List<string>> player1, List<List<string>> player2, List<string> p1, List<string> p2)
    {
        if (ValidacionLargo(p1, p2) == false || ValidacionRepetidosHabilidad(player1) == false
                                             || ValidacionRepetidosHabilidad(player2) == false
                                             || ValidacionHabilidades(player1) == false
                                             || ValidacionHabilidades(player2) == false
                                             || ValidacionRepetidosNombre(p1) == false
                                             || ValidacionRepetidosNombre(p2) == false)
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
}