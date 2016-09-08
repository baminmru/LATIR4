
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
'''Реализация строки раздела Раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PART
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Иконка раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_partIconCls  as String


''' <summary>
'''Локальная переменная для поля Правило составления BRIEF поля
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ruleBrief  as String


''' <summary>
'''Локальная переменная для поля Целочисленный ключ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_integerpkey  as enumBoolean


''' <summary>
'''Локальная переменная для поля Исключить из индексирования
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ManualRegister  as enumBoolean


''' <summary>
'''Локальная переменная для поля При удалении
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnDelete  as System.Guid


''' <summary>
'''Локальная переменная для поля Поведение при добавлении
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AddBehaivor  as enumPartAddBehaivor


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля При сохранении
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnSave  as System.Guid


''' <summary>
'''Локальная переменная для поля При создании
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnCreate  as System.Guid


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Comment  as STRING


''' <summary>
'''Локальная переменная для поля Архивировать вместо удаления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UseArchiving  as enumBoolean


''' <summary>
'''Локальная переменная для поля При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OnRun  as System.Guid


''' <summary>
'''Локальная переменная для поля Объект расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ExtenderObject  as System.Guid


''' <summary>
'''Локальная переменная для поля Не записывать в журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NoLog  as enumBoolean


''' <summary>
'''Локальная переменная для поля Шаблон для краткого отображения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_shablonBrief  as String


''' <summary>
'''Локальная переменная для поля Тип структры
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_PartType  as enumPartType


''' <summary>
'''Локальная переменная для поля № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Sequence  as long


''' <summary>
'''Локальная переменная для поля Вести журнал изменений
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsJormalChange  as enumBoolean


''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для дочернего раздела Методы раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_PARTMENU As PARTMENU_col


''' <summary>
'''Локальная переменная для дочернего раздела Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_PARTVIEW As PARTVIEW_col


''' <summary>
'''Локальная переменная для дочернего раздела Логика на форме
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_VALIDATOR As VALIDATOR_col


''' <summary>
'''Локальная переменная для дочернего раздела Ограничение уникальности
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_UNIQUECONSTRAINT As UNIQUECONSTRAINT_col


''' <summary>
'''Локальная переменная для дочернего раздела Интерфейсы расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ExtenderInterface As ExtenderInterface_col


''' <summary>
'''Локальная переменная для дочернего раздела Поле
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELD As FIELD_col


''' <summary>
'''Локальная переменная для дочерних записей раздела Раздел
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
            ' m_partIconCls=   
            ' m_ruleBrief=   
            ' m_integerpkey=   
            ' m_ManualRegister=   
            ' m_OnDelete=   
            ' m_AddBehaivor=   
            ' m_Name=   
            ' m_OnSave=   
            ' m_OnCreate=   
            ' m_the_Comment=   
            ' m_UseArchiving=   
            ' m_OnRun=   
            ' m_ExtenderObject=   
            ' m_NoLog=   
            ' m_shablonBrief=   
            ' m_PartType=   
            ' m_Sequence=   
            ' m_IsJormalChange=   
            ' m_Caption=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 19
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
                    Value = Sequence
                Case 2
                    Value = PartType
                Case 3
                    Value = Caption
                Case 4
                    Value = Name
                Case 5
                    Value = the_Comment
                Case 6
                    Value = NoLog
                Case 7
                    Value = ManualRegister
                Case 8
                    Value = OnCreate
                Case 9
                    Value = OnSave
                Case 10
                    Value = OnRun
                Case 11
                    Value = OnDelete
                Case 12
                    Value = AddBehaivor
                Case 13
                    Value = ExtenderObject
                Case 14
                    Value = shablonBrief
                Case 15
                    Value = ruleBrief
                Case 16
                    Value = IsJormalChange
                Case 17
                    Value = UseArchiving
                Case 18
                    Value = integerpkey
                Case 19
                    Value = partIconCls
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
                    Sequence = value
                Case 2
                    PartType = value
                Case 3
                    Caption = value
                Case 4
                    Name = value
                Case 5
                    the_Comment = value
                Case 6
                    NoLog = value
                Case 7
                    ManualRegister = value
                Case 8
                    OnCreate = value
                Case 9
                    OnSave = value
                Case 10
                    OnRun = value
                Case 11
                    OnDelete = value
                Case 12
                    AddBehaivor = value
                Case 13
                    ExtenderObject = value
                Case 14
                    shablonBrief = value
                Case 15
                    ruleBrief = value
                Case 16
                    IsJormalChange = value
                Case 17
                    UseArchiving = value
                Case 18
                    integerpkey = value
                Case 19
                    partIconCls = value
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
                    Return "Sequence"
                Case 2
                    Return "PartType"
                Case 3
                    Return "Caption"
                Case 4
                    Return "Name"
                Case 5
                    Return "the_Comment"
                Case 6
                    Return "NoLog"
                Case 7
                    Return "ManualRegister"
                Case 8
                    Return "OnCreate"
                Case 9
                    Return "OnSave"
                Case 10
                    Return "OnRun"
                Case 11
                    Return "OnDelete"
                Case 12
                    Return "AddBehaivor"
                Case 13
                    Return "ExtenderObject"
                Case 14
                    Return "shablonBrief"
                Case 15
                    Return "ruleBrief"
                Case 16
                    Return "IsJormalChange"
                Case 17
                    Return "UseArchiving"
                Case 18
                    Return "integerpkey"
                Case 19
                    Return "partIconCls"
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
             dr("Sequence") =Sequence
             select case PartType
            case enumPartType.PartType_Kollekciy
              dr ("PartType")  = "Коллекция"
              dr ("PartType_VAL")  = 1
            case enumPartType.PartType_Derevo
              dr ("PartType")  = "Дерево"
              dr ("PartType_VAL")  = 2
            case enumPartType.PartType_Stroka
              dr ("PartType")  = "Строка"
              dr ("PartType_VAL")  = 0
            case enumPartType.PartType_Rassirenie_s_dannimi
              dr ("PartType")  = "Расширение с данными"
              dr ("PartType_VAL")  = 4
            case enumPartType.PartType_Rassirenie
              dr ("PartType")  = "Расширение"
              dr ("PartType_VAL")  = 3
              end select 'PartType
             dr("Caption") =Caption
             dr("Name") =Name
             dr("the_Comment") =the_Comment
             select case NoLog
            case enumBoolean.Boolean_Da
              dr ("NoLog")  = "Да"
              dr ("NoLog_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("NoLog")  = "Нет"
              dr ("NoLog_VAL")  = 0
              end select 'NoLog
             select case ManualRegister
            case enumBoolean.Boolean_Da
              dr ("ManualRegister")  = "Да"
              dr ("ManualRegister_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ManualRegister")  = "Нет"
              dr ("ManualRegister_VAL")  = 0
              end select 'ManualRegister
             if OnCreate is nothing then
               dr("OnCreate") =system.dbnull.value
               dr("OnCreate_ID") =System.Guid.Empty
             else
               dr("OnCreate") =OnCreate.BRIEF
               dr("OnCreate_ID") =OnCreate.ID
             end if 
             if OnSave is nothing then
               dr("OnSave") =system.dbnull.value
               dr("OnSave_ID") =System.Guid.Empty
             else
               dr("OnSave") =OnSave.BRIEF
               dr("OnSave_ID") =OnSave.ID
             end if 
             if OnRun is nothing then
               dr("OnRun") =system.dbnull.value
               dr("OnRun_ID") =System.Guid.Empty
             else
               dr("OnRun") =OnRun.BRIEF
               dr("OnRun_ID") =OnRun.ID
             end if 
             if OnDelete is nothing then
               dr("OnDelete") =system.dbnull.value
               dr("OnDelete_ID") =System.Guid.Empty
             else
               dr("OnDelete") =OnDelete.BRIEF
               dr("OnDelete_ID") =OnDelete.ID
             end if 
             select case AddBehaivor
            case enumPartAddBehaivor.PartAddBehaivor_AddForm
              dr ("AddBehaivor")  = "AddForm"
              dr ("AddBehaivor_VAL")  = 0
            case enumPartAddBehaivor.PartAddBehaivor_RunAction
              dr ("AddBehaivor")  = "RunAction"
              dr ("AddBehaivor_VAL")  = 2
            case enumPartAddBehaivor.PartAddBehaivor_RefreshOnly
              dr ("AddBehaivor")  = "RefreshOnly"
              dr ("AddBehaivor_VAL")  = 1
              end select 'AddBehaivor
             if ExtenderObject is nothing then
               dr("ExtenderObject") =system.dbnull.value
               dr("ExtenderObject_ID") =System.Guid.Empty
             else
               dr("ExtenderObject") =ExtenderObject.BRIEF
               dr("ExtenderObject_ID") =ExtenderObject.ID
             end if 
             dr("shablonBrief") =shablonBrief
             dr("ruleBrief") =ruleBrief
             select case IsJormalChange
            case enumBoolean.Boolean_Da
              dr ("IsJormalChange")  = "Да"
              dr ("IsJormalChange_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsJormalChange")  = "Нет"
              dr ("IsJormalChange_VAL")  = 0
              end select 'IsJormalChange
             select case UseArchiving
            case enumBoolean.Boolean_Da
              dr ("UseArchiving")  = "Да"
              dr ("UseArchiving_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("UseArchiving")  = "Нет"
              dr ("UseArchiving_VAL")  = 0
              end select 'UseArchiving
             select case integerpkey
            case enumBoolean.Boolean_Da
              dr ("integerpkey")  = "Да"
              dr ("integerpkey_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("integerpkey")  = "Нет"
              dr ("integerpkey_VAL")  = 0
              end select 'integerpkey
             dr("partIconCls") =partIconCls
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
            mFindInside = PART.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = PARTMENU.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = PARTVIEW.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = VALIDATOR.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = UNIQUECONSTRAINT.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = ExtenderInterface.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELD.FindObject(table,RowID)
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
          nv.Add("Sequence", Sequence, dbtype.Int32)
          nv.Add("PartType", PartType, dbtype.int16)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("Name", Name, dbtype.string)
          nv.Add("the_Comment", the_Comment, dbtype.string)
          nv.Add("NoLog", NoLog, dbtype.int16)
          nv.Add("ManualRegister", ManualRegister, dbtype.int16)
          if m_OnCreate.Equals(System.Guid.Empty) then
            nv.Add("OnCreate", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnCreate", Application.Session.GetProvider.ID2Param(m_OnCreate), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnSave.Equals(System.Guid.Empty) then
            nv.Add("OnSave", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnSave", Application.Session.GetProvider.ID2Param(m_OnSave), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnRun.Equals(System.Guid.Empty) then
            nv.Add("OnRun", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnRun", Application.Session.GetProvider.ID2Param(m_OnRun), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_OnDelete.Equals(System.Guid.Empty) then
            nv.Add("OnDelete", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("OnDelete", Application.Session.GetProvider.ID2Param(m_OnDelete), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AddBehaivor", AddBehaivor, dbtype.int16)
          if m_ExtenderObject.Equals(System.Guid.Empty) then
            nv.Add("ExtenderObject", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ExtenderObject", Application.Session.GetProvider.ID2Param(m_ExtenderObject), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("shablonBrief", shablonBrief, dbtype.string)
          nv.Add("ruleBrief", ruleBrief, dbtype.string)
          nv.Add("IsJormalChange", IsJormalChange, dbtype.int16)
          nv.Add("UseArchiving", UseArchiving, dbtype.int16)
          nv.Add("integerpkey", integerpkey, dbtype.int16)
          nv.Add("partIconCls", partIconCls, dbtype.string)
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
          If reader.Table.Columns.Contains("Sequence") Then m_Sequence=reader.item("Sequence")
          If reader.Table.Columns.Contains("PartType") Then m_PartType=reader.item("PartType")
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("the_Comment") Then m_the_Comment=reader.item("the_Comment").ToString()
          If reader.Table.Columns.Contains("NoLog") Then m_NoLog=reader.item("NoLog")
          If reader.Table.Columns.Contains("ManualRegister") Then m_ManualRegister=reader.item("ManualRegister")
      If reader.Table.Columns.Contains("OnCreate") Then
          if isdbnull(reader.item("OnCreate")) then
            If reader.Table.Columns.Contains("OnCreate") Then m_OnCreate = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnCreate") Then m_OnCreate= New System.Guid(reader.item("OnCreate").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnSave") Then
          if isdbnull(reader.item("OnSave")) then
            If reader.Table.Columns.Contains("OnSave") Then m_OnSave = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnSave") Then m_OnSave= New System.Guid(reader.item("OnSave").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnRun") Then
          if isdbnull(reader.item("OnRun")) then
            If reader.Table.Columns.Contains("OnRun") Then m_OnRun = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnRun") Then m_OnRun= New System.Guid(reader.item("OnRun").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("OnDelete") Then
          if isdbnull(reader.item("OnDelete")) then
            If reader.Table.Columns.Contains("OnDelete") Then m_OnDelete = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("OnDelete") Then m_OnDelete= New System.Guid(reader.item("OnDelete").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AddBehaivor") Then m_AddBehaivor=reader.item("AddBehaivor")
      If reader.Table.Columns.Contains("ExtenderObject") Then
          if isdbnull(reader.item("ExtenderObject")) then
            If reader.Table.Columns.Contains("ExtenderObject") Then m_ExtenderObject = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ExtenderObject") Then m_ExtenderObject= New System.Guid(reader.item("ExtenderObject").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("shablonBrief") Then m_shablonBrief=reader.item("shablonBrief").ToString()
          If reader.Table.Columns.Contains("ruleBrief") Then m_ruleBrief=reader.item("ruleBrief").ToString()
          If reader.Table.Columns.Contains("IsJormalChange") Then m_IsJormalChange=reader.item("IsJormalChange")
          If reader.Table.Columns.Contains("UseArchiving") Then m_UseArchiving=reader.item("UseArchiving")
          If reader.Table.Columns.Contains("integerpkey") Then m_integerpkey=reader.item("integerpkey")
          If reader.Table.Columns.Contains("partIconCls") Then m_partIconCls=reader.item("partIconCls").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


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
'''Доступ к полю Тип структры
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property PartType() As enumPartType
            Get
                LoadFromDatabase()
                PartType = m_PartType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumPartType )
                LoadFromDatabase()
                m_PartType = Value
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
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Comment() As STRING
            Get
                LoadFromDatabase()
                the_Comment = m_the_Comment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_the_Comment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Не записывать в журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NoLog() As enumBoolean
            Get
                LoadFromDatabase()
                NoLog = m_NoLog
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_NoLog = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Исключить из индексирования
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ManualRegister() As enumBoolean
            Get
                LoadFromDatabase()
                ManualRegister = m_ManualRegister
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ManualRegister = Value
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
                OnCreate = me.application.Findrowobject("PARTMENU",m_OnCreate)
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
'''Доступ к полю При сохранении
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnSave() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnSave = me.application.Findrowobject("PARTMENU",m_OnSave)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_OnSave = Value.id
                else
                   m_OnSave=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю При открытии
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnRun() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnRun = me.application.Findrowobject("PARTMENU",m_OnRun)
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
'''Доступ к полю При удалении
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OnDelete() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                OnDelete = me.application.Findrowobject("PARTMENU",m_OnDelete)
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
'''Доступ к полю Поведение при добавлении
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AddBehaivor() As enumPartAddBehaivor
            Get
                LoadFromDatabase()
                AddBehaivor = m_AddBehaivor
                AccessTime = Now
            End Get
            Set(ByVal Value As enumPartAddBehaivor )
                LoadFromDatabase()
                m_AddBehaivor = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объект расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ExtenderObject() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                ExtenderObject = me.application.manager.GetInstanceObject(m_ExtenderObject)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_ExtenderObject = Value.id
                else
                  m_ExtenderObject =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Шаблон для краткого отображения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property shablonBrief() As String
            Get
                LoadFromDatabase()
                shablonBrief = m_shablonBrief
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_shablonBrief = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Правило составления BRIEF поля
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ruleBrief() As String
            Get
                LoadFromDatabase()
                ruleBrief = m_ruleBrief
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ruleBrief = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Вести журнал изменений
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsJormalChange() As enumBoolean
            Get
                LoadFromDatabase()
                IsJormalChange = m_IsJormalChange
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsJormalChange = Value
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
'''Доступ к полю Целочисленный ключ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property integerpkey() As enumBoolean
            Get
                LoadFromDatabase()
                integerpkey = m_integerpkey
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_integerpkey = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property partIconCls() As String
            Get
                LoadFromDatabase()
                partIconCls = m_partIconCls
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_partIconCls = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Методы раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property PARTMENU() As PARTMENU_col
            Get
                if  m_PARTMENU is nothing then
                  m_PARTMENU = new PARTMENU_col
                  m_PARTMENU.Parent = me
                  m_PARTMENU.Application = me.Application
                  m_PARTMENU.Refresh
                end if
                PARTMENU = m_PARTMENU
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property PARTVIEW() As PARTVIEW_col
            Get
                if  m_PARTVIEW is nothing then
                  m_PARTVIEW = new PARTVIEW_col
                  m_PARTVIEW.Parent = me
                  m_PARTVIEW.Application = me.Application
                  m_PARTVIEW.Refresh
                end if
                PARTVIEW = m_PARTVIEW
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Логика на форме
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property VALIDATOR() As VALIDATOR_col
            Get
                if  m_VALIDATOR is nothing then
                  m_VALIDATOR = new VALIDATOR_col
                  m_VALIDATOR.Parent = me
                  m_VALIDATOR.Application = me.Application
                  m_VALIDATOR.Refresh
                end if
                VALIDATOR = m_VALIDATOR
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Ограничение уникальности
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property UNIQUECONSTRAINT() As UNIQUECONSTRAINT_col
            Get
                if  m_UNIQUECONSTRAINT is nothing then
                  m_UNIQUECONSTRAINT = new UNIQUECONSTRAINT_col
                  m_UNIQUECONSTRAINT.Parent = me
                  m_UNIQUECONSTRAINT.Application = me.Application
                  m_UNIQUECONSTRAINT.Refresh
                end if
                UNIQUECONSTRAINT = m_UNIQUECONSTRAINT
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Интерфейсы расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ExtenderInterface() As ExtenderInterface_col
            Get
                if  m_ExtenderInterface is nothing then
                  m_ExtenderInterface = new ExtenderInterface_col
                  m_ExtenderInterface.Parent = me
                  m_ExtenderInterface.Application = me.Application
                  m_ExtenderInterface.Refresh
                end if
                ExtenderInterface = m_ExtenderInterface
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Поле
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELD() As FIELD_col
            Get
                if  m_FIELD is nothing then
                  m_FIELD = new FIELD_col
                  m_FIELD.Parent = me
                  m_FIELD.Application = me.Application
                  m_FIELD.Refresh
                end if
                FIELD = m_FIELD
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
            Sequence = node.Attributes.GetNamedItem("Sequence").Value
            PartType = node.Attributes.GetNamedItem("PartType").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            the_Comment = node.Attributes.GetNamedItem("the_Comment").Value
            NoLog = node.Attributes.GetNamedItem("NoLog").Value
            ManualRegister = node.Attributes.GetNamedItem("ManualRegister").Value
            m_OnCreate = new system.guid(node.Attributes.GetNamedItem("OnCreate").Value)
            m_OnSave = new system.guid(node.Attributes.GetNamedItem("OnSave").Value)
            m_OnRun = new system.guid(node.Attributes.GetNamedItem("OnRun").Value)
            m_OnDelete = new system.guid(node.Attributes.GetNamedItem("OnDelete").Value)
            AddBehaivor = node.Attributes.GetNamedItem("AddBehaivor").Value
            m_ExtenderObject = new system.guid(node.Attributes.GetNamedItem("ExtenderObject").Value)
            shablonBrief = node.Attributes.GetNamedItem("shablonBrief").Value
            ruleBrief = node.Attributes.GetNamedItem("ruleBrief").Value
            IsJormalChange = node.Attributes.GetNamedItem("IsJormalChange").Value
            UseArchiving = node.Attributes.GetNamedItem("UseArchiving").Value
            integerpkey = node.Attributes.GetNamedItem("integerpkey").Value
            partIconCls = node.Attributes.GetNamedItem("partIconCls").Value
            e_list = node.SelectNodes("PART_COL")
            PART.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("PARTMENU_COL")
            PARTMENU.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("PARTVIEW_COL")
            PARTVIEW.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("VALIDATOR_COL")
            VALIDATOR.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("UNIQUECONSTRAINT_COL")
            UNIQUECONSTRAINT.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("ExtenderInterface_COL")
            ExtenderInterface.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELD_COL")
            FIELD.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            PARTMENU.Dispose
            PARTVIEW.Dispose
            VALIDATOR.Dispose
            UNIQUECONSTRAINT.Dispose
            ExtenderInterface.Dispose
            FIELD.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("Sequence", Sequence)  
          node.SetAttribute("PartType", PartType)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("the_Comment", the_Comment)  
          node.SetAttribute("NoLog", NoLog)  
          node.SetAttribute("ManualRegister", ManualRegister)  
          node.SetAttribute("OnCreate", m_OnCreate.tostring)  
          node.SetAttribute("OnSave", m_OnSave.tostring)  
          node.SetAttribute("OnRun", m_OnRun.tostring)  
          node.SetAttribute("OnDelete", m_OnDelete.tostring)  
          node.SetAttribute("AddBehaivor", AddBehaivor)  
          node.SetAttribute("ExtenderObject", m_ExtenderObject.tostring)  
          node.SetAttribute("shablonBrief", shablonBrief)  
          node.SetAttribute("ruleBrief", ruleBrief)  
          node.SetAttribute("IsJormalChange", IsJormalChange)  
          node.SetAttribute("UseArchiving", UseArchiving)  
          node.SetAttribute("integerpkey", integerpkey)  
          node.SetAttribute("partIconCls", partIconCls)  
            PART.XMLSave(node,xdom)
            PARTMENU.XMLSave(node,xdom)
            PARTVIEW.XMLSave(node,xdom)
            VALIDATOR.XMLSave(node,xdom)
            UNIQUECONSTRAINT.XMLSave(node,xdom)
            ExtenderInterface.XMLSave(node,xdom)
            FIELD.XMLSave(node,xdom)
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
            PART.BatchUpdate
            PARTMENU.BatchUpdate
            PARTVIEW.BatchUpdate
            VALIDATOR.BatchUpdate
            UNIQUECONSTRAINT.BatchUpdate
            ExtenderInterface.BatchUpdate
            FIELD.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 6
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
            return FIELD
         Case 2
            return PARTMENU
         Case 3
            return UNIQUECONSTRAINT
         Case 4
            return VALIDATOR
         Case 5
            return PARTVIEW
         Case 6
            return ExtenderInterface
            End Select
            return nothing
        End Function
    End Class
End Namespace
