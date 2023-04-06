//<snippet1>
// This example demonstrates the CopyTo(Int32, Char[], Int32, Int32) method.

// Typically the destination array is small, preallocated, and global while
// the StringBuilder is large with programmatically defined data.
// However, for this example both the array and StringBuilder are small
// and the StringBuilder has predefined data.

open System.Text

let dest = Array.zeroCreate 6

let src = StringBuilder "abcdefghijklmnopqrstuvwxyz!"
dest[1] <- ')'
dest[2] <- ' '

// Copy the source to the destination in 9 pieces, 3 characters per piece.

printfn "\Piece) Data:"
for i = 0 to 8 do
    dest[0] <- (string i)[0]
    src.CopyTo(i * 3, dest, 3, 3)
    printfn $"    {dest}"

// This example produces the following results:
//       Piece) Data:
//           0) abc
//           1) def
//           2) ghi
//           3) jkl
//           4) mno
//           5) pqr
//           6) stu
//           7) vwx
//           8) yz!
//</snippet1>