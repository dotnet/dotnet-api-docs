module NoFind1

// <Snippet17>
let getSecondWord (s: string) =
    let pos = s.IndexOf " "
    s.Substring(pos).Trim()

let phrases = [ "ocean blue"; "concerned citizen"; "runOnPhrase" ]
for phrase in phrases do
    printfn $"Second word is {getSecondWord phrase}"

// The example displays the following output:
//    Second word is blue
//    Second word is citizen
//
//    Unhandled Exception: System.ArgumentOutOfRangeException: StartIndex cannot be less than zero. (Parameter 'startIndex')
//       at System.String.Substring(Int32 startIndex, Int32 length)
//       at System.String.Substring(Int32 startIndex)
//       at NoFind1.getSecondWord(String s)
//       at <StartupCode$argumentoutofrangeexception>.$NoFind1.main@()
// </Snippet17>
