// The following code example enumerates the elements of a StringDictionary.

// <snippet2>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionaryValues
{
    public static void Run()
    {
        // Creates and initializes a new StringDictionary.
        StringDictionary myCol = new()
        {
            { "red", "rojo" },
            { "green", "verde" },
            { "blue", "azul" }
        };

        Console.WriteLine("VALUES");
        foreach (string val in myCol.Values)
        {
            Console.WriteLine(val);
        }
    }
}
// This code produces the following output.
// VALUES
// verde
// rojo
// azul
// </snippet2>
