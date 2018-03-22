
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Параметрыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARAMETERS_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "PARAMETERS"
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
            dt.TableName="PARAMETERS"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("sequence", Gettype(System.Int32))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("TypeOfParm_ID" , GetType(System.guid))
            dt.Columns.Add("TypeOfParm", Gettype(System.string))
            dt.Columns.Add("DataSize", Gettype(System.Int32))
            dt.Columns.Add("AllowNull_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowNull", Gettype(System.string))
            dt.Columns.Add("OutParam_VAL" , Gettype(System.Int16))
            dt.Columns.Add("OutParam", Gettype(System.string))
            dt.Columns.Add("ReferenceType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ReferenceType", Gettype(System.string))
            dt.Columns.Add("RefToType_ID" , GetType(System.guid))
            dt.Columns.Add("RefToType", Gettype(System.string))
            dt.Columns.Add("RefToPart_ID" , GetType(System.guid))
            dt.Columns.Add("RefToPart", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New PARAMETERS
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.PARAMETERS
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.PARAMETERS))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.PARAMETERS
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("PARAMETERSID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+","+.ID2Base("TypeOfParm") 
           mFieldList =mFieldList+ ", datasize" 
           mFieldList =mFieldList+ ", allownull" 
           mFieldList =mFieldList+ ", outparam" 
           mFieldList =mFieldList+ ", referencetype" 
           mFieldList =mFieldList+","+.ID2Base("RefToType") 
           mFieldList =mFieldList+","+.ID2Base("RefToPart") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
