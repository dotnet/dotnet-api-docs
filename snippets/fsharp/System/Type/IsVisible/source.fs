//<Snippet1>
module internal InternalOnly = 
    type Nested() = class end

module Example =
    type Nested() = class end

let t = typeof<InternalOnly.Nested>
printfn $"Is the {t.FullName} class visible outside the assembly? {t.IsVisible}" 

let t2 = typeof<Example.Nested>
printfn $"Is the {t2.FullName} class visible outside the assembly? {t2.IsVisible}" 

(* This example produces the following output:

Is the InternalOnly+Nested class visible outside the assembly? False
Is the Example+Nested class visible outside the assembly? True
 *)
//</Snippet1>