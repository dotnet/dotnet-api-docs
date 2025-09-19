module length2

// <Snippet4>
let characters = ResizeArray()
characters.InsertRange(0, [| 'a'; 'b'; 'c'; 'd'; 'e'; 'f' |])

for i = 0 to characters.Count - 1 do
    printf $"'{characters[i]}'    "
// The example displays the following output:
//        'a'    'b'    'c'    'd'    'e'    'f'
// </Snippet4>