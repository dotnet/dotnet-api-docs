// <Snippet1>
open System

let numbersToConvert = [ 162345L; 32183L; -54000L ]

for number in numbersToConvert do
    if number >= int64 Int16.MinValue && number <= int64 Int16.MaxValue then
        let newNumber = Convert.ToInt16 number
        printfn $"Successfully converted {newNumber} to an Int16."
    else
        printfn $"Unable to convert {number} to an Int16."

// The example displays the following output to the console:
//       Unable to convert 162345 to an Int16.
//       Successfully converted 32183 to an Int16.
//       Unable to convert -54000 to an Int16.
// </Snippet1>
