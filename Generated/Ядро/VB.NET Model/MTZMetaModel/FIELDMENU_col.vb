
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Методы поляв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDMENU_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FIELDMENU"
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
            dt.TableName="FIELDMENU"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("ToolTip", Gettype(System.string))
            dt.Columns.Add("ActionID_ID" , GetType(System.guid))
            dt.Columns.Add("ActionID", Gettype(System.string))
            dt.Columns.Add("IsMenuItem_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsMenuItem", Gettype(System.string))
            dt.Columns.Add("IsToolBarButton_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsToolBarButton", Gettype(System.string))
            dt.Columns.Add("HotKey", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FIELDMENU
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.FIELDMENU
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.FIELDMENU))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.FIELDMENU
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FIELDMENUID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", tooltip" 
           mFieldList =mFieldList+","+.ID2Base("ActionID") 
           mFieldList =mFieldList+ ", ismenuitem" 
           mFieldList =mFieldList+ ", istoolbarbutton" 
           mFieldList =mFieldList+ ", hotkey" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
