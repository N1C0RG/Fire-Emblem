using Fire_Emblem.ExcepcionesJuego;

namespace Fire_Emblem;
using System.Text.Json;
public class LectorDeArchivo
{
    private string _carpetaEquipo;
    private string _archivoSeleccionado;

    public LectorDeArchivo(string carpetaEquipo, string archivoSeleccionado)
    {
        _carpetaEquipo = carpetaEquipo;
        _archivoSeleccionado = archivoSeleccionado;
    }

    public string[] leerArchivo()
    {
        try
        {
            string numeroArchivo = _archivoSeleccionado.PadLeft(3, '0');
            var pathCompleto = Directory.GetFiles(_carpetaEquipo)
                .FirstOrDefault(file => Path.GetFileName(file).Contains(numeroArchivo));
            
            if (pathCompleto == null)
            {
                throw new ExcepcionArchivoInvalido();
            }

            return File.ReadAllLines(pathCompleto); 
        } 
        catch ( Exception e)
        {
            throw new ExceptionErrorLeerArchivo(); 
        }
    }
}
