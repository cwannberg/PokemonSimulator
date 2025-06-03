namespace PokemonSimulator;

class ConsoleUI
{

    public static void Menu()
    {
        List<Pokemon> pokemonList = PokemonHandler.CatchPokemons();
        bool continueMenu = true;
        while (continueMenu)
        {
            Console.WriteLine("Pick your pokemon to fight:");
            Console.WriteLine("1. Charmander");
            Console.WriteLine("2. Squirtle");
            Console.WriteLine("3. Pikachu");
            Console.WriteLine("4. Bulbasaur");
            Console.WriteLine("Enter a number 1-4: ");
            int input = int.Parse(Console.ReadLine());

            if (input >= 1 && input <= 4)
            {
                Pokemon pokemon = PokemonHandler.GetPokemon(input - 1, pokemonList);

                Pokemon.Fight(pokemon);
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 4.");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
}

