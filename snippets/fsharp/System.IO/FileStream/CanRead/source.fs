module source
// <Snippet1>
open System.IO

let fs = new FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.Read)

if fs.CanRead && fs.CanWrite then
    printfn "MyFile.txt can be both written to and read from."
else if fs.CanRead then
    printfn "MyFile.txt is not writable."
// </Snippet1>
