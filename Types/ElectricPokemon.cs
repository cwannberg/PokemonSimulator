using PokemonSimulator.Enums;
using PokemonSimulator.Pokemons;

namespace PokemonSimulator.Types;

class ElectricPokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Electric, level, attacks){
}
