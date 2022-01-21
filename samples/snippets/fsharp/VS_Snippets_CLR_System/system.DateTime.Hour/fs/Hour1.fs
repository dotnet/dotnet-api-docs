open System

// <Snippet1>
let date1 = DateTime(2008, 4, 1, 18, 53, 0)

date1.ToString "%h"
|> printfn "%s"              // Displays 6

date1.ToString "h tt"        
|> printfn "%s"              // Displays 6 PM
// </Snippet1>