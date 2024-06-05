module writeline_obj1

open System

// <Snippet3>
let values: obj [] = 
    [| true; 12.632; 17908; "stringValue"; 'a'; 16907.32M |]

for value in values do
   Console.WriteLine value

// The example displays the following output:
//    True
//    12.632
//    17908
//    stringValue
//    a
//    16907.32
// </Snippet3>