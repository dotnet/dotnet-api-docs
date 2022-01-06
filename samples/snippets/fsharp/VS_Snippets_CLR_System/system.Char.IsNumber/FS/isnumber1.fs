module isnumber1

open System

let overload1 () =
    // <Snippet1>
    let utf32 = 0x10107      // AEGEAN NUMBER ONE
    let surrogate = Char.ConvertFromUtf32 utf32
    for ch in surrogate do
        printfn $"U+{Convert.ToUInt16 ch:X4}: {Char.IsNumber ch}"

    // The example displays the following output:
    //       U+D800: False
    //       U+DD07: False
    // </Snippet1>

let overload2 () =
    // <Snippet2>
    let utf32 = 0x10107      // AEGEAN NUMBER ONE
    let surrogate = Char.ConvertFromUtf32 utf32
    for i = 0 to surrogate.Length - 1 do
        printfn $"U+{Convert.ToUInt16 surrogate[i]:X4} at position {i}: {Char.IsNumber(surrogate, i)}"
                        
    // The example displays the following output:
    //       U+D800 at position 0: True
    //       U+DD07 at position 1: False
    //  </Snippet2>

overload1 ()
printfn ""
overload2 ()