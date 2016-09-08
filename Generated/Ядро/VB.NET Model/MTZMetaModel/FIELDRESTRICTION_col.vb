
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Ограничения полейв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDRESTRICTION_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FIELDRESTRICTION"
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
            dt.TableName="FIELDRESTRICTION"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ThePart_ID" , GetType(System.guid))
            dt.Columns.Add("ThePart", Gettype(System.string))
            dt.Columns.Add("TheField_ID" , GetType(System.guid))
            dt.Columns.Add("TheField", Gettype(System.string))
            dt.Columns.Add("AllowRead_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowRead", Gettype(System.string))
            dt.Columns.Add("AllowModify_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowModify", Gettype(System.string))
            dt.Columns.Add("MandatoryField_VAL" , Gettype(System.Int16))
            dt.Columns.Add("MandatoryField", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FIELDRESTRICTION
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.FIELDRESTRICTION
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.FIELDRESTRICTION))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.FIELDRESTRICTION
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FIELDRESTRICTIONID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("ThePart") 
           mFieldList =mFieldList+","+.ID2Base("TheField") 
           mFieldList =mFieldList+ ", allowread" 
           mFieldList =mFieldList+ ", allowmodify" 
           mFieldList =mFieldList+ ", mandatoryfield" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
