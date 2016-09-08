
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZwp


''' <summary>
'''Реализация раздела Армв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class WorkPlace_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "WorkPlace"
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
            dt.TableName="WorkPlace"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("TheVersion", Gettype(System.string))
            dt.Columns.Add("ThePlatform_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ThePlatform", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New WorkPlace
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZwp.WorkPlace
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZwp.WorkPlace))
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
        Public Shadows Function Item( vIndex as object ) As MTZwp.WorkPlace
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("WorkPlaceID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", theversion" 
           mFieldList =mFieldList+ ", theplatform" 
           mFieldList =mFieldList+ ", thecomment" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
