Imports System
Imports System.Data
Imports System.Data.Common
Imports MySql.Data
Imports LATIR2.Utils


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
        connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false; charset=utf8;Convert Zero Datetime=true;", _
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
        Return "G2B('" + ID2String(ID.ToString()) + "')"
    End Function

    Public Overrides Function ID2DbType() As DbType
        Return DbType.String
    End Function

    Public Overrides Function ID2Size() As Integer
        Return 38
    End Function

    Public Overrides Function ID2Param(ByVal ID As Guid) As Object
        Return ID2String(ID.ToString())
    End Function

    Public Overrides Function Date2Base(ByVal fieldName As String) As String
        Return "DATE_FORMAT(" + fieldName.ToLower + ",'%Y/%m/%d %H:%i:%s') " + fieldName.ToLower
    End Function


    Public Overrides Function InstanceFieldList() As String
        Return "B2G(instanceid) instanceid,name,objtype, b2g(locksessionid) locksessionid, b2g(lockuserid) lockuserid, b2g(status) status,ownerpartname ,b2g(ownerrowid) ownerrowid "
    End Function

End Class
