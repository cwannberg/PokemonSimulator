using PokemonSimulator.Enums;
using PokemonSimulator.Pokemons;

namespace PokemonSimulator.Types;
class FirePokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Fire, level, attacks){}
