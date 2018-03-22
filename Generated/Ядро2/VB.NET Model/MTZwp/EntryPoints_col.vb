
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZwp


''' <summary>
'''Реализация раздела Менюв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class EntryPoints_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "EntryPoints"
        End Function



''' <summary>
'''Признак древовидного раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function IsTree() As Boolean
            IsTree=true
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
            dt.TableName="EntryPoints"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("AsToolbarItem_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AsToolbarItem", Gettype(System.string))
            dt.Columns.Add("ActionType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ActionType", Gettype(System.string))
            dt.Columns.Add("TheFilter_ID" , GetType(System.guid))
            dt.Columns.Add("TheFilter", Gettype(System.string))
            dt.Columns.Add("Journal_ID" , GetType(System.guid))
            dt.Columns.Add("Journal", Gettype(System.string))
            dt.Columns.Add("Report_ID" , GetType(System.guid))
            dt.Columns.Add("Report", Gettype(System.string))
            dt.Columns.Add("Document_ID" , GetType(System.guid))
            dt.Columns.Add("Document", Gettype(System.string))
            dt.Columns.Add("Method_ID" , GetType(System.guid))
            dt.Columns.Add("Method", Gettype(System.string))
            dt.Columns.Add("IconFile", Gettype(System.string))
            dt.Columns.Add("TheExtention_ID" , GetType(System.guid))
            dt.Columns.Add("TheExtention", Gettype(System.string))
            dt.Columns.Add("ARM_ID" , GetType(System.guid))
            dt.Columns.Add("ARM", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            dt.Columns.Add("ObjectType_ID" , GetType(System.guid))
            dt.Columns.Add("ObjectType", Gettype(System.string))
            dt.Columns.Add("JournalFixedQuery", Gettype(System.string))
            dt.Columns.Add("AllowAdd_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowAdd", Gettype(System.string))
            dt.Columns.Add("AllowEdit_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowEdit", Gettype(System.string))
            dt.Columns.Add("AllowDel_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowDel", Gettype(System.string))
            dt.Columns.Add("AllowFilter_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowFilter", Gettype(System.string))
            dt.Columns.Add("AllowPrint_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowPrint", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New EntryPoints
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZwp.EntryPoints
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZwp.EntryPoints))
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
        Public Shadows Function Item( vIndex as object ) As MTZwp.EntryPoints
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("EntryPointsID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("PARENTROWID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", astoolbaritem" 
           mFieldList =mFieldList+ ", actiontype" 
           mFieldList =mFieldList+","+.ID2Base("TheFilter") 
           mFieldList =mFieldList+","+.ID2Base("Journal") 
           mFieldList =mFieldList+","+.ID2Base("Report") 
           mFieldList =mFieldList+","+.ID2Base("Document") 
           mFieldList =mFieldList+","+.ID2Base("Method") 
           mFieldList =mFieldList+ ", iconfile" 
           mFieldList =mFieldList+","+.ID2Base("TheExtention") 
           mFieldList =mFieldList+","+.ID2Base("ARM") 
           mFieldList =mFieldList+ ", thecomment" 
           mFieldList =mFieldList+","+.ID2Base("ObjectType") 
           mFieldList =mFieldList+ ", journalfixedquery" 
           mFieldList =mFieldList+ ", allowadd" 
           mFieldList =mFieldList+ ", allowedit" 
           mFieldList =mFieldList+ ", allowdel" 
           mFieldList =mFieldList+ ", allowfilter" 
           mFieldList =mFieldList+ ", allowprint" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
