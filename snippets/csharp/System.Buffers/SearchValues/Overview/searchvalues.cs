// <SnippetUsings>
using System;
using System.Buffers;
using System.Globalization;
using System.Text;
// </SnippetUsings>

namespace SearchValuesExamples;

public static class Escaping
{
    // <SnippetEscaping>
    // Cache the SearchValues instance in a static readonly field so that the
    // optimized representation is computed once and reused for every search.
    private static readonly SearchValues<char> s_charsToEscape = SearchValues.Create("\"\\\b\f\n\r\t");

    public static void AppendEscaped(StringBuilder builder, ReadOnlySpan<char> value)
    {
        while (true)
        {
            // Find the next character that needs special treatment.
            // IndexOfAny returns -1 when none of the values are present.
            int index = value.IndexOfAny(s_charsToEscape);
            if (index < 0)
            {
                builder.Append(value);
                return;
            }

            // Everything up to that point can be copied in bulk.
            builder.Append(value[..index]);

            builder.Append('\\');
            builder.Append(value[index] switch
            {
                '\b' => 'b',
                '\f' => 'f',
                '\n' => 'n',
                '\r' => 'r',
                '\t' => 't',
                char c => c,
            });

            value = value[(index + 1)..];
        }
    }
    // </SnippetEscaping>
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
    // Bytes that separate fields in the UTF-8 log lines this app reads.
    // A UTF-8 literal ("u8") avoids allocating a string just to create the set.
    private static readonly SearchValues<byte> s_delimiters = SearchValues.Create("\t ,;:|="u8);

    // Finds where the next field ends, or -1 when the last field is reached.
    public static int IndexOfNextDelimiter(ReadOnlySpan<byte> utf8Line) =>
        utf8Line.IndexOfAny(s_delimiters);
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

public static class SingleString
{
    // <SnippetSingleString>
    private static readonly SearchValues<string> s_chunked =
        SearchValues.Create(["chunked"], StringComparison.OrdinalIgnoreCase);

    // Equivalent to text.IndexOf("chunked", StringComparison.OrdinalIgnoreCase),
    // but faster because the value is analyzed once when the instance is created.
    public static int IndexOfChunked(ReadOnlySpan<char> text) =>
        text.IndexOfAny(s_chunked);
    // </SnippetSingleString>
}

public static class SingleValues
{
    // <SnippetContains>
    // Characters that aren't allowed to appear unescaped in the output.
    private static readonly SearchValues<char> s_mustStayEscaped = SearchValues.Create("\"\\\b\f\n\r\t");

    // Turns "\uXXXX" sequences back into the characters they represent, but
    // keeps the ones that must stay escaped as they are.
    public static void AppendDecoded(StringBuilder builder, ReadOnlySpan<char> value)
    {
        while (true)
        {
            int index = value.IndexOf("\\u", StringComparison.Ordinal);
            if (index < 0 || value.Length - index < 6)
            {
                builder.Append(value);
                return;
            }

            builder.Append(value[..index]);

            ReadOnlySpan<char> escaped = value.Slice(index, 6);
            value = value[(index + 6)..];

            // The decoded character is computed one at a time, so there's no span
            // to search and Contains is the right choice here.
            if (!ushort.TryParse(escaped[2..], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out ushort decoded) ||
                s_mustStayEscaped.Contains((char)decoded))
            {
                builder.Append(escaped);
            }
            else
            {
                builder.Append((char)decoded);
            }
        }
    }
    // </SnippetContains>
}
