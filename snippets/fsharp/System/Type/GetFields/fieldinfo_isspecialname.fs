module fieldinfo_isspecialname

// <Snippet1>
open System.ComponentModel.Design

try
    // Get the type handle of a specified class.
    let myType = typeof<ViewTechnology>

    // Get the fields of the specified class.
    let myFields = myType.GetFields()

    printfn $"\nDisplaying fields that have SpecialName attributes:\n"
    for field in myFields do
        // Determine whether or not each field is a special name.
        if field.IsSpecialName then
            printfn $"The field {field.Name} has a SpecialName attribute."
with e ->
    printfn $"Exception : {e.Message} "
// </Snippet1>