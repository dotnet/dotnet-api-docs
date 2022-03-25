// <Snippet1>
open System
open System.Threading

type Example() =
    [<ThreadStatic; DefaultValue>] 
    static val mutable private previous : double

    [<ThreadStatic; DefaultValue>] 
    static val mutable private sum : double
    
    [<ThreadStatic; DefaultValue>] 
    static val mutable private calls : int

    [<ThreadStatic; DefaultValue>] 
    static val mutable private abnormal : bool
   
    static let mutable totalNumbers = 0
    static let countdown = new CountdownEvent(1)
    static let lockObj = obj ()
    let rand = Random()


    member this.Execute() =
        for threads = 1 to 10 do
            let newThread = new Thread(ThreadStart this.GetRandomNumbers)
            countdown.AddCount()
            newThread.Name <- threads.ToString()
            newThread.Start()
        this.GetRandomNumbers()
        countdown.Wait()
        printfn $"{totalNumbers:N0} random numbers were generated."

    member _.GetRandomNumbers() =
        let mutable i = 0
        while i < 2000000 do
            lock lockObj (fun () ->
                let result = rand.NextDouble()
                Example.calls <- Example.calls + 1
                Interlocked.Increment &totalNumbers |> ignore
                // We should never get the same random number twice.
                if result = Example.previous then
                    Example.abnormal <- true
                    i <- 2000001 // break
                else
                    Example.previous <- result
                    Example.sum <- Example.sum + result )
            i <- i + 1
        // get last result
        if Example.abnormal then
            printfn $"Result is {Example.previous} in {Thread.CurrentThread.Name}"
        
        printfn $"Thread {Thread.CurrentThread.Name} finished random number generation."
        printfn $"Sum = {Example.sum:N4}, Mean = {Example.sum / float Example.calls:N4}, n = {Example.calls:N0}\n"
        countdown.Signal() |> ignore

let ex = Example()
Thread.CurrentThread.Name <- "Main"
ex.Execute()

// The example displays output similar to the following:
//    Thread 1 finished random number generation.
//    Sum = 1,000,556.7483, Mean = 0.5003, n = 2,000,000
//    
//    Thread 6 finished random number generation.
//    Sum = 999,704.3865, Mean = 0.4999, n = 2,000,000
//    
//    Thread 2 finished random number generation.
//    Sum = 999,680.8904, Mean = 0.4998, n = 2,000,000
//    
//    Thread 10 finished random number generation.
//    Sum = 999,437.5132, Mean = 0.4997, n = 2,000,000
//    
//    Thread 8 finished random number generation.
//    Sum = 1,000,663.7789, Mean = 0.5003, n = 2,000,000
//    
//    Thread 4 finished random number generation.
//    Sum = 999,379.5978, Mean = 0.4997, n = 2,000,000
//    
//    Thread 5 finished random number generation.
//    Sum = 1,000,011.0605, Mean = 0.5000, n = 2,000,000
//    
//    Thread 9 finished random number generation.
//    Sum = 1,000,637.4556, Mean = 0.5003, n = 2,000,000
//    
//    Thread Main finished random number generation.
//    Sum = 1,000,676.2381, Mean = 0.5003, n = 2,000,000
//    
//    Thread 3 finished random number generation.
//    Sum = 999,951.1025, Mean = 0.5000, n = 2,000,000
//    
//    Thread 7 finished random number generation.
//    Sum = 1,000,844.5217, Mean = 0.5004, n = 2,000,000
//    
//    22,000,000 random numbers were generated.
// </Snippet1>