﻿using System;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        string[] dinosaurs = { "Tyrannosaurus",
            "Amargasaurus",
            "Mamenchisaurus",
            "Brachiosaurus",
            "Deinonychus",
            "Tyrannosaurus",
            "Compsognathus" };

        Console.WriteLine();
        foreach(string dinosaur in dinosaurs)
        {
            Console.WriteLine(dinosaur);
        }

        Console.WriteLine(
            "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\"): {0}",
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus"));

        Console.WriteLine(
            "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\", 3): {0}",
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3));

        Console.WriteLine(
            "\nArray.LastIndexOf(dinosaurs, \"Tyrannosaurus\", 4, 4): {0}",
            Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4));

        /* This code example produces the following output:

        Tyrannosaurus
        Amargasaurus
        Mamenchisaurus
        Brachiosaurus
        Deinonychus
        Tyrannosaurus
        Compsognathus

        Array.LastIndexOf(dinosaurs, "Tyrannosaurus"): 5

        Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 3): 0

        Array.LastIndexOf(dinosaurs, "Tyrannosaurus", 4, 4): -1
        */
        // </Snippet1>
    }
}
