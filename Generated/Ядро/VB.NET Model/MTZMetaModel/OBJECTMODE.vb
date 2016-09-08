
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
'''Реализация строки раздела Режим работы
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class OBJECTMODE
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheComment  as STRING


''' <summary>
'''Локальная переменная для поля Название режима
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Этот режим является основным режимом работы объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_DefaultMode  as enumBoolean


''' <summary>
'''Локальная переменная для дочернего раздела Органичения разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_STRUCTRESTRICTION As STRUCTRESTRICTION_col


''' <summary>
'''Локальная переменная для дочернего раздела Ограничения методов
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_METHODRESTRICTION As METHODRESTRICTION_col


''' <summary>
'''Локальная переменная для дочернего раздела Ограничения полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_FIELDRESTRICTION As FIELDRESTRICTION_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheComment=   
            ' m_Name=   
            ' m_DefaultMode=   
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
                    Value = DefaultMode
                Case 3
                    Value = TheComment
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
                    DefaultMode = value
                Case 3
                    TheComment = value
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
                    Return "DefaultMode"
                Case 3
                    Return "TheComment"
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
             select case DefaultMode
            case enumBoolean.Boolean_Da
              dr ("DefaultMode")  = "Да"
              dr ("DefaultMode_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("DefaultMode")  = "Нет"
              dr ("DefaultMode_VAL")  = 0
              end select 'DefaultMode
             dr("TheComment") =TheComment
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
            mFindInside = STRUCTRESTRICTION.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = METHODRESTRICTION.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = FIELDRESTRICTION.FindObject(table,RowID)
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
          nv.Add("DefaultMode", DefaultMode, dbtype.int16)
          nv.Add("TheComment", TheComment, dbtype.string)
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
          If reader.Table.Columns.Contains("DefaultMode") Then m_DefaultMode=reader.item("DefaultMode")
          If reader.Table.Columns.Contains("TheComment") Then m_TheComment=reader.item("TheComment").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Название режима
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
'''Доступ к полю Этот режим является основным режимом работы объекта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property DefaultMode() As enumBoolean
            Get
                LoadFromDatabase()
                DefaultMode = m_DefaultMode
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_DefaultMode = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheComment() As STRING
            Get
                LoadFromDatabase()
                TheComment = m_TheComment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_TheComment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Органичения разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property STRUCTRESTRICTION() As STRUCTRESTRICTION_col
            Get
                if  m_STRUCTRESTRICTION is nothing then
                  m_STRUCTRESTRICTION = new STRUCTRESTRICTION_col
                  m_STRUCTRESTRICTION.Parent = me
                  m_STRUCTRESTRICTION.Application = me.Application
                  m_STRUCTRESTRICTION.Refresh
                end if
                STRUCTRESTRICTION = m_STRUCTRESTRICTION
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Ограничения методов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property METHODRESTRICTION() As METHODRESTRICTION_col
            Get
                if  m_METHODRESTRICTION is nothing then
                  m_METHODRESTRICTION = new METHODRESTRICTION_col
                  m_METHODRESTRICTION.Parent = me
                  m_METHODRESTRICTION.Application = me.Application
                  m_METHODRESTRICTION.Refresh
                end if
                METHODRESTRICTION = m_METHODRESTRICTION
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Ограничения полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property FIELDRESTRICTION() As FIELDRESTRICTION_col
            Get
                if  m_FIELDRESTRICTION is nothing then
                  m_FIELDRESTRICTION = new FIELDRESTRICTION_col
                  m_FIELDRESTRICTION.Parent = me
                  m_FIELDRESTRICTION.Application = me.Application
                  m_FIELDRESTRICTION.Refresh
                end if
                FIELDRESTRICTION = m_FIELDRESTRICTION
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
            DefaultMode = node.Attributes.GetNamedItem("DefaultMode").Value
            TheComment = node.Attributes.GetNamedItem("TheComment").Value
            e_list = node.SelectNodes("STRUCTRESTRICTION_COL")
            STRUCTRESTRICTION.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("METHODRESTRICTION_COL")
            METHODRESTRICTION.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("FIELDRESTRICTION_COL")
            FIELDRESTRICTION.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            STRUCTRESTRICTION.Dispose
            METHODRESTRICTION.Dispose
            FIELDRESTRICTION.Dispose
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
          node.SetAttribute("DefaultMode", DefaultMode)  
          node.SetAttribute("TheComment", TheComment)  
            STRUCTRESTRICTION.XMLSave(node,xdom)
            METHODRESTRICTION.XMLSave(node,xdom)
            FIELDRESTRICTION.XMLSave(node,xdom)
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
            STRUCTRESTRICTION.BatchUpdate
            METHODRESTRICTION.BatchUpdate
            FIELDRESTRICTION.BatchUpdate
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
            return STRUCTRESTRICTION
         Case 2
            return FIELDRESTRICTION
         Case 3
            return METHODRESTRICTION
            End Select
            return nothing
        End Function
    End Class
End Namespace
