
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация раздела Модулив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES2_MODULE_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ROLES2_MODULE"
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
            dt.TableName="ROLES2_MODULE"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("GroupName", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("Sequence", Gettype(System.Int32))
            dt.Columns.Add("ModuleAccessible_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ModuleAccessible", Gettype(System.string))
            dt.Columns.Add("CustomizeVisibility_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CustomizeVisibility", Gettype(System.string))
            dt.Columns.Add("TheIcon", Gettype(System.string))
            dt.Columns.Add("name", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            dt.Columns.Add("AllObjects_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllObjects", Gettype(System.string))
            dt.Columns.Add("ColegsObject_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ColegsObject", Gettype(System.string))
            dt.Columns.Add("SubStructObjects_VAL" , Gettype(System.Int16))
            dt.Columns.Add("SubStructObjects", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New ROLES2_MODULE
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As ROLES.ROLES2_MODULE
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(ROLES.ROLES2_MODULE))
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
        Public Shadows Function Item( vIndex as object ) As ROLES.ROLES2_MODULE
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ROLES2_MODULEID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", groupname" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", moduleaccessible" 
           mFieldList =mFieldList+ ", customizevisibility" 
           mFieldList =mFieldList+ ", theicon" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", thecomment" 
           mFieldList =mFieldList+ ", allobjects" 
           mFieldList =mFieldList+ ", colegsobject" 
           mFieldList =mFieldList+ ", substructobjects" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
