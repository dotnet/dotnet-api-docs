module ToString1

open System

do
    // <Snippet1>
    // Initialize a time span to zero.
    let span = TimeSpan.Zero
    printfn $"{span}"

    // Initialize a time span to 14 days.
    let span = TimeSpan(-14, 0, 0, 0, 0)
    printfn $"{span}"

    // Initialize a time span to 1:02:03.
    let span = TimeSpan(1, 2, 3)
    printfn $"{span}"

    // Initialize a time span to 250 milliseconds.
    let span = TimeSpan(0, 0, 0, 0, 250)
    printfn $"{span}"

    // Initialize a time span to 99 days, 23 hours, 59 minutes, and 59.999 seconds.
    let span = TimeSpan(99, 23, 59, 59, 999)
    printfn $"{span}"

    // Initialize a time span to 3 hours.
    let span = TimeSpan(3, 0, 0)
    printfn $"{span}"

    // Initialize a timespan to 25 milliseconds.
    let span = TimeSpan(0, 0, 0, 0, 25)
    printfn $"{span}"

    // The example displays the following output:
    //       00:00:00
    //       -14.00:00:00
    //       01:02:03
    //       00:00:00.2500000
    //       99.23:59:59.9990000
    //       03:00:00
    //       00:00:00.0250000
    // </Snippet1>