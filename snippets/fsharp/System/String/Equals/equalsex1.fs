module equalsex1

// <Snippet2>
open System

Console.OutputEncoding <- Text.Encoding.UTF8
let word = "File"
let others = [| word.ToLower(); word; word.ToUpper(); "Fıle" |]
for other in others do
    if word.Equals other then
        printfn $"{word} = {other}"
    else
        printfn $"{word} \u2260 {other}"
// The example displays the following output:
//       File ≠ file
//       File = File
//       File ≠ FILE
//       File ≠ Fıle
// </Snippet2>