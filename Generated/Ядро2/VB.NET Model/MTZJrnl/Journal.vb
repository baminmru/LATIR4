
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace mtzjrnl


''' <summary>
'''Реализация строки раздела Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class journal
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Псевдоним
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_alias  as String


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_thecomment  as STRING


''' <summary>
'''Локальная переменная для поля Иконка журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_jrnliconcls  as String


''' <summary>
'''Локальная переменная для поля Массовое выделение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_usefavorites  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_name=   
            ' m_the_alias=   
            ' m_thecomment=   
            ' m_jrnliconcls=   
            ' m_usefavorites=   
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
                    Value = name
                Case 2
                    Value = the_alias
                Case 3
                    Value = thecomment
                Case 4
                    Value = jrnliconcls
                Case 5
                    Value = usefavorites
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
                    name = value
                Case 2
                    the_alias = value
                Case 3
                    thecomment = value
                Case 4
                    jrnliconcls = value
                Case 5
                    usefavorites = value
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
                    Return "name"
                Case 2
                    Return "the_alias"
                Case 3
                    Return "thecomment"
                Case 4
                    Return "jrnliconcls"
                Case 5
                    Return "usefavorites"
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
             dr("name") =name
             dr("the_alias") =the_alias
             dr("thecomment") =thecomment
             dr("jrnliconcls") =jrnliconcls
             select case usefavorites
            case enumBoolean.Boolean_Da
              dr ("usefavorites")  = "Да"
              dr ("usefavorites_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("usefavorites")  = "Нет"
              dr ("usefavorites_VAL")  = 0
              end select 'usefavorites
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
          nv.Add("name", name, dbtype.string)
          nv.Add("the_alias", the_alias, dbtype.string)
          nv.Add("thecomment", thecomment, dbtype.string)
          nv.Add("jrnliconcls", jrnliconcls, dbtype.string)
          nv.Add("usefavorites", usefavorites, dbtype.int16)
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
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("the_alias") Then m_the_alias=reader.item("the_alias").ToString()
          If reader.Table.Columns.Contains("thecomment") Then m_thecomment=reader.item("thecomment").ToString()
          If reader.Table.Columns.Contains("jrnliconcls") Then m_jrnliconcls=reader.item("jrnliconcls").ToString()
          If reader.Table.Columns.Contains("usefavorites") Then m_usefavorites=reader.item("usefavorites")
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
'''Доступ к полю Псевдоним
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_alias() As String
            Get
                LoadFromDatabase()
                the_alias = m_the_alias
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_alias = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property thecomment() As STRING
            Get
                LoadFromDatabase()
                thecomment = m_thecomment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_thecomment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property jrnliconcls() As String
            Get
                LoadFromDatabase()
                jrnliconcls = m_jrnliconcls
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_jrnliconcls = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Массовое выделение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property usefavorites() As enumBoolean
            Get
                LoadFromDatabase()
                usefavorites = m_usefavorites
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_usefavorites = Value
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
            name = node.Attributes.GetNamedItem("name").Value
            the_alias = node.Attributes.GetNamedItem("the_alias").Value
            thecomment = node.Attributes.GetNamedItem("thecomment").Value
            jrnliconcls = node.Attributes.GetNamedItem("jrnliconcls").Value
            usefavorites = node.Attributes.GetNamedItem("usefavorites").Value
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
          node.SetAttribute("name", name)  
          node.SetAttribute("the_alias", the_alias)  
          node.SetAttribute("thecomment", thecomment)  
          node.SetAttribute("jrnliconcls", jrnliconcls)  
          node.SetAttribute("usefavorites", usefavorites)  
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
