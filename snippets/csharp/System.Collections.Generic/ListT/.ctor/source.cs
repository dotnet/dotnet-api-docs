// <Snippet1>
using System;
using System.Collections.Generic;

public partial class Program
{
    public static void Main()
    {
        List<string> animals = new List<string>(4);

        Console.WriteLine("\nCapacity: {0}", animals.Capacity);

        animals.Add("Cat");
        animals.Add("Dog");
        animals.Add("Squirrel");
        animals.Add("Wolf");

        Console.WriteLine();
        foreach (string animal in animals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine("\nIList<string> roAnimals = animals.AsReadOnly()");
        IList<string> roAnimals = animals.AsReadOnly();

        Console.WriteLine("\nElements in the read-only IList:");
        foreach (string animal in roAnimals)
        {
            Console.WriteLine(animal);
        }

        Console.WriteLine("\nanimals[2] = \"Lion\"");
        animals[2] = "Lion";

        Console.WriteLine("\nElements in the read-only IList:");
        foreach (string animal in roAnimals)
        {
            Console.WriteLine(animal);
        }
    }
}

/*
    This code example produces the following output:

    Capacity: 4

    Cat
    Dog
    Squirrel
    Wolf

    IList<string> roAnimals = animals.AsReadOnly()

    Elements in the read-only IList:
    Cat
    Dog
    Squirrel
    Wolf

    animals[2] = "Lion"

    Elements in the read-only IList:
    Cat
    Dog
    Lion
    Wolf
*/
// </Snippet1>
