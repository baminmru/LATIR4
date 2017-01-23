
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZ2JOB


''' <summary>
'''Реализация строки раздела Отложенное событие
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class MTZ2JOB_DEF
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Состояние после обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_NextState  as Guid


''' <summary>
'''Локальная переменная для поля Состояние - причина
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThruState  as Guid


''' <summary>
'''Локальная переменная для поля Объект - причина события
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThruObject  as System.Guid


''' <summary>
'''Локальная переменная для поля Тип события
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_EvenType  as String


''' <summary>
'''Локальная переменная для поля Отложено до
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_EventDate  as DATE


''' <summary>
'''Локальная переменная для поля Момент обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ProcessDate  as DATE


''' <summary>
'''Локальная переменная для поля Обработан
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Processed  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_NextState=   
            ' m_ThruState=   
            ' m_ThruObject=   
            ' m_EvenType=   
            ' m_EventDate=   
            ' m_ProcessDate=   
            ' m_Processed=   
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
                    Value = EventDate
                Case 2
                    Value = EvenType
                Case 3
                    Value = ThruObject
                Case 4
                    Value = ThruState
                Case 5
                    Value = NextState
                Case 6
                    Value = ProcessDate
                Case 7
                    Value = Processed
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
                    EventDate = value
                Case 2
                    EvenType = value
                Case 3
                    ThruObject = value
                Case 4
                    ThruState = value
                Case 5
                    NextState = value
                Case 6
                    ProcessDate = value
                Case 7
                    Processed = value
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
                    Return "EventDate"
                Case 2
                    Return "EvenType"
                Case 3
                    Return "ThruObject"
                Case 4
                    Return "ThruState"
                Case 5
                    Return "NextState"
                Case 6
                    Return "ProcessDate"
                Case 7
                    Return "Processed"
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
             dr("EventDate") =EventDate
             dr("EvenType") =EvenType
             if ThruObject is nothing then
               dr("ThruObject") =system.dbnull.value
               dr("ThruObject_ID") =System.Guid.Empty
             else
               dr("ThruObject") =ThruObject.BRIEF
               dr("ThruObject_ID") =ThruObject.ID
             end if 
             dr("ThruState") =ThruState
             dr("NextState") =NextState
             dr("ProcessDate") =ProcessDate
             select case Processed
            case enumBoolean.Boolean_Da
              dr ("Processed")  = "Да"
              dr ("Processed_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("Processed")  = "Нет"
              dr ("Processed_VAL")  = 0
              end select 'Processed
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
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          if EventDate=System.DateTime.MinValue then
            nv.Add("EventDate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("EventDate", EventDate, dbtype.DATETIME)
          end if 
          nv.Add("EvenType", EvenType, dbtype.string)
          if m_ThruObject.Equals(System.Guid.Empty) then
            nv.Add("ThruObject", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ThruObject", Application.Session.GetProvider.ID2Param(m_ThruObject), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("ThruState", ThruState, dbtype.GUID)
          nv.Add("NextState", NextState, dbtype.GUID)
          if ProcessDate=System.DateTime.MinValue then
            nv.Add("ProcessDate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("ProcessDate", ProcessDate, dbtype.DATETIME)
          end if 
          nv.Add("Processed", Processed, dbtype.int16)
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
      If reader.Table.Columns.Contains("EventDate") Then
          if isdbnull(reader.item("EventDate")) then
            If reader.Table.Columns.Contains("EventDate") Then m_EventDate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("EventDate") Then m_EventDate=reader.item("EventDate")
          end if 
      end if 
          If reader.Table.Columns.Contains("EvenType") Then m_EvenType=reader.item("EvenType").ToString()
      If reader.Table.Columns.Contains("ThruObject") Then
          if isdbnull(reader.item("ThruObject")) then
            If reader.Table.Columns.Contains("ThruObject") Then m_ThruObject = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ThruObject") Then m_ThruObject= New System.Guid(reader.item("ThruObject").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ThruState") Then
          if isdbnull(reader.item("ThruState")) then
            If reader.Table.Columns.Contains("ThruState") Then m_ThruState = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ThruState") Then m_ThruState= New System.Guid(reader.item("ThruState").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("NextState") Then
          if isdbnull(reader.item("NextState")) then
            If reader.Table.Columns.Contains("NextState") Then m_NextState = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("NextState") Then m_NextState= New System.Guid(reader.item("NextState").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ProcessDate") Then
          if isdbnull(reader.item("ProcessDate")) then
            If reader.Table.Columns.Contains("ProcessDate") Then m_ProcessDate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("ProcessDate") Then m_ProcessDate=reader.item("ProcessDate")
          end if 
      end if 
          If reader.Table.Columns.Contains("Processed") Then m_Processed=reader.item("Processed")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Отложено до
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property EventDate() As DATE
            Get
                LoadFromDatabase()
                EventDate = m_EventDate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_EventDate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип события
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property EvenType() As String
            Get
                LoadFromDatabase()
                EvenType = m_EvenType
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_EvenType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объект - причина события
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ThruObject() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                ThruObject = me.application.manager.GetInstanceObject(m_ThruObject)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_ThruObject = Value.id
                else
                  m_ThruObject =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Состояние - причина
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ThruState() As Guid
            Get
                LoadFromDatabase()
                ThruState = m_ThruState
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_ThruState = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Состояние после обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property NextState() As Guid
            Get
                LoadFromDatabase()
                NextState = m_NextState
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_NextState = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Момент обработки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ProcessDate() As DATE
            Get
                LoadFromDatabase()
                ProcessDate = m_ProcessDate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_ProcessDate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Обработан
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Processed() As enumBoolean
            Get
                LoadFromDatabase()
                Processed = m_Processed
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_Processed = Value
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
          try 
            m_EventDate = System.DateTime.MinValue
            EventDate = m_EventDate.AddTicks( node.Attributes.GetNamedItem("EventDate").Value)
            EvenType = node.Attributes.GetNamedItem("EvenType").Value
            m_ThruObject = new system.guid(node.Attributes.GetNamedItem("ThruObject").Value)
            m_ThruState =new system.guid(node.Attributes.GetNamedItem("ThruState").Value)
            m_NextState =new system.guid(node.Attributes.GetNamedItem("NextState").Value)
            m_ProcessDate = System.DateTime.MinValue
            ProcessDate = m_ProcessDate.AddTicks( node.Attributes.GetNamedItem("ProcessDate").Value)
            Processed = node.Attributes.GetNamedItem("Processed").Value
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
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
           try 
         ' if EventDate = System.DateTime.MinValue then EventDate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("EventDate", EventDate.Ticks)  
          node.SetAttribute("EvenType", EvenType)  
          node.SetAttribute("ThruObject", m_ThruObject.tostring)  
          node.SetAttribute("ThruState", ThruState.ToString())  
          node.SetAttribute("NextState", NextState.ToString())  
         ' if ProcessDate = System.DateTime.MinValue then ProcessDate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("ProcessDate", ProcessDate.Ticks)  
          node.SetAttribute("Processed", Processed)  
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
