
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
'''Реализация строки раздела Поле
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELD
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Имя поля
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Может быть пустым
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowNull  as enumBoolean


''' <summary>
'''Локальная переменная для поля Маска
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheMask  as String


''' <summary>
'''Локальная переменная для поля Ссылка на раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefToPart  as System.Guid


''' <summary>
'''Локальная переменная для поля Имя вкладки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TabName  as String


''' <summary>
'''Локальная переменная для поля Нумератор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheNumerator  as System.Guid


''' <summary>
'''Локальная переменная для поля Шаблон для краткого отображения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_shablonBrief  as String


''' <summary>
'''Локальная переменная для поля Размер поля
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DataSize  as long


''' <summary>
'''Локальная переменная для поля Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Имя группы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FieldGroupBox  as String


''' <summary>
'''Локальная переменная для поля Стиль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheStyle  as String


''' <summary>
'''Локальная переменная для поля Шаблон зоны нумерации
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ZoneTemplate  as String


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Ссылка на тип
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefToType  as System.Guid


''' <summary>
'''Локальная переменная для поля Краткая информация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsBrief  as enumBoolean


''' <summary>
'''Локальная переменная для поля Тип поля
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FieldType  as System.Guid


''' <summary>
'''Локальная переменная для поля Автонумерация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsAutoNumber  as enumBoolean


''' <summary>
'''Локальная переменная для поля Тип ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReferenceType  as enumReferenceType


''' <summary>
'''Локальная переменная для поля № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Sequence  as long


''' <summary>
'''Локальная переменная для поля Ссылка в пределах объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_InternalReference  as enumBoolean


''' <summary>
'''Локальная переменная для поля Только создание объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CreateRefOnly  as enumBoolean


''' <summary>
'''Локальная переменная для поля Для отображения в таблице
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsTabBrief  as enumBoolean


''' <summary>
'''Локальная переменная для поля Имя класса для мастера строк
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theNameClass  as String


''' <summary>
'''Локальная переменная для поля Поле для расчета даты
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NumberDateField  as System.Guid


''' <summary>
'''Локальная переменная для дочернего раздела Интерфейсы расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FldExtenders As FldExtenders_col


''' <summary>
'''Локальная переменная для дочернего раздела Описание источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELDSRCDEF As FIELDSRCDEF_col


''' <summary>
'''Локальная переменная для дочернего раздела Динамический фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_DINAMICFILTERSCRIPT As DINAMICFILTERSCRIPT_col


''' <summary>
'''Локальная переменная для дочернего раздела Значение по умолчанию
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELDEXPRESSION As FIELDEXPRESSION_col


''' <summary>
'''Локальная переменная для дочернего раздела Логика поля на форме
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELDVALIDATOR As FIELDVALIDATOR_col


''' <summary>
'''Локальная переменная для дочернего раздела Методы поля
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELDMENU As FIELDMENU_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_AllowNull=   
            ' m_TheMask=   
            ' m_RefToPart=   
            ' m_TabName=   
            ' m_TheNumerator=   
            ' m_shablonBrief=   
            ' m_DataSize=   
            ' m_Caption=   
            ' m_FieldGroupBox=   
            ' m_TheStyle=   
            ' m_ZoneTemplate=   
            ' m_TheComment=   
            ' m_RefToType=   
            ' m_IsBrief=   
            ' m_FieldType=   
            ' m_IsAutoNumber=   
            ' m_ReferenceType=   
            ' m_Sequence=   
            ' m_InternalReference=   
            ' m_CreateRefOnly=   
            ' m_IsTabBrief=   
            ' m_theNameClass=   
            ' m_NumberDateField=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 24
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
                    Value = TabName
                Case 2
                    Value = FieldGroupBox
                Case 3
                    Value = Sequence
                Case 4
                    Value = Caption
                Case 5
                    Value = Name
                Case 6
                    Value = FieldType
                Case 7
                    Value = IsBrief
                Case 8
                    Value = IsTabBrief
                Case 9
                    Value = AllowNull
                Case 10
                    Value = DataSize
                Case 11
                    Value = ReferenceType
                Case 12
                    Value = RefToType
                Case 13
                    Value = RefToPart
                Case 14
                    Value = TheStyle
                Case 15
                    Value = InternalReference
                Case 16
                    Value = CreateRefOnly
                Case 17
                    Value = IsAutoNumber
                Case 18
                    Value = TheNumerator
                Case 19
                    Value = ZoneTemplate
                Case 20
                    Value = NumberDateField
                Case 21
                    Value = TheComment
                Case 22
                    Value = shablonBrief
                Case 23
                    Value = theNameClass
                Case 24
                    Value = TheMask
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
                    TabName = value
                Case 2
                    FieldGroupBox = value
                Case 3
                    Sequence = value
                Case 4
                    Caption = value
                Case 5
                    Name = value
                Case 6
                    FieldType = value
                Case 7
                    IsBrief = value
                Case 8
                    IsTabBrief = value
                Case 9
                    AllowNull = value
                Case 10
                    DataSize = value
                Case 11
                    ReferenceType = value
                Case 12
                    RefToType = value
                Case 13
                    RefToPart = value
                Case 14
                    TheStyle = value
                Case 15
                    InternalReference = value
                Case 16
                    CreateRefOnly = value
                Case 17
                    IsAutoNumber = value
                Case 18
                    TheNumerator = value
                Case 19
                    ZoneTemplate = value
                Case 20
                    NumberDateField = value
                Case 21
                    TheComment = value
                Case 22
                    shablonBrief = value
                Case 23
                    theNameClass = value
                Case 24
                    TheMask = value
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
                    Return "TabName"
                Case 2
                    Return "FieldGroupBox"
                Case 3
                    Return "Sequence"
                Case 4
                    Return "Caption"
                Case 5
                    Return "Name"
                Case 6
                    Return "FieldType"
                Case 7
                    Return "IsBrief"
                Case 8
                    Return "IsTabBrief"
                Case 9
                    Return "AllowNull"
                Case 10
                    Return "DataSize"
                Case 11
                    Return "ReferenceType"
                Case 12
                    Return "RefToType"
                Case 13
                    Return "RefToPart"
                Case 14
                    Return "TheStyle"
                Case 15
                    Return "InternalReference"
                Case 16
                    Return "CreateRefOnly"
                Case 17
                    Return "IsAutoNumber"
                Case 18
                    Return "TheNumerator"
                Case 19
                    Return "ZoneTemplate"
                Case 20
                    Return "NumberDateField"
                Case 21
                    Return "TheComment"
                Case 22
                    Return "shablonBrief"
                Case 23
                    Return "theNameClass"
                Case 24
                    Return "TheMask"
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
             dr("TabName") =TabName
             dr("FieldGroupBox") =FieldGroupBox
             dr("Sequence") =Sequence
             dr("Caption") =Caption
             dr("Name") =Name
             if FieldType is nothing then
               dr("FieldType") =system.dbnull.value
               dr("FieldType_ID") =System.Guid.Empty
             else
               dr("FieldType") =FieldType.BRIEF
               dr("FieldType_ID") =FieldType.ID
             end if 
             select case IsBrief
            case enumBoolean.Boolean_Da
              dr ("IsBrief")  = "Да"
              dr ("IsBrief_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsBrief")  = "Нет"
              dr ("IsBrief_VAL")  = 0
              end select 'IsBrief
             select case IsTabBrief
            case enumBoolean.Boolean_Da
              dr ("IsTabBrief")  = "Да"
              dr ("IsTabBrief_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsTabBrief")  = "Нет"
              dr ("IsTabBrief_VAL")  = 0
              end select 'IsTabBrief
             select case AllowNull
            case enumBoolean.Boolean_Da
              dr ("AllowNull")  = "Да"
              dr ("AllowNull_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowNull")  = "Нет"
              dr ("AllowNull_VAL")  = 0
              end select 'AllowNull
             dr("DataSize") =DataSize
             select case ReferenceType
            case enumReferenceType.ReferenceType_Na_istocnik_dannih
              dr ("ReferenceType")  = "На источник данных"
              dr ("ReferenceType_VAL")  = 3
            case enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS
              dr ("ReferenceType")  = "Скалярное поле ( не ссылка)"
              dr ("ReferenceType_VAL")  = 0
            case enumReferenceType.ReferenceType_Na_stroku_razdela
              dr ("ReferenceType")  = "На строку раздела"
              dr ("ReferenceType_VAL")  = 2
            case enumReferenceType.ReferenceType_Na_ob_ekt_
              dr ("ReferenceType")  = "На объект "
              dr ("ReferenceType_VAL")  = 1
              end select 'ReferenceType
             if RefToType is nothing then
               dr("RefToType") =system.dbnull.value
               dr("RefToType_ID") =System.Guid.Empty
             else
               dr("RefToType") =RefToType.BRIEF
               dr("RefToType_ID") =RefToType.ID
             end if 
             if RefToPart is nothing then
               dr("RefToPart") =system.dbnull.value
               dr("RefToPart_ID") =System.Guid.Empty
             else
               dr("RefToPart") =RefToPart.BRIEF
               dr("RefToPart_ID") =RefToPart.ID
             end if 
             dr("TheStyle") =TheStyle
             select case InternalReference
            case enumBoolean.Boolean_Da
              dr ("InternalReference")  = "Да"
              dr ("InternalReference_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("InternalReference")  = "Нет"
              dr ("InternalReference_VAL")  = 0
              end select 'InternalReference
             select case CreateRefOnly
            case enumBoolean.Boolean_Da
              dr ("CreateRefOnly")  = "Да"
              dr ("CreateRefOnly_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("CreateRefOnly")  = "Нет"
              dr ("CreateRefOnly_VAL")  = 0
              end select 'CreateRefOnly
             select case IsAutoNumber
            case enumBoolean.Boolean_Da
              dr ("IsAutoNumber")  = "Да"
              dr ("IsAutoNumber_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsAutoNumber")  = "Нет"
              dr ("IsAutoNumber_VAL")  = 0
              end select 'IsAutoNumber
             if TheNumerator is nothing then
               dr("TheNumerator") =system.dbnull.value
               dr("TheNumerator_ID") =System.Guid.Empty
             else
               dr("TheNumerator") =TheNumerator.BRIEF
               dr("TheNumerator_ID") =TheNumerator.ID
             end if 
             dr("ZoneTemplate") =ZoneTemplate
             if NumberDateField is nothing then
               dr("NumberDateField") =system.dbnull.value
               dr("NumberDateField_ID") =System.Guid.Empty
             else
               dr("NumberDateField") =NumberDateField.BRIEF
               dr("NumberDateField_ID") =NumberDateField.ID
             end if 
             dr("TheComment") =TheComment
             dr("shablonBrief") =shablonBrief
             dr("theNameClass") =theNameClass
             dr("TheMask") =TheMask
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
            mFindInside = FldExtenders.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELDSRCDEF.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = DINAMICFILTERSCRIPT.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELDEXPRESSION.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELDVALIDATOR.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELDMENU.FindObject(table,RowID)
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
          nv.Add("TabName", TabName, dbtype.string)
          nv.Add("FieldGroupBox", FieldGroupBox, dbtype.string)
          nv.Add("Sequence", Sequence, dbtype.Int32)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("Name", Name, dbtype.string)
          if m_FieldType.Equals(System.Guid.Empty) then
            nv.Add("FieldType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("FieldType", Application.Session.GetProvider.ID2Param(m_FieldType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("IsBrief", IsBrief, dbtype.int16)
          nv.Add("IsTabBrief", IsTabBrief, dbtype.int16)
          nv.Add("AllowNull", AllowNull, dbtype.int16)
          nv.Add("DataSize", DataSize, dbtype.Int32)
          nv.Add("ReferenceType", ReferenceType, dbtype.int16)
          if m_RefToType.Equals(System.Guid.Empty) then
            nv.Add("RefToType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("RefToType", Application.Session.GetProvider.ID2Param(m_RefToType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_RefToPart.Equals(System.Guid.Empty) then
            nv.Add("RefToPart", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("RefToPart", Application.Session.GetProvider.ID2Param(m_RefToPart), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("TheStyle", TheStyle, dbtype.string)
          nv.Add("InternalReference", InternalReference, dbtype.int16)
          nv.Add("CreateRefOnly", CreateRefOnly, dbtype.int16)
          nv.Add("IsAutoNumber", IsAutoNumber, dbtype.int16)
          if m_TheNumerator.Equals(System.Guid.Empty) then
            nv.Add("TheNumerator", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheNumerator", Application.Session.GetProvider.ID2Param(m_TheNumerator), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("ZoneTemplate", ZoneTemplate, dbtype.string)
          if m_NumberDateField.Equals(System.Guid.Empty) then
            nv.Add("NumberDateField", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("NumberDateField", Application.Session.GetProvider.ID2Param(m_NumberDateField), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("TheComment", TheComment, dbtype.string)
          nv.Add("shablonBrief", shablonBrief, dbtype.string)
          nv.Add("theNameClass", theNameClass, dbtype.string)
          nv.Add("TheMask", TheMask, dbtype.string)
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
          If reader.Table.Columns.Contains("TabName") Then m_TabName=reader.item("TabName").ToString()
          If reader.Table.Columns.Contains("FieldGroupBox") Then m_FieldGroupBox=reader.item("FieldGroupBox").ToString()
          If reader.Table.Columns.Contains("Sequence") Then m_Sequence=reader.item("Sequence")
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
      If reader.Table.Columns.Contains("FieldType") Then
          if isdbnull(reader.item("FieldType")) then
            If reader.Table.Columns.Contains("FieldType") Then m_FieldType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("FieldType") Then m_FieldType= New System.Guid(reader.item("FieldType").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("IsBrief") Then m_IsBrief=reader.item("IsBrief")
          If reader.Table.Columns.Contains("IsTabBrief") Then m_IsTabBrief=reader.item("IsTabBrief")
          If reader.Table.Columns.Contains("AllowNull") Then m_AllowNull=reader.item("AllowNull")
          If reader.Table.Columns.Contains("DataSize") Then m_DataSize=reader.item("DataSize")
          If reader.Table.Columns.Contains("ReferenceType") Then m_ReferenceType=reader.item("ReferenceType")
      If reader.Table.Columns.Contains("RefToType") Then
          if isdbnull(reader.item("RefToType")) then
            If reader.Table.Columns.Contains("RefToType") Then m_RefToType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("RefToType") Then m_RefToType= New System.Guid(reader.item("RefToType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("RefToPart") Then
          if isdbnull(reader.item("RefToPart")) then
            If reader.Table.Columns.Contains("RefToPart") Then m_RefToPart = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("RefToPart") Then m_RefToPart= New System.Guid(reader.item("RefToPart").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("TheStyle") Then m_TheStyle=reader.item("TheStyle").ToString()
          If reader.Table.Columns.Contains("InternalReference") Then m_InternalReference=reader.item("InternalReference")
          If reader.Table.Columns.Contains("CreateRefOnly") Then m_CreateRefOnly=reader.item("CreateRefOnly")
          If reader.Table.Columns.Contains("IsAutoNumber") Then m_IsAutoNumber=reader.item("IsAutoNumber")
      If reader.Table.Columns.Contains("TheNumerator") Then
          if isdbnull(reader.item("TheNumerator")) then
            If reader.Table.Columns.Contains("TheNumerator") Then m_TheNumerator = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheNumerator") Then m_TheNumerator= New System.Guid(reader.item("TheNumerator").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("ZoneTemplate") Then m_ZoneTemplate=reader.item("ZoneTemplate").ToString()
      If reader.Table.Columns.Contains("NumberDateField") Then
          if isdbnull(reader.item("NumberDateField")) then
            If reader.Table.Columns.Contains("NumberDateField") Then m_NumberDateField = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("NumberDateField") Then m_NumberDateField= New System.Guid(reader.item("NumberDateField").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
          If reader.Table.Columns.Contains("shablonBrief") Then m_shablonBrief=reader.item("shablonBrief").ToString()
          If reader.Table.Columns.Contains("theNameClass") Then m_theNameClass=reader.item("theNameClass").ToString()
          If reader.Table.Columns.Contains("TheMask") Then m_TheMask=reader.item("TheMask").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Имя вкладки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TabName() As String
            Get
                LoadFromDatabase()
                TabName = m_TabName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TabName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя группы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FieldGroupBox() As String
            Get
                LoadFromDatabase()
                FieldGroupBox = m_FieldGroupBox
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FieldGroupBox = Value
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
'''Доступ к полю Имя поля
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
'''Доступ к полю Тип поля
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FieldType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                FieldType = me.application.Findrowobject("FIELDTYPE",m_FieldType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_FieldType = Value.id
                else
                   m_FieldType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Краткая информация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsBrief() As enumBoolean
            Get
                LoadFromDatabase()
                IsBrief = m_IsBrief
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsBrief = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Для отображения в таблице
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsTabBrief() As enumBoolean
            Get
                LoadFromDatabase()
                IsTabBrief = m_IsTabBrief
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsTabBrief = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Может быть пустым
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowNull() As enumBoolean
            Get
                LoadFromDatabase()
                AllowNull = m_AllowNull
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowNull = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Размер поля
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DataSize() As long
            Get
                LoadFromDatabase()
                DataSize = m_DataSize
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_DataSize = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReferenceType() As enumReferenceType
            Get
                LoadFromDatabase()
                ReferenceType = m_ReferenceType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumReferenceType )
                LoadFromDatabase()
                m_ReferenceType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ссылка на тип
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefToType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                RefToType = me.application.Findrowobject("OBJECTTYPE",m_RefToType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_RefToType = Value.id
                else
                   m_RefToType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ссылка на раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefToPart() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                RefToPart = me.application.Findrowobject("PART",m_RefToPart)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_RefToPart = Value.id
                else
                   m_RefToPart=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Стиль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheStyle() As String
            Get
                LoadFromDatabase()
                TheStyle = m_TheStyle
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheStyle = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ссылка в пределах объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property InternalReference() As enumBoolean
            Get
                LoadFromDatabase()
                InternalReference = m_InternalReference
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_InternalReference = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Только создание объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CreateRefOnly() As enumBoolean
            Get
                LoadFromDatabase()
                CreateRefOnly = m_CreateRefOnly
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_CreateRefOnly = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Автонумерация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsAutoNumber() As enumBoolean
            Get
                LoadFromDatabase()
                IsAutoNumber = m_IsAutoNumber
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsAutoNumber = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нумератор
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheNumerator() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                TheNumerator = me.application.manager.GetInstanceObject(m_TheNumerator)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_TheNumerator = Value.id
                else
                  m_TheNumerator =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Шаблон зоны нумерации
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ZoneTemplate() As String
            Get
                LoadFromDatabase()
                ZoneTemplate = m_ZoneTemplate
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ZoneTemplate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле для расчета даты
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NumberDateField() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                NumberDateField = me.application.Findrowobject("FIELD",m_NumberDateField)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_NumberDateField = Value.id
                else
                   m_NumberDateField=System.Guid.Empty
                end if
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
'''Доступ к полю Имя класса для мастера строк
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property theNameClass() As String
            Get
                LoadFromDatabase()
                theNameClass = m_theNameClass
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_theNameClass = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Маска
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheMask() As String
            Get
                LoadFromDatabase()
                TheMask = m_TheMask
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheMask = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Интерфейсы расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FldExtenders() As FldExtenders_col
            Get
                if  m_FldExtenders is nothing then
                  m_FldExtenders = new FldExtenders_col
                  m_FldExtenders.Parent = me
                  m_FldExtenders.Application = me.Application
                  m_FldExtenders.Refresh
                end if
                FldExtenders = m_FldExtenders
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Описание источника данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELDSRCDEF() As FIELDSRCDEF_col
            Get
                if  m_FIELDSRCDEF is nothing then
                  m_FIELDSRCDEF = new FIELDSRCDEF_col
                  m_FIELDSRCDEF.Parent = me
                  m_FIELDSRCDEF.Application = me.Application
                  m_FIELDSRCDEF.Refresh
                end if
                FIELDSRCDEF = m_FIELDSRCDEF
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Динамический фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property DINAMICFILTERSCRIPT() As DINAMICFILTERSCRIPT_col
            Get
                if  m_DINAMICFILTERSCRIPT is nothing then
                  m_DINAMICFILTERSCRIPT = new DINAMICFILTERSCRIPT_col
                  m_DINAMICFILTERSCRIPT.Parent = me
                  m_DINAMICFILTERSCRIPT.Application = me.Application
                  m_DINAMICFILTERSCRIPT.Refresh
                end if
                DINAMICFILTERSCRIPT = m_DINAMICFILTERSCRIPT
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Значение по умолчанию
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELDEXPRESSION() As FIELDEXPRESSION_col
            Get
                if  m_FIELDEXPRESSION is nothing then
                  m_FIELDEXPRESSION = new FIELDEXPRESSION_col
                  m_FIELDEXPRESSION.Parent = me
                  m_FIELDEXPRESSION.Application = me.Application
                  m_FIELDEXPRESSION.Refresh
                end if
                FIELDEXPRESSION = m_FIELDEXPRESSION
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Логика поля на форме
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELDVALIDATOR() As FIELDVALIDATOR_col
            Get
                if  m_FIELDVALIDATOR is nothing then
                  m_FIELDVALIDATOR = new FIELDVALIDATOR_col
                  m_FIELDVALIDATOR.Parent = me
                  m_FIELDVALIDATOR.Application = me.Application
                  m_FIELDVALIDATOR.Refresh
                end if
                FIELDVALIDATOR = m_FIELDVALIDATOR
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Методы поля
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELDMENU() As FIELDMENU_col
            Get
                if  m_FIELDMENU is nothing then
                  m_FIELDMENU = new FIELDMENU_col
                  m_FIELDMENU.Parent = me
                  m_FIELDMENU.Application = me.Application
                  m_FIELDMENU.Refresh
                end if
                FIELDMENU = m_FIELDMENU
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
            TabName = node.Attributes.GetNamedItem("TabName").Value
            FieldGroupBox = node.Attributes.GetNamedItem("FieldGroupBox").Value
            Sequence = node.Attributes.GetNamedItem("Sequence").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            m_FieldType = new system.guid(node.Attributes.GetNamedItem("FieldType").Value)
            IsBrief = node.Attributes.GetNamedItem("IsBrief").Value
            IsTabBrief = node.Attributes.GetNamedItem("IsTabBrief").Value
            AllowNull = node.Attributes.GetNamedItem("AllowNull").Value
            DataSize = node.Attributes.GetNamedItem("DataSize").Value
            ReferenceType = node.Attributes.GetNamedItem("ReferenceType").Value
            m_RefToType = new system.guid(node.Attributes.GetNamedItem("RefToType").Value)
            m_RefToPart = new system.guid(node.Attributes.GetNamedItem("RefToPart").Value)
            TheStyle = node.Attributes.GetNamedItem("TheStyle").Value
            InternalReference = node.Attributes.GetNamedItem("InternalReference").Value
            CreateRefOnly = node.Attributes.GetNamedItem("CreateRefOnly").Value
            IsAutoNumber = node.Attributes.GetNamedItem("IsAutoNumber").Value
            m_TheNumerator = new system.guid(node.Attributes.GetNamedItem("TheNumerator").Value)
            ZoneTemplate = node.Attributes.GetNamedItem("ZoneTemplate").Value
            m_NumberDateField = new system.guid(node.Attributes.GetNamedItem("NumberDateField").Value)
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            shablonBrief = node.Attributes.GetNamedItem("shablonBrief").Value
            theNameClass = node.Attributes.GetNamedItem("theNameClass").Value
            TheMask = node.Attributes.GetNamedItem("TheMask").Value
            e_list = node.SelectNodes("FldExtenders_COL")
            FldExtenders.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELDSRCDEF_COL")
            FIELDSRCDEF.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("DINAMICFILTERSCRIPT_COL")
            DINAMICFILTERSCRIPT.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELDEXPRESSION_COL")
            FIELDEXPRESSION.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELDVALIDATOR_COL")
            FIELDVALIDATOR.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELDMENU_COL")
            FIELDMENU.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            FldExtenders.Dispose
            FIELDSRCDEF.Dispose
            DINAMICFILTERSCRIPT.Dispose
            FIELDEXPRESSION.Dispose
            FIELDVALIDATOR.Dispose
            FIELDMENU.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("TabName", TabName)  
          node.SetAttribute("FieldGroupBox", FieldGroupBox)  
          node.SetAttribute("Sequence", Sequence)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("FieldType", m_FieldType.tostring)  
          node.SetAttribute("IsBrief", IsBrief)  
          node.SetAttribute("IsTabBrief", IsTabBrief)  
          node.SetAttribute("AllowNull", AllowNull)  
          node.SetAttribute("DataSize", DataSize)  
          node.SetAttribute("ReferenceType", ReferenceType)  
          node.SetAttribute("RefToType", m_RefToType.tostring)  
          node.SetAttribute("RefToPart", m_RefToPart.tostring)  
          node.SetAttribute("TheStyle", TheStyle)  
          node.SetAttribute("InternalReference", InternalReference)  
          node.SetAttribute("CreateRefOnly", CreateRefOnly)  
          node.SetAttribute("IsAutoNumber", IsAutoNumber)  
          node.SetAttribute("TheNumerator", m_TheNumerator.tostring)  
          node.SetAttribute("ZoneTemplate", ZoneTemplate)  
          node.SetAttribute("NumberDateField", m_NumberDateField.tostring)  
          node.SetAttribute("TheComment", TheComment)  
          node.SetAttribute("shablonBrief", shablonBrief)  
          node.SetAttribute("theNameClass", theNameClass)  
          node.SetAttribute("TheMask", TheMask)  
            FldExtenders.XMLSave(node,xdom)
            FIELDSRCDEF.XMLSave(node,xdom)
            DINAMICFILTERSCRIPT.XMLSave(node,xdom)
            FIELDEXPRESSION.XMLSave(node,xdom)
            FIELDVALIDATOR.XMLSave(node,xdom)
            FIELDMENU.XMLSave(node,xdom)
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
            FldExtenders.BatchUpdate
            FIELDSRCDEF.BatchUpdate
            DINAMICFILTERSCRIPT.BatchUpdate
            FIELDEXPRESSION.BatchUpdate
            FIELDVALIDATOR.BatchUpdate
            FIELDMENU.BatchUpdate
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
            return FIELDMENU
         Case 2
            return DINAMICFILTERSCRIPT
         Case 3
            return FIELDVALIDATOR
         Case 4
            return FIELDEXPRESSION
         Case 5
            return FIELDSRCDEF
         Case 6
            return FldExtenders
            End Select
            return nothing
        End Function
    End Class
End Namespace
