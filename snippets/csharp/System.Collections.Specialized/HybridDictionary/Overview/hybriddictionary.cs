// The following code example demonstrates several of the properties and methods of HybridDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesHybridDictionary
{

    public static void Run()
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

        // Display the contents of the collection using foreach. This is the preferred method.
        Console.WriteLine("Displays the elements using foreach:");
        PrintKeysAndValues1(myCol);

        // Display the contents of the collection using the enumerator.
        Console.WriteLine("Displays the elements using the IDictionaryEnumerator:");
        PrintKeysAndValues2(myCol);

        // Display the contents of the collection using the Keys, Values, Count, and Item properties.
        Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
        PrintKeysAndValues3(myCol);

        // Copies the HybridDictionary to an array with DictionaryEntry elements.
        DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
        myCol.CopyTo(myArr, 0);

        // Displays the values in the array.
        Console.WriteLine("Displays the elements in the array:");
        Console.WriteLine("   KEY                       VALUE");
        for (int i = 0; i < myArr.Length; i++)
            Console.WriteLine($"   {myArr[i].Key,-25} {myArr[i].Value}");
        Console.WriteLine();

        // Searches for a key.
        if (myCol.Contains("Kiwis"))
            Console.WriteLine("The collection contains the key \"Kiwis\".");
        else
            Console.WriteLine("The collection does not contain the key \"Kiwis\".");
        Console.WriteLine();

        // Deletes a key.
        myCol.Remove("Plums");
        Console.WriteLine("The collection contains the following elements after removing \"Plums\":");
        PrintKeysAndValues1(myCol);

        // Clears the entire collection.
        myCol.Clear();
        Console.WriteLine("The collection contains the following elements after it is cleared:");
        PrintKeysAndValues1(myCol);
    }

    // Uses the foreach statement which hides the complexity of the enumerator.
    // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
    public static void PrintKeysAndValues1(IDictionary myCol)
    {
        Console.WriteLine("   KEY                       VALUE");
        foreach (DictionaryEntry de in myCol)
            Console.WriteLine($"   {de.Key,-25} {de.Value}");
        Console.WriteLine();
    }

    // Uses the enumerator.
    // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
    public static void PrintKeysAndValues2(IDictionary myCol)
    {
        IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
        Console.WriteLine("   KEY                       VALUE");
        while (myEnumerator.MoveNext())
            Console.WriteLine($"   {myEnumerator.Key,-25} {myEnumerator.Value}");
        Console.WriteLine();
    }

    // Uses the Keys, Values, Count, and Item properties.
    public static void PrintKeysAndValues3(HybridDictionary myCol)
    {
        string[] myKeys = new string[myCol.Count];
        myCol.Keys.CopyTo(myKeys, 0);

        Console.WriteLine("   INDEX KEY                       VALUE");
        for (int i = 0; i < myCol.Count; i++)
            Console.WriteLine($"   {i,-5} {myKeys[i],-25} {myCol[myKeys[i]]}");
        Console.WriteLine();
    }
}

/*
This code produces output similar to the following:

Displays the elements using foreach:
   KEY                       VALUE
   Strawberries              3.33
   Yellow Bananas            0.79
   Cranberries               5.98
   Grapes                    1.99
   Granny Smith Apples       0.89
   Seedless Watermelon       0.49
   Honeydew Melon            0.59
   Red Delicious Apples      0.99
   Navel Oranges             1.29
   Fuji Apples               1.29
   Plantain Bananas          1.49
   Gala Apples               1.49
   Pineapple                 1.49
   Plums                     1.69
   Braeburn Apples           1.49
   Peaches                   1.99
   Golden Delicious Apples   1.29
   Nectarine                 1.99

Displays the elements using the IDictionaryEnumerator:
   KEY                       VALUE
   Strawberries              3.33
   Yellow Bananas            0.79
   Cranberries               5.98
   Grapes                    1.99
   Granny Smith Apples       0.89
   Seedless Watermelon       0.49
   Honeydew Melon            0.59
   Red Delicious Apples      0.99
   Navel Oranges             1.29
   Fuji Apples               1.29
   Plantain Bananas          1.49
   Gala Apples               1.49
   Pineapple                 1.49
   Plums                     1.69
   Braeburn Apples           1.49
   Peaches                   1.99
   Golden Delicious Apples   1.29
   Nectarine                 1.99

Displays the elements using the Keys, Values, Count, and Item properties:
   INDEX KEY                       VALUE
   0     Strawberries              3.33
   1     Yellow Bananas            0.79
   2     Cranberries               5.98
   3     Grapes                    1.99
   4     Granny Smith Apples       0.89
   5     Seedless Watermelon       0.49
   6     Honeydew Melon            0.59
   7     Red Delicious Apples      0.99
   8     Navel Oranges             1.29
   9     Fuji Apples               1.29
   10    Plantain Bananas          1.49
   11    Gala Apples               1.49
   12    Pineapple                 1.49
   13    Plums                     1.69
   14    Braeburn Apples           1.49
   15    Peaches                   1.99
   16    Golden Delicious Apples   1.29
   17    Nectarine                 1.99

Displays the elements in the array:
   KEY                       VALUE
   Strawberries              3.33
   Yellow Bananas            0.79
   Cranberries               5.98
   Grapes                    1.99
   Granny Smith Apples       0.89
   Seedless Watermelon       0.49
   Honeydew Melon            0.59
   Red Delicious Apples      0.99
   Navel Oranges             1.29
   Fuji Apples               1.29
   Plantain Bananas          1.49
   Gala Apples               1.49
   Pineapple                 1.49
   Plums                     1.69
   Braeburn Apples           1.49
   Peaches                   1.99
   Golden Delicious Apples   1.29
   Nectarine                 1.99

The collection does not contain the key "Kiwis".

The collection contains the following elements after removing "Plums":
   KEY                       VALUE
   Strawberries              3.33
   Yellow Bananas            0.79
   Cranberries               5.98
   Grapes                    1.99
   Granny Smith Apples       0.89
   Seedless Watermelon       0.49
   Honeydew Melon            0.59
   Red Delicious Apples      0.99
   Navel Oranges             1.29
   Fuji Apples               1.29
   Plantain Bananas          1.49
   Gala Apples               1.49
   Pineapple                 1.49
   Braeburn Apples           1.49
   Peaches                   1.99
   Golden Delicious Apples   1.29
   Nectarine                 1.99

The collection contains the following elements after it is cleared:
   KEY                       VALUE

*/
// </snippet1>
