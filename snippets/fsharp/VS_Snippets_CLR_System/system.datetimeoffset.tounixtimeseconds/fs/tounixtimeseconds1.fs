// <Snippet1>
open System

[<EntryPoint>]
let main _ =
    let dto = DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)
    printfn $"{dto} --> Unix Seconds: {dto.ToUnixTimeSeconds()}"

    let dto = DateTimeOffset(1969, 12, 31, 23, 59, 0, TimeSpan.Zero)
    printfn $"{dto} --> Unix Seconds: {dto.ToUnixTimeSeconds()}"

    let dto = DateTimeOffset(1970, 1, 1, 0, 1, 0, TimeSpan.Zero)
    printfn $"{dto} --> Unix Seconds: {dto.ToUnixTimeSeconds()}"

    0
// The example displays the following output:
//    1/1/1970 12:00:00 AM +00:00 --> Unix Seconds: 0
//    12/31/1969 11:59:00 PM +00:00 --> Unix Seconds: -60
//    1/1/1970 12:01:00 AM +00:00 --> Unix Seconds: 60
// </Snippet1>