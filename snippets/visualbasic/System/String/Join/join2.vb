<<<<<<< HEAD
﻿'<snippet1>
Class Sample
   Public Shared Sub Main()
      Dim val As [String]() =  {"apple", "orange", "grape", "pear"}
      Dim sep As [String] = ", "
      Dim result As [String]
      
      Console.WriteLine("sep = '{0}'", sep)
      Console.WriteLine("val() = {{'{0}' '{1}' '{2}' '{3}'}}", val(0), val(1), val(2), val(3))
      result = [String].Join(sep, val, 1, 2)
      Console.WriteLine("String.Join(sep, val, 1, 2) = '{0}'", result)
   End Sub
End Class 
'This example displays the following output:
'       sep = ', '
'       val() = {'apple' 'orange' 'grape' 'pear'}
'       String.Join(sep, val, 1, 2) = 'orange, grape'
'</snippet1>
=======
﻿' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim maxPrime As Integer = 100
      Dim primes As List(Of Integer) = GetPrimes(maxPrime)
      Console.WriteLine("Primes less than {0}:", maxPrime)
      Console.WriteLine("   {0}", String.Join(" ", primes))
   End Sub
   
   Private Function GetPrimes(maxPrime As Integer) As List(Of Integer)
      Dim values As Array = Array.CreateInstance(GetType(Integer), _
                              New Integer() { maxPrime - 1}, New Integer(){ 2 }) 
        ' Use Sieve of Eratosthenes to determine prime numbers.
      For ctr As Integer = values.GetLowerBound(0) To _
                           CInt(Math.Ceiling(Math.Sqrt(values.GetUpperBound(0))))
         If CInt(values.GetValue(ctr)) = 1 Then Continue For
         
         For multiplier As Integer = ctr To maxPrime \ 2
            If ctr * multiplier <= maxPrime Then values.SetValue(1, ctr * multiplier)
         Next   
      Next      
      
      Dim primes As New System.Collections.Generic.List(Of Integer)
      For ctr As Integer = values.GetLowerBound(0) To values.GetUpperBound(0)
         If CInt(values.GetValue(ctr)) = 0 Then primes.Add(ctr)
      Next            
      Return primes
   End Function   
End Module
' The example displays the following output:
'    Primes less than 100:
'       2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97
' </Snippet2>
>>>>>>> 888bb64f55349b13f1342f20d22b825c7eb339d7
