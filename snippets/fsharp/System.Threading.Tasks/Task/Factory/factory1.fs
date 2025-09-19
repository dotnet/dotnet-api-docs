module factory1
// <Snippet1>
open System
open System.IO
open System.Threading.Tasks

let mutable files = Unchecked.defaultof<string[]>
let mutable dirs = Unchecked.defaultof<string[]>
let docsDirectory = Environment.GetFolderPath Environment.SpecialFolder.MyDocuments

let tasks =
    [| Task.Factory.StartNew(fun () -> files <- Directory.GetFiles docsDirectory)
       Task.Factory.StartNew(fun () -> dirs <- Directory.GetDirectories docsDirectory) |]

Task.Factory.ContinueWhenAll(
    tasks,
    fun completedTasks ->
        printfn $"{docsDirectory} contains: "
        printfn $"   {dirs.Length} subdirectories"
        printfn $"   {files.Length} files"
)
|> ignore

// The example displays output like the following:
//       C:\Users\<username>\Documents contains:
//          24 subdirectories
//          16 files
// </Snippet1>
