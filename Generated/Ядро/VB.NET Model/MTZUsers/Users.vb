
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZUsers


''' <summary>
'''Реализация строки раздела Пользователи
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Users
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Family  as String


''' <summary>
'''Локальная переменная для поля Имя для входа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Login  as String


''' <summary>
'''Локальная переменная для поля Пароль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Password  as string


''' <summary>
'''Локальная переменная для поля e-mail
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_EMail  as string


''' <summary>
'''Локальная переменная для поля Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Phone  as String


''' <summary>
'''Локальная переменная для поля Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Доменное имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DomaiName  as String


''' <summary>
'''Локальная переменная для поля Местный телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_LocalPhone  as String


''' <summary>
'''Локальная переменная для поля Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SurName  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Family=   
            ' m_Login=   
            ' m_Password=   
            ' m_EMail=   
            ' m_Phone=   
            ' m_Name=   
            ' m_DomaiName=   
            ' m_LocalPhone=   
            ' m_SurName=   
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
                    Value = Family
                Case 2
                    Value = Name
                Case 3
                    Value = SurName
                Case 4
                    Value = Login
                Case 5
                    Value = Password
                Case 6
                    Value = DomaiName
                Case 7
                    Value = EMail
                Case 8
                    Value = Phone
                Case 9
                    Value = LocalPhone
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
                    Family = value
                Case 2
                    Name = value
                Case 3
                    SurName = value
                Case 4
                    Login = value
                Case 5
                    Password = value
                Case 6
                    DomaiName = value
                Case 7
                    EMail = value
                Case 8
                    Phone = value
                Case 9
                    LocalPhone = value
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
                    Return "Family"
                Case 2
                    Return "Name"
                Case 3
                    Return "SurName"
                Case 4
                    Return "Login"
                Case 5
                    Return "Password"
                Case 6
                    Return "DomaiName"
                Case 7
                    Return "EMail"
                Case 8
                    Return "Phone"
                Case 9
                    Return "LocalPhone"
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
             dr("Family") =Family
             dr("Name") =Name
             dr("SurName") =SurName
             dr("Login") =Login
             dr("Password") =Password
             dr("DomaiName") =DomaiName
             dr("EMail") =EMail
             dr("Phone") =Phone
             dr("LocalPhone") =LocalPhone
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
          nv.Add("Family", Family, dbtype.string)
          nv.Add("Name", Name, dbtype.string)
          nv.Add("SurName", SurName, dbtype.string)
          nv.Add("Login", Login, dbtype.string)
          nv.Add("Password", Password, dbtype.string)
          nv.Add("DomaiName", DomaiName, dbtype.string)
          nv.Add("EMail", EMail, dbtype.string)
          nv.Add("Phone", Phone, dbtype.string)
          nv.Add("LocalPhone", LocalPhone, dbtype.string)
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
          If reader.Table.Columns.Contains("Family") Then m_Family=reader.item("Family").ToString()
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("SurName") Then m_SurName=reader.item("SurName").ToString()
          If reader.Table.Columns.Contains("Login") Then m_Login=reader.item("Login").ToString()
          If reader.Table.Columns.Contains("Password") Then m_Password=reader.item("Password").ToString()
          If reader.Table.Columns.Contains("DomaiName") Then m_DomaiName=reader.item("DomaiName").ToString()
          If reader.Table.Columns.Contains("EMail") Then m_EMail=reader.item("EMail").ToString()
          If reader.Table.Columns.Contains("Phone") Then m_Phone=reader.item("Phone").ToString()
          If reader.Table.Columns.Contains("LocalPhone") Then m_LocalPhone=reader.item("LocalPhone").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Family() As String
            Get
                LoadFromDatabase()
                Family = m_Family
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Family = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя
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
'''Доступ к полю Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SurName() As String
            Get
                LoadFromDatabase()
                SurName = m_SurName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_SurName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя для входа
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
'''Доступ к полю Пароль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Password() As string
            Get
                LoadFromDatabase()
                Password = m_Password
                AccessTime = Now
            End Get
            Set(ByVal Value As string )
                LoadFromDatabase()
                m_Password = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Доменное имя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DomaiName() As String
            Get
                LoadFromDatabase()
                DomaiName = m_DomaiName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_DomaiName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю e-mail
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property EMail() As string
            Get
                LoadFromDatabase()
                EMail = m_EMail
                AccessTime = Now
            End Get
            Set(ByVal Value As string )
                LoadFromDatabase()
                m_EMail = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Phone() As String
            Get
                LoadFromDatabase()
                Phone = m_Phone
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Phone = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Местный телефон
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property LocalPhone() As String
            Get
                LoadFromDatabase()
                LocalPhone = m_LocalPhone
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_LocalPhone = Value
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
            Family = node.Attributes.GetNamedItem("Family").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            SurName = node.Attributes.GetNamedItem("SurName").Value
            Login = node.Attributes.GetNamedItem("Login").Value
            Password = node.Attributes.GetNamedItem("Password").Value
            DomaiName = node.Attributes.GetNamedItem("DomaiName").Value
            EMail = node.Attributes.GetNamedItem("EMail").Value
            Phone = node.Attributes.GetNamedItem("Phone").Value
            LocalPhone = node.Attributes.GetNamedItem("LocalPhone").Value
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
          node.SetAttribute("Family", Family)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("SurName", SurName)  
          node.SetAttribute("Login", Login)  
          node.SetAttribute("Password", Password)  
          node.SetAttribute("DomaiName", DomaiName)  
          node.SetAttribute("EMail", EMail)  
          node.SetAttribute("Phone", Phone)  
          node.SetAttribute("LocalPhone", LocalPhone)  
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
