
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Связанные представленияв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTVIEW_LNK_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "PARTVIEW_LNK"
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
            dt.TableName="PARTVIEW_LNK"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TheView_ID" , GetType(System.guid))
            dt.Columns.Add("TheView", Gettype(System.string))
            dt.Columns.Add("TheJoinSource_ID" , GetType(System.guid))
            dt.Columns.Add("TheJoinSource", Gettype(System.string))
            dt.Columns.Add("RefType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("RefType", Gettype(System.string))
            dt.Columns.Add("TheJoinDestination_ID" , GetType(System.guid))
            dt.Columns.Add("TheJoinDestination", Gettype(System.string))
            dt.Columns.Add("HandJoin", Gettype(System.string))
            dt.Columns.Add("SEQ", Gettype(System.Int32))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New PARTVIEW_LNK
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.PARTVIEW_LNK
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.PARTVIEW_LNK))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.PARTVIEW_LNK
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("PARTVIEW_LNKID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("TheView") 
           mFieldList =mFieldList+","+.ID2Base("TheJoinSource") 
           mFieldList =mFieldList+ ", reftype" 
           mFieldList =mFieldList+","+.ID2Base("TheJoinDestination") 
           mFieldList =mFieldList+ ", handjoin" 
           mFieldList =mFieldList+ ", seq" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
