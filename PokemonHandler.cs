using PokemonSimulator.Enums;
using PokemonSimulator.Interface;
using PokemonSimulator.Models;

namespace PokemonSimulator;

public static class PokemonHandler
{
    public static List<Pokemon> CatchPokemons()
    {
        Charmander charmander = new(4, AttackHandler.GetAttacks(ElementalType.Fire));
        Squirtle squirtle = new(5, AttackHandler.GetAttacks(ElementalType.Water));
        Pikachu pikachu = new(8, AttackHandler.GetAttacks(ElementalType.Electric));
        Bulbasaur bulbasaur = new(2, AttackHandler.GetAttacks(ElementalType.Grass));

        List<Pokemon> pokemonList = new List<Pokemon> { charmander, squirtle, pikachu, bulbasaur };

        return pokemonList;
    }
    public static void EvolvePokemon(Pokemon pokemon)
    {
        if (pokemon is IEvolvable evolvable)
        {
            evolvable.Evolve();
        }
    }
    public static Pokemon GetPokemon(int index, List<Pokemon>? pokemonList)
    {
        Pokemon pokemon = pokemonList[index];
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
}
