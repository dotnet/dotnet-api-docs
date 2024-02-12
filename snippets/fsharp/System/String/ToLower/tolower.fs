module tolower

//<snippet1>
// Sample for String.ToLower(CultureInfo)

open System
open System.Globalization

let codePoints title s =
     printf $"{Environment.NewLine}The code points in {title} are: {Environment.NewLine}"
     for u in s do
          printf $"{u:x4} "
     printfn ""

let str1 = "INDIGO"
// str2 = str1, except each 'I' is '\u0130' (Unicode LATIN CAPITAL I WITH DOT ABOVE).
let str2 = String [| '\u0130'; 'N'; 'D'; '\u0130'; 'G'; 'O' |]

printfn $"\nstr1 = '{str1}'\n"

printfn $"""str1 is {if 0 = String.CompareOrdinal(str1, str2) then "equal" else "not equal"} to str2."""
codePoints "str1" str1
codePoints "str2" str2

// str3 is a lower case copy of str2, using English-United States culture.
printfn "\nstr3 = Lower case copy of str2 using English-United States culture."
let str3 = str2.ToLower(CultureInfo("en-US", false))

// str4 is a lower case copy of str2, using Turkish-Turkey culture.
printfn "str4 = Lower case copy of str2 using Turkish-Turkey culture."
let str4 = str2.ToLower(CultureInfo("tr-TR", false))

// Compare the code points in str3 and str4.
printfn $"""\nstr3 is {if 0 = String.CompareOrdinal(str3, str4) then "equal" else "not equal"} to str4."""
     
codePoints "str3" str3
codePoints "str4" str4

(*
This example produces the following results:

str1 = 'INDIGO'

str1 is not equal to str2.

The code points in str1 are:
0049 004e 0044 0049 0047 004f

The code points in str2 are:
0130 004e 0044 0130 0047 004f

str3 = Lower case copy of str2 using English-United States culture.
str4 = Lower case copy of str2 using Turkish-Turkey culture.

str3 is equal to str4.

The code points in str3 are:
0069 006e 0064 0069 0067 006f

The code points in str4 are:
0069 006e 0064 0069 0067 006f
*)
//</snippet1>