module System.TimeSpan.FromMinutes

open System

do
    // <Snippet1>
    // The following throws an OverflowException at runtime
    let maxSpan = TimeSpan.FromMinutes TimeSpan.MaxValue.TotalMinutes
    // </Snippet1>

    // <Snippet2>
    // The following throws an OverflowException at runtime
    let maxSpan = TimeSpan.FromDays TimeSpan.MaxValue.TotalDays
    // </Snippet2>

    // <Snippet3>
    // The following throws an OverflowException at runtime
    let maxSpan = TimeSpan.FromHours TimeSpan.MaxValue.TotalHours
    // </Snippet3>

    // <Snippet4>
    // The following throws an OverflowException at runtime
    let maxSpan = TimeSpan.FromMilliseconds TimeSpan.MaxValue.TotalMilliseconds
    // </Snippet4>

    // <Snippet5>
    // The following throws an OverflowException at runtime
    let maxSpan = TimeSpan.FromSeconds TimeSpan.MaxValue.TotalSeconds
    // </Snippet5>

    ()