
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace MTZExt


''' <summary>
'''Реализация раздела Реализации расширенияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class MTZExtRel_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "MTZExtRel"
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
            dt.TableName="MTZExtRel"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ThePlatform_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ThePlatform", Gettype(System.string))
            dt.Columns.Add("TheClassName", Gettype(System.string))
            dt.Columns.Add("TheLibraryName", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New MTZExtRel
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZExt.MTZExtRel
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZExt.MTZExtRel))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As MTZExt.MTZExtRel
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("MTZExtRelID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", theplatform" 
           mFieldList =mFieldList+ ", theclassname" 
           mFieldList =mFieldList+ ", thelibraryname" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
