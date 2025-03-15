' Visual Basic .NET Document
Option Strict On

' <Person>
Public Class Person
    Implements IEquatable(Of Person)

    Public Sub New(lastName As String, nationalId As String)
        Me.LastName = lastName
        Me.NationalId = nationalId
    End Sub

    Public ReadOnly Property LastName As String
    Public ReadOnly Property NationalId As String

    Public Overloads Function Equals(other As Person) As Boolean Implements IEquatable(Of Person).Equals
        Return other IsNot Nothing AndAlso other.NationalId = Me.NationalId
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return Equals(TryCast(obj, Person))
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return NationalId.GetHashCode()
    End Function

    Public Shared Operator =(person1 As Person, person2 As Person) As Boolean
        If person1 Is Nothing Then
            Return person2 Is Nothing
        End If
        Return person1.Equals(person2)
    End Operator

    Public Shared Operator <>(person1 As Person, person2 As Person) As Boolean
        If person1 Is Nothing Then
            Return person2 IsNot Nothing
        End If
        Return Not person1.Equals(person2)
    End Operator
End Class
' </Person>

Module EqualsExample
    Public Sub Main()
        ' <PersonSample>
        Dim applicants As New List(Of Person)
        applicants.Add(New Person("Jones", "099-29-4999"))
        applicants.Add(New Person("Jones", "199-29-3999"))
        applicants.Add(New Person("Jones", "299-49-6999"))

        ' Create a Person object for the final candidate.
        Dim candidate As New Person("Jones", "199-29-3999")
        Dim contains As Boolean = applicants.Contains(candidate)
        Console.WriteLine($"{candidate.LastName} ({candidate.NationalId}) is on record: {contains}")
        ' The example prints the following output:
        ' Jones (199-29-3999) Is on record True
        ' </PersonSample>
    End Sub
End Module

