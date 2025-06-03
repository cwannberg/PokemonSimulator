using PokemonSimulator.Enums;

namespace PokemonSimulator.Types;
class FirePokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Fire, level, attacks){}
