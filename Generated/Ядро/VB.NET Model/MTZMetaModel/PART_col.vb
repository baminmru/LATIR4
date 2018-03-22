
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Разделв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PART_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "PART"
        End Function



''' <summary>
'''Признак древовидного раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function IsTree() As Boolean
            IsTree=true
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
            dt.TableName="PART"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Sequence", Gettype(System.Int32))
            dt.Columns.Add("PartType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("PartType", Gettype(System.string))
            dt.Columns.Add("Caption", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("the_Comment", Gettype(System.string))
            dt.Columns.Add("NoLog_VAL" , Gettype(System.Int16))
            dt.Columns.Add("NoLog", Gettype(System.string))
            dt.Columns.Add("ManualRegister_VAL" , Gettype(System.Int16))
            dt.Columns.Add("ManualRegister", Gettype(System.string))
            dt.Columns.Add("OnCreate_ID" , GetType(System.guid))
            dt.Columns.Add("OnCreate", Gettype(System.string))
            dt.Columns.Add("OnSave_ID" , GetType(System.guid))
            dt.Columns.Add("OnSave", Gettype(System.string))
            dt.Columns.Add("OnRun_ID" , GetType(System.guid))
            dt.Columns.Add("OnRun", Gettype(System.string))
            dt.Columns.Add("OnDelete_ID" , GetType(System.guid))
            dt.Columns.Add("OnDelete", Gettype(System.string))
            dt.Columns.Add("AddBehaivor_VAL" , Gettype(System.Int16))
            dt.Columns.Add("AddBehaivor", Gettype(System.string))
            dt.Columns.Add("ExtenderObject_ID" , GetType(System.guid))
            dt.Columns.Add("ExtenderObject", Gettype(System.string))
            dt.Columns.Add("shablonBrief", Gettype(System.string))
            dt.Columns.Add("ruleBrief", Gettype(System.string))
            dt.Columns.Add("IsJormalChange_VAL" , Gettype(System.Int16))
            dt.Columns.Add("IsJormalChange", Gettype(System.string))
            dt.Columns.Add("UseArchiving_VAL" , Gettype(System.Int16))
            dt.Columns.Add("UseArchiving", Gettype(System.string))
            dt.Columns.Add("integerpkey_VAL" , Gettype(System.Int16))
            dt.Columns.Add("integerpkey", Gettype(System.string))
            dt.Columns.Add("partIconCls", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New PART
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.PART
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.PART))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.PART
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("PARTID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("PARENTROWID") 
           mFieldList =mFieldList+ ", sequence" 
           mFieldList =mFieldList+ ", parttype" 
           mFieldList =mFieldList+ ", caption" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", the_comment" 
           mFieldList =mFieldList+ ", nolog" 
           mFieldList =mFieldList+ ", manualregister" 
           mFieldList =mFieldList+","+.ID2Base("OnCreate") 
           mFieldList =mFieldList+","+.ID2Base("OnSave") 
           mFieldList =mFieldList+","+.ID2Base("OnRun") 
           mFieldList =mFieldList+","+.ID2Base("OnDelete") 
           mFieldList =mFieldList+ ", addbehaivor" 
           mFieldList =mFieldList+","+.ID2Base("ExtenderObject") 
           mFieldList =mFieldList+ ", shablonbrief" 
           mFieldList =mFieldList+ ", rulebrief" 
           mFieldList =mFieldList+ ", isjormalchange" 
           mFieldList =mFieldList+ ", usearchiving" 
           mFieldList =mFieldList+ ", integerpkey" 
           mFieldList =mFieldList+ ", particoncls" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
