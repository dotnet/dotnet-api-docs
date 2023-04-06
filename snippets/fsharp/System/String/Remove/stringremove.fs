module stringremove

//<snippet1>
let name = "Michelle Violet Banks"

printfn $"The entire name is '{name}'"

// Remove the middle name, identified by finding the spaces in the name.
let foundS1 = name.IndexOf " "
let foundS2 = name.IndexOf(" ", foundS1 + 1)

if foundS1 <> foundS2 && foundS1 >= 0 then
    let name = name.Remove(foundS1 + 1, foundS2 - foundS1)

    printfn $"After removing the middle name, we are left with '{name}'"
// The example displays the following output:
//       The entire name is 'Michelle Violet Banks'
//       After removing the middle name, we are left with 'Michelle Banks'
//</snippet1>