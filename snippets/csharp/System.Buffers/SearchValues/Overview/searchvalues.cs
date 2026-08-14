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
    // Bytes that must be escaped in a JSON string: the quote, the backslash,
    // and every control character. A UTF-8 literal ("u8") avoids allocating a
    // string just to create the set.
    private static readonly SearchValues<byte> s_bytesToEscape = SearchValues.Create(
        "\"\\"u8 +
        "\u0000\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u000A\u000B\u000C\u000D\u000E\u000F"u8 +
        "\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F"u8);

    public static bool NeedsEscaping(ReadOnlySpan<byte> utf8Value) =>
        utf8Value.ContainsAny(s_bytesToEscape);
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
    // Characters that change the meaning of a URI, so they must stay escaped.
    private static readonly SearchValues<char> s_notSafeToUnescape = SearchValues.Create("#%/:?@[]\\");

    public static void AppendUnescaped(StringBuilder builder, ReadOnlySpan<char> value)
    {
        while (true)
        {
            int index = value.IndexOf('%');
            if (index < 0 || value.Length - index < 3)
            {
                builder.Append(value);
                return;
            }

            builder.Append(value[..index]);

            ReadOnlySpan<char> escaped = value.Slice(index, 3);
            value = value[(index + 3)..];

            // The decoded character is computed one at a time, so there's no span
            // to search and Contains is the right choice here.
            if (!int.TryParse(escaped[1..], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int codePoint) ||
                s_notSafeToUnescape.Contains((char)codePoint))
            {
                builder.Append(escaped);
            }
            else
            {
                builder.Append((char)codePoint);
            }
        }
    }
    // </SnippetContains>
}
