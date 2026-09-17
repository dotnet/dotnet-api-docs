// <Snippet1>
using System.Diagnostics;

// Create an EventLog instance and assign its log name.
using EventLog myLog = new()
{
    Log = "myNewLog"
};

myLog.Clear();

// </Snippet1>
