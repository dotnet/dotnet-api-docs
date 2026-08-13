// <Snippet2>
using System;

// A type that represents a 2-D point.
public struct Point2
{
    private int x;
    private int y;

    public Point2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Point2)) return false;

        Point2 p = (Point2)obj;
        return x == p.x & y == p.y;
    }

    public override int GetHashCode() => x ^ y;
}

public class Example3
{
    public static void Main()
    {
        Point2 pt = new(5, 8);
        Console.WriteLine(pt.GetHashCode());

        pt = new(8, 5);
        Console.WriteLine(pt.GetHashCode());
    }
}
// The example displays the following output:
//       13
//       13
// </Snippet2>
