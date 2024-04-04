public interface IEquipos
{
    void listarJugadores(Jugador juga);
    int totalRendimiento();
}
public class Equipos : IEquipos
{

    private string nombreEquipo { get; set; }
    public List<Jugador> jugadoresEquipo = new List<Jugador>();
    private int totalRendimientoEquipo { get; set; }

    public Equipos(string nombreEquipo)
    {
        this.nombreEquipo = nombreEquipo;
        this.totalRendimientoEquipo = 0;
    }

    public string getNombreEquipo()
    {
        return this.nombreEquipo;
    }

    public void listarJugadores(Jugador juga)
    {
        jugadoresEquipo.Add(juga);
    }

    public int totalRendimiento()
    {
        int sumaRendimiento = 0;
        foreach (Jugador ren in jugadoresEquipo)
        {
            sumaRendimiento += ren.getRendimiento();
        }
        return sumaRendimiento;
    }
}