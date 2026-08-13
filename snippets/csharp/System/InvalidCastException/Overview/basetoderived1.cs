// <Snippet1>
using System;

public class Person
{
    string _name;

    public string Name
   {
      get => _name;
      set => _name = value;
   }
}

public class PersonWithId : Person
{
    string _id;

    public string Id
   {
      get => _id;
      set => _id = value;
   }
}

public class Example
{
    public static void Main()
    {
        Person p = new()
        {
            Name = "John"
        };
        try
        {
            PersonWithId pid = (PersonWithId)p;
            Console.WriteLine("Conversion succeeded.");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Conversion failed.");
        }

        PersonWithId pid1 = new()
        {
            Name = "John",
            Id = "246"
        };
        Person p1 = pid1;
        try
        {
            PersonWithId pid1a = (PersonWithId)p1;
            Console.WriteLine("Conversion succeeded.");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Conversion failed.");
        }

        Person p2 = null;
        try
        {
            PersonWithId pid2 = (PersonWithId)p2;
            Console.WriteLine("Conversion succeeded.");
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Conversion failed.");
        }
    }
}
// The example displays the following output:
//       Conversion failed.
//       Conversion succeeded.
//       Conversion succeeded.
// </Snippet1>
