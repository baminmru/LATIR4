
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация раздела Доступные действияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_OPERATIONS_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ROLES_OPERATIONS"
        End Function



''' <summary>
'''Вернуть даные текущей коллекции в виде DataTable
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function CreateDataTable() As System.Data.DataTable
            Dim dt As DataTable
            dt = New DataTable
            dt.TableName="ROLES_OPERATIONS"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("info", Gettype(System.string))
            dt.Columns.Add("AllowAction_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowAction", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New ROLES_OPERATIONS
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As ROLES.ROLES_OPERATIONS
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(ROLES.ROLES_OPERATIONS))
catch ex as System.Exception
 Debug.Print( ex.Message + " >> " + ex.StackTrace)
end try
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As ROLES.ROLES_OPERATIONS
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ROLES_OPERATIONSID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", info" 
           mFieldList =mFieldList+ ", allowaction" 
           mFieldList =mFieldList+ ", name" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
