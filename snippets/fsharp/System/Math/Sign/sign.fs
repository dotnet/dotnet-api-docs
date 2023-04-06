//<snippet1>
// This example demonstrates Math.Sign()
// In F#, the sign function may be used instead
open System

let test = function
    | 0 ->
        "equal to"
    | x when x < 0 ->
        "less than"
    | _ ->
        "greater than"

let print typ a b = 
    printfn $"{typ}: {a,3} is {b} zero."

let xByte1    = 0uy
let xShort1   = -2s
let xInt1     = -3
let xLong1    = -4L
let xSingle1  = 0f
let xDouble1  = 6.
let xDecimal1 = -7m
let xIntPtr1  = 8

// The following type is not CLS-compliant.
let xSbyte1   = -101y

printfn "\nTest the sign of the following types of values:"
print "Byte   " xByte1 (test (Math.Sign xByte1))
print "Int16  " xShort1 (test (Math.Sign xShort1))
print "Int32  " xInt1 (test (Math.Sign xInt1))
print "Int64  " xLong1 (test (Math.Sign xLong1))
print "Single " xSingle1 (test (Math.Sign xSingle1))
print "Double " xDouble1 (test (Math.Sign xDouble1))
print "Decimal" xDecimal1 (test (Math.Sign xDecimal1))
print "IntPtr"  xIntPtr1 (test (Math.Sign xIntPtr1))

printfn "\nThe following type is not CLS-compliant."
print "SByte  " xSbyte1 (test (Math.Sign xSbyte1))

// This example produces the following results:
//     Test the sign of the following types of values:
//     Byte   :   0 is equal to zero.
//     Int16  :  -2 is less than zero.
//     Int32  :  -3 is less than zero.
//     Int64  :  -4 is less than zero.
//     Single :   0 is equal to zero.
//     Double :   6 is greater than zero.
//     Decimal:  -7 is less than zero.
//     IntPtr:    8 is greater than zero.
//    
//     The following type is not CLS-compliant.
//     SByte  : -101 is less than zero.
//</snippet1>