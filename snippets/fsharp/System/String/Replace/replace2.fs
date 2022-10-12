module replace2

// <Snippet2>
let s = new string('a', 3)
printfn $"The initial string: '{s}'"
let s2 = s.Replace('a', 'b').Replace('b', 'c').Replace('c', 'd')
printfn $"The final string: '{s2}'"

// The example displays the following output:
//       The initial string: 'aaa'
//       The final string: 'ddd'
// </Snippet2>