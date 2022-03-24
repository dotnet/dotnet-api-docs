//<snippet1>
// This code example demonstrates the
// Nullable<T>.GetValueOrDefault methods.
open System

// Display the values of two nullable of System.Single structures.
// The printfn string interpolation automatically calls the ToString methods of
// each input argument to display its values. If no value is defined for a
// nullable type, the ToString method for that argument returns the empty
// string ("").
let display title dspMySingle dspYourSingle =
    printfn $"{title}) mySingle = [{dspMySingle}], yourSingle = [{dspYourSingle}]"

let mySingle = Nullable 12.34f
let yourSingle = Nullable -1f

[<EntryPoint>]
let main _ =
    printfn "*** Display a value or the default value ***\n"
    // Display the values of mySingle and yourSingle.

    display "A1" mySingle yourSingle

    // Shadow the value of mySingle to yourSingle, then display the values
    // of mySingle and yourSingle. The yourSingle variable is assigned the
    // value 12.34 because mySingle has a value.

    let yourSingle = mySingle.GetValueOrDefault()
    display "A2" mySingle yourSingle

    // Shadow null (Nothing in Visual Basic) to mySingle, which means no value is
    // defined for mySingle. Then assign the value of mySingle to yourSingle and
    // display the values of both variables. The default value of all binary zeroes
    // is assigned to yourSingle because mySingle has no value.

    let mySingle = Nullable()
    let yourSingle = mySingle.GetValueOrDefault()
    display "A3" mySingle yourSingle

    // Shadow the original values of mySingle and yourSingle.
    let mySingle = Nullable 12.34f
    let yourSingle = Nullable -1.0f

    printf "\n*** Display a value or the "
    printfn "specified default value ***\n"

    // Display the values of mySingle and yourSingle.
    display "B1" mySingle yourSingle

    // Shadow the value of mySingle to yourSingle, then display the values
    // of mySingle and yourSingle. The yourSingle variable is assigned the
    // value 12.34 because mySingle has a value.

    let yourSingle = mySingle.GetValueOrDefault -222.22f
    display "B2" mySingle yourSingle

    // Shadow null (Nothing in Visual Basic) to mySingle, which means no value is
    // defined for mySingle. Then shadow the value of mySingle to yourSingle and
    // display the values of both variables. The specified default value of -333.33
    // is assigned to yourSingle because mySingle has no value.

    let mySingle = Nullable()
    let yourSingle = mySingle.GetValueOrDefault -333.33f
    display "B3" mySingle yourSingle
    0

// This code example produces the following results:
//     A1) mySingle = [12.34], yourSingle = [-1]
//     A2) mySingle = [12.34], yourSingle = [12.34]
//     A3) mySingle = [], yourSingle = [0]
//     
//     *** Display a value or the specified default value ***
//     
//     B1) mySingle = [12.34], yourSingle = [-1]
//     B2) mySingle = [12.34], yourSingle = [12.34]
//     B3) mySingle = [], yourSingle = [-333.33]
//</snippet1>