module source

// <Snippet3>
open System

printfn 
    $"""{Math.Round(3.44m, 1)}
{Math.Round(3.45m, 1)}
{Math.Round(3.46m, 1)}

{Math.Round(4.34m, 1)}
{Math.Round(4.35m, 1)}
{Math.Round(4.36m, 1)}"""

// The example displays the following output:
//       3.4
//       3.4
//       3.5
//
//       4.3
//       4.4
//       4.4
// </Snippet3>