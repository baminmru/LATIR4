
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
'''Реализация строки раздела Методы и процедуры
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class SHAREDMETHOD
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Описание метода
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Comment  as STRING


''' <summary>
'''Локальная переменная для поля Возвращаемый тип
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ReturnType  as System.Guid


''' <summary>
'''Локальная переменная для дочернего раздела Реализация
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_SCRIPT As SCRIPT_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_the_Comment=   
            ' m_ReturnType=   
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
                    Value = the_Comment
                Case 3
                    Value = ReturnType
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
                    the_Comment = value
                Case 3
                    ReturnType = value
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
                    Return "the_Comment"
                Case 3
                    Return "ReturnType"
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
             dr("the_Comment") =the_Comment
             if ReturnType is nothing then
               dr("ReturnType") =system.dbnull.value
               dr("ReturnType_ID") =System.Guid.Empty
             else
               dr("ReturnType") =ReturnType.BRIEF
               dr("ReturnType_ID") =ReturnType.ID
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
            mFindInside = SCRIPT.FindObject(table,RowID)
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
          nv.Add("the_Comment", the_Comment, dbtype.string)
          if m_ReturnType.Equals(System.Guid.Empty) then
            nv.Add("ReturnType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ReturnType", Application.Session.GetProvider.ID2Param(m_ReturnType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("the_Comment") Then m_the_Comment=reader.item("the_Comment").ToString()
      If reader.Table.Columns.Contains("ReturnType") Then
          if isdbnull(reader.item("ReturnType")) then
            If reader.Table.Columns.Contains("ReturnType") Then m_ReturnType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ReturnType") Then m_ReturnType= New System.Guid(reader.item("ReturnType").ToString())
          end if 
      end if 
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
'''Доступ к полю Описание метода
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Comment() As STRING
            Get
                LoadFromDatabase()
                the_Comment = m_the_Comment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_the_Comment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Возвращаемый тип
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ReturnType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ReturnType = me.application.Findrowobject("FIELDTYPE",m_ReturnType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ReturnType = Value.id
                else
                   m_ReturnType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Реализация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property SCRIPT() As SCRIPT_col
            Get
                if  m_SCRIPT is nothing then
                  m_SCRIPT = new SCRIPT_col
                  m_SCRIPT.Parent = me
                  m_SCRIPT.Application = me.Application
                  m_SCRIPT.Refresh
                end if
                SCRIPT = m_SCRIPT
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
            the_Comment = node.Attributes.GetNamedItem("the_Comment").Value
            m_ReturnType = new system.guid(node.Attributes.GetNamedItem("ReturnType").Value)
            e_list = node.SelectNodes("SCRIPT_COL")
            SCRIPT.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            SCRIPT.Dispose
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
          node.SetAttribute("the_Comment", the_Comment)  
          node.SetAttribute("ReturnType", m_ReturnType.tostring)  
            SCRIPT.XMLSave(node,xdom)
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
            SCRIPT.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 1
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
            return SCRIPT
            End Select
            return nothing
        End Function
    End Class
End Namespace
