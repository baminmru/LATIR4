Option Strict Off
Option Explicit On
Imports System
Imports System.Data
Imports System.Data.Common
Friend Class DataSource
	'{group:Data Access Service}
    Private mADOConnection As SqlClient.SqlConnection
	Private InTransaction As Boolean
	Private mPrevConnectionString As String
	Private mPrevProvider As String
	Private mPrevTimeOut As Integer
	
	Public Server As String
	Public DataBaseName As String
	Public UserName As String
	Public Password As String
	Public Integrated As Boolean
	
	
	
	' открыть таблицу
	'Parameters:
    'TableName - имя таблицы 

    '    Private Function OpenTable(ByVal TableName As String) As DataTable
    '        Dim RecordSet As DataTable

    '        If mADOConnection Is Nothing Then Exit Function
    '        'If mADOConnection.State <> ConnectionState.Open Then CheckState()
    '        If mADOConnection.State <> ConnectionState.Open Then Exit Function



    '        On Error GoTo errOpenTable
    '        RecordSet = New DataTable
    '        RecordSet.CursorType = ADODB.CursorTypeEnum.adOpenDynamic
    '        RecordSet.LockType = ADODB.LockTypeEnum.adLockReadOnly
    '        Call RecordSet.Open(TableName, mADOConnection, , , ADODB.CommandTypeEnum.adCmdTable)
    '        OpenTable = RecordSet
    '        '  mLastCheck = Now
    '        Exit Function
    'errOpenTable:
    '        Dim ADOErrors As String
    '        Dim e As ADODB.Error
    '        ADOErrors = ""
    '        For Each e In mADOConnection.Errors
    '            ADOErrors = ADOErrors & "[" & e.NativeError & "]" & e.Description & vbCrLf
    '        Next e

    '        Resume bye2
    'bye2:

    '        CheckState()
    '    End Function
	
	
	
	'
	'##ModelId=3B8F80100215
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Terminate_Renamed()
		On Error Resume Next
		CloseClass()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		On Error Resume Next
		'UPGRADE_NOTE: Object mADOConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mADOConnection = Nothing
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	' "Деструктор"
	Friend Sub CloseClass()
		On Error Resume Next
		'UPGRADE_NOTE: Object mADOConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		mADOConnection = Nothing
	End Sub
	
    '' инициализировать объект соединением ADODB.Connection
    'Public Sub SetConnection()
    '	If Not mADOConnection Is Nothing Then
    '		mPrevConnectionString = mADOConnection.ConnectionString
    '           mPrevProvider = mADOConnection.Provider
    '		mPrevTimeOut = mADOConnection.ConnectionTimeout
    '	End If
    '	'    mLastCheck = Now
    'End Sub
	
	
	' открыть RecordSet
	'Parameters:
	'SqlString - запрос
	'ReadOnly - открыть только для чтения
    '    Public Function OpenRecordset(ByVal SqlString As String) As ADODB.Recordset
    '        On Error Resume Next
    '        Dim ADORecordSet As ADODB.Recordset
    '        If mADOConnection Is Nothing Then Exit Function
    '        If mADOConnection.State <> ADODB.ObjectStateEnum.adStateOpen Then CheckState()
    '        If mADOConnection.State <> ADODB.ObjectStateEnum.adStateOpen Then Exit Function

    '        ADORecordSet = New ADODB.Recordset
    '        ADORecordSet.CursorType = ADODB.CursorTypeEnum.adOpenStatic 'adOpenForwardOnly
    '        ADORecordSet.LockType = ADODB.LockTypeEnum.adLockReadOnly
    '        ADORecordSet.CursorLocation = ADODB.CursorLocationEnum.adUseClient
    '        ADORecordSet.CacheSize = 100
    '        ADORecordSet.PageSize = 100
    '        On Error GoTo bye
    '        Debug.Print(SqlString)
    '        Call ADORecordSet.Open(SqlString, mADOConnection)
    '        On Error Resume Next
    '        'UPGRADE_NOTE: Object ADORecordSet.ActiveConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        ADORecordSet.ActiveConnection = Nothing
    '        OpenRecordset = ADORecordSet
    '        'UPGRADE_NOTE: Object ADORecordSet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        ADORecordSet = Nothing
    '        Exit Function

    'bye:
    '        Dim ADOErrors As String
    '        Dim e As ADODB.Error
    '        ADOErrors = ""
    '        For Each e In mADOConnection.Errors
    '            ADOErrors = ADOErrors & "[" & e.NativeError & "]" & e.Description & vbCrLf
    '        Next e

    '        'UPGRADE_NOTE: Object OpenRecordset may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        OpenRecordset = Nothing
    '        'UPGRADE_NOTE: Object ADORecordSet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        ADORecordSet = Nothing

    '        Resume bye2
    'bye2:
    '        CheckState()
    '        On Error GoTo 0
    '        Err.Raise(10000, "MTZSession.OpenRecordset", ADOErrors & vbCrLf & "[" & SqlString & "]")
    '    End Function

    ' выполнить SQL запрос
    'Parameters:
    'SqlString - запрос
    'Returns:
    'true- запрос успешно выполнен
    Public Function Execute(ByVal SqlString As String) As Boolean
        If mADOConnection Is Nothing Then Exit Function
        'If mADOConnection.State <> ConnectionState.Open Then CheckState()
        If mADOConnection.State <> ConnectionState.Open Then Exit Function

        On Error GoTo bye
        Debug.Print(SqlString)
        Dim dbcom As DbCommand
        dbcom = mADOConnection.CreateCommand()
        dbcom.CommandText = SqlString
        dbcom.ExecuteNonQuery()
        'mADOConnection. Execute(SqlString,  , ADODB.CommandTypeEnum.adCmdText)

        Execute = True
        Exit Function
bye:
        Dim ADOErrors As String
        ADOErrors = Err.Description

        'Dim e As DbComman  Errortostring
        'ADOErrors = "ыыыыыыыыы"
        'For	Each e In mADOConnection.Errors
        'ADOErrors = ADOErrors & "[" & e.NativeError & "]" & e.Description & vbCrLf
        'Next e
        'ADOErrors =  mADOConnection.

        Execute = False
        Resume bye2
bye2:

        'CheckState()
        On Error GoTo 0
        Err.Raise(10000, "MTZSession.Execute", ADOErrors & vbCrLf & "[" & SqlString & "]")
    End Function



    '	' начать транзакцию
    '	' See Also:
    '	'InTransaction
    '	Public Function BeginTrans() As Integer

    '		On Error GoTo bye
    '		BeginTrans = 0
    '		If mADOConnection Is Nothing Then Exit Function
    '        If mADOConnection.State <> ConnectionState.Open Then CheckState()
    '        If mADOConnection.State <> ConnectionState.Open Then Exit Function

    '        mADOConnection.BeginTransaction()

    '		If BeginTrans > 0 Then
    '			InTransaction = True
    '		Else
    '			InTransaction = False
    '		End If
    '		Exit Function
    'bye: 
    '		Resume bye2
    'bye2: 
    '		CheckState()
    '	End Function

    '	' завершить транзакцию
    '	' See Also:
    '	'InTransaction
    '	Public Sub CommitTrans()
    '		If mADOConnection Is Nothing Then Exit Sub
    '        If mADOConnection.State <> ConnectionState.Open Then CheckState()
    '        If mADOConnection.State <> ConnectionState.Open Then Exit Sub


    '		On Error GoTo bye

    '        '      If Not mADOConnection Is Nothing Then mADOConnection.CommitTrans()
    '        'InTransaction = False
    '        'Exit Sub
    'bye: 
    '		Resume bye2
    'bye2: 
    '        'CheckState()
    '	End Sub

    '	' отменить транзакцию
    '	Public Sub RollbackTrans()
    '		If mADOConnection Is Nothing Then Exit Sub
    '        If mADOConnection.State <> ConnectionState.Open Then CheckState()
    '        If mADOConnection.State <> ConnectionState.Open Then Exit Sub

    '		On Error GoTo bye

    '        'If Not mADOConnection Is Nothing Then mADOConnection.RollbackTrans()
    '        'InTransaction = False
    '        'Exit Sub
    'bye: 
    '		Resume bye2
    'bye2: 
    '        'CheckState()

    '	End Sub

    ' есть ли активные транзакции
    Public Function IsInTransaction() As Boolean
        IsInTransaction = InTransaction
    End Function

    '	' проверить состояние соединения с БД
    '	Public Sub CheckState()
    '		Static attempts As Short

    '        Dim dbcom As DbCommand
    '        dbcom = mADOConnection.CreateCommand
    '        Dim dt As DataTable

    '        'attempts = 0
    '        ''Dim ADORecordSet As ADODB.Recordset
    '        ''ADORecordSet = New ADODB.Recordset
    '		On Error GoTo errCheck

    '        'ADORecordSet.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
    '        'ADORecordSet.LockType = ADODB.LockTypeEnum.adLockReadOnly
    '        'Call ADORecordSet.Open("SELECT 'OK' SRV_TEST", mADOConnection)
    '        'If ADORecordSet.Fields("SRV_TEST").Value = "OK" Then
    '        'mPrevConnectionString = mADOConnection.ConnectionString
    '        'mPrevProvider = mADOConnection.Provider
    '        'mPrevTimeOut = mADOConnection.ConnectionTimeout
    '        'attempts = 0
    '        'Exit Sub
    '        'End If
    '        'errCheck:
    '        '       If attempts > 10 Then
    '        'Exit Sub
    '        'End If
    '        'attempts = attempts + 1
    '        'Resume ErrClear
    'ErrClear:
    '        If mPrevConnectionString <> "" Then
    '            If mADOConnection.State <> ADODB.ObjectStateEnum.adStateClosed Then
    '                mADOConnection.Close()
    '            End If
    '            'UPGRADE_NOTE: Object mADOConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '            mADOConnection = Nothing
    '            mADOConnection = New ADODB.Connection
    '            mADOConnection.Provider = mPrevProvider
    '            mADOConnection.ConnectionTimeout = mPrevTimeOut
    '            mADOConnection.CommandTimeout = mPrevTimeOut
    '            Call mADOConnection.Open(mPrevConnectionString)

    '        End If
    '	End Sub


    '    Public Function CheckConnection() As Boolean
    '        Dim ADORecordSet As ADODB.Recordset
    '        ADORecordSet = New ADODB.Recordset
    '        If mADOConnection Is Nothing Then
    '            CheckConnection = False
    '            Exit Function
    '        End If
    '        If mADOConnection.State = ADODB.ObjectStateEnum.adStateClosed Then
    '            CheckConnection = False
    '            Exit Function
    '        End If
    '        On Error GoTo errCheck
    '        ADORecordSet.CursorType = ADODB.CursorTypeEnum.adOpenForwardOnly
    '        ADORecordSet.LockType = ADODB.LockTypeEnum.adLockReadOnly
    '        Call ADORecordSet.Open("SELECT 'OK' SRV_TEST", mADOConnection)
    '        If ADORecordSet.Fields("SRV_TEST").Value = "OK" Then
    '            CheckConnection = True
    '            ADORecordSet.Close()
    '            'UPGRADE_NOTE: Object ADORecordSet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '            ADORecordSet = Nothing
    '            Exit Function
    '        End If
    'errCheck:
    '        Resume ErrClear
    'ErrClear:
    '        On Error Resume Next
    '        ADORecordSet.Close()
    '        'UPGRADE_NOTE: Object ADORecordSet may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
    '        ADORecordSet = Nothing
    '        CheckConnection = False
    '    End Function



    'Public Property IsolationLevel() As Integer
    '    Get
    '        If mADOConnection Is Nothing Then
    '            IsolationLevel = ADODB.IsolationLevelEnum.adXactUnspecified
    '        Else
    '            IsolationLevel = mADOConnection.IsolationLevel
    '        End If
    '    End Get
    '    Set(ByVal Value As Integer)
    '        If Not mADOConnection Is Nothing Then
    '            mADOConnection.IsolationLevel = Value
    '        End If
    '    End Set
    'End Property

    Public Function ServerLogIn() As Boolean
        'If mADOConnection Is Nothing Then
        'On Error Resume Next
        ADOLogin(Server, DataBaseName, UserName, Password, 100, Integrated)
        'If ADOLogin(Server, DataBaseName, UserName, Password, 100, Integrated) Then
        'SetConnection()
        'End If
        'End If
        ServerLogIn = Not (mADOConnection Is Nothing)
    End Function


    Private Function ADOLogin(ByVal Server As String, ByVal DataBaseName As String, ByVal UserName As String, ByVal Password As String, ByVal aLoginTimeOut As Short, ByVal Integrated As Boolean) As Boolean
        Dim mConnectString As String
        On Error GoTo bye
        ADOLogin = False

        mADOConnection = New SqlClient.SqlConnection
        If Integrated Then
           mADOConnection.ConnectionString = "Integrated Security=SSPI;Database=" + DataBaseName + ";Server=" + Server + ";"

        Else
            mADOConnection.ConnectionString = "Database=" + DataBaseName + ";Server=" + Server + ";User ID=" + UserName + ";Pwd=" + Password + ";"

        End If

        
        Call mADOConnection.Open()
        ADOLogin = (mADOConnection.State = ConnectionState.Open) 'ObjectStateEnum.adStateOpen)
        Exit Function
bye:
        My.Application.Log.WriteEntry(Err.Description, System.Diagnostics.TraceEventType.Error)
        Err.Raise(Err.Number, Err.Source, Err.Description)
    End Function

    'phisical ADO connection close
    '##ModelId=3B8F800E019A
    Private Sub ADOLogOff()
        On Error Resume Next
        mADOConnection.Close()
        'UPGRADE_NOTE: Object mADOConnection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        mADOConnection = Nothing
    End Sub
End Class