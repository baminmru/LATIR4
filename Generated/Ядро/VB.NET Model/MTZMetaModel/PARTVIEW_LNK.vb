
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
'''Реализация строки раздела Связанные представления
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTVIEW_LNK
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Свзяь: Поле для join приемник
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheJoinDestination  as System.Guid


''' <summary>
'''Локальная переменная для поля Ручной join
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HandJoin  as String


''' <summary>
'''Локальная переменная для поля Порядок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SEQ  as long


''' <summary>
'''Локальная переменная для поля Связь: Поле для join источник
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheJoinSource  as System.Guid


''' <summary>
'''Локальная переменная для поля Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheView  as System.Guid


''' <summary>
'''Локальная переменная для поля Связывать как
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefType  as enumJournalLinkType



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheJoinDestination=   
            ' m_HandJoin=   
            ' m_SEQ=   
            ' m_TheJoinSource=   
            ' m_TheView=   
            ' m_RefType=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 6
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
                    Value = TheView
                Case 2
                    Value = TheJoinSource
                Case 3
                    Value = RefType
                Case 4
                    Value = TheJoinDestination
                Case 5
                    Value = HandJoin
                Case 6
                    Value = SEQ
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
                    TheView = value
                Case 2
                    TheJoinSource = value
                Case 3
                    RefType = value
                Case 4
                    TheJoinDestination = value
                Case 5
                    HandJoin = value
                Case 6
                    SEQ = value
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
                    Return "TheView"
                Case 2
                    Return "TheJoinSource"
                Case 3
                    Return "RefType"
                Case 4
                    Return "TheJoinDestination"
                Case 5
                    Return "HandJoin"
                Case 6
                    Return "SEQ"
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
             if TheView is nothing then
               dr("TheView") =system.dbnull.value
               dr("TheView_ID") =System.Guid.Empty
             else
               dr("TheView") =TheView.BRIEF
               dr("TheView_ID") =TheView.ID
             end if 
             if TheJoinSource is nothing then
               dr("TheJoinSource") =system.dbnull.value
               dr("TheJoinSource_ID") =System.Guid.Empty
             else
               dr("TheJoinSource") =TheJoinSource.BRIEF
               dr("TheJoinSource_ID") =TheJoinSource.ID
             end if 
             select case RefType
            case enumJournalLinkType.JournalLinkType_Net
              dr ("RefType")  = "Нет"
              dr ("RefType_VAL")  = 0
            case enumJournalLinkType.JournalLinkType_Svyzka_ParentStructRowID__OPNv_peredlah_ob_ektaCLS
              dr ("RefType")  = "Связка ParentStructRowID  (в передлах объекта)"
              dr ("RefType_VAL")  = 4
            case enumJournalLinkType.JournalLinkType_Svyzka_InstanceID_OPNv_peredlah_ob_ektaCLS
              dr ("RefType")  = "Связка InstanceID (в передлах объекта)"
              dr ("RefType_VAL")  = 3
            case enumJournalLinkType.JournalLinkType_Ssilka_na_ob_ekt
              dr ("RefType")  = "Ссылка на объект"
              dr ("RefType_VAL")  = 1
            case enumJournalLinkType.JournalLinkType_Ssilka_na_stroku
              dr ("RefType")  = "Ссылка на строку"
              dr ("RefType_VAL")  = 2
              end select 'RefType
             if TheJoinDestination is nothing then
               dr("TheJoinDestination") =system.dbnull.value
               dr("TheJoinDestination_ID") =System.Guid.Empty
             else
               dr("TheJoinDestination") =TheJoinDestination.BRIEF
               dr("TheJoinDestination_ID") =TheJoinDestination.ID
             end if 
             dr("HandJoin") =HandJoin
             dr("SEQ") =SEQ
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
          if m_TheView.Equals(System.Guid.Empty) then
            nv.Add("TheView", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheView", Application.Session.GetProvider.ID2Param(m_TheView), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_TheJoinSource.Equals(System.Guid.Empty) then
            nv.Add("TheJoinSource", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheJoinSource", Application.Session.GetProvider.ID2Param(m_TheJoinSource), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("RefType", RefType, dbtype.int16)
          if m_TheJoinDestination.Equals(System.Guid.Empty) then
            nv.Add("TheJoinDestination", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheJoinDestination", Application.Session.GetProvider.ID2Param(m_TheJoinDestination), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("HandJoin", HandJoin, dbtype.string)
          nv.Add("SEQ", SEQ, dbtype.Int32)
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
      If reader.Table.Columns.Contains("TheView") Then
          if isdbnull(reader.item("TheView")) then
            If reader.Table.Columns.Contains("TheView") Then m_TheView = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheView") Then m_TheView= New System.Guid(reader.item("TheView").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("TheJoinSource") Then
          if isdbnull(reader.item("TheJoinSource")) then
            If reader.Table.Columns.Contains("TheJoinSource") Then m_TheJoinSource = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheJoinSource") Then m_TheJoinSource= New System.Guid(reader.item("TheJoinSource").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("RefType") Then m_RefType=reader.item("RefType")
      If reader.Table.Columns.Contains("TheJoinDestination") Then
          if isdbnull(reader.item("TheJoinDestination")) then
            If reader.Table.Columns.Contains("TheJoinDestination") Then m_TheJoinDestination = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheJoinDestination") Then m_TheJoinDestination= New System.Guid(reader.item("TheJoinDestination").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("HandJoin") Then m_HandJoin=reader.item("HandJoin").ToString()
          If reader.Table.Columns.Contains("SEQ") Then m_SEQ=reader.item("SEQ")
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
        Public Property TheView() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheView = me.application.Findrowobject("PARTVIEW",m_TheView)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheView = Value.id
                else
                   m_TheView=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Связь: Поле для join источник
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheJoinSource() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheJoinSource = me.application.Findrowobject("ViewColumn",m_TheJoinSource)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheJoinSource = Value.id
                else
                   m_TheJoinSource=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Связывать как
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefType() As enumJournalLinkType
            Get
                LoadFromDatabase()
                RefType = m_RefType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumJournalLinkType )
                LoadFromDatabase()
                m_RefType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Свзяь: Поле для join приемник
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheJoinDestination() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheJoinDestination = me.application.Findrowobject("ViewColumn",m_TheJoinDestination)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheJoinDestination = Value.id
                else
                   m_TheJoinDestination=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ручной join
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HandJoin() As String
            Get
                LoadFromDatabase()
                HandJoin = m_HandJoin
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HandJoin = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Порядок
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SEQ() As long
            Get
                LoadFromDatabase()
                SEQ = m_SEQ
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_SEQ = Value
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
            m_TheView = new system.guid(node.Attributes.GetNamedItem("TheView").Value)
            m_TheJoinSource = new system.guid(node.Attributes.GetNamedItem("TheJoinSource").Value)
            RefType = node.Attributes.GetNamedItem("RefType").Value
            m_TheJoinDestination = new system.guid(node.Attributes.GetNamedItem("TheJoinDestination").Value)
            HandJoin = node.Attributes.GetNamedItem("HandJoin").Value
            SEQ = node.Attributes.GetNamedItem("SEQ").Value
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
          node.SetAttribute("TheView", m_TheView.tostring)  
          node.SetAttribute("TheJoinSource", m_TheJoinSource.tostring)  
          node.SetAttribute("RefType", RefType)  
          node.SetAttribute("TheJoinDestination", m_TheJoinDestination.tostring)  
          node.SetAttribute("HandJoin", HandJoin)  
          node.SetAttribute("SEQ", SEQ)  
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
