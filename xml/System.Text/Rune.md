## Remarks

A <xref:System.Text.Rune> instance represents a Unicode scalar value, which means any code point excluding the surrogate range (U+D800..U+DFFF). The type's constructors and conversion operators validate the input, so consumers can call the APIs assuming that the underlying <xref:System.Text.Rune> instance is well-formed.

If you aren't familiar with the terms Unicode scalar value, code point, surrogate range, and well-formed, see [Introduction to character encoding in .NET](/dotnet/standard/base-types/character-encoding-introduction).

The following sections explain:

* [When to use the Rune type](#when-to-use-the-rune-type)
* [When not to use the Rune type](#when-not-to-use-rune)
* [How to instantiate a Rune](#how-to-instantiate-a-rune)
* [How to query properties of a Rune instance](#query-properties-of-a-rune)
* [Convert a `Rune` to UTF-8 or UTF-16](#convert-a-rune-to-utf-8-or-utf-16)

### When to use the Rune type

Consider using the `Rune` type if your code:

* Calls APIs that require Unicode scalar values
* Explicitly handles surrogate pairs

#### APIs that require Unicode scalar values

If your code iterates through the `char` instances in a `string` or a `ReadOnlySpan<char>`, some of the `char` methods won't work correctly on `char` instances that are in the surrogate range. For example, the following APIs require a scalar value `char` to work correctly:

* <xref:System.Char.GetNumericValue%2A?displayProperty=nameWithType>
* <xref:System.Char.GetUnicodeCategory%2A?displayProperty=nameWithType>
* <xref:System.Char.IsDigit%2A?displayProperty=nameWithType>
* <xref:System.Char.IsLetter%2A?displayProperty=nameWithType>
* <xref:System.Char.IsLetterOrDigit%2A?displayProperty=nameWithType>
* <xref:System.Char.IsLower%2A?displayProperty=nameWithType>
* <xref:System.Char.IsNumber%2A?displayProperty=nameWithType>
* <xref:System.Char.IsPunctuation%2A?displayProperty=nameWithType>
* <xref:System.Char.IsSymbol%2A?displayProperty=nameWithType>
* <xref:System.Char.IsUpper%2A?displayProperty=nameWithType>

The following examples show code that won't work correctly if any of the `char` instances are surrogate code points:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/CountLettersInString.cs" id="SnippetBadExample":::

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/CountLettersInSpan.cs" id="SnippetBadExample":::

The preceding code works correctly with some languages such as English:

```csharp
CountLettersInString("Hello")
// Returns 5
```

But it won't work correctly for languages outside the Basic Multilingual Plane, such as Osage:

```csharp
CountLettersInString("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟")
// Returns 0
```

The reason this method returns incorrect results for Osage text is that the `char` instances for Osage letters are surrogate code points. No single surrogate code point has enough information to determine if it's a letter.

If you change this code to use `Rune` instead of `char`, the method works correctly with code points outside the Basic Multilingual Plane:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/CountLettersInString.cs" id="SnippetGoodExample":::

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/CountLettersInSpan.cs" id="SnippetGoodExample":::

The preceding code counts Osage letters correctly:

```csharp
CountLettersInString("𐓏𐓘𐓻𐓘𐓻𐓟 𐒻𐓟")
// Returns 8
```

#### Code that explicitly handles surrogate pairs

Consider using the `Rune` type if your code calls APIs that explicitly operate on surrogate code points, such as the following methods:

* <xref:System.Char.IsSurrogate%2A?displayProperty=nameWithType>
* <xref:System.Char.IsSurrogatePair%2A?displayProperty=nameWithType>
* <xref:System.Char.IsHighSurrogate%2A?displayProperty=nameWithType>
* <xref:System.Char.IsLowSurrogate%2A?displayProperty=nameWithType>
* <xref:System.Char.ConvertFromUtf32%2A?displayProperty=nameWithType>
* <xref:System.Char.ConvertToUtf32%2A?displayProperty=nameWithType>

For example, the following method has special logic to deal with surrogate `char` pairs:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/WorkWithSurrogates.cs" id="SnippetUseChar":::

Such code is simpler if it uses `Rune`, as in the following example:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/WorkWithSurrogates.cs" id="SnippetUseRune":::

### When not to use `Rune`

You don't need to use the `Rune` type if your code:

* Looks for exact `char` matches
* Splits a string on a `known` char value

Using the `Rune` type may return incorrect results if your code:

* Counts the number of display characters in a `string`

#### Look for exact `char` matches

The following code iterates through a `string` looking for specific characters, returning the index of the first match. There's no need to change this code to use `Rune`, as the code is looking for characters that are represented by a single `char`.

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/FindFirstLetter.cs" id="SnippetExample":::

#### Split a string on a known `char`

It's common to call `string.Split` and use delimiters such as `' '` (space) or `','` (comma), as in the following example:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/SplitStringOnChar.cs" id="SnippetExample":::

There is no need to use `Rune` here, because the code is looking for characters that are represented by a single `char`.

#### Count the number of display characters in a `string`

The number of `Rune` instances in a string might not match the number of user-perceivable characters shown when displaying the string.

Since `Rune` instances represent Unicode scalar values, components that follow the [Unicode text segmentation guidelines](https://www.unicode.org/reports/tr29/) can use `Rune` as a building block for counting display characters.

The <xref:System.Globalization.StringInfo> type can be used to count display characters, but in implementations of .NET other than .NET 5 it doesn't count correctly in all scenarios.

For more information, see [Grapheme clusters](/dotnet/standard/base-types/character-encoding-introduction#grapheme-clusters).

### How to instantiate a `Rune`

There are several ways to get a `Rune` instance. You can use a constructor to create a `Rune` directly from:

* A code point.

  :::code language="csharp" source="../../snippets/System.Text/Rune/csharp/InstantiateRunes.cs" id="SnippetCodePoint":::

* A single `char`.

  :::code language="csharp" source="../../snippets/System.Text/Rune/csharp/InstantiateRunes.cs" id="SnippetChar":::

* A surrogate `char` pair.

  :::code language="csharp" source="../../snippets/System.Text/Rune/csharp/InstantiateRunes.cs" id="SnippetSurrogate":::

All of the constructors throw an `ArgumentException` if the input doesn't represent a valid Unicode scalar value.

There are <xref:System.Text.Rune.TryCreate%2A?displayProperty=nameWithType> methods available for callers who don't want exceptions to be thrown on failure.

`Rune` instances can also be read from existing input sequences. For instance, given a `ReadOnlySpan<char>` which represents UTF-16 data, the <xref:System.Text.Rune.DecodeFromUtf16%2A?displayProperty=nameWithType> method returns the first `Rune` instance at the beginning of the input span. The <xref:System.Text.Rune.DecodeFromUtf8%2A?displayProperty=nameWithType> method operates similarly, accepting a `ReadOnlySpan<byte>` parameter that represents UTF-8 data. There are equivalent methods to read from the end of the span instead of the beginning of the span.

### Query properties of a `Rune`

To get the integer code point value of a `Rune` instance, use the <xref:System.Text.Rune.Value?displayProperty=nameWithType> property.

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/InstantiateRunes.cs" id="SnippetValue":::

Many of the static APIs available on the `char` type are also available on the `Rune` type. For instance, <xref:System.Text.Rune.IsWhiteSpace%2A?displayProperty=nameWithType> and <xref:System.Text.Rune.GetUnicodeCategory%2A?displayProperty=nameWithType> are equivalents to <xref:System.Char.IsWhiteSpace%2A?displayProperty=nameWithType> and <xref:System.Char.GetUnicodeCategory%2A?displayProperty=nameWithType> methods. The `Rune` methods correctly handle surrogate pairs.

The following example code takes a `ReadOnlySpan<char>` as input and trims from both the start and the end of the span every `Rune` which isn't a letter or a digit.

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/TrimNonLettersAndNonDigits.cs" id="SnippetExample":::

There are some API differences between `char` and `Rune`. For example:

* There is no `Rune` equivalent  to <xref:System.Char.IsSurrogate(System.Char)?displayProperty=nameWithType>, since `Rune` instances by definition can never be surrogate code points.
* The <xref:System.Text.Rune.GetUnicodeCategory%2A?displayProperty=nameWithType> doesn't always return the same result as <xref:System.Char.GetUnicodeCategory?displayProperty=nameWithType>. It does return the same value as <xref:System.Globalization.CharUnicodeInfo.GetUnicodeCategory%2A?displayProperty=nameWithType>. For more information, see the **Remarks** on <xref:System.Char.GetUnicodeCategory?displayProperty=nameWithType>.

### Convert a `Rune` to UTF-8 or UTF-16

Since a `Rune` is a Unicode scalar value, it can be converted to UTF-8, UTF-16, or UTF-32 encoding. The `Rune` type has built-in support for conversion to UTF-8 and UTF-16.

The <xref:System.Text.Rune.EncodeToUtf16%2A?displayProperty=nameWithType> converts a `Rune` instance to `char` instances. To query the number of `char` instances that would result from converting a `Rune` instance to UTF-16, use the <xref:System.Text.Rune.Utf16SequenceLength?displayProperty=nameWithType> property. Similar methods exist for UTF-8 conversion.

The following example converts a `Rune` instance to a `char` array. The code assumes you have a `Rune` instance in the `rune` variable:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/EncodeRune.cs" id="SnippetUtf16CharArray":::

Since a `string` is a sequence of UTF-16 chars, the following example also converts a `Rune` instance to UTF-16:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/EncodeRune.cs" id="SnippetUtf16String":::

The following example converts a `Rune` instance to a `UTF-8` byte array:

:::code language="csharp" source="../../snippets/System.Text/Rune/csharp/EncodeRune.cs" id="SnippetUtf18ByteArray":::

The <xref:System.Text.Rune.EncodeToUtf16%2A?displayProperty=nameWithType> and <xref:System.Text.Rune.EncodeToUtf8%2A?displayProperty=nameWithType> methods return the actual number of elements written. They throw an exception if the destination buffer is too short to contain the result. There are non-throwing <xref:System.Text.Rune.TryEncodeToUtf8%2A> and <xref:System.Text.Rune.EncodeToUtf16%2A> methods as well for callers who want to avoid exceptions.
