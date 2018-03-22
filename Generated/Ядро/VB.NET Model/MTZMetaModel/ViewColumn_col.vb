
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Колонкав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ViewColumn_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ViewColumn"
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
            dt.TableName="ViewColumn"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("the_Alias", Gettype(System.string))
            dt.Columns.Add("FromPart_ID" , GetType(System.guid))
            dt.Columns.Add("FromPart", Gettype(System.string))
            dt.Columns.Add("Field_ID" , GetType(System.guid))
            dt.Columns.Add("Field", Gettype(System.string))
            dt.Columns.Add("Aggregation_VAL" , Gettype(System.Int16))
            dt.Columns.Add("Aggregation", Gettype(System.string))
            dt.Columns.Add("Expression", Gettype(System.string))
            dt.Columns.Add("ForCombo_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ForCombo", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New ViewColumn
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.ViewColumn
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.ViewColumn))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.ViewColumn
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ViewColumnID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", the_alias" 
           mFieldList =mFieldList+","+.ID2Base("FromPart") 
           mFieldList =mFieldList+","+.ID2Base("Field") 
           mFieldList =mFieldList+ ", aggregation" 
           mFieldList =mFieldList+ ", expression" 
           mFieldList =mFieldList+ ", forcombo" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
