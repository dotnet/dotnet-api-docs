module run4
// Illustrates the Task.Run(Action, CancellationToken) overload.

// <Snippet4>
open System
open System.IO
open System.Threading
open System.Threading.Tasks

let main =
    task {
        use tokenSource = new CancellationTokenSource()
        let token = tokenSource.Token
        let files = ResizeArray()

        let t =
            new Task(
                (fun () ->
                    let dir = @"C:\Windows\System32\"
                    let obj = obj ()

                    if Directory.Exists dir then
                        Parallel.ForEach(
                            Directory.GetFiles dir,
                            fun f ->
                                if token.IsCancellationRequested then
                                    token.ThrowIfCancellationRequested()

                                let fi = FileInfo f
                                lock obj (fun () -> files.Add(fi.Name, fi.DirectoryName, fi.Length, fi.LastWriteTimeUtc))
                        )
                        |> ignore),
                token
            )

        t.Start()
        tokenSource.Cancel()

        try
            do! t
            printfn $"Retrieved information for {files.Count} files."

        with :? AggregateException as e ->
            printfn "Exception messages:"

            for ie in e.InnerExceptions do
                printfn $"   {ie.GetType().Name}: {ie.Message}"

            printfn $"Task status: {t.Status}"
    }

main.Wait()

// The example displays the following output:
//       Exception messages:
//          TaskCanceledException: A task was canceled.
//
//       Task status: Canceled
// </Snippet4>
