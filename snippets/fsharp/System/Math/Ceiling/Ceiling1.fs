open System

let ceilingWithDecimal () =
    // <Snippet1>
    // The ceil and floor functions may be used instead. 
    let values = 
        [ 7.03m; 7.64m; 0.12m; -0.12m; -7.1m; -7.6m ]
    printfn "  Value          Ceiling          Floor\n"
    for value in values do
        printfn $"{value,7} {Math.Ceiling value,16} {Math.Floor value,14}"
    // The example displays the following output to the console:
    //         Value          Ceiling          Floor
    //
    //          7.03                8              7
    //          7.64                8              7
    //          0.12                1              0
    //         -0.12                0             -1
    //          -7.1               -7             -8
    //          -7.6               -7             -8
    // </Snippet1>

let ceilingWithDouble () =
    // <Snippet2>
    // The ceil and floor functions may be used instead.
    let values = 
        [ 7.03; 7.64; 0.12; -0.12; -7.1; -7.6 ]
    printfn "  Value          Ceiling          Floor\n"
    for value in values do
        printfn $"{value,7} {Math.Ceiling value,16} {Math.Floor value,14}"
    // The example displays the following output to the console:
    //         Value          Ceiling          Floor
    //
    //          7.03                8              7
    //          7.64                8              7
    //          0.12                1              0
    //         -0.12                0             -1
    //          -7.1               -7             -8
    //          -7.6               -7             -8
    // </Snippet2>
ceilingWithDecimal ()
printfn ""
ceilingWithDouble ()