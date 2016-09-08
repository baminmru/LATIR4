
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
'''Реализация строки раздела Состояния
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class OBJSTATUS
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Архивное
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsArchive  as enumBoolean


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_comment  as STRING


''' <summary>
'''Локальная переменная для поля Начальное
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_isStartup  as enumBoolean


''' <summary>
'''Локальная переменная для дочернего раздела Разрешенные переходы
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_NEXTSTATE As NEXTSTATE_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_IsArchive=   
            ' m_name=   
            ' m_the_comment=   
            ' m_isStartup=   
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
                    Value = name
                Case 2
                    Value = isStartup
                Case 3
                    Value = IsArchive
                Case 4
                    Value = the_comment
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
                    isStartup = value
                Case 3
                    IsArchive = value
                Case 4
                    the_comment = value
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
                    Return "isStartup"
                Case 3
                    Return "IsArchive"
                Case 4
                    Return "the_comment"
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
             select case isStartup
            case enumBoolean.Boolean_Da
              dr ("isStartup")  = "Да"
              dr ("isStartup_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("isStartup")  = "Нет"
              dr ("isStartup_VAL")  = 0
              end select 'isStartup
             select case IsArchive
            case enumBoolean.Boolean_Da
              dr ("IsArchive")  = "Да"
              dr ("IsArchive_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsArchive")  = "Нет"
              dr ("IsArchive_VAL")  = 0
              end select 'IsArchive
             dr("the_comment") =the_comment
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
            mFindInside = NEXTSTATE.FindObject(table,RowID)
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
          nv.Add("name", name, dbtype.string)
          nv.Add("isStartup", isStartup, dbtype.int16)
          nv.Add("IsArchive", IsArchive, dbtype.int16)
          nv.Add("the_comment", the_comment, dbtype.string)
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
          If reader.Table.Columns.Contains("isStartup") Then m_isStartup=reader.item("isStartup")
          If reader.Table.Columns.Contains("IsArchive") Then m_IsArchive=reader.item("IsArchive")
          If reader.Table.Columns.Contains("the_comment") Then m_the_comment=reader.item("the_comment").ToString()
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
'''Доступ к полю Начальное
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property isStartup() As enumBoolean
            Get
                LoadFromDatabase()
                isStartup = m_isStartup
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_isStartup = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Архивное
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsArchive() As enumBoolean
            Get
                LoadFromDatabase()
                IsArchive = m_IsArchive
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsArchive = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_comment() As STRING
            Get
                LoadFromDatabase()
                the_comment = m_the_comment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_the_comment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Разрешенные переходы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property NEXTSTATE() As NEXTSTATE_col
            Get
                if  m_NEXTSTATE is nothing then
                  m_NEXTSTATE = new NEXTSTATE_col
                  m_NEXTSTATE.Parent = me
                  m_NEXTSTATE.Application = me.Application
                  m_NEXTSTATE.Refresh
                end if
                NEXTSTATE = m_NEXTSTATE
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
            name = node.Attributes.GetNamedItem("name").Value
            isStartup = node.Attributes.GetNamedItem("isStartup").Value
            IsArchive = node.Attributes.GetNamedItem("IsArchive").Value
            the_comment = node.Attributes.GetNamedItem("the_comment").Value
            e_list = node.SelectNodes("NEXTSTATE_COL")
            NEXTSTATE.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            NEXTSTATE.Dispose
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
          node.SetAttribute("isStartup", isStartup)  
          node.SetAttribute("IsArchive", IsArchive)  
          node.SetAttribute("the_comment", the_comment)  
            NEXTSTATE.XMLSave(node,xdom)
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
            NEXTSTATE.BatchUpdate
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
            return NEXTSTATE
            End Select
            return nothing
        End Function
    End Class
End Namespace
