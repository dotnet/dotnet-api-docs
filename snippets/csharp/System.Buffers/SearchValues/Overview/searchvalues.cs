// <SnippetUsings>
using System;
using System.Buffers;
using System.Text;
// </SnippetUsings>

namespace SearchValuesExamples;

public static class Parsing
{
    // <SnippetParsing>
    // Cache the SearchValues instance in a static readonly field so that the
    // optimized representation is computed once and reused for every search.
    private static readonly SearchValues<char> s_delimiters = SearchValues.Create(";,");

    public static void PrintFields(ReadOnlySpan<char> line)
    {
        while (!line.IsEmpty)
        {
            // Find the next delimiter. IndexOfAny returns -1 when none of the values are present.
            int index = line.IndexOfAny(s_delimiters);

            ReadOnlySpan<char> field = index < 0 ? line : line[..index];
            Console.WriteLine(field.Trim().ToString());

            line = index < 0 ? default : line[(index + 1)..];
        }
    }
    // </SnippetParsing>
}

public static class Validation
{
    // <SnippetValidation>
    private static readonly SearchValues<char> s_allowedHostChars =
        SearchValues.Create("-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

    // Rejects any host name that contains a character outside of the allowed set.
    public static bool IsValidHost(ReadOnlySpan<char> host) =>
        !host.IsEmpty && !host.ContainsAnyExcept(s_allowedHostChars);
    // </SnippetValidation>
}

public static class Bytes
{
    // <SnippetBytes>
    // A UTF-8 literal ("u8") avoids allocating a string just to create the set.
    private static readonly SearchValues<byte> s_newLineBytes = SearchValues.Create("\r\n"u8);

    public static int IndexOfLineBreak(ReadOnlySpan<byte> utf8Text) =>
        utf8Text.IndexOfAny(s_newLineBytes);
    // </SnippetBytes>
}

public static class Strings
{
    // <SnippetStrings>
    private static readonly SearchValues<string> s_schemes =
        SearchValues.Create(["http://", "https://", "ftp://"], StringComparison.OrdinalIgnoreCase);

    // Finds the position of the first substring in the set, ignoring case.
    public static int IndexOfScheme(ReadOnlySpan<char> text) =>
        text.IndexOfAny(s_schemes);
    // </SnippetStrings>
}

public static class SingleValues
{
    // <SnippetContains>
    private static readonly SearchValues<char> s_charsToEscape = SearchValues.Create("\\[]+*&,");

    // Each character is inspected as it's written out because the ones in the set
    // expand into two characters. There's no span left to search, so Contains is
    // the right choice here.
    public static void AppendEscaped(StringBuilder builder, ReadOnlySpan<char> identifier)
    {
        foreach (char c in identifier)
        {
            if (s_charsToEscape.Contains(c))
            {
                builder.Append('\\');
            }

            builder.Append(c);
        }
    }
    // </SnippetContains>
}
