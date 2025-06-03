using PokemonSimulator.Enums;

namespace PokemonSimulator.Types;

class WaterPokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Water, level, attacks){} 
