// This example demonstrates Math.Min()
//<snippet1>
open System

let print typ a b m = 
    printfn $"{typ}: The lesser of {a,3} and {b,3} is {m}."

let xByte1,    xByte2    = 1uy, 51uy
let xShort1,   xShort2   = -2s, 52s
let xInt1,     xInt2     = -3,  53
let xLong1,    xLong2    = -4L, 54L
let xSingle1,  xSingle2  = 5f,  55f
let xDouble1,  xDouble2  = 6.,  56.
let xDecimal1, xDecimal2 = 7m,  57m

// The following types are not CLS-compliant.
let xSbyte1, xSbyte2   = 101y,  111y
let xUshort1, xUshort2 = 102us, 112us
let xUint1, xUint2     = 103u,  113u
let xUlong1, xUlong2   = 104uL, 114uL

printfn "Display the lesser of two values:\n"
print "Byte   " xByte1 xByte2 (Math.Min(xByte1, xByte2))
print "Int16  " xShort1 xShort2 (Math.Min(xShort1, xShort2))
print "Int32  " xInt1 xInt2 (Math.Min(xInt1, xInt2))
print "Int64  " xLong1 xLong2 (Math.Min(xLong1, xLong2))
print "Single " xSingle1 xSingle2 (Math.Min(xSingle1, xSingle2))
print "Double " xDouble1 xDouble2 (Math.Min(xDouble1, xDouble2))
print "Decimal" xDecimal1 xDecimal2 (Math.Min(xDecimal1, xDecimal2))

printfn"\nThe following types are not CLS-compliant:\n"
print "SByte  " xSbyte1 xSbyte2 (Math.Min(xSbyte1, xSbyte2))
print "UInt16 " xUshort1 xUshort2 (Math.Min(xUshort1, xUshort2))
print "UInt32 " xUint1 xUint2 (Math.Min(xUint1, xUint2))
print "UInt64 " xUlong1 xUlong2 (Math.Min(xUlong1, xUlong2))

// This example produces the following results:
//     Display the lesser of two values:
//    
//     Byte   : The lesser of   1 and  51 is 1.
//     Int16  : The lesser of  -2 and  52 is -2.
//     Int32  : The lesser of  -3 and  53 is -3.
//     Int64  : The lesser of  -4 and  54 is -4.
//     Single : The lesser of   5 and  55 is 5.
//     Double : The lesser of   6 and  56 is 6.
//     Decimal: The lesser of   7 and  57 is 7.
//    
//     The following types are not CLS-compliant:
//    
//     SByte  : The lesser of 101 and 111 is 101.
//     UInt16 : The lesser of 102 and 112 is 102.
//     UInt32 : The lesser of 103 and 113 is 103.
//     UInt64 : The lesser of 104 and 114 is 104.
//</snippet1>