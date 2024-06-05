﻿'<snippet1>
Imports System.Reflection

Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]

            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)

            'In a simple project with only one module, the module at index
            ' 0 will be the module containing this class.
            Dim myModule As [Module] = moduleArray(0)

            Console.WriteLine("myModule.IsResource() = {0}", myModule.IsResource())
        End Sub
    End Class
End Namespace 'ReflectionModule_Examples
'</snippet1>