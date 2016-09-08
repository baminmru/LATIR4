
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace MTZRprt


''' <summary>
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Reports
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Метод для формирования
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PrepareMethod  as System.Guid


''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Тип отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReportType  as enumReportType


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Файл отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReportFile  as Object


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Базовый запрос
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReportView  as String


''' <summary>
'''Локальная переменная для поля Расширение для создания отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheReportExt  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_PrepareMethod=   
            ' m_Caption=   
            ' m_ReportType=   
            ' m_TheComment=   
            ' m_ReportFile=   
            ' m_Name=   
            ' m_ReportView=   
            ' m_TheReportExt=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 8
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
                    Value = Name
                Case 2
                    Value = ReportFile
                Case 3
                    Value = Caption
                Case 4
                    Value = PrepareMethod
                Case 5
                    Value = ReportType
                Case 6
                    Value = TheReportExt
                Case 7
                    Value = ReportView
                Case 8
                    Value = TheComment
            End Select
        else
        On Error Resume Next
        Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
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
                    Name = value
                Case 2
                    ReportFile = value
                Case 3
                    Caption = value
                Case 4
                    PrepareMethod = value
                Case 5
                    ReportType = value
                Case 6
                    TheReportExt = value
                Case 7
                    ReportView = value
                Case 8
                    TheComment = value
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
                    Return "Name"
                Case 2
                    Return "ReportFile"
                Case 3
                    Return "Caption"
                Case 4
                    Return "PrepareMethod"
                Case 5
                    Return "ReportType"
                Case 6
                    Return "TheReportExt"
                Case 7
                    Return "ReportView"
                Case 8
                    Return "TheComment"
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
            on error resume next
            dr("ID") =ID
            dr("Brief") =Brief
             dr("Name") =Name
             dr("ReportFile") =ReportFile
             dr("Caption") =Caption
             if PrepareMethod is nothing then
               dr("PrepareMethod") =system.dbnull.value
               dr("PrepareMethod_ID") =System.Guid.Empty
             else
               dr("PrepareMethod") =PrepareMethod.BRIEF
               dr("PrepareMethod_ID") =PrepareMethod.ID
             end if 
             select case ReportType
            case enumReportType.ReportType_Eksport_po_Excel_sablonu
              dr ("ReportType")  = "Экспорт по Excel шаблону"
              dr ("ReportType_VAL")  = 4
            case enumReportType.ReportType_Tablica
              dr ("ReportType")  = "Таблица"
              dr ("ReportType_VAL")  = 0
            case enumReportType.ReportType_Eksport_po_WORD_sablonu
              dr ("ReportType")  = "Экспорт по WORD шаблону"
              dr ("ReportType_VAL")  = 3
            case enumReportType.ReportType_Dvumernay_matrica
              dr ("ReportType")  = "Двумерная матрица"
              dr ("ReportType_VAL")  = 1
            case enumReportType.ReportType_Tol_ko_rascet
              dr ("ReportType")  = "Только расчет"
              dr ("ReportType_VAL")  = 2
              end select 'ReportType
             if TheReportExt is nothing then
               dr("TheReportExt") =system.dbnull.value
               dr("TheReportExt_ID") =System.Guid.Empty
             else
               dr("TheReportExt") =TheReportExt.BRIEF
               dr("TheReportExt_ID") =TheReportExt.ID
             end if 
             dr("ReportView") =ReportView
             dr("TheComment") =TheComment
            DestDataTable.Rows.Add (dr)
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
          nv.Add("Name", Name, dbtype.string)
          nv.Add("ReportFile", ReportFile, dbtype.Binary)
          nv.Add("Caption", Caption, dbtype.string)
          if m_PrepareMethod.Equals(System.Guid.Empty) then
            nv.Add("PrepareMethod", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("PrepareMethod", Application.Session.GetProvider.ID2Param(m_PrepareMethod), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("ReportType", ReportType, dbtype.int16)
          if m_TheReportExt.Equals(System.Guid.Empty) then
            nv.Add("TheReportExt", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheReportExt", Application.Session.GetProvider.ID2Param(m_TheReportExt), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("ReportView", ReportView, dbtype.string)
          nv.Add("TheComment", TheComment, dbtype.string)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            on error resume next  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("ReportFile") Then m_ReportFile=reader.item("ReportFile")
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
      If reader.Table.Columns.Contains("PrepareMethod") Then
          if isdbnull(reader.item("PrepareMethod")) then
            If reader.Table.Columns.Contains("PrepareMethod") Then m_PrepareMethod = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("PrepareMethod") Then m_PrepareMethod= New System.Guid(reader.item("PrepareMethod").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("ReportType") Then m_ReportType=reader.item("ReportType")
      If reader.Table.Columns.Contains("TheReportExt") Then
          if isdbnull(reader.item("TheReportExt")) then
            If reader.Table.Columns.Contains("TheReportExt") Then m_TheReportExt = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheReportExt") Then m_TheReportExt= New System.Guid(reader.item("TheReportExt").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("ReportView") Then m_ReportView=reader.item("ReportView").ToString()
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
        End Sub


''' <summary>
'''Доступ к полю Название
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Name() As String
            Get
                LoadFromDatabase()
                Name = m_Name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Name = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Файл отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReportFile() As Object
            Get
                LoadFromDatabase()
                ReportFile = m_ReportFile
                AccessTime = Now
            End Get
            Set(ByVal Value As Object )
                LoadFromDatabase()
                m_ReportFile = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Caption() As String
            Get
                LoadFromDatabase()
                Caption = m_Caption
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Caption = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Метод для формирования
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PrepareMethod() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                PrepareMethod = me.application.Findrowobject("SHAREDMETHOD",m_PrepareMethod)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_PrepareMethod = Value.id
                else
                   m_PrepareMethod=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReportType() As enumReportType
            Get
                LoadFromDatabase()
                ReportType = m_ReportType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumReportType )
                LoadFromDatabase()
                m_ReportType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расширение для создания отчета
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheReportExt() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                TheReportExt = me.application.manager.GetInstanceObject(m_TheReportExt)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_TheReportExt = Value.id
                else
                  m_TheReportExt =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Базовый запрос
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReportView() As String
            Get
                LoadFromDatabase()
                ReportView = m_ReportView
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ReportView = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheComment() As STRING
            Get
                LoadFromDatabase()
                TheComment = m_TheComment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_TheComment = Value
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
          on error resume next  
            Name = node.Attributes.GetNamedItem("Name").Value
            ReportFile = System.Convert.FromBase64String(node.Attributes.GetNamedItem("ReportFile").Value.ToString())
            Caption = node.Attributes.GetNamedItem("Caption").Value
            m_PrepareMethod = new system.guid(node.Attributes.GetNamedItem("PrepareMethod").Value)
            ReportType = node.Attributes.GetNamedItem("ReportType").Value
            m_TheReportExt = new system.guid(node.Attributes.GetNamedItem("TheReportExt").Value)
            ReportView = node.Attributes.GetNamedItem("ReportView").Value
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
             Changed = true
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
           on error resume next  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("ReportFile", System.Convert.ToBase64String(ReportFile))  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("PrepareMethod", m_PrepareMethod.tostring)  
          node.SetAttribute("ReportType", ReportType)  
          node.SetAttribute("TheReportExt", m_TheReportExt.tostring)  
          node.SetAttribute("ReportView", ReportView)  
          node.SetAttribute("TheComment", TheComment)  
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
