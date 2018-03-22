
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZFltr


''' <summary>
'''Реализация раздела Группа полей фильтрав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FilterFieldGroup_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FilterFieldGroup"
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
            dt.TableName="FilterFieldGroup"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("AllowIgnore_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowIgnore", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FilterFieldGroup
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZFltr.FilterFieldGroup
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZFltr.FilterFieldGroup))
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
        Public Shadows Function Item( vIndex as object ) As MTZFltr.FilterFieldGroup
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FilterFieldGroupID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", allowignore" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
