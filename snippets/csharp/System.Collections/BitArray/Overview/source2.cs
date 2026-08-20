using System;
using System.Collections;

public class SamplesLocker
{
    public static void Run()
    {

        // <Snippet2>
        BitArray myCollection = new(64, true);
        lock (myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}
