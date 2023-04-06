module StartsWith2.fs
// <Snippet2>
open System

let title = "The House of the Seven Gables"
let searchString = "the"
let comparison = StringComparison.InvariantCulture
printfn $"'{title}':"
printfn $"   Starts with '{searchString}' ({comparison:G} comparison): {title.StartsWith(searchString, comparison)}"

let comparison2 = StringComparison.InvariantCultureIgnoreCase
printfn $"   Starts with '{searchString}' ({comparison2:G} comparison): {title.StartsWith(searchString, comparison2)}"
// The example displays the following output:
//       'The House of the Seven Gables':
//          Starts with 'the' (InvariantCulture comparison): False
//          Starts with 'the' (InvariantCultureIgnoreCase comparison): True
// </Snippet2>
