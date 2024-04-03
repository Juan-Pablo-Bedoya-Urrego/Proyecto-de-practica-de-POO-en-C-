using System.Data;
using System.Security.Cryptography.X509Certificates;

public class Jugador{
    private Random r = new Random();
    private string nombre {get;set;}
    private int rendimiento{get;set;}

    public Jugador(string nombre){
        this.nombre= nombre;
        this.rendimiento= r.Next(1,10);
    }

    public int getRendimiento(){
        return this.rendimiento;
    }
}

public interface IEquipos{
    void agregarJugadores(Jugador juga);
    int calcularRendimiento();
}
public class Equipos:IEquipos{
    
    private string nombreEquipo {get;set;}
    public List<Jugador> jugadoresEquipo= new List<Jugador>();
    private int totalRendimientoEquipo{get;set;}

    public Equipos(string nombreEquipo){
        this.nombreEquipo= nombreEquipo;
        this.totalRendimientoEquipo= 0;
    }

    public string getNombreEquipo(){
        return this.nombreEquipo;
    }
   
   public void agregarJugadores(Jugador juga){
        jugadoresEquipo.Add(juga);
   }

   public int calcularRendimiento(){
    int sumaRendimiento = 0;
    foreach(Jugador ren in jugadoresEquipo){
        sumaRendimiento += ren.getRendimiento();
    }
    return sumaRendimiento;
   }
}  


