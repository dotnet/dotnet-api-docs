using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        await SnippetAwait();
        await SnippetWaitAsync();
        await SnippetAwaitMultiple();
    }

    static async Task SnippetAwait()
    {
        // <SnippetAwait>
        // Wait on a single task with no timeout specified
        Task taskA = Task.Run(() => Thread.Sleep(2000));
        Console.WriteLine("taskA Status: {0}", taskA.Status);

        await taskA;
        Console.WriteLine("taskA Status: {0}", taskA.Status);

        // This example displays output like the following:
        //     taskA Status: WaitingToRun
        //     taskA Status: RanToCompletion
        // </SnippetAwait>
    }

    static async Task SnippetWaitAsync()
    {
        // <SnippetWaitAsync>
        // Wait on a single task with a timeout specified
        Task taskA = Task.Run(() => Thread.Sleep(2000));
        Console.WriteLine("taskA Status: {0}", taskA.Status);

        try
        {
            await taskA.WaitAsync(TimeSpan.FromSeconds(1));
        }
        catch (TimeoutException)
        {
            Console.WriteLine("taskA timed out after a second");
        }
        Console.WriteLine("taskA Status: {0}", taskA.Status);

        // task is still running
        await taskA;
        Console.WriteLine("taskA Status: {0}", taskA.Status);

        // This example displays output like the following:
        //     taskA Status: WaitingToRun
        //     taskA timed out after a second
        //     taskA Status: Running
        //     taskA Status: RanToCompletion
        // </SnippetWaitAsync>
    }

    static async Task SnippetAwaitMultiple()
    {
        // <SnippetAwaitMultiple>
        // Wait on multiple tasks
        Task task0 = Task.Run(() => Thread.Sleep(2000));
        Task task1 = Task.Run(() => Thread.Sleep(500));
        Task task2 = Task.Run(() => Thread.Sleep(1000));

        var tasks = new[] { task0, task1, task2 };

        // wait for the first task to complete
        await Task.WhenAny(tasks);

        Console.WriteLine("First task completed. Status of all tasks:");
        for (var i = 0; i < tasks.Length; i++)
            Console.WriteLine("- Task {0}: {1}", i, tasks[i].Status);

        // wait for all tasks to complete
        await Task.WhenAll(tasks);

        Console.WriteLine("All tasks completed. Status of all tasks:");
        for (var i = 0; i < tasks.Length; i++)
            Console.WriteLine("- Task {0}: {1}", i, tasks[i].Status);

        // This example displays output like the following:
        //     First task completed.Status of all tasks:
        //     - Task 0: Running
        //     - Task 1: RanToCompletion
        //     - Task 2: Running
        //     All tasks completed. Status of all tasks:
        //     - Task 0: RanToCompletion
        //     - Task 1: RanToCompletion
        //     - Task 2: RanToCompletion
        // </SnippetAwaitMultiple>
    }
}
