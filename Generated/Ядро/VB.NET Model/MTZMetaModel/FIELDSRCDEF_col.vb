
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Описание источника данныхв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDSRCDEF_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FIELDSRCDEF"
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
            dt.TableName="FIELDSRCDEF"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Provider", Gettype(System.string))
            dt.Columns.Add("ConnectionString", Gettype(System.string))
            dt.Columns.Add("DataSource", Gettype(System.string))
            dt.Columns.Add("IDField", Gettype(System.string))
            dt.Columns.Add("BriefString", Gettype(System.string))
            dt.Columns.Add("FilterString", Gettype(System.string))
            dt.Columns.Add("SortField", Gettype(System.string))
            dt.Columns.Add("DescriptionString", Gettype(System.string))
            dt.Columns.Add("DontShowDialog_VAL" , Gettype(System.Int16))
            dt.Columns.Add("DontShowDialog", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FIELDSRCDEF
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.FIELDSRCDEF
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.FIELDSRCDEF))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.FIELDSRCDEF
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FIELDSRCDEFID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", provider" 
           mFieldList =mFieldList+ ", connectionstring" 
           mFieldList =mFieldList+ ", datasource" 
           mFieldList =mFieldList+ ", idfield" 
           mFieldList =mFieldList+ ", briefstring" 
           mFieldList =mFieldList+ ", filterstring" 
           mFieldList =mFieldList+ ", sortfield" 
           mFieldList =mFieldList+ ", descriptionstring" 
           mFieldList =mFieldList+ ", dontshowdialog" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
