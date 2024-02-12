module toupper

// <Snippet1>
open System
open System.Globalization

let str1 = "indigo"

let showCodePoints varName s =
    printf $"%s{varName} = %s{s}: "
    for u in s do
        printf $"{uint16 u:x4} "
    printfn ""

// str2 is an uppercase copy of str1, using English-United States culture.
let str2 = str1.ToUpper(CultureInfo("en-US", false))

// str3 is an uppercase copy of str1, using Turkish-Turkey culture.
let str3 = str1.ToUpper(CultureInfo("tr-TR", false))

// Compare the code points and compare the uppercase strings.
showCodePoints "str2" str2
showCodePoints "str1" str1
showCodePoints "str3" str3
printfn $"""str2 is {if String.CompareOrdinal(str2, str3) = 0 then "equal" else "not equal"} to str3."""
// This example displays the following output:
//       str1 = indigo: 0069 006e 0064 0069 0067 006f
//       str2 = INDIGO: 0049 004e 0044 0049 0047 004f
//       str3 = İNDİGO: 0130 004e 0044 0130 0047 004f
//       str2 is not equal to str3.
// </Snippet1>