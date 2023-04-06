module item1

// <Snippet1>
open System

// Define array of tuples reflecting population change by state, 1990-2000.
let statesData = 
    [| Tuple.Create("California", 29760021, 33871648, 4111627, 13.8)
       Tuple.Create("Illinois", 11430602, 12419293, 988691, 8.6)
       Tuple.Create("Washington", 4866692, 5894121, 1027429, 21.1) |]

// Display the items of each tuple
printfn "%-12s%18s%18s%15s%12s\n" "State" "Population 1990" "Population 2000" "Change" "% Change"
for stateData in statesData do
    printfn $"{stateData.Item1,-12}{stateData.Item2,18:N0}{stateData.Item3,18:N0}{stateData.Item4,15:N0}{stateData.Item5,12:P1}"
// The example displays the following output:
//    State          Population 1990   Population 2000         Change    % Change
//    
//    California          29,760,021        33,871,648      4,111,627      13.8 %
//    Illinois            11,430,602        12,419,293        988,691       8.6 %
//    Washington           4,866,692         5,894,121      1,027,429      21.1 %
// </Snippet1>