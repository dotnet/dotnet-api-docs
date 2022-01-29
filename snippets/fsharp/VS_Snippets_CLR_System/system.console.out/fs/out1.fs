// <Snippet1>
open System
open System.IO

// Get all files in the current directory.
let files = 
    Directory.GetFiles "."
    |> Array.sort

// Display the files to the current output source to the console.
Console.Out.WriteLine "First display of filenames to the console:"
files |> Array.iter Console.Out.WriteLine
Console.Out.WriteLine()

// Redirect output to a file named Files.txt and write file list.
let sw = new StreamWriter(@".\Files.txt")
sw.AutoFlush <- true
Console.SetOut sw
Console.Out.WriteLine "Display filenames to a file:"
files |> Array.iter Console.Out.WriteLine
Console.Out.WriteLine()

// Close previous output stream and redirect output to standard output.
Console.Out.Close()
let sw2 = new StreamWriter(Console.OpenStandardOutput())
sw2.AutoFlush <- true
Console.SetOut sw2

// Display the files to the current output source to the console.
Console.Out.WriteLine "Second display of filenames to the console:"
files |> Array.iter Console.Out.WriteLine
// </Snippet1>