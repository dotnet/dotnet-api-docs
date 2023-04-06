module equals1

// <Snippet1>
let values: obj[] = 
    [| 10s; 20s; 10; 20
       10L; 20L; 10.; 20.; 10us
       20us; 10u; 20u
       10uL; 20uL |]
let baseValue = 20uL
let baseType = baseValue.GetType().Name

for value in values do
    printfn $"{baseValue} ({baseType}) = {value} ({value.GetType().Name}): {value.GetType().Name}"
// The example displays the following output:
//       20 (UInt64) = 10 (Int16): False
//       20 (UInt64) = 20 (Int16): False
//       20 (UInt64) = 10 (Int32): False
//       20 (UInt64) = 20 (Int32): False
//       20 (UInt64) = 10 (Int64): False
//       20 (UInt64) = 20 (Int64): False
//       20 (UInt64) = 10 (Double): False
//       20 (UInt64) = 20 (Double): False
//       20 (UInt64) = 10 (UInt16): False
//       20 (UInt64) = 20 (UInt16): False
//       20 (UInt64) = 10 (UInt32): False
//       20 (UInt64) = 20 (UInt32): False
//       20 (UInt64) = 10 (UInt64): False
//       20 (UInt64) = 20 (UInt64): True
// </Snippet1>