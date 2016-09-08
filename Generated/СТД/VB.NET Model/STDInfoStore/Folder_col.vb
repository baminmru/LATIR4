
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace STDInfoStore


''' <summary>
'''Реализация раздела Папкав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Folder_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Folder"
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
            dt.TableName="Folder"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("FolderType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("FolderType", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Folder
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As STDInfoStore.Folder
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(STDInfoStore.Folder))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As STDInfoStore.Folder
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FolderID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("PARENTROWID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", foldertype" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
