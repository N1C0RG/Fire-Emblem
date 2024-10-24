using Fire_Emblem_View;
namespace Fire_Emblem.Habilidades;

public class ManejadorAplicadorHabilidad
{
    private Personaje _jugador;
    private Personaje _rival;

    public ManejadorAplicadorHabilidad(Personaje jugador, Personaje rival)
    {
        _jugador = jugador;
        _rival = rival;
    }

    public void aplicarHabilidades()
    {
        aplicarHabilidadesIndependientes(_jugador, _rival);
        aplicarHabilidadesIndependientes(_rival, _jugador);

        _jugador.dataHabilidadStats.calcularPostEfecto();
        _rival.dataHabilidadStats.calcularPostEfecto();

        aplicarHabilidadesDependientes(_jugador, _rival);
        aplicarHabilidadesDependientes(_rival, _jugador);
    }

    private void aplicarHabilidadesIndependientes(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadIndependienteStats(habilidad, jugador, rival);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
                aplicadorHabilidad.aplicarHabilidad();
            }
            catch { }
        }
    }

    private void aplicarHabilidadesDependientes(Personaje jugador, Personaje rival)
    {
        foreach (var habilidad in jugador.habilidades)
        {
            var fabricaHabilidad = new FabricaHabilidadesDependientesStats(habilidad, jugador, rival);
            try
            {
                fabricaHabilidad.crearHabilidad();
                var aplicadorHabilidad = fabricaHabilidad.crearAplicador();
                aplicadorHabilidad.aplicarHabilidad();
            }
            catch { }
        }
    }
}

