module getbyte

//<Snippet3>
open System

let print obj1 obj2 obj3 obj4 = printfn $"{obj1,10}{obj2,10}{obj3,9} {obj4}"

// Display the array contents in hexadecimal.
let inline displayArray (arr: ^a []) name =
    // Get the array element width; format the formatting string.
    let elemWidth = Buffer.ByteLength arr / arr.Length

    // Display the array elements from right to left.
    printf $"{name,5}:"
    for i = arr.Length - 1 downto 0 do
        printf " %0*X" (2 * elemWidth) arr[i]
    printfn ""

let arrayInfo (arr: Array) name index =
    let value = Buffer.GetByte(arr, index)

    // Display the array name, index, and byte to be viewed.
    print name index value $"0x{value:X2}"

// These are the arrays to be viewed with GetByte.
let longs =
    [| 333333333333333333L; 666666666666666666L; 999999999999999999L |]
let ints =
    [| 111111111; 222222222; 333333333; 444444444; 555555555 |]

printfn "This example of the Buffer.GetByte(Array, int) \nmethod generates the following output.\nNote: The arrays are displayed from right to left.\n"
printfn "  Values of arrays:\n"

// Display the values of the arrays.
displayArray longs "longs"
displayArray ints "ints"
printfn ""

print "Array" "index" "value" ""
print "-----" "-----" "-----" "----"

// Display the Length and ByteLength for each array.
arrayInfo ints "ints" 0
arrayInfo ints "ints" 7
arrayInfo ints "ints" 10
arrayInfo ints "ints" 17
arrayInfo longs "longs" 0
arrayInfo longs "longs" 6
arrayInfo longs "longs" 10
arrayInfo longs "longs" 17
arrayInfo longs "longs" 21


// This example of the Buffer.GetByte( Array, int )
// method generates the following output.
// Note: The arrays are displayed from right to left.
//
//   Values of arrays:
//
// longs: 0DE0B6B3A763FFFF 094079CD1A42AAAA 04A03CE68D215555
//  ints: 211D1AE3 1A7DAF1C 13DE4355 0D3ED78E 069F6BC7
//
//      Array     index    value
//      -----     -----    ----- ----
//       ints         0      199 0xC7
//       ints         7       13 0x0D
//       ints        10      222 0xDE
//       ints        17       26 0x1A
//      longs         0       85 0x55
//      longs         6      160 0xA0
//      longs        10       66 0x42
//      longs        17      255 0xFF
//      longs        21      182 0xB6
//</Snippet3>