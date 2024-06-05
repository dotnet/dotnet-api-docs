namespace global

// <Snippet2>
open System

module StringLib =
    let private exceptionList = [ "a"; "an"; "the"; "in"; "on"; "of" ]
    let private separators = [| ' ' |]

    [<CompiledName "ToProperCase">]
    let toProperCase (title: string) =
        title.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        |> Array.mapi (fun i word ->
            if i <> 0 && List.contains word exceptionList then
                word
            else 
                word[0..0].ToUpper() + word[1..])
        |> String.concat " "

// Attempting to load the StringLib.dll assembly produces the following output:
//    Unhandled Exception: System.BadImageFormatException:
//                         The format of the file 'StringLib.dll' is invalid.
// </Snippet2>