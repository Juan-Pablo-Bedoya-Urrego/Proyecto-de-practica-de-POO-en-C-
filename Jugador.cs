using System.Data;
using System.Security.Cryptography.X509Certificates;

public class Jugador
{
    private Random r = new Random();
    private string nombre { get; set; }
    private int rendimiento { get; set; }

    public Jugador(string nombre)
    {
        this.nombre = nombre;
        this.rendimiento = r.Next(1, 10);
    }

    public int getRendimiento()
    {
        return this.rendimiento;
    }
}