// <Snippet1>
using System;
using System.Collections.Generic;

public struct PathExample2 : IEquatable<PathExample2>
{
    public IReadOnlyList<string> Segments { get; }

    public PathExample2(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is PathExample2 o && Equals(o);

    public bool Equals(PathExample2 other)
    {
        if (ReferenceEquals(Segments, other.Segments)) return true;
        if (Segments is null || other.Segments is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        for (int i = 0; i < Segments.Count; i++)
        {
            if (!string.Equals(Segments[i], other.Segments[i]))
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        for (int i = 0; i < Segments?.Count; i++)
            hash.Add(Segments[i]);

        return hash.ToHashCode();
    }
}

class PathHashCodeExample2
{
    public static void Run(string[] args)
    {
        var set = new HashSet<PathExample2>
        {
            new PathExample2("C:", "tmp", "file.txt"),
            new PathExample2("C:", "tmp", "file.txt"),
            new PathExample2("C:", "tmp", "file.tmp")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 2.
// </Snippet1>
