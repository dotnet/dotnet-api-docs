module continuationoptions
//<snippet04>
open System
open System.Threading
open System.Threading.Tasks

// Demonstrated features:
//      TaskContinuationOptions
//		Task.ContinueWith()
// 		Task.Factory
//		Task.Wait()
// Expected results:
// 		This sample demonstrates branched continuation sequences - Task+Commit or Task+Rollback.
//      Notice that no if statements are used.
//		The first sequence is successful - tran1 and commitTran1 are executed. rollbackTran1 is canceled.
//		The second sequence is unsuccessful - tran2 and rollbackTran2 are executed. tran2 is faulted, and commitTran2 is canceled.
// Documentation:
//		http://msdn.microsoft.com/library/system.threading.tasks.taskcontinuationoptions(VS.100).aspx
let success =
    fun () ->
        printfn $"Task={Task.CurrentId}, Thread={Thread.CurrentThread.ManagedThreadId}: Begin successful transaction"

let failure =
    fun () ->

        printfn
            $"Task={Task.CurrentId}, Thread={Thread.CurrentThread.ManagedThreadId}: Begin transaction and encounter an error"

        raise (InvalidOperationException "SIMULATED EXCEPTION")

let commit =
    fun antecendent ->
        printfn $"Task={Task.CurrentId}, Thread={Thread.CurrentThread.ManagedThreadId}: Commit transaction"

let rollback =
    fun (antecendent: Task) ->

        // "Observe" your antecedent's exception so as to avoid an exception
        // being thrown on the finalizer thread
        let unused = antecendent.Exception

        printfn $"Task={Task.CurrentId}, Thread={Thread.CurrentThread.ManagedThreadId}: Rollback transaction"

// Successful transaction - Begin + Commit
printfn "Demonstrating a successful transaction"

// Initial task
// Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
let tran1 = Task.Factory.StartNew success

// The following task gets scheduled only if tran1 completes successfully
let commitTran1 =
    tran1.ContinueWith(commit, TaskContinuationOptions.OnlyOnRanToCompletion)

// The following task gets scheduled only if tran1 DOES NOT complete successfully
let rollbackTran1 =
    tran1.ContinueWith(rollback, TaskContinuationOptions.NotOnRanToCompletion)

// For demo purposes, wait for the sample to complete
commitTran1.Wait()

// -----------------------------------------------------------------------------------

// Failed transaction - Begin + exception + Rollback
printfn "\nDemonstrating a failed transaction"

// Initial task
// Treated as "fire-and-forget" -- any exceptions will be cleaned up in rollback continuation
let tran2: Task = Task.Factory.StartNew failure

// The following task gets scheduled only if tran2 completes successfully
let commitTran2 =
    tran2.ContinueWith(Action<Task> commit, TaskContinuationOptions.OnlyOnRanToCompletion)

// The following task gets scheduled only if tran2 DOES NOT complete successfully
let rollbackTran2 =
    tran2.ContinueWith(Action<Task> rollback, TaskContinuationOptions.NotOnRanToCompletion)

// For demo purposes, wait for the sample to complete
rollbackTran2.Wait()


//</snippet04>
