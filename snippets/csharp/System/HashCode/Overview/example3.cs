// <Snippet1>
using System;
using System.Collections.Generic;

public struct PathExample3 : IEquatable<PathExample3>
{
    public IReadOnlyList<string> Segments { get; }

    public PathExample3(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is PathExample3 o && Equals(o);

    public bool Equals(PathExample3 other)
    {
        if (ReferenceEquals(Segments, other.Segments)) return true;
        if (Segments is null || other.Segments is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        for (int i = 0; i < Segments.Count; i++)
        {
            if (!string.Equals(Segments[i], other.Segments[i], StringComparison.OrdinalIgnoreCase))
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        for (int i = 0; i < Segments?.Count; i++)
            hash.Add(Segments[i], StringComparer.OrdinalIgnoreCase);

        return hash.ToHashCode();
    }
}

class PathHashCodeExample3
{
    public static void Run(string[] args)
    {
        var set = new HashSet<PathExample3>
        {
            new PathExample3("C:", "tmp", "file.txt"),
            new PathExample3("C:", "TMP", "file.txt"),
            new PathExample3("C:", "tmp", "FILE.TXT")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 1.
// </Snippet1>
