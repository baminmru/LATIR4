
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZJrnl


''' <summary>
'''Реализация раздела Журналв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Journal_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Journal"
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
            dt.TableName="Journal"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("the_Alias", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            dt.Columns.Add("jrnlIconCls", Gettype(System.string))
            dt.Columns.Add("UseFavorites_VAL" , Gettype(System.Int16))
            dt.Columns.Add("UseFavorites", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Journal
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZJrnl.Journal
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZJrnl.Journal))
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
        Public Shadows Function Item( vIndex as object ) As MTZJrnl.Journal
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("JournalID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", the_alias" 
           mFieldList =mFieldList+ ", thecomment" 
           mFieldList =mFieldList+ ", jrnliconcls" 
           mFieldList =mFieldList+ ", usefavorites" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
