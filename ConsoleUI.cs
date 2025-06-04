using PokemonSimulator.Enums;
using PokemonSimulator.Handlers;
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
            Console.WriteLine("3. Add a new pokemon");
            Console.WriteLine("4. Exit application");
            Console.WriteLine("Enter a number 1-4: ");
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
                        AddNewPokemon();
                        break;
                    case 4:
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
    public static void AddNewPokemon()
    {
        try
        {
            Console.WriteLine("Add new pokemon");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            name = InputHandler.ReadValidatedString("Name: ", lettersOnly: true);
            Console.WriteLine("Level: ");
            int level = int.Parse(Console.ReadLine());
            level = InputHandler.ReadValidatedInt("Level: ", min: 1, max: 100); 
            Console.WriteLine("Elemental type: ");
            string type = Console.ReadLine().ToLower();
            type = InputHandler.ReadValidatedString("Elemental type: ", lettersOnly: true).ToLower();


            ElementalType elType;
            if (type.Equals("fire"))
            {
                elType = ElementalType.Fire;
            }
            else if (type.Equals("water"))
            {
                elType = ElementalType.Water;
            }
            else if (type.Equals("electric"))
            {
                elType = ElementalType.Electric;
            }
            else if (type.Equals("grass"))
            {
                elType = ElementalType.Grass;
            }
        }
        catch
        {
            Console.WriteLine($"Invalid input");
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

