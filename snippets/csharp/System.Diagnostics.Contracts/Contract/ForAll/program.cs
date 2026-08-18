//<Snippet1>
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

// Start the application with at least two arguments.
args[1] = null;
Contract.Requires(args != null && Contract.ForAll(0, args.Length, i => args[i] != null));
// Test the ForAll method. This is only for the purpose of demonstrating how ForAll works.
CheckIndexes(args);
Stack<string> numbers = new();
numbers.Push("one");
numbers.Push("two");
numbers.Push(null);
numbers.Push("four");
numbers.Push("five");
Contract.Requires(numbers != null && !Contract.ForAll(numbers, (string x) => x != null));
// Test the ForAll generic overload. This is only for the purpose of demonstrating how ForAll works.
CheckTypeArray(numbers);

static bool CheckIndexes(string[] args)
{
    try
    {
        if (args != null && !Contract.ForAll(0, args.Length, i => args[i] != null))
        {
            throw new ArgumentException("The parameter array has a null element", "args");
        }

        return true;
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
}

static bool CheckTypeArray(IEnumerable<string> xs)
{
    try
    {
        if (xs != null && !Contract.ForAll(xs, (string x) => x != null))
        {
            throw new ArgumentException("The parameter array has a null element", "indexes");
        }

        return true;
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
}
//</Snippet1>
