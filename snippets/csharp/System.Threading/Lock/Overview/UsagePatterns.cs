using System;
using System.Threading;

// <Snippet1>
public sealed class ExampleDataStructure
{
    private readonly Lock _lockObj = new();

    private void Modify()
    {
        lock (_lockObj)
        {
            // Critical section associated with _lockObj
        }

        using (_lockObj.EnterScope())
        {
            // Critical section associated with _lockObj
        }

        _lockObj.Enter();
        try
        {
            // Critical section associated with _lockObj
        }
        finally { _lockObj.Exit(); }

        if (_lockObj.TryEnter())
        {
            try
            {
                // Critical section associated with _lockObj
            }
            finally { _lockObj.Exit(); }
        }
    }
}
// </Snippet1>
