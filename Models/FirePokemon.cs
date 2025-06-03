using PokemonSimulator.Enums;


namespace PokemonSimulator.Models;
class FirePokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Fire, level, attacks){}
