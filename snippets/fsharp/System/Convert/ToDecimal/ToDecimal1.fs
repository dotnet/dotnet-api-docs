module ToDecimal1

open System

let convertSingleToDecimal () =
    // <Snippet1>
    printfn $"{Convert.ToDecimal 1234567500.12F}"  // Displays 1234568000
    printfn $"{Convert.ToDecimal 1234568500.12F}"  // Displays 1234568000

    printfn $"{Convert.ToDecimal 10.980365F}"      // Displays 10.98036
    printfn $"{Convert.ToDecimal 10.980355F}"      // Displays 10.98036
    // </Snippet1>

let convertDoubleToDecimal () =
    // <Snippet2>
    printfn $"{Convert.ToDecimal 123456789012345500.12}"  // Displays 123456789012346000
    printfn $"{Convert.ToDecimal 123456789012346500.12}"  // Displays 123456789012346000

    printfn $"{Convert.ToDecimal 10030.12345678905}"      // Displays 10030.123456789
    printfn $"{Convert.ToDecimal 10030.12345678915}"      // Displays 10030.1234567892
    // </Snippet2>


convertSingleToDecimal ()
convertDoubleToDecimal ()

