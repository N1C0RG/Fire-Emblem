namespace Fire_Emblem;
using System.Text.Json;
public class ManejoArchivos
{
    private LectorDeArchivo _leactorDeArchivo;
    private ConstructorDeEquipo _constructorDeEquipo;
    private ManejadorDeEquipo _manejadorDeEquipo;
    private DeserializadorJson _deserializadorJson;

    public ManejoArchivos(string carpetaEquipo, string archivoSeleccionado)
    {
        _leactorDeArchivo = new LectorDeArchivo(carpetaEquipo, archivoSeleccionado);
        _constructorDeEquipo = new ConstructorDeEquipo();
        _manejadorDeEquipo = new ManejadorDeEquipo();
        _deserializadorJson = new DeserializadorJson();
    }

    public void guardarEquipo()
    {
        var lineasArchivo = _leactorDeArchivo.leerArchivo();
        _manejadorDeEquipo.guardarEquipos(lineasArchivo);
    }

    public List<Personaje> crearEquipo(bool esEquipoDelJugador)
    {
        var dataEquipo = esEquipoDelJugador ? _manejadorDeEquipo.getEquipoJugador()
            : _manejadorDeEquipo.getEquipoRival();
        return _constructorDeEquipo.crearEquipo(_deserializadorJson.LoadJsonCharacter(), dataEquipo);
    }
}





