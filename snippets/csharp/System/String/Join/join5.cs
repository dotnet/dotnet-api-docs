// <Snippet5>
using System;
using System.Collections.Generic;
using System.Linq;

public class Animal
{
    public string Kind;
    public string Order;

    public Animal(string kind, string order)
    {
        this.Kind = kind;
        this.Order = order;
    }

    public override string ToString() => this.Kind;
}

public class Example
{
    public static void Main()
    {
        List<Animal> animals = new()
        {
            new Animal("Squirrel", "Rodent"),
            new Animal("Gray Wolf", "Carnivora"),
            new Animal("Capybara", "Rodent")
        };
        string output = string.Join(" ", animals.Where(animal =>
                        (animal.Order == "Rodent")));
        Console.WriteLine(output);
    }
}
// The example displays the following output:
//      Squirrel Capybara
// </Snippet5>
