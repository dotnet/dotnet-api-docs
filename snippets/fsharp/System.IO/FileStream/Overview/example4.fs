module example4
// <snippet4>
open System.Text
open System.IO

let read () =
    task {
        let filename = @"c:\Temp\userinputlog.txt"
        use sourceStream = File.Open(filename, FileMode.Open)
        let length = int sourceStream.Length    
        let result = Array.zeroCreate length 
        let! _ = sourceStream.ReadAsync(result, 0, length)
        return Encoding.ASCII.GetString result
    }

let main =
    task {
        let! text = read ()
        printfn $"{text}"
    }    
main.Wait()

// </snippet4>