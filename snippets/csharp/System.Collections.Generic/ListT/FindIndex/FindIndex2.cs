// <Snippet2>
using System;
using System.Collections.Generic;

namespace FindIndexSnippet2;

public class Employee : IComparable
{
    public string Name { get; set; }
    public int Id { get; set; }

    public int CompareTo(object o)
    {
        Employee e = o as Employee;
        if (e == null)
            throw new ArgumentException("o is not an Employee object.");

        return Name.CompareTo(e.Name);
    }
}

public class EmployeeSearch
{
    string _s;

    public EmployeeSearch(string s)
    {
        _s = s;
    }

    public bool StartsWith(Employee e)
    {
        return e.Name.StartsWith(_s, StringComparison.InvariantCultureIgnoreCase);
    }
}

public class Example
{
    public static void Run()
    {
        List<Employee> employees = [];
        employees.AddRange([ new() { Name = "Frank", Id = 2 },
                                           new() { Name = "Jill", Id = 3 },
                                           new() { Name = "Dave", Id = 5 },
                                           new() { Name = "Jack", Id = 8 },
                                           new() { Name = "Judith", Id = 12 },
                                           new() { Name = "Robert", Id = 14 },
                                           new() { Name = "Adam", Id = 1 } ]);
        employees.Sort();

        EmployeeSearch es = new("J");
        Console.WriteLine("'J' starts at index {0}",
                          employees.FindIndex(es.StartsWith));

        es = new EmployeeSearch("Ju");
        Console.WriteLine("'Ju' starts at index {0}",
                          employees.FindIndex(es.StartsWith));
    }
}
// The example displays the following output:
//       'J' starts at index 3
//       'Ju' starts at index 5
// </Snippet2>
