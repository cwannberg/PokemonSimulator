
using PokemonSimulator.Enums;

namespace PokemonSimulator;

class AttackHandler
{
    public static List<Attack> GetAttacks(ElementalType type)
    {
        return type switch
        {
            ElementalType.Fire => FireAttacks(),
            ElementalType.Water => WaterAttacks(),
            ElementalType.Electric => ElectricAttacks(),
            ElementalType.Grass => GrassAttacks(),
            _ => new List<Attack>()
        };
    }

    public static List<Attack> FireAttacks()
    {
        var flamethrower = new Attack("Flamethrower", ElementalType.Fire, 12);
        var ember = new Attack("Ember", ElementalType.Fire, 6);
        return new List<Attack> { flamethrower, ember };
    }
    public static List<Attack> WaterAttacks()
    {
        var staticParalyze = new Attack("Static paralyze", ElementalType.Electric, 4);
        var lightning = new Attack("Lightning", ElementalType.Electric, 16);
        return new List<Attack> { staticParalyze, lightning };
    }
    public static List<Attack> ElectricAttacks()
    {
        var staticParalyze = new Attack("Static paralyze", ElementalType.Electric, 4);
        var lightning = new Attack("Lightning", ElementalType.Electric, 16);
        return new List<Attack> { staticParalyze, lightning };
    }
    public static List<Attack> GrassAttacks()
    {
        var tackle = new Attack("Tackle", ElementalType.Grass, 5);
        var vineWhip = new Attack("Vine whip", ElementalType.Grass, 15);
        return new List<Attack> { tackle, vineWhip };
    }
}
