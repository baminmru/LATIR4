
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZSystem


''' <summary>
'''Реализация строки раздела Сессия пользователя
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class the_Session
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Login
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Login  as String


''' <summary>
'''Локальная переменная для поля Текущая роль пользователя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UserRole  as System.Guid


''' <summary>
'''Локальная переменная для поля Последнее подтверждение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_LastAccess  as DATE


''' <summary>
'''Локальная переменная для поля Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Usersid  as System.Guid


''' <summary>
'''Локальная переменная для поля Закрыта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Closed  as enumYesNo


''' <summary>
'''Локальная переменная для поля Момент открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_StartAt  as DATE


''' <summary>
'''Локальная переменная для поля Момент закрытия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ClosedAt  as DATE


''' <summary>
'''Локальная переменная для поля Приложение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ApplicationID  as System.Guid


''' <summary>
'''Локальная переменная для поля Локализация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Lang  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Login=   
            ' m_UserRole=   
            ' m_LastAccess=   
            ' m_Usersid=   
            ' m_Closed=   
            ' m_StartAt=   
            ' m_ClosedAt=   
            ' m_ApplicationID=   
            ' m_Lang=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 9
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
                    Value = ApplicationID
                Case 2
                    Value = UserRole
                Case 3
                    Value = ClosedAt
                Case 4
                    Value = Closed
                Case 5
                    Value = Usersid
                Case 6
                    Value = LastAccess
                Case 7
                    Value = StartAt
                Case 8
                    Value = Lang
                Case 9
                    Value = Login
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
                    ApplicationID = value
                Case 2
                    UserRole = value
                Case 3
                    ClosedAt = value
                Case 4
                    Closed = value
                Case 5
                    Usersid = value
                Case 6
                    LastAccess = value
                Case 7
                    StartAt = value
                Case 8
                    Lang = value
                Case 9
                    Login = value
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
                    Return "ApplicationID"
                Case 2
                    Return "UserRole"
                Case 3
                    Return "ClosedAt"
                Case 4
                    Return "Closed"
                Case 5
                    Return "Usersid"
                Case 6
                    Return "LastAccess"
                Case 7
                    Return "StartAt"
                Case 8
                    Return "Lang"
                Case 9
                    Return "Login"
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
             if ApplicationID is nothing then
               dr("ApplicationID") =system.dbnull.value
               dr("ApplicationID_ID") =System.Guid.Empty
             else
               dr("ApplicationID") =ApplicationID.BRIEF
               dr("ApplicationID_ID") =ApplicationID.ID
             end if 
             if UserRole is nothing then
               dr("UserRole") =system.dbnull.value
               dr("UserRole_ID") =System.Guid.Empty
             else
               dr("UserRole") =UserRole.BRIEF
               dr("UserRole_ID") =UserRole.ID
             end if 
             dr("ClosedAt") =ClosedAt
             select case Closed
            case enumYesNo.YesNo_Da
              dr ("Closed")  = "Да"
              dr ("Closed_VAL")  = 1
            case enumYesNo.YesNo_Net
              dr ("Closed")  = "Нет"
              dr ("Closed_VAL")  = 0
              end select 'Closed
             if Usersid is nothing then
               dr("Usersid") =system.dbnull.value
               dr("Usersid_ID") =System.Guid.Empty
             else
               dr("Usersid") =Usersid.BRIEF
               dr("Usersid_ID") =Usersid.ID
             end if 
             dr("LastAccess") =LastAccess
             dr("StartAt") =StartAt
             dr("Lang") =Lang
             dr("Login") =Login
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
          if m_ApplicationID.Equals(System.Guid.Empty) then
            nv.Add("ApplicationID", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ApplicationID", Application.Session.GetProvider.ID2Param(m_ApplicationID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_UserRole.Equals(System.Guid.Empty) then
            nv.Add("UserRole", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("UserRole", Application.Session.GetProvider.ID2Param(m_UserRole), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if ClosedAt=System.DateTime.MinValue then
            nv.Add("ClosedAt", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("ClosedAt", ClosedAt, dbtype.DATETIME)
          end if 
          nv.Add("Closed", Closed, dbtype.int16)
          if m_Usersid.Equals(System.Guid.Empty) then
            nv.Add("Usersid", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Usersid", Application.Session.GetProvider.ID2Param(m_Usersid), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if LastAccess=System.DateTime.MinValue then
            nv.Add("LastAccess", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("LastAccess", LastAccess, dbtype.DATETIME)
          end if 
          if StartAt=System.DateTime.MinValue then
            nv.Add("StartAt", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("StartAt", StartAt, dbtype.DATETIME)
          end if 
          nv.Add("Lang", Lang, dbtype.string)
          nv.Add("Login", Login, dbtype.string)
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
      If reader.Table.Columns.Contains("ApplicationID") Then
          if isdbnull(reader.item("ApplicationID")) then
            If reader.Table.Columns.Contains("ApplicationID") Then m_ApplicationID = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ApplicationID") Then m_ApplicationID= New System.Guid(reader.item("ApplicationID").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("UserRole") Then
          if isdbnull(reader.item("UserRole")) then
            If reader.Table.Columns.Contains("UserRole") Then m_UserRole = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("UserRole") Then m_UserRole= New System.Guid(reader.item("UserRole").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("ClosedAt") Then
          if isdbnull(reader.item("ClosedAt")) then
            If reader.Table.Columns.Contains("ClosedAt") Then m_ClosedAt = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("ClosedAt") Then m_ClosedAt=reader.item("ClosedAt")
          end if 
      end if 
          If reader.Table.Columns.Contains("Closed") Then m_Closed=reader.item("Closed")
      If reader.Table.Columns.Contains("Usersid") Then
          if isdbnull(reader.item("Usersid")) then
            If reader.Table.Columns.Contains("Usersid") Then m_Usersid = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Usersid") Then m_Usersid= New System.Guid(reader.item("Usersid").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("LastAccess") Then
          if isdbnull(reader.item("LastAccess")) then
            If reader.Table.Columns.Contains("LastAccess") Then m_LastAccess = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("LastAccess") Then m_LastAccess=reader.item("LastAccess")
          end if 
      end if 
      If reader.Table.Columns.Contains("StartAt") Then
          if isdbnull(reader.item("StartAt")) then
            If reader.Table.Columns.Contains("StartAt") Then m_StartAt = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("StartAt") Then m_StartAt=reader.item("StartAt")
          end if 
      end if 
          If reader.Table.Columns.Contains("Lang") Then m_Lang=reader.item("Lang").ToString()
          If reader.Table.Columns.Contains("Login") Then m_Login=reader.item("Login").ToString()
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
        Public Property ApplicationID() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ApplicationID = me.application.Findrowobject("WorkPlace",m_ApplicationID)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ApplicationID = Value.id
                else
                   m_ApplicationID=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Текущая роль пользователя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UserRole() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                UserRole = me.application.Findrowobject("Groups",m_UserRole)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_UserRole = Value.id
                else
                   m_UserRole=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Момент закрытия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ClosedAt() As DATE
            Get
                LoadFromDatabase()
                ClosedAt = m_ClosedAt
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_ClosedAt = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Закрыта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Closed() As enumYesNo
            Get
                LoadFromDatabase()
                Closed = m_Closed
                AccessTime = Now
            End Get
            Set(ByVal Value As enumYesNo )
                LoadFromDatabase()
                m_Closed = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Пользователь
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Usersid() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Usersid = me.application.Findrowobject("Users",m_Usersid)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Usersid = Value.id
                else
                   m_Usersid=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Последнее подтверждение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property LastAccess() As DATE
            Get
                LoadFromDatabase()
                LastAccess = m_LastAccess
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_LastAccess = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Момент открытия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property StartAt() As DATE
            Get
                LoadFromDatabase()
                StartAt = m_StartAt
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_StartAt = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Локализация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Lang() As String
            Get
                LoadFromDatabase()
                Lang = m_Lang
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Lang = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Login
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Login() As String
            Get
                LoadFromDatabase()
                Login = m_Login
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Login = Value
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
            m_ApplicationID = new system.guid(node.Attributes.GetNamedItem("ApplicationID").Value)
            m_UserRole = new system.guid(node.Attributes.GetNamedItem("UserRole").Value)
            m_ClosedAt = System.DateTime.MinValue
            ClosedAt = m_ClosedAt.AddTicks( node.Attributes.GetNamedItem("ClosedAt").Value)
            Closed = node.Attributes.GetNamedItem("Closed").Value
            m_Usersid = new system.guid(node.Attributes.GetNamedItem("Usersid").Value)
            m_LastAccess = System.DateTime.MinValue
            LastAccess = m_LastAccess.AddTicks( node.Attributes.GetNamedItem("LastAccess").Value)
            m_StartAt = System.DateTime.MinValue
            StartAt = m_StartAt.AddTicks( node.Attributes.GetNamedItem("StartAt").Value)
            Lang = node.Attributes.GetNamedItem("Lang").Value
            Login = node.Attributes.GetNamedItem("Login").Value
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
          node.SetAttribute("ApplicationID", m_ApplicationID.tostring)  
          node.SetAttribute("UserRole", m_UserRole.tostring)  
         ' if ClosedAt = System.DateTime.MinValue then ClosedAt=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("ClosedAt", ClosedAt.Ticks)  
          node.SetAttribute("Closed", Closed)  
          node.SetAttribute("Usersid", m_Usersid.tostring)  
         ' if LastAccess = System.DateTime.MinValue then LastAccess=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("LastAccess", LastAccess.Ticks)  
         ' if StartAt = System.DateTime.MinValue then StartAt=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("StartAt", StartAt.Ticks)  
          node.SetAttribute("Lang", Lang)  
          node.SetAttribute("Login", Login)  
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
