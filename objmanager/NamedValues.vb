Option Strict Off
Option Explicit On 


Public Class NamedValues
    Private mCol As Collection
    Private sortIndex() As Integer
    Private sortValue() As Object
    Private sorted As Boolean


    Public Function Add(ByVal TheName As String, ByVal Value As Object, ByVal dbtype As DbType, ByVal Direction As ParameterDirection) As NamedValue
        Dim nv As NamedValue
        nv = Add(TheName, Value)
        nv.DataType = dbtype
        nv.Direction = Direction
        Return nv
    End Function

    Public Function Add(ByVal TheName As String, ByVal Value As Object, ByVal dbtype As DbType, ByVal Size As Integer, ByVal Direction As ParameterDirection) As NamedValue
        Dim nv As NamedValue
        nv = Add(TheName, Value)
        nv.DataType = dbtype
        nv.Direction = Direction
        If Size > 0 Then
            nv.Size = Size
        End If
        Return nv
    End Function

    Public Function Add(ByVal TheName As String, ByVal Value As Object, ByVal dbtype As DbType) As NamedValue
        Dim nv As NamedValue
        nv = Add(TheName, Value)
        nv.DataType = dbtype
        Return nv
    End Function

    Public Function Add(ByVal TheName As String, ByVal Value As Object, ByVal dbtype As DbType, ByVal Size As Integer) As NamedValue
        Dim nv As NamedValue
        nv = Add(TheName, Value)
        nv.DataType = dbtype
        If Size > 0 Then
            nv.Size = Size
        End If
        Return nv
    End Function


    Public Function Add(ByVal TheName As String, ByVal Value As Object) As NamedValue
        'create a new object
        Try
            Dim objNewMember As NamedValue
            objNewMember = New NamedValue

            objNewMember.TheName = UCase(TheName)
            If IsReference(Value) Then
                objNewMember.Value = Value
            Else
                objNewMember.Value = Value
            End If
            If Not mCol.Contains(UCase(TheName)) Then
                mCol.Add(objNewMember, UCase(TheName))
            End If

            sorted = False
            Return objNewMember
      
        Catch
            Return Nothing
        End Try
    End Function

    Default Public ReadOnly Property Item(ByVal vntIndexKey As Object) As NamedValue
        Get
            If IsNumeric(vntIndexKey) Then
                Return CType(mCol.Item(vntIndexKey), NamedValue)
            Else

                If mCol.Contains(UCase(vntIndexKey.ToString)) Then
                    Return CType(mCol.Item(UCase(vntIndexKey.ToString)), NamedValue)
                Else
                    Return Nothing
                End If
            End If
        End Get
    End Property

    'Parameters:
    ' параметров нет
    'Returns:
    '  значение типа Long
    'See Also:
    '  Add
    '  Item
    '  Remove
    'Example:
    ' dim variable as Long
    ' variable = me.Count
    Public ReadOnly Property Count() As Integer
        Get
            'used when retrieving the number of elements in the
            'ACollection. Syntax: Debug.Print x.Count
            Return mCol.Count()
        End Get
    End Property

    'Parameters:
    '[IN]   vntIndexKey , тип параметра: Variant  - ...
    'See Also:
    '  Add
    '  Count
    '  Item
    'Example:
    '  call me.Remove(<параметры>)
    Public Sub Remove(ByVal vntIndexKey As Object)
        'used when removing an element from the ACollection
        'vntIndexKey contains either the Index or Key, which is why
        'it is declared as a Variant
        'Syntax: x.Remove(xyz)

        If IsNumeric(vntIndexKey) Then
            mCol.Remove(CType(vntIndexKey, Integer))
        Else
            mCol.Remove(UCase(vntIndexKey.ToString))
        End If
        sorted = False
    End Sub




    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Private Sub Class_Initialize_Renamed()
        'creates the ACollection when this class is created
        mCol = New Collection
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub



    Private Sub Class_Terminate_Renamed()
        'destroys Collection when this class is terminated
        mCol = Nothing
        Erase sortIndex
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    Public Sub SortValues()
        sorted = False
        Dim i As Integer
        If mCol.Count() > 0 Then
            ReDim sortIndex(mCol.Count())
            ReDim sortValue(mCol.Count())
            For i = 1 To mCol.Count()
                sortValue(i) = CType(mCol.Item(i), NamedValue).Value
                sortIndex(i) = i
            Next
            qsort(1, mCol.Count())
            Erase sortValue
            sorted = True
        End If
    End Sub

    Public Function ItemByValueIndex(ByVal Index As Integer) As NamedValue
        Try

            If sorted Then
                Return Item(sortIndex(Index))
            End If

        Catch ex As System.Exception
        End Try
        Return Nothing
    End Function

    Private Sub qsort(ByRef l As Integer, ByRef r As Integer)
        Dim i, j As Integer
        Dim x, y As Object
        Dim vv As Integer
        Try
            i = l
            j = r
            x = sortValue((l + r) \ 2)
            Do
                While sortValue(i) < x
                    i = i + 1
                End While
                While x < sortValue(j)
                    j = j - 1
                End While
                If i <= j Then
                    y = sortValue(i)
                    sortValue(i) = sortValue(j)
                    sortValue(j) = y

                    vv = sortIndex(i)
                    sortIndex(i) = sortIndex(j)
                    sortIndex(j) = vv
                    i = i + 1
                    j = j - 1
                End If
            Loop Until i > j
            If l < j Then qsort(l, j)
            If i < r Then qsort(i, r)
        Catch ex As System.Exception
        End Try
    End Sub
End Class
