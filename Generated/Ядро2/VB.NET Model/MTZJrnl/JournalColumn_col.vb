
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace mtzjrnl


''' <summary>
'''Реализация раздела Колонки журналав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class journalcolumn_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "journalcolumn"
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
            dt.TableName="journalcolumn"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("name", Gettype(System.string))
            dt.Columns.Add("columnalignment_VAL" , Gettype(System.Int16))
            dt.Columns.Add("columnalignment", Gettype(System.string))
            dt.Columns.Add("colsort_VAL" , Gettype(System.Int16))
            dt.Columns.Add("colsort", Gettype(System.string))
            dt.Columns.Add("groupaggregation_VAL" , Gettype(System.Int16))
            dt.Columns.Add("groupaggregation", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New journalcolumn
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As mtzjrnl.journalcolumn
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(mtzjrnl.journalcolumn))
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
        Public Shadows Function Item( vIndex as object ) As mtzjrnl.journalcolumn
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("journalcolumnID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", columnalignment" 
           mFieldList =mFieldList+ ", colsort" 
           mFieldList =mFieldList+ ", groupaggregation" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
