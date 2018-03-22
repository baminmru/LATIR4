Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("JOrders_NET.JOrders")> Public Class JOrders
    Implements System.Collections.IEnumerable

    'local variable to hold collection
    Private mCol As Collection

    Public Function Add(ByVal OrderString As String, ByVal ViewName As String) As JOrder
        'create a new object
        Dim objNewMember As JOrder

        On Error Resume Next

        objNewMember = mCol.Item(ViewName)
        If objNewMember Is Nothing Then
            objNewMember = New JOrder
            objNewMember.ViewName = ViewName
            objNewMember.OrderString = OrderString
            mCol.Add(objNewMember, ViewName)
        End If
        objNewMember.OrderString = OrderString

        'return the object created
        Add = objNewMember
       objNewMember = Nothing


    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As JOrder
        Get
            On Error Resume Next
            Item = mCol.Item(vntIndexKey)
        End Get
    End Property



    Public ReadOnly Property Count() As Integer
        Get
            Count = mCol.Count()
        End Get
    End Property



    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        'GetEnumerator = mCol.GetEnumerator
    End Function


    Public Sub Remove(ByRef vntIndexKey As Object)


        On Error Resume Next
        mCol.Remove(vntIndexKey)
    End Sub



    Private Sub Class_Initialize_Renamed()

        mCol = New Collection
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub


    Private Sub Class_Terminate_Renamed()

        mCol = Nothing
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub
End Class