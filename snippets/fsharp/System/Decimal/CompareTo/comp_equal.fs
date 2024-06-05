module comp_equal

//<Snippet2>
// Example of the decimal.Compare and static decimal.Equals methods.
open System

let print message obj = printfn $"%-45s{message}{obj}"

// Compare decimal parameters, and display them with the results.
let compareDecimals (left: decimal) (right: decimal) (rightText: string) =
    printfn ""
    print $"right: {rightText}" right
    print "decimal.Equals(left, right)  " (Decimal.Equals(left, right))
    print "decimal.Compare(left, right)  " (Decimal.Compare(left, right))

Console.WriteLine( "This example of the " +
    "decimal.Equals(decimal, decimal) and \n" +
    "decimal.Compare(decimal, decimal) methods " +
    "generates the \nfollowing output. It creates several " +
    "different decimal \nvalues and compares them with " +
    "the following reference value.\n" )

// Create a reference decimal value.
let left = decimal 123.456

print "left: decimal( 123.456 )" left

// Create decimal values to compare with the reference.
compareDecimals left (decimal 1.2345600E+2 ) "decimal(1.2345600E+2)"
compareDecimals left 123.4561M "123.4561M"
compareDecimals left 123.4559M "123.4559M"
compareDecimals left 123.456000M "123.456000M"
compareDecimals left (Decimal(123456000, 0, 0, false, 6uy)) "Decimal(123456000, 0, 0, false, 6)"


// This example of the decimal.Equals(decimal, decimal) and
// decimal.Compare(decimal, decimal) methods generates the
// following output. It creates several different decimal
// values and compares them with the following reference value.

// left: decimal(123.456)                       123.456

// right: decimal(1.2345600E+2)                 123.456
// decimal.Equals(left, right)                  True
// decimal.Compare(left, right)                 0

// right: 123.4561M                             123.4561
// decimal.Equals(left, right)                  False
// decimal.Compare(left, right)                 -1

// right: 123.4559M                             123.4559
// decimal.Equals(left, right)                  False
// decimal.Compare(left, right)                 1

// right: 123.456000M                           123.456000
// decimal.Equals(left, right)                  True
// decimal.Compare(left, right)                 0

// right: decimal(123456000, 0, 0, false, 6)    123.456000
// decimal.Equals(left, right)                  True
// decimal.Compare(left, right)                 0
//</Snippet2> 