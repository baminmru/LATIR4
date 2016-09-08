
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Тип объектав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class OBJECTTYPE_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "OBJECTTYPE"
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
            dt.TableName="OBJECTTYPE"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Package_ID" , GetType(System.guid))
            dt.Columns.Add("Package", Gettype(System.string))
            dt.Columns.Add("the_Comment", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("IsSingleInstance_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsSingleInstance", Gettype(System.string))
            dt.Columns.Add("ChooseView_ID" , GetType(System.guid))
            dt.Columns.Add("ChooseView", Gettype(System.string))
            dt.Columns.Add("OnRun_ID" , GetType(System.guid))
            dt.Columns.Add("OnRun", Gettype(System.string))
            dt.Columns.Add("OnCreate_ID" , GetType(System.guid))
            dt.Columns.Add("OnCreate", Gettype(System.string))
            dt.Columns.Add("OnDelete_ID" , GetType(System.guid))
            dt.Columns.Add("OnDelete", Gettype(System.string))
            dt.Columns.Add("AllowRefToObject_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowRefToObject", Gettype(System.string))
            dt.Columns.Add("AllowSearch_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AllowSearch", Gettype(System.string))
            dt.Columns.Add("ReplicaType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ReplicaType", Gettype(System.string))
            dt.Columns.Add("TheComment", Gettype(System.string))
            dt.Columns.Add("UseOwnership_VAL" , Gettype(System.Int16))
            dt.Columns.Add("UseOwnership", Gettype(System.string))
            dt.Columns.Add("UseArchiving_VAL" , Gettype(System.Int16))
            dt.Columns.Add("UseArchiving", Gettype(System.string))
            dt.Columns.Add("CommitFullObject_VAL" , Gettype(System.Int16))
            dt.Columns.Add("CommitFullObject", Gettype(System.string))
            dt.Columns.Add("objIconCls", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New OBJECTTYPE
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.OBJECTTYPE
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.OBJECTTYPE))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.OBJECTTYPE
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("OBJECTTYPEID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("Package") 
           mFieldList =mFieldList+ ", the_comment" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", issingleinstance" 
           mFieldList =mFieldList+","+.ID2Base("ChooseView") 
           mFieldList =mFieldList+","+.ID2Base("OnRun") 
           mFieldList =mFieldList+","+.ID2Base("OnCreate") 
           mFieldList =mFieldList+","+.ID2Base("OnDelete") 
           mFieldList =mFieldList+ ", allowreftoobject" 
           mFieldList =mFieldList+ ", allowsearch" 
           mFieldList =mFieldList+ ", replicatype" 
           mFieldList =mFieldList+ ", thecomment" 
           mFieldList =mFieldList+ ", useownership" 
           mFieldList =mFieldList+ ", usearchiving" 
           mFieldList =mFieldList+ ", commitfullobject" 
           mFieldList =mFieldList+ ", objiconcls" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
