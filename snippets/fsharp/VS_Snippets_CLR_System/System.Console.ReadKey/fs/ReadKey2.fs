module ReadKey2

// <Snippet2>
open System

let dat = DateTime.Now
printfn $"The time: {dat:d} at {dat:t}"

let tz = TimeZoneInfo.Local
printfn $"The time zone: {if tz.IsDaylightSavingTime dat then tz.DaylightName else tz.StandardName}\n"
printf"Press <Enter> to exit... "
while Console.ReadKey(true).Key <> ConsoleKey.Enter do ()


// The example displays output like the following:
//     The time: 12/28/2021 at 8:37 PM
//     The time zone: Pacific Standard Time
// </Snippet2>