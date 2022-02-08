module NoElements2

// <Snippet13>
let numbers = ResizeArray<int>()
numbers.AddRange [ 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 20 ]

let squares = ResizeArray<int>()
for  ctr = 0 to numbers.Count - 1 do
    squares[ctr] <- int (float numbers[ctr] ** 2)

// The example displays the following output:
//    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
//       at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
//       at <StartupCode$argumentoutofrangeexception>.$NoElements.main@()
// </Snippet13>

module Correction =
    let test () =
        let numbers = ResizeArray<int>()
        numbers.AddRange [| 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 20 |]
        // <Snippet14>
        let squares = ResizeArray<int>()
        for ctr = 0 to numbers.Count - 1 do
            squares.Add(int (float numbers[ctr] ** 2))
        // </Snippet14>
   