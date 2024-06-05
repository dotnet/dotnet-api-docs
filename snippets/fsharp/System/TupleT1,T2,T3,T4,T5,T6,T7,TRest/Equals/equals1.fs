// <Snippet1>
open System

// Create five 8-tuple objects containing prime numbers.
let prime1 = 
    new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
        Tuple<Int32>> (2, 3, 5, 7, 11, 13, 17, 
        new Tuple<Int32>(19))
let prime2 = 
    new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
        Tuple<Int32>> (23, 29, 31, 37, 41, 43, 47, 
        new Tuple<Int32>(55))
let prime3 = 
    new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
        Tuple<Int32>> (3, 2, 5, 7, 11, 13, 17, 
        new Tuple<Int32>(19)) 
let prime4 = 
    new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
        Tuple<Int32, Int32>> (2, 3, 5, 7, 11, 13, 17, 
        new Tuple<Int32, Int32>(19, 23))
let prime5 = 
    new Tuple<Int32, Int32, Int32, Int32, Int32, Int32, Int32, 
        Tuple<Int32>> (2, 3, 5, 7, 11, 13, 17, 
        new Tuple<Int32>(19))
printfn $"{prime1} = {prime2} : {prime1.Equals prime2}"
printfn $"{prime1} = {prime3} : {prime1.Equals prime3}"
printfn $"{prime1} = {prime4} : {prime1.Equals prime4}"
printfn $"{prime1} = {prime5} : {prime1.Equals prime5}"
// The example displays the following output:
//    (2, 3, 5, 7, 11, 13, 17, 19) = (23, 29, 31, 37, 41, 43, 47, 55) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (3, 2, 5, 7, 11, 13, 17, 19) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19, 23) : False
//    (2, 3, 5, 7, 11, 13, 17, 19) = (2, 3, 5, 7, 11, 13, 17, 19) : True
// </Snippet1>