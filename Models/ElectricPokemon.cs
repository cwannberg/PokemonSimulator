using PokemonSimulator.Enums;

namespace PokemonSimulator.Models;

class ElectricPokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Electric, level, attacks){}
