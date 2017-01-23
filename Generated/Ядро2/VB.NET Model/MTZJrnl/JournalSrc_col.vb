
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace mtzjrnl


''' <summary>
'''Реализация раздела Источники журналав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class journalsrc_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "journalsrc"
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
            dt.TableName="journalsrc"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("spartview", Gettype(System.string))
            dt.Columns.Add("onrun_VAL" , Gettype(System.Int16))
            dt.Columns.Add("onrun", Gettype(System.string))
            dt.Columns.Add("openmode", Gettype(System.string))
            dt.Columns.Add("viewalias", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New journalsrc
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As mtzjrnl.journalsrc
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(mtzjrnl.journalsrc))
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
        Public Shadows Function Item( vIndex as object ) As mtzjrnl.journalsrc
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("journalsrcID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", spartview" 
           mFieldList =mFieldList+ ", onrun" 
           mFieldList =mFieldList+ ", openmode" 
           mFieldList =mFieldList+ ", viewalias" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
