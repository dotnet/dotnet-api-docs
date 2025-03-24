//<snippet1>
// This example demonstrates the Char.IsLowSurrogate() method
//                                    IsHighSurrogate() method
//                                    IsSurrogatePair() method
open System

let cHigh = '\uD800'
let cLow  = '\uDC00'
let s1 = String [| 'a'; '\uD800'; '\uDC00'; 'z' |]
let divider = String.Concat(Environment.NewLine, String('-', 70), Environment.NewLine)

printfn $"""
Hexadecimal code point of the character, cHigh: {int cHigh:X4}
Hexadecimal code point of the character, cLow:  {int cLow:X4}

Characters in string, s1: 'a', high surrogate, low surrogate, 'z'
Hexadecimal code points of the characters in string, s1: """

for i = 0 to s1.Length - 1 do
    printfn $"s1[{i}] = {int s1[i]:X4} "

printfn $"""{divider}
Is each of the following characters a high surrogate?
A1) cLow?  - {Char.IsHighSurrogate cLow}
A2) cHigh? - {Char.IsHighSurrogate cHigh}
A3) s1[0]? - {Char.IsHighSurrogate(s1, 0)}
A4) s1[1]? - {Char.IsHighSurrogate(s1, 1)}
{divider}"""

printfn $"""Is each of the following characters a low surrogate?
B1) cLow?  - {Char.IsLowSurrogate cLow}
B2) cHigh? - {Char.IsLowSurrogate cHigh}
B3) s1[0]? - {Char.IsLowSurrogate(s1, 0)}
B4) s1[2]? - {Char.IsLowSurrogate(s1, 2)}
{divider}"""

printfn $"""Is each of the following pairs of characters a surrogate pair?
C1) cHigh and cLow?  - {Char.IsSurrogatePair(cHigh, cLow)}
C2) s1[0] and s1[1]? - {Char.IsSurrogatePair(s1, 0)}
C3) s1[1] and s1[2]? - {Char.IsSurrogatePair(s1, 1)}
C4) s1[2] and s1[3]? - {Char.IsSurrogatePair(s1, 2)}"
{divider}"""

// This example produces the following results:
//
// Hexadecimal code point of the character, cHigh: D800
// Hexadecimal code point of the character, cLow:  DC00
//
// Characters in string, s1: 'a', high surrogate, low surrogate, 'z'
// Hexadecimal code points of the characters in string, s1:
// s1[0] = 0061
// s1[1] = D800
// s1[2] = DC00
// s1[3] = 007A
//
// ----------------------------------------------------------------------
//
// Is each of the following characters a high surrogate?
// A1) cLow?  - False
// A2) cHigh? - True
// A3) s1[0]? - False
// A4) s1[1]? - True
//
// ----------------------------------------------------------------------
//
// Is each of the following characters a low surrogate?
// B1) cLow?  - True
// B2) cHigh? - False
// B3) s1[0]? - False
// B4) s1[2]? - True
//
// ----------------------------------------------------------------------
//
// Is each of the following pairs of characters a surrogate pair?
// C1) cHigh and cLow?  - True
// C2) s1[0] and s1[1]? - False
// C3) s1[1] and s1[2]? - True
// C4) s1[2] and s1[3]? - False
//
// ----------------------------------------------------------------------
//</snippet1>