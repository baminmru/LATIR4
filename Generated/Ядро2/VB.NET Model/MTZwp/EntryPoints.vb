
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZwp


''' <summary>
'''Реализация строки раздела Меню
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class EntryPoints
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Примечание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Разрешена печать
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowPrint  as enumBoolean


''' <summary>
'''Локальная переменная для поля Файл картинки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IconFile  as String


''' <summary>
'''Локальная переменная для поля Разрешен фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowFilter  as enumBoolean


''' <summary>
'''Локальная переменная для поля Фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheFilter  as System.Guid


''' <summary>
'''Локальная переменная для поля Ограничения к журналу
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_JournalFixedQuery  as STRING


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Отчет
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Report  as System.Guid


''' <summary>
'''Локальная переменная для поля Документ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Document  as System.Guid


''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Расширение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheExtention  as System.Guid


''' <summary>
'''Локальная переменная для поля АРМ
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ARM  as System.Guid


''' <summary>
'''Локальная переменная для поля Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ObjectType  as System.Guid


''' <summary>
'''Локальная переменная для поля Разрешено добавление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowAdd  as enumBoolean


''' <summary>
'''Локальная переменная для поля Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Journal  as System.Guid


''' <summary>
'''Локальная переменная для поля Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Method  as System.Guid


''' <summary>
'''Локальная переменная для поля Разрешено редактирование
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowEdit  as enumBoolean


''' <summary>
'''Локальная переменная для поля Рарешено удаление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowDel  as enumBoolean


''' <summary>
'''Локальная переменная для поля Включить в тулбар
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AsToolbarItem  as enumBoolean


''' <summary>
'''Локальная переменная для поля Вариант действия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ActionType  as enumMenuActionType


''' <summary>
'''Локальная переменная для поля Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_sequence  as long


''' <summary>
'''Локальная переменная для дочернего раздела Привязка фильтра
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_EPFilterLink As EPFilterLink_col


''' <summary>
'''Локальная переменная для дочерних записей раздела Меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_EntryPoints As EntryPoints_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheComment=   
            ' m_AllowPrint=   
            ' m_IconFile=   
            ' m_AllowFilter=   
            ' m_TheFilter=   
            ' m_JournalFixedQuery=   
            ' m_Name=   
            ' m_Report=   
            ' m_Document=   
            ' m_Caption=   
            ' m_TheExtention=   
            ' m_ARM=   
            ' m_ObjectType=   
            ' m_AllowAdd=   
            ' m_Journal=   
            ' m_Method=   
            ' m_AllowEdit=   
            ' m_AllowDel=   
            ' m_AsToolbarItem=   
            ' m_ActionType=   
            ' m_sequence=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 21
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
                    Value = sequence
                Case 2
                    Value = Name
                Case 3
                    Value = Caption
                Case 4
                    Value = AsToolbarItem
                Case 5
                    Value = ActionType
                Case 6
                    Value = TheFilter
                Case 7
                    Value = Journal
                Case 8
                    Value = Report
                Case 9
                    Value = Document
                Case 10
                    Value = Method
                Case 11
                    Value = IconFile
                Case 12
                    Value = TheExtention
                Case 13
                    Value = ARM
                Case 14
                    Value = TheComment
                Case 15
                    Value = ObjectType
                Case 16
                    Value = JournalFixedQuery
                Case 17
                    Value = AllowAdd
                Case 18
                    Value = AllowEdit
                Case 19
                    Value = AllowDel
                Case 20
                    Value = AllowFilter
                Case 21
                    Value = AllowPrint
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
                    sequence = value
                Case 2
                    Name = value
                Case 3
                    Caption = value
                Case 4
                    AsToolbarItem = value
                Case 5
                    ActionType = value
                Case 6
                    TheFilter = value
                Case 7
                    Journal = value
                Case 8
                    Report = value
                Case 9
                    Document = value
                Case 10
                    Method = value
                Case 11
                    IconFile = value
                Case 12
                    TheExtention = value
                Case 13
                    ARM = value
                Case 14
                    TheComment = value
                Case 15
                    ObjectType = value
                Case 16
                    JournalFixedQuery = value
                Case 17
                    AllowAdd = value
                Case 18
                    AllowEdit = value
                Case 19
                    AllowDel = value
                Case 20
                    AllowFilter = value
                Case 21
                    AllowPrint = value
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
                    Return "sequence"
                Case 2
                    Return "Name"
                Case 3
                    Return "Caption"
                Case 4
                    Return "AsToolbarItem"
                Case 5
                    Return "ActionType"
                Case 6
                    Return "TheFilter"
                Case 7
                    Return "Journal"
                Case 8
                    Return "Report"
                Case 9
                    Return "Document"
                Case 10
                    Return "Method"
                Case 11
                    Return "IconFile"
                Case 12
                    Return "TheExtention"
                Case 13
                    Return "ARM"
                Case 14
                    Return "TheComment"
                Case 15
                    Return "ObjectType"
                Case 16
                    Return "JournalFixedQuery"
                Case 17
                    Return "AllowAdd"
                Case 18
                    Return "AllowEdit"
                Case 19
                    Return "AllowDel"
                Case 20
                    Return "AllowFilter"
                Case 21
                    Return "AllowPrint"
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
             dr("sequence") =sequence
             dr("Name") =Name
             dr("Caption") =Caption
             select case AsToolbarItem
            case enumBoolean.Boolean_Da
              dr ("AsToolbarItem")  = "Да"
              dr ("AsToolbarItem_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AsToolbarItem")  = "Нет"
              dr ("AsToolbarItem_VAL")  = 0
              end select 'AsToolbarItem
             select case ActionType
            case enumMenuActionType.MenuActionType_Zapustit__ARM
              dr ("ActionType")  = "Запустить АРМ"
              dr ("ActionType_VAL")  = 4
            case enumMenuActionType.MenuActionType_Vipolnit__metod
              dr ("ActionType")  = "Выполнить метод"
              dr ("ActionType_VAL")  = 2
            case enumMenuActionType.MenuActionType_Otkrit__otcet
              dr ("ActionType")  = "Открыть отчет"
              dr ("ActionType_VAL")  = 5
            case enumMenuActionType.MenuActionType_Nicego_ne_delat_
              dr ("ActionType")  = "Ничего не делать"
              dr ("ActionType_VAL")  = 0
            case enumMenuActionType.MenuActionType_Otkrit__dokument
              dr ("ActionType")  = "Открыть документ"
              dr ("ActionType_VAL")  = 1
            case enumMenuActionType.MenuActionType_Otkrit__gurnal
              dr ("ActionType")  = "Открыть журнал"
              dr ("ActionType_VAL")  = 3
              end select 'ActionType
             if TheFilter is nothing then
               dr("TheFilter") =system.dbnull.value
               dr("TheFilter_ID") =System.Guid.Empty
             else
               dr("TheFilter") =TheFilter.BRIEF
               dr("TheFilter_ID") =TheFilter.ID
             end if 
             if Journal is nothing then
               dr("Journal") =system.dbnull.value
               dr("Journal_ID") =System.Guid.Empty
             else
               dr("Journal") =Journal.BRIEF
               dr("Journal_ID") =Journal.ID
             end if 
             if Report is nothing then
               dr("Report") =system.dbnull.value
               dr("Report_ID") =System.Guid.Empty
             else
               dr("Report") =Report.BRIEF
               dr("Report_ID") =Report.ID
             end if 
             if Document is nothing then
               dr("Document") =system.dbnull.value
               dr("Document_ID") =System.Guid.Empty
             else
               dr("Document") =Document.BRIEF
               dr("Document_ID") =Document.ID
             end if 
             if Method is nothing then
               dr("Method") =system.dbnull.value
               dr("Method_ID") =System.Guid.Empty
             else
               dr("Method") =Method.BRIEF
               dr("Method_ID") =Method.ID
             end if 
             dr("IconFile") =IconFile
             if TheExtention is nothing then
               dr("TheExtention") =system.dbnull.value
               dr("TheExtention_ID") =System.Guid.Empty
             else
               dr("TheExtention") =TheExtention.BRIEF
               dr("TheExtention_ID") =TheExtention.ID
             end if 
             if ARM is nothing then
               dr("ARM") =system.dbnull.value
               dr("ARM_ID") =System.Guid.Empty
             else
               dr("ARM") =ARM.BRIEF
               dr("ARM_ID") =ARM.ID
             end if 
             dr("TheComment") =TheComment
             if ObjectType is nothing then
               dr("ObjectType") =system.dbnull.value
               dr("ObjectType_ID") =System.Guid.Empty
             else
               dr("ObjectType") =ObjectType.BRIEF
               dr("ObjectType_ID") =ObjectType.ID
             end if 
             dr("JournalFixedQuery") =JournalFixedQuery
             select case AllowAdd
            case enumBoolean.Boolean_Da
              dr ("AllowAdd")  = "Да"
              dr ("AllowAdd_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowAdd")  = "Нет"
              dr ("AllowAdd_VAL")  = 0
              end select 'AllowAdd
             select case AllowEdit
            case enumBoolean.Boolean_Da
              dr ("AllowEdit")  = "Да"
              dr ("AllowEdit_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowEdit")  = "Нет"
              dr ("AllowEdit_VAL")  = 0
              end select 'AllowEdit
             select case AllowDel
            case enumBoolean.Boolean_Da
              dr ("AllowDel")  = "Да"
              dr ("AllowDel_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowDel")  = "Нет"
              dr ("AllowDel_VAL")  = 0
              end select 'AllowDel
             select case AllowFilter
            case enumBoolean.Boolean_Da
              dr ("AllowFilter")  = "Да"
              dr ("AllowFilter_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowFilter")  = "Нет"
              dr ("AllowFilter_VAL")  = 0
              end select 'AllowFilter
             select case AllowPrint
            case enumBoolean.Boolean_Da
              dr ("AllowPrint")  = "Да"
              dr ("AllowPrint_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowPrint")  = "Нет"
              dr ("AllowPrint_VAL")  = 0
              end select 'AllowPrint
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
            mFindInside = EntryPoints.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = EPFilterLink.FindObject(table,RowID)
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
          nv.Add("sequence", sequence, dbtype.Int32)
          nv.Add("Name", Name, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("AsToolbarItem", AsToolbarItem, dbtype.int16)
          nv.Add("ActionType", ActionType, dbtype.int16)
          if m_TheFilter.Equals(System.Guid.Empty) then
            nv.Add("TheFilter", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheFilter", Application.Session.GetProvider.ID2Param(m_TheFilter), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Journal.Equals(System.Guid.Empty) then
            nv.Add("Journal", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Journal", Application.Session.GetProvider.ID2Param(m_Journal), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Report.Equals(System.Guid.Empty) then
            nv.Add("Report", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Report", Application.Session.GetProvider.ID2Param(m_Report), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Document.Equals(System.Guid.Empty) then
            nv.Add("Document", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Document", Application.Session.GetProvider.ID2Param(m_Document), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Method.Equals(System.Guid.Empty) then
            nv.Add("Method", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Method", Application.Session.GetProvider.ID2Param(m_Method), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("IconFile", IconFile, dbtype.string)
          if m_TheExtention.Equals(System.Guid.Empty) then
            nv.Add("TheExtention", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheExtention", Application.Session.GetProvider.ID2Param(m_TheExtention), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_ARM.Equals(System.Guid.Empty) then
            nv.Add("ARM", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ARM", Application.Session.GetProvider.ID2Param(m_ARM), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("TheComment", TheComment, dbtype.string)
          if m_ObjectType.Equals(System.Guid.Empty) then
            nv.Add("ObjectType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ObjectType", Application.Session.GetProvider.ID2Param(m_ObjectType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("JournalFixedQuery", JournalFixedQuery, dbtype.string)
          nv.Add("AllowAdd", AllowAdd, dbtype.int16)
          nv.Add("AllowEdit", AllowEdit, dbtype.int16)
          nv.Add("AllowDel", AllowDel, dbtype.int16)
          nv.Add("AllowFilter", AllowFilter, dbtype.int16)
          nv.Add("AllowPrint", AllowPrint, dbtype.int16)
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
          If reader.Table.Columns.Contains("sequence") Then m_sequence=reader.item("sequence")
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("AsToolbarItem") Then m_AsToolbarItem=reader.item("AsToolbarItem")
          If reader.Table.Columns.Contains("ActionType") Then m_ActionType=reader.item("ActionType")
      If reader.Table.Columns.Contains("TheFilter") Then
          if isdbnull(reader.item("TheFilter")) then
            If reader.Table.Columns.Contains("TheFilter") Then m_TheFilter = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheFilter") Then m_TheFilter= New System.Guid(reader.item("TheFilter").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Journal") Then
          if isdbnull(reader.item("Journal")) then
            If reader.Table.Columns.Contains("Journal") Then m_Journal = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Journal") Then m_Journal= New System.Guid(reader.item("Journal").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Report") Then
          if isdbnull(reader.item("Report")) then
            If reader.Table.Columns.Contains("Report") Then m_Report = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Report") Then m_Report= New System.Guid(reader.item("Report").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Document") Then
          if isdbnull(reader.item("Document")) then
            If reader.Table.Columns.Contains("Document") Then m_Document = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Document") Then m_Document= New System.Guid(reader.item("Document").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Method") Then
          if isdbnull(reader.item("Method")) then
            If reader.Table.Columns.Contains("Method") Then m_Method = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Method") Then m_Method= New System.Guid(reader.item("Method").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("IconFile") Then m_IconFile=reader.item("IconFile").ToString()
      If reader.Table.Columns.Contains("TheExtention") Then
          if isdbnull(reader.item("TheExtention")) then
            If reader.Table.Columns.Contains("TheExtention") Then m_TheExtention = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheExtention") Then m_TheExtention= New System.Guid(reader.item("TheExtention").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ARM") Then
          if isdbnull(reader.item("ARM")) then
            If reader.Table.Columns.Contains("ARM") Then m_ARM = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ARM") Then m_ARM= New System.Guid(reader.item("ARM").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
      If reader.Table.Columns.Contains("ObjectType") Then
          if isdbnull(reader.item("ObjectType")) then
            If reader.Table.Columns.Contains("ObjectType") Then m_ObjectType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ObjectType") Then m_ObjectType= New System.Guid(reader.item("ObjectType").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("JournalFixedQuery") Then m_JournalFixedQuery=reader.item("JournalFixedQuery").ToString()
          If reader.Table.Columns.Contains("AllowAdd") Then m_AllowAdd=reader.item("AllowAdd")
          If reader.Table.Columns.Contains("AllowEdit") Then m_AllowEdit=reader.item("AllowEdit")
          If reader.Table.Columns.Contains("AllowDel") Then m_AllowDel=reader.item("AllowDel")
          If reader.Table.Columns.Contains("AllowFilter") Then m_AllowFilter=reader.item("AllowFilter")
          If reader.Table.Columns.Contains("AllowPrint") Then m_AllowPrint=reader.item("AllowPrint")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property sequence() As long
            Get
                LoadFromDatabase()
                sequence = m_sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_sequence = Value
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
'''Доступ к полю Включить в тулбар
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AsToolbarItem() As enumBoolean
            Get
                LoadFromDatabase()
                AsToolbarItem = m_AsToolbarItem
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AsToolbarItem = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Вариант действия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ActionType() As enumMenuActionType
            Get
                LoadFromDatabase()
                ActionType = m_ActionType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumMenuActionType )
                LoadFromDatabase()
                m_ActionType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheFilter() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                TheFilter = me.application.manager.GetInstanceObject(m_TheFilter)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_TheFilter = Value.id
                else
                  m_TheFilter =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Journal() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                Journal = me.application.manager.GetInstanceObject(m_Journal)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_Journal = Value.id
                else
                  m_Journal =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Отчет
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Report() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                Report = me.application.manager.GetInstanceObject(m_Report)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_Report = Value.id
                else
                  m_Report =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Документ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Document() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                Document = me.application.manager.GetInstanceObject(m_Document)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_Document = Value.id
                else
                  m_Document =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Method() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Method = me.application.Findrowobject("SHAREDMETHOD",m_Method)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Method = Value.id
                else
                   m_Method=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Файл картинки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IconFile() As String
            Get
                LoadFromDatabase()
                IconFile = m_IconFile
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_IconFile = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Расширение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheExtention() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                TheExtention = me.application.manager.GetInstanceObject(m_TheExtention)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_TheExtention = Value.id
                else
                  m_TheExtention =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю АРМ
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ARM() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                ARM = me.application.manager.GetInstanceObject(m_ARM)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_ARM = Value.id
                else
                  m_ARM =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Примечание
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
'''Доступ к полю Тип документа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ObjectType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ObjectType = me.application.Findrowobject("OBJECTTYPE",m_ObjectType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ObjectType = Value.id
                else
                   m_ObjectType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ограничения к журналу
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property JournalFixedQuery() As STRING
            Get
                LoadFromDatabase()
                JournalFixedQuery = m_JournalFixedQuery
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_JournalFixedQuery = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешено добавление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowAdd() As enumBoolean
            Get
                LoadFromDatabase()
                AllowAdd = m_AllowAdd
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowAdd = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешено редактирование
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowEdit() As enumBoolean
            Get
                LoadFromDatabase()
                AllowEdit = m_AllowEdit
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowEdit = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Рарешено удаление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowDel() As enumBoolean
            Get
                LoadFromDatabase()
                AllowDel = m_AllowDel
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowDel = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешен фильтр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowFilter() As enumBoolean
            Get
                LoadFromDatabase()
                AllowFilter = m_AllowFilter
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowFilter = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешена печать
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowPrint() As enumBoolean
            Get
                LoadFromDatabase()
                AllowPrint = m_AllowPrint
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowPrint = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Привязка фильтра
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property EPFilterLink() As EPFilterLink_col
            Get
                if  m_EPFilterLink is nothing then
                  m_EPFilterLink = new EPFilterLink_col
                  m_EPFilterLink.Parent = me
                  m_EPFilterLink.Application = me.Application
                  m_EPFilterLink.Refresh
                end if
                EPFilterLink = m_EPFilterLink
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property EntryPoints() As EntryPoints_col
            Get
                if  m_EntryPoints is nothing then
                  m_EntryPoints = new EntryPoints_col
                  m_EntryPoints.Parent = me
                  m_EntryPoints.Application = me.Application
                  m_EntryPoints.Refresh
                end if
                EntryPoints = m_EntryPoints
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
            sequence = node.Attributes.GetNamedItem("sequence").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            AsToolbarItem = node.Attributes.GetNamedItem("AsToolbarItem").Value
            ActionType = node.Attributes.GetNamedItem("ActionType").Value
            m_TheFilter = new system.guid(node.Attributes.GetNamedItem("TheFilter").Value)
            m_Journal = new system.guid(node.Attributes.GetNamedItem("Journal").Value)
            m_Report = new system.guid(node.Attributes.GetNamedItem("Report").Value)
            m_Document = new system.guid(node.Attributes.GetNamedItem("Document").Value)
            m_Method = new system.guid(node.Attributes.GetNamedItem("Method").Value)
            IconFile = node.Attributes.GetNamedItem("IconFile").Value
            m_TheExtention = new system.guid(node.Attributes.GetNamedItem("TheExtention").Value)
            m_ARM = new system.guid(node.Attributes.GetNamedItem("ARM").Value)
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            m_ObjectType = new system.guid(node.Attributes.GetNamedItem("ObjectType").Value)
            JournalFixedQuery = node.Attributes.GetNamedItem("JournalFixedQuery").Value
            AllowAdd = node.Attributes.GetNamedItem("AllowAdd").Value
            AllowEdit = node.Attributes.GetNamedItem("AllowEdit").Value
            AllowDel = node.Attributes.GetNamedItem("AllowDel").Value
            AllowFilter = node.Attributes.GetNamedItem("AllowFilter").Value
            AllowPrint = node.Attributes.GetNamedItem("AllowPrint").Value
            e_list = node.SelectNodes("EntryPoints_COL")
            EntryPoints.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("EPFilterLink_COL")
            EPFilterLink.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            EPFilterLink.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("sequence", sequence)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("AsToolbarItem", AsToolbarItem)  
          node.SetAttribute("ActionType", ActionType)  
          node.SetAttribute("TheFilter", m_TheFilter.tostring)  
          node.SetAttribute("Journal", m_Journal.tostring)  
          node.SetAttribute("Report", m_Report.tostring)  
          node.SetAttribute("Document", m_Document.tostring)  
          node.SetAttribute("Method", m_Method.tostring)  
          node.SetAttribute("IconFile", IconFile)  
          node.SetAttribute("TheExtention", m_TheExtention.tostring)  
          node.SetAttribute("ARM", m_ARM.tostring)  
          node.SetAttribute("TheComment", TheComment)  
          node.SetAttribute("ObjectType", m_ObjectType.tostring)  
          node.SetAttribute("JournalFixedQuery", JournalFixedQuery)  
          node.SetAttribute("AllowAdd", AllowAdd)  
          node.SetAttribute("AllowEdit", AllowEdit)  
          node.SetAttribute("AllowDel", AllowDel)  
          node.SetAttribute("AllowFilter", AllowFilter)  
          node.SetAttribute("AllowPrint", AllowPrint)  
            EntryPoints.XMLSave(node,xdom)
            EPFilterLink.XMLSave(node,xdom)
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
            EntryPoints.BatchUpdate
            EPFilterLink.BatchUpdate
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
            return EPFilterLink
            End Select
            return nothing
        End Function
    End Class
End Namespace
