// <Snippet1>
open System
open System.IO

let args = Environment.GetCommandLineArgs()[1..]
let mutable errorOutput = ""
// Make sure that there is at least one command line argument.
if args.Length < 1 then
    errorOutput <- errorOutput + "You must include a filename on the command line.\n"

for file in args do
    // Check whether the file exists.
    if File.Exists file then
        errorOutput <- errorOutput + $"'{file}' does not exist.\n"
    else
        // Display the contents of the file.
        use sr = new StreamReader(file)
        let contents = sr.ReadToEnd()
        Console.WriteLine $"*****Contents of file '{file}':\n\n"
        Console.WriteLine contents
        Console.WriteLine "*****\n"

// Check for error conditions.
if not (String.IsNullOrEmpty errorOutput) then
    // Write error information to a file.
    Console.SetError(new StreamWriter(@".\ViewTextFile.Err.txt"))
    Console.Error.WriteLine errorOutput
    Console.Error.Close()
    // Reacquire the standard error stream.
    use standardError = new StreamWriter(Console.OpenStandardError())
    standardError.AutoFlush <- true
    Console.SetError standardError
    Console.Error.WriteLine "\nError information written to ViewTextFile.Err.txt"

// If the example is compiled and run with the following command line:
//     ViewTextFile file1.txt file2.txt
// and neither file1.txt nor file2.txt exist, it displays the
// following output:
//     Error information written to ViewTextFile.Err.txt
// and writes the following text to ViewTextFile.Err.txt:
//     'file1.txt' does not exist.
//     'file2.txt' does not exist.
// </Snippet1>