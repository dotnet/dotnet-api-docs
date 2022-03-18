﻿Imports System.Reflection
Imports System.Reflection.Emit

Public Class Example

    Private Shared timer As Object
    
    Public Shared Sub Main() 
        ' Get the Timer type.
        Dim t As Type = GetType(System.Timers.Timer)
        ' Create an instance of the Timer type.
        timer = Activator.CreateInstance(t)
        
        ' Use reflection to get the Elapsed event.
        Dim eInfo As EventInfo = t.GetEvent("Elapsed")
        
        ' In order to create a method to handle the Elapsed event,
        ' it is necessary to know the signature of the delegate 
        ' used to raise the event. Reflection.Emit can then be
        ' used to construct a dynamic class with a static method
        ' that has the correct signature.
        '
        ' Get the event handler type of the Elapsed event. This is
        ' a delegate type, so it has an Invoke method that has
        ' the same signature as the delegate. The following code
        ' creates an array of Type objects that represent the 
        ' parameter types of the Invoke method.
        '
        Dim handlerType As Type = eInfo.EventHandlerType
        Dim invokeMethod As MethodInfo = handlerType.GetMethod("Invoke")
        Dim parms As ParameterInfo() = invokeMethod.GetParameters()
        '
        ' Note that in Visual Basic you must dimension the array one
        ' unit smaller than the source array in order to get an array
        ' of the same size. This is because Visual Basic adds an extra
        ' element to every array, for ease of use.
        '
        Dim parmTypes(parms.Length - 1) As Type
        Dim i As Integer
        For i = 0 To parms.Length - 1
            parmTypes(i) = parms(i).ParameterType
        Next i
        
        ' Use Reflection.Emit to create a dynamic assembly that
        ' will be run but not saved. An assembly must have at 
        ' least one module, which in this case contains a single
        ' type. The only purpose of this type is to contain the 
        ' event handler method. (You can alsso use dynamic methods, 
        ' which are simpler because there is no need to create an 
        ' assembly, module, or type.)
        Dim aName As New AssemblyName()
        aName.Name = "DynamicTypes"
        Dim ab As AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run)
        Dim mb As ModuleBuilder = ab.DefineDynamicModule(aName.Name)
        Dim tb As TypeBuilder = mb.DefineType("Handler", TypeAttributes.Class Or TypeAttributes.Public)
        
        ' Create the method that will handle the event. The name
        ' is not important. The method is Shared ("static" in 
        ' reflection), because there is no reason to create an 
        ' instance of the dynamic type "Handler".
        '
        ' The parameter types and return type of the method are
        ' the same as those of the delegate's Invoke method, 
        ' captured earlier.
        Dim handler As MethodBuilder = tb.DefineMethod("DynamicHandler", MethodAttributes.Public Or MethodAttributes.Static, invokeMethod.ReturnType, parmTypes)
        
        ' Generate code to handle the event. In this case, the 
        ' handler simply prints a text string to the console.
        '
        Dim il As ILGenerator = handler.GetILGenerator()
        il.EmitWriteLine("Timer's Elapsed event is raised.")
        il.Emit(OpCodes.Ret)
        
        ' CreateType must be called before the Handler type can
        ' be used. In order to create the delegate that will
        ' handle the event, a MethodInfo from the finished type
        ' is required.
        Dim finished As Type = tb.CreateType()
        Dim eventHandler As MethodInfo = finished.GetMethod("DynamicHandler")
        
        ' Use the MethodInfo to create a delegate of the correct 
        ' type, and call the AddEventHandler method to hook up 
        ' the event.
        Dim d As [Delegate] = [Delegate].CreateDelegate(handlerType, eventHandler)
        eInfo.AddEventHandler(timer, d)
        
        ' Late-bound calls to the Interval and Enabled property 
        ' are required to enable the timer with a one-second
        ' interval.
        t.InvokeMember("Interval", BindingFlags.SetProperty, Nothing, timer, New [Object]() {1000})
        t.InvokeMember("Enabled", BindingFlags.SetProperty, Nothing, timer, New [Object]() {True})
        
        Console.WriteLine("Press the Enter key to end the program.")
        Console.ReadLine()
    
    End Sub 
End Class 
' This example produces output similar to the following:
'      Press the Enter key to end the program.
'      Timer's Elapsed event is raised.
'      Timer's Elapsed event is raised.
'      Timer's Elapsed event is raised.

