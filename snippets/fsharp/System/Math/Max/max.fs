// This example demonstrates Math.Max()
//<snippet1>
open System

let print typ a b m = 
    printfn $"{typ}: The greater of {a,3} and {b,3} is {m}."

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

printfn "Display the greater of two values:\n"
print "Byte   " xByte1 xByte2 (Math.Max(xByte1, xByte2))
print "Int16  " xShort1 xShort2 (Math.Max(xShort1, xShort2))
print "Int32  " xInt1 xInt2 (Math.Max(xInt1, xInt2))
print "Int64  " xLong1 xLong2 (Math.Max(xLong1, xLong2))
print "Single " xSingle1 xSingle2 (Math.Max(xSingle1, xSingle2))
print "Double " xDouble1 xDouble2 (Math.Max(xDouble1, xDouble2))
print "Decimal" xDecimal1 xDecimal2 (Math.Max(xDecimal1, xDecimal2))

printfn "\nThe following types are not CLS-compliant.\n"
print "SByte  " xSbyte1 xSbyte2 (Math.Max(xSbyte1, xSbyte2))
print "UInt16 " xUshort1 xUshort2 (Math.Max(xUshort1, xUshort2))
print "UInt32 " xUint1 xUint2 (Math.Max(xUint1, xUint2))
print "UInt64 " xUlong1 xUlong2 (Math.Max(xUlong1, xUlong2))

// This example produces the following results:
//     Display the greater of two values:
//    
//     Byte   : The greater of   1 and  51 is 51.
//     Int16  : The greater of  -2 and  52 is 52.
//     Int32  : The greater of  -3 and  53 is 53.
//     Int64  : The greater of  -4 and  54 is 54.
//     Single : The greater of   5 and  55 is 55.
//     Double : The greater of   6 and  56 is 56.
//     Decimal: The greater of   7 and  57 is 57.
//    
//     (The following types are not CLS-compliant.)
//    
//     SByte  : The greater of 101 and 111 is 111.
//     UInt16 : The greater of 102 and 112 is 112.
//     UInt32 : The greater of 103 and 113 is 113.
//     UInt64 : The greater of 104 and 114 is 114.
//</snippet1>