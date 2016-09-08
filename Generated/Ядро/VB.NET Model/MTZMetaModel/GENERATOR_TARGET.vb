
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
'''Реализация строки раздела Генераторы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class GENERATOR_TARGET
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_GeneratorStyle  as enumGeneratorStyle


''' <summary>
'''Локальная переменная для поля Очередь
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_QueueName  as String


''' <summary>
'''Локальная переменная для поля Среда разработки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheDevelopmentEnv  as enumDevelopmentBase


''' <summary>
'''Локальная переменная для поля COM класс
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_GeneratorProgID  as String


''' <summary>
'''Локальная переменная для поля Тип платформы
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TargetType  as enumTargetType


''' <summary>
'''Локальная переменная для дочернего раздела Библиотеки
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_GENREFERENCE As GENREFERENCE_col


''' <summary>
'''Локальная переменная для дочернего раздела Ручной код
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_GENMANUALCODE As GENMANUALCODE_col


''' <summary>
'''Локальная переменная для дочернего раздела Контрольные элементы
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_GENCONTROLS As GENCONTROLS_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_GeneratorStyle=   
            ' m_QueueName=   
            ' m_TheDevelopmentEnv=   
            ' m_GeneratorProgID=   
            ' m_TargetType=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 6
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
                    Value = TargetType
                Case 3
                    Value = QueueName
                Case 4
                    Value = GeneratorProgID
                Case 5
                    Value = GeneratorStyle
                Case 6
                    Value = TheDevelopmentEnv
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
                    TargetType = value
                Case 3
                    QueueName = value
                Case 4
                    GeneratorProgID = value
                Case 5
                    GeneratorStyle = value
                Case 6
                    TheDevelopmentEnv = value
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
                    Return "TargetType"
                Case 3
                    Return "QueueName"
                Case 4
                    Return "GeneratorProgID"
                Case 5
                    Return "GeneratorStyle"
                Case 6
                    Return "TheDevelopmentEnv"
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
             select case TargetType
            case enumTargetType.TargetType_SUBD
              dr ("TargetType")  = "СУБД"
              dr ("TargetType_VAL")  = 0
            case enumTargetType.TargetType_Dokumentaciy
              dr ("TargetType")  = "Документация"
              dr ("TargetType_VAL")  = 3
            case enumTargetType.TargetType_MODEL_
              dr ("TargetType")  = "МОДЕЛЬ"
              dr ("TargetType_VAL")  = 1
            case enumTargetType.TargetType_Prilogenie
              dr ("TargetType")  = "Приложение"
              dr ("TargetType_VAL")  = 2
            case enumTargetType.TargetType_ARM
              dr ("TargetType")  = "АРМ"
              dr ("TargetType_VAL")  = 4
              end select 'TargetType
             dr("QueueName") =QueueName
             dr("GeneratorProgID") =GeneratorProgID
             select case GeneratorStyle
            case enumGeneratorStyle.GeneratorStyle_Odin_tip
              dr ("GeneratorStyle")  = "Один тип"
              dr ("GeneratorStyle_VAL")  = 0
            case enumGeneratorStyle.GeneratorStyle_Vse_tipi_srazu
              dr ("GeneratorStyle")  = "Все типы сразу"
              dr ("GeneratorStyle_VAL")  = 1
              end select 'GeneratorStyle
             select case TheDevelopmentEnv
            case enumDevelopmentBase.DevelopmentBase_OTHER
              dr ("TheDevelopmentEnv")  = "OTHER"
              dr ("TheDevelopmentEnv_VAL")  = 3
            case enumDevelopmentBase.DevelopmentBase_DOTNET
              dr ("TheDevelopmentEnv")  = "DOTNET"
              dr ("TheDevelopmentEnv_VAL")  = 1
            case enumDevelopmentBase.DevelopmentBase_JAVA
              dr ("TheDevelopmentEnv")  = "JAVA"
              dr ("TheDevelopmentEnv_VAL")  = 2
            case enumDevelopmentBase.DevelopmentBase_VB6
              dr ("TheDevelopmentEnv")  = "VB6"
              dr ("TheDevelopmentEnv_VAL")  = 0
              end select 'TheDevelopmentEnv
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
            mFindInside = GENREFERENCE.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = GENMANUALCODE.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = GENCONTROLS.FindObject(table,RowID)
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
          nv.Add("TargetType", TargetType, dbtype.int16)
          nv.Add("QueueName", QueueName, dbtype.string)
          nv.Add("GeneratorProgID", GeneratorProgID, dbtype.string)
          nv.Add("GeneratorStyle", GeneratorStyle, dbtype.int16)
          nv.Add("TheDevelopmentEnv", TheDevelopmentEnv, dbtype.int16)
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
          If reader.Table.Columns.Contains("TargetType") Then m_TargetType=reader.item("TargetType")
          If reader.Table.Columns.Contains("QueueName") Then m_QueueName=reader.item("QueueName").ToString()
          If reader.Table.Columns.Contains("GeneratorProgID") Then m_GeneratorProgID=reader.item("GeneratorProgID").ToString()
          If reader.Table.Columns.Contains("GeneratorStyle") Then m_GeneratorStyle=reader.item("GeneratorStyle")
          If reader.Table.Columns.Contains("TheDevelopmentEnv") Then m_TheDevelopmentEnv=reader.item("TheDevelopmentEnv")
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
'''Доступ к полю Тип платформы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TargetType() As enumTargetType
            Get
                LoadFromDatabase()
                TargetType = m_TargetType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumTargetType )
                LoadFromDatabase()
                m_TargetType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Очередь
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property QueueName() As String
            Get
                LoadFromDatabase()
                QueueName = m_QueueName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_QueueName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю COM класс
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property GeneratorProgID() As String
            Get
                LoadFromDatabase()
                GeneratorProgID = m_GeneratorProgID
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_GeneratorProgID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property GeneratorStyle() As enumGeneratorStyle
            Get
                LoadFromDatabase()
                GeneratorStyle = m_GeneratorStyle
                AccessTime = Now
            End Get
            Set(ByVal Value As enumGeneratorStyle )
                LoadFromDatabase()
                m_GeneratorStyle = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Среда разработки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheDevelopmentEnv() As enumDevelopmentBase
            Get
                LoadFromDatabase()
                TheDevelopmentEnv = m_TheDevelopmentEnv
                AccessTime = Now
            End Get
            Set(ByVal Value As enumDevelopmentBase )
                LoadFromDatabase()
                m_TheDevelopmentEnv = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Библиотеки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property GENREFERENCE() As GENREFERENCE_col
            Get
                if  m_GENREFERENCE is nothing then
                  m_GENREFERENCE = new GENREFERENCE_col
                  m_GENREFERENCE.Parent = me
                  m_GENREFERENCE.Application = me.Application
                  m_GENREFERENCE.Refresh
                end if
                GENREFERENCE = m_GENREFERENCE
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Ручной код
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property GENMANUALCODE() As GENMANUALCODE_col
            Get
                if  m_GENMANUALCODE is nothing then
                  m_GENMANUALCODE = new GENMANUALCODE_col
                  m_GENMANUALCODE.Parent = me
                  m_GENMANUALCODE.Application = me.Application
                  m_GENMANUALCODE.Refresh
                end if
                GENMANUALCODE = m_GENMANUALCODE
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Контрольные элементы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property GENCONTROLS() As GENCONTROLS_col
            Get
                if  m_GENCONTROLS is nothing then
                  m_GENCONTROLS = new GENCONTROLS_col
                  m_GENCONTROLS.Parent = me
                  m_GENCONTROLS.Application = me.Application
                  m_GENCONTROLS.Refresh
                end if
                GENCONTROLS = m_GENCONTROLS
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
            TargetType = node.Attributes.GetNamedItem("TargetType").Value
            QueueName = node.Attributes.GetNamedItem("QueueName").Value
            GeneratorProgID = node.Attributes.GetNamedItem("GeneratorProgID").Value
            GeneratorStyle = node.Attributes.GetNamedItem("GeneratorStyle").Value
            TheDevelopmentEnv = node.Attributes.GetNamedItem("TheDevelopmentEnv").Value
            e_list = node.SelectNodes("GENREFERENCE_COL")
            GENREFERENCE.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("GENMANUALCODE_COL")
            GENMANUALCODE.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("GENCONTROLS_COL")
            GENCONTROLS.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            GENREFERENCE.Dispose
            GENMANUALCODE.Dispose
            GENCONTROLS.Dispose
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
          node.SetAttribute("TargetType", TargetType)  
          node.SetAttribute("QueueName", QueueName)  
          node.SetAttribute("GeneratorProgID", GeneratorProgID)  
          node.SetAttribute("GeneratorStyle", GeneratorStyle)  
          node.SetAttribute("TheDevelopmentEnv", TheDevelopmentEnv)  
            GENREFERENCE.XMLSave(node,xdom)
            GENMANUALCODE.XMLSave(node,xdom)
            GENCONTROLS.XMLSave(node,xdom)
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
            GENREFERENCE.BatchUpdate
            GENMANUALCODE.BatchUpdate
            GENCONTROLS.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 3
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
            return GENREFERENCE
         Case 2
            return GENCONTROLS
         Case 3
            return GENMANUALCODE
            End Select
            return nothing
        End Function
    End Class
End Namespace
