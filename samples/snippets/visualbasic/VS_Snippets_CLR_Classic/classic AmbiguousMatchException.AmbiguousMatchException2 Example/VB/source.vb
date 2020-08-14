﻿' <Snippet1>
Imports System.Reflection

Namespace Ambiguity
    Class Myambiguous

        'The first overload is typed to an Int32
        Overloads Public Shared Sub Mymethod(number As Int32)
            Console.WriteLine("I am from 'Int32' method")
        End Sub

        'The second overload is typed to a string
        Overloads Public Shared Sub Mymethod(alpha As String)
            Console.WriteLine("I am from 'string' method.")
        End Sub

        Public Shared Sub Main()
            Try
                'The following does not cause as exception
                Mymethod(2) ' goes to Mymethod Int32)
                Mymethod("3") ' goes to Mymethod(string)
                Dim Mytype As Type = Type.GetType("Ambiguity.Myambiguous")

                Dim Mymethodinfo32 As MethodInfo = Mytype.GetMethod("Mymethod", New Type() {GetType(Int32)})
                Dim Mymethodinfostr As MethodInfo = Mytype.GetMethod("Mymethod", New Type() {GetType(System.String)})

                'Invoke a method, utilizing a Int32 integer
                Mymethodinfo32.Invoke(Nothing, New Object() {2})

                'Invoke the method utilizing a string
                Mymethodinfostr.Invoke(Nothing, New Object() {"1"})

                'The following line causes an ambiguious exception
                Dim Mymethodinfo As MethodInfo = Mytype.GetMethod("Mymethod")
                ' end of try block
            Catch ex As AmbiguousMatchException
                Console.WriteLine(Environment.NewLine + "{0}" + Environment.NewLine + "{1}", ex.GetType().FullName, ex.Message)
            Catch
                Console.WriteLine(Environment.NewLine + "Some other exception.")
            End Try
            Return
        End Sub
    End Class
End Namespace
' This code produces the following output:
'
' I am from 'Int32' method
' I am from 'string' method.
' I am from 'Int32' method
' I am from 'string' method.
'
' System.Reflection.AmbiguousMatchException
' Ambiguous match found.
' </Snippet1>
