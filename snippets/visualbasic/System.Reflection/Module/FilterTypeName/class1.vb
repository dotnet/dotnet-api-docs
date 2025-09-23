﻿' <snippet1>
Imports System.Reflection

Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]

            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)

            ' In a simple project with only one module, the module at index
            ' 0 will be the module containing these classes.
            Dim myModule As [Module] = moduleArray(0)

            Dim tArray() As Type

            tArray = myModule.FindTypes([Module].FilterTypeName, "My*")

            Dim t As Type
            For Each t In tArray
                Console.WriteLine("Found a module beginning with My*: {0}", t.Name)
            Next t
        End Sub
    End Class

    Class MySecondClass
    End Class

    ' This class does not fit the filter criteria My*.
    Class YourClass
    End Class
End Namespace 'ReflectionModule_Examples
' </snippet1>