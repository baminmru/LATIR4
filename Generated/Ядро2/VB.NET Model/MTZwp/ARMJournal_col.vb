
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZwp


''' <summary>
'''Реализация раздела Поведение журналовв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ARMJournal_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ARMJournal"
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
            dt.TableName="ARMJournal"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TheJournal_ID" , GetType(System.guid))
            dt.Columns.Add("TheJournal", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New ARMJournal
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZwp.ARMJournal
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZwp.ARMJournal))
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
        Public Shadows Function Item( vIndex as object ) As MTZwp.ARMJournal
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ARMJournalID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("TheJournal") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
