
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Imports LATIR2.Utils




Public Class DBProvider

    Public Enum DBProviderType
        Unknown = 0
        MSSQL = 1
        ORACLE = 2
        POSTGRESQL = 3
        MYSQL = 4
    End Enum

    Private _ProviderType As DBProviderType

    Public Sub New()
        ProviderType = DBProviderType.Unknown
    End Sub

    Public Property ProviderType() As DBProviderType
        Get
            Return _ProviderType
        End Get
        Set(ByVal value As DBProviderType)
            _ProviderType = value
        End Set
    End Property



    Public Overridable Function BuildCN( _
    ByVal Server As String, _
    ByVal DataBaseName As String, _
    ByVal UserName As String, _
    ByVal Password As String, _
    ByVal LoginTimeOut As String, _
    ByVal Provider As String, _
    ByVal Integrated As Boolean) As String
        Return "Provider=" & Provider & "; Data Source=" & Server & "; Database Name=" & DataBaseName
        '"Provider=MSDAORA; Data Source=ORACLE8i7;Persist Security Info=False;Integrated Security=Yes"
        '"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\bin\LocalAccess40.mdb"
        '"Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI"
    End Function

    Public Overridable Sub ConnectSetup(BuildCN As DbConnection)
        ' do nothing
    End Sub


    Public Overridable Function CreateConnection(ByVal ConnectionString As String) As DbConnection
        Dim cn As DbConnection
        cn = New OleDb.OleDbConnection
        cn.ConnectionString = ConnectionString
        Return cn
    End Function

    Public Overridable Function CreateCommand() As DbCommand
        Return New OleDb.OleDbCommand
    End Function

    Public Overridable Function CreateDataAdapter() As DbDataAdapter
        Return New OleDb.OleDbDataAdapter
    End Function

    Public Overridable Function GetTestQuery() As String
        Return "SELECT 'OK' SRV_TEST"
    End Function

    Public Overridable Function GetServerDate() As String
        Return "select getdate() SRV_DATE"
    End Function


    Public Overridable Function DateFunc() As String
        Return "getdate()"
    End Function



    Public Overridable Function IsNUll(ByVal TryValue As String, ByVal NoNullValue As String) As String
        Return IsNULL_SQL(ProviderType, TryValue, NoNullValue)
    End Function

    Public Overridable Function ID2Base(ByVal fieldName As String) As String
        Return fieldName
    End Function

    Public Overridable Function ID2Base(ByVal fieldName As String, ByVal FieldAlias As String) As String
        Return fieldName + " " + FieldAlias
    End Function


    Public Overridable Function ID2Const(ByVal ID As Guid) As String
        Return "'" + GUID2String(ID) + "'"
    End Function

    Public Overridable Function ID2DbType() As DbType
        Return DbType.Guid
    End Function

    Public Overridable Function ID2Size() As Integer
        Return -1
    End Function



    Public Overridable Function ID2Param(ByVal ID As Guid) As Object
        Return ID
    End Function

    Public Overridable Function Date2Base(ByVal fieldName As String) As String
        Return fieldName
    End Function


    Public Overridable Function Date2Const(ByVal D As Date) As String
        Return MakeODBCDate(d)
    End Function

    Public Overridable Function Dig2Base(ByVal fieldName As String) As String
        Return fieldName
    End Function


    Public Overridable Function Dig2Const(ByVal Dig As Double) As String
        Return Dig.ToString().Replace(",", ".")
    End Function

    Public Overridable Function InstanceFieldList() As String
        Return "*"
    End Function



    Public Overridable Function SaveFileFromField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid) As Long
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




    Public Overridable Sub LoadFileToField(ByRef dbconn As DbConnection, ByVal filepath As String, ByVal table As String, ByVal field As String, ByVal RowID As Guid)

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

