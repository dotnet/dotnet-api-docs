module IndexOfAny1.fs
// <Snippet1>
let chars = [| 'a'; 'e'; 'i'; 'o'; 'u'; 'y'
               'A'; 'E'; 'I'; 'O'; 'U'; 'Y' |]
let s = "The long and winding road..."
printfn $"The first vowel in \n   {s}\nis found at position {s.IndexOfAny chars + 1}"
// The example displays the following output:
//       The first vowel in
//          The long and winding road...
//       is found at position 3
// </Snippet1>
