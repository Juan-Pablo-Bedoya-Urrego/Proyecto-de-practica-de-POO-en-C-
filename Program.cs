using System.Net.Mail;

class Program{
    static void Main(string[] args){
        //se pide que se ingresen los valores del primer pokemon
        Console.WriteLine("=============Ingrese los datos del primer Pokemon================");
        Console.Write("Ingrese el nombre del pokemon: ");
        String NombrePokemon = Console.ReadLine();
        Console.Write("Ingrese el tipo del pokemon: ");
        String TipoPokemon = Console.ReadLine();
        Console.Write("Ingrese la salud del pokemon: ");
        int SaludPokemon = int.Parse(Console.ReadLine());
        Pokemon pokemon1 = new Pokemon(NombrePokemon,TipoPokemon,SaludPokemon);
        //se pide que se ingresen los valores del segundo pokemon
        Console.WriteLine("=============Ingrese los datos del segundo Pokemon================");
        Console.Write("Ingrese el nombre del pokemon: ");
        String NombrePokemon2 = Console.ReadLine();
        Console.Write("Ingrese el tipo del pokemon: ");
        String TipoPokemon2 = Console.ReadLine();
        Console.Write("Ingrese la salud del pokemon: ");
        int SaludPokemon2 = int.Parse(Console.ReadLine());
        Pokemon pokemon2 = new Pokemon(NombrePokemon2,TipoPokemon2,SaludPokemon2);
        Console.WriteLine("");
        /*se simula la batalla en la cual en una variable se guarda el valor que retorna el metodo ataque para
        posteriormente pasar este valor al metodo recibirataque en los parametros y asi poder realizar los
        calculos para poder descontar o no salud*/
        for(int i = 0; i < 3; i++){
            Console.WriteLine($"*********Round-{i+1}*********");
            int ataquePokemon1 = pokemon1.Ataque();
            int ataquePokemon2 = pokemon2.Ataque();

            Console.WriteLine($"{pokemon1.GetNombre()} ataca a {pokemon2.GetNombre()}!");
            pokemon2.RecibirAtaque(ataquePokemon1);

            Console.WriteLine($"{pokemon2.GetNombre()} ataca a {pokemon1.GetNombre()}!");
            pokemon1.RecibirAtaque(ataquePokemon2);
        }
        /*Finalmente despues de los 3 rounds se compara la salud para determinar cual de los dos pokemones
        Es el ganador*/
        if (pokemon1.GetSalud() > pokemon2.GetSalud())
        {
            Console.WriteLine($"Gana {pokemon1.GetNombre()}! con {pokemon1.GetSalud()} puntos de vida");
        }
        else if (pokemon1.GetSalud() < pokemon2.GetSalud())
        {
            Console.WriteLine($"Gana {pokemon2.GetNombre()}! con {pokemon2.GetSalud()} puntos de vida");
        }
        else
        {
            Console.WriteLine("¡Empate!");
        }
    }
}