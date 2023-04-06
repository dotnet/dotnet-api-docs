// <Snippet1>
// Embed an array of characters in a string
let strSource = "changed"
let destination = 
    [| 'T'; 'h'; 'e'; ' '; 'i'; 'n'; 'i'; 't'; 'i'; 'a'; 'l'; ' ';
       'a'; 'r'; 'r'; 'a'; 'y' |]

// Print the char array
printfn $"{destination}"

// Embed the source string in the destination string
strSource.CopyTo( 0, destination, 4, strSource.Length)

// Print the resulting array
printfn $"{destination}"

let strSource2 = "A different string"

// Embed only a section of the source string in the destination
strSource2.CopyTo( 2, destination, 3, 9)

// Print the resulting array
printfn $"{destination}"
// The example displays the following output:
//       The initial array
//       The changed array
//       Thedifferentarray
// </Snippet1>