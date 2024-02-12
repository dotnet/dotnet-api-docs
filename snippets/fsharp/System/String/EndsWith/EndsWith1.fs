module EndsWith1

// <Snippet1>
let strings = 
    [| "This is a string."; "Hello!"; "Nothing."
       "Yes."; "randomize" |]

for value in strings do
    let endsInPeriod = value.EndsWith "."
    printfn $"'{value}' ends in a period: {endsInPeriod}"
// The example displays the following output:
//       'This is a string.' ends in a period: True
//       'Hello!' ends in a period: False
//       'Nothing.' ends in a period: True
//       'Yes.' ends in a period: True
//       'randomize' ends in a period: False
// </Snippet1>