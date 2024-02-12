module EqualsEx2

// <Snippet3>
open System
open System.Text.RegularExpressions

type Person(lastName, ssn) =
    let mutable lastName = lastName
    let ssn = 
        if Regex.IsMatch(ssn, @"\d{9}") then
            $"{ssn.Substring(0, 3)}-{ssn.Substring(3, 2)}-{ssn.Substring(5, 4)}"
        elif Regex.IsMatch(ssn, @"\d{3}-\d{2}-\d{4}") then
            ssn
        else
            raise (FormatException "The social security number has an invalid format.")

    member _.SSN =
        ssn

    member _.LastName
        with get () = lastName
        and set (value) =
            if String.IsNullOrEmpty value then
                invalidArg (nameof value) "The last name cannot be null or empty."
            else
                lastName <- value

    static member op_Equality (person1: Person, person2: Person) =
        if box person1 |> isNull || box person2 |> isNull then
            Object.Equals(person1, person2)
        else
            person1.Equals person2

    static member op_Inequality (person1: Person, person2: Person) =
        if box person1 |> isNull || box person2 |> isNull then
            Object.Equals(person1, person2) |> not
        else
            person1.Equals person2 |> not

    override _.GetHashCode() =
        ssn.GetHashCode()

    override this.Equals(obj: obj) =
        match obj with 
        | :? Person as personObj ->
            (this :> IEquatable<_>).Equals personObj
        | _ -> false

    interface IEquatable<Person> with
        member this.Equals(other: Person) =
            match box other with 
            | null -> false
            | _ ->
                this.SSN = other.SSN
// </Snippet3>
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

// This tests the handling of null values, but does not appear in the documentation.
//
//public class Example
//{
//   public static void Main()
//   {
//      var p1 = new Person("Joe", "613-24-0068")
//      Person p2 = null
//
//      Console.WriteLine(p1 == p2)
//   }
//}