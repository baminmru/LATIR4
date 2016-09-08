
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
'''Реализация строки раздела Параметры
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class PARAMETERS
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для поля Ссылка на раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefToPart  as System.Guid


''' <summary>
'''Локальная переменная для поля Возвращает значение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OutParam  as enumBoolean


''' <summary>
'''Локальная переменная для поля Размер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DataSize  as long


''' <summary>
'''Локальная переменная для поля Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Тип данных
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TypeOfParm  as System.Guid


''' <summary>
'''Локальная переменная для поля Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_sequence  as long


''' <summary>
'''Локальная переменная для поля Тип ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReferenceType  as enumReferenceType


''' <summary>
'''Локальная переменная для поля Можно не задавать
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowNull  as enumBoolean


''' <summary>
'''Локальная переменная для поля Ссылка на тип
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_RefToType  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Caption=   
            ' m_RefToPart=   
            ' m_OutParam=   
            ' m_DataSize=   
            ' m_Name=   
            ' m_TypeOfParm=   
            ' m_sequence=   
            ' m_ReferenceType=   
            ' m_AllowNull=   
            ' m_RefToType=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 10
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
                    Value = sequence
                Case 2
                    Value = Name
                Case 3
                    Value = Caption
                Case 4
                    Value = TypeOfParm
                Case 5
                    Value = DataSize
                Case 6
                    Value = AllowNull
                Case 7
                    Value = OutParam
                Case 8
                    Value = ReferenceType
                Case 9
                    Value = RefToType
                Case 10
                    Value = RefToPart
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
                    sequence = value
                Case 2
                    Name = value
                Case 3
                    Caption = value
                Case 4
                    TypeOfParm = value
                Case 5
                    DataSize = value
                Case 6
                    AllowNull = value
                Case 7
                    OutParam = value
                Case 8
                    ReferenceType = value
                Case 9
                    RefToType = value
                Case 10
                    RefToPart = value
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
                    Return "sequence"
                Case 2
                    Return "Name"
                Case 3
                    Return "Caption"
                Case 4
                    Return "TypeOfParm"
                Case 5
                    Return "DataSize"
                Case 6
                    Return "AllowNull"
                Case 7
                    Return "OutParam"
                Case 8
                    Return "ReferenceType"
                Case 9
                    Return "RefToType"
                Case 10
                    Return "RefToPart"
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
             dr("sequence") =sequence
             dr("Name") =Name
             dr("Caption") =Caption
             if TypeOfParm is nothing then
               dr("TypeOfParm") =system.dbnull.value
               dr("TypeOfParm_ID") =System.Guid.Empty
             else
               dr("TypeOfParm") =TypeOfParm.BRIEF
               dr("TypeOfParm_ID") =TypeOfParm.ID
             end if 
             dr("DataSize") =DataSize
             select case AllowNull
            case enumBoolean.Boolean_Da
              dr ("AllowNull")  = "Да"
              dr ("AllowNull_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowNull")  = "Нет"
              dr ("AllowNull_VAL")  = 0
              end select 'AllowNull
             select case OutParam
            case enumBoolean.Boolean_Da
              dr ("OutParam")  = "Да"
              dr ("OutParam_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("OutParam")  = "Нет"
              dr ("OutParam_VAL")  = 0
              end select 'OutParam
             select case ReferenceType
            case enumReferenceType.ReferenceType_Na_istocnik_dannih
              dr ("ReferenceType")  = "На источник данных"
              dr ("ReferenceType_VAL")  = 3
            case enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS
              dr ("ReferenceType")  = "Скалярное поле ( не ссылка)"
              dr ("ReferenceType_VAL")  = 0
            case enumReferenceType.ReferenceType_Na_stroku_razdela
              dr ("ReferenceType")  = "На строку раздела"
              dr ("ReferenceType_VAL")  = 2
            case enumReferenceType.ReferenceType_Na_ob_ekt_
              dr ("ReferenceType")  = "На объект "
              dr ("ReferenceType_VAL")  = 1
              end select 'ReferenceType
             if RefToType is nothing then
               dr("RefToType") =system.dbnull.value
               dr("RefToType_ID") =System.Guid.Empty
             else
               dr("RefToType") =RefToType.BRIEF
               dr("RefToType_ID") =RefToType.ID
             end if 
             if RefToPart is nothing then
               dr("RefToPart") =system.dbnull.value
               dr("RefToPart_ID") =System.Guid.Empty
             else
               dr("RefToPart") =RefToPart.BRIEF
               dr("RefToPart_ID") =RefToPart.ID
             end if 
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
          nv.Add("sequence", sequence, dbtype.Int32)
          nv.Add("Name", Name, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
          if m_TypeOfParm.Equals(System.Guid.Empty) then
            nv.Add("TypeOfParm", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TypeOfParm", Application.Session.GetProvider.ID2Param(m_TypeOfParm), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("DataSize", DataSize, dbtype.Int32)
          nv.Add("AllowNull", AllowNull, dbtype.int16)
          nv.Add("OutParam", OutParam, dbtype.int16)
          nv.Add("ReferenceType", ReferenceType, dbtype.int16)
          if m_RefToType.Equals(System.Guid.Empty) then
            nv.Add("RefToType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("RefToType", Application.Session.GetProvider.ID2Param(m_RefToType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_RefToPart.Equals(System.Guid.Empty) then
            nv.Add("RefToPart", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("RefToPart", Application.Session.GetProvider.ID2Param(m_RefToPart), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
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
          If reader.Table.Columns.Contains("sequence") Then m_sequence=reader.item("sequence")
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
      If reader.Table.Columns.Contains("TypeOfParm") Then
          if isdbnull(reader.item("TypeOfParm")) then
            If reader.Table.Columns.Contains("TypeOfParm") Then m_TypeOfParm = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TypeOfParm") Then m_TypeOfParm= New System.Guid(reader.item("TypeOfParm").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("DataSize") Then m_DataSize=reader.item("DataSize")
          If reader.Table.Columns.Contains("AllowNull") Then m_AllowNull=reader.item("AllowNull")
          If reader.Table.Columns.Contains("OutParam") Then m_OutParam=reader.item("OutParam")
          If reader.Table.Columns.Contains("ReferenceType") Then m_ReferenceType=reader.item("ReferenceType")
      If reader.Table.Columns.Contains("RefToType") Then
          if isdbnull(reader.item("RefToType")) then
            If reader.Table.Columns.Contains("RefToType") Then m_RefToType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("RefToType") Then m_RefToType= New System.Guid(reader.item("RefToType").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("RefToPart") Then
          if isdbnull(reader.item("RefToPart")) then
            If reader.Table.Columns.Contains("RefToPart") Then m_RefToPart = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("RefToPart") Then m_RefToPart= New System.Guid(reader.item("RefToPart").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property sequence() As long
            Get
                LoadFromDatabase()
                sequence = m_sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_sequence = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя
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
'''Доступ к полю Заголовок
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
'''Доступ к полю Тип данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TypeOfParm() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TypeOfParm = me.application.Findrowobject("FIELDTYPE",m_TypeOfParm)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TypeOfParm = Value.id
                else
                   m_TypeOfParm=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Размер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DataSize() As long
            Get
                LoadFromDatabase()
                DataSize = m_DataSize
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_DataSize = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Можно не задавать
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowNull() As enumBoolean
            Get
                LoadFromDatabase()
                AllowNull = m_AllowNull
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowNull = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Возвращает значение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OutParam() As enumBoolean
            Get
                LoadFromDatabase()
                OutParam = m_OutParam
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_OutParam = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип ссылки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReferenceType() As enumReferenceType
            Get
                LoadFromDatabase()
                ReferenceType = m_ReferenceType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumReferenceType )
                LoadFromDatabase()
                m_ReferenceType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ссылка на тип
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefToType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                RefToType = me.application.Findrowobject("OBJECTTYPE",m_RefToType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_RefToType = Value.id
                else
                   m_RefToType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Ссылка на раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property RefToPart() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                RefToPart = me.application.Findrowobject("PART",m_RefToPart)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_RefToPart = Value.id
                else
                   m_RefToPart=System.Guid.Empty
                end if
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
            sequence = node.Attributes.GetNamedItem("sequence").Value
            Name = node.Attributes.GetNamedItem("Name").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            m_TypeOfParm = new system.guid(node.Attributes.GetNamedItem("TypeOfParm").Value)
            DataSize = node.Attributes.GetNamedItem("DataSize").Value
            AllowNull = node.Attributes.GetNamedItem("AllowNull").Value
            OutParam = node.Attributes.GetNamedItem("OutParam").Value
            ReferenceType = node.Attributes.GetNamedItem("ReferenceType").Value
            m_RefToType = new system.guid(node.Attributes.GetNamedItem("RefToType").Value)
            m_RefToPart = new system.guid(node.Attributes.GetNamedItem("RefToPart").Value)
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
          node.SetAttribute("sequence", sequence)  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("Caption", Caption)  
          node.SetAttribute("TypeOfParm", m_TypeOfParm.tostring)  
          node.SetAttribute("DataSize", DataSize)  
          node.SetAttribute("AllowNull", AllowNull)  
          node.SetAttribute("OutParam", OutParam)  
          node.SetAttribute("ReferenceType", ReferenceType)  
          node.SetAttribute("RefToType", m_RefToType.tostring)  
          node.SetAttribute("RefToPart", m_RefToPart.tostring)  
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
