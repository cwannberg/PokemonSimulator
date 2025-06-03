using PokemonSimulator.Enums;
using PokemonSimulator.Interface;
using PokemonSimulator.Models;

namespace PokemonSimulator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            InitiatePokemons();
        }

        public static void InitiatePokemons()
        {
            var flamethrower = new Attack("Flamethrower", ElementalType.Fire, 12);
            var ember = new Attack("Ember", ElementalType.Fire, 6);

            var torrent = new Attack("Torrent", ElementalType.Water, 10);
            var splash = new Attack("Splash", ElementalType.Water, 8);

            var staticParalyze = new Attack("StaticParalyze", ElementalType.Electric, 4);
            var lightning = new Attack("Lightning", ElementalType.Electric, 16);

            List<Attack> charmanderAttacks = new List<Attack>() { flamethrower, ember };
            List<Attack> squirtleAttacks = new List<Attack>() { torrent, splash };
            List<Attack> pikachuAttacks = new List<Attack>() { staticParalyze, lightning };           

            Charmander charmander = new(4, charmanderAttacks);
            Squirtle squirtle = new(5, squirtleAttacks);
            Pikachu pikachu = new(8, pikachuAttacks);

            Fight(charmander, charmanderAttacks);
            EvolvePokemon(pikachu);
            EvolvePokemon(squirtle);
        }

        public static void Fight(Pokemon pokemon, List<Attack> attacks)
        {
            pokemon.GetAttack(attacks);
        }

        public static void EvolvePokemon(Pokemon pokemon) {
            if (pokemon is IEvolvable evolvable)
            {
                evolvable.Evolve();
            }
            else
            {
                Console.WriteLine($"{pokemon.Name} can't evolve");
            }
        }
    }
}
