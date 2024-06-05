module WriteParams1

// <Snippet1>
open System

type Person =
    { Name: string
      BirthDate: DateOnly
      Height: double
      Weight: double
      Gender: char
      Remarks: string }

    member this.GetDescription(): obj [] =
        [| this.Name; this.Gender; this.Height; this.Weight; this.BirthDate |]

let p1 = 
    { Name = "John"
      Gender = 'M'
      BirthDate = DateOnly(1992, 5, 10)
      Height = 73.5
      Weight = 207
      Remarks = "Client since 1/3/2012" }

Console.Write("{0}: {1}, born {4:d}  Height {2} inches, Weight {3} lbs  ", p1.GetDescription())

if String.IsNullOrEmpty p1.Remarks then
    Console.WriteLine()
else
    Console.WriteLine $"""{if Console.CursorLeft + p1.Remarks.Length + 10 > Console.WindowWidth then "\n   " else ""}Remarks: {p1.Remarks}"""


// The example displays the following output:
//    John: M, born 5/10/1992  Height 73.5 inches, Weight 207 lbs  Remarks: Client since 1/3/2012
// </Snippet1>