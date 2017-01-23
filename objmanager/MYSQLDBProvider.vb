Imports System
Imports System.Data
Imports System.Data.Common
Imports MySql.Data
Imports LATIR2.Utils
Imports System.IO


Public Class MYSQLDBProvider
    Inherits LATIR2.DBProvider

    Public Sub New()
        ProviderType = DBProviderType.MYSQL
    End Sub

    Public Overrides Function BuildCN( _
           ByVal Server As String, _
           ByVal DataBaseName As String, _
           ByVal UserName As String, _
           ByVal Password As String, _
           ByVal LoginTimeOut As String, _
           ByVal Provider As String, _
           ByVal Integrated As Boolean) As String
         Dim connStr As String
        connStr = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false; charset=utf8; Convert Zero Datetime=true;",
        Server, UserName, Password, DataBaseName)
        Return connStr
    End Function

    Public Overrides Function CreateConnection(ByVal ConnectionString As String) As DbConnection
        Dim cn As DbConnection
        cn = New MySqlClient.MySqlConnection
        cn.ConnectionString = ConnectionString
        Return cn
    End Function

    Public Overrides Function CreateCommand() As DbCommand
        Return New MySqlClient.MySqlCommand
    End Function

    Public Overrides Function CreateDataAdapter() As DbDataAdapter
        Return New MySqlClient.MySqlDataAdapter
    End Function

    Public Overrides Function GetTestQuery() As String
        Return "SELECT 'OK' SRV_TEST"
    End Function
    Public Overrides Function GetServerDate() As String
        Return "select now() SRV_DATE"
    End Function

    Public Overrides Function DateFunc() As String
        Return "now()"
    End Function

    Public Overrides Function Date2Const(ByVal d As Date) As String
        Return MakeMySqlDate(d)
    End Function


    Public Overrides Function ID2Base(ByVal fieldName As String) As String
        Return "B2G(" + fieldName.ToLower + ") " + fieldName.ToLower
    End Function

    Public Overrides Function ID2Base(ByVal fieldName As String, ByVal FieldAlias As String) As String
        Return "B2G(" + fieldName.ToLower + ") " + FieldAlias.ToLower
    End Function

    Public Overrides Function ID2Const(ByVal ID As Guid) As String
        Return "G2B('" + GUID2String(ID) + "')"
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
        Return "DATE_FORMAT(" + fieldName.ToLower + ",'%Y/%m/%d %H:%i:%s') " + fieldName.ToLower
    End Function


    Public Overrides Function InstanceFieldList() As String
        Return "B2G(instanceid) instanceid,name,objtype, b2g(locksessionid) locksessionid, b2g(lockuserid) lockuserid, b2g(status) status,ownerpartname ,b2g(ownerrowid) ownerrowid "
    End Function



    Public Overrides Function SaveFileFromField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid) As Long
        Dim fs As FileStream                 ' Writes the BLOB to a file (*.bmp).
        Dim bw As BinaryWriter               ' Streams the binary data to the FileStream object.
        Dim bufferSize As Integer = 32000      ' The size of the BLOB buffer.
        Dim outbyte(bufferSize - 1) As Byte  ' The BLOB byte() buffer to be filled by GetBytes.
        Dim retval As Long                 ' The bytes returned from GetBytes.
        Dim startIndex As Long = 0           ' The starting position in the BLOB output.
        Dim cmd As MySqlClient.MySqlCommand



        cmd = New MySqlClient.MySqlCommand
        cmd.CommandText = "select " & field & " from " & table & " where " & table & "id=" & ID2Const(RowID)
        cmd.Connection = CType(dbconn, MySqlClient.MySqlConnection)
        Dim myReader As MySqlClient.MySqlDataReader = Nothing
        Try
            fs = New FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
        Catch
            Return 0
        End Try
        Try
            myReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
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
                bw.Write(outbyte, 0, CInt(retval))
                bw.Flush()
                bw.Close()
            Loop
        Catch

        Finally
            If (Not myReader Is Nothing) Then
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


    Public Overrides Sub LoadFileToField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid)
        If filepath <> "" Then
            Dim file As IO.FileStream
            Try
                Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = @Data WHERE " + table + "ID =" & ID2Const(RowID)
                Dim cmd As MySqlClient.MySqlCommand

                cmd = New MySqlClient.MySqlCommand
                cmd.CommandText = strSQL
                cmd.Connection = CType(dbconn, MySqlClient.MySqlConnection)
                Dim aBytes() As Byte
                file = New IO.FileStream(filepath, IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                ReDim aBytes(CInt(file.Length))
                file.Read(aBytes, 0, CInt(file.Length))
                cmd.Parameters.AddWithValue("@Data", aBytes)
                cmd.ExecuteNonQuery()
                file.Close()
            Catch ex As Exception
            Finally
            End Try
        Else
            Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = null WHERE " + table + "ID =" & ID2Const(RowID)
            Dim cmd As MySqlClient.MySqlCommand
            cmd = New MySqlClient.MySqlCommand
            cmd.CommandText = strSQL
            cmd.Connection = CType(dbconn, MySqlClient.MySqlConnection)

            cmd.ExecuteNonQuery()
        End If

    End Sub


End Class
