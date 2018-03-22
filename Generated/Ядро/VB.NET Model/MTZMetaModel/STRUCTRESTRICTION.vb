
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
'''Реализация строки раздела Органичения разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class STRUCTRESTRICTION
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Разрешено добавлять
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowAdd  as enumBoolean


''' <summary>
'''Локальная переменная для поля Разрешено удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowDelete  as enumBoolean


''' <summary>
'''Локальная переменная для поля Разрешен просмотр
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowRead  as enumBoolean


''' <summary>
'''Локальная переменная для поля структура, доступ к которой ограничен
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Struct  as System.Guid


''' <summary>
'''Локальная переменная для поля Разрешено изменять
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_AllowEdit  as enumBoolean



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_AllowAdd=   
            ' m_AllowDelete=   
            ' m_AllowRead=   
            ' m_Struct=   
            ' m_AllowEdit=   
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
                    Value = Struct
                Case 2
                    Value = AllowRead
                Case 3
                    Value = AllowAdd
                Case 4
                    Value = AllowEdit
                Case 5
                    Value = AllowDelete
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
                    Struct = value
                Case 2
                    AllowRead = value
                Case 3
                    AllowAdd = value
                Case 4
                    AllowEdit = value
                Case 5
                    AllowDelete = value
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
                    Return "Struct"
                Case 2
                    Return "AllowRead"
                Case 3
                    Return "AllowAdd"
                Case 4
                    Return "AllowEdit"
                Case 5
                    Return "AllowDelete"
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
             if Struct is nothing then
               dr("Struct") =system.dbnull.value
               dr("Struct_ID") =System.Guid.Empty
             else
               dr("Struct") =Struct.BRIEF
               dr("Struct_ID") =Struct.ID
             end if 
             select case AllowRead
            case enumBoolean.Boolean_Da
              dr ("AllowRead")  = "Да"
              dr ("AllowRead_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowRead")  = "Нет"
              dr ("AllowRead_VAL")  = 0
              end select 'AllowRead
             select case AllowAdd
            case enumBoolean.Boolean_Da
              dr ("AllowAdd")  = "Да"
              dr ("AllowAdd_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowAdd")  = "Нет"
              dr ("AllowAdd_VAL")  = 0
              end select 'AllowAdd
             select case AllowEdit
            case enumBoolean.Boolean_Da
              dr ("AllowEdit")  = "Да"
              dr ("AllowEdit_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowEdit")  = "Нет"
              dr ("AllowEdit_VAL")  = 0
              end select 'AllowEdit
             select case AllowDelete
            case enumBoolean.Boolean_Da
              dr ("AllowDelete")  = "Да"
              dr ("AllowDelete_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("AllowDelete")  = "Нет"
              dr ("AllowDelete_VAL")  = 0
              end select 'AllowDelete
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
          if m_Struct.Equals(System.Guid.Empty) then
            nv.Add("Struct", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Struct", Application.Session.GetProvider.ID2Param(m_Struct), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("AllowRead", AllowRead, dbtype.int16)
          nv.Add("AllowAdd", AllowAdd, dbtype.int16)
          nv.Add("AllowEdit", AllowEdit, dbtype.int16)
          nv.Add("AllowDelete", AllowDelete, dbtype.int16)
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
      If reader.Table.Columns.Contains("Struct") Then
          if isdbnull(reader.item("Struct")) then
            If reader.Table.Columns.Contains("Struct") Then m_Struct = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Struct") Then m_Struct= New System.Guid(reader.item("Struct").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("AllowRead") Then m_AllowRead=reader.item("AllowRead")
          If reader.Table.Columns.Contains("AllowAdd") Then m_AllowAdd=reader.item("AllowAdd")
          If reader.Table.Columns.Contains("AllowEdit") Then m_AllowEdit=reader.item("AllowEdit")
          If reader.Table.Columns.Contains("AllowDelete") Then m_AllowDelete=reader.item("AllowDelete")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю структура, доступ к которой ограничен
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Struct() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Struct = me.application.Findrowobject("PART",m_Struct)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Struct = Value.id
                else
                   m_Struct=System.Guid.Empty
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
'''Доступ к полю Разрешено добавлять
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowAdd() As enumBoolean
            Get
                LoadFromDatabase()
                AllowAdd = m_AllowAdd
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowAdd = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешено изменять
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowEdit() As enumBoolean
            Get
                LoadFromDatabase()
                AllowEdit = m_AllowEdit
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowEdit = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Разрешено удалять
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property AllowDelete() As enumBoolean
            Get
                LoadFromDatabase()
                AllowDelete = m_AllowDelete
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_AllowDelete = Value
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
            m_Struct = new system.guid(node.Attributes.GetNamedItem("Struct").Value)
            AllowRead = node.Attributes.GetNamedItem("AllowRead").Value
            AllowAdd = node.Attributes.GetNamedItem("AllowAdd").Value
            AllowEdit = node.Attributes.GetNamedItem("AllowEdit").Value
            AllowDelete = node.Attributes.GetNamedItem("AllowDelete").Value
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
          node.SetAttribute("Struct", m_Struct.tostring)  
          node.SetAttribute("AllowRead", AllowRead)  
          node.SetAttribute("AllowAdd", AllowAdd)  
          node.SetAttribute("AllowEdit", AllowEdit)  
          node.SetAttribute("AllowDelete", AllowDelete)  
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
