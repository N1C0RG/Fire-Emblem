namespace Fire_Emblem;
using System.Text.Json;
public class ManejoArchivos
{
    private LectorDeArchivo _leactorDeArchivo;
    private ConstructorDeEquipo _constructorDeEquipo;
    private ManejadorDeEquipo _manejadorDeEquipo;

    public ManejoArchivos(string carpetaEquipo, string archivoSeleccionado)
    {
        _leactorDeArchivo = new LectorDeArchivo(carpetaEquipo, archivoSeleccionado);
        _constructorDeEquipo = new ConstructorDeEquipo();
        _manejadorDeEquipo = new ManejadorDeEquipo();
    }

    public void guardarEquipo()
    {
        var lineasArchivo = _leactorDeArchivo.leerArchivo();
        _manejadorDeEquipo.guardarEquipos(lineasArchivo);
    }

    public List<Personaje> crearEquipo(bool esEquipoDelJugador)
    {
        var dataEquipo = esEquipoDelJugador ? _manejadorDeEquipo.getPlayerTeam() : _manejadorDeEquipo.getRivalTeam();
        return _constructorDeEquipo.crearEquipo(_leactorDeArchivo.LoadJsonCharacter(), dataEquipo);
    }
}






