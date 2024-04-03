using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        //se pide que se ingresen los valores del primer pokemon
        Console.WriteLine("=============Ingrese los datos del primer Pokemon================");
        Console.Write("Ingrese el nombre del pokemon: ");
        String NombrePokemon = Console.ReadLine();
        Console.Write("Ingrese el tipo del pokemon: ");
        String TipoPokemon = Console.ReadLine();
        Console.Write("Ingrese la salud del pokemon: ");
        int SaludPokemon = int.Parse(Console.ReadLine());
        Pokemon pokemon1 = new Pokemon(NombrePokemon, TipoPokemon, SaludPokemon);
        //se pide que se ingresen los valores del segundo pokemon
        Console.WriteLine("=============Ingrese los datos del segundo Pokemon================");
        Console.Write("Ingrese el nombre del pokemon: ");
        String NombrePokemon2 = Console.ReadLine();
        Console.Write("Ingrese el tipo del pokemon: ");
        String TipoPokemon2 = Console.ReadLine();
        Console.Write("Ingrese la salud del pokemon: ");
        int SaludPokemon2 = int.Parse(Console.ReadLine());
        Pokemon pokemon2 = new Pokemon(NombrePokemon2, TipoPokemon2, SaludPokemon2);
        Console.WriteLine("");
        /*se simula la batalla en la cual en una variable se guarda el valor que retorna el metodo ataque para
        posteriormente pasar este valor al metodo recibirataque en los parametros y asi poder realizar los
        calculos para poder descontar o no salud*/
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"*********Round-{i + 1}*********");
            int ataquePokemon1 = pokemon1.Ataque();
            int ataquePokemon2 = pokemon2.Ataque();

            Console.WriteLine($"{pokemon1.GetNombre()} ataca a {pokemon2.GetNombre()}!");
            pokemon2.RecibirAtaque(ataquePokemon1);

            Console.WriteLine($"{pokemon2.GetNombre()} ataca a {pokemon1.GetNombre()}!");
            pokemon1.RecibirAtaque(ataquePokemon2);
        }
        /*Finalmente despues de los 3 rounds se compara la salud para determinar cual de los dos pokemones
        Es el ganador*/
        Console.WriteLine("**********************El Ganador es**********************");
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

        Random r = new Random();
        List<Jugador> xxx = new List<Jugador>();
        Jugador one = new Jugador("Andres");
        Jugador two = new Jugador("Juan");
        Jugador three = new Jugador("Lebron");
        Jugador four = new Jugador("Ana");
        Jugador five = new Jugador("Mariana");
        Jugador six = new Jugador("Cecho");
        Equipos equipoOne = new Equipos("Los inseparables");
        Equipos equipoTwo = new Equipos("Los encatados");


        xxx.Add(one);
        xxx.Add(two);
        xxx.Add(three);
        xxx.Add(four);
        xxx.Add(five);
        xxx.Add(six);

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Ingrese que desea realizar [Seleccion, Partido, Salir]");
            string accion = Console.ReadLine();
            switch (accion)
            {
                case "Seleccion":
                    int contador = xxx.Count;

                    while (contador != 0)
                    {
                        if (contador % 2 == 0) // Asignar jugadores a los equipos alternativamente
                        {
                            int seleccionador = r.Next(0, xxx.Count);
                            equipoOne.agregarJugadores(xxx[seleccionador]);
                            xxx.RemoveAt(seleccionador);
                        }
                        else
                        {
                            int seleccionador = r.Next(0, xxx.Count);
                            equipoTwo.agregarJugadores(xxx[seleccionador]);
                            xxx.RemoveAt(seleccionador);
                        }
                        contador = xxx.Count;
                    }
                    Console.WriteLine("Seleccion realizada");
                    break;
                case "Partido":
                    int rendimientoEquipoOne = equipoOne.calcularRendimiento();
                    int rendimientoEquipoTwo = equipoTwo.calcularRendimiento();

                    if (rendimientoEquipoOne > rendimientoEquipoTwo)
                    {
                        Console.WriteLine($"El equipo ganador es: {equipoOne.getNombreEquipo()} con un rendimiento de: {rendimientoEquipoOne}");

                    }
                    else if (rendimientoEquipoOne < rendimientoEquipoTwo)
                    {
                        Console.WriteLine($"El equipo ganador es: {equipoTwo.getNombreEquipo()} con un rendimiento de: {rendimientoEquipoTwo}");
                    }
                    else
                    {
                        Console.WriteLine("Empate");
                    }
                    break;
                case "Salir":
                    salir = true;
                    break;
            }
        }
    }
}