
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZFltr


''' <summary>
'''Реализация раздела Поле фильтрав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FileterField_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FileterField"
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
            dt.TableName="FileterField"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("FieldType_ID" , GetType(System.guid))
            dt.Columns.Add("FieldType", Gettype(System.string))
            dt.Columns.Add("FieldSize", Gettype(System.Int32))
            dt.Columns.Add("RefType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("RefType", Gettype(System.string))
            dt.Columns.Add("RefToType_ID" , GetType(System.guid))
            dt.Columns.Add("RefToType", Gettype(System.string))
            dt.Columns.Add("RefToPart_ID" , GetType(System.guid))
            dt.Columns.Add("RefToPart", Gettype(System.string))
            dt.Columns.Add("ValueArray_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ValueArray", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FileterField
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZFltr.FileterField
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZFltr.FileterField))
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
        Public Shadows Function Item( vIndex as object ) As MTZFltr.FileterField
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FileterFieldID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+","+.ID2Base("FieldType") 
           mFieldList =mFieldList+ ", fieldsize" 
           mFieldList =mFieldList+ ", reftype" 
           mFieldList =mFieldList+","+.ID2Base("RefToType") 
           mFieldList =mFieldList+","+.ID2Base("RefToPart") 
           mFieldList =mFieldList+ ", valuearray" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
