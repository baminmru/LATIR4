
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
'''Реализация строки раздела Описание источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDSRCDEF
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Строка соединения с источником
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ConnectionString  as String


''' <summary>
'''Локальная переменная для поля Примечания
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DescriptionString  as STRING


''' <summary>
'''Локальная переменная для поля Сортировка источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SortField  as String


''' <summary>
'''Локальная переменная для поля Провайдер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Provider  as String


''' <summary>
'''Локальная переменная для поля Фильтр источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FilterString  as String


''' <summary>
'''Локальная переменная для поля Источник данных
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DataSource  as String


''' <summary>
'''Локальная переменная для поля Не показывать форму выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DontShowDialog  as enumYesNo


''' <summary>
'''Локальная переменная для поля Источник краткой информации
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_BriefString  as String


''' <summary>
'''Локальная переменная для поля ID
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IDField  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ConnectionString=   
            ' m_DescriptionString=   
            ' m_SortField=   
            ' m_Provider=   
            ' m_FilterString=   
            ' m_DataSource=   
            ' m_DontShowDialog=   
            ' m_BriefString=   
            ' m_IDField=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 9
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
                    Value = Provider
                Case 2
                    Value = ConnectionString
                Case 3
                    Value = DataSource
                Case 4
                    Value = IDField
                Case 5
                    Value = BriefString
                Case 6
                    Value = FilterString
                Case 7
                    Value = SortField
                Case 8
                    Value = DescriptionString
                Case 9
                    Value = DontShowDialog
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
                    Provider = value
                Case 2
                    ConnectionString = value
                Case 3
                    DataSource = value
                Case 4
                    IDField = value
                Case 5
                    BriefString = value
                Case 6
                    FilterString = value
                Case 7
                    SortField = value
                Case 8
                    DescriptionString = value
                Case 9
                    DontShowDialog = value
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
                    Return "Provider"
                Case 2
                    Return "ConnectionString"
                Case 3
                    Return "DataSource"
                Case 4
                    Return "IDField"
                Case 5
                    Return "BriefString"
                Case 6
                    Return "FilterString"
                Case 7
                    Return "SortField"
                Case 8
                    Return "DescriptionString"
                Case 9
                    Return "DontShowDialog"
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
             dr("Provider") =Provider
             dr("ConnectionString") =ConnectionString
             dr("DataSource") =DataSource
             dr("IDField") =IDField
             dr("BriefString") =BriefString
             dr("FilterString") =FilterString
             dr("SortField") =SortField
             dr("DescriptionString") =DescriptionString
             select case DontShowDialog
            case enumYesNo.YesNo_Da
              dr ("DontShowDialog")  = "Да"
              dr ("DontShowDialog_VAL")  = 1
            case enumYesNo.YesNo_Net
              dr ("DontShowDialog")  = "Нет"
              dr ("DontShowDialog_VAL")  = 0
              end select 'DontShowDialog
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
          nv.Add("Provider", Provider, dbtype.string)
          nv.Add("ConnectionString", ConnectionString, dbtype.string)
          nv.Add("DataSource", DataSource, dbtype.string)
          nv.Add("IDField", IDField, dbtype.string)
          nv.Add("BriefString", BriefString, dbtype.string)
          nv.Add("FilterString", FilterString, dbtype.string)
          nv.Add("SortField", SortField, dbtype.string)
          nv.Add("DescriptionString", DescriptionString, dbtype.string)
          nv.Add("DontShowDialog", DontShowDialog, dbtype.int16)
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
          If reader.Table.Columns.Contains("Provider") Then m_Provider=reader.item("Provider").ToString()
          If reader.Table.Columns.Contains("ConnectionString") Then m_ConnectionString=reader.item("ConnectionString").ToString()
          If reader.Table.Columns.Contains("DataSource") Then m_DataSource=reader.item("DataSource").ToString()
          If reader.Table.Columns.Contains("IDField") Then m_IDField=reader.item("IDField").ToString()
          If reader.Table.Columns.Contains("BriefString") Then m_BriefString=reader.item("BriefString").ToString()
          If reader.Table.Columns.Contains("FilterString") Then m_FilterString=reader.item("FilterString").ToString()
          If reader.Table.Columns.Contains("SortField") Then m_SortField=reader.item("SortField").ToString()
          If reader.Table.Columns.Contains("DescriptionString") Then m_DescriptionString=reader.item("DescriptionString").ToString()
          If reader.Table.Columns.Contains("DontShowDialog") Then m_DontShowDialog=reader.item("DontShowDialog")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Провайдер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Provider() As String
            Get
                LoadFromDatabase()
                Provider = m_Provider
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Provider = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Строка соединения с источником
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ConnectionString() As String
            Get
                LoadFromDatabase()
                ConnectionString = m_ConnectionString
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ConnectionString = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Источник данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DataSource() As String
            Get
                LoadFromDatabase()
                DataSource = m_DataSource
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_DataSource = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю ID
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IDField() As String
            Get
                LoadFromDatabase()
                IDField = m_IDField
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_IDField = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Источник краткой информации
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property BriefString() As String
            Get
                LoadFromDatabase()
                BriefString = m_BriefString
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_BriefString = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фильтр источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FilterString() As String
            Get
                LoadFromDatabase()
                FilterString = m_FilterString
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FilterString = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сортировка источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SortField() As String
            Get
                LoadFromDatabase()
                SortField = m_SortField
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_SortField = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Примечания
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DescriptionString() As STRING
            Get
                LoadFromDatabase()
                DescriptionString = m_DescriptionString
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_DescriptionString = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Не показывать форму выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DontShowDialog() As enumYesNo
            Get
                LoadFromDatabase()
                DontShowDialog = m_DontShowDialog
                AccessTime = Now
            End Get
            Set(ByVal Value As enumYesNo )
                LoadFromDatabase()
                m_DontShowDialog = Value
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
            Provider = node.Attributes.GetNamedItem("Provider").Value
            ConnectionString = node.Attributes.GetNamedItem("ConnectionString").Value
            DataSource = node.Attributes.GetNamedItem("DataSource").Value
            IDField = node.Attributes.GetNamedItem("IDField").Value
            BriefString = node.Attributes.GetNamedItem("BriefString").Value
            FilterString = node.Attributes.GetNamedItem("FilterString").Value
            SortField = node.Attributes.GetNamedItem("SortField").Value
            DescriptionString = node.Attributes.GetNamedItem("DescriptionString").Value
            DontShowDialog = node.Attributes.GetNamedItem("DontShowDialog").Value
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
          node.SetAttribute("Provider", Provider)  
          node.SetAttribute("ConnectionString", ConnectionString)  
          node.SetAttribute("DataSource", DataSource)  
          node.SetAttribute("IDField", IDField)  
          node.SetAttribute("BriefString", BriefString)  
          node.SetAttribute("FilterString", FilterString)  
          node.SetAttribute("SortField", SortField)  
          node.SetAttribute("DescriptionString", DescriptionString)  
          node.SetAttribute("DontShowDialog", DontShowDialog)  
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
