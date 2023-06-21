// <Snippet1>
using System;
using System.Collections.Generic;

static class Example
{
    static void Main()
    {
        BoxEqualityComparer comparer = new();

        Dictionary<Box, string> boxes = new(comparer);

        AddBox(new Box(4, 3, 4), "red");
        AddBox(new Box(4, 3, 4), "blue");
        AddBox(new Box(3, 4, 3), "green");

        Console.WriteLine($"The dictionary contains {boxes.Count} Box objects.");

        void AddBox(Box box, string name)
        {
            try
            {
                boxes.Add(box, name);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Unable to add {box}: {e.Message}");
            }
        }
    }
}

class Box
{
    public int Height { get; }
    public int Length { get; }
    public int Width { get; }

    public Box(int height, int length, int width)
    {
        Height = height;
        Length = length;
        Width = width;
    }

    public override string ToString() => $"({Height}, {Length}, {Width})";
}

class BoxEqualityComparer : IEqualityComparer<Box>
{
    public bool Equals(Box? b1, Box? b2)
    {
        if (ReferenceEquals(b1, b2))
            return true;

        if (b2 is null || b1 is null)
            return false;

        return b1.Height == b2.Height
            && b1.Length == b2.Length
            && b1.Width == b2.Width;
    }

    public int GetHashCode(Box box) => box.Height ^ box.Length ^ box.Width;
}

// The example displays the following output:
//    Unable to add (4, 3, 4): An item with the same key has already been added.
//    The dictionary contains 2 Box objects.
// </Snippet1>
