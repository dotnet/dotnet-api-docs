module tostring6

open System

let convertInt64 () =
    // <Snippet28>
    // Create a NumberFormatInfo object and set several of its
    // properties that control default integer formatting.
    let provider = System.Globalization.NumberFormatInfo()
    provider.NegativeSign <- "minus "

    let values = [| -200; 0; 1000 |]

    for value in values do
        printfn $"{value,-6}  -->  {Convert.ToString(value, provider),10}"
    // The example displays the following output:
    //       -200    -->   minus 200
    //       0       -->           0
    //       1000    -->        1000
    // </Snippet28>

convertInt64 ()
