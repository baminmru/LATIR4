
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
'''Реализация строки раздела Доступные состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_DOC_STATE
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Запрещена смена состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_StateChangeDisabled  as enumBoolean


''' <summary>
'''Локальная переменная для поля Состояние
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_The_State  as System.Guid


''' <summary>
'''Локальная переменная для поля Можно удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowDelete  as enumBoolean


''' <summary>
'''Локальная переменная для поля Режим
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_The_Mode  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_StateChangeDisabled=   
            ' m_The_State=   
            ' m_AllowDelete=   
            ' m_The_Mode=   
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
                    Value = The_State
                Case 2
                    Value = The_Mode
                Case 3
                    Value = AllowDelete
                Case 4
                    Value = StateChangeDisabled
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
                    The_State = value
                Case 2
                    The_Mode = value
                Case 3
                    AllowDelete = value
                Case 4
                    StateChangeDisabled = value
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
                    Return "The_State"
                Case 2
                    Return "The_Mode"
                Case 3
                    Return "AllowDelete"
                Case 4
                    Return "StateChangeDisabled"
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
             if The_State is nothing then
               dr("The_State") =system.dbnull.value
               dr("The_State_ID") =System.Guid.Empty
             else
               dr("The_State") =The_State.BRIEF
               dr("The_State_ID") =The_State.ID
             end if 
             if The_Mode is nothing then
               dr("The_Mode") =system.dbnull.value
               dr("The_Mode_ID") =System.Guid.Empty
             else
               dr("The_Mode") =The_Mode.BRIEF
               dr("The_Mode_ID") =The_Mode.ID
             end if 
             select case AllowDelete
            case enumBoolean.Boolean_Da
              dr ("AllowDelete")  = "Да"
              dr ("AllowDelete_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowDelete")  = "Нет"
              dr ("AllowDelete_VAL")  = 0
              end select 'AllowDelete
             select case StateChangeDisabled
            case enumBoolean.Boolean_Da
              dr ("StateChangeDisabled")  = "Да"
              dr ("StateChangeDisabled_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("StateChangeDisabled")  = "Нет"
              dr ("StateChangeDisabled_VAL")  = 0
              end select 'StateChangeDisabled
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
          if m_The_State.Equals(System.Guid.Empty) then
            nv.Add("The_State", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("The_State", Application.Session.GetProvider.ID2Param(m_The_State), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_The_Mode.Equals(System.Guid.Empty) then
            nv.Add("The_Mode", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("The_Mode", Application.Session.GetProvider.ID2Param(m_The_Mode), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AllowDelete", AllowDelete, dbtype.int16)
          nv.Add("StateChangeDisabled", StateChangeDisabled, dbtype.int16)
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
      If reader.Table.Columns.Contains("The_State") Then
          if isdbnull(reader.item("The_State")) then
            If reader.Table.Columns.Contains("The_State") Then m_The_State = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("The_State") Then m_The_State= New System.Guid(reader.item("The_State").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("The_Mode") Then
          if isdbnull(reader.item("The_Mode")) then
            If reader.Table.Columns.Contains("The_Mode") Then m_The_Mode = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("The_Mode") Then m_The_Mode= New System.Guid(reader.item("The_Mode").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AllowDelete") Then m_AllowDelete=reader.item("AllowDelete")
          If reader.Table.Columns.Contains("StateChangeDisabled") Then m_StateChangeDisabled=reader.item("StateChangeDisabled")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Состояние
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property The_State() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                The_State = me.application.Findrowobject("OBJSTATUS",m_The_State)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_The_State = Value.id
                else
                   m_The_State=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Режим
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property The_Mode() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                The_Mode = me.application.Findrowobject("OBJECTMODE",m_The_Mode)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_The_Mode = Value.id
                else
                   m_The_Mode=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Можно удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowDelete() As enumBoolean
            Get
                LoadFromDatabase()
                AllowDelete = m_AllowDelete
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowDelete = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запрещена смена состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property StateChangeDisabled() As enumBoolean
            Get
                LoadFromDatabase()
                StateChangeDisabled = m_StateChangeDisabled
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_StateChangeDisabled = Value
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
            m_The_State = new system.guid(node.Attributes.GetNamedItem("The_State").Value)
            m_The_Mode = new system.guid(node.Attributes.GetNamedItem("The_Mode").Value)
            AllowDelete = node.Attributes.GetNamedItem("AllowDelete").Value
            StateChangeDisabled = node.Attributes.GetNamedItem("StateChangeDisabled").Value
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
          node.SetAttribute("The_State", m_The_State.tostring)  
          node.SetAttribute("The_Mode", m_The_Mode.tostring)  
          node.SetAttribute("AllowDelete", AllowDelete)  
          node.SetAttribute("StateChangeDisabled", StateChangeDisabled)  
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
