
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация раздела Генераторыв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class GENERATOR_TARGET_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "GENERATOR_TARGET"
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
            dt.TableName="GENERATOR_TARGET"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("Name", Gettype(System.string))
            dt.Columns.Add("TargetType_VAL" , Gettype(System.Int16))
            dt.Columns.Add("TargetType", Gettype(System.string))
            dt.Columns.Add("QueueName", Gettype(System.string))
            dt.Columns.Add("GeneratorProgID", Gettype(System.string))
            dt.Columns.Add("GeneratorStyle_VAL" , Gettype(System.Int16))
            dt.Columns.Add("GeneratorStyle", Gettype(System.string))
            dt.Columns.Add("TheDevelopmentEnv_VAL" , Gettype(System.Int16))
            dt.Columns.Add("TheDevelopmentEnv", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New GENERATOR_TARGET
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As MTZMetaModel.GENERATOR_TARGET
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(MTZMetaModel.GENERATOR_TARGET))
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
        Public Shadows Function Item( vIndex as object ) As MTZMetaModel.GENERATOR_TARGET
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("GENERATOR_TARGETID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", targettype" 
           mFieldList =mFieldList+ ", queuename" 
           mFieldList =mFieldList+ ", generatorprogid" 
           mFieldList =mFieldList+ ", generatorstyle" 
           mFieldList =mFieldList+ ", thedevelopmentenv" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
