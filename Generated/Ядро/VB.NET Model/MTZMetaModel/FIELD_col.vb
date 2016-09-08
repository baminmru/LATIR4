
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Полев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELD_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "FIELD"
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
            dt.TableName="FIELD"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("TabName", Gettype(System.string))
            dt.Columns.Add("FieldGroupBox", Gettype(System.string))
            dt.Columns.Add("Sequence", Gettype(System.Int32))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("FieldType_ID" , GetType(System.guid))
            dt.Columns.Add("FieldType", Gettype(System.string))
            dt.Columns.Add("IsBrief_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsBrief", Gettype(System.string))
            dt.Columns.Add("IsTabBrief_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsTabBrief", Gettype(System.string))
            dt.Columns.Add("AllowNull_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowNull", Gettype(System.string))
            dt.Columns.Add("DataSize", Gettype(System.Int32))
            dt.Columns.Add("ReferenceType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ReferenceType", Gettype(System.string))
            dt.Columns.Add("RefToType_ID" , GetType(System.guid))
            dt.Columns.Add("RefToType", Gettype(System.string))
            dt.Columns.Add("RefToPart_ID" , GetType(System.guid))
            dt.Columns.Add("RefToPart", Gettype(System.string))
            dt.Columns.Add("TheStyle", Gettype(System.string))
            dt.Columns.Add("InternalReference_VAL" , Gettype(System.Int16))
            dt.Columns.Add("InternalReference", Gettype(System.string))
            dt.Columns.Add("CreateRefOnly_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CreateRefOnly", Gettype(System.string))
            dt.Columns.Add("IsAutoNumber_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsAutoNumber", Gettype(System.string))
            dt.Columns.Add("TheNumerator_ID" , GetType(System.guid))
            dt.Columns.Add("TheNumerator", Gettype(System.string))
            dt.Columns.Add("ZoneTemplate", Gettype(System.string))
            dt.Columns.Add("NumberDateField_ID" , GetType(System.guid))
            dt.Columns.Add("NumberDateField", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            dt.Columns.Add("shablonBrief", Gettype(System.string))
            dt.Columns.Add("theNameClass", Gettype(System.string))
            dt.Columns.Add("TheMask", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New FIELD
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.FIELD
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.FIELD))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.FIELD
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("FIELDID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", tabname" 
           mFieldList =mFieldList+ ", fieldgroupbox" 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+","+.ID2Base("FieldType") 
           mFieldList =mFieldList+ ", isbrief" 
           mFieldList =mFieldList+ ", istabbrief" 
           mFieldList =mFieldList+ ", allownull" 
           mFieldList =mFieldList+ ", datasize" 
           mFieldList =mFieldList+ ", referencetype" 
           mFieldList =mFieldList+","+.ID2Base("RefToType") 
           mFieldList =mFieldList+","+.ID2Base("RefToPart") 
           mFieldList =mFieldList+ ", thestyle" 
           mFieldList =mFieldList+ ", internalreference" 
           mFieldList =mFieldList+ ", createrefonly" 
           mFieldList =mFieldList+ ", isautonumber" 
           mFieldList =mFieldList+","+.ID2Base("TheNumerator") 
           mFieldList =mFieldList+ ", zonetemplate" 
           mFieldList =mFieldList+","+.ID2Base("NumberDateField") 
           mFieldList =mFieldList+ ", thecomment" 
           mFieldList =mFieldList+ ", shablonbrief" 
           mFieldList =mFieldList+ ", thenameclass" 
           mFieldList =mFieldList+ ", themask" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
