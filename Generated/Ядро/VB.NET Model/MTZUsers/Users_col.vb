
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZUsers


''' <summary>
'''Реализация раздела Пользователив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Users_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Users"
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
            dt.TableName="Users"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Family", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("SurName", Gettype(System.string))
            dt.Columns.Add("Login", Gettype(System.string))
            dt.Columns.Add("Password", Gettype(System.string))
            dt.Columns.Add("DomaiName", Gettype(System.string))
            dt.Columns.Add("EMail", Gettype(System.string))
            dt.Columns.Add("Phone", Gettype(System.string))
            dt.Columns.Add("LocalPhone", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Users
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZUsers.Users
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZUsers.Users))
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
        Public Shadows Function Item( vIndex as object ) As MTZUsers.Users
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("UsersID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", family" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", surname" 
           mFieldList =mFieldList+ ", login" 
           mFieldList =mFieldList+ ", password" 
           mFieldList =mFieldList+ ", domainame" 
           mFieldList =mFieldList+ ", email" 
           mFieldList =mFieldList+ ", phone" 
           mFieldList =mFieldList+ ", localphone" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
