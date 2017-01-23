
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZExt


''' <summary>
'''Реализация строки раздела Реализации расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class MTZExtRel
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название класса
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheClassName  as String


''' <summary>
'''Локальная переменная для поля Реализация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThePlatform  as enumDevelopmentBase


''' <summary>
'''Локальная переменная для поля Название библиотеки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheLibraryName  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheClassName=   
            ' m_ThePlatform=   
            ' m_TheLibraryName=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 3
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
                    Value = ThePlatform
                Case 2
                    Value = TheClassName
                Case 3
                    Value = TheLibraryName
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
                    ThePlatform = value
                Case 2
                    TheClassName = value
                Case 3
                    TheLibraryName = value
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
                    Return "ThePlatform"
                Case 2
                    Return "TheClassName"
                Case 3
                    Return "TheLibraryName"
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
             select case ThePlatform
            case enumDevelopmentBase.DevelopmentBase_OTHER
              dr ("ThePlatform")  = "OTHER"
              dr ("ThePlatform_VAL")  = 3
            case enumDevelopmentBase.DevelopmentBase_DOTNET
              dr ("ThePlatform")  = "DOTNET"
              dr ("ThePlatform_VAL")  = 1
            case enumDevelopmentBase.DevelopmentBase_JAVA
              dr ("ThePlatform")  = "JAVA"
              dr ("ThePlatform_VAL")  = 2
            case enumDevelopmentBase.DevelopmentBase_VB6
              dr ("ThePlatform")  = "VB6"
              dr ("ThePlatform_VAL")  = 0
              end select 'ThePlatform
             dr("TheClassName") =TheClassName
             dr("TheLibraryName") =TheLibraryName
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
          nv.Add("ThePlatform", ThePlatform, dbtype.int16)
          nv.Add("TheClassName", TheClassName, dbtype.string)
          nv.Add("TheLibraryName", TheLibraryName, dbtype.string)
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
          If reader.Table.Columns.Contains("ThePlatform") Then m_ThePlatform=reader.item("ThePlatform")
          If reader.Table.Columns.Contains("TheClassName") Then m_TheClassName=reader.item("TheClassName").ToString()
          If reader.Table.Columns.Contains("TheLibraryName") Then m_TheLibraryName=reader.item("TheLibraryName").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Реализация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ThePlatform() As enumDevelopmentBase
            Get
                LoadFromDatabase()
                ThePlatform = m_ThePlatform
                AccessTime = Now
            End Get
            Set(ByVal Value As enumDevelopmentBase )
                LoadFromDatabase()
                m_ThePlatform = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название класса
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheClassName() As String
            Get
                LoadFromDatabase()
                TheClassName = m_TheClassName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheClassName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название библиотеки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheLibraryName() As String
            Get
                LoadFromDatabase()
                TheLibraryName = m_TheLibraryName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheLibraryName = Value
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
            ThePlatform = node.Attributes.GetNamedItem("ThePlatform").Value
            TheClassName = node.Attributes.GetNamedItem("TheClassName").Value
            TheLibraryName = node.Attributes.GetNamedItem("TheLibraryName").Value
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
          node.SetAttribute("ThePlatform", ThePlatform)  
          node.SetAttribute("TheClassName", TheClassName)  
          node.SetAttribute("TheLibraryName", TheLibraryName)  
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
