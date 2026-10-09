// <Snippet14>
using System;
using System.Collections.Generic;

public class Person3
{
    public Person3(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class PersonComparer : IComparer<Person3>
{
    public int Compare(Person3 x, Person3 y) => $"{x.LastName} {x.FirstName}".
               CompareTo($"{y.LastName} {y.FirstName}");
}

public class ListSortEx3
{
    public static void Main()
    {
        var people = new List<Person3>() { new Person3("John", "Doe"), new Person3("Jane", "Doe") };
        people.Sort(new PersonComparer());
        foreach (var person in people)
            Console.WriteLine($"{person.FirstName} {person.LastName}");
    }
}
// The example displays the following output:
//       Jane Doe
//       John Doe
// </Snippet14>
