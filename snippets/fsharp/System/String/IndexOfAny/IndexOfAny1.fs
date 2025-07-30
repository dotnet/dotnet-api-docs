module IndexOfAny1.fs
// <Snippet1>
let chars = [| 'a'; 'e'; 'i'; 'o'; 'u'; 'y'
               'A'; 'E'; 'I'; 'O'; 'U'; 'Y' |]
let s = "The long and winding road..."
printfn $"The first vowel in \n   {s}\nis found at index {s.IndexOfAny chars}"

// The example displays the following output:
//       The first vowel in
//          The long and winding road...
//       is found at index 2
// </Snippet1>
