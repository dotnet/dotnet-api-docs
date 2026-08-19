using System;
using System.Collections.Generic;

namespace BinarySearchSnippet1;

public class BinarySearchExample1
{
    public static void Run()
    {
        // <Snippet1>
        List<string> dinosaurs =
        [
            "Pachycephalosaurus",
            "Amargasaurus",
            "Mamenchisaurus",
            "Deinonychus",
        ];

        Console.WriteLine("Initial list:");
        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nSort:");
        dinosaurs.Sort();

        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nBinarySearch and Insert \"Coelophysis\":");
        int index = dinosaurs.BinarySearch("Coelophysis");
        if (index < 0)
        {
            dinosaurs.Insert(~index, "Coelophysis");
        }

        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine("\nBinarySearch and Insert \"Tyrannosaurus\":");
        index = dinosaurs.BinarySearch("Tyrannosaurus");
        if (index < 0)
        {
            dinosaurs.Insert(~index, "Tyrannosaurus");
        }

        Console.WriteLine();
        foreach (string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }
        /* This code example produces the following output:

        Initial list:

        Pachycephalosaurus
        Amargasaurus
        Mamenchisaurus
        Deinonychus

        Sort:

        Amargasaurus
        Deinonychus
        Mamenchisaurus
        Pachycephalosaurus

        BinarySearch and Insert "Coelophysis":

        Amargasaurus
        Coelophysis
        Deinonychus
        Mamenchisaurus
        Pachycephalosaurus

        BinarySearch and Insert "Tyrannosaurus":

        Amargasaurus
        Coelophysis
        Deinonychus
        Mamenchisaurus
        Pachycephalosaurus
        Tyrannosaurus
        */
        // </Snippet1>
    }
}
