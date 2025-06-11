using PokemonSimulator.Enums;
using PokemonSimulator.Handlers;
using PokemonSimulator.Pokemons;
using System.Diagnostics;

namespace PokemonSimulator;

class ConsoleUI
{

    public static void Menu()
    {
        bool continueMenu = true;

        do
        {
            Console.WriteLine("** Menu options **");
            Console.WriteLine("1. View pokemoncollection");
            Console.WriteLine("2. Fight");
            Console.WriteLine("3. Exit application");
            Console.WriteLine("Enter a number 1-3: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        DisplayPokemonCollection();
                        break;
                    case 2:
                        PokemonChoiceMenu();
                        break;
                    case 3:
                        continueMenu = false;
                        break;
                    default:
                        break;
                }
            } catch(FormatException fx)
            {
                Console.WriteLine($"Invalid input. Please enter a number.");
            }
        } while (continueMenu);
    }

    public static void DisplayPokemonCollection()
    {
        foreach(Pokemon pokemon in PokemonHandler.CatchPokemons())
        {
            Console.WriteLine($"Name: {pokemon.Name} " +
                              $"Level: {pokemon.Level} " +
                              $"Type: {pokemon.Elemental}");
        }
    }
    
    public static void PokemonChoiceMenu()
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

                pokemon.Fight(pokemon);
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

