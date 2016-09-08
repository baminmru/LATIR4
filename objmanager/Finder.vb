
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports LATIR2.Utils

    Public Class Finder
        'Утилиты для поиска
        'операции допустимые при поиске
        Public Enum FinderOP
            OpEQ 'равно
            OpNE 'не равно
            OpLE 'меньше или равно
            OpLT 'меньше
            OpGE 'больше или равно
            OpGT 'больше
            OpLIKE 'строка включает значение
            OpNULL 'поле содержит пустое значение
            OpNOT_NULL 'поле содержит не пустое значение
            OpLIKE_LEFT 'строка начинается с значения
            OpLIKE_RIGHT 'строка заканчивается значением
            OpSTR_EQ 'равно строковому значению
            OpSTR_NE 'не равно строковому значению
            OpSTR_LT 'меньше строкового значения
            OpSTR_LE 'меньше или равно строкового значения
            OpSTR_GE 'больше или равно строкового значения
            OpSTR_GT 'больше или равно строкового значения
            OpIN_NUMBERS 'значение входит в множество чисел
            OpIN_DATES 'значение входит в множество дат
            OpIN_STRINGS 'значение входит в множество строк
            OpIN_RESULT 'значения находятся в подмножестве QUERYRESULT
            OpLIKE_EXACT 'строка соответствует маске
            OpNOT_IN_NUMBERS 'значение не входит в множество чисел
            OpNOT_IN_DATES 'значение не входит в множество дат
            OpNOT_IN_STRINGS 'значение не входит в множество строк
            OpNOT_IN_RESULT 'значения не находятся в подмножестве QUERYRESULT
            OpLEFT_BRACKET 'левая скобка
            OpRIGHT_BRACKET 'правая скобка
        End Enum

        Private m_session As Session

        Friend Property Application() As Session
            Get
            Return m_session
            End Get
            Set(ByVal Value As Session)
                m_session = Value
            End Set
        End Property

        ' получить идентификаторы строк, которые удовлетворяют условию
        'Parameters:
        '[IN]   IDOut , тип параметра: String,
        '[IN]   Table , тип параметра: String,
        '[IN]   Field , тип параметра: String,
        '[IN]   OP , тип параметра: FinderOP,
        '[IN]   Value , тип параметра: Variant  - ...
        'Returns:
        '  значение типа Long
        'See Also:
        '  DropResults
        '  FullTextSearch
        '  GetResults
        '  QR_AND_QR
        '  QR_OR_QR
        '  RowsToInstances
        '  RowsToParents
        '  USDate
        'Example:
        ' dim variable as Long
        ' variable = me.FIND_IDS(<параметры>)
    Public Function FIND_IDS(ByVal IDOut As String, ByVal Table As String, ByVal Field As String, ByVal OP As FinderOP, ByVal Value As Object) As Integer
        Dim cond As String
        Dim cnt As Integer
        IDOut = ID2String(IDOut)
        cond = PackCondition(OP, Value, Field)
        Try
            Dim rs As DataTable
            If cond <> "" Then
                cond = "insert into QUERYRESULT (QUERYRESULTID,RESULT) select distinct '" & IDOut & "'," & Table & "id from " & Table & " where " & cond
                If Application.TheDataSource.Execute(cond) = 1 Then
                    rs = Application.TheDataSource.ExecuteReader("select count(*) cnt from QUERYRESULT where QUERYRESULTID='" & IDOut & "'")
                    cnt = CInt(rs.Rows.Item(0)("cnt"))
                End If
            End If
            Return cnt

        Catch ex As System.Exception
        End Try
    End Function


    ' преобразование условия в строку запроса
    Friend Function PackCondition(ByVal OP As FinderOP, ByVal Value As Object, ByVal FieldName As String) As String
        Dim cond As String
        'Dim I As Integer
        cond = ""
        Select Case OP
            Case FinderOP.OpEQ
                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( " & FieldName & " = " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then
                    cond = cond & "( " & FieldName & " = " & Value.ToString.Replace(",", ".") & ")"
                Else
                    cond = cond & "( " & FieldName & " = " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpNE
                If IsDBNull(Value) Then
                    cond = cond & "( not " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( not " & FieldName & " = " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then
                    cond = cond & "( not " & FieldName & " = " & Value.ToString.Replace(",", ".") & ")"
                Else
                    cond = cond & "( not " & FieldName & " = " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpLT

                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( " & FieldName & " < " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then
                    cond = cond & "( " & FieldName & " < " & Value.ToString.Replace(",", ".") & ")"
                Else
                    cond = cond & "( " & FieldName & " < " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpLE
                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( " & FieldName & " <= " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then

                    cond = cond & "( " & FieldName & " <= " & Value.ToString.Replace(",", ".") & ")"
                Else

                    cond = cond & "( " & FieldName & " <= " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpGT
                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( " & FieldName & " > " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then

                    cond = cond & "( " & FieldName & " > " & Value.ToString.Replace(",", ".") & ")"
                Else

                    cond = cond & "( " & FieldName & " > " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpGE

                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                ElseIf IsDate(Value) Then
                    cond = cond & "( " & FieldName & " >= " & USDate(Value) & ")"
                ElseIf IsNumeric(Value) Then
                    cond = cond & "( " & FieldName & " >= " & Value.ToString.Replace(",", ".") & ")"
                Else
                    cond = cond & "( " & FieldName & " >= " & StrOrNull(Value.ToString) & ")"
                End If

            Case FinderOP.OpLIKE
                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    cond = cond & "( " & FieldName & " like '%" & Value.ToString & "%')"
                End If

            Case FinderOP.OpLIKE_EXACT

                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                Else

                    cond = cond & "( " & FieldName & " like '" & Value.ToString & "')"
                End If

            Case FinderOP.OpNULL
                cond = cond & "( " & FieldName & " is null )"
            Case FinderOP.OpNOT_NULL
                cond = cond & "( not " & FieldName & " is null )"
            Case FinderOP.OpLIKE_LEFT

                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                Else
                    cond = cond & "( " & FieldName & " like '" & Value.ToString & "%')"
                End If
            Case FinderOP.OpLIKE_RIGHT
                'UPGRADE_WARNING: Use of Null/" +Manager.Sessiom.GEtProvider().IsNUll(") detected. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1049"'
                If IsDBNull(Value) Then
                    cond = cond & "( " & FieldName & " is  null)"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                    cond = cond & "( " & FieldName & " like '%" & Value.ToString & "')"
                End If
            Case FinderOP.OpSTR_EQ
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " = " & StrOrNull(Value.ToString) & ")"
            Case FinderOP.OpSTR_NE
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( not " & FieldName & " = " & StrOrNull(Value.ToString) & ")"
            Case FinderOP.OpSTR_LT
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " < " & StrOrNull(Value.ToString) & ")"
            Case FinderOP.OpSTR_LE
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " <= " & StrOrNull(Value.ToString) & ")"
            Case FinderOP.OpSTR_GE
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " >= " & StrOrNull(Value.ToString) & ")"
            Case FinderOP.OpSTR_GT
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " > " & StrOrNull(Value.ToString) & ")"
                'Case FinderOP.OpIN_NUMBERS
                '    If IsArray(Value) Then

                '        I = LBound(CType(Value, System.Array))
                '        Try

                '            cond = cond & "( " & FieldName & " in ("
                '            For I = LBound(CType(Value, System.Array)) To UBound(CType(Value, System.Array))
                '                If I > LBound(CType(Value, System.Array)) Then
                '                    cond = cond & " , "
                '                End If

                '                cond = cond & Value(I)
                '            Next
                '            cond = cond & " ) )"
                '        Catch
                '        End Try
                '    Else
                '        'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '        cond = cond & "( " & FieldName & " = " & Value.ToString & ")"
                '    End If



                'Case FinderOP.OpIN_DATES
                '    If IsArray(Value) Then

                '        I = LBound(Value)
                '        Try
                '            cond = cond & "( " & FieldName & " in ("

                '            For I = LBound(Value) To UBound(Value)
                '                If I > LBound(Value) Then
                '                    cond = cond & " , "
                '                End If
                '                cond = cond & USDate(Value(I))
                '            Next
                '            cond = cond & " ) )"
                '        Catch
                '        End Try
                '    Else
                '        cond = cond & "( " & FieldName & " = " & USDate(Value) & ")"
                '    End If


                'Case FinderOP.OpIN_STRINGS
                '    If IsArray(Value) Then

                '        I = LBound(Value)

                '        cond = cond & "( " & FieldName & " in ("
                '        Try
                '            For I = LBound(Value) To UBound(Value)
                '                If I > LBound(Value) Then
                '                    cond = cond & " , "
                '                End If
                '                'UPGRADE_WARNING: Couldn't resolve default property of object Value(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '                cond = cond & StrOrNull(Value(I))
                '            Next
                '            cond = cond & " ) )"
                '        Catch
                '        End Try

                '    Else
                '        'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '        cond = cond & "( " & FieldName & " = " & StrOrNull(Value) & ")"
                '    End If


            Case FinderOP.OpLEFT_BRACKET
                cond = cond & " ( "

            Case FinderOP.OpRIGHT_BRACKET
                cond = cond & " ) "


            Case FinderOP.OpIN_RESULT
                'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                cond = cond & "( " & FieldName & " in ( select RESULT from QUERYRESULT where QUERYRESULTID=" & StrOrNull(Value.ToString) & "))"

                'Case FinderOP.OpNOT_IN_DATES
                '    If IsArray(Value) Then

                '        I = LBound(Value)
                '        Try
                '            cond = cond & "( " & FieldName & " not in ("

                '            For I = LBound(Value) To UBound(Value)
                '                If I > LBound(Value) Then
                '                    cond = cond & " , "
                '                End If
                '                'UPGRADE_WARNING: Couldn't resolve default property of object Value(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '                cond = cond & Application.GetProvider().Date2Const(Value(I))
                '            Next
                '            cond = cond & " ) )"
                '        Catch
                '        End Try
                '    Else
                '        'UPGRADE_WARNING: Couldn't resolve default property of object Value. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '        cond = cond & "( " & FieldName & " <> " & Application.GetProvider().Date2Const(Value) & ")"
                '    End If

                'Case FinderOP.OpNOT_IN_STRINGS
                '    If IsArray(Value) Then

                '        I = LBound(Value)

                '        cond = cond & "( " & FieldName & " not in ("
                '        Try
                '            For I = LBound(Value) To UBound(Value)
                '                If I > LBound(Value) Then
                '                    cond = cond & " , "
                '                End If
                '                'UPGRADE_WARNING: Couldn't resolve default property of object Value(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
                '                cond = cond & StrOrNull(Value(I))
                '            Next
                '            cond = cond & " ) )"
                '        Catch
                '        End Try
                '    Else
                '        cond = cond & "( " & FieldName & " <> " & StrOrNull(Value) & ")"
                '    End If

                'Case FinderOP.OpNOT_IN_NUMBERS
                '    If IsArray(Value) Then

                '        I = LBound(Value)
                '        Try

                '        cond = cond & "( " & FieldName & " not in ("
                '        For I = LBound(Value) To UBound(Value)
                '            If I > LBound(Value) Then
                '                cond = cond & " , "
                '            End If

                '            cond = cond & Value(I)
                '        Next
                '        cond = cond & " ) )"
                '        Catch
                '        End Try
                '    Else
                '        cond = cond & "( " & FieldName & " <> " & Value & ")"
                '    End If

            Case FinderOP.OpNOT_IN_RESULT
                cond = cond & "( " & FieldName & " not in ( select RESULT from QUERYRESULT where QUERYRESULTID='" & Value.ToString & "')"
        End Select
nxt:
        Return cond
    End Function


    Private Function StrOrNull(ByVal Value As String) As String
        If Value = "" Then
            Return " null"
        Else
            Return "'" & Replace(Value, "'", "''") & "'"
        End If
    End Function


    Public Function USDate(ByVal vArg As Object) As String

        Dim dtTemp As Date

        If IsDate(vArg) Then

            dtTemp = CDate(vArg)
            Return "'" & Right("0" & dtTemp.Month.ToString(), 2) & "/" & Right("0" & dtTemp.Day.ToString(), 2) & "/" & Right("000" & dtTemp.Year.ToString(), 4) & " " & Right("000" & dtTemp.Hour.ToString(), 2) & ":" & Right("000" & dtTemp.Minute.ToString(), 2) & ":" & Right("0" & dtTemp.Second, 2) & "'"
        Else
            dtTemp = Now
            Return "'" & Right("0" & dtTemp.Month.ToString(), 2) & "/" & Right("0" & dtTemp.Day.ToString(), 2) & "/" & Right("000" & dtTemp.Year.ToString(), 4) & " " & Right("000" & dtTemp.Hour.ToString(), 2) & ":" & Right("000" & dtTemp.Minute.ToString(), 2) & ":" & Right("0" & dtTemp.Second, 2) & "'"
        End If
    End Function

    Public Sub DropResults(ByVal queryid As String)
        Application.TheDataSource.Execute("delete from QUERYRESULT where QUERYRESULTID='" & ID2String(queryid) & "'")
    End Sub

    Public Function GetResultsDT(ByVal queryid As String) As DataTable
        Try
            Dim rs As DataTable
            rs = Application.TheDataSource.ExecuteReader("select RESULT from QUERYRESULT where QUERYRESULTID='" & queryid & "'")
            Return rs

        Catch ex As System.Exception
            Return Nothing
        End Try
    End Function

    Public Function QR_AND_QR(ByVal QueryID1 As String, ByVal QueryID2 As String, ByVal QueryIDOut As String) As Integer

        Try

            Dim p As LATIR2.NamedValues
            Dim cnt As Integer
            p = New LATIR2.NamedValues
            p.Add("ID1", QueryID1)
            p.Add("ID2", QueryID2)
            p.Add("IDOUT", QueryIDOut)
            p.Add("CNT", cnt, DbType.Int16, ParameterDirection.Output)

            Application.TheDataSource.ExecuteProc("QR_and_QR", p, False)


            Return CInt(p.Item("CNT").Value)


        Catch

            Return 0
        End Try
    End Function

    'объединение запросов
    'Parameters:
    '[IN]   QueryID1 , тип параметра: String идентификатор первого результата,
    '[IN]   QueryID2 , тип параметра: String идентификатор второго результата,
    '[IN]   QueryIDOut , тип параметра: String  - идентификатор объединения
    'Returns:
    '  значение типа Long
    'See Also:
    '  DropResults
    '  FIND_IDS
    '  FullTextSearch
    '  GetResults
    '  QR_AND_QR
    '  RowsToInstances
    '  RowsToParents
    '  USDate
    'Example:
    ' dim variable as Long
    ' variable = me.QR_OR_QR(<параметры>)
    Public Function QR_OR_QR(ByVal QueryID1 As String, ByVal QueryID2 As String, ByVal QueryIDOut As String) As Integer
        Try

            Dim p As LATIR2.NamedValues
            Dim cnt As Integer
            p = New LATIR2.NamedValues
            p.Add("ID1", QueryID1)
            p.Add("ID2", QueryID2)
            p.Add("IDOUT", QueryIDOut)
            p.Add("CNT", cnt, DbType.Int16, ParameterDirection.Output)

            Application.TheDataSource.ExecuteProc("QR_or_QR", p, False)


            Return CInt(p.Item("CNT").Value)
        Catch

            Return 0
        End Try
    End Function


    Public Sub RowsToInstances(ByVal TableName As String, ByVal RowQueryID As Guid, ByVal QueryIDOut As Guid)
        Dim p As LATIR2.NamedValues
        p = New LATIR2.NamedValues
        p.Add("RowQueryID", Application.GetProvider.ID2Param(RowQueryID), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)
        p.Add("OutputQueryID", Application.GetProvider.ID2Param(QueryIDOut), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)
        p.Add("the_TABLE", TableName)
        p.Add("CURSESSION", Application.GetProvider.ID2Param(Application.SessionID), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)
        Application.TheDataSource.ExecuteProc("RowsToInstances", p)
    End Sub


    Public Sub RowsToParents(ByVal TableName As String, ByVal RowQueryID As String, ByVal QueryIDOut As String)
        Dim s As String
        s = "insert into QUERYRESULT(QUERYRESULTID,RESULT) select distinct " & StrOrNull(QueryIDOut) & ",PARENTSTRUCTROWID from " & TableName & " where " & TableName & "id in (select result from QUERYRESULT where QUERYRESULTID=" & StrOrNull(RowQueryID) & ")"
        Application.TheDataSource.Execute(s)

    End Sub

    'список объектов по результатам полнотекстового запроса
    'Parameters:
    '[IN]   Filter , тип параметра: String  - запрос,
    '[IN]   TypeName , тип параметра: String - имя типа,
    '[IN][OUT]   ResultID , тип параметра: String  - идентификатор результата
    'Returns:
    ' Boolean, семантика результата:
    '   true  -
    '   false -
    'See Also:
    '  DropResults
    '  FIND_IDS
    '  GetResults
    '  QR_AND_QR
    '  QR_OR_QR
    '  RowsToInstances
    '  RowsToParents
    '  USDate
    'Example:
    ' dim variable as Boolean
    ' variable = me.FullTextSearch(<параметры>)
    Public Function FullTextSearch(ByVal Filter_Renamed As String, ByVal TypeName_Renamed As String, ByRef ResultID As Guid) As Boolean
        Dim nv As LATIR2.NamedValues
        nv = New LATIR2.NamedValues
        nv.Add("QueryResultID", Application.GetProvider.ID2Param(ResultID), Application.GetProvider.ID2DbType(), Application.GetProvider.ID2Size())
        nv.Add("Filter", Filter_Renamed, DbType.String)
        'FullTextSearch = Application.TheDataSource.ExecuteProc(TypeName_Renamed & "_search", nv)
        Return Application.TheDataSource.ExecuteProc(Replace(Application.ProcPrefix, "%Type%", TypeName_Renamed, , , vbTextCompare) & TypeName_Renamed & "_search", nv)
    End Function


    Public Function RowParents(ByVal TableName As String, ByVal RowID As Guid) As RowParentList
        Dim rs As DataTable
        Dim queryid As Guid
        Dim rpl As RowParentList
        rpl = New RowParentList
        queryid = System.Guid.NewGuid()
        Dim p As LATIR2.NamedValues
        p = New LATIR2.NamedValues
        p.Add("QueryID", Application.GetProvider.ID2Param(queryid), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)
        p.Add("RowID", Application.GetProvider.ID2Param(RowID), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)

        p.Add("TABLE", TableName)
        p.Add("CURSESSION", Application.GetProvider.ID2Param(Application.SessionID), Application.GetProvider.ID2DbType, Application.GetProvider.ID2Size)
        Try
            Application.TheDataSource.ExecuteProc(Application.KernelPrefix & "RowParents", p)

            Try
                rs = Application.TheDataSource.ExecuteReader("select PARTNAME," + Application.GetProvider.ID2Base("ROWID", "THEROWID") + ",PARENTLEVEL from RPRESULT where RPRESULTID=" + Application.GetProvider.ID2Const(queryid) + " order by parentlevel desc")

               
            Catch ex As Exception
                rs = Application.TheDataSource.ExecuteReader("select PARTNAME," + Application.GetProvider.ID2Base("THEROWID") + ",PARENTLEVEL from RPRESULT where RPRESULTID=" + Application.GetProvider.ID2Const(queryid) + " order by parentlevel desc")

            End Try
           


            If rs Is Nothing Then Return rpl
            Dim i As Integer
            For i = 0 To rs.Rows.Count - 1

                If (Not rs.Rows(i)("theRowID").Equals(System.DBNull.Value)) Then
                    rpl.Add(New Guid(rs.Rows(i)("theRowID").ToString), CStr(rs.Rows(i)("PartName")))
                End If

            Next

            rs = Nothing

            Application.TheDataSource.Execute("delete from RPRESULT where RPRESULTID=" + Application.GetProvider.ID2Const(queryid))
        Catch ex As system.Exception

        End Try
        Return rpl
    End Function




End Class
