module tostring4

// <Snippet4>
open System
open System.Globalization

let intervals = 
    [| TimeSpan(38, 30, 15)
       TimeSpan(16, 14, 30) |] 
let cultures = 
    [| CultureInfo "en-US"
       CultureInfo "fr-FR" |]
let formats = [| "c"; "g"; "G"; @"hh\:mm\:ss" |]
printfn $"""{"Interval",12}      Format  {cultures[0].Name,22}  {cultures[1].Name,22}\n""" 

for interval in intervals do
    for fmt in formats do
        printfn $"{interval,12}  {fmt,10}  {interval.ToString(fmt, cultures[0]),22}  {interval.ToString(fmt, cultures[1]),22}"
    printfn ""
// The example displays the following output:
//        Interval      Format                   en-US                   fr-FR
//    
//      1.14:30:15           c              1.14:30:15              1.14:30:15
//      1.14:30:15           g              1:14:30:15              1:14:30:15
//      1.14:30:15           G      1:14:30:15.0000000      1:14:30:15,0000000
//      1.14:30:15  hh\:mm\:ss                14:30:15                14:30:15
//    
//        16:14:30           c                16:14:30                16:14:30
//        16:14:30           g                16:14:30                16:14:30
//        16:14:30           G      0:16:14:30.0000000      0:16:14:30,0000000
//        16:14:30  hh\:mm\:ss                16:14:30                16:14:30
// </Snippet4>