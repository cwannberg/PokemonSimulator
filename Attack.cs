using PokemonSimulator.Enums;
namespace PokemonSimulator;

public class Attack
{
    public string Name { get; }
    public int BasePower { get; }
    public ElementalType Element { get; }

    public Attack(string name, ElementalType element, int basepower)
    {
        Name = name;
        Element = element;
        BasePower = basepower;
    }

    public void Use(int level)
    {
        Console.WriteLine($"{Name} hits with total power {BasePower + level}!");
    }
}
