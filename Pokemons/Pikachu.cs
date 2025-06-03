using PokemonSimulator.Interface;
using PokemonSimulator.Types;

namespace PokemonSimulator.Models;

class Pikachu : ElectricPokemon, IEvolvable{
    public Pikachu(int level, List<Attack> attacks)
       : base("Pikachu", level, attacks) { }


    public void Evolve()
    {
        string oldName = Name;
        Name = "Raichu";
        Level += 10;

        Console.WriteLine($"{oldName} is evolving... Now it's {Name}! Level {Level}!");
    }
}