module source
// <Snippet1>
open System.IO

let fs = new FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.Write)

if fs.CanRead && fs.CanWrite then
    printfn "MyFile.txt can be both written to and read from."
elif fs.CanWrite then
    printfn "MyFile.txt is writable."

// </Snippet1>
