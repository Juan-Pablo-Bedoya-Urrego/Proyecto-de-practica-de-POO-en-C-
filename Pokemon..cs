using System.Reflection.Metadata;
public interface IPokemon{
    int Ataque();
    int Defensa();
}

public class Pokemon:IPokemon{
    private Random r = new Random();
    private String nombrePokemon{get; set;}
    private String tipoPokemon{get; set;}
    private int saludPokemon{get; set;}

    private List<int> AtaquesPokemon{get; set;} = new List<int>();
    private List<int> DefensasPokemon{get; set;} = new List<int>();

    public Pokemon (String Nombre, String Tipo, int Salud){
        this.nombrePokemon = Nombre;
        this.tipoPokemon = Tipo;
        this.saludPokemon = Salud;

        for(int i = 0; i < 3; i++){
            AtaquesPokemon.Add(r.Next(0,40));
        }
        for(int i = 0; i < 3; i++){
            DefensasPokemon.Add(r.Next(10,35));
        }
    }
    public int Ataque(){
        int ataque = AtaquesPokemon[r.Next(0, 3)];
        double multiplicadorDaño = r.NextDouble() < 0.5 ? 1 : 1.5; // 50% probabilidad de 1, 50% de 1.5

        return (int)(ataque * multiplicadorDaño);
    }

    public int Defensa(){
        int defensa = DefensasPokemon[r.Next(0, 2)];
        double multiplicadorDefensa = r.NextDouble() < 0.5 ? 1 : 0.5;
        return (int)(defensa * multiplicadorDefensa);
    }

    public void mostrarAtaquesBase(){
        foreach(int At in AtaquesPokemon){
            Console.WriteLine($"Ataque Base: {At}");
        }
        foreach(int Df in DefensasPokemon){
            Console.WriteLine($"Defensa Base: {Df}");
        }
    }

    public void SetSalud(int Salud){
        saludPokemon = Salud;
    }

    public String GetNombre(){
        return nombrePokemon;
    }

    public int GetSalud(){
        return saludPokemon;
    }

    public void RecibirAtaque(int ataqueRecibido)
    {
        int defensaAtaque = Defensa();
        Console.WriteLine($"Ataque recibido por {nombrePokemon} es de {ataqueRecibido} y su defensa de {defensaAtaque}");
        if (defensaAtaque >= ataqueRecibido)
        {
            Console.WriteLine($"{nombrePokemon} ha resistido el ataque!");
        }
        else
        {
            int diferencia = Math.Max(0,ataqueRecibido - defensaAtaque);
            int nuevaSalud = saludPokemon - diferencia;
            SetSalud(nuevaSalud);
            Console.WriteLine($"{nombrePokemon} ha recibido {diferencia} puntos de daño!");
        }
    }
}