
Option Explicit On
Imports System.Data



Public Class NamedValue
    'Именованные значения
    Public TheName As String
    'Public DataType As DbType
    Public int_DataType As DbType
    Public Direction As ParameterDirection
    Private _Value As Object
    Public Size As Integer

    Public Sub New()
        DataType = DbType.String
        Direction = ParameterDirection.Input
    End Sub

    Property DataType() As DbType
        Get
            Return int_DataType
        End Get
        Set(ByVal value As DbType)
          

                int_DataType = value

        End Set
    End Property

    Property Value() As Object
        Get
            Return _Value
        End Get
        Set(ByVal value2 As Object)
            _Value = value2

        End Set
    End Property


End Class
