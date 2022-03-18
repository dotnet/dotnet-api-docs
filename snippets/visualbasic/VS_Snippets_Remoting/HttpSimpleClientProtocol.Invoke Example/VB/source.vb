﻿'<Snippet1>
Namespace MyMath
    
    <System.Web.Services.WebServiceBindingAttribute(Name:="MathSoap", [Namespace]:="http://tempuri.org/")>  _
    Public Class Math
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.Url = "http://www.contoso.com/math.asmx"
        End Sub
        
        <System.Diagnostics.DebuggerStepThroughAttribute(),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Add(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
            Dim results() As Object = Me.Invoke("Add", New Object() {num1, num2})
            Return CType(results(0),Integer)
        End Function
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Function BeginAdd(ByVal num1 As Integer, ByVal num2 As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Add", New Object() {num1, num2}, callback, asyncState)
        End Function
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Function EndAdd(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
    End Class
End Namespace
'</Snippet1>