
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace MTZSystem


''' <summary>
'''Реализация раздела Разрешенные владельцыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class SysRefCache_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "SysRefCache"
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
            dt.TableName="SysRefCache"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("CacheType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CacheType", Gettype(System.string))
            dt.Columns.Add("ObjectOwnerID", GetType(System.guid))
            dt.Columns.Add("SessionID_ID" , GetType(System.guid))
            dt.Columns.Add("SessionID", Gettype(System.string))
            dt.Columns.Add("modulename", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New SysRefCache
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZSystem.SysRefCache
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZSystem.SysRefCache))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As MTZSystem.SysRefCache
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("SysRefCacheID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", cachetype" 
           mFieldList =mFieldList+ ", objectownerid" 
           mFieldList =mFieldList+","+.ID2Base("SessionID") 
           mFieldList =mFieldList+ ", modulename" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
