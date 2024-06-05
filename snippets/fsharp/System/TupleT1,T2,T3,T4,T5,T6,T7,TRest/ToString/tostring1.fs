// <Snippet1>
open System

let showPopulation year newPopulation =
    printfn $"""{year,5}  {newPopulation,14:N0}  {"n/a",10:P2}"""

let showPopulationChange year newPopulation oldPopulation =
    printfn $"{year,5}  {newPopulation,14:N0}  {(double (newPopulation - oldPopulation) / oldPopulation) / 10.,10:P2}"

let from1980 = Tuple.Create(1203339, 1027974, 951270)
let from1910 = 
    new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>(465766, 993078, 1568622, 1623452, 1849568, 1670144, 1511462, from1980)
let population = 
    new Tuple<string, int, int, int, int, int, int, Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>>("Detroit", 1860, 45619, 79577, 116340, 205876, 285704, from1910)

printfn $"{population}"

// The example displays the following output:
//   (Detroit, 1860, 45619, 79577, 116340, 205876, 285704, 465766, 993078, 
//    1568622, 1623452, 1849568, 1670144, 1511462, 1203339, 1027974, 951270)
// </Snippet1>