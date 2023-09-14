module fromresult1
// <Snippet1>
open System
open System.IO
open System.Threading
open System.Threading.Tasks

let getFileLengthsAsync filePath =
    if Directory.Exists filePath |> not then
        DirectoryNotFoundException "Invalid directory name."
        |> Task.FromException<int64>

    else
        let files = Directory.GetFiles filePath

        if files.Length = 0 then
            Task.FromResult 0L
        else
            Task.Run(fun () ->
                let mutable total = 0L

                Parallel.ForEach(
                    files,
                    fun fileName ->
                        use fs =
                            new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 256, true)

                        Interlocked.Add(ref total, fs.Length) |> ignore
                )
                |> ignore

                total)

let args = Environment.GetCommandLineArgs()[1..]

if args.Length > 0 then
    let tasks = Array.map getFileLengthsAsync args

    try
        Seq.cast tasks |> Seq.toArray |> Task.WaitAll

    // Ignore exceptions here.
    with :? AggregateException ->
        ()

    for i = 0 to tasks.Length - 1 do
        if tasks[i].Status = TaskStatus.Faulted then
            printfn $"{args[i + 1]} does not exist"
        else
            printfn $"{tasks[i].Result:N0} bytes in files in '{args[i + 1]}'"
else
    printfn "Syntax error: Include one or more file paths."

// When launched with the following command line arguments:
//      subdir . newsubdir
// the example displays output like the following:
//       0 bytes in files in 'subdir'
//       2,059 bytes in files in '.'
//       newsubdir does not exist
// </Snippet1>
