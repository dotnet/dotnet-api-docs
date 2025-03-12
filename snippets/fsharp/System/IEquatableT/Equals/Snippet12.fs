open System
open System.Collections.Generic
open System.Text.RegularExpressions

open System

type Person(lastName: string, ssn: string) =
    member this.LastName = lastName
    member this.SSN = ssn

    interface IEquatable<Person> with
        member this.Equals(other: Person) =
            other.SSN = this.SSN

    override this.Equals(obj: obj) =
        match obj with
        | :? Person as person -> (this :> IEquatable<Person>).Equals(person)
        | _ -> false

    override this.GetHashCode() =
        this.SSN.GetHashCode()

    static member (==) (person1: Person, person2: Person) =
        person1.Equals(person2)

    static member (!=) (person1: Person, person2: Person) =
        not (person1.Equals(person2))

// <Snippet12>
// Create a Person object for each job applicant.
let applicant1 = Person("Jones", "099-29-4999")
let applicant2 = Person("Jones", "199-29-3999")
let applicant3 = Person("Jones", "299-49-6999")

// Add applicants to a List object.
let applicants = ResizeArray()
applicants.Add applicant1
applicants.Add applicant2
applicants.Add applicant3

// Create a Person object for the final candidate.
let candidate = Person("Jones", "199-29-3999")
if applicants.Contains candidate then
    printfn $"Found {candidate.LastName} (SSN {candidate.SSN})."
else
    printfn $"Applicant {candidate.SSN} not found."

// Call the shared inherited Equals(Object, Object) method.
// It will in turn call the IEquatable<T>.Equals implementation.
printfn $"{applicant2.LastName}({applicant2.SSN}) already on file: {Person.Equals(applicant2, candidate)}."

// The example displays the following output:
//       Found Jones (SSN 199-29-3999).
//       Jones(199-29-3999) already on file: True.
// </Snippet12>