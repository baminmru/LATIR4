
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZJrnl


''' <summary>
'''Реализация раздела Источники журналав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class JournalSrc_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "JournalSrc"
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
            dt.TableName="JournalSrc"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("PartView", GetType(System.guid))
            dt.Columns.Add("OnRun_VAL" , Gettype(System.Int16))
            dt.Columns.Add("OnRun", Gettype(System.string))
            dt.Columns.Add("OpenMode", Gettype(System.string))
            dt.Columns.Add("ViewAlias", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New JournalSrc
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZJrnl.JournalSrc
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZJrnl.JournalSrc))
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
        Public Shadows Function Item( vIndex as object ) As MTZJrnl.JournalSrc
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("JournalSrcID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", partview" 
           mFieldList =mFieldList+ ", onrun" 
           mFieldList =mFieldList+ ", openmode" 
           mFieldList =mFieldList+ ", viewalias" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
