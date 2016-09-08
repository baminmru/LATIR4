
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
'''Реализация строки раздела Библиотеки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class GENREFERENCE
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Класс ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefClassID  as String


''' <summary>
'''Локальная переменная для поля Номер версии
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_VersionMajor  as long


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Подверсия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_VersionMinor  as long



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_RefClassID=   
            ' m_VersionMajor=   
            ' m_Name=   
            ' m_VersionMinor=   
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
                    Value = Name
                Case 2
                    Value = RefClassID
                Case 3
                    Value = VersionMajor
                Case 4
                    Value = VersionMinor
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
                    RefClassID = value
                Case 3
                    VersionMajor = value
                Case 4
                    VersionMinor = value
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
                    Return "RefClassID"
                Case 3
                    Return "VersionMajor"
                Case 4
                    Return "VersionMinor"
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
             dr("RefClassID") =RefClassID
             dr("VersionMajor") =VersionMajor
             dr("VersionMinor") =VersionMinor
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
          nv.Add("RefClassID", RefClassID, dbtype.string)
          nv.Add("VersionMajor", VersionMajor, dbtype.Int32)
          nv.Add("VersionMinor", VersionMinor, dbtype.Int32)
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
          If reader.Table.Columns.Contains("RefClassID") Then m_RefClassID=reader.item("RefClassID").ToString()
          If reader.Table.Columns.Contains("VersionMajor") Then m_VersionMajor=reader.item("VersionMajor")
          If reader.Table.Columns.Contains("VersionMinor") Then m_VersionMinor=reader.item("VersionMinor")
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
'''Доступ к полю Класс ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefClassID() As String
            Get
                LoadFromDatabase()
                RefClassID = m_RefClassID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_RefClassID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Номер версии
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property VersionMajor() As long
            Get
                LoadFromDatabase()
                VersionMajor = m_VersionMajor
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_VersionMajor = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Подверсия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property VersionMinor() As long
            Get
                LoadFromDatabase()
                VersionMinor = m_VersionMinor
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_VersionMinor = Value
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
            RefClassID = node.Attributes.GetNamedItem("RefClassID").Value
            VersionMajor = node.Attributes.GetNamedItem("VersionMajor").Value
            VersionMinor = node.Attributes.GetNamedItem("VersionMinor").Value
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
          node.SetAttribute("RefClassID", RefClassID)  
          node.SetAttribute("VersionMajor", VersionMajor)  
          node.SetAttribute("VersionMinor", VersionMinor)  
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
