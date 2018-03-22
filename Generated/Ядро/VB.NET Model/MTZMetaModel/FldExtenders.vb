
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
'''Реализация строки раздела Интерфейсы расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FldExtenders
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Объект
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheObject  as String


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheName  as String


''' <summary>
'''Локальная переменная для поля Целевая платформа
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TargetPlatform  as System.Guid


''' <summary>
'''Локальная переменная для поля Конфиг
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheConfig  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheObject=   
            ' m_TheName=   
            ' m_TargetPlatform=   
            ' m_TheConfig=   
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
                    Value = TheName
                Case 2
                    Value = TargetPlatform
                Case 3
                    Value = TheObject
                Case 4
                    Value = TheConfig
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
                    TheName = value
                Case 2
                    TargetPlatform = value
                Case 3
                    TheObject = value
                Case 4
                    TheConfig = value
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
                    Return "TheName"
                Case 2
                    Return "TargetPlatform"
                Case 3
                    Return "TheObject"
                Case 4
                    Return "TheConfig"
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
             dr("TheName") =TheName
             if TargetPlatform is nothing then
               dr("TargetPlatform") =system.dbnull.value
               dr("TargetPlatform_ID") =System.Guid.Empty
             else
               dr("TargetPlatform") =TargetPlatform.BRIEF
               dr("TargetPlatform_ID") =TargetPlatform.ID
             end if 
             dr("TheObject") =TheObject
             dr("TheConfig") =TheConfig
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
          nv.Add("TheName", TheName, dbtype.string)
          if m_TargetPlatform.Equals(System.Guid.Empty) then
            nv.Add("TargetPlatform", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TargetPlatform", Application.Session.GetProvider.ID2Param(m_TargetPlatform), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("TheObject", TheObject, dbtype.string)
          nv.Add("TheConfig", TheConfig, dbtype.string)
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
          If reader.Table.Columns.Contains("TheName") Then m_TheName=reader.item("TheName").ToString()
      If reader.Table.Columns.Contains("TargetPlatform") Then
          if isdbnull(reader.item("TargetPlatform")) then
            If reader.Table.Columns.Contains("TargetPlatform") Then m_TargetPlatform = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TargetPlatform") Then m_TargetPlatform= New System.Guid(reader.item("TargetPlatform").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("TheObject") Then m_TheObject=reader.item("TheObject").ToString()
          If reader.Table.Columns.Contains("TheConfig") Then m_TheConfig=reader.item("TheConfig").ToString()
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
        Public Property TheName() As String
            Get
                LoadFromDatabase()
                TheName = m_TheName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Целевая платформа
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TargetPlatform() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TargetPlatform = me.application.Findrowobject("GENERATOR_TARGET",m_TargetPlatform)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TargetPlatform = Value.id
                else
                   m_TargetPlatform=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объект
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheObject() As String
            Get
                LoadFromDatabase()
                TheObject = m_TheObject
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Конфиг
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheConfig() As String
            Get
                LoadFromDatabase()
                TheConfig = m_TheConfig
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheConfig = Value
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
            TheName = node.Attributes.GetNamedItem("TheName").Value
            m_TargetPlatform = new system.guid(node.Attributes.GetNamedItem("TargetPlatform").Value)
            TheObject = node.Attributes.GetNamedItem("TheObject").Value
            TheConfig = node.Attributes.GetNamedItem("TheConfig").Value
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
          node.SetAttribute("TheName", TheName)  
          node.SetAttribute("TargetPlatform", m_TargetPlatform.tostring)  
          node.SetAttribute("TheObject", TheObject)  
          node.SetAttribute("TheConfig", TheConfig)  
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
