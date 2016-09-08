
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
'''Реализация строки раздела Ограничения полей
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class FIELDRESTRICTION
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Обязательное поле
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_MandatoryField  as enumTriState


''' <summary>
'''Локальная переменная для поля Поле, на которое накладывается ограничение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheField  as System.Guid


''' <summary>
'''Локальная переменная для поля Структура, которой принадлежит поле
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ThePart  as System.Guid


''' <summary>
'''Локальная переменная для поля Разрешена модификация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowModify  as enumBoolean


''' <summary>
'''Локальная переменная для поля Разрешен просмотр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowRead  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_MandatoryField=   
            ' m_TheField=   
            ' m_ThePart=   
            ' m_AllowModify=   
            ' m_AllowRead=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 5
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
                    Value = ThePart
                Case 2
                    Value = TheField
                Case 3
                    Value = AllowRead
                Case 4
                    Value = AllowModify
                Case 5
                    Value = MandatoryField
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
                    ThePart = value
                Case 2
                    TheField = value
                Case 3
                    AllowRead = value
                Case 4
                    AllowModify = value
                Case 5
                    MandatoryField = value
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
                    Return "ThePart"
                Case 2
                    Return "TheField"
                Case 3
                    Return "AllowRead"
                Case 4
                    Return "AllowModify"
                Case 5
                    Return "MandatoryField"
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
             if ThePart is nothing then
               dr("ThePart") =system.dbnull.value
               dr("ThePart_ID") =System.Guid.Empty
             else
               dr("ThePart") =ThePart.BRIEF
               dr("ThePart_ID") =ThePart.ID
             end if 
             if TheField is nothing then
               dr("TheField") =system.dbnull.value
               dr("TheField_ID") =System.Guid.Empty
             else
               dr("TheField") =TheField.BRIEF
               dr("TheField_ID") =TheField.ID
             end if 
             select case AllowRead
            case enumBoolean.Boolean_Da
              dr ("AllowRead")  = "Да"
              dr ("AllowRead_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowRead")  = "Нет"
              dr ("AllowRead_VAL")  = 0
              end select 'AllowRead
             select case AllowModify
            case enumBoolean.Boolean_Da
              dr ("AllowModify")  = "Да"
              dr ("AllowModify_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowModify")  = "Нет"
              dr ("AllowModify_VAL")  = 0
              end select 'AllowModify
             select case MandatoryField
            case enumTriState.TriState_Ne_susestvenno
              dr ("MandatoryField")  = "Не существенно"
              dr ("MandatoryField_VAL")  = -1
            case enumTriState.TriState_Da
              dr ("MandatoryField")  = "Да"
              dr ("MandatoryField_VAL")  = 1
            case enumTriState.TriState_Net
              dr ("MandatoryField")  = "Нет"
              dr ("MandatoryField_VAL")  = 0
              end select 'MandatoryField
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
          if m_ThePart.Equals(System.Guid.Empty) then
            nv.Add("ThePart", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ThePart", Application.Session.GetProvider.ID2Param(m_ThePart), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_TheField.Equals(System.Guid.Empty) then
            nv.Add("TheField", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheField", Application.Session.GetProvider.ID2Param(m_TheField), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AllowRead", AllowRead, dbtype.int16)
          nv.Add("AllowModify", AllowModify, dbtype.int16)
          nv.Add("MandatoryField", MandatoryField, dbtype.int16)
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
      If reader.Table.Columns.Contains("ThePart") Then
          if isdbnull(reader.item("ThePart")) then
            If reader.Table.Columns.Contains("ThePart") Then m_ThePart = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ThePart") Then m_ThePart= New System.Guid(reader.item("ThePart").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("TheField") Then
          if isdbnull(reader.item("TheField")) then
            If reader.Table.Columns.Contains("TheField") Then m_TheField = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheField") Then m_TheField= New System.Guid(reader.item("TheField").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AllowRead") Then m_AllowRead=reader.item("AllowRead")
          If reader.Table.Columns.Contains("AllowModify") Then m_AllowModify=reader.item("AllowModify")
          If reader.Table.Columns.Contains("MandatoryField") Then m_MandatoryField=reader.item("MandatoryField")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Структура, которой принадлежит поле
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ThePart() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ThePart = me.application.Findrowobject("PART",m_ThePart)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ThePart = Value.id
                else
                   m_ThePart=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле, на которое накладывается ограничение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheField() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                TheField = me.application.Findrowobject("FIELD",m_TheField)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_TheField = Value.id
                else
                   m_TheField=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешен просмотр
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowRead() As enumBoolean
            Get
                LoadFromDatabase()
                AllowRead = m_AllowRead
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowRead = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешена модификация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowModify() As enumBoolean
            Get
                LoadFromDatabase()
                AllowModify = m_AllowModify
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowModify = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Обязательное поле
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property MandatoryField() As enumTriState
            Get
                LoadFromDatabase()
                MandatoryField = m_MandatoryField
                AccessTime = Now
            End Get
            Set(ByVal Value As enumTriState )
                LoadFromDatabase()
                m_MandatoryField = Value
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
            m_ThePart = new system.guid(node.Attributes.GetNamedItem("ThePart").Value)
            m_TheField = new system.guid(node.Attributes.GetNamedItem("TheField").Value)
            AllowRead = node.Attributes.GetNamedItem("AllowRead").Value
            AllowModify = node.Attributes.GetNamedItem("AllowModify").Value
            MandatoryField = node.Attributes.GetNamedItem("MandatoryField").Value
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
          node.SetAttribute("ThePart", m_ThePart.tostring)  
          node.SetAttribute("TheField", m_TheField.tostring)  
          node.SetAttribute("AllowRead", AllowRead)  
          node.SetAttribute("AllowModify", AllowModify)  
          node.SetAttribute("MandatoryField", MandatoryField)  
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
