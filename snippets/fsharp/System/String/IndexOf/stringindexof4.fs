module stringindexof4.fs
//<snippet1>
open System

let strSource = "This is the string which we will perform the search on"

printfn $"The search string is:{Environment.NewLine}\"{strSource}\"{Environment.NewLine}"

let mutable broken = false
while not broken do
    let mutable totFinds = 0
    printf "Please enter a search value to look for in the above string (hit Enter to exit) => "

    let strTarget = stdin.ReadLine()

    if strTarget <> "" then
        let mutable i = 0
        let mutable broken = false
        while not broken && i <= strSource.Length - 1 do
            let found = strSource.IndexOf(strTarget, i)

            if found >= 0 then
                totFinds <- totFinds + 1
                i <- found
            else
                broken <- true
            i <- i + 1
    else
        broken <- true

    printfn $"{Environment.NewLine}The search parameter '{strTarget}' was found {totFinds} times.{Environment.NewLine}"
// </snippet1>
