
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace mtzjrnl


''' <summary>
'''Реализация строки раздела Источники журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class journalsrc
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_spartview  as String


''' <summary>
'''Локальная переменная для поля При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_onrun  as enumOnJournalRowClick


''' <summary>
'''Локальная переменная для поля Режим открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_openmode  as String


''' <summary>
'''Локальная переменная для поля Псевдоним представления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_viewalias  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_spartview=   
            ' m_onrun=   
            ' m_openmode=   
            ' m_viewalias=   
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
                    Value = spartview
                Case 2
                    Value = onrun
                Case 3
                    Value = openmode
                Case 4
                    Value = viewalias
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
                    spartview = value
                Case 2
                    onrun = value
                Case 3
                    openmode = value
                Case 4
                    viewalias = value
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
                    Return "spartview"
                Case 2
                    Return "onrun"
                Case 3
                    Return "openmode"
                Case 4
                    Return "viewalias"
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
             dr("spartview") =spartview
             select case onrun
            case enumOnJournalRowClick.OnJournalRowClick_Otkrit__dokument
              dr ("onrun")  = "Открыть документ"
              dr ("onrun_VAL")  = 2
            case enumOnJournalRowClick.OnJournalRowClick_Nicego_ne_delat_
              dr ("onrun")  = "Ничего не делать"
              dr ("onrun_VAL")  = 0
            case enumOnJournalRowClick.OnJournalRowClick_Otkrit__stroku
              dr ("onrun")  = "Открыть строку"
              dr ("onrun_VAL")  = 1
              end select 'onrun
             dr("openmode") =openmode
             dr("viewalias") =viewalias
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
          nv.Add("spartview", spartview, dbtype.string)
          nv.Add("onrun", onrun, dbtype.int16)
          nv.Add("openmode", openmode, dbtype.string)
          nv.Add("viewalias", viewalias, dbtype.string)
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
          If reader.Table.Columns.Contains("spartview") Then m_spartview=reader.item("spartview").ToString()
          If reader.Table.Columns.Contains("onrun") Then m_onrun=reader.item("onrun")
          If reader.Table.Columns.Contains("openmode") Then m_openmode=reader.item("openmode").ToString()
          If reader.Table.Columns.Contains("viewalias") Then m_viewalias=reader.item("viewalias").ToString()
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
        Public Property spartview() As String
            Get
                LoadFromDatabase()
                spartview = m_spartview
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_spartview = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property onrun() As enumOnJournalRowClick
            Get
                LoadFromDatabase()
                onrun = m_onrun
                AccessTime = Now
            End Get
            Set(ByVal Value As enumOnJournalRowClick )
                LoadFromDatabase()
                m_onrun = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Режим открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property openmode() As String
            Get
                LoadFromDatabase()
                openmode = m_openmode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_openmode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Псевдоним представления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property viewalias() As String
            Get
                LoadFromDatabase()
                viewalias = m_viewalias
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_viewalias = Value
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
            spartview = node.Attributes.GetNamedItem("spartview").Value
            onrun = node.Attributes.GetNamedItem("onrun").Value
            openmode = node.Attributes.GetNamedItem("openmode").Value
            viewalias = node.Attributes.GetNamedItem("viewalias").Value
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
          node.SetAttribute("spartview", spartview)  
          node.SetAttribute("onrun", onrun)  
          node.SetAttribute("openmode", openmode)  
          node.SetAttribute("viewalias", viewalias)  
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
