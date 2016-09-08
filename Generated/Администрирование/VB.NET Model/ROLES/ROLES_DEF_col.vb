
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация раздела Определение ролив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_DEF_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "ROLES_DEF"
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
            dt.TableName="ROLES_DEF"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("name", Gettype(System.string))
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
            NewItem = New ROLES_DEF
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As ROLES.ROLES_DEF
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(ROLES.ROLES_DEF))
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
        Public Shadows Function Item( vIndex as object ) As ROLES.ROLES_DEF
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("ROLES_DEFID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", allobjects" 
           mFieldList =mFieldList+ ", colegsobject" 
           mFieldList =mFieldList+ ", substructobjects" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
