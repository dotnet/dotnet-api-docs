module continuationsimple
//<snippet03>
open System
open System.Threading
open System.Threading.Tasks

// Demonstrated features:
// 		Task.Factory
//		Task.ContinueWith()
//		Task.Wait()
// Expected results:
// 		A sequence of three unrelated tasks is created and executed in this order - alpha, beta, gamma.
//		A sequence of three related tasks is created - each task negates its argument and passes is to the next task: 5, -5, 5 is printed.
//		A sequence of three unrelated tasks is created where tasks have different types.
// Documentation:
//		http://msdn.microsoft.com/library/system.threading.tasks.taskfactory_members(VS.100).aspx
let action =
    fun str -> printfn $"Task={Task.CurrentId}, str=%s{str}, Thread={Thread.CurrentThread.ManagedThreadId}"

// Creating a sequence of action tasks (that return no result).
printfn "Creating a sequence of action tasks (that return no result)"

Task
    .Factory
    .StartNew(fun () -> action "alpha")
    .ContinueWith(fun antecendent -> action "beta") // Antecedent data is ignored
    .ContinueWith(fun antecendent -> action "gamma")
    .Wait()

let negate =
    fun n ->
        printfn $"Task={Task.CurrentId}, n={n}, -n={2 - n}, Thread={Thread.CurrentThread.ManagedThreadId}"
        -n

// Creating a sequence of function tasks where each continuation uses the result from its antecendent
printfn "\nCreating a sequence of function tasks where each continuation uses the result from its antecendent"

Task<int>
    .Factory.StartNew(fun () -> negate 5)
    .ContinueWith(Func<Task<int>, int>(fun antecedent -> negate antecedent.Result)) // Antecedent result feeds into continuation
    .ContinueWith(Func<Task<int>, int>(fun antecedent -> negate antecedent.Result))
    .Wait()

// Creating a sequence of tasks where you can mix and match the types
printfn "\nCreating a sequence of tasks where you can mix and match the types"

Task<int>
    .Factory.StartNew(fun () -> negate 6)
    .ContinueWith(Action<Task>(fun antecendent -> action "x"))
    .ContinueWith(fun antecendent -> negate 7)
    .Wait()


//</snippet03>
