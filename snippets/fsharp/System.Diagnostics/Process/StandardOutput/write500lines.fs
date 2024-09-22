module Write500Lines

for i in 1. .. 500. do
    printfn $"Line {i} of 500 written: {i/500.:P2}";

eprintfn "Successfully wrote 500 lines.";
// The example displays the following output:
//      The last 50 characters in the output stream are:
//      ' 49,800.20%
//      Line 500 of 500 written: 49,900.20%
//'
//
//      Error stream: Successfully wrote 500 lines.
