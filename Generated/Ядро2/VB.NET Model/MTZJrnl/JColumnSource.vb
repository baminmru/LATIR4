
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZJrnl


''' <summary>
'''Реализация строки раздела Состав колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class JColumnSource
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Поле представления
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ViewField  as String


''' <summary>
'''Локальная переменная для поля Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SrcPartView  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_ViewField=   
            ' m_SrcPartView=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 2
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
                    Value = SrcPartView
                Case 2
                    Value = ViewField
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
                    SrcPartView = value
                Case 2
                    ViewField = value
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
                    Return "SrcPartView"
                Case 2
                    Return "ViewField"
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
             if SrcPartView is nothing then
               dr("SrcPartView") =system.dbnull.value
               dr("SrcPartView_ID") =System.Guid.Empty
             else
               dr("SrcPartView") =SrcPartView.BRIEF
               dr("SrcPartView_ID") =SrcPartView.ID
             end if 
             dr("ViewField") =ViewField
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
          if m_SrcPartView.Equals(System.Guid.Empty) then
            nv.Add("SrcPartView", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("SrcPartView", Application.Session.GetProvider.ID2Param(m_SrcPartView), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("ViewField", ViewField, dbtype.string)
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
      If reader.Table.Columns.Contains("SrcPartView") Then
          if isdbnull(reader.item("SrcPartView")) then
            If reader.Table.Columns.Contains("SrcPartView") Then m_SrcPartView = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("SrcPartView") Then m_SrcPartView= New System.Guid(reader.item("SrcPartView").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("ViewField") Then m_ViewField=reader.item("ViewField").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Представление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SrcPartView() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                SrcPartView = me.application.Findrowobject("JournalSrc",m_SrcPartView)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_SrcPartView = Value.id
                else
                   m_SrcPartView=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Поле представления
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ViewField() As String
            Get
                LoadFromDatabase()
                ViewField = m_ViewField
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_ViewField = Value
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
            m_SrcPartView = new system.guid(node.Attributes.GetNamedItem("SrcPartView").Value)
            ViewField = node.Attributes.GetNamedItem("ViewField").Value
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
          node.SetAttribute("SrcPartView", m_SrcPartView.tostring)  
          node.SetAttribute("ViewField", ViewField)  
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
