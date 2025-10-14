// <Snippet1>
using System;
using System.Collections.Generic;

string[] input = { "Apple",
                   "Banana",
                   "Orange" };

List<string> fruits = new List<string>(input);

Console.WriteLine("\nCapacity: {0}", fruits.Capacity);
Console.WriteLine();

foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}

Console.WriteLine("\nAddRange(fruits)");
fruits.AddRange(fruits);

Console.WriteLine();
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}

Console.WriteLine("\nRemoveRange(2, 2)");
fruits.RemoveRange(2, 2);

Console.WriteLine();
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}

input = new string[] { "Mango",
                       "Pineapple",
                       "Watermelon" };

Console.WriteLine("\nInsertRange(3, input)");
fruits.InsertRange(3, input);

Console.WriteLine();
foreach (string fruit in fruits)
{
    Console.WriteLine(fruit);
}

Console.WriteLine("\noutput = fruits.GetRange(2, 3).ToArray()");
string[] output = fruits.GetRange(2, 3).ToArray();

Console.WriteLine();
foreach (string fruit in output)
{
    Console.WriteLine(fruit);
}

/*
    This code example produces the following output:

    Capacity: 3

    Apple
    Banana
    Orange

    AddRange(fruits)

    Apple
    Banana
    Orange
    Apple
    Banana
    Orange

    RemoveRange(2, 2)

    Apple
    Banana
    Banana
    Orange

    InsertRange(3, input)

    Apple
    Banana
    Banana
    Mango
    Pineapple
    Watermelon
    Orange

    output = fruits.GetRange(2, 3).ToArray()

    Banana
    Mango
    Pineapple
*/
// </Snippet1>
