<%@ WebService Language="VB" Class="Operation_2_Service" %>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services

Public Class Operation_2_Service
   Inherits System.Web.Services.WebService
   
   <WebMethod()>  _
   Public Function AddNumbers(firstNumber As Integer, secondNumber As Integer) As Integer
      Return firstNumber + secondNumber
   End Function 'AddNumbers
End Class 'Operation_2_Service