using PokemonSimulator.Enums;
using PokemonSimulator.Interface;
using PokemonSimulator.Models;
using System.Collections.Concurrent;

namespace PokemonSimulator
{
    internal class Program
    {
        public static List<Pokemon>? _pokemonList;
        static void Main(string[] args)
        {
            CreatePokemons();
            Menu();
        }

        private static void Menu()
        {
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
                    Pokemon pokemon = GetPokemon(input - 1);

                    Fight(pokemon);
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please enter a number between 1 and 4.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }
        } 

        private static void Fight(Pokemon pokemon)
        {
            Console.WriteLine("Press ESC to stop fighting");
            while (true)
            {
                if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Fight ended");
                    break;
                }
                Attack(pokemon);
            }
            Menu();
        }
        private static Pokemon GetPokemon(int index)
        {
            Pokemon pokemon = _pokemonList[index];
            Console.WriteLine($"The pokemon you chose is {pokemon.Name}. A level {pokemon.Level} {pokemon.Elemental.ToString().ToLower()}type.");
            if (pokemon is IEvolvable evolvable)
            {
                Console.WriteLine("This pokemon is evolveable!");
                Console.WriteLine($"Would you like to evolve {pokemon.Name}? yes/no");
                string answer = Console.ReadLine().ToLower();
                if (answer.Equals("yes"))
                {
                    EvolvePokemon(pokemon);
                }
            }
            return pokemon;
        }
        private static void CreatePokemons()
        {
            Charmander charmander = new(4, CreateAttacks(ElementalType.Fire));
            Squirtle squirtle = new(5, CreateAttacks(ElementalType.Water));
            Pikachu pikachu = new(8, CreateAttacks(ElementalType.Electric));
            Bulbasaur bulbasaur = new(2, CreateAttacks(ElementalType.Grass));

            _pokemonList = new List<Pokemon> { charmander, squirtle, pikachu, bulbasaur };
        }
        private static List<Attack> CreateAttacks(ElementalType type)
        {
            if (type == ElementalType.Fire)
            {
                var flamethrower = new Attack("Flamethrower", ElementalType.Fire, 12);
                var ember = new Attack("Ember", ElementalType.Fire, 6);
                return new List<Attack> { flamethrower, ember };
            }
            else if (type == ElementalType.Water)
            {
                var torrent = new Attack("Torrent", ElementalType.Water, 10);
                var splash = new Attack("Splash", ElementalType.Water, 8);
                return new List<Attack> { torrent, splash };
            }
            else if (type == ElementalType.Electric)
            {
                var staticParalyze = new Attack("Static paralyze", ElementalType.Electric, 4);
                var lightning = new Attack("Lightning", ElementalType.Electric, 16);
                return new List<Attack> { staticParalyze, lightning };
            }
            else if (type == ElementalType.Grass)
            {
                var tackle = new Attack("Tackle", ElementalType.Grass, 5);
                var vineWhip = new Attack("Vine whip", ElementalType.Grass, 15);
                return new List<Attack> { tackle, vineWhip };
            }
            else
            {
                return new List<Attack> { };
            }
        }


        public static void Attack(Pokemon pokemon)
        {
            pokemon.GetAttack(pokemon.Attacks);
            pokemon.RaiseLevel();
        }

        public static void EvolvePokemon(Pokemon pokemon) {
            if (pokemon is IEvolvable evolvable)
            {
                evolvable.Evolve();
            }
        }
    }
}
