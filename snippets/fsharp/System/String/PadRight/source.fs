module source

// <Snippet1>
let str = "BBQ and Slaw"

printf "|"
printf $"{str.PadRight 15}"
printfn "|"       // Displays "|BBQ and Slaw   |".

printf "|"
printf $"{str.PadRight 5}"
printfn "|"       // Displays "|BBQ and Slaw|".
// </Snippet1>