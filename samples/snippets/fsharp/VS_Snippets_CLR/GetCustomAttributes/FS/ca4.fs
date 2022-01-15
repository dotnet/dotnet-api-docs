module ca4

// <Snippet4>
open System
open System.Runtime.InteropServices

// Define an enumeration of Win32 unmanaged types
type UnmanagedType =
    | User = 0
    | GDI = 1
    | Kernel = 2
    | Shell = 3
    | Networking = 4
    | Multimedia = 5

// Define the Unmanaged attribute.
type UnmanagedAttribute(unmanagedType) =
    inherit Attribute()
    
    // Define a property to get and set the UnmanagedType value.
    member val Win32Type = unmanagedType with get, set

// Create a module for an imported Win32 unmanaged function.
module Win32 =
    [<DllImport("user32.dll", CharSet = CharSet.Unicode)>]
    extern int MessageBox(IntPtr hWnd, String text, String caption, uint ``type``)

type AClass() =
    // Add some attributes to Win32CallMethod.
    [<Obsolete "This method is obsolete. Use managed MsgBox instead.">]
    [<Unmanaged(UnmanagedType.User)>]
    member _.Win32CallMethod () =
        Win32.MessageBox(0, "This is an unmanaged call.", "Caution!", 0u)

// Get the AClass type to access its metadata.
let clsType = typeof<AClass>
// Get the type information for Win32CallMethod.
let mInfo = clsType.GetMethod "Win32CallMethod"
if mInfo <> null then
    // Iterate through all the attributes of the method.
    for attr in Attribute.GetCustomAttributes mInfo do
        match attr with 
        // Check for the Obsolete attribute.
        | :? ObsoleteAttribute as attr ->
            printfn $"Method {mInfo.Name} is obsolete. The message is:"
            printfn $"  \"{attr.Message}\""

        // Check for the Unmanaged attribute.
        | :? UnmanagedAttribute as attr ->
            printfn "This method calls unmanaged code."
            printfn $"The Unmanaged attribute type is {attr.Win32Type}."
            let myCls = AClass()
            myCls.Win32CallMethod() |> ignore
        | _ -> ()

// This code example produces the following results.
//
// First, the compilation yields the warning, "... This method is
// obsolete. Use managed MsgBox instead."
// Second, execution yields a message box with a title of "Caution!"
// and message text of "This is an unmanaged call."
// Third, the following text is displayed in the console window:

// Method Win32CallMethod is obsolete. The message is:
//   "This method is obsolete. Use managed MsgBox instead."
// This method calls unmanaged code.
// The Unmanaged attribute type is User.

// </Snippet4>