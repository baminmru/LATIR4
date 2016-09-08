
Option Explicit On

Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
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
        Return " getdate() "
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
        Return "'" + ID2String (ID.ToString()) + "'"
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




End Class

