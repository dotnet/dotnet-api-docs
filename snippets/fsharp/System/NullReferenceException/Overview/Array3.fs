module Array3

// <Snippet10>
let values: int[] = null
for i = 0 to 9 do
    values[i] <- i * 2

for value in values do
    printfn $"{value}"
// The example displays the following output:
//    Unhandled Exception:
//       System.NullReferenceException: Object reference not set to an instance of an object.
//       at <StartupCode$fs>.main()
// </Snippet10>