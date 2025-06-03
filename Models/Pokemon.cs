using PokemonSimulator.Enums;
using System.Threading.Channels;

namespace PokemonSimulator.Models;

public abstract class Pokemon
{
    public List<Attack> Attacks { get; set; }
    public ElementalType Elemental { get; }
    public string name;
    public int level;
    public int Level
    {
        get => level;
        set
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException(nameof(Level), "Level must be at least 1.");
            level = value;
        }
    }
    public string Name
    {
        get => name;
        private set
        {
            if (value.Length <2 || value.Length > 15)
                throw new ArgumentOutOfRangeException(nameof(Level), "Name must be between 2 and 15 characters long");
            name = value;
        }
    }

    public Pokemon(string name, ElementalType elemental, int level, List<Attack> attacks)
    {
        Name = name;
        Elemental = elemental;
        Level = level;
        Attacks = attacks;
    }

    public void RandomAttack()
    {
        Random random = new();
        int randomNumber = random.Next(Attacks.Count);

        Attack randomAttackFromList = Attacks[randomNumber];

        randomAttackFromList.Use(Level);
    }

    public void GetAttack(List<Attack> attacks){
        Console.WriteLine("Pick one of the following attacks:");
        for(int i = 0; i < attacks.Count; i++)
        {
            Console.WriteLine($"{i} - {attacks[i].Name}");
        }
        int chosenAttack = int.Parse(Console.ReadLine());

        if (chosenAttack == 0)
        {
            Console.WriteLine($"Your choice is: {attacks[chosenAttack].Name}");
        }
        else if(chosenAttack == 1)
        {
            Console.WriteLine($"Your choice is: {attacks[chosenAttack].Name}");
        }
        else
        {
            Console.WriteLine("Felaktig input");
        }
    }

    public void RaiseLevel()
    {
        Level++;
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }
}
