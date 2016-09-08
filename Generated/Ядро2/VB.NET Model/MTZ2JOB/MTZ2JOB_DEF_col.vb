
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace MTZ2JOB


''' <summary>
'''Реализация раздела Отложенное событиев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class MTZ2JOB_DEF_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "MTZ2JOB_DEF"
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
            dt.TableName="MTZ2JOB_DEF"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("EventDate", GetType(System.DateTime))
            dt.Columns.Add("EvenType", Gettype(System.string))
            dt.Columns.Add("ThruObject_ID" , GetType(System.guid))
            dt.Columns.Add("ThruObject", Gettype(System.string))
            dt.Columns.Add("ThruState", GetType(System.guid))
            dt.Columns.Add("NextState", GetType(System.guid))
            dt.Columns.Add("ProcessDate", GetType(System.DateTime))
            dt.Columns.Add("Processed_VAL" , Gettype(System.Int16))
            dt.Columns.Add("Processed", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New MTZ2JOB_DEF
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZ2JOB.MTZ2JOB_DEF
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZ2JOB.MTZ2JOB_DEF))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As MTZ2JOB.MTZ2JOB_DEF
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("MTZ2JOB_DEFID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.Date2Base("EventDate") 
           mFieldList =mFieldList+ ", eventype" 
           mFieldList =mFieldList+","+.ID2Base("ThruObject") 
           mFieldList =mFieldList+ ", thrustate" 
           mFieldList =mFieldList+ ", nextstate" 
           mFieldList =mFieldList+","+.Date2Base("ProcessDate") 
           mFieldList =mFieldList+ ", processed" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
