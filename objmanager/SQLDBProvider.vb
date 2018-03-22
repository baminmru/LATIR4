Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LATIR2.Utils
Imports System.IO


Public Class SQLDBProvider
    Inherits LATIR2.DBProvider

    Public Sub New()
        ProviderType = DBProviderType.MSSQL
    End Sub

    Public Overrides Function BuildCN( _
           ByVal Server As String, _
           ByVal DataBaseName As String, _
           ByVal UserName As String, _
           ByVal Password As String, _
           ByVal LoginTimeOut As String, _
           ByVal Provider As String, _
           ByVal Integrated As Boolean) As String
        ' "Provider=" & Provider & "; Data Source=" & Server & "; Database Name=" & DataBaseName
        '"Provider=MSDAORA; Data Source=ORACLE8i7;Persist Security Info=False;Integrated Security=Yes"
        '"Provider=Microsoft.Jet.sqlclient.4.0; Data Source=c:\bin\LocalAccess40.mdb"
        '"Provider=SQLsqlclient;Data Source=(local);Integrated Security=SSPI"

        If Integrated Then
            Return "Integrated Security=SSPI;Database=" & DataBaseName & ";Server=" & Server & ";"
        Else
            Return "Database=" & DataBaseName & ";Server=" & Server & ";User ID=" & UserName & ";Pwd=" & Password & ";"
        End If

    End Function



    Public Overrides Function CreateConnection(ByVal ConnectionString As String) As DbConnection
        Dim cn As DbConnection
        cn = New SqlClient.SqlConnection
        cn.ConnectionString = ConnectionString
        Return cn
    End Function

    Public Overrides Function CreateCommand() As DbCommand
        Return New SqlClient.SqlCommand
    End Function

    Public Overrides Function CreateDataAdapter() As DbDataAdapter
        Return New SqlClient.SqlDataAdapter
    End Function

    Public Overrides Function GetTestQuery() As String
        Return "SELECT 'OK' SRV_TEST"
    End Function

    Public Overrides Function DateFunc() As String
        Return "get_date()"
    End Function


    Public Overrides Function Date2Const(ByVal d As Date) As String
        Return MakeMSSQLDate(d)
    End Function


    Public Overrides Function SaveFileFromField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid) As Long
        Dim fs As FileStream                 ' Writes the BLOB to a file (*.bmp).
        Dim bw As BinaryWriter               ' Streams the binary data to the FileStream object.
        Dim bufferSize As Integer = 32000      ' The size of the BLOB buffer.
        Dim outbyte(bufferSize - 1) As Byte  ' The BLOB byte() buffer to be filled by GetBytes.
        Dim retval As Long                 ' The bytes returned from GetBytes.
        Dim startIndex As Long = 0           ' The starting position in the BLOB output.
        Dim cmd As System.Data.Common.DbCommand



        cmd = CreateCommand()
        cmd.CommandText = "select " & field & " from " & table & " where " & table & "id='" & RowID.ToString() & "'"
        cmd.Connection = dbconn
        Dim myReader As System.Data.SqlClient.SqlDataReader = Nothing
        Try
            fs = New FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
        Catch
            Return 0
        End Try
        Try
            myReader = CType(cmd.ExecuteReader(CommandBehavior.SequentialAccess), SqlClient.SqlDataReader)
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
                        "UPDATE " + table + " SET " + field + " = @Data WHERE " + table + "ID = @ID"
                Dim cmd As System.Data.Common.DbCommand
                cmd = CreateCommand()
                cmd.CommandText = strSQL
                cmd.Connection = dbconn
                Dim aBytes() As Byte
                file = New IO.FileStream(filepath, IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                ReDim aBytes(CInt(file.Length))
                file.Read(aBytes, 0, CInt(file.Length))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Data", SqlDbType.Image, CInt(file.Length)))
                cmd.Parameters("@Data").Value = aBytes
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ID", RowID))
                cmd.ExecuteNonQuery()
                file.Close()
            Catch ex As Exception
            Finally
            End Try
        Else
            Dim strSQL As String =
                        "UPDATE " + table + " SET " + field + " = null WHERE " + table + "ID = @ID"
            Dim cmd As System.Data.Common.DbCommand
            cmd = CreateCommand()
            cmd.CommandText = strSQL
            cmd.Connection = dbconn
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ID", RowID))
            cmd.ExecuteNonQuery()
        End If

    End Sub


End Class
