
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Контрольные элементыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class GENCONTROLS_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "GENCONTROLS"
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
            dt.TableName="GENCONTROLS"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("ControlProgID", Gettype(System.string))
            dt.Columns.Add("ControlClassID", Gettype(System.string))
            dt.Columns.Add("VersionMajor", Gettype(System.Int32))
            dt.Columns.Add("VersionMinor", Gettype(System.Int32))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New GENCONTROLS
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.GENCONTROLS
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.GENCONTROLS))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.GENCONTROLS
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("GENCONTROLSID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", controlprogid" 
           mFieldList =mFieldList+ ", controlclassid" 
           mFieldList =mFieldList+ ", versionmajor" 
           mFieldList =mFieldList+ ", versionminor" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
