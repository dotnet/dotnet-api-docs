module stringinsert.fs
// <Snippet1>
open System

let animal1 = "fox"
let animal2 = "dog"

let strTarget = String.Format("The {0} jumps over the {1}.", animal1, animal2)

do
    printfn $"The original string is:{Environment.NewLine}{strTarget}{Environment.NewLine}"

    printf $"Enter an adjective (or group of adjectives) to describe the {animal1}: => "
    let adj1 = stdin.ReadLine()

    printf $"Enter an adjective (or group of adjectives) to describe the {animal2}: => "
    let adj2 = stdin.ReadLine()

    let adj1 = adj1.Trim() + " "
    let adj2 = adj2.Trim() + " "

    let strTarget = strTarget.Insert(strTarget.IndexOf animal1, adj1)
    let strTarget = strTarget.Insert(strTarget.IndexOf animal2, adj2)

    printfn $"{Environment.NewLine}The final string is:{strTarget}{Environment.NewLine}"
// Output from the example might appear as follows:
//       The original string is:
//       The fox jumps over the dog.
//
//       Enter an adjective (or group of adjectives) to describe the fox: => bold
//       Enter an adjective (or group of adjectives) to describe the dog: => lazy
//
//       The final string is:
//       The bold fox jumps over the lazy dog.
// </Snippet1>
