module cto_eq_obj

//<Snippet1>
// Example of the decimal.CompareTo and decimal.Equals instance
// methods.
open System

// Get the exception type name remove the namespace prefix.
let getExceptionType (ex: exn) =
    let exceptionType = ex.GetType() |> string
    exceptionType.Substring(exceptionType.LastIndexOf '.'  + 1)

// Compare the decimal to the object parameters,
// and display the object parameters with the results.
let compDecimalToObject (left: decimal) (right: obj) (rightText: string) =
    printfn $"object: %-38s{rightText}{right}"
    printfn $"""%-46s{"left.Equals(object)"}{left.Equals right}"""       
    printf $"""%-46s{"left.CompareTo(object)"}"""

    try
        // Catch the exception if CompareTo( ) throws one.
        printfn $"{left.CompareTo right}\n"
    with ex ->
        printfn $"{getExceptionType ex}\n"

Console.WriteLine(
    "This example of the decimal.Equals( object ) and \n" +
    "decimal.CompareTo( object ) methods generates the \n" +
    "following output. It creates several different " +
    "decimal \nvalues and compares them with the following " +
    "reference value.\n" )

// Create a reference decimal value.
let left = decimal 987.654

printfn $"""{"Left: decimal(987.654)",-46}{left}\n"""

// Create objects to compare with the reference.
compDecimalToObject left (decimal 9.8765400E+2 ) "decimal(9.8765400E+2)"
compDecimalToObject left 987.6541M "987.6541D"
compDecimalToObject left 987.6539M "987.6539D"
compDecimalToObject left (Decimal(987654000, 0, 0, false, 6uy)) "Decimal(987654000, 0, 0, false, 6)"
compDecimalToObject left 9.8765400E+2 "Double 9.8765400E+2"
compDecimalToObject left "987.654" "String \"987.654\""


// This example of the Decimal.Equals(object) and
// Decimal.CompareTo(object) methods generates the
// following output. It creates several different decimal
// values and compares them with the following reference value.
// Left: decimal(987.654)                        987.654
//
// object: decimal(9.8765400E+2)                 987.654
// left.Equals(object)                           True
// left.CompareTo(object)                        0
//
// object: 987.6541D                             987.6541
// left.Equals(object)                           False
// left.CompareTo(object)                        -1
//
// object: 987.6539D                             987.6539
// left.Equals(object)                           False
// left.CompareTo(object)                        1
//
// object: Decimal(987654000, 0, 0, false, 6)    987.654000
// left.Equals(object)                           True
// left.CompareTo(object)                        0
//
// object: Double 9.8765400E+2                   987.654
// left.Equals(object)                           False
// left.CompareTo(object)                        ArgumentException
//
// object: String "987.654"                      987.654
// left.Equals(object)                           False
// left.CompareTo(object)                        ArgumentException
//</Snippet1> 