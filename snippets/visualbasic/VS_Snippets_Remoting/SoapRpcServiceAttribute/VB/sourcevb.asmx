<%@ WebService Language="VB" Class="SumService" %>

Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Services.Description

	<SoapRpcServiceAttribute(RoutingStyle:=SoapServiceRoutingStyle.SoapAction)> _
	Public Class SumService 
          Inherits System.Web.Services.WebService
	
		<WebMethod> _
		Public Function Add(a As Integer, b as Integer)
		   return a + b
		End Function
	End Class