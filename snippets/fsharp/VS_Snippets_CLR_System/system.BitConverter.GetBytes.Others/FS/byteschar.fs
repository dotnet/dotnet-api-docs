module byteschar

//<Snippet2>
open System

let print obj1 obj2 =
    printfn $"{obj1,10}{obj2,16}"

// Convert a char argument to a byte array and display it.
let getBytesChar (argument: char) =
    let byteArray = BitConverter.GetBytes argument
    
    BitConverter.ToString byteArray
    |> print argument

printfn "This example of the BitConverter.GetBytes(char) \nmethod generates the following output.\r\n"
print "char" "byte array"
print "----" "----------"

// Convert char values and display the results.
getBytesChar '\000'
getBytesChar ' '
getBytesChar '*'
getBytesChar '3'
getBytesChar 'A'
getBytesChar '['
getBytesChar 'a'
getBytesChar '{'


// This example of the BitConverter.GetBytes(char)
// method generates the following output.
//
//       char      byte array
//       ----      ----------
//                      00-00
//                      20-00
//          *           2A-00
//          3           33-00
//          A           41-00
//          [           5B-00
//          a           61-00
//          {           7B-00
//</Snippet2>