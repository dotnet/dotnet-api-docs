module bytelength

//<Snippet1>
open System

let print obj1 obj2 obj3 obj4 = 
    printfn $"{obj1,10}{obj2,20}{obj3,9}{obj4,12}"

let arrayInfo (arr: Array) name =
    let byteLength = Buffer.ByteLength arr

    // Display the array name, type, Length, and ByteLength.
    print name (arr.GetType()) arr.Length byteLength

let bytes = [| 1uy; 2uy; 3uy; 4uy; 5uy; 6uy; 7uy; 8uy; 9uy; 0uy |]
let bools = [| true; false; true; false; true |]
let chars = [| ' '; '$'; '\"'; 'A'; '{' |]
let shorts = [| 258s; 259s; 260s; 261s; 262s; 263s |]
let singles = [| 1f; 678f; 2.37E33f; 0.00415f; 8.9f |]
let doubles = [| 2E-22; 0.003; 4.4E44; 555E55 |]
let longs = [| 1L; 10L; 100L; 1000L; 10000L; 100000L |]

printfn "This example of the Buffer.ByteLength(Array) \nmethod generates the following output.\n"
print "Array name" "Array type" "Length" "ByteLength"
print "----------" "----------" "------" "----------"

// Display the Length and ByteLength for each array.
arrayInfo bytes "bytes" 
arrayInfo bools "bools" 
arrayInfo chars "chars" 
arrayInfo shorts "shorts" 
arrayInfo singles "singles" 
arrayInfo doubles "doubles" 
arrayInfo longs "longs" 


// This example of the Buffer.ByteLength(Array)
// method generates the following output.
//
// Array name          Array type   Length  ByteLength
// ----------          ----------   ------  ----------
//      bytes       System.Byte[]       10          10
//      bools    System.Boolean[]        5           5
//      chars       System.Char[]        5          10
//     shorts      System.Int16[]        6          12
//    singles     System.Single[]        5          20
//    doubles     System.Double[]        4          32
//      longs      System.Int64[]        6          48
//</Snippet1>