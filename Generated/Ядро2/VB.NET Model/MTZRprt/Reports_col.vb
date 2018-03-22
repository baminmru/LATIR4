
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZRprt


''' <summary>
'''Реализация раздела Описаниев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Reports_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Reports"
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
            dt.TableName="Reports"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("ReportFile", GetType(System.object))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("PrepareMethod_ID" , GetType(System.guid))
            dt.Columns.Add("PrepareMethod", Gettype(System.string))
            dt.Columns.Add("ReportType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ReportType", Gettype(System.string))
            dt.Columns.Add("TheReportExt_ID" , GetType(System.guid))
            dt.Columns.Add("TheReportExt", Gettype(System.string))
            dt.Columns.Add("ReportView", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Reports
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZRprt.Reports
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZRprt.Reports))
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
        Public Shadows Function Item( vIndex as object ) As MTZRprt.Reports
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ReportsID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", reportfile" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+","+.ID2Base("PrepareMethod") 
           mFieldList =mFieldList+ ", reporttype" 
           mFieldList =mFieldList+","+.ID2Base("TheReportExt") 
           mFieldList =mFieldList+ ", reportview" 
           mFieldList =mFieldList+ ", thecomment" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
