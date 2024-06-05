module length1

// <Snippet3>
let characters = ResizeArray()
characters.InsertRange(0, [| 'a'; 'b'; 'c'; 'd'; 'e'; 'f' |])

for i = 0 to characters.Count do
    printf $"'{characters[i]}'    "
// The example displays the following output:
//    'a'    'b'    'c'    'd'    'e'    'f'
//    Unhandled Exception:
//    System.ArgumentOutOfRangeException:
//    Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at <StartupCode$fs>.main@()
// </Snippet3>