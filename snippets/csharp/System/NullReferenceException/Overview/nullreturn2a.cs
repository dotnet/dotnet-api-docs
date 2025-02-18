using System;

namespace NullReturn2
{
    // <Snippet5>
    public class NullReturn2Example
    {
        public static void Main()
        {
            Person[] persons = Person.AddRange([ "Abigail", "Abra",
                                          "Abraham", "Adrian", "Ariella",
                                          "Arnold", "Aston", "Astor" ]);
            string nameToFind = "Robert";
            Person found = Array.Find(persons, p => p.FirstName == nameToFind);
            if (found != null)
                Console.WriteLine(found.FirstName);
            else
                Console.WriteLine("{0} not found.", nameToFind);
        }
    }

    public class Person
    {
        public static Person[] AddRange(string[] firstNames)
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
    // The example displays the following output:
    //        Robert not found
    // </Snippet5>
}
