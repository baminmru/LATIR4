Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LATIR2.Utils


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


    Public Overrides Function Date2Const(ByVal d As Date) As String
        Return MakeMSSQLDate(d)
    End Function
End Class
