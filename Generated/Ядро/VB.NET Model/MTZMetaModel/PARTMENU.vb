
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
'''Реализация строки раздела Методы раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTMENU
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Action  as System.Guid


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Включать в меню
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsMenuItem  as enumBoolean


''' <summary>
'''Локальная переменная для поля В тулбар
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsToolBarButton  as enumBoolean


''' <summary>
'''Локальная переменная для поля Горячая клавиша
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_HotKey  as String


''' <summary>
'''Локальная переменная для поля Подсказка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ToolTip  as String


''' <summary>
'''Локальная переменная для дочернего раздела Отображение параметров
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_PARTPARAMMAP As PARTPARAMMAP_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_Action=   
            ' m_Name=   
            ' m_Caption=   
            ' m_IsMenuItem=   
            ' m_IsToolBarButton=   
            ' m_HotKey=   
            ' m_ToolTip=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 7
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
                    Value = Caption
                Case 3
                    Value = ToolTip
                Case 4
                    Value = the_Action
                Case 5
                    Value = IsMenuItem
                Case 6
                    Value = IsToolBarButton
                Case 7
                    Value = HotKey
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
                    Name = value
                Case 2
                    Caption = value
                Case 3
                    ToolTip = value
                Case 4
                    the_Action = value
                Case 5
                    IsMenuItem = value
                Case 6
                    IsToolBarButton = value
                Case 7
                    HotKey = value
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
                    Return "Caption"
                Case 3
                    Return "ToolTip"
                Case 4
                    Return "the_Action"
                Case 5
                    Return "IsMenuItem"
                Case 6
                    Return "IsToolBarButton"
                Case 7
                    Return "HotKey"
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
             dr("Name") =Name
             dr("Caption") =Caption
             dr("ToolTip") =ToolTip
             if the_Action is nothing then
               dr("the_Action") =system.dbnull.value
               dr("the_Action_ID") =System.Guid.Empty
             else
               dr("the_Action") =the_Action.BRIEF
               dr("the_Action_ID") =the_Action.ID
             end if 
             select case IsMenuItem
            case enumBoolean.Boolean_Da
              dr ("IsMenuItem")  = "Да"
              dr ("IsMenuItem_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsMenuItem")  = "Нет"
              dr ("IsMenuItem_VAL")  = 0
              end select 'IsMenuItem
             select case IsToolBarButton
            case enumBoolean.Boolean_Da
              dr ("IsToolBarButton")  = "Да"
              dr ("IsToolBarButton_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsToolBarButton")  = "Нет"
              dr ("IsToolBarButton_VAL")  = 0
              end select 'IsToolBarButton
             dr("HotKey") =HotKey
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
            mFindInside = PARTPARAMMAP.FindObject(table,RowID)
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
          nv.Add("Name", Name, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("ToolTip", ToolTip, dbtype.string)
          if m_the_Action.Equals(System.Guid.Empty) then
            nv.Add("the_Action", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("the_Action", Application.Session.GetProvider.ID2Param(m_the_Action), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("IsMenuItem", IsMenuItem, dbtype.int16)
          nv.Add("IsToolBarButton", IsToolBarButton, dbtype.int16)
          nv.Add("HotKey", HotKey, dbtype.string)
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
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("ToolTip") Then m_ToolTip=reader.item("ToolTip").ToString()
      If reader.Table.Columns.Contains("the_Action") Then
          if isdbnull(reader.item("the_Action")) then
            If reader.Table.Columns.Contains("the_Action") Then m_the_Action = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("the_Action") Then m_the_Action= New System.Guid(reader.item("the_Action").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("IsMenuItem") Then m_IsMenuItem=reader.item("IsMenuItem")
          If reader.Table.Columns.Contains("IsToolBarButton") Then m_IsToolBarButton=reader.item("IsToolBarButton")
          If reader.Table.Columns.Contains("HotKey") Then m_HotKey=reader.item("HotKey").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
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
'''Доступ к полю Подсказка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ToolTip() As String
            Get
                LoadFromDatabase()
                ToolTip = m_ToolTip
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ToolTip = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Action() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                the_Action = me.application.Findrowobject("SHAREDMETHOD",m_the_Action)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_the_Action = Value.id
                else
                   m_the_Action=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Включать в меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsMenuItem() As enumBoolean
            Get
                LoadFromDatabase()
                IsMenuItem = m_IsMenuItem
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsMenuItem = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю В тулбар
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsToolBarButton() As enumBoolean
            Get
                LoadFromDatabase()
                IsToolBarButton = m_IsToolBarButton
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsToolBarButton = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Горячая клавиша
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property HotKey() As String
            Get
                LoadFromDatabase()
                HotKey = m_HotKey
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_HotKey = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Отображение параметров
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property PARTPARAMMAP() As PARTPARAMMAP_col
            Get
                if  m_PARTPARAMMAP is nothing then
                  m_PARTPARAMMAP = new PARTPARAMMAP_col
                  m_PARTPARAMMAP.Parent = me
                  m_PARTPARAMMAP.Application = me.Application
                  m_PARTPARAMMAP.Refresh
                end if
                PARTPARAMMAP = m_PARTPARAMMAP
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
            Name = node.Attributes.GetNamedItem("Name").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            ToolTip = node.Attributes.GetNamedItem("ToolTip").Value
            m_the_Action = new system.guid(node.Attributes.GetNamedItem("the_Action").Value)
            IsMenuItem = node.Attributes.GetNamedItem("IsMenuItem").Value
            IsToolBarButton = node.Attributes.GetNamedItem("IsToolBarButton").Value
            HotKey = node.Attributes.GetNamedItem("HotKey").Value
            e_list = node.SelectNodes("PARTPARAMMAP_COL")
            PARTPARAMMAP.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            PARTPARAMMAP.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("Name", Name)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("ToolTip", ToolTip)  
          node.SetAttribute("the_Action", m_the_Action.tostring)  
          node.SetAttribute("IsMenuItem", IsMenuItem)  
          node.SetAttribute("IsToolBarButton", IsToolBarButton)  
          node.SetAttribute("HotKey", HotKey)  
            PARTPARAMMAP.XMLSave(node,xdom)
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
            PARTPARAMMAP.BatchUpdate
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
            return PARTPARAMMAP
            End Select
            return nothing
        End Function
    End Class
End Namespace
