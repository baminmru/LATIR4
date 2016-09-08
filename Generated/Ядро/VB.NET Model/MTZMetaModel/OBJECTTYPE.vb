
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
'''Реализация строки раздела Тип объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class OBJECTTYPE
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Иконка объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_objIconCls  as String


''' <summary>
'''Локальная переменная для поля Код
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Видмость зависит от пользователя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UseOwnership  as enumBoolean


''' <summary>
'''Локальная переменная для поля При удалении
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnDelete  as System.Guid


''' <summary>
'''Локальная переменная для поля Архивировать вместо удаления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UseArchiving  as enumBoolean


''' <summary>
'''Локальная переменная для поля Тип репликации
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReplicaType  as enumReplicationType


''' <summary>
'''Локальная переменная для поля При создании
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnCreate  as System.Guid


''' <summary>
'''Локальная переменная для поля Сохранять объект целиком
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CommitFullObject  as enumBoolean


''' <summary>
'''Локальная переменная для поля Отображать при выборе ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowRefToObject  as enumBoolean


''' <summary>
'''Локальная переменная для поля Приложение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Package  as System.Guid


''' <summary>
'''Локальная переменная для поля При запуске
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnRun  as System.Guid


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Comment  as String


''' <summary>
'''Локальная переменная для поля Представление для выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ChooseView  as System.Guid


''' <summary>
'''Локальная переменная для поля Допускается только один объект
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsSingleInstance  as enumBoolean


''' <summary>
'''Локальная переменная для поля Отображать при поиске
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowSearch  as enumBoolean


''' <summary>
'''Локальная переменная для дочернего раздела Состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_OBJSTATUS As OBJSTATUS_col


''' <summary>
'''Локальная переменная для дочернего раздела Режим работы
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_OBJECTMODE As OBJECTMODE_col


''' <summary>
'''Локальная переменная для дочернего раздела Методы типа
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_TYPEMENU As TYPEMENU_col


''' <summary>
'''Локальная переменная для дочернего раздела Проверка правильности
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_INSTANCEVALIDATOR As INSTANCEVALIDATOR_col


''' <summary>
'''Локальная переменная для дочернего раздела Раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_PART As PART_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_objIconCls=   
            ' m_Name=   
            ' m_TheComment=   
            ' m_UseOwnership=   
            ' m_OnDelete=   
            ' m_UseArchiving=   
            ' m_ReplicaType=   
            ' m_OnCreate=   
            ' m_CommitFullObject=   
            ' m_AllowRefToObject=   
            ' m_Package=   
            ' m_OnRun=   
            ' m_the_Comment=   
            ' m_ChooseView=   
            ' m_IsSingleInstance=   
            ' m_AllowSearch=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 16
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
                    Value = Package
                Case 2
                    Value = the_Comment
                Case 3
                    Value = Name
                Case 4
                    Value = IsSingleInstance
                Case 5
                    Value = ChooseView
                Case 6
                    Value = OnRun
                Case 7
                    Value = OnCreate
                Case 8
                    Value = OnDelete
                Case 9
                    Value = AllowRefToObject
                Case 10
                    Value = AllowSearch
                Case 11
                    Value = ReplicaType
                Case 12
                    Value = TheComment
                Case 13
                    Value = UseOwnership
                Case 14
                    Value = UseArchiving
                Case 15
                    Value = CommitFullObject
                Case 16
                    Value = objIconCls
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
                    Package = value
                Case 2
                    the_Comment = value
                Case 3
                    Name = value
                Case 4
                    IsSingleInstance = value
                Case 5
                    ChooseView = value
                Case 6
                    OnRun = value
                Case 7
                    OnCreate = value
                Case 8
                    OnDelete = value
                Case 9
                    AllowRefToObject = value
                Case 10
                    AllowSearch = value
                Case 11
                    ReplicaType = value
                Case 12
                    TheComment = value
                Case 13
                    UseOwnership = value
                Case 14
                    UseArchiving = value
                Case 15
                    CommitFullObject = value
                Case 16
                    objIconCls = value
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
                    Return "Package"
                Case 2
                    Return "the_Comment"
                Case 3
                    Return "Name"
                Case 4
                    Return "IsSingleInstance"
                Case 5
                    Return "ChooseView"
                Case 6
                    Return "OnRun"
                Case 7
                    Return "OnCreate"
                Case 8
                    Return "OnDelete"
                Case 9
                    Return "AllowRefToObject"
                Case 10
                    Return "AllowSearch"
                Case 11
                    Return "ReplicaType"
                Case 12
                    Return "TheComment"
                Case 13
                    Return "UseOwnership"
                Case 14
                    Return "UseArchiving"
                Case 15
                    Return "CommitFullObject"
                Case 16
                    Return "objIconCls"
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
             if Package is nothing then
               dr("Package") =system.dbnull.value
               dr("Package_ID") =System.Guid.Empty
             else
               dr("Package") =Package.BRIEF
               dr("Package_ID") =Package.ID
             end if 
             dr("the_Comment") =the_Comment
             dr("Name") =Name
             select case IsSingleInstance
            case enumBoolean.Boolean_Da
              dr ("IsSingleInstance")  = "Да"
              dr ("IsSingleInstance_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsSingleInstance")  = "Нет"
              dr ("IsSingleInstance_VAL")  = 0
              end select 'IsSingleInstance
             if ChooseView is nothing then
               dr("ChooseView") =system.dbnull.value
               dr("ChooseView_ID") =System.Guid.Empty
             else
               dr("ChooseView") =ChooseView.BRIEF
               dr("ChooseView_ID") =ChooseView.ID
             end if 
             if OnRun is nothing then
               dr("OnRun") =system.dbnull.value
               dr("OnRun_ID") =System.Guid.Empty
             else
               dr("OnRun") =OnRun.BRIEF
               dr("OnRun_ID") =OnRun.ID
             end if 
             if OnCreate is nothing then
               dr("OnCreate") =system.dbnull.value
               dr("OnCreate_ID") =System.Guid.Empty
             else
               dr("OnCreate") =OnCreate.BRIEF
               dr("OnCreate_ID") =OnCreate.ID
             end if 
             if OnDelete is nothing then
               dr("OnDelete") =system.dbnull.value
               dr("OnDelete_ID") =System.Guid.Empty
             else
               dr("OnDelete") =OnDelete.BRIEF
               dr("OnDelete_ID") =OnDelete.ID
             end if 
             select case AllowRefToObject
            case enumBoolean.Boolean_Da
              dr ("AllowRefToObject")  = "Да"
              dr ("AllowRefToObject_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowRefToObject")  = "Нет"
              dr ("AllowRefToObject_VAL")  = 0
              end select 'AllowRefToObject
             select case AllowSearch
            case enumBoolean.Boolean_Da
              dr ("AllowSearch")  = "Да"
              dr ("AllowSearch_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowSearch")  = "Нет"
              dr ("AllowSearch_VAL")  = 0
              end select 'AllowSearch
             select case ReplicaType
            case enumReplicationType.ReplicationType_Postrocno
              dr ("ReplicaType")  = "Построчно"
              dr ("ReplicaType_VAL")  = 1
            case enumReplicationType.ReplicationType_Ves__dokument
              dr ("ReplicaType")  = "Весь документ"
              dr ("ReplicaType_VAL")  = 0
            case enumReplicationType.ReplicationType_Lokal_niy
              dr ("ReplicaType")  = "Локальный"
              dr ("ReplicaType_VAL")  = 2
              end select 'ReplicaType
             dr("TheComment") =TheComment
             select case UseOwnership
            case enumBoolean.Boolean_Da
              dr ("UseOwnership")  = "Да"
              dr ("UseOwnership_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("UseOwnership")  = "Нет"
              dr ("UseOwnership_VAL")  = 0
              end select 'UseOwnership
             select case UseArchiving
            case enumBoolean.Boolean_Da
              dr ("UseArchiving")  = "Да"
              dr ("UseArchiving_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("UseArchiving")  = "Нет"
              dr ("UseArchiving_VAL")  = 0
              end select 'UseArchiving
             select case CommitFullObject
            case enumBoolean.Boolean_Da
              dr ("CommitFullObject")  = "Да"
              dr ("CommitFullObject_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CommitFullObject")  = "Нет"
              dr ("CommitFullObject_VAL")  = 0
              end select 'CommitFullObject
             dr("objIconCls") =objIconCls
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
            mFindInside = OBJSTATUS.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = OBJECTMODE.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = TYPEMENU.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = INSTANCEVALIDATOR.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = PART.FindObject(table,RowID)
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
          if m_Package.Equals(System.Guid.Empty) then
            nv.Add("Package", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Package", Application.Session.GetProvider.ID2Param(m_Package), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("the_Comment", the_Comment, dbtype.string)
          nv.Add("Name", Name, dbtype.string)
          nv.Add("IsSingleInstance", IsSingleInstance, dbtype.int16)
          if m_ChooseView.Equals(System.Guid.Empty) then
            nv.Add("ChooseView", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ChooseView", Application.Session.GetProvider.ID2Param(m_ChooseView), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnRun.Equals(System.Guid.Empty) then
            nv.Add("OnRun", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnRun", Application.Session.GetProvider.ID2Param(m_OnRun), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnCreate.Equals(System.Guid.Empty) then
            nv.Add("OnCreate", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnCreate", Application.Session.GetProvider.ID2Param(m_OnCreate), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnDelete.Equals(System.Guid.Empty) then
            nv.Add("OnDelete", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnDelete", Application.Session.GetProvider.ID2Param(m_OnDelete), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AllowRefToObject", AllowRefToObject, dbtype.int16)
          nv.Add("AllowSearch", AllowSearch, dbtype.int16)
          nv.Add("ReplicaType", ReplicaType, dbtype.int16)
          nv.Add("TheComment", TheComment, dbtype.string)
          nv.Add("UseOwnership", UseOwnership, dbtype.int16)
          nv.Add("UseArchiving", UseArchiving, dbtype.int16)
          nv.Add("CommitFullObject", CommitFullObject, dbtype.int16)
          nv.Add("objIconCls", objIconCls, dbtype.string)
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
      If reader.Table.Columns.Contains("Package") Then
          if isdbnull(reader.item("Package")) then
            If reader.Table.Columns.Contains("Package") Then m_Package = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Package") Then m_Package= New System.Guid(reader.item("Package").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("the_Comment") Then m_the_Comment=reader.item("the_Comment").ToString()
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("IsSingleInstance") Then m_IsSingleInstance=reader.item("IsSingleInstance")
      If reader.Table.Columns.Contains("ChooseView") Then
          if isdbnull(reader.item("ChooseView")) then
            If reader.Table.Columns.Contains("ChooseView") Then m_ChooseView = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ChooseView") Then m_ChooseView= New System.Guid(reader.item("ChooseView").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnRun") Then
          if isdbnull(reader.item("OnRun")) then
            If reader.Table.Columns.Contains("OnRun") Then m_OnRun = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnRun") Then m_OnRun= New System.Guid(reader.item("OnRun").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnCreate") Then
          if isdbnull(reader.item("OnCreate")) then
            If reader.Table.Columns.Contains("OnCreate") Then m_OnCreate = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnCreate") Then m_OnCreate= New System.Guid(reader.item("OnCreate").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnDelete") Then
          if isdbnull(reader.item("OnDelete")) then
            If reader.Table.Columns.Contains("OnDelete") Then m_OnDelete = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnDelete") Then m_OnDelete= New System.Guid(reader.item("OnDelete").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AllowRefToObject") Then m_AllowRefToObject=reader.item("AllowRefToObject")
          If reader.Table.Columns.Contains("AllowSearch") Then m_AllowSearch=reader.item("AllowSearch")
          If reader.Table.Columns.Contains("ReplicaType") Then m_ReplicaType=reader.item("ReplicaType")
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
          If reader.Table.Columns.Contains("UseOwnership") Then m_UseOwnership=reader.item("UseOwnership")
          If reader.Table.Columns.Contains("UseArchiving") Then m_UseArchiving=reader.item("UseArchiving")
          If reader.Table.Columns.Contains("CommitFullObject") Then m_CommitFullObject=reader.item("CommitFullObject")
          If reader.Table.Columns.Contains("objIconCls") Then m_objIconCls=reader.item("objIconCls").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Приложение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Package() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Package = me.application.Findrowobject("MTZAPP",m_Package)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Package = Value.id
                else
                   m_Package=System.Guid.Empty
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
        Public Property the_Comment() As String
            Get
                LoadFromDatabase()
                the_Comment = m_the_Comment
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_Comment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код
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
'''Доступ к полю Допускается только один объект
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsSingleInstance() As enumBoolean
            Get
                LoadFromDatabase()
                IsSingleInstance = m_IsSingleInstance
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsSingleInstance = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Представление для выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ChooseView() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ChooseView = me.application.Findrowobject("PARTVIEW",m_ChooseView)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ChooseView = Value.id
                else
                   m_ChooseView=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При запуске
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnRun() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnRun = me.application.Findrowobject("TYPEMENU",m_OnRun)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_OnRun = Value.id
                else
                   m_OnRun=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При создании
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnCreate() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnCreate = me.application.Findrowobject("TYPEMENU",m_OnCreate)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_OnCreate = Value.id
                else
                   m_OnCreate=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При удалении
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnDelete() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnDelete = me.application.Findrowobject("TYPEMENU",m_OnDelete)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_OnDelete = Value.id
                else
                   m_OnDelete=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Отображать при выборе ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowRefToObject() As enumBoolean
            Get
                LoadFromDatabase()
                AllowRefToObject = m_AllowRefToObject
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowRefToObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Отображать при поиске
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowSearch() As enumBoolean
            Get
                LoadFromDatabase()
                AllowSearch = m_AllowSearch
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowSearch = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип репликации
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReplicaType() As enumReplicationType
            Get
                LoadFromDatabase()
                ReplicaType = m_ReplicaType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumReplicationType )
                LoadFromDatabase()
                m_ReplicaType = Value
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
'''Доступ к полю Видмость зависит от пользователя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UseOwnership() As enumBoolean
            Get
                LoadFromDatabase()
                UseOwnership = m_UseOwnership
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_UseOwnership = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Архивировать вместо удаления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UseArchiving() As enumBoolean
            Get
                LoadFromDatabase()
                UseArchiving = m_UseArchiving
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_UseArchiving = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сохранять объект целиком
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CommitFullObject() As enumBoolean
            Get
                LoadFromDatabase()
                CommitFullObject = m_CommitFullObject
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CommitFullObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property objIconCls() As String
            Get
                LoadFromDatabase()
                objIconCls = m_objIconCls
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_objIconCls = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property OBJSTATUS() As OBJSTATUS_col
            Get
                if  m_OBJSTATUS is nothing then
                  m_OBJSTATUS = new OBJSTATUS_col
                  m_OBJSTATUS.Parent = me
                  m_OBJSTATUS.Application = me.Application
                  m_OBJSTATUS.Refresh
                end if
                OBJSTATUS = m_OBJSTATUS
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Режим работы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property OBJECTMODE() As OBJECTMODE_col
            Get
                if  m_OBJECTMODE is nothing then
                  m_OBJECTMODE = new OBJECTMODE_col
                  m_OBJECTMODE.Parent = me
                  m_OBJECTMODE.Application = me.Application
                  m_OBJECTMODE.Refresh
                end if
                OBJECTMODE = m_OBJECTMODE
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Методы типа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property TYPEMENU() As TYPEMENU_col
            Get
                if  m_TYPEMENU is nothing then
                  m_TYPEMENU = new TYPEMENU_col
                  m_TYPEMENU.Parent = me
                  m_TYPEMENU.Application = me.Application
                  m_TYPEMENU.Refresh
                end if
                TYPEMENU = m_TYPEMENU
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Проверка правильности
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property INSTANCEVALIDATOR() As INSTANCEVALIDATOR_col
            Get
                if  m_INSTANCEVALIDATOR is nothing then
                  m_INSTANCEVALIDATOR = new INSTANCEVALIDATOR_col
                  m_INSTANCEVALIDATOR.Parent = me
                  m_INSTANCEVALIDATOR.Application = me.Application
                  m_INSTANCEVALIDATOR.Refresh
                end if
                INSTANCEVALIDATOR = m_INSTANCEVALIDATOR
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property PART() As PART_col
            Get
                if  m_PART is nothing then
                  m_PART = new PART_col
                  m_PART.Parent = me
                  m_PART.Application = me.Application
                  m_PART.Refresh
                end if
                PART = m_PART
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
            m_Package = new system.guid(node.Attributes.GetNamedItem("Package").Value)
            the_Comment = node.Attributes.GetNamedItem("the_Comment").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            IsSingleInstance = node.Attributes.GetNamedItem("IsSingleInstance").Value
            m_ChooseView = new system.guid(node.Attributes.GetNamedItem("ChooseView").Value)
            m_OnRun = new system.guid(node.Attributes.GetNamedItem("OnRun").Value)
            m_OnCreate = new system.guid(node.Attributes.GetNamedItem("OnCreate").Value)
            m_OnDelete = new system.guid(node.Attributes.GetNamedItem("OnDelete").Value)
            AllowRefToObject = node.Attributes.GetNamedItem("AllowRefToObject").Value
            AllowSearch = node.Attributes.GetNamedItem("AllowSearch").Value
            ReplicaType = node.Attributes.GetNamedItem("ReplicaType").Value
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            UseOwnership = node.Attributes.GetNamedItem("UseOwnership").Value
            UseArchiving = node.Attributes.GetNamedItem("UseArchiving").Value
            CommitFullObject = node.Attributes.GetNamedItem("CommitFullObject").Value
            objIconCls = node.Attributes.GetNamedItem("objIconCls").Value
            e_list = node.SelectNodes("OBJSTATUS_COL")
            OBJSTATUS.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("OBJECTMODE_COL")
            OBJECTMODE.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("TYPEMENU_COL")
            TYPEMENU.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("INSTANCEVALIDATOR_COL")
            INSTANCEVALIDATOR.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("PART_COL")
            PART.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            OBJSTATUS.Dispose
            OBJECTMODE.Dispose
            TYPEMENU.Dispose
            INSTANCEVALIDATOR.Dispose
            PART.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("Package", m_Package.tostring)  
          node.SetAttribute("the_Comment", the_Comment)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("IsSingleInstance", IsSingleInstance)  
          node.SetAttribute("ChooseView", m_ChooseView.tostring)  
          node.SetAttribute("OnRun", m_OnRun.tostring)  
          node.SetAttribute("OnCreate", m_OnCreate.tostring)  
          node.SetAttribute("OnDelete", m_OnDelete.tostring)  
          node.SetAttribute("AllowRefToObject", AllowRefToObject)  
          node.SetAttribute("AllowSearch", AllowSearch)  
          node.SetAttribute("ReplicaType", ReplicaType)  
          node.SetAttribute("TheComment", TheComment)  
          node.SetAttribute("UseOwnership", UseOwnership)  
          node.SetAttribute("UseArchiving", UseArchiving)  
          node.SetAttribute("CommitFullObject", CommitFullObject)  
          node.SetAttribute("objIconCls", objIconCls)  
            OBJSTATUS.XMLSave(node,xdom)
            OBJECTMODE.XMLSave(node,xdom)
            TYPEMENU.XMLSave(node,xdom)
            INSTANCEVALIDATOR.XMLSave(node,xdom)
            PART.XMLSave(node,xdom)
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
            OBJSTATUS.BatchUpdate
            OBJECTMODE.BatchUpdate
            TYPEMENU.BatchUpdate
            INSTANCEVALIDATOR.BatchUpdate
            PART.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 5
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
            return PART
         Case 2
            return TYPEMENU
         Case 3
            return INSTANCEVALIDATOR
         Case 4
            return OBJECTMODE
         Case 5
            return OBJSTATUS
            End Select
            return nothing
        End Function
    End Class
End Namespace
