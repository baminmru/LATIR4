
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZSystem


''' <summary>
'''Реализация строки раздела Разрешенные владельцы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class SysRefCache
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля модуль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_modulename  as String


''' <summary>
'''Локальная переменная для поля Идентификатор владельца
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ObjectOwnerID  as Guid


''' <summary>
'''Локальная переменная для поля Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SessionID  as System.Guid


''' <summary>
'''Локальная переменная для поля Тип кеширования
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_CacheType  as enumCacheType



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_modulename=   
            ' m_ObjectOwnerID=   
            ' m_SessionID=   
            ' m_CacheType=   
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
                    Value = CacheType
                Case 2
                    Value = ObjectOwnerID
                Case 3
                    Value = SessionID
                Case 4
                    Value = modulename
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
                    CacheType = value
                Case 2
                    ObjectOwnerID = value
                Case 3
                    SessionID = value
                Case 4
                    modulename = value
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
                    Return "CacheType"
                Case 2
                    Return "ObjectOwnerID"
                Case 3
                    Return "SessionID"
                Case 4
                    Return "modulename"
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
             select case CacheType
            case enumCacheType.CacheType_Vse
              dr ("CacheType")  = "Все"
              dr ("CacheType_VAL")  = 2
            case enumCacheType.CacheType_Tol_ko_svoi
              dr ("CacheType")  = "Только свои"
              dr ("CacheType_VAL")  = 0
            case enumCacheType.CacheType_Podcinennie
              dr ("CacheType")  = "Подчиненные"
              dr ("CacheType_VAL")  = 1
              end select 'CacheType
             dr("ObjectOwnerID") =ObjectOwnerID
             if SessionID is nothing then
               dr("SessionID") =system.dbnull.value
               dr("SessionID_ID") =System.Guid.Empty
             else
               dr("SessionID") =SessionID.BRIEF
               dr("SessionID_ID") =SessionID.ID
             end if 
             dr("modulename") =modulename
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
          nv.Add("CacheType", CacheType, dbtype.int16)
          nv.Add("ObjectOwnerID", ObjectOwnerID, dbtype.GUID)
          if m_SessionID.Equals(System.Guid.Empty) then
            nv.Add("SessionID", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("SessionID", Application.Session.GetProvider.ID2Param(m_SessionID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("modulename", modulename, dbtype.string)
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
          If reader.Table.Columns.Contains("CacheType") Then m_CacheType=reader.item("CacheType")
      If reader.Table.Columns.Contains("ObjectOwnerID") Then
          if isdbnull(reader.item("ObjectOwnerID")) then
            If reader.Table.Columns.Contains("ObjectOwnerID") Then m_ObjectOwnerID = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ObjectOwnerID") Then m_ObjectOwnerID= New System.Guid(reader.item("ObjectOwnerID").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("SessionID") Then
          if isdbnull(reader.item("SessionID")) then
            If reader.Table.Columns.Contains("SessionID") Then m_SessionID = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("SessionID") Then m_SessionID= New System.Guid(reader.item("SessionID").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("modulename") Then m_modulename=reader.item("modulename").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Тип кеширования
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property CacheType() As enumCacheType
            Get
                LoadFromDatabase()
                CacheType = m_CacheType
                AccessTime = Now
            End Get
            Set(ByVal Value As enumCacheType )
                LoadFromDatabase()
                m_CacheType = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор владельца
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ObjectOwnerID() As Guid
            Get
                LoadFromDatabase()
                ObjectOwnerID = m_ObjectOwnerID
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_ObjectOwnerID = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сессия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SessionID() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                SessionID = me.application.Findrowobject("the_Session",m_SessionID)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_SessionID = Value.id
                else
                   m_SessionID=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю модуль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property modulename() As String
            Get
                LoadFromDatabase()
                modulename = m_modulename
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_modulename = Value
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
            CacheType = node.Attributes.GetNamedItem("CacheType").Value
            m_ObjectOwnerID =new system.guid(node.Attributes.GetNamedItem("ObjectOwnerID").Value)
            m_SessionID = new system.guid(node.Attributes.GetNamedItem("SessionID").Value)
            modulename = node.Attributes.GetNamedItem("modulename").Value
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
          node.SetAttribute("CacheType", CacheType)  
          node.SetAttribute("ObjectOwnerID", ObjectOwnerID.ToString())  
          node.SetAttribute("SessionID", m_SessionID.tostring)  
          node.SetAttribute("modulename", modulename)  
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
