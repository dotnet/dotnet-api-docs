module stringcompareordinal

//<Snippet1>
open System
open System.Globalization

[<EntryPoint>]
let main _ =
    let strLow = "abc"
    let strCap = "ABC"
    let result = "equal to "
    let pos = 1

    // The Unicode codepoint for 'b' is greater than the codepoint for 'B'.
    let x = String.CompareOrdinal(strLow, pos, strCap, pos, 1)
    let result =
        if x < 0 then "less than"
        elif x > 0 then "greater than"
        else "equal to"
    printfn $"CompareOrdinal(\"{strLow}\"[{pos}], \"{strCap}\"[{pos}]):"
    printfn $"   '{strLow[pos]}' is {result} '{strCap[pos]}'"

    // In U.S. English culture, 'b' is linguistically less than 'B'.
    let x = String.Compare(strLow, pos, strCap, pos, 1, false, new CultureInfo("en-US"))
    let result =
        if x < 0 then "less than"
        elif x > 0 then "greater than"
        else "equal to"
    printfn $"Compare(\"{strLow}\"[{pos}], \"{strCap}\"[{pos}]):"
    printfn $"   '{strLow[pos]}' is {result} '{strCap[pos]}'"
    0
//</Snippet1>