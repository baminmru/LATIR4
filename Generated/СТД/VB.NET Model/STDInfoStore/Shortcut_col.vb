
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace STDInfoStore


''' <summary>
'''Реализация раздела Документыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Shortcut_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Shortcut"
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
            dt.TableName="Shortcut"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("DocItem_ID" , GetType(System.guid))
            dt.Columns.Add("DocItem", Gettype(System.string))
            dt.Columns.Add("StartMode", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Shortcut
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As STDInfoStore.Shortcut
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(STDInfoStore.Shortcut))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As STDInfoStore.Shortcut
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ShortcutID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("DocItem") 
           mFieldList =mFieldList+ ", startmode" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
