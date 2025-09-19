//<SNIPPET1>
open System.IO

// Encrypt a file.
let addEncryption fileName = File.Encrypt fileName

// Decrypt a file.
let removeEncryption fileName = File.Decrypt fileName

let fileName = "test.xml"

printfn $"Encrypt {fileName}"

// Encrypt the file.
addEncryption fileName

printfn $"Decrypt {fileName}"

// Decrypt the file.
removeEncryption fileName

printfn "Done"
//</SNIPPET1>
