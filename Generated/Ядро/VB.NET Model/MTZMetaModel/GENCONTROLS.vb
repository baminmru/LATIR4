
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
'''Реализация строки раздела Контрольные элементы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class GENCONTROLS
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Подверсия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_VersionMinor  as long


''' <summary>
'''Локальная переменная для поля Версия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_VersionMajor  as long


''' <summary>
'''Локальная переменная для поля ProgID контрольконо элемента
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ControlProgID  as String


''' <summary>
'''Локальная переменная для поля Класс контрольногоэлемента
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ControlClassID  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_VersionMinor=   
            ' m_VersionMajor=   
            ' m_ControlProgID=   
            ' m_ControlClassID=   
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
                    Value = ControlProgID
                Case 2
                    Value = ControlClassID
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
                    ControlProgID = value
                Case 2
                    ControlClassID = value
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
                    Return "ControlProgID"
                Case 2
                    Return "ControlClassID"
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
             dr("ControlProgID") =ControlProgID
             dr("ControlClassID") =ControlClassID
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
          nv.Add("ControlProgID", ControlProgID, dbtype.string)
          nv.Add("ControlClassID", ControlClassID, dbtype.string)
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
          If reader.Table.Columns.Contains("ControlProgID") Then m_ControlProgID=reader.item("ControlProgID").ToString()
          If reader.Table.Columns.Contains("ControlClassID") Then m_ControlClassID=reader.item("ControlClassID").ToString()
          If reader.Table.Columns.Contains("VersionMajor") Then m_VersionMajor=reader.item("VersionMajor")
          If reader.Table.Columns.Contains("VersionMinor") Then m_VersionMinor=reader.item("VersionMinor")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю ProgID контрольконо элемента
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ControlProgID() As String
            Get
                LoadFromDatabase()
                ControlProgID = m_ControlProgID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ControlProgID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Класс контрольногоэлемента
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ControlClassID() As String
            Get
                LoadFromDatabase()
                ControlClassID = m_ControlClassID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ControlClassID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Версия
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
            ControlProgID = node.Attributes.GetNamedItem("ControlProgID").Value
            ControlClassID = node.Attributes.GetNamedItem("ControlClassID").Value
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
          node.SetAttribute("ControlProgID", ControlProgID)  
          node.SetAttribute("ControlClassID", ControlClassID)  
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
