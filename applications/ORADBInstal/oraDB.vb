Imports Oracle.ManagedDataAccess.Client
Imports System.Windows.Forms


Public Class oraDB
    Private Inited As Boolean
    Private connection As OracleConnection

    Public Function dbconnect() As OracleConnection
        Return connection
    End Function

    Public Function Init(serviceName As String, sUserID As String, sPassword As String) As Boolean
        If Inited Then
            Return Inited
        End If




        Dim builder As New OracleConnectionStringBuilder()
        builder.DataSource = serviceName '  node.Attributes.GetNamedItem("DataSource").Value
        builder.UserID = sUserID
        builder.Password = sPassword
        connection = New OracleConnection()
        connection.ConnectionString = builder.ConnectionString


        Try
            '' SyncLock connection
            connection.Open()
            '' End SyncLock
            If connection.State <> ConnectionState.Open Then
                Console.WriteLine("Ошибка соединения")
                Return False
            End If
            Dim SessionGlob As OracleGlobalization = connection.GetSessionInfo()
            SessionGlob.Language = "RUSSIAN"

        Catch ex As Exception
            lastError = ex.Message
            MsgBox(ex.Message)
            Return False
        End Try

        QueryExec("ALTER SESSION FORCE PARALLEL DML")
        QueryExec("ALTER SESSION SET NLS_SORT=BINARY_CI")


        Inited = True
        Return Inited
    End Function

    Public lastError As String

    Public Function QueryExec(ByVal s As String) As Boolean
        Dim cmd As OracleCommand
        cmd = New OracleCommand
        Try

            cmd.CommandType = CommandType.Text
            cmd.CommandText = s
            cmd.Connection = dbconnect()
            Dim t As DateTime
            t = Now
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Debug.Print(s + " err:")
            Debug.Print(ex.Message)
            lastError = ex.Message
            Try
                cmd.Dispose()
            Catch ex1 As Exception

            End Try

            Return False
        End Try
        Try
            cmd.Dispose()
        Catch ex1 As Exception

        End Try
        Return True
    End Function

    Public Function QuerySelect(ByVal s As String) As DataTable
        Dim cmd As OracleCommand
        cmd = New OracleCommand
        cmd.CommandType = CommandType.Text
        cmd.CommandText = s
        cmd.Connection = dbconnect()
        Dim t As DateTime
        t = Now
        Dim dt As DataTable
        Dim da As OracleDataAdapter
        dt = New DataTable
        da = New OracleDataAdapter
        da.SelectCommand = cmd
        Try
            da.Fill(dt)
        Catch ex As Exception
            Debug.Print(s + " Err:" + ex.Message)
        End Try
        Try
            da.Dispose()
        Catch ex As Exception

        End Try
        Try
            cmd.Dispose()
        Catch ex As Exception

        End Try


        Return dt
    End Function
End Class
