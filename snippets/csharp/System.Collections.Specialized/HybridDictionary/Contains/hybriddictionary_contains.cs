// The following code example searches for an element in a HybridDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesHybridDictionary
{

    public static void Main()
    {

        // Creates and initializes a new HybridDictionary.
        HybridDictionary myCol = new()
      {
          { "Braeburn Apples", "1.49" },
          { "Fuji Apples", "1.29" },
          { "Gala Apples", "1.49" },
          { "Golden Delicious Apples", "1.29" },
          { "Granny Smith Apples", "0.89" },
          { "Red Delicious Apples", "0.99" },
          { "Plantain Bananas", "1.49" },
          { "Yellow Bananas", "0.79" },
          { "Strawberries", "3.33" },
          { "Cranberries", "5.98" },
          { "Navel Oranges", "1.29" },
          { "Grapes", "1.99" },
          { "Honeydew Melon", "0.59" },
          { "Seedless Watermelon", "0.49" },
          { "Pineapple", "1.49" },
          { "Nectarine", "1.99" },
          { "Plums", "1.69" },
          { "Peaches", "1.99" }
      };

        // Displays the values in the HybridDictionary in three different ways.
        Console.WriteLine("Initial contents of the HybridDictionary:");
        PrintKeysAndValues(myCol);

        // Searches for a key.
        if (myCol.Contains("Kiwis"))
            Console.WriteLine("The collection contains the key \"Kiwis\".");
        else
            Console.WriteLine("The collection does not contain the key \"Kiwis\".");
        Console.WriteLine();
    }

    public static void PrintKeysAndValues(IDictionary myCol)
    {
        Console.WriteLine("   KEY                       VALUE");
        foreach (DictionaryEntry de in myCol)
            Console.WriteLine($"   {de.Key,-25} {de.Value}");
        Console.WriteLine();
    }
}

/*
This code produces output similar to the following:

Initial contents of the HybridDictionary:
   KEY                       VALUE
   Seedless Watermelon       0.49
   Nectarine                 1.99
   Cranberries               5.98
   Plantain Bananas          1.49
   Honeydew Melon            0.59
   Pineapple                 1.49
   Strawberries              3.33
   Grapes                    1.99
   Braeburn Apples           1.49
   Peaches                   1.99
   Red Delicious Apples      0.99
   Golden Delicious Apples   1.29
   Yellow Bananas            0.79
   Granny Smith Apples       0.89
   Gala Apples               1.49
   Plums                     1.69
   Navel Oranges             1.29
   Fuji Apples               1.29

The collection does not contain the key "Kiwis".

*/
// </snippet1>
