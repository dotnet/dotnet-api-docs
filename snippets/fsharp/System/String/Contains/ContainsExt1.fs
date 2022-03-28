module ContainsExt1

// <Snippet1>
open System
open System.Runtime.CompilerServices

[<Extension>]
type StringExtensions =
    [<Extension>]
    static member Contains(str: string, substring, comp: StringComparison) =
        if substring = null then
            invalidArg "substring" "substring cannot be null"
        if Enum.IsDefined(typeof<StringComparison>, comp) |> not then
            invalidArg "comp" "comp is not a member of StringComparison"
        str.IndexOf(substring, comp) >= 0                      
// </Snippet1>

// <Snippet2>
let s = "This is a string."
let sub1 = "this"
printfn $"Does '{s}' contain '{sub1}'?"
let comp = StringComparison.Ordinal
printfn $"   {comp:G}: {s.Contains(sub1, comp)}"

let comp2 = StringComparison.OrdinalIgnoreCase
printfn $"   {comp2:G}: {s.Contains(sub1, comp2)}"

// The example displays the following output:
//       Does 'This is a string.' contain 'this'?
//          Ordinal: False
//          OrdinalIgnoreCase: True
// </Snippet2>