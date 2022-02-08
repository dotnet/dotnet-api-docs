open System
// This sample converts tab-delmited input and converts it to
// comma-delimited output.  Furthermore, it converts all boolean
// input to numeric representations.
// System.Console.Write
// System.Console.WriteLine
// System.Console.ReadLine
// <Snippet1>
let mutable lineInput = Console.ReadLine()
while lineInput <> null do
    let fields = lineInput.Split '\t'
    let mutable isFirstField = true

    for item in fields do
        if isFirstField then
            isFirstField <- false
        else
            Console.Write ','

        // If the field represents a boolean, replace with a numeric representation.
        match Boolean.TryParse item with 
        | true, itemBool ->
            Console.Write(Convert.ToByte itemBool)
        | _ ->
            Console.Write item
    Console.WriteLine()
// </Snippet1>
// usage examples:
// To convert tab-delimited input from the keyboard and display
// the output (type CTRL+Z to mark the end of input):
//     REFORMAT

// To input tab-delimited data from a file and display the output:
//     REFORMAT <tabs.txt

// To convert tab-delimted input from the keyboard and output the
// conversion to a file:
//     REFORMAT >commas.txt

// To convert tab-delimited data from a file and output the conversion
// to a file:
//     REFORMAT <tabs.txt >commas.txt

// Example input:
// 1       2.2     hello   TRUE
// 2       5.22    bye     FALSE
// 3       6.38    see ya' TRUE

// Example output:
// 1,2.2,hello,1
// 2,5.22,bye,0
// 3,6.38,see ya',1
