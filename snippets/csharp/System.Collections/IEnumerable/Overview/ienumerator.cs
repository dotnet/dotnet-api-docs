//<Snippet1>
using System;
using System.Collections;

Person[] peopleArray =
[
    new("John", "Smith"),
    new("Jim", "Johnson"),
    new("Sue", "Rabon"),
];

People peopleList = new(peopleArray);
foreach (Person p in peopleList)
{
    Console.WriteLine($"{p.firstName} {p.lastName}");
}

// Simple business object.
public class Person
{
    public Person(string fName, string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
    }

    public string firstName;
    public string lastName;
}

// Collection of Person objects. This class
// implements IEnumerable so that it can be used
// with ForEach syntax.
public class People : IEnumerable
{
    private Person[] _people;
    public People(Person[] pArray)
    {
        _people = new Person[pArray.Length];

        for (int i = 0; i < pArray.Length; i++)
        {
            _people[i] = pArray[i];
        }
    }

    // Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

    public PeopleEnum GetEnumerator() => new PeopleEnum(_people);
}

// <Snippet2>
// When you implement IEnumerable, you must also implement IEnumerator.
public class PeopleEnum : IEnumerator
{
    public Person[] _people;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public PeopleEnum(Person[] list) => _people = list;

    public bool MoveNext()
    {
        position++;
        return (position < _people.Length);
    }

    public void Reset() => position = -1;

    object IEnumerator.Current => Current;

    public Person Current
    {
        get
        {
            try
            {
                return _people[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
// </Snippet2>

/* This code produces output similar to the following:
 *
 * John Smith
 * Jim Johnson
 * Sue Rabon
 *
 */
//</Snippet1>
