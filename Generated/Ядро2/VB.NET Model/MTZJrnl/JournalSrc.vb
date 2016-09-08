
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZJrnl


''' <summary>
'''Реализация строки раздела Источники журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class JournalSrc
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Псевдоним представления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ViewAlias  as String


''' <summary>
'''Локальная переменная для поля При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnRun  as enumOnJournalRowClick


''' <summary>
'''Локальная переменная для поля Режим открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OpenMode  as String


''' <summary>
'''Локальная переменная для поля Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PartView  as Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ViewAlias=   
            ' m_OnRun=   
            ' m_OpenMode=   
            ' m_PartView=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 4
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
                    Value = PartView
                Case 2
                    Value = OnRun
                Case 3
                    Value = OpenMode
                Case 4
                    Value = ViewAlias
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
                    PartView = value
                Case 2
                    OnRun = value
                Case 3
                    OpenMode = value
                Case 4
                    ViewAlias = value
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
                    Return "PartView"
                Case 2
                    Return "OnRun"
                Case 3
                    Return "OpenMode"
                Case 4
                    Return "ViewAlias"
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
             dr("PartView") =PartView
             select case OnRun
            case enumOnJournalRowClick.OnJournalRowClick_Otkrit__dokument
              dr ("OnRun")  = "Открыть документ"
              dr ("OnRun_VAL")  = 2
            case enumOnJournalRowClick.OnJournalRowClick_Nicego_ne_delat_
              dr ("OnRun")  = "Ничего не делать"
              dr ("OnRun_VAL")  = 0
            case enumOnJournalRowClick.OnJournalRowClick_Otkrit__stroku
              dr ("OnRun")  = "Открыть строку"
              dr ("OnRun_VAL")  = 1
              end select 'OnRun
             dr("OpenMode") =OpenMode
             dr("ViewAlias") =ViewAlias
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
          nv.Add("PartView", PartView, dbtype.GUID)
          nv.Add("OnRun", OnRun, dbtype.int16)
          nv.Add("OpenMode", OpenMode, dbtype.string)
          nv.Add("ViewAlias", ViewAlias, dbtype.string)
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
          If reader.Table.Columns.Contains("PartView") Then m_PartView=reader.item("PartView")
          If reader.Table.Columns.Contains("OnRun") Then m_OnRun=reader.item("OnRun")
          If reader.Table.Columns.Contains("OpenMode") Then m_OpenMode=reader.item("OpenMode").ToString()
          If reader.Table.Columns.Contains("ViewAlias") Then m_ViewAlias=reader.item("ViewAlias").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PartView() As Guid
            Get
                LoadFromDatabase()
                PartView = m_PartView
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_PartView = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnRun() As enumOnJournalRowClick
            Get
                LoadFromDatabase()
                OnRun = m_OnRun
                AccessTime = Now
            End Get
            Set(ByVal Value As enumOnJournalRowClick )
                LoadFromDatabase()
                m_OnRun = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Режим открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OpenMode() As String
            Get
                LoadFromDatabase()
                OpenMode = m_OpenMode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_OpenMode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Псевдоним представления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ViewAlias() As String
            Get
                LoadFromDatabase()
                ViewAlias = m_ViewAlias
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ViewAlias = Value
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
            m_PartView =new system.guid(node.Attributes.GetNamedItem("PartView").Value)
            OnRun = node.Attributes.GetNamedItem("OnRun").Value
            OpenMode = node.Attributes.GetNamedItem("OpenMode").Value
            ViewAlias = node.Attributes.GetNamedItem("ViewAlias").Value
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
          node.SetAttribute("PartView", PartView.ToString())  
          node.SetAttribute("OnRun", OnRun)  
          node.SetAttribute("OpenMode", OpenMode)  
          node.SetAttribute("ViewAlias", ViewAlias)  
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
