// <Snippet15>
using System;
using System.Collections.Generic;

public class Person
{
    public Person(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class ListSortEx4
{
    public static void Main()
    {
        var people = new List<Person>() { new Person("John", "Doe"), new Person("Jane", "Doe") };
        people.Sort(PersonComparison);
        foreach (var person in people)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }

    public static int PersonComparison(Person x, Person y) => $"{x.LastName} {x.FirstName}".
              CompareTo($"{y.LastName} {y.FirstName}");
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet15>
