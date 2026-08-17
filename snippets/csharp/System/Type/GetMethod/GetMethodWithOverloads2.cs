// <Snippet3>
using System;
using System.Reflection;

public class Person
{
    public string FirstName;
    public string LastName;

    public override string ToString() => (FirstName + " " + LastName).Trim();
}

public class Example2
{
    public static void Main()
    {
        Type t = typeof(Person);
        RetrieveMethod(t, "ToString");

        t = typeof(int);
        RetrieveMethod(t, "ToString");
    }

    private static void RetrieveMethod(Type t, string name)
    {
        try
        {
            MethodInfo m = t.GetMethod(name);
            if (m != null)
                Console.WriteLine($"{m.ReflectedType.Name}.{m.Name}: {(m.IsStatic ? "Static" : "Instance")} method");
            else
                Console.WriteLine($"{t.Name}.ToString method not found");
        }
        catch (AmbiguousMatchException)
        {
            Console.WriteLine($"{t.Name}.{name} has multiple public overloads.");
        }
    }
}
// The example displays the following output:
//       Person.ToString: Instance method
//       Int32.ToString has multiple public overloads.
// </Snippet3>
