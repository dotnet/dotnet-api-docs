// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // <Snippet2>
        List<Box> Boxes =
        [
            new Box(4, 20, 14),
            new Box(12, 12, 12),
            new Box(8, 20, 10),
            new Box(6, 10, 2),
            new Box(2, 8, 4),
            new Box(2, 6, 8),
            new Box(4, 12, 20),
            new Box(18, 10, 4),
            new Box(24, 4, 18),
            new Box(10, 4, 16),
            new Box(10, 2, 10),
            new Box(6, 18, 2),
            new Box(8, 12, 4),
            new Box(12, 10, 8),
            new Box(14, 6, 6),
            new Box(16, 6, 16),
            new Box(2, 8, 12),
            new Box(4, 24, 8),
            new Box(8, 6, 20),
            new Box(18, 18, 12),
        ];

        // Sort by an Comparer<T> implementation that sorts
        // first by the length.
        Boxes.Sort(new BoxLengthFirst());

        Console.WriteLine("H - L - W");
        Console.WriteLine("==========");
        foreach (Box bx in Boxes)
        {
            Console.WriteLine("{0}\t{1}\t{2}",
                bx.Height.ToString(), bx.Length.ToString(),
                bx.Width.ToString());
        }
        // </Snippet2>

        Console.WriteLine();
        Console.WriteLine("H - L - W");
        Console.WriteLine("==========");

        // <Snippet3>
        // Get the default comparer that
        // sorts first by the height.
        Comparer<Box> defComp = Comparer<Box>.Default;

        // Calling Boxes.Sort() with no parameter
        // is the same as calling Boxs.Sort(defComp)
        // because they are both using the default comparer.
        Boxes.Sort();

        foreach (Box bx in Boxes)
        {
            Console.WriteLine("{0}\t{1}\t{2}",
                bx.Height.ToString(), bx.Length.ToString(),
                bx.Width.ToString());
        }
        // </Snippet3>

        // <Snippet4>

        // This explicit interface implementation
        // compares first by the length.
        // Returns -1 because the length of BoxA
        // is less than the length of BoxB.
        BoxLengthFirst LengthFirst = new();

        Comparer<Box> bc = (Comparer<Box>)LengthFirst;

        Box BoxA = new(2, 6, 8);
        Box BoxB = new(10, 12, 14);
        int x = LengthFirst.Compare(BoxA, BoxB);
        Console.WriteLine();
        Console.WriteLine(x.ToString());
        // </Snippet4>
    }
}

// <Snippet5>
public class BoxLengthFirst : Comparer<Box>
{
    // <Snippet6>
    // Compares by Length, Height, and Width.
    public override int Compare(Box x, Box y)
    {
        if (x.Length.CompareTo(y.Length) != 0)
        {
            return x.Length.CompareTo(y.Length);
        }
        else if (x.Height.CompareTo(y.Height) != 0)
        {
            return x.Height.CompareTo(y.Height);
        }
        else if (x.Width.CompareTo(y.Width) != 0)
        {
            return x.Width.CompareTo(y.Width);
        }
        else
        {
            return 0;
        }
    }
    // </Snippet6>
}
// </Snippet5>

// <Snippet7>
// This class is not demonstrated in the Main method
// and is provided only to show how to implement
// the interface. It is recommended to derive
// from Comparer<T> instead of implementing IComparer<T>.
public class BoxComp : IComparer<Box>
{
    // Compares by Height, Length, and Width.
    public int Compare(Box x, Box y)
    {
        if (x.Height.CompareTo(y.Height) != 0)
        {
            return x.Height.CompareTo(y.Height);
        }
        else if (x.Length.CompareTo(y.Length) != 0)
        {
            return x.Length.CompareTo(y.Length);
        }
        else if (x.Width.CompareTo(y.Width) != 0)
        {
            return x.Width.CompareTo(y.Width);
        }
        else
        {
            return 0;
        }
    }
}
// </Snippet7>

// <Snippet8>
public class Box : IComparable<Box>
{

    public Box(int h, int l, int w)
    {
        this.Height = h;
        this.Length = l;
        this.Width = w;
    }
    public int Height { get; private set; }
    public int Length { get; private set; }
    public int Width { get; private set; }

    public int CompareTo(Box other)
    {
        // Compares Height, Length, and Width.
        if (this.Height.CompareTo(other.Height) != 0)
        {
            return this.Height.CompareTo(other.Height);
        }
        else if (this.Length.CompareTo(other.Length) != 0)
        {
            return this.Length.CompareTo(other.Length);
        }
        else if (this.Width.CompareTo(other.Width) != 0)
        {
            return this.Width.CompareTo(other.Width);
        }
        else
        {
            return 0;
        }
    }
}
// </Snippet8>

// </Snippet1>
