
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZMetaModel


''' <summary>
'''Реализация строки раздела Отображение параметров
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTPARAMMAP
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ParamName  as String


''' <summary>
'''Локальная переменная для поля Поле (значение)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FieldName  as String


''' <summary>
'''Локальная переменная для поля Редактировать параметр нельзя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NoEdit  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ParamName=   
            ' m_FieldName=   
            ' m_NoEdit=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 3
        End Get
    End Property



''' <summary>
'''Получить \Задать поле по номеру 
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Property Value(ByVal Index As Object) As Object
    Get
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                    Value = ID
                Case 1
                    Value = FieldName
                Case 2
                    Value = ParamName
                Case 3
                    Value = NoEdit
            End Select
        else
        try
          Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
              Value=nothing
          end try
        End If
    End Get
    Set(ByVal value As Object)
    If Microsoft.VisualBasic.IsNumeric(Index) Then
        Dim l As Long
        l = CLng(Index)
        Select Case l
            Case 0
                 ID=value
                Case 1
                    FieldName = value
                Case 2
                    ParamName = value
                Case 3
                    NoEdit = value
        End Select
     Else
        Try
            Try
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)
            Catch ex As Exception
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)
            End Try
        Catch ex As Exception
        End Try
     End If
  End Set

End Property



''' <summary>
'''Название поля по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Function FieldNameByID(ByVal Index As long) As String
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                   Return "ID"
                Case 1
                    Return "FieldName"
                Case 2
                    Return "ParamName"
                Case 3
                    Return "NoEdit"
                Case else
                return "" 
            End Select
        End If
        return "" 
End Function



''' <summary>
'''Заполнить строку таблицы данными из полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)
            Dim dr As  DataRow
            dr = destdatatable.NewRow
            try
            dr("ID") =ID
            dr("Brief") =Brief
             dr("FieldName") =FieldName
             dr("ParamName") =ParamName
             select case NoEdit
            case enumBoolean.Boolean_Da
              dr ("NoEdit")  = "Да"
              dr ("NoEdit_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("NoEdit")  = "Нет"
              dr ("NoEdit_VAL")  = 0
              end select 'NoEdit
            DestDataTable.Rows.Add (dr)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub



''' <summary>
'''Найти строку в коллекции по идентификатору
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base
            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          nv.Add("FieldName", FieldName, dbtype.string)
          nv.Add("ParamName", ParamName, dbtype.string)
          nv.Add("NoEdit", NoEdit, dbtype.int16)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            try  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
          If reader.Table.Columns.Contains("FieldName") Then m_FieldName=reader.item("FieldName").ToString()
          If reader.Table.Columns.Contains("ParamName") Then m_ParamName=reader.item("ParamName").ToString()
          If reader.Table.Columns.Contains("NoEdit") Then m_NoEdit=reader.item("NoEdit")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Поле (значение)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FieldName() As String
            Get
                LoadFromDatabase()
                FieldName = m_FieldName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FieldName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Параметр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ParamName() As String
            Get
                LoadFromDatabase()
                ParamName = m_ParamName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ParamName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Редактировать параметр нельзя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NoEdit() As enumBoolean
            Get
                LoadFromDatabase()
                NoEdit = m_NoEdit
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_NoEdit = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Заполнить поля данными из XML
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
          Dim e_list As XmlNodeList
          try 
            FieldName = node.Attributes.GetNamedItem("FieldName").Value
            ParamName = node.Attributes.GetNamedItem("ParamName").Value
            NoEdit = node.Attributes.GetNamedItem("NoEdit").Value
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("FieldName", FieldName)  
          node.SetAttribute("ParamName", ParamName)  
          node.SetAttribute("NoEdit", NoEdit)  
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub


''' <summary>
'''Записать изменения в базу данных
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Sub BatchUpdate()
  If Deleted Then
    Delete
    Exit Sub
  End If
  If Changed Then Save
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property



''' <summary>
'''Доступ к дочернему разделу по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base
            Select Case Index
            End Select
            return nothing
        End Function
    End Class
End Namespace
