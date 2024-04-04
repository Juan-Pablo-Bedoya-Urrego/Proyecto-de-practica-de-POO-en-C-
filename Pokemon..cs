using System.Reflection.Metadata;
//Declaro la interfaz con las metodos que debe llevar
public interface IPokemon
{
    int Ataque();
    int Defensa();
}

//La clase Pokemon con la interfaz que declare anteriormente
public class Pokemon : IPokemon
{
    /*Los atratibutos que va a llegar esta clase, las listas son para guardar los ataques y las defensas que
    debe tener cada objeto que se instancia de esta clase*/
    private Random r = new Random();
    private String nombrePokemon { get; set; }
    private String tipoPokemon { get; set; }
    private int saludPokemon { get; set; }

    private List<int> AtaquesPokemon { get; set; } = new List<int>();
    private List<int> DefensasPokemon { get; set; } = new List<int>();
    //El constructor de esta clase en el que se inicializa cada uno de sus atributos
    public Pokemon(String Nombre, String Tipo, int Salud)
    {
        this.nombrePokemon = Nombre;
        this.tipoPokemon = Tipo;
        this.saludPokemon = Salud;
        //Aqui se guarda los ataques con un valor entero desde 0 a 40
        for (int i = 0; i < 3; i++)
        {
            AtaquesPokemon.Add(r.Next(0, 40));
        }
        //y aqui se guardan las defensas 
        for (int i = 0; i < 3; i++)
        {
            DefensasPokemon.Add(r.Next(10, 35));
        }
    }
    /*el metodo ataque en el cual de la lista de ataques se escoje de manera aleatorio un ataque de esta lista 
    y depues se multiplica por un valor que puede ser 1 o 1.5 esto se hace dejando que la probalidad que toque
    uno o el otro sea del 50% y despues se retorna de manera entera el valor del ataque multiplicado por este 
    valor*/
    public int Ataque()
    {
        int ataque = AtaquesPokemon[r.Next(0, 3)];
        double randomValue = r.NextDouble();
        double multiplicadorDaño;

        if (randomValue < 1.0 / 3.0)
        {
            multiplicadorDaño = 0;
        }
        else if (randomValue < 2.0 / 3.0)
        {
            multiplicadorDaño = 1;
        }
        else
        {
            multiplicadorDaño = 1.5;
        }

        return (int)(ataque * multiplicadorDaño);
    }
    //Lo mismo que el ataque ya que los valores del 50/50 ya son 0.5 o 1.0
    public int Defensa()
    {
        int defensa = DefensasPokemon[r.Next(0, 2)];
        double multiplicadorDefensa = r.NextDouble() < 0.5 ? 1 : 0.5;
        return (int)(defensa * multiplicadorDefensa);
    }
    //Este metodo se usa para poder ir modificando la salud de cada pokemon a medida que va a avanzado la pelea
    public void SetSalud(int Salud)
    {
        saludPokemon = Salud;
    }
    /*Este se usa para poder ver el valor que tiene el atribito nombrePokemon ya que no se puede acceder 
    directamente a este atributo por que es privado*/
    public String GetNombre()
    {
        return nombrePokemon;
    }
    //Lo mismo que el GetNombre
    public int GetSalud()
    {
        return saludPokemon;
    }
    /*Este metodo se usa para calcular el daño que recibe cada objeto y asi poder descontar esto de la salud 
    de ese objeto lo que se ase es rebicir como parametro el ataque que le causo el otro objetos a este 
    y con esto y la defensa mirar si la defensa es mayor que el ataque que recivio no se le descontara salud
    pero si el ataque es mayor que la defensa se decontara salud*/
    public int RecibirAtaque(int ataqueRecibido)
    {
        int defensaAtaque = Defensa();
        Console.WriteLine($"Ataque recibido por {nombrePokemon} es de {ataqueRecibido} y su defensa de {defensaAtaque}");
        if (defensaAtaque >= ataqueRecibido)
        {
            return defensaAtaque - ataqueRecibido;
        }
        else
        {
            int diferencia = Math.Max(0, ataqueRecibido - defensaAtaque);
            int nuevaSalud = saludPokemon - diferencia;
            SetSalud(nuevaSalud);
            Console.WriteLine($"{nombrePokemon} ha recibido {diferencia} puntos de daño y queda con {GetSalud()} puntos de vida");
            return 0;
        }
    }
}