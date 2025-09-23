module Write500Lines

for i in 1. .. 500. do
    printfn $"Line {i} of 500 written: {i/500.:P2}";

eprintfn "Successfully wrote 500 lines.";
// The example displays the following output:
//      Line 1 of 500 written: 0,20%
//      Line 2 of 500 written: 0,40%
//      Line 3 of 500 written: 0,60%
//      ...
//      Line 498 of 500 written: 99,60%
//      Line 499 of 500 written: 99,80%
//      Line 500 of 500 written: 100,00%
//      Successfully wrote 500 lines.
