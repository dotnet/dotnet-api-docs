module program
// <Snippet1>
open System
open System.IO

let dataPath = @"c:\temp\timestamps.txt"

let createSampleFile () =
    let timeStamp = DateTime(1700, 1, 1)

    use sw = new StreamWriter(dataPath)

    for i = 0 to 499 do
        let ts1 = timeStamp.AddYears i
        let ts2 = ts1.AddMonths i
        let ts3 = ts2.AddDays i
        ts3.ToLongDateString() |> sw.WriteLine

createSampleFile ()

let julyWeekends =
    File.ReadLines dataPath
    |> Seq.filter (fun line ->
        (line.StartsWith "Saturday"
         || line.StartsWith "Sunday")
        && line.Contains "July")

File.WriteAllLines(@"C:\temp\selectedDays.txt", julyWeekends)

let marchMondays =
    File.ReadLines dataPath
    |> Seq.filter (fun line -> line.StartsWith "Monday" && line.Contains "March")

File.AppendAllLines(@"C:\temp\selectedDays.txt", marchMondays)

// </Snippet1>
