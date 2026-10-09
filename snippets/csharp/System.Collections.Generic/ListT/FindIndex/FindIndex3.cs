// <Snippet3>
using System;
using System.Collections.Generic;

namespace FindIndexSnippet3;

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
        int index = employees.FindIndex(4, es.StartsWith);
        Console.WriteLine("Starting index of'J': {0}",
                          index >= 0 ? index.ToString() : "Not found");

        es = new EmployeeSearch("Ju");
        index = employees.FindIndex(4, es.StartsWith);
        Console.WriteLine("Starting index of 'Ju': {0}",
                          index >= 0 ? index.ToString() : "Not found");
    }
}
// The example displays the following output:
//       'J' starts at index 4
//       'Ju' starts at index 5
// </Snippet3>
