// <Snippet1>
open System

let numbersToConvert = [ 162345L; 32183L; -54000L; Int64.MaxValue / 2L ]
for number in numbersToConvert do
    if number >= Int32.MinValue && number <= Int32.MaxValue then
        let newNumber = Convert.ToInt32 number
        printfn $"Successfully converted {newNumber} to an Int32."
    else
        printfn $"Unable to convert {number} to an Int32."
   

// The example displays the following output to the console:
//    Successfully converted 162345 to an Int32.
//    Successfully converted 32183 to an Int32.
//    Successfully converted -54000 to an Int32.
//    Unable to convert 4611686018427387903 to an Int32.
// </Snippet1>
