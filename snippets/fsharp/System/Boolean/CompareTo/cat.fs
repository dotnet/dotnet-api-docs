//<snippet1>
// This example demonstrates the generic and non-generic versions of the
// CompareTo method for several base types.
// The non-generic version takes a parameter of type Object, while the generic
// version takes a type-specific parameter, such as Boolean, Int32, or Double.
open System

let show caption (var1: obj) (var2: obj) resultGeneric resultNonGeneric =
    printf "%s" caption
    if resultGeneric = resultNonGeneric then
        let relation =
            if resultGeneric < 0 then "less than"
            elif resultGeneric > 0 then "greater than"
            else "equal to"
        printfn $"{var1} is {relation} {var2}"

    // The following condition will never occur because the generic and non-generic
    // CompareTo methods are equivalent.
    else
        printfn $"Generic CompareTo = {resultGeneric} non-generic CompareTo = {resultNonGeneric}"

let now = DateTime.Now
// Time span = 11 days, 22 hours, 33 minutes, 44 seconds
let tsX = TimeSpan(11, 22, 33, 44)
// Version = 1.2.333.4
let versX = Version "1.2.333.4"
// Guid = CA761232-ED42-11CE-BACD-00AA0057B223
let guidX = Guid "{CA761232-ED42-11CE-BACD-00AA0057B223}"

let a1, a2 = true, true
let b1, b2 = 1uy, 1uy
let c1, c2 = -2s, 2s
let d1, d2 = 3, 3
let e1, e2 = 4L, -4L
let f1, f2 = -5.5m, 5.5m
let g1, g2 = 6.6f, 6.6f
let h1, h2 = 7.7, -7.7
let i1, i2 = 'A', 'A'
let j1, j2 = "abc", "abc"
let k1, k2 = now, now
let l1, l2 = tsX, tsX
let m1, m2 = versX, Version "2.0"
let n1, n2 = guidX, guidX

// The following types are not CLS-compliant.
let w1, w2 = 8y, 8y
let x1, x2 = 9us, 9us
let y1, y2 = 10u, 10u
let z1, z2 = 11uL, 11uL

printfn "\nThe following is the result of using the generic and non-generic\nversions of the CompareTo method for several base types:\n"
try
    // The second and third show function call parameters are automatically boxed because
    // the second and third show function declaration arguments expect type Object.
    show "Boolean:  " a1 a2 (a1.CompareTo a2) (a1.CompareTo (a2 :> obj))

    show "Byte:     " b1 b2 (b1.CompareTo b2) (b1.CompareTo (b2 :> obj))
    show "Int16:    " c1 c2 (c1.CompareTo c2) (c1.CompareTo (c2 :> obj))
    show "Int32:    " d1 d2 (d1.CompareTo d2) (d1.CompareTo (d2 :> obj))
    show "Int64:    " e1 e2 (e1.CompareTo e2) (e1.CompareTo (e2 :> obj))
    show "Decimal:  " f1 f2 (f1.CompareTo f2) (f1.CompareTo (f2 :> obj))
    show "Single:   " g1 g2 (g1.CompareTo g2) (g1.CompareTo (g2 :> obj))
    show "Double:   " h1 h2 (h1.CompareTo h2) (h1.CompareTo (h2 :> obj))
    show "Char:     " i1 i2 (i1.CompareTo i2) (i1.CompareTo (i2 :> obj))
    show "String:   " j1 j2 (j1.CompareTo j2) (j1.CompareTo (j2 :> obj))
    show "DateTime: " k1 k2 (k1.CompareTo k2) (k1.CompareTo (k2 :> obj))
    show "TimeSpan: " l1 l2 (l1.CompareTo l2) (l1.CompareTo (l2 :> obj))
    show "Version:  " m1 m2 (m1.CompareTo m2) (m1.CompareTo (m2 :> obj))
    show "Guid:     " n1 n2 (n1.CompareTo n2) (n1.CompareTo (n2 :> obj))

    printfn "\nThe following types are not CLS-compliant:"
    show "SByte:    " w1 w2 (w1.CompareTo w2) (w1.CompareTo (w2 :> obj))
    show "UInt16:   " x1 x2 (x1.CompareTo x2) (x1.CompareTo (x2 :> obj))
    show "UInt32:   " y1 y2 (y1.CompareTo y2) (y1.CompareTo (y2 :> obj))
    show "UInt64:   " z1 z2 (z1.CompareTo z2) (z1.CompareTo (z2 :> obj))
with e -> printfn $"{e}"


// This example produces the following results:
// The following is the result of using the generic and non-generic versions of the
// CompareTo method for several base types:
// Boolean:  True is equal to True
// Byte:     1 is equal to 1
// Int16:    -2 is less than 2
// Int32:    3 is equal to 3
// Int64:    4 is greater than -4
// Decimal:  -5.5 is less than 5.5
// Single:   6.6 is equal to 6.6
// Double:   7.7 is greater than -7.7
// Char:     A is equal to A
// String:   abc is equal to abc
// DateTime: 12/1/2003 5:37:46 PM is equal to 12/1/2003 5:37:46 PM
// TimeSpan: 11.22:33:44 is equal to 11.22:33:44
// Version:  1.2.333.4 is less than 2.0
// Guid:     ca761232-ed42-11ce-bacd-00aa0057b223 is equal to ca761232-ed42-11ce-bacd-00
// aa0057b223
// The following types are not CLS-compliant:
// SByte:    8 is equal to 8
// UInt16:   9 is equal to 9
// UInt32:   10 is equal to 10
// UInt64:   11 is equal to 11
//</snippet1>