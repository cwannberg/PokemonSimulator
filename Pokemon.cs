using PokemonSimulator.Enums;

namespace PokemonSimulator;

public abstract class Pokemon
{
    private string name;
    private int level;
    // This exposes the internal list of attacks as a read-only list.
    // Other classes can view the attacks, but cannot modify the list (add/remove).
    private readonly List<Attack> attacks = new();
    public IReadOnlyList<Attack> Attacks => attacks.AsReadOnly();
    public ElementalType Elemental { get; }

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
        set
        {
            if (value.Length <2 || value.Length > 15)
                throw new ArgumentOutOfRangeException(nameof(Level), "Name must be between 2 and 15 characters long");
            name = value;
        }
    }

    protected Pokemon(string name, ElementalType elemental, int level, List<Attack> initialAttacks)
    {
        Name = name;
        Elemental = elemental;
        Level = level;
        attacks.AddRange(initialAttacks);
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

        attacks[chosenAttack].Use(Level);
    }

    public void RaiseLevel()
    {
        Level++;
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }
}
