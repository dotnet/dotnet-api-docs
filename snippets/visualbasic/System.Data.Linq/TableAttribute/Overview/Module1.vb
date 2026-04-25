Imports System.Data.Linq
Imports System.Data.Linq.Mapping

Module Module1
    Sub Main()

    End Sub

End Module

' <Snippet1>
<Table(Name:="Customers")>
Public Class Customer
    ' ...
End Class
' </Snippet1>

Namespace ns

    ' <Snippet2>
    <Table(Name:="Customers")>
    Public Class Customer
        <Column(Name:="CustomerID")>
        Public CustomerID As String
        ' ...
    End Class
    ' </Snippet2>

End Namespace

Namespace ns2

    ' <Snippet3>
    <Table(Name:="Customers")>
    Public Class Customer
        <Column(IsPrimaryKey:=True)>
        Public CustomerID As String
        ' ...
        Private _orders As EntitySet(Of Order)
        <Association(Storage:="_Orders", OtherKey:="CustomerID")>
        Public Property Orders() As EntitySet(Of Order)
            Get
                Return _orders
            End Get
            Set(ByVal value As EntitySet(Of Order))
                _orders.Assign(value)
            End Set
        End Property
    End Class
    ' </Snippet3>

    ' <Snippet4>
    <Table()>
    <InheritanceMapping(Code:="C", Type:=GetType(Car))>
    <InheritanceMapping(Code:="T", Type:=GetType(Truck))>
    <InheritanceMapping(Code:="V", Type:=GetType(Vehicle),
        IsDefault:=True)>
    Public Class Vehicle
        <Column(IsDiscriminator:=True)>
        Private _discKey As String
        <Column(IsPrimaryKey:=True)>
        Private _vIN As String
        <Column()>
        Private _mfgPlant As String
    End Class

    Public Class Car
        Inherits Vehicle
        <Column()>
        Private _trimCode As Integer
        <Column()>
        Private _modelName As String
    End Class

    Public Class Truck
        Inherits Vehicle
        <Column()>
        Private _tonnage As Integer
        <Column()>
        Private _axles As Integer
    End Class
    ' </Snippet4>

    ' <Snippet5>
    <Table(Name:="Orders")>
    Public Class Order
        <Column(IsPrimaryKey:=True)>
        Public OrderID As Integer
        <Column()>
        Public CustomerID As String
        Private _customer As EntityRef(Of Customer)
        <Association(Storage:="Customer", ThisKey:="CustomerID")>
        Public Property Customer() As Customer
            Get
                Return _customer.Entity
            End Get
            Set(ByVal value As Customer)
                _customer.Entity = value
            End Set
        End Property
    End Class
    ' </Snippet5>

End Namespace
