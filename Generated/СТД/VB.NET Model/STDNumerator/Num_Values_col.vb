
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data

Namespace STDNumerator


''' <summary>
'''Реализация раздела Номерав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Num_Values_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "Num_Values"
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
            dt.TableName="Num_Values"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("the_Value", Gettype(System.Int32))
            dt.Columns.Add("OwnerPartName", Gettype(System.string))
            dt.Columns.Add("OwnerRowID", GetType(System.guid))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New Num_Values
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As STDNumerator.Num_Values
            on error resume next
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(STDNumerator.Num_Values))
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As STDNumerator.Num_Values
            on error resume next
            return GetItem(vIndex)
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("Num_ValuesID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", the_value" 
           mFieldList =mFieldList+ ", ownerpartname" 
           mFieldList =mFieldList+ ", ownerrowid" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
