Option Strict Off
Option Explicit On 

Friend Class LoadedGUIs
    Implements System.Collections.IEnumerable
    Private mCol As Collection


    Public Function Add(ByRef TypeName As String) As LoadedGUI

        Dim objNewMember As LoadedGUI

        On Error Resume Next
        objNewMember = Item(TypeName)
        If objNewMember Is Nothing Then
            objNewMember = New LoadedGUI
            mCol.Add(objNewMember, TypeName)
        End If
        Add = objNewMember
        objNewMember = Nothing
    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As LoadedGUI
        Get
            On Error Resume Next
            Item = Nothing
            If IsNumeric(vntIndexKey) Then
                IsNumeric(vntIndexKey)
            Else
                If mCol.Contains(vntIndexKey.ToString) Then
                    Item = mCol.Item(vntIndexKey)
                End If
            End If
            
        End Get
    End Property



    Public ReadOnly Property Count() As Integer
        Get
            Count = mCol.Count()
        End Get
    End Property



    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        GetEnumerator = mCol.GetEnumerator
    End Function


    Public Sub Remove(ByVal vntIndexKey As Object)

        If IsNumeric(vntIndexKey) Then
            mCol.Remove(CInt(vntIndexKey))
        Else
            If vntIndexKey.GetType.Name = "Guid" Then
                mCol.Remove(vntIndexKey.ToString)
            Else
                mCol.Remove(CStr(vntIndexKey))
            End If
        End If

    End Sub


    Private Sub Class_Initialize_Renamed()

    End Sub
    Public Sub New()
        MyBase.New()
        mCol = New Collection
    End Sub

    Protected Overrides Sub Finalize()
        mCol = Nothing
        MyBase.Finalize()
    End Sub

    Friend Sub Dispose()
        Dim oi As LoadedGUI
        On Error Resume Next
        For Each oi In mCol
            If Not oi.GUI Is Nothing Then
                'oi.GUI.Dispose()
                oi.GUI = Nothing
                oi.TypeName = ""
            End If
        Next oi
    End Sub
End Class
