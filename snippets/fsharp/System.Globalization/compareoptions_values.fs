module compareoptions_values

open System
open System.Globalization

let testStringEquality (str1: string) (str2: string) (description: string) (options: CompareOptions) =
    printfn "\n%s:" description

    let compareAndPrint opts =
        let result = String.Compare(str1, str2, CultureInfo.InvariantCulture, opts)
        let equalityStatus = if result = 0 then "equal" else "not equal"
        printfn "  When using CompareOptions.%A, \"%s\" and \"%s\" are %s." opts str1 str2 equalityStatus

    compareAndPrint CompareOptions.None
    compareAndPrint options

[<EntryPoint>]
let main argv =
    // Uppercase and lowercase characters are equivalent (according to the culture rules) when IgnoreCase is used.
    testStringEquality "ONE two" "one TWO" "Case sensitivity" CompareOptions.IgnoreCase

    // Punctuation is ignored with the IgnoreSymbols option.
    testStringEquality "hello world" "hello, world!" "Punctuation" CompareOptions.IgnoreSymbols

    // Whitespace and mathematical symbols are also ignored with IgnoreSymbols.
    testStringEquality "3 + 5 = 8" "358" "Whitespace and mathematical symbols" CompareOptions.IgnoreSymbols

    // Caution: currency symbols and thousands separators are ignored with IgnoreSymbols.
    // Parse strings containing numbers/currency and compare them numerically instead.
    testStringEquality "Total $15,000" "Total: £150.00" "Currency symbols, decimals and thousands separators" CompareOptions.IgnoreSymbols

    // Full width characters are common in East Asian languages. Use the IgnoreWidth
    // option to treat full- and half-width characters as equal.
    testStringEquality "ａｂｃ，－" "abc,-" "Half width and full width characters" CompareOptions.IgnoreWidth

    // The same string in Hiragana and Katakana is equal when IgnoreKanaType is used.
    testStringEquality "ありがとう" "アリガトウ" "Hiragana and Katakana strings" CompareOptions.IgnoreKanaType

    // When comparing with the IgnoreNonSpace option, characters like diacritical marks are ignored.
    testStringEquality "café" "cafe" "Diacritical marks" CompareOptions.IgnoreNonSpace

    // Ligature characters and their non-ligature forms compare equal with the IgnoreNonSpace option.
    // Note: prior to .NET 5, ligature characters were equal to their expanded forms by default.
    testStringEquality "straße œuvre cæsar" "strasse oeuvre caesar" "Ligature characters" CompareOptions.IgnoreNonSpace

    0 // return an integer exit code

(*
In .NET 5 and later, the output will be the following:

Case sensitivity:
  When using CompareOptions.None, "ONE two" and "one TWO" are not equal.
  When using CompareOptions.IgnoreCase, "ONE two" and "one TWO" are equal.

Punctuation:
  When using CompareOptions.None, "hello world" and "hello, world!" are not equal.
  When using CompareOptions.IgnoreSymbols, "hello world" and "hello, world!" are equal.

Whitespace and mathematical symbols:
  When using CompareOptions.None, "3 + 5 = 8" and "358" are not equal.
  When using CompareOptions.IgnoreSymbols, "3 + 5 = 8" and "358" are equal.

Currency symbols, decimals and thousands separators:
  When using CompareOptions.None, "Total $15,000" and "Total: £150.00" are not equal.
  When using CompareOptions.IgnoreSymbols, "Total $15,000" and "Total: £150.00" are equal.

Half width and full width characters:
  When using CompareOptions.None, "ａｂｃ，－" and "abc,-" are not equal.
  When using CompareOptions.IgnoreWidth, "ａｂｃ，－" and "abc,-" are equal.

Hiragana and Katakana strings:
  When using CompareOptions.None, "ありがとう" and "アリガトウ" are not equal.
  When using CompareOptions.IgnoreKanaType, "ありがとう" and "アリガトウ" are equal.

Diacritical marks:
  When using CompareOptions.None, "café" and "cafe" are not equal.
  When using CompareOptions.IgnoreNonSpace, "café" and "cafe" are equal.

Ligature characters:
  When using CompareOptions.None, "straße œuvre cæsar" and "strasse oeuvre caesar" are not equal.
  When using CompareOptions.IgnoreNonSpace, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.


Note: when using .NET versions prior to .NET 5, ligature characters compare as equal to their
non-ligature counterparts by default, so the last test will output as follows:

Ligature characters:
  When using CompareOptions.None, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.
  When using CompareOptions.IgnoreNonSpace, "straße œuvre cæsar" and "strasse oeuvre caesar" are equal.
*)
