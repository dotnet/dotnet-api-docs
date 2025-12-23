// <PersonSample>
List<Person> applicants = new List<Person>()
{
    new Person("Jones", "099-29-4999"),
    new Person("Jones", "199-29-3999"),
    new Person("Jones", "299-49-6999")
};

// Create a Person object for the final candidate.
Person candidate = new Person("Jones", "199-29-3999");
bool contains = applicants.Contains(candidate);
Console.WriteLine($"{candidate.LastName} ({candidate.NationalId}) is on record: {contains}");
// The example prints the following output:
// Jones (199-29-3999) is on record: True
// </PersonSample>

// <Person>
public class Person : IEquatable<Person>
{
    public Person(string lastName, string ssn)
    {
        LastName = lastName;
        NationalId = ssn;
    }

    public string LastName { get; }

    public string NationalId { get; }

    public bool Equals(Person? other) => other is not null && other.NationalId == NationalId;

    public override bool Equals(object? obj) => Equals(obj as Person);

    public override int GetHashCode() => NationalId.GetHashCode();

    public static bool operator ==(Person person1, Person person2)
    {
        if (person1 is null)
        {
            return person2 is null;
        }

        return person1.Equals(person2);
    }

    public static bool operator !=(Person person1, Person person2)
    {
        if (person1 is null)
        {
            return person2 is not null;
        }

        return !person1.Equals(person2);
    }
}
// </Person>
