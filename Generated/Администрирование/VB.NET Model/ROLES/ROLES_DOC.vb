
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация строки раздела Доступные документы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_DOC
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Разрешено удаление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowDeleteDoc  as enumBoolean


''' <summary>
'''Локальная переменная для поля Запрещен
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_The_Denied  as enumYesNo


''' <summary>
'''Локальная переменная для поля Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_The_Document  as System.Guid


''' <summary>
'''Локальная переменная для дочернего раздела Доступные состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ROLES_DOC_STATE As ROLES_DOC_STATE_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_AllowDeleteDoc=   
            ' m_The_Denied=   
            ' m_The_Document=   
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
                    Value = The_Document
                Case 2
                    Value = The_Denied
                Case 3
                    Value = AllowDeleteDoc
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
                    The_Document = value
                Case 2
                    The_Denied = value
                Case 3
                    AllowDeleteDoc = value
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
                    Return "The_Document"
                Case 2
                    Return "The_Denied"
                Case 3
                    Return "AllowDeleteDoc"
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
             if The_Document is nothing then
               dr("The_Document") =system.dbnull.value
               dr("The_Document_ID") =System.Guid.Empty
             else
               dr("The_Document") =The_Document.BRIEF
               dr("The_Document_ID") =The_Document.ID
             end if 
             select case The_Denied
            case enumYesNo.YesNo_Da
              dr ("The_Denied")  = "Да"
              dr ("The_Denied_VAL")  = 1
            case enumYesNo.YesNo_Net
              dr ("The_Denied")  = "Нет"
              dr ("The_Denied_VAL")  = 0
              end select 'The_Denied
             select case AllowDeleteDoc
            case enumBoolean.Boolean_Da
              dr ("AllowDeleteDoc")  = "Да"
              dr ("AllowDeleteDoc_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowDeleteDoc")  = "Нет"
              dr ("AllowDeleteDoc_VAL")  = 0
              end select 'AllowDeleteDoc
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
            mFindInside = ROLES_DOC_STATE.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          if m_The_Document.Equals(System.Guid.Empty) then
            nv.Add("The_Document", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("The_Document", Application.Session.GetProvider.ID2Param(m_The_Document), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("The_Denied", The_Denied, dbtype.int16)
          nv.Add("AllowDeleteDoc", AllowDeleteDoc, dbtype.int16)
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
      If reader.Table.Columns.Contains("The_Document") Then
          if isdbnull(reader.item("The_Document")) then
            If reader.Table.Columns.Contains("The_Document") Then m_The_Document = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("The_Document") Then m_The_Document= New System.Guid(reader.item("The_Document").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("The_Denied") Then m_The_Denied=reader.item("The_Denied")
          If reader.Table.Columns.Contains("AllowDeleteDoc") Then m_AllowDeleteDoc=reader.item("AllowDeleteDoc")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property The_Document() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                The_Document = me.application.Findrowobject("OBJECTTYPE",m_The_Document)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_The_Document = Value.id
                else
                   m_The_Document=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запрещен
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property The_Denied() As enumYesNo
            Get
                LoadFromDatabase()
                The_Denied = m_The_Denied
                AccessTime = Now
            End Get
            Set(ByVal Value As enumYesNo )
                LoadFromDatabase()
                m_The_Denied = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешено удаление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowDeleteDoc() As enumBoolean
            Get
                LoadFromDatabase()
                AllowDeleteDoc = m_AllowDeleteDoc
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowDeleteDoc = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Доступные состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ROLES_DOC_STATE() As ROLES_DOC_STATE_col
            Get
                if  m_ROLES_DOC_STATE is nothing then
                  m_ROLES_DOC_STATE = new ROLES_DOC_STATE_col
                  m_ROLES_DOC_STATE.Parent = me
                  m_ROLES_DOC_STATE.Application = me.Application
                  m_ROLES_DOC_STATE.Refresh
                end if
                ROLES_DOC_STATE = m_ROLES_DOC_STATE
                AccessTime = Now
            End Get
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
            m_The_Document = new system.guid(node.Attributes.GetNamedItem("The_Document").Value)
            The_Denied = node.Attributes.GetNamedItem("The_Denied").Value
            AllowDeleteDoc = node.Attributes.GetNamedItem("AllowDeleteDoc").Value
            e_list = node.SelectNodes("ROLES_DOC_STATE_COL")
            ROLES_DOC_STATE.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            ROLES_DOC_STATE.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("The_Document", m_The_Document.tostring)  
          node.SetAttribute("The_Denied", The_Denied)  
          node.SetAttribute("AllowDeleteDoc", AllowDeleteDoc)  
            ROLES_DOC_STATE.XMLSave(node,xdom)
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
            ROLES_DOC_STATE.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 1
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
         Case 1
            return ROLES_DOC_STATE
            End Select
            return nothing
        End Function
    End Class
End Namespace
