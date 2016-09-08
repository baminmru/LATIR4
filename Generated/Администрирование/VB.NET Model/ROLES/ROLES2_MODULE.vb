
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
'''Реализация строки раздела Модули
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES2_MODULE
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SubStructObjects  as enumBoolean


''' <summary>
'''Локальная переменная для поля № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Sequence  as long


''' <summary>
'''Локальная переменная для поля Имя группы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_GroupName  as String


''' <summary>
'''Локальная переменная для поля Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllObjects  as enumBoolean


''' <summary>
'''Локальная переменная для поля Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheIcon  as String


''' <summary>
'''Локальная переменная для поля Код модуля
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ColegsObject  as enumBoolean


''' <summary>
'''Локальная переменная для поля Настраивать видимость
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CustomizeVisibility  as enumBoolean


''' <summary>
'''Локальная переменная для поля Разрешен
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ModuleAccessible  as enumBoolean


''' <summary>
'''Локальная переменная для дочернего раздела Действия и отчеты
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ROLES2_MODREPORT As ROLES2_MODREPORT_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheComment=   
            ' m_SubStructObjects=   
            ' m_Sequence=   
            ' m_GroupName=   
            ' m_Caption=   
            ' m_AllObjects=   
            ' m_TheIcon=   
            ' m_name=   
            ' m_ColegsObject=   
            ' m_CustomizeVisibility=   
            ' m_ModuleAccessible=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 11
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
                    Value = GroupName
                Case 2
                    Value = Caption
                Case 3
                    Value = Sequence
                Case 4
                    Value = ModuleAccessible
                Case 5
                    Value = CustomizeVisibility
                Case 6
                    Value = TheIcon
                Case 7
                    Value = name
                Case 8
                    Value = TheComment
                Case 9
                    Value = AllObjects
                Case 10
                    Value = ColegsObject
                Case 11
                    Value = SubStructObjects
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
                    GroupName = value
                Case 2
                    Caption = value
                Case 3
                    Sequence = value
                Case 4
                    ModuleAccessible = value
                Case 5
                    CustomizeVisibility = value
                Case 6
                    TheIcon = value
                Case 7
                    name = value
                Case 8
                    TheComment = value
                Case 9
                    AllObjects = value
                Case 10
                    ColegsObject = value
                Case 11
                    SubStructObjects = value
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
                    Return "GroupName"
                Case 2
                    Return "Caption"
                Case 3
                    Return "Sequence"
                Case 4
                    Return "ModuleAccessible"
                Case 5
                    Return "CustomizeVisibility"
                Case 6
                    Return "TheIcon"
                Case 7
                    Return "name"
                Case 8
                    Return "TheComment"
                Case 9
                    Return "AllObjects"
                Case 10
                    Return "ColegsObject"
                Case 11
                    Return "SubStructObjects"
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
             dr("GroupName") =GroupName
             dr("Caption") =Caption
             dr("Sequence") =Sequence
             select case ModuleAccessible
            case enumBoolean.Boolean_Da
              dr ("ModuleAccessible")  = "Да"
              dr ("ModuleAccessible_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ModuleAccessible")  = "Нет"
              dr ("ModuleAccessible_VAL")  = 0
              end select 'ModuleAccessible
             select case CustomizeVisibility
            case enumBoolean.Boolean_Da
              dr ("CustomizeVisibility")  = "Да"
              dr ("CustomizeVisibility_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CustomizeVisibility")  = "Нет"
              dr ("CustomizeVisibility_VAL")  = 0
              end select 'CustomizeVisibility
             dr("TheIcon") =TheIcon
             dr("name") =name
             dr("TheComment") =TheComment
             select case AllObjects
            case enumBoolean.Boolean_Da
              dr ("AllObjects")  = "Да"
              dr ("AllObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllObjects")  = "Нет"
              dr ("AllObjects_VAL")  = 0
              end select 'AllObjects
             select case ColegsObject
            case enumBoolean.Boolean_Da
              dr ("ColegsObject")  = "Да"
              dr ("ColegsObject_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ColegsObject")  = "Нет"
              dr ("ColegsObject_VAL")  = 0
              end select 'ColegsObject
             select case SubStructObjects
            case enumBoolean.Boolean_Da
              dr ("SubStructObjects")  = "Да"
              dr ("SubStructObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("SubStructObjects")  = "Нет"
              dr ("SubStructObjects_VAL")  = 0
              end select 'SubStructObjects
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
            mFindInside = ROLES2_MODREPORT.FindObject(table,RowID)
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
          nv.Add("GroupName", GroupName, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("Sequence", Sequence, dbtype.Int32)
          nv.Add("ModuleAccessible", ModuleAccessible, dbtype.int16)
          nv.Add("CustomizeVisibility", CustomizeVisibility, dbtype.int16)
          nv.Add("TheIcon", TheIcon, dbtype.string)
          nv.Add("name", name, dbtype.string)
          nv.Add("TheComment", TheComment, dbtype.string)
          nv.Add("AllObjects", AllObjects, dbtype.int16)
          nv.Add("ColegsObject", ColegsObject, dbtype.int16)
          nv.Add("SubStructObjects", SubStructObjects, dbtype.int16)
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
          If reader.Table.Columns.Contains("GroupName") Then m_GroupName=reader.item("GroupName").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("Sequence") Then m_Sequence=reader.item("Sequence")
          If reader.Table.Columns.Contains("ModuleAccessible") Then m_ModuleAccessible=reader.item("ModuleAccessible")
          If reader.Table.Columns.Contains("CustomizeVisibility") Then m_CustomizeVisibility=reader.item("CustomizeVisibility")
          If reader.Table.Columns.Contains("TheIcon") Then m_TheIcon=reader.item("TheIcon").ToString()
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
          If reader.Table.Columns.Contains("AllObjects") Then m_AllObjects=reader.item("AllObjects")
          If reader.Table.Columns.Contains("ColegsObject") Then m_ColegsObject=reader.item("ColegsObject")
          If reader.Table.Columns.Contains("SubStructObjects") Then m_SubStructObjects=reader.item("SubStructObjects")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Имя группы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property GroupName() As String
            Get
                LoadFromDatabase()
                GroupName = m_GroupName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_GroupName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Надпись
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
'''Доступ к полю № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Sequence() As long
            Get
                LoadFromDatabase()
                Sequence = m_Sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_Sequence = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешен
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ModuleAccessible() As enumBoolean
            Get
                LoadFromDatabase()
                ModuleAccessible = m_ModuleAccessible
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ModuleAccessible = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Настраивать видимость
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CustomizeVisibility() As enumBoolean
            Get
                LoadFromDatabase()
                CustomizeVisibility = m_CustomizeVisibility
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CustomizeVisibility = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheIcon() As String
            Get
                LoadFromDatabase()
                TheIcon = m_TheIcon
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheIcon = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код модуля
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property name() As String
            Get
                LoadFromDatabase()
                name = m_name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_name = Value
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
'''Доступ к полю Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllObjects() As enumBoolean
            Get
                LoadFromDatabase()
                AllObjects = m_AllObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllObjects = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ColegsObject() As enumBoolean
            Get
                LoadFromDatabase()
                ColegsObject = m_ColegsObject
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ColegsObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SubStructObjects() As enumBoolean
            Get
                LoadFromDatabase()
                SubStructObjects = m_SubStructObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_SubStructObjects = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Действия и отчеты
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ROLES2_MODREPORT() As ROLES2_MODREPORT_col
            Get
                if  m_ROLES2_MODREPORT is nothing then
                  m_ROLES2_MODREPORT = new ROLES2_MODREPORT_col
                  m_ROLES2_MODREPORT.Parent = me
                  m_ROLES2_MODREPORT.Application = me.Application
                  m_ROLES2_MODREPORT.Refresh
                end if
                ROLES2_MODREPORT = m_ROLES2_MODREPORT
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
            GroupName = node.Attributes.GetNamedItem("GroupName").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            Sequence = node.Attributes.GetNamedItem("Sequence").Value
            ModuleAccessible = node.Attributes.GetNamedItem("ModuleAccessible").Value
            CustomizeVisibility = node.Attributes.GetNamedItem("CustomizeVisibility").Value
            TheIcon = node.Attributes.GetNamedItem("TheIcon").Value
            name = node.Attributes.GetNamedItem("name").Value
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            AllObjects = node.Attributes.GetNamedItem("AllObjects").Value
            ColegsObject = node.Attributes.GetNamedItem("ColegsObject").Value
            SubStructObjects = node.Attributes.GetNamedItem("SubStructObjects").Value
            e_list = node.SelectNodes("ROLES2_MODREPORT_COL")
            ROLES2_MODREPORT.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            ROLES2_MODREPORT.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("GroupName", GroupName)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("Sequence", Sequence)  
          node.SetAttribute("ModuleAccessible", ModuleAccessible)  
          node.SetAttribute("CustomizeVisibility", CustomizeVisibility)  
          node.SetAttribute("TheIcon", TheIcon)  
          node.SetAttribute("name", name)  
          node.SetAttribute("TheComment", TheComment)  
          node.SetAttribute("AllObjects", AllObjects)  
          node.SetAttribute("ColegsObject", ColegsObject)  
          node.SetAttribute("SubStructObjects", SubStructObjects)  
            ROLES2_MODREPORT.XMLSave(node,xdom)
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
            ROLES2_MODREPORT.BatchUpdate
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
            return ROLES2_MODREPORT
            End Select
            return nothing
        End Function
    End Class
End Namespace
