
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
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class InfoStoreDef
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Тип каталога
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_InfoStoreType  as enumInfoStoreType


''' <summary>
'''Локальная переменная для поля Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheGroup  as System.Guid


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheUser  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_InfoStoreType=   
            ' m_TheGroup=   
            ' m_Name=   
            ' m_TheUser=   
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
                    Value = TheGroup
                Case 2
                    Value = Name
                Case 3
                    Value = InfoStoreType
                Case 4
                    Value = TheUser
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
                    TheGroup = value
                Case 2
                    Name = value
                Case 3
                    InfoStoreType = value
                Case 4
                    TheUser = value
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
                    Return "TheGroup"
                Case 2
                    Return "Name"
                Case 3
                    Return "InfoStoreType"
                Case 4
                    Return "TheUser"
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
             if TheGroup is nothing then
               dr("TheGroup") =system.dbnull.value
               dr("TheGroup_ID") =System.Guid.Empty
             else
               dr("TheGroup") =TheGroup.BRIEF
               dr("TheGroup_ID") =TheGroup.ID
             end if 
             dr("Name") =Name
             select case InfoStoreType
            case enumInfoStoreType.InfoStoreType_Gruppovoy
              dr ("InfoStoreType")  = "Групповой"
              dr ("InfoStoreType_VAL")  = 2
            case enumInfoStoreType.InfoStoreType_cls__Obsiy
              dr ("InfoStoreType")  = " Общий"
              dr ("InfoStoreType_VAL")  = 0
            case enumInfoStoreType.InfoStoreType_Personal_niy
              dr ("InfoStoreType")  = "Персональный"
              dr ("InfoStoreType_VAL")  = 1
              end select 'InfoStoreType
             if TheUser is nothing then
               dr("TheUser") =system.dbnull.value
               dr("TheUser_ID") =System.Guid.Empty
             else
               dr("TheUser") =TheUser.BRIEF
               dr("TheUser_ID") =TheUser.ID
             end if 
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
          if m_TheGroup.Equals(System.Guid.Empty) then
            nv.Add("TheGroup", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheGroup", Application.Session.GetProvider.ID2Param(m_TheGroup), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("Name", Name, dbtype.string)
          nv.Add("InfoStoreType", InfoStoreType, dbtype.int16)
          if m_TheUser.Equals(System.Guid.Empty) then
            nv.Add("TheUser", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheUser", Application.Session.GetProvider.ID2Param(m_TheUser), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
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
      If reader.Table.Columns.Contains("TheGroup") Then
          if isdbnull(reader.item("TheGroup")) then
            If reader.Table.Columns.Contains("TheGroup") Then m_TheGroup = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheGroup") Then m_TheGroup= New System.Guid(reader.item("TheGroup").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("InfoStoreType") Then m_InfoStoreType=reader.item("InfoStoreType")
      If reader.Table.Columns.Contains("TheUser") Then
          if isdbnull(reader.item("TheUser")) then
            If reader.Table.Columns.Contains("TheUser") Then m_TheUser = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheUser") Then m_TheUser= New System.Guid(reader.item("TheUser").ToString())
          end if 
      end if 
        End Sub


''' <summary>
'''Доступ к полю Группа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheGroup() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheGroup = me.application.Findrowobject("Groups",m_TheGroup)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheGroup = Value.id
                else
                   m_TheGroup=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


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
'''Доступ к полю Тип каталога
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property InfoStoreType() As enumInfoStoreType
            Get
                LoadFromDatabase()
                InfoStoreType = m_InfoStoreType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumInfoStoreType )
                LoadFromDatabase()
                m_InfoStoreType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheUser() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheUser = me.application.Findrowobject("Users",m_TheUser)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheUser = Value.id
                else
                   m_TheUser=System.Guid.Empty
                end if
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
            m_TheGroup = new system.guid(node.Attributes.GetNamedItem("TheGroup").Value)
            Name = node.Attributes.GetNamedItem("Name").Value
            InfoStoreType = node.Attributes.GetNamedItem("InfoStoreType").Value
            m_TheUser = new system.guid(node.Attributes.GetNamedItem("TheUser").Value)
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
          node.SetAttribute("TheGroup", m_TheGroup.tostring)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("InfoStoreType", InfoStoreType)  
          node.SetAttribute("TheUser", m_TheUser.tostring)  
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
