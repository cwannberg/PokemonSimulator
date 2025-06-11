using PokemonSimulator.Enums;
using PokemonSimulator.Pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSimulator.Types
{
    class GrassPokemon(string name, int level, List<Attack> attacks) : Pokemon(name, ElementalType.Grass, level, attacks)
    {
    }
}
