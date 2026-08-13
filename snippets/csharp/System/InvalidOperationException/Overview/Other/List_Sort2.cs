// <Snippet13>
using System;
using System.Collections.Generic;

public class Person2 : IComparable<Person>
{
    public Person2(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int CompareTo(Person other) => $"{LastName} {FirstName}".
               CompareTo($"{other.LastName} {other.FirstName}");
}

public class ListSortEx2
{
    public static void Main()
    {
        var people = new List<Person2>() { new Person2("John", "Doe"), new Person2("Jane", "Doe") };
        people.Sort();
        foreach (var person in people)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet13>
