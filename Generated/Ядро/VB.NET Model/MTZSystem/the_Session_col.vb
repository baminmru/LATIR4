
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZSystem


''' <summary>
'''Реализация раздела Сессия пользователяв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class the_Session_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "the_Session"
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
            dt.TableName="the_Session"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ApplicationID_ID" , GetType(System.guid))
            dt.Columns.Add("ApplicationID", Gettype(System.string))
            dt.Columns.Add("UserRole_ID" , GetType(System.guid))
            dt.Columns.Add("UserRole", Gettype(System.string))
            dt.Columns.Add("ClosedAt", GetType(System.DateTime))
            dt.Columns.Add("Closed_VAL" , Gettype(System.Int16))
            dt.Columns.Add("Closed", Gettype(System.string))
            dt.Columns.Add("Usersid_ID" , GetType(System.guid))
            dt.Columns.Add("Usersid", Gettype(System.string))
            dt.Columns.Add("LastAccess", GetType(System.DateTime))
            dt.Columns.Add("StartAt", GetType(System.DateTime))
            dt.Columns.Add("Lang", Gettype(System.string))
            dt.Columns.Add("Login", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New the_Session
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZSystem.the_Session
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZSystem.the_Session))
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
        Public Shadows Function Item( vIndex as object ) As MTZSystem.the_Session
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("the_SessionID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("ApplicationID") 
           mFieldList =mFieldList+","+.ID2Base("UserRole") 
           mFieldList =mFieldList+","+.Date2Base("ClosedAt") 
           mFieldList =mFieldList+ ", closed" 
           mFieldList =mFieldList+","+.ID2Base("Usersid") 
           mFieldList =mFieldList+","+.Date2Base("LastAccess") 
           mFieldList =mFieldList+","+.Date2Base("StartAt") 
           mFieldList =mFieldList+ ", lang" 
           mFieldList =mFieldList+ ", login" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
