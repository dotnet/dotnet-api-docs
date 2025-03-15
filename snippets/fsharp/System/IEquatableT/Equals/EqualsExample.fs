
// <Person>
open System

type Person(lastName: string, nationalId: string) =
    member this.LastName = lastName
    member this.NationalId = nationalId

    interface IEquatable<Person> with
        member this.Equals(other: Person) =
            other.NationalId = this.NationalId

    override this.Equals(obj: obj) =
        match obj with
        | :? Person as person -> (this :> IEquatable<Person>).Equals(person)
        | _ -> false

    override this.GetHashCode() =
        this.NationalId.GetHashCode()

    static member (==) (person1: Person, person2: Person) =
        person1.Equals(person2)

    static member (!=) (person1: Person, person2: Person) =
        not (person1.Equals(person2))
// </Person>

// <PersonSample>
let applicants = 
    [ Person("Jones", "099-29-4999")
      Person("Jones", "199-29-3999")
      Person("Jones", "299-49-6999") ]

let candidate = Person("Jones", "199-29-3999")
let contains = List.contains candidate applicants
printfn "%s (%s) is on record: %b" candidate.LastName candidate.NationalId contains
// The example prints the following output:
// Jones (199-29-3999) is on record: true
// </PersonSample>
