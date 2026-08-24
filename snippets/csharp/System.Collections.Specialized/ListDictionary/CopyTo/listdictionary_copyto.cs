// The following code example copies the elements of a ListDictionary to an array.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesListDictionary
{

    public static void Main()
    {

        // Creates and initializes a new ListDictionary.
        ListDictionary myCol = new()
      {
          { "Braeburn Apples", "1.49" },
          { "Fuji Apples", "1.29" },
          { "Gala Apples", "1.49" },
          { "Golden Delicious Apples", "1.29" },
          { "Granny Smith Apples", "0.89" },
          { "Red Delicious Apples", "0.99" }
      };

        // Displays the values in the ListDictionary in three different ways.
        Console.WriteLine("Initial contents of the ListDictionary:");
        PrintKeysAndValues(myCol);

        // Copies the ListDictionary to an array with DictionaryEntry elements.
        DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
        myCol.CopyTo(myArr, 0);

        // Displays the values in the array.
        Console.WriteLine("Displays the elements in the array:");
        Console.WriteLine("   KEY                       VALUE");
        for (int i = 0; i < myArr.Length; i++)
            Console.WriteLine($"   {myArr[i].Key,-25} {myArr[i].Value}");
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
This code produces the following output.

Initial contents of the ListDictionary:
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

Displays the elements in the array:
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

*/

// </snippet1>
