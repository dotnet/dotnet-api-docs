module bytesint16

//<Snippet3>
open System

let print obj1 obj2 = printfn $"{obj1,10}{obj2,13}"

// Convert a short argument to a byte array and display it.
let getBytesInt16 (argument: int16) =
    let byteArray = BitConverter.GetBytes argument

    BitConverter.ToString byteArray
    |> print argument 

printfn "This example of the BitConverter.GetBytes(int16) \nmethod generates the following output.\n"
print "short" "byte array"
print "-----" "----------"

// Convert short values and display the results.
getBytesInt16 0s
getBytesInt16 15s
getBytesInt16 -15s
getBytesInt16 10000s
getBytesInt16 -10000s
getBytesInt16 Int16.MinValue
getBytesInt16 Int16.MaxValue


// This example of the BitConverter.GetBytes(int16)
// method generates the following output.
//
//      short   byte array
//      -----   ----------
//          0        00-00
//         15        0F-00
//        -15        F1-FF
//      10000        10-27
//     -10000        F0-D8
//     -32768        00-80
//      32767        FF-7F
//</Snippet3>