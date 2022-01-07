// <snippet19>
let chA = 'A'
let chB = 'B'

printfn $"{chA.CompareTo 'A'}"  // Output: "0" (meaning they're equal)
printfn $"{'b'.CompareTo chB}"  // Output: "32" (meaning 'b' is greater than 'B' by 32)
printfn $"{chA.CompareTo chB}"  // Output: "-1" (meaning 'A' is less than 'B' by 1)

// </snippet19>