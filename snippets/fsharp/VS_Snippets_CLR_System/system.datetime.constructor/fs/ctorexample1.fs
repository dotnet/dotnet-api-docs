module ctorexample1

open System

let showYMD () =
    // <Snippet1>
    let date1 = DateTime(2010, 8, 18)
    printfn $"{date1}"
    
    // The example displays the following output:
    //      8/18/2010 12:00:00 AM
    // </Snippet1>

let showYMDHMS () =
    // <Snippet3>
    let date1 = DateTime(2010, 8, 18, 16, 32, 0)
    printfn $"{date1}"
    
    // The example displays the following output, in this case for en-us culture:
    //      8/18/2010 4:32:00 PM
    // </Snippet3>

let showYMDHMSMs () =
    // <Snippet5>
    let date1 = DateTime(2010, 8, 18, 16, 32, 18, 500)
    
    date1.ToString "M/dd/yyyy h:mm:ss.fff tt"
    |> printfn "%s"
    
    // The example displays the following output, in this case for en-us culture:
    //      8/18/2010 4:32:18.500 PM
    // </Snippet5>

let showYMDHMSKind () =
    // <Snippet7>
    let date1 = DateTime(2010, 8, 18, 16, 32, 0, DateTimeKind.Local)
    printfn $"{date1} {date1.Kind}"

    // The example displays the following output, in this case for en-us culture:
    //      8/18/2010 4:32:00 PM Local
    // </Snippet7>

let showYMDHMSMsKind () =
    // <Snippet8>
    let date1 = DateTime(2010, 8, 18, 16, 32, 18, 500, DateTimeKind.Local)
    printfn $"""{date1.ToString "M/dd/yyyy h:mm:ss.fff tt"} {date1.Kind}"""

    // The example displays the following output, in this case for en-us culture:
    //      8/18/2010 4:32:18.500 PM Local
    // </Snippet8>

showYMD ()
printfn "-----"
showYMDHMS ()
printfn "-----"
showYMDHMSMs ()
printfn "-----"
showYMDHMSKind ()
printfn "-----"
showYMDHMSMsKind ()