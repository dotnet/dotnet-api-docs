﻿using System;
using System.Collections;

public class SamplesArrayList2
{
    public static void Main()
    {
        // <Snippet2>
        ArrayList myCollection = new ArrayList();

        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}
