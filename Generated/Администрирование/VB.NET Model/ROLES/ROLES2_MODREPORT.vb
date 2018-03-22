
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
'''Реализация строки раздела Действия и отчеты
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES2_MODREPORT
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Sequence  as long


''' <summary>
'''Локальная переменная для поля Код
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheIcon  as String


''' <summary>
'''Локальная переменная для поля Это отчет
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsReport  as enumBoolean


''' <summary>
'''Локальная переменная для поля Разрешен
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowAction  as enumBoolean


''' <summary>
'''Локальная переменная для поля Вариант выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_selectType  as long



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Caption=   
            ' m_Sequence=   
            ' m_Name=   
            ' m_TheIcon=   
            ' m_IsReport=   
            ' m_AllowAction=   
            ' m_selectType=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 7
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
                    Value = AllowAction
                Case 3
                    Value = Caption
                Case 4
                    Value = Sequence
                Case 5
                    Value = TheIcon
                Case 6
                    Value = IsReport
                Case 7
                    Value = selectType
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
                    AllowAction = value
                Case 3
                    Caption = value
                Case 4
                    Sequence = value
                Case 5
                    TheIcon = value
                Case 6
                    IsReport = value
                Case 7
                    selectType = value
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
                    Return "AllowAction"
                Case 3
                    Return "Caption"
                Case 4
                    Return "Sequence"
                Case 5
                    Return "TheIcon"
                Case 6
                    Return "IsReport"
                Case 7
                    Return "selectType"
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
             select case AllowAction
            case enumBoolean.Boolean_Da
              dr ("AllowAction")  = "Да"
              dr ("AllowAction_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowAction")  = "Нет"
              dr ("AllowAction_VAL")  = 0
              end select 'AllowAction
             dr("Caption") =Caption
             dr("Sequence") =Sequence
             dr("TheIcon") =TheIcon
             select case IsReport
            case enumBoolean.Boolean_Da
              dr ("IsReport")  = "Да"
              dr ("IsReport_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsReport")  = "Нет"
              dr ("IsReport_VAL")  = 0
              end select 'IsReport
             dr("selectType") =selectType
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
          nv.Add("AllowAction", AllowAction, dbtype.int16)
          nv.Add("Caption", Caption, dbtype.string)
          nv.Add("Sequence", Sequence, dbtype.Int32)
          nv.Add("TheIcon", TheIcon, dbtype.string)
          nv.Add("IsReport", IsReport, dbtype.int16)
          nv.Add("selectType", selectType, dbtype.Int32)
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
          If reader.Table.Columns.Contains("AllowAction") Then m_AllowAction=reader.item("AllowAction")
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
          If reader.Table.Columns.Contains("Sequence") Then m_Sequence=reader.item("Sequence")
          If reader.Table.Columns.Contains("TheIcon") Then m_TheIcon=reader.item("TheIcon").ToString()
          If reader.Table.Columns.Contains("IsReport") Then m_IsReport=reader.item("IsReport")
          If reader.Table.Columns.Contains("selectType") Then m_selectType=reader.item("selectType")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Код
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
'''Доступ к полю Разрешен
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowAction() As enumBoolean
            Get
                LoadFromDatabase()
                AllowAction = m_AllowAction
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowAction = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Надпись
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Caption() As String
            Get
                LoadFromDatabase()
                Caption = m_Caption
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Caption = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю № п/п
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Sequence() As long
            Get
                LoadFromDatabase()
                Sequence = m_Sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_Sequence = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Иконка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheIcon() As String
            Get
                LoadFromDatabase()
                TheIcon = m_TheIcon
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_TheIcon = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Это отчет
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsReport() As enumBoolean
            Get
                LoadFromDatabase()
                IsReport = m_IsReport
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsReport = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Вариант выбора
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property selectType() As long
            Get
                LoadFromDatabase()
                selectType = m_selectType
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_selectType = Value
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
            AllowAction = node.Attributes.GetNamedItem("AllowAction").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            Sequence = node.Attributes.GetNamedItem("Sequence").Value
            TheIcon = node.Attributes.GetNamedItem("TheIcon").Value
            IsReport = node.Attributes.GetNamedItem("IsReport").Value
            selectType = node.Attributes.GetNamedItem("selectType").Value
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
          node.SetAttribute("AllowAction", AllowAction)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("Sequence", Sequence)  
          node.SetAttribute("TheIcon", TheIcon)  
          node.SetAttribute("IsReport", IsReport)  
          node.SetAttribute("selectType", selectType)  
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
