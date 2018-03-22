
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZSystem


''' <summary>
'''Реализация строки раздела Журнал событий
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class SysLog
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Ресурс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Resource  as String


''' <summary>
'''Локальная переменная для поля Действие
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_VERB  as String


''' <summary>
'''Локальная переменная для поля Идентификатор документа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_LogInstanceID  as Guid


''' <summary>
'''Локальная переменная для поля Раздел с которым происхоит действие
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_LogStructID  as String


''' <summary>
'''Локальная переменная для поля Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheSession  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_Resource=   
            ' m_VERB=   
            ' m_LogInstanceID=   
            ' m_LogStructID=   
            ' m_TheSession=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 5
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
                    Value = TheSession
                Case 2
                    Value = the_Resource
                Case 3
                    Value = LogStructID
                Case 4
                    Value = VERB
                Case 5
                    Value = LogInstanceID
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
                    TheSession = value
                Case 2
                    the_Resource = value
                Case 3
                    LogStructID = value
                Case 4
                    VERB = value
                Case 5
                    LogInstanceID = value
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
                    Return "TheSession"
                Case 2
                    Return "the_Resource"
                Case 3
                    Return "LogStructID"
                Case 4
                    Return "VERB"
                Case 5
                    Return "LogInstanceID"
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
             if TheSession is nothing then
               dr("TheSession") =system.dbnull.value
               dr("TheSession_ID") =System.Guid.Empty
             else
               dr("TheSession") =TheSession.BRIEF
               dr("TheSession_ID") =TheSession.ID
             end if 
             dr("the_Resource") =the_Resource
             dr("LogStructID") =LogStructID
             dr("VERB") =VERB
             dr("LogInstanceID") =LogInstanceID
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
          if m_TheSession.Equals(System.Guid.Empty) then
            nv.Add("TheSession", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheSession", Application.Session.GetProvider.ID2Param(m_TheSession), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("the_Resource", the_Resource, dbtype.string)
          nv.Add("LogStructID", LogStructID, dbtype.string)
          nv.Add("VERB", VERB, dbtype.string)
          nv.Add("LogInstanceID", LogInstanceID, dbtype.GUID)
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
      If reader.Table.Columns.Contains("TheSession") Then
          if isdbnull(reader.item("TheSession")) then
            If reader.Table.Columns.Contains("TheSession") Then m_TheSession = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheSession") Then m_TheSession= New System.Guid(reader.item("TheSession").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("the_Resource") Then m_the_Resource=reader.item("the_Resource").ToString()
          If reader.Table.Columns.Contains("LogStructID") Then m_LogStructID=reader.item("LogStructID").ToString()
          If reader.Table.Columns.Contains("VERB") Then m_VERB=reader.item("VERB").ToString()
      If reader.Table.Columns.Contains("LogInstanceID") Then
          if isdbnull(reader.item("LogInstanceID")) then
            If reader.Table.Columns.Contains("LogInstanceID") Then m_LogInstanceID = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("LogInstanceID") Then m_LogInstanceID= New System.Guid(reader.item("LogInstanceID").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheSession() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheSession = me.application.Findrowobject("the_Session",m_TheSession)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheSession = Value.id
                else
                   m_TheSession=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ресурс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Resource() As String
            Get
                LoadFromDatabase()
                the_Resource = m_the_Resource
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_Resource = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Раздел с которым происхоит действие
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property LogStructID() As String
            Get
                LoadFromDatabase()
                LogStructID = m_LogStructID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_LogStructID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Действие
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property VERB() As String
            Get
                LoadFromDatabase()
                VERB = m_VERB
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_VERB = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор документа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property LogInstanceID() As Guid
            Get
                LoadFromDatabase()
                LogInstanceID = m_LogInstanceID
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_LogInstanceID = Value
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
            m_TheSession = new system.guid(node.Attributes.GetNamedItem("TheSession").Value)
            the_Resource = node.Attributes.GetNamedItem("the_Resource").Value
            LogStructID = node.Attributes.GetNamedItem("LogStructID").Value
            VERB = node.Attributes.GetNamedItem("VERB").Value
            m_LogInstanceID =new system.guid(node.Attributes.GetNamedItem("LogInstanceID").Value)
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
          node.SetAttribute("TheSession", m_TheSession.tostring)  
          node.SetAttribute("the_Resource", the_Resource)  
          node.SetAttribute("LogStructID", LogStructID)  
          node.SetAttribute("VERB", VERB)  
          node.SetAttribute("LogInstanceID", LogInstanceID.ToString())  
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
