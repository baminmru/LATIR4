
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация строки раздела Определение роли
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_DEF
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SubStructObjects  as enumBoolean


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ColegsObject  as enumBoolean


''' <summary>
'''Локальная переменная для поля Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllObjects  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_SubStructObjects=   
            ' m_name=   
            ' m_ColegsObject=   
            ' m_AllObjects=   
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
                    Value = AllObjects
                Case 3
                    Value = ColegsObject
                Case 4
                    Value = SubStructObjects
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
                    AllObjects = value
                Case 3
                    ColegsObject = value
                Case 4
                    SubStructObjects = value
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
                    Return "AllObjects"
                Case 3
                    Return "ColegsObject"
                Case 4
                    Return "SubStructObjects"
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
             select case AllObjects
            case enumBoolean.Boolean_Da
              dr ("AllObjects")  = "Да"
              dr ("AllObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllObjects")  = "Нет"
              dr ("AllObjects_VAL")  = 0
              end select 'AllObjects
             select case ColegsObject
            case enumBoolean.Boolean_Da
              dr ("ColegsObject")  = "Да"
              dr ("ColegsObject_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ColegsObject")  = "Нет"
              dr ("ColegsObject_VAL")  = 0
              end select 'ColegsObject
             select case SubStructObjects
            case enumBoolean.Boolean_Da
              dr ("SubStructObjects")  = "Да"
              dr ("SubStructObjects_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("SubStructObjects")  = "Нет"
              dr ("SubStructObjects_VAL")  = 0
              end select 'SubStructObjects
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
          nv.Add("AllObjects", AllObjects, dbtype.int16)
          nv.Add("ColegsObject", ColegsObject, dbtype.int16)
          nv.Add("SubStructObjects", SubStructObjects, dbtype.int16)
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
          If reader.Table.Columns.Contains("AllObjects") Then m_AllObjects=reader.item("AllObjects")
          If reader.Table.Columns.Contains("ColegsObject") Then m_ColegsObject=reader.item("ColegsObject")
          If reader.Table.Columns.Contains("SubStructObjects") Then m_SubStructObjects=reader.item("SubStructObjects")
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
'''Доступ к полю Вся фирма
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllObjects() As enumBoolean
            Get
                LoadFromDatabase()
                AllObjects = m_AllObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllObjects = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Объекты коллег
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ColegsObject() As enumBoolean
            Get
                LoadFromDatabase()
                ColegsObject = m_ColegsObject
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ColegsObject = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Подчиненные подразделения
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SubStructObjects() As enumBoolean
            Get
                LoadFromDatabase()
                SubStructObjects = m_SubStructObjects
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_SubStructObjects = Value
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
            AllObjects = node.Attributes.GetNamedItem("AllObjects").Value
            ColegsObject = node.Attributes.GetNamedItem("ColegsObject").Value
            SubStructObjects = node.Attributes.GetNamedItem("SubStructObjects").Value
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
          node.SetAttribute("AllObjects", AllObjects)  
          node.SetAttribute("ColegsObject", ColegsObject)  
          node.SetAttribute("SubStructObjects", SubStructObjects)  
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
