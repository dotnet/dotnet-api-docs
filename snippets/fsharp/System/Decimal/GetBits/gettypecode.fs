module gettypecode

//<Snippet3>
// Example of the Decimal.GetTypeCode method.
open System

printfn $"This example of the decimal.GetTypeCode() \nmethod generates the following output.\n"

// Create a decimal object and get its type code.
let aDecimal = Decimal 1.0
let typCode = aDecimal.GetTypeCode()

printfn $"Type Code:      \"{typCode}\""
printfn $"Numeric value:  {int typCode}"


// This example of the decimal.GetTypeCode()
// method generates the following output.
//
// Type Code:      "Decimal"
// Numeric value:  15
//</Snippet3> 