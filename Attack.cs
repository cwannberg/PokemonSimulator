using PokemonSimulator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSimulator;

public class Attack
{
    public string Name { get; set; }
    public int BasePower { get; set; }
    public ElementalType Element { get; set; }

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
