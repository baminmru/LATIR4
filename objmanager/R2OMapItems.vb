

Option Explicit On

Friend Class R2OMapItems
    Implements System.Collections.IEnumerable
    Private mCol As Collection


    Public Function Add(ByRef RowID As Guid) As R2OMap

        Dim objNewMember As R2OMap
        objNewMember = New R2OMap

        objNewMember.RowID = RowID
        mCol.Add(objNewMember, RowID.ToString)

        Return objNewMember


    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As R2OMap
        Get
            Try

                If IsNumeric(vntIndexKey) Then
                    Return CType(mCol.Item(vntIndexKey.ToString), R2OMap)
                Else
                    If mCol.Contains(vntIndexKey.ToString) Then
                        Return CType(mCol.Item(vntIndexKey.ToString), R2OMap)
                    End If
                End If
            Catch
                Return Nothing
            End Try
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


   
    Public Sub New()
        MyBase.New()
        mCol = New Collection
    End Sub

    Protected Overrides Sub Finalize()
        mCol = Nothing
        MyBase.Finalize()
    End Sub

    Friend Sub Dispose()
        If mCol Is Nothing Then Exit Sub
        mCol = Nothing
    End Sub
End Class


