Option Strict Off
Option Explicit On
Imports System
Imports System.Data
Imports System.Data.Common
Imports MySql.Data


Friend Class DataSource
    '{group:Data Access Service}
    Private mMySQLConnection As MySqlClient.MySqlConnection
    Private InTransaction As Boolean
    Private mPrevConnectionString As String
    Private mPrevProvider As String
    Private mPrevTimeOut As Integer

    Public Server As String
    Public DataBaseName As String
    Public UserName As String
    Public Password As String
    Public Integrated As Boolean
    Private lMsg As String

    Public Function LastMessage() As String

    End Function

    Private Sub Class_Terminate_Renamed()
        On Error Resume Next
        CloseClass()
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
        MyBase.Finalize()
    End Sub

    '
    Private Sub Class_Initialize_Renamed()
        On Error Resume Next

        mMySQLConnection = Nothing
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    ' "Деструктор"
    Friend Sub CloseClass()
        On Error Resume Next

        mMySQLConnection = Nothing
    End Sub

   
    Public Function Execute(ByVal SqlString As String) As Boolean
        If mMySQLConnection Is Nothing Then ServerLogIn()
        If mMySQLConnection.State <> ConnectionState.Open Then ServerLogIn()
        If mMySQLConnection.State <> ConnectionState.Open Then Return False

        lMsg = ""
        Debug.Print(SqlString)
        Dim dbcom As DbCommand
        dbcom = mMySQLConnection.CreateCommand()
        dbcom.CommandTimeout = 100
        dbcom.CommandText = SqlString

        Try
            dbcom.ExecuteNonQuery()
        Catch ex As Exception
            Err.Raise(10000, "MTZSession.Execute", ex.Message & vbCrLf & "[" & SqlString & "]")
            Return False
        End Try

        
        Return True
        
    End Function



    ' есть ли активные транзакции
    Public Function IsInTransaction() As Boolean
        IsInTransaction = InTransaction
    End Function

    Public Function ServerLogIn() As Boolean
  
        If MySQLLogin(Server, DataBaseName, UserName, Password, 100, Integrated) Then
            lMsg = "log in ok"
        Else
            lMsg = "log in error"
        End If

        Return Not (mMySQLConnection Is Nothing)
    End Function


    Private Function MySQLLogin(ByVal Server As String, ByVal DataBaseName As String, ByVal UserName As String, ByVal Password As String, ByVal aLoginTimeOut As Short, ByVal Integrated As Boolean) As Boolean
        Dim mConnectString As String
        On Error GoTo bye
        MySQLLogin = False

     

        mMySQLConnection = New MySqlClient.MySqlConnection


        Dim connStr As String
        connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; charset=utf8;", _
        Server, UserName, Password, DataBaseName)

        mMySQLConnection.ConnectionString = connStr


        Call mMySQLConnection.Open()
        MySQLLogin = (mMySQLConnection.State = ConnectionState.Open) 'ObjectStateEnum.adStateOpen)


        Exit Function
bye:
        My.Application.Log.WriteEntry(Err.Description, System.Diagnostics.TraceEventType.Error)
        Err.Raise(Err.Number, Err.Source, Err.Description)
    End Function

    'phisical MySQL connection close
    Private Sub MySQLLogOff()
        On Error Resume Next
        mMySQLConnection.Close()

        mMySQLConnection = Nothing
        lMsg = "Connection closed"

    End Sub
End Class