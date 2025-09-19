module ToBoolean1

// <Snippet1>
open System

let values =
    [| null; String.Empty; "true"; "TrueString"
       "False"; "    false    "; "-1"; "0" |]

for value in values do
    try
        printfn $"Converted '{value}' to {Convert.ToBoolean value}."
                        
    with :? FormatException ->
        printfn $"Unable to convert '{value}' to a Boolean."
// The example displays the following output:
//       Converted '' to False.
//       Unable to convert '' to a Boolean.
//       Converted 'true' to True.
//       Unable to convert 'TrueString' to a Boolean.
//       Converted 'False' to False.
//       Converted '    false    ' to False.
//       Unable to convert '-1' to a Boolean.
//       Unable to convert '0' to a Boolean.
// </Snippet1>
