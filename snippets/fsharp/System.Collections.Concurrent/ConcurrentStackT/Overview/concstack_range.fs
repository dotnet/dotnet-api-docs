module concstack_range
//<snippet1>
open System.Collections.Concurrent
open System.Linq
open System.Threading
open System.Threading.Tasks

// Demonstrates:
//      ConcurrentStack<T>.PushRange();
//      ConcurrentStack<T>.TryPopRange();

let main = 
    task {
        let numParallelTasks = 4
        let numItems = 1000
        let stack = ConcurrentStack<int>()

        // Push a range of values onto the stack concurrently
        let! _ = Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(fun i -> 
            Task.Factory.StartNew((fun state ->
                // state = i * numItems
                let index: int = unbox state
                let array = 
                    [|  for j in 0 .. numItems - 1 do
                            index + j |]
                printfn $"Pushing an array of ints from {array[0]} to {array[numItems - 1]}"
                stack.PushRange array
            ), i * numItems, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default)).ToArray())

        let numTotalElements = 4 * numItems
        let resultBuffer = Array.zeroCreate numTotalElements
        let! _ = Task.WhenAll(Enumerable.Range(0, numParallelTasks).Select(fun i -> 
            Task.Factory.StartNew((fun obj ->
                let index = unbox obj
                let result = stack.TryPopRange(resultBuffer, index, numItems)
                printfn $"TryPopRange expected {numItems}, got {result}."
            ), i * numItems, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default)).ToArray())

        for i = 0 to numParallelTasks - 1 do
            // Create a sequence we expect to see from the stack taking the last number of the range we inserted
            let expected = Enumerable.Range(resultBuffer[i*numItems + numItems - 1], numItems)

            // Take the range we inserted, reverse it, and compare to the expected sequence
            let areEqual = expected.SequenceEqual(resultBuffer.Skip(i * numItems).Take(numItems).Reverse())
            if areEqual then
                printfn $"Expected a range of {expected.First()} to {expected.Last()}. Got {resultBuffer[i * numItems + numItems - 1]} to {resultBuffer[i * numItems]}"
            else
                printfn $"Unexpected consecutive ranges."
    }
main.Wait()
//</snippet1>