
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация раздела Действия и отчетыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES2_MODREPORT_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ROLES2_MODREPORT"
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
            dt.TableName="ROLES2_MODREPORT"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("AllowAction_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowAction", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("Sequence", Gettype(System.Int32))
            dt.Columns.Add("TheIcon", Gettype(System.string))
            dt.Columns.Add("IsReport_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsReport", Gettype(System.string))
            dt.Columns.Add("selectType", Gettype(System.Int32))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New ROLES2_MODREPORT
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As ROLES.ROLES2_MODREPORT
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(ROLES.ROLES2_MODREPORT))
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
        Public Shadows Function Item( vIndex as object ) As ROLES.ROLES2_MODREPORT
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ROLES2_MODREPORTID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", allowaction" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", theicon" 
           mFieldList =mFieldList+ ", isreport" 
           mFieldList =mFieldList+ ", selecttype" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
