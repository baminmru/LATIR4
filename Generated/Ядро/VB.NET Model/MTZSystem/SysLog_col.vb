
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace MTZSystem


''' <summary>
'''Реализация раздела Журнал событийв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class SysLog_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "SysLog"
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
            dt.TableName="SysLog"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TheSession_ID" , GetType(System.guid))
            dt.Columns.Add("TheSession", Gettype(System.string))
            dt.Columns.Add("the_Resource", Gettype(System.string))
            dt.Columns.Add("LogStructID", Gettype(System.string))
            dt.Columns.Add("VERB", Gettype(System.string))
            dt.Columns.Add("LogInstanceID", GetType(System.guid))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New SysLog
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZSystem.SysLog
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZSystem.SysLog))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As MTZSystem.SysLog
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("SysLogID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("TheSession") 
           mFieldList =mFieldList+ ", the_resource" 
           mFieldList =mFieldList+ ", logstructid" 
           mFieldList =mFieldList+ ", verb" 
           mFieldList =mFieldList+ ", loginstanceid" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
