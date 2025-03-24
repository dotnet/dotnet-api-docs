//<Snippet1>
// Example of the Decimal fields.
open System

let numberFmt obj1 obj2 = printfn $"{obj1,-25}{obj2,45:N0}"
let exprFmt obj1 obj2 = printfn $"{obj1,-55}{obj2,15}"

printfn "This example of the fields of the Decimal structure \ngenerates the following output.\n"
numberFmt "Field or Expression" "Value"
numberFmt "-------------------" "-----"

// Display the values of the Decimal fields.
numberFmt "Decimal.MaxValue" Decimal.MaxValue
numberFmt "Decimal.MinValue" Decimal.MinValue
numberFmt "Decimal.MinusOne" Decimal.MinusOne
numberFmt "Decimal.One" Decimal.One
numberFmt "Decimal.Zero" Decimal.Zero
printfn ""

// Display the values of expressions of the Decimal fields.
exprFmt "( Decimal.MinusOne + Decimal.One ) == Decimal.Zero" (Decimal.MinusOne + Decimal.One = Decimal.Zero)
exprFmt "Decimal.MaxValue + Decimal.MinValue" (Decimal.MaxValue + Decimal.MinValue)
exprFmt "Decimal.MinValue / Decimal.MaxValue" (Decimal.MinValue / Decimal.MaxValue)
printfn "%-40s%30O" "100000000000000M / Decimal.MaxValue" (100000000000000M / Decimal.MaxValue)


// This example of the fields of the Decimal structure
// generates the following output.
//
// Field or Expression                                              Value
// -------------------                                              -----
// Decimal.MaxValue                79,228,162,514,264,337,593,543,950,335
// Decimal.MinValue               -79,228,162,514,264,337,593,543,950,335
// Decimal.MinusOne                                                    -1
// Decimal.One                                                          1
// Decimal.Zero                                                         0
//
// ( Decimal.MinusOne + Decimal.One ) == Decimal.Zero                True
// Decimal.MaxValue + Decimal.MinValue                                  0
// Decimal.MinValue / Decimal.MaxValue                                 -1
// 100000000000000M / Decimal.MaxValue     0.0000000000000012621774483536
//</Snippet1> 