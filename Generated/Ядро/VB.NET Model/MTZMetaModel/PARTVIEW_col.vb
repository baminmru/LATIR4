
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Представлениев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTVIEW_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "PARTVIEW"
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
            dt.TableName="PARTVIEW"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("the_Alias", Gettype(System.string))
            dt.Columns.Add("ForChoose_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ForChoose", Gettype(System.string))
            dt.Columns.Add("FilterField0", Gettype(System.string))
            dt.Columns.Add("FilterField1", Gettype(System.string))
            dt.Columns.Add("FilterField2", Gettype(System.string))
            dt.Columns.Add("FilterField3", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New PARTVIEW
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.PARTVIEW
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.PARTVIEW))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.PARTVIEW
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("PARTVIEWID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", the_alias" 
           mFieldList =mFieldList+ ", forchoose" 
           mFieldList =mFieldList+ ", filterfield0" 
           mFieldList =mFieldList+ ", filterfield1" 
           mFieldList =mFieldList+ ", filterfield2" 
           mFieldList =mFieldList+ ", filterfield3" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
