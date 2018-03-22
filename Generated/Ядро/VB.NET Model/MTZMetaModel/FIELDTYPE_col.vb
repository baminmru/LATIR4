
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Тип поляв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDTYPE_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FIELDTYPE"
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
            dt.TableName="FIELDTYPE"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("TypeStyle_VAL" , Gettype(System.Int16))
            dt.Columns.Add("TypeStyle", Gettype(System.string))
            dt.Columns.Add("the_Comment", Gettype(System.string))
            dt.Columns.Add("AllowSize_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowSize", Gettype(System.string))
            dt.Columns.Add("Minimum", Gettype(System.string))
            dt.Columns.Add("Maximum", Gettype(System.string))
            dt.Columns.Add("AllowLikeSearch_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowLikeSearch", Gettype(System.string))
            dt.Columns.Add("GridSortType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("GridSortType", Gettype(System.string))
            dt.Columns.Add("DelayedSave_VAL" , Gettype(System.Int16))
            dt.Columns.Add("DelayedSave", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FIELDTYPE
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.FIELDTYPE
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.FIELDTYPE))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.FIELDTYPE
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FIELDTYPEID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", typestyle" 
           mFieldList =mFieldList+ ", the_comment" 
           mFieldList =mFieldList+ ", allowsize" 
           mFieldList =mFieldList+ ", minimum" 
           mFieldList =mFieldList+ ", maximum" 
           mFieldList =mFieldList+ ", allowlikesearch" 
           mFieldList =mFieldList+ ", gridsorttype" 
           mFieldList =mFieldList+ ", delayedsave" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
