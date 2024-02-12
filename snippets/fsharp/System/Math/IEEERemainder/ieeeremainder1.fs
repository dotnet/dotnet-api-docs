// <Snippet1>
open System

let showRemainders number1 number2 =
    let formula = $"{number1} / {number2} = "
    let ieeeRemainder = Math.IEEERemainder(number1, number2)
    let remainder = number1 % number2
    printfn $"{formula,-16} {ieeeRemainder,18} {remainder,20}"
    
printfn "                      IEEERemainder   Remainder operator"
showRemainders 3 2
showRemainders 4 2
showRemainders 10 3
showRemainders 11 3
showRemainders 27 4
showRemainders 28 5
showRemainders 17.8 4
showRemainders 17.8 4.1
showRemainders -16.3 4.1
showRemainders 17.8 -4.1
showRemainders -17.8 -4.1

// The example displays the following output:
//
//
//                       IEEERemainder   Remainder operator
// 3 / 2 =                          -1                    1
// 4 / 2 =                           0                    0
// 10 / 3 =                          1                    1
// 11 / 3 =                         -1                    2
// 27 / 4 =                         -1                    3
// 28 / 5 =                         -2                    3
// 17.8 / 4 =                      1.8                  1.8
// 17.8 / 4.1 =                    1.4                  1.4
// -16.3 / 4.1 =    0.0999999999999979                   -4
// 17.8 / -4.1 =                   1.4                  1.4
// -17.8 / -4.1 =                 -1.4                 -1.4
// </Snippet1>