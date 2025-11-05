module tostring

open System.Globalization
open System.Numerics


let callToString1 () =
    // <Snippet1>
    let number = bigint 9867857831128L
    let number = BigInteger.Pow(number, 3) * BigInteger.MinusOne

    let bigIntegerProvider = NumberFormatInfo()
    bigIntegerProvider.NegativeSign <- "~"

    printfn $"{number.ToString(bigIntegerProvider)}"
// </Snippet1>


let callToString2 () =
    // <Snippet2>
    let number = bigint 9867857831128L
    printfn $"""{number.ToString("G")}"""
    printfn $"""{number.ToString("D")}"""
    printfn $"""{number.ToString("X")}"""
// </Snippet2>

let callToString3 () =
    // <Snippet3>
    let bigIntegerFormat = NumberFormatInfo()
    bigIntegerFormat.NegativeSign <- "~"

    let number = BigInteger.MinusOne * bigint 9867857831128L

    printfn $"""{number.ToString("G")}"""
    printfn $"""{number.ToString("D")}"""
    printfn $"""{number.ToString("X")}"""
// </Snippet3>


callToString1 ()
callToString2 ()
callToString3 ()
