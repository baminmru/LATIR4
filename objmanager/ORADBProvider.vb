Imports System
Imports System.Data
Imports System.Data.Common
Imports Oracle.ManagedDataAccess.Client
Imports LATIR2.Utils
Imports System.IO



Public Class ORADBProvider
    Inherits LATIR2.DBProvider

    Public Sub New()
        ProviderType = DBProviderType.ORACLE
    End Sub

    Public Overrides Function BuildCN( _
           ByVal Server As String, _
           ByVal DataBaseName As String, _
           ByVal UserName As String, _
           ByVal Password As String, _
           ByVal LoginTimeOut As String, _
           ByVal Provider As String, _
           ByVal Integrated As Boolean) As String

        Dim builder As New OracleConnectionStringBuilder()
        builder.DataSource = Server
        builder.UserID = UserName
        builder.Password = Password

        Return builder.ConnectionString

    End Function

    Public Overrides Function CreateConnection(ByVal ConnectionString As String) As DbConnection
        Dim cn As DbConnection
        cn = New OracleConnection
        cn.ConnectionString = ConnectionString
        Return cn
    End Function

    Public Overrides Sub ConnectSetup(CN As DbConnection)
        Dim cmd As OracleCommand
        cmd = New OracleCommand
        'cmd.Connection = CType(CN, OracleConnection)
        'cmd.CommandText = "ALTER SESSION FORCE PARALLEL DML"
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()

        cmd = New OracleCommand
        cmd.Connection = CType(CN, OracleConnection)
        cmd.CommandText = "ALTER SESSION SET NLS_COMP=LINGUISTIC"
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New OracleCommand
        cmd.Connection = CType(CN, OracleConnection)
        cmd.CommandText = "ALTER SESSION SET NLS_SORT=BINARY_CI"
        cmd.ExecuteNonQuery()
        cmd.Dispose()



    End Sub

    Public Overrides Function CreateCommand() As DbCommand
        Return New OracleCommand
    End Function

    Public Overrides Function CreateDataAdapter() As DbDataAdapter
        Return New OracleDataAdapter
    End Function

    Public Overrides Function GetTestQuery() As String
        Return "SELECT 'OK' SRV_TEST from dummy"
    End Function
    Public Overrides Function GetServerDate() As String
        Return "SELECT sysdate SRV_DATE from dummy"
    End Function

    Public Overrides Function DateFunc() As String
        Return "sysdate"
    End Function

    Public Overrides Function Date2Const(ByVal d As Date) As String
        Return MakeORACLEDate(d)
    End Function


    Public Overrides Function ID2Base(ByVal fieldName As String) As String
        Return fieldName
    End Function


    Public Overrides Function ID2Const(ByVal ID As Guid) As String
        Return "'" + GUID2String(ID) + "'"
    End Function

    Public Overrides Function ID2DbType() As DbType
        Return DbType.String
    End Function

    Public Overrides Function ID2Size() As Integer
        Return 38
    End Function



    Public Overrides Function ID2Param(ByVal ID As Guid) As Object
        Return GUID2String(ID)
    End Function

    Public Overrides Function Date2Base(ByVal fieldName As String) As String
        Return fieldName
    End Function






    Public Overrides Sub LoadFileToField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid)


        If filepath <> "" Then
            Try
                Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = :Data WHERE " + table + "id=" & ID2Const(RowID)
                Dim cmd As System.Data.Common.DbCommand

                cmd = New OracleCommand
                cmd.Connection = dbconn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                Dim aBytes() As Byte
                aBytes = IO.File.ReadAllBytes(filepath)
                cmd.Parameters.Add(New OracleParameter("Data", OracleDbType.Blob))
                cmd.Parameters("Data").Value = aBytes
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally
            End Try
        Else
            Dim strSQL As String =
            "UPDATE " + table + " SET " + field + " = null WHERE " + table + "id =" & ID2Const(RowID)
            Dim cmd As System.Data.Common.DbCommand
            cmd = New OracleCommand
            cmd.Connection = dbconn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.Parameters.Add(New OracleParameter("ID", Utils.GUID2String(RowID)))
            cmd.ExecuteNonQuery()
        End If

    End Sub


    Public Sub LoadStringToField(ByVal DBConnect As DbConnection, ByVal Data As String, ByVal table As String, ByVal field As String, ByVal idField As String, ByVal RowID As String)

        If Data <> "" Then

            Try
                Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = :Data WHERE " + idField + "=:ID"
                Dim cmd As System.Data.Common.DbCommand

                cmd = New OracleCommand
                cmd.Connection = DBConnect
                cmd.CommandType = CommandType.Text
                cmd.CommandText = strSQL
                cmd.Parameters.Add(New OracleParameter("Data", OracleDbType.Blob))
                cmd.Parameters.Add(New OracleParameter("ID", RowID))
                cmd.Parameters("Data").Value = System.Text.Encoding.UTF8.GetBytes(Data)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                System.Diagnostics.Debug.Print(ex.Message)
            Finally
            End Try
        Else
            Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = null WHERE " + idField + " = :ID"
            Dim cmd As System.Data.Common.DbCommand
            cmd = New OracleCommand
            cmd.Connection = DBConnect
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.Parameters.Add(New OracleParameter("ID", RowID))
            cmd.ExecuteNonQuery()
        End If

    End Sub


    Public Overrides Function SaveFileFromField(ByRef DBConnect As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid) As Long
        Dim fs As FileStream                 ' Writes the BLOB to a file (*.bmp).
        Dim bw As BinaryWriter               ' Streams the binary data to the FileStream object.
        Dim bufferSize As Integer = 32000      ' The size of the BLOB buffer.
        Dim outbyte(bufferSize - 1) As Byte  ' The BLOB byte() buffer to be filled by GetBytes.
        Dim retval As Long                   ' The bytes returned from GetBytes.
        Dim startIndex As Long = 0           ' The starting position in the BLOB output.
        Dim cmd As System.Data.Common.DbCommand
        cmd = New OracleCommand
        cmd.Connection = DBConnect
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select " + field + " from " + table + " where " + table + "id='" + Utils.GUID2String(RowID) + "'"
        Dim myReader As OracleDataReader = Nothing
        Try
            fs = New FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
        Catch
            Return 0
        End Try
        Try
            SyncLock cmd.Connection
                myReader = CType(cmd.ExecuteReader(CommandBehavior.SequentialAccess), OracleDataReader)
                Do While myReader.Read()

                    bw = New BinaryWriter(fs)
                    startIndex = 0
                    retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                    Do While retval = bufferSize
                        bw.Write(outbyte)
                        bw.Flush()
                        startIndex += bufferSize
                        Try
                            retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                        Catch ex As Exception
                            retval = 0
                        End Try
                    Loop
                    'bw.Write(outbyte, 0, retval - 1)
                    bw.Write(outbyte, 0, CType(retval, Integer))
                    bw.Flush()
                    bw.Close()
                Loop
            End SyncLock
        Catch

        Finally
            If (Not myReader Is Nothing) Then
                myReader.Close()
                myReader.Dispose()
            End If
            If (Not cmd Is Nothing) Then
                cmd.Dispose()
            End If
        End Try

        Try
            fs.Close()
        Catch
        End Try
        Return retval
    End Function


    Public Function GetStringFromField(ByVal DBConnect As DbConnection, ByRef Data As String, ByVal table As String, ByVal field As String, ByVal idField As String, ByVal RowID As String) As Long
        Dim bufferSize As Integer = 32000      ' The size of the BLOB buffer.
        Dim outbyte(bufferSize - 1) As Byte  ' The BLOB byte() buffer to be filled by GetBytes.
        Dim buf(0) As Byte
        Dim retval As Long                   ' The bytes returned from GetBytes.
        Dim startIndex As Long = 0           ' The starting position in the BLOB output.
        Dim cmd As System.Data.Common.DbCommand
        cmd = New OracleCommand
        cmd.Connection = DBConnect
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select " + field + " from " + table + " where " + idField + "=" + RowID
        Dim myReader As OracleDataReader = Nothing

        Try
            SyncLock cmd.Connection
                myReader = CType(cmd.ExecuteReader(CommandBehavior.SequentialAccess), OracleDataReader)
                Do While myReader.Read()

                    startIndex = 0
                    retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                    Do While retval = bufferSize
                        Array.Resize(buf, CType(buf.Length + retval, Integer))
                        Array.Copy(outbyte, buf, startIndex)
                        startIndex += bufferSize
                        Try
                            retval = myReader.GetBytes(0, startIndex, outbyte, 0, bufferSize)
                        Catch ex As Exception
                            retval = 0
                        End Try
                    Loop
                    Array.Resize(buf, CType(buf.Length + retval, Integer))
                    Array.Copy(outbyte, 0, buf, startIndex, retval)
                    Data = System.Text.Encoding.UTF8.GetString(buf)
                Loop
            End SyncLock
        Catch

        Finally
            If (Not myReader Is Nothing) Then
                myReader.Close()
                myReader.Dispose()
            End If
            If (Not cmd Is Nothing) Then
                cmd.Dispose()
            End If
        End Try
        Return retval
    End Function



End Class
