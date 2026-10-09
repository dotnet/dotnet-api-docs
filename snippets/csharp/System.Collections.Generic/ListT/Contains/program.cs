// <Snippet1>
using System;
using System.Collections.Generic;

class CubeExample
{
    public static void Run()
    {
        List<Cube> cubes = [new(8, 8, 4), new(8, 4, 8), new(8, 6, 4)];

        if (cubes.Contains(new(8, 6, 4)))
        {
            Console.WriteLine("An equal cube is already in the collection.");
        }
        else
        {
            Console.WriteLine("Cube can be added.");
        }

        // Outputs "An equal cube is already in the collection."
    }
}

public class Cube : IEquatable<Cube>
{
    public Cube(int h, int l, int w)
    {
        Height = h;
        Length = l;
        Width = w;
    }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }

    public bool Equals(Cube other)
    {
        if (Height == other.Height
            && Length == other.Length
            && Width == other.Width)
        {
            return true;
        }

        return false;
    }
}
// </Snippet1>
