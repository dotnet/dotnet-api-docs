module example2

// <Snippet3>
let populateNames (names: ResizeArray<string>) =
    let arrNames =
        [ "Dakota"; "Samuel"; "Nikita"
          "Koani"; "Saya"; "Yiska"; "Yumaevsky" ]
    for arrName in arrNames do
        names.Add arrName

let getData () : ResizeArray<string> =
    null

let names = getData ()
populateNames names

// The example displays output like the following:
//    Unhandled Exception: System.NullReferenceException: Object reference
//    not set to an instance of an object.
//       at Example.PopulateNames(List`1 names)
//       at <StartupCode$fs>.main()
// </Snippet3>