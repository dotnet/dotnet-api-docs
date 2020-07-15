﻿// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesHashtable
 {

    public static void Main()
    {

       // Creates and initializes a new Hashtable.
       var myHT = new Hashtable();
       myHT.Add("First", "Hello");
       myHT.Add("Second", "World");
       myHT.Add("Third", "!");

       // Displays the properties and values of the Hashtable.
       Console.WriteLine("myHT");
       Console.WriteLine($"  Count:    {myHT.Count}");
       Console.WriteLine("  Keys and Values:");
       PrintKeysAndValues(myHT);
    }

    public static void PrintKeysAndValues( Hashtable myHT )
    {
       Console.WriteLine( "\t-KEY-\t-VALUE-" );
       foreach (DictionaryEntry de in myHT)
          Console.WriteLine($"\t{de.Key}:\t{de.Value}");
       Console.WriteLine();
    }
 }


 /*
 This code produces the following output.

 myHT
   Count:    3
   Keys and Values:
         -KEY-   -VALUE-
         Second: World
         Third:  !
         First:  Hello

 */
// </Snippet1>
