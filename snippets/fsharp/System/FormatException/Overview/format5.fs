module format5

open System

// <Snippet5>
let date1 = DateTime(2009, 7, 1)
let hiTime = TimeSpan(14, 17, 32)
let hiTemp = 62.1m 
let loTime = TimeSpan(3, 16, 10)
let loTemp = 54.8m 

String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", date1, hiTime, hiTemp, loTime, loTemp)
|> printfn "%s\n"
      
String.Format("Temperature on {0:d}:\n{1,11}: {2} degrees (hi)\n{3,11}: {4} degrees (lo)", [| date1 :> obj; hiTime; hiTemp; loTime; loTemp |])
|> printfn "%s"
// The example displays output like the following:
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
//       Temperature on 7/1/2009:
//          14:17:32: 62.1 degrees (hi)
//          03:16:10: 54.8 degrees (lo)
// </Snippet5>