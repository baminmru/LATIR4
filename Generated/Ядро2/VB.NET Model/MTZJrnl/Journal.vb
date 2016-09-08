
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZJrnl


''' <summary>
'''Реализация строки раздела Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Journal
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
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
'''Локальная переменная для поля Иконка журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_jrnlIconCls  as String


''' <summary>
'''Локальная переменная для поля Псевдоним
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Alias  as String


''' <summary>
'''Локальная переменная для поля Массовое выделение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_UseFavorites  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_TheComment=   
            ' m_jrnlIconCls=   
            ' m_the_Alias=   
            ' m_UseFavorites=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 5
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
                    Value = the_Alias
                Case 3
                    Value = TheComment
                Case 4
                    Value = jrnlIconCls
                Case 5
                    Value = UseFavorites
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
                    the_Alias = value
                Case 3
                    TheComment = value
                Case 4
                    jrnlIconCls = value
                Case 5
                    UseFavorites = value
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
                    Return "the_Alias"
                Case 3
                    Return "TheComment"
                Case 4
                    Return "jrnlIconCls"
                Case 5
                    Return "UseFavorites"
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
             dr("the_Alias") =the_Alias
             dr("TheComment") =TheComment
             dr("jrnlIconCls") =jrnlIconCls
             select case UseFavorites
            case enumBoolean.Boolean_Da
              dr ("UseFavorites")  = "Да"
              dr ("UseFavorites_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("UseFavorites")  = "Нет"
              dr ("UseFavorites_VAL")  = 0
              end select 'UseFavorites
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
          nv.Add("Name", Name, dbtype.string)
          nv.Add("the_Alias", the_Alias, dbtype.string)
          nv.Add("TheComment", TheComment, dbtype.string)
          nv.Add("jrnlIconCls", jrnlIconCls, dbtype.string)
          nv.Add("UseFavorites", UseFavorites, dbtype.int16)
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
          If reader.Table.Columns.Contains("the_Alias") Then m_the_Alias=reader.item("the_Alias").ToString()
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
          If reader.Table.Columns.Contains("jrnlIconCls") Then m_jrnlIconCls=reader.item("jrnlIconCls").ToString()
          If reader.Table.Columns.Contains("UseFavorites") Then m_UseFavorites=reader.item("UseFavorites")
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
'''Доступ к полю Псевдоним
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Alias() As String
            Get
                LoadFromDatabase()
                the_Alias = m_the_Alias
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_Alias = Value
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
'''Доступ к полю Иконка журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property jrnlIconCls() As String
            Get
                LoadFromDatabase()
                jrnlIconCls = m_jrnlIconCls
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_jrnlIconCls = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Массовое выделение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property UseFavorites() As enumBoolean
            Get
                LoadFromDatabase()
                UseFavorites = m_UseFavorites
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_UseFavorites = Value
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
            Name = node.Attributes.GetNamedItem("Name").Value
            the_Alias = node.Attributes.GetNamedItem("the_Alias").Value
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            jrnlIconCls = node.Attributes.GetNamedItem("jrnlIconCls").Value
            UseFavorites = node.Attributes.GetNamedItem("UseFavorites").Value
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
          node.SetAttribute("Name", Name)  
          node.SetAttribute("the_Alias", the_Alias)  
          node.SetAttribute("TheComment", TheComment)  
          node.SetAttribute("jrnlIconCls", jrnlIconCls)  
          node.SetAttribute("UseFavorites", UseFavorites)  
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
