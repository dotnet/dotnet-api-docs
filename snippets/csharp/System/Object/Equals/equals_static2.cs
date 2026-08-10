// <Snippet1>
using System;

public class RefExample
{
    public static void Main()
    {
        Dog m1 = new("Alaskan Malamute");
        Dog m2 = new("Alaskan Malamute");
        Dog g1 = new("Great Pyrenees");
        Dog g2 = g1;
        Dog d1 = new("Dalmatian");
        Dog n1 = null;
        Dog n2 = null;

        Console.WriteLine($"null = null: {object.Equals(n1, n2)}");
        Console.WriteLine($"null Reference Equals null: {object.ReferenceEquals(n1, n2)}\n");

        Console.WriteLine($"{g1} = {g2}: {object.Equals(g1, g2)}");
        Console.WriteLine($"{g1} Reference Equals {g2}: {object.ReferenceEquals(g1, g2)}\n");

        Console.WriteLine($"{m1} = {m2}: {object.Equals(m1, m2)}");
        Console.WriteLine($"{m1} Reference Equals {m2}: {object.ReferenceEquals(m1, m2)}\n");

        Console.WriteLine($"{m1} = {d1}: {object.Equals(m1, d1)}");
        Console.WriteLine($"{m1} Reference Equals {d1}: {object.ReferenceEquals(m1, d1)}");
    }
}

public class Dog
{
    // Public field.
    public string Breed;

    // Class constructor.
    public Dog(string dogBreed) => this.Breed = dogBreed;

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Dog))
            return false;
        else
            return this.Breed == ((Dog)obj).Breed;
    }

    public override int GetHashCode() => this.Breed.GetHashCode();

    public override string ToString() => this.Breed;
}

// The example displays the following output:

//       null = null: True
//       null Reference Equals null: True
//
//       Great Pyrenees = Great Pyrenees: True
//       Great Pyrenees Reference Equals Great Pyrenees: True
//
//       Alaskan Malamute = Alaskan Malamute: True
//       Alaskan Malamute Reference Equals Alaskan Malamute: False
//
//       Alaskan Malamute = Dalmatian: False
//       Alaskan Malamute Reference Equals Dalmatian: False

// </Snippet1>
