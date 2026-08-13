// <Snippet1>
using System;
using System.Collections.Generic;

public struct PathExample4 : IEquatable<PathExample4>
{
    public IReadOnlyList<string> Segments { get; }

    public PathExample4(params string[] segments) => Segments = segments;

    public override bool Equals(object obj) => obj is PathExample4 o && Equals(o);

    public bool Equals(PathExample4 other)
    {
        if (ReferenceEquals(Segments, other.Segments)) return true;
        if (Segments is null || other.Segments is null) return false;
        if (Segments.Count != other.Segments.Count) return false;

        for (int i = 0; i < Segments.Count; i++)
        {
            if (!PlatformUtils.PathEquals(Segments[i], other.Segments[i]))
                return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();

        for (int i = 0; i < Segments?.Count; i++)
            PlatformUtils.AddPath(ref hash, Segments[i]);

        return hash.ToHashCode();
    }
}

internal static class PlatformUtils
{
    public static bool PathEquals(string a, string b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    public static void AddPath(ref HashCode hash, string path) => hash.Add(path, StringComparer.OrdinalIgnoreCase);
}

class PathHashCodeExample4
{
    public static void Run(string[] args)
    {
        var set = new HashSet<PathExample4>
        {
            new PathExample4("C:", "tmp", "file.txt"),
            new PathExample4("C:", "TMP", "file.txt"),
            new PathExample4("C:", "tmp", "FILE.TXT")
        };

        Console.WriteLine($"Item count: {set.Count}.");
    }
}
// The example displays the following output:
// Item count: 1.
// </Snippet1>
