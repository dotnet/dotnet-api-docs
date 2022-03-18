// <Snippet1>
open System

type DateComparisonResult =
    | Earlier = -1
    | Later = 1
    | TheSame = 0

[<EntryPoint>]
let main _ =
    let thisDate = DateTime.Today

    // Define two DateTime objects for today's date next year and last year		
    // Call AddYears instance method to add/substract 1 year
    let thisDateNextYear = thisDate.AddYears 1
    let thisDateLastYear = thisDate.AddYears -1

    // Compare today to last year
    let comparison = thisDate.CompareTo thisDateLastYear |> enum<DateComparisonResult>
    printfn $"CompareTo method returns {int comparison}: {thisDate:d} is {comparison.ToString().ToLower()} than {thisDateLastYear:d}"

    // Compare today to next year
    let comparison = thisDate.CompareTo thisDateNextYear |> enum<DateComparisonResult>
    printfn $"CompareTo method returns {int comparison}: {thisDate:d} is {comparison.ToString().ToLower()} than {thisDateNextYear:d}"
                        
    0

// If run on December 31, 2021, the example produces the following output:
//    CompareTo method returns 1: 12/31/2021 is later than 12/31/2020
//    CompareTo method returns -1: 12/31/2021 is earlier than 12/31/2022
// </Snippet1>