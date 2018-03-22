
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
'''Реализация строки раздела Ограничения методов
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class METHODRESTRICTION
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Запрещено использовать
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_IsRestricted  as enumBoolean


''' <summary>
'''Локальная переменная для поля Структура, которой принадлежит метод
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Part  as System.Guid


''' <summary>
'''Локальная переменная для поля Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Method  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_IsRestricted=   
            ' m_Part=   
            ' m_Method=   
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
                    Value = Part
                Case 2
                    Value = Method
                Case 3
                    Value = IsRestricted
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
                    Part = value
                Case 2
                    Method = value
                Case 3
                    IsRestricted = value
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
                    Return "Part"
                Case 2
                    Return "Method"
                Case 3
                    Return "IsRestricted"
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
             if Part is nothing then
               dr("Part") =system.dbnull.value
               dr("Part_ID") =System.Guid.Empty
             else
               dr("Part") =Part.BRIEF
               dr("Part_ID") =Part.ID
             end if 
             if Method is nothing then
               dr("Method") =system.dbnull.value
               dr("Method_ID") =System.Guid.Empty
             else
               dr("Method") =Method.BRIEF
               dr("Method_ID") =Method.ID
             end if 
             select case IsRestricted
            case enumBoolean.Boolean_Da
              dr ("IsRestricted")  = "Да"
              dr ("IsRestricted_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("IsRestricted")  = "Нет"
              dr ("IsRestricted_VAL")  = 0
              end select 'IsRestricted
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
          if m_Part.Equals(System.Guid.Empty) then
            nv.Add("Part", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Part", Application.Session.GetProvider.ID2Param(m_Part), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_Method.Equals(System.Guid.Empty) then
            nv.Add("Method", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("Method", Application.Session.GetProvider.ID2Param(m_Method), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("IsRestricted", IsRestricted, dbtype.int16)
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
      If reader.Table.Columns.Contains("Part") Then
          if isdbnull(reader.item("Part")) then
            If reader.Table.Columns.Contains("Part") Then m_Part = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Part") Then m_Part= New System.Guid(reader.item("Part").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("Method") Then
          if isdbnull(reader.item("Method")) then
            If reader.Table.Columns.Contains("Method") Then m_Method = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("Method") Then m_Method= New System.Guid(reader.item("Method").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("IsRestricted") Then m_IsRestricted=reader.item("IsRestricted")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Структура, которой принадлежит метод
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Part() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Part = me.application.Findrowobject("PART",m_Part)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Part = Value.id
                else
                   m_Part=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Метод
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Method() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                Method = me.application.Findrowobject("SHAREDMETHOD",m_Method)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_Method = Value.id
                else
                   m_Method=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Запрещено использовать
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property IsRestricted() As enumBoolean
            Get
                LoadFromDatabase()
                IsRestricted = m_IsRestricted
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_IsRestricted = Value
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
            m_Part = new system.guid(node.Attributes.GetNamedItem("Part").Value)
            m_Method = new system.guid(node.Attributes.GetNamedItem("Method").Value)
            IsRestricted = node.Attributes.GetNamedItem("IsRestricted").Value
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
          node.SetAttribute("Part", m_Part.tostring)  
          node.SetAttribute("Method", m_Method.tostring)  
          node.SetAttribute("IsRestricted", IsRestricted)  
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
