using PokemonSimulator.Enums;
using PokemonSimulator.Models;

namespace PokemonSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var flamethrower = new Attack("Flamethrower", ElementalType.Fire, 12);
            var ember = new Attack("Ember", ElementalType.Fire, 6);

            var torrent = new Attack("Torrent", ElementalType.Water, 10);
            var splash = new Attack("Splash", ElementalType.Water, 8);

            var staticParalyze = new Attack("StaticParalyze", ElementalType.Electric, 4);
            var lightning = new Attack("Lightning", ElementalType.Electric, 16);

            List<Attack> charmanderAttacks = new List<Attack>() { flamethrower, ember };
            List<Attack> squirtleAttacks = new List<Attack>() { torrent, splash};
            List<Attack> pikachuAttacks = new List<Attack>() { staticParalyze, lightning };

            Charmander charmander = new(4, charmanderAttacks);
            Squirtle squirtle = new(5, squirtleAttacks);
            Pikachu pikachu = new(8, pikachuAttacks);;

            squirtle.GetAttack(squirtleAttacks);
            squirtle.RandomAttack();
            Console.WriteLine($"{squirtle.Name} is a level {squirtle.Level} {squirtle.Elemental} pokemon");
            Console.WriteLine($"{charmander.Name} is a level {charmander.Level} {charmander.Elemental} pokemon");
            Console.WriteLine($"{pikachu.Name} is a level {pikachu.Level} {pikachu.Elemental} pokemon");

            Console.WriteLine($"{squirtle.Name} is a level {squirtle.Level} {squirtle.Elemental} pokemon");
            for(int i= 0; i<squirtle.Attacks.Count; i++)
            {
                Console.WriteLine($"{squirtle.Name} attacks with {squirtle.Attacks[i].Name}");
                squirtle.RaiseLevel();
            }
        }
    }
}
