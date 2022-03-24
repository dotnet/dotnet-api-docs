module IsControl2

// <Snippet2>
open System

let sentence = "This is a " + Environment.NewLine + "two-line sentence."

for i = 0 to sentence.Length - 1 do
    if Char.IsControl(sentence, i) then
        printfn $"Control character \\U{Convert.ToInt32 sentence[i]:X4} found in position {i}."

// The example displays the following output to the console:
//       Control character \U000D found in position 10.
//       Control character \U000A found in position 11.
// </Snippet2>