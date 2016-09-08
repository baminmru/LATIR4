
Option Explicit On


Public Class RowParentList
    Implements System.Collections.IEnumerable

    'local variable to hold collection
    Private mCol As Collection

    Public Function Add(ByRef RowID As Guid, ByRef PartName As String, Optional ByRef sKey As String = "") As RowParentItem
        'create a new object
        Dim objNewMember As RowParentItem
        objNewMember = New RowParentItem


        'set the properties passed into the method
        objNewMember.RowID = RowID
        objNewMember.PartName = PartName
        If Len(sKey) = 0 Then
            mCol.Add(objNewMember)
        Else
            mCol.Add(objNewMember, sKey)
        End If


        Return objNewMember
       
    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As RowParentItem
        Get

            If IsNumeric(vntIndexKey) Then
                Return CType(mCol.Item(vntIndexKey), RowParentItem)
            Else
                If mCol.Contains(vntIndexKey.ToString) Then
                    Return CType(mCol.Item(vntIndexKey.ToString), RowParentItem)
                End If
            End If
            Return Nothing
        End Get
    End Property



    Public ReadOnly Property Count() As Integer
        Get
            Return mCol.Count()
        End Get
    End Property


    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function


    Public Sub Remove(ByRef vntIndexKey As Object)
        If IsNumeric(vntIndexKey) Then
            mCol.Remove(CType(vntIndexKey, Integer))
        Else
            If mCol.Contains(vntIndexKey.ToString) Then
                mCol.Remove(vntIndexKey.ToString)
            End If
        End If

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
