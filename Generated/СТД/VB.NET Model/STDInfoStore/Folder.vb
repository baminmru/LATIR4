
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace STDInfoStore


''' <summary>
'''Реализация строки раздела Папка
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Folder
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип папки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FolderType  as enumFolderType


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для дочернего раздела Документы
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_Shortcut As Shortcut_col


''' <summary>
'''Локальная переменная для дочерних записей раздела Папка
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_Folder As Folder_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_FolderType=   
            ' m_Name=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 2
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
                    Value = FolderType
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
                    FolderType = value
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
                    Return "FolderType"
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
             select case FolderType
            case enumFolderType.FolderType_Udalennie
              dr ("FolderType")  = "Удаленные"
              dr ("FolderType_VAL")  = 3
            case enumFolderType.FolderType_Vhodysie
              dr ("FolderType")  = "Входящие"
              dr ("FolderType_VAL")  = 1
            case enumFolderType.FolderType_Otlogennie
              dr ("FolderType")  = "Отложенные"
              dr ("FolderType_VAL")  = 9
            case enumFolderType.FolderType_Gurnal
              dr ("FolderType")  = "Журнал"
              dr ("FolderType_VAL")  = 4
            case enumFolderType.FolderType_Ishodysie
              dr ("FolderType")  = "Исходящие"
              dr ("FolderType_VAL")  = 2
            case enumFolderType.FolderType_Cernoviki
              dr ("FolderType")  = "Черновики"
              dr ("FolderType_VAL")  = 7
            case enumFolderType.FolderType_Otpravlennie
              dr ("FolderType")  = "Отправленные"
              dr ("FolderType_VAL")  = 6
            case enumFolderType.FolderType_V_rabote
              dr ("FolderType")  = "В работе"
              dr ("FolderType_VAL")  = 8
            case enumFolderType.FolderType_Kalendar_
              dr ("FolderType")  = "Календарь"
              dr ("FolderType_VAL")  = 5
            case enumFolderType.FolderType_Zaversennie
              dr ("FolderType")  = "Завершенные"
              dr ("FolderType_VAL")  = 10
            case enumFolderType.FolderType_cls__
              dr ("FolderType")  = "cls__"
              dr ("FolderType_VAL")  = 0
              end select 'FolderType
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
            mFindInside = Folder.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = Shortcut.FindObject(table,RowID)
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
        If Me.Parent.Parent.GetType.name = Me.GetType.name Then
            nv.Add("ParentRowID",  Application.Session.GetProvider.ID2Param(Me.Parent.Parent.ID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        Else
             nv.Add("ParentRowID", system.dbnull.value,  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End If
          nv.Add("Name", Name, dbtype.string)
          nv.Add("FolderType", FolderType, dbtype.int16)
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
          If reader.Table.Columns.Contains("FolderType") Then m_FolderType=reader.item("FolderType")
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
'''Доступ к полю Тип папки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FolderType() As enumFolderType
            Get
                LoadFromDatabase()
                FolderType = m_FolderType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumFolderType )
                LoadFromDatabase()
                m_FolderType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Документы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property Shortcut() As Shortcut_col
            Get
                if  m_Shortcut is nothing then
                  m_Shortcut = new Shortcut_col
                  m_Shortcut.Parent = me
                  m_Shortcut.Application = me.Application
                  m_Shortcut.Refresh
                end if
                Shortcut = m_Shortcut
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Папка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property Folder() As Folder_col
            Get
                if  m_Folder is nothing then
                  m_Folder = new Folder_col
                  m_Folder.Parent = me
                  m_Folder.Application = me.Application
                  m_Folder.Refresh
                end if
                Folder = m_Folder
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
          on error resume next  
            Name = node.Attributes.GetNamedItem("Name").Value
            FolderType = node.Attributes.GetNamedItem("FolderType").Value
            e_list = node.SelectNodes("Folder_COL")
            Folder.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("Shortcut_COL")
            Shortcut.XMLLoad(e_list,LoadMode)
             Changed = true
        End sub
        Public Overrides Sub Dispose()
            Shortcut.Dispose
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
          node.SetAttribute("FolderType", FolderType)  
            Folder.XMLSave(node,xdom)
            Shortcut.XMLSave(node,xdom)
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
            Folder.BatchUpdate
            Shortcut.BatchUpdate
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
            return Shortcut
            End Select
            return nothing
        End Function
    End Class
End Namespace
