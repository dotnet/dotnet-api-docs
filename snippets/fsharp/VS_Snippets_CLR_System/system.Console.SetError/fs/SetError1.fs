// <Snippet1>
open System
open System.IO
open System.Reflection

[<EntryPoint>]
let main _ =
    // Define file to receive error stream.
    let appStart = DateTime.Now
    let fn = @"C:\temp\errlog" + appStart.ToString "yyyyMMddHHmm" + ".log"
    use fs = new FileStream(fn, FileMode.OpenOrCreate)
    let errStream = new StreamWriter(fs)
    let appName = 
        let appName = Assembly.GetExecutingAssembly().Location
        appName.Substring(appName.LastIndexOf('\\') + 1)

    // Redirect standard error stream to file.
    Console.SetError errStream

    // Write file header.
    Console.Error.WriteLine $"Error Log for Application {appName}"
    Console.Error.WriteLine()
    Console.Error.WriteLine $"Application started at {appStart}."
    Console.Error.WriteLine()
    //
    // Application code along with error output
    //
    // Close redirected error stream.
    Console.Error.Close()
    
    0
// </Snippet1>