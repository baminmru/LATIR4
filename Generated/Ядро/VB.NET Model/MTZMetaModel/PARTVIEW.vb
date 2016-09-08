
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
'''Реализация строки раздела Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARTVIEW
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Поле - фильтр 2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FilterField2  as String


''' <summary>
'''Локальная переменная для поля Поле - фильтр 0
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FilterField0  as String


''' <summary>
'''Локальная переменная для поля Псевдоним
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Alias  as String


''' <summary>
'''Локальная переменная для поля Для поиска
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ForChoose  as enumBoolean


''' <summary>
'''Локальная переменная для поля Поле - фильтр 1
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FilterField1  as String


''' <summary>
'''Локальная переменная для поля Поле - фильтр 3
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FilterField3  as String


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для дочернего раздела Колонка
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ViewColumn As ViewColumn_col


''' <summary>
'''Локальная переменная для дочернего раздела Связанные представления
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_PARTVIEW_LNK As PARTVIEW_LNK_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_FilterField2=   
            ' m_FilterField0=   
            ' m_the_Alias=   
            ' m_ForChoose=   
            ' m_FilterField1=   
            ' m_FilterField3=   
            ' m_Name=   
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
                    Value = the_Alias
                Case 3
                    Value = ForChoose
                Case 4
                    Value = FilterField0
                Case 5
                    Value = FilterField1
                Case 6
                    Value = FilterField2
                Case 7
                    Value = FilterField3
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
                    ForChoose = value
                Case 4
                    FilterField0 = value
                Case 5
                    FilterField1 = value
                Case 6
                    FilterField2 = value
                Case 7
                    FilterField3 = value
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
                    Return "ForChoose"
                Case 4
                    Return "FilterField0"
                Case 5
                    Return "FilterField1"
                Case 6
                    Return "FilterField2"
                Case 7
                    Return "FilterField3"
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
             select case ForChoose
            case enumBoolean.Boolean_Da
              dr ("ForChoose")  = "Да"
              dr ("ForChoose_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("ForChoose")  = "Нет"
              dr ("ForChoose_VAL")  = 0
              end select 'ForChoose
             dr("FilterField0") =FilterField0
             dr("FilterField1") =FilterField1
             dr("FilterField2") =FilterField2
             dr("FilterField3") =FilterField3
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
            mFindInside = ViewColumn.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = PARTVIEW_LNK.FindObject(table,RowID)
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
          nv.Add("Name", Name, dbtype.string)
          nv.Add("the_Alias", the_Alias, dbtype.string)
          nv.Add("ForChoose", ForChoose, dbtype.int16)
          nv.Add("FilterField0", FilterField0, dbtype.string)
          nv.Add("FilterField1", FilterField1, dbtype.string)
          nv.Add("FilterField2", FilterField2, dbtype.string)
          nv.Add("FilterField3", FilterField3, dbtype.string)
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
          If reader.Table.Columns.Contains("ForChoose") Then m_ForChoose=reader.item("ForChoose")
          If reader.Table.Columns.Contains("FilterField0") Then m_FilterField0=reader.item("FilterField0").ToString()
          If reader.Table.Columns.Contains("FilterField1") Then m_FilterField1=reader.item("FilterField1").ToString()
          If reader.Table.Columns.Contains("FilterField2") Then m_FilterField2=reader.item("FilterField2").ToString()
          If reader.Table.Columns.Contains("FilterField3") Then m_FilterField3=reader.item("FilterField3").ToString()
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
'''Доступ к полю Для поиска
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ForChoose() As enumBoolean
            Get
                LoadFromDatabase()
                ForChoose = m_ForChoose
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_ForChoose = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле - фильтр 0
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FilterField0() As String
            Get
                LoadFromDatabase()
                FilterField0 = m_FilterField0
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FilterField0 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле - фильтр 1
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FilterField1() As String
            Get
                LoadFromDatabase()
                FilterField1 = m_FilterField1
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FilterField1 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле - фильтр 2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FilterField2() As String
            Get
                LoadFromDatabase()
                FilterField2 = m_FilterField2
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FilterField2 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле - фильтр 3
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FilterField3() As String
            Get
                LoadFromDatabase()
                FilterField3 = m_FilterField3
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FilterField3 = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Колонка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ViewColumn() As ViewColumn_col
            Get
                if  m_ViewColumn is nothing then
                  m_ViewColumn = new ViewColumn_col
                  m_ViewColumn.Parent = me
                  m_ViewColumn.Application = me.Application
                  m_ViewColumn.Refresh
                end if
                ViewColumn = m_ViewColumn
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Связанные представления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property PARTVIEW_LNK() As PARTVIEW_LNK_col
            Get
                if  m_PARTVIEW_LNK is nothing then
                  m_PARTVIEW_LNK = new PARTVIEW_LNK_col
                  m_PARTVIEW_LNK.Parent = me
                  m_PARTVIEW_LNK.Application = me.Application
                  m_PARTVIEW_LNK.Refresh
                end if
                PARTVIEW_LNK = m_PARTVIEW_LNK
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
            Name = node.Attributes.GetNamedItem("Name").Value
            the_Alias = node.Attributes.GetNamedItem("the_Alias").Value
            ForChoose = node.Attributes.GetNamedItem("ForChoose").Value
            FilterField0 = node.Attributes.GetNamedItem("FilterField0").Value
            FilterField1 = node.Attributes.GetNamedItem("FilterField1").Value
            FilterField2 = node.Attributes.GetNamedItem("FilterField2").Value
            FilterField3 = node.Attributes.GetNamedItem("FilterField3").Value
            e_list = node.SelectNodes("ViewColumn_COL")
            ViewColumn.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("PARTVIEW_LNK_COL")
            PARTVIEW_LNK.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            ViewColumn.Dispose
            PARTVIEW_LNK.Dispose
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
          node.SetAttribute("ForChoose", ForChoose)  
          node.SetAttribute("FilterField0", FilterField0)  
          node.SetAttribute("FilterField1", FilterField1)  
          node.SetAttribute("FilterField2", FilterField2)  
          node.SetAttribute("FilterField3", FilterField3)  
            ViewColumn.XMLSave(node,xdom)
            PARTVIEW_LNK.XMLSave(node,xdom)
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
            ViewColumn.BatchUpdate
            PARTVIEW_LNK.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 2
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
            return ViewColumn
         Case 2
            return PARTVIEW_LNK
            End Select
            return nothing
        End Function
    End Class
End Namespace
