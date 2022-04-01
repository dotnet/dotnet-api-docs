module Trim2

// <Snippet2>
printf "Enter your first name: "
let firstName = stdin.ReadLine()

printf "Enter your middle name or initial: "
let middleName = stdin.ReadLine()

printf "Enter your last name: "
let lastName = stdin.ReadLine()

printfn $"\nYou entered '{firstName}', '{middleName}', and '{lastName}'." 

let name = ((firstName.Trim() + " " + middleName.Trim()).Trim() + " " + lastName.Trim()).Trim()
printfn $"The result is {name}."

// The following is a possible output from this example:
//       Enter your first name:    John
//       Enter your middle name or initial:
//       Enter your last name:    Doe
//       
//       You entered '   John  ', '', and '   Doe'.
//       The result is John Doe.
// </Snippet2>