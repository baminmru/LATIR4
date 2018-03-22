
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Органичения разделовв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class STRUCTRESTRICTION_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "STRUCTRESTRICTION"
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
            dt.TableName="STRUCTRESTRICTION"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Struct_ID" , GetType(System.guid))
            dt.Columns.Add("Struct", Gettype(System.string))
            dt.Columns.Add("AllowRead_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowRead", Gettype(System.string))
            dt.Columns.Add("AllowAdd_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowAdd", Gettype(System.string))
            dt.Columns.Add("AllowEdit_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowEdit", Gettype(System.string))
            dt.Columns.Add("AllowDelete_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowDelete", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New STRUCTRESTRICTION
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.STRUCTRESTRICTION
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.STRUCTRESTRICTION))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.STRUCTRESTRICTION
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("STRUCTRESTRICTIONID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("Struct") 
           mFieldList =mFieldList+ ", allowread" 
           mFieldList =mFieldList+ ", allowadd" 
           mFieldList =mFieldList+ ", allowedit" 
           mFieldList =mFieldList+ ", allowdelete" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
