
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace MTZExt


''' <summary>
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class MTZExt_def
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Тип расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ExtType  as enumExtentionType


''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheDescription  as STRING



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_ExtType=   
            ' m_TheDescription=   
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
                    Value = Name
                Case 2
                    Value = ExtType
                Case 3
                    Value = TheDescription
            End Select
        else
        On Error Resume Next
        Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
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
                    ExtType = value
                Case 3
                    TheDescription = value
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
                    Return "ExtType"
                Case 3
                    Return "TheDescription"
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
            on error resume next
            dr("ID") =ID
            dr("Brief") =Brief
             dr("Name") =Name
             select case ExtType
            case enumExtentionType.ExtentionType_VerifyRowExt
              dr ("ExtType")  = "VerifyRowExt"
              dr ("ExtType_VAL")  = 6
            case enumExtentionType.ExtentionType_CodeGenerator
              dr ("ExtType")  = "CodeGenerator"
              dr ("ExtType_VAL")  = 7
            case enumExtentionType.ExtentionType_DefaultExt
              dr ("ExtType")  = "DefaultExt"
              dr ("ExtType_VAL")  = 5
            case enumExtentionType.ExtentionType_StatusExt
              dr ("ExtType")  = "StatusExt"
              dr ("ExtType_VAL")  = 0
            case enumExtentionType.ExtentionType_JrnlRunExt
              dr ("ExtType")  = "JrnlRunExt"
              dr ("ExtType_VAL")  = 4
            case enumExtentionType.ExtentionType_CustomExt
              dr ("ExtType")  = "CustomExt"
              dr ("ExtType_VAL")  = 2
            case enumExtentionType.ExtentionType_ARMGenerator
              dr ("ExtType")  = "ARMGenerator"
              dr ("ExtType_VAL")  = 8
            case enumExtentionType.ExtentionType_OnFormExt
              dr ("ExtType")  = "OnFormExt"
              dr ("ExtType_VAL")  = 1
            case enumExtentionType.ExtentionType_JrnlAddExt
              dr ("ExtType")  = "JrnlAddExt"
              dr ("ExtType_VAL")  = 3
              end select 'ExtType
             dr("TheDescription") =TheDescription
            DestDataTable.Rows.Add (dr)
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
          nv.Add("ExtType", ExtType, dbtype.int16)
          nv.Add("TheDescription", TheDescription, dbtype.string)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            on error resume next  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("ExtType") Then m_ExtType=reader.item("ExtType")
          If reader.Table.Columns.Contains("TheDescription") Then m_TheDescription=reader.item("TheDescription").ToString()
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
'''Доступ к полю Тип расширения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ExtType() As enumExtentionType
            Get
                LoadFromDatabase()
                ExtType = m_ExtType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumExtentionType )
                LoadFromDatabase()
                m_ExtType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheDescription() As STRING
            Get
                LoadFromDatabase()
                TheDescription = m_TheDescription
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_TheDescription = Value
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
          on error resume next  
            Name = node.Attributes.GetNamedItem("Name").Value
            ExtType = node.Attributes.GetNamedItem("ExtType").Value
            TheDescription = node.Attributes.GetNamedItem("TheDescription").Value
             Changed = true
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
           on error resume next  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("ExtType", ExtType)  
          node.SetAttribute("TheDescription", TheDescription)  
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
