﻿// <Snippet1>
using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

// <Snippet2>
// Context-bound type with the Synchronization context attribute.
[Synchronization()]
public class SampleSynchronized : ContextBoundObject {

    // A method that does some work, and returns the square of the given number.
    public int Square(int i)  {

        Console.Write("The hash of the thread executing ");
        Console.WriteLine("SampleSynchronized.Square is: {0}",
                             Thread.CurrentThread.GetHashCode());
        return i*i;
    }
}
// </Snippet2>

// The async delegate used to call a method with this signature asynchronously.
public delegate int SampSyncSqrDelegate(int i);

public class AsyncResultSample {

// <Snippet4>
    // Asynchronous Callback method.
    public static void MyCallback(IAsyncResult ar) {

        // Obtains the last parameter of the delegate call.
        int value = Convert.ToInt32(ar.AsyncState);

        // Obtains return value from the delegate call using EndInvoke.
        AsyncResult aResult = (AsyncResult)ar;
        SampSyncSqrDelegate temp = (SampSyncSqrDelegate)aResult.AsyncDelegate;
        int result = temp.EndInvoke(ar);

        Console.Write("Simple.SomeMethod (AsyncCallback): Result of ");
        Console.WriteLine("{0} in SampleSynchronized.Square is {1} ", value, result);
    }
// </Snippet4>

    public static void Main() {

        int result;
        int param;

// <Snippet6>
        // Creates an instance of a context-bound type SampleSynchronized.
        SampleSynchronized sampSyncObj = new SampleSynchronized();

        // Checks whether the object is a proxy, since it is context-bound.
        if (RemotingServices.IsTransparentProxy(sampSyncObj))
            Console.WriteLine("sampSyncObj is a proxy.");
        else
            Console.WriteLine("sampSyncObj is NOT a proxy.");
// </Snippet6>
// <Snippet7>

        param = 10;

        Console.WriteLine("");
        Console.WriteLine("Making a synchronous call on the context-bound object:");

        result = sampSyncObj.Square(param);
        Console.Write("The result of calling sampSyncObj.Square with ");
        Console.WriteLine("{0} is {1}.", param, result);
        Console.WriteLine("");

// </Snippet7>
// <Snippet8>
        SampSyncSqrDelegate sampleDelegate = new SampSyncSqrDelegate(sampSyncObj.Square);
        param = 8;

        Console.WriteLine("Making a single asynchronous call on the context-bound object:");

        IAsyncResult ar1 = sampleDelegate.BeginInvoke( param,
                              new AsyncCallback(AsyncResultSample.MyCallback),
                              param);

        Console.WriteLine("Waiting for the asynchronous call to complete...");
        WaitHandle wh = ar1.AsyncWaitHandle;
        wh.WaitOne();

        wh.Close();

        Console.WriteLine("");
        Console.WriteLine("Waiting for the AsyncCallback to complete...");
        // Note that normally, a callback and a wait handle would not
        // both be used on the same asynchronous call. Callbacks are
        // useful in cases where the original thread does not need to
        // be synchronized with the result of the call, and in that
        // scenario they provide a place to call EndInvoke. Sleep is
        // used here because the callback is on a ThreadPool thread.
        // ThreadPool threads are background threads, and will not keep
        // a process running when the main thread ends.
        Thread.Sleep(1000);
// </Snippet8>
    }
}

/* This code produces output similar to the following:

sampSyncObj is a proxy.

Making a synchronous call on the context-bound object:
The hash of the thread executing SampleSynchronized.Square is: 1
The result of calling sampSyncObj.Square with 10 is 100.

Making a single asynchronous call on the context-bound object:
Waiting for the asynchronous call to complete...
The hash of the thread executing SampleSynchronized.Square is: 6

Waiting for the AsyncCallback to complete...
Simple.SomeMethod (AsyncCallback): Result of 8 in SampleSynchronized.Square is 64
 */
// </Snippet1>