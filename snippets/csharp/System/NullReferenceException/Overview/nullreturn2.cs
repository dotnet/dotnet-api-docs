
using System;

public class NullReturnExample
{
    // <Snippet4>
    public static void NoCheckExample()
    {
        Person[] persons = Person.AddRange([ "Abigail", "Abra",
                                          "Abraham", "Adrian", "Ariella",
                                          "Arnold", "Aston", "Astor" ]);
        string nameToFind = "Robert";
        Person found = Array.Find(persons, p => p.FirstName == nameToFind);
        Console.WriteLine(found.FirstName);
    }

    // The example displays the following output:
    //       Unhandled Exception: System.NullReferenceException:
    //       Object reference not set to an instance of an object.
    // </Snippet4>

    // <Snippet5>
    public static void ExampleWithNullCheck()
    {
        Person[] persons = Person.AddRange([ "Abigail", "Abra",
                                          "Abraham", "Adrian", "Ariella",
                                          "Arnold", "Aston", "Astor" ]);
        string nameToFind = "Robert";
        Person found = Array.Find(persons, p => p.FirstName == nameToFind);
        if (found != null)
            Console.WriteLine(found.FirstName);
        else
            Console.WriteLine($"'{nameToFind}' not found.");
    }

    // The example displays the following output:
    //        'Robert' not found
    // </Snippet5>
}

public class Person
{
    public static Person[] AddRange(params string[] firstNames)
    {
        Person[] p = new Person[firstNames.Length];
        for (int ctr = 0; ctr < firstNames.Length; ctr++)
            p[ctr] = new Person(firstNames[ctr]);

        return p;
    }

    public Person(string firstName)
    {
        FirstName = firstName;
    }

    public string FirstName;
}
