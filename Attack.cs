using PokemonSimulator.Enums;
namespace PokemonSimulator;

public class Attack(string name, ElementalType element, int basepower)
{
    public string Name { get; } = name;
    public ElementalType Element { get; } = element;
    public int BasePower { get; } = basepower;

    public void Use(int level)
    {
        Console.WriteLine($"{Name} hits with total power {BasePower + level}!");
    }
}
