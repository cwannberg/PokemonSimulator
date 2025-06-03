using PokemonSimulator.Enums;
namespace PokemonSimulator;

public abstract class Pokemon
{
    private string name;
    private int level;
    public List<Attack> Attacks = new();
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

    protected Pokemon(string name, ElementalType elemental, int level, List<Attack> attacks)
    {
        Name = name;
        Elemental = elemental;
        Level = level;
        Attacks = attacks;
    }
    public static void Attack(Pokemon pokemon)
    {
        pokemon.GetAttack(pokemon.Attacks);
        pokemon.RaiseLevel();
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
        Console.WriteLine($"{attacks.Count} - Random attack");

        int chosenAttack = int.Parse(Console.ReadLine());

        if(chosenAttack == attacks.Count())
        {
            RandomAttack();
        }

        attacks[chosenAttack].Use(Level);
    }
    public static void Fight(Pokemon pokemon)
    {
        while (true)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Fight ended");
                break;
            }
            Attack(pokemon);
            Thread.Sleep(1000);
        }
    }
    public void RaiseLevel()
    {
        Level++;
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }
}
