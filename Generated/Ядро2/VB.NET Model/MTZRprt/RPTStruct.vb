
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace MTZRprt


''' <summary>
'''Реализация строки раздела Секции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class RPTStruct
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Заголовок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Caption  as String


''' <summary>
'''Локальная переменная для дочернего раздела Поля секции
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_RPTFields As RPTFields_col


''' <summary>
'''Локальная переменная для дочерних записей раздела Секции
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_RPTStruct As RPTStruct_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_Caption=   
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
                    Value = Name
                Case 2
                    Value = Caption
            End Select
        else
        On Error Resume Next
        Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
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
                    Caption = value
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
                    Return "Caption"
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
            on error resume next
            dr("ID") =ID
            dr("Brief") =Brief
             dr("Name") =Name
             dr("Caption") =Caption
            DestDataTable.Rows.Add (dr)
        End Sub



''' <summary>
'''Найти строку в коллекции по идентификатору
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base
            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing
            mFindInside = RPTStruct.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = RPTFields.FindObject(table,RowID)
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
        If Me.Parent.Parent.GetType.name = Me.GetType.name Then
            nv.Add("ParentRowID",  Application.Session.GetProvider.ID2Param(Me.Parent.Parent.ID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        Else
             nv.Add("ParentRowID", system.dbnull.value,  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End If
          nv.Add("Name", Name, dbtype.string)
          nv.Add("Caption", Caption, dbtype.string)
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            on error resume next  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("Caption") Then m_Caption=reader.item("Caption").ToString()
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
'''Доступ к дочернему разделу Поля секции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property RPTFields() As RPTFields_col
            Get
                if  m_RPTFields is nothing then
                  m_RPTFields = new RPTFields_col
                  m_RPTFields.Parent = me
                  m_RPTFields.Application = me.Application
                  m_RPTFields.Refresh
                end if
                RPTFields = m_RPTFields
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Секции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property RPTStruct() As RPTStruct_col
            Get
                if  m_RPTStruct is nothing then
                  m_RPTStruct = new RPTStruct_col
                  m_RPTStruct.Parent = me
                  m_RPTStruct.Application = me.Application
                  m_RPTStruct.Refresh
                end if
                RPTStruct = m_RPTStruct
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
          on error resume next  
            Name = node.Attributes.GetNamedItem("Name").Value
            Caption = node.Attributes.GetNamedItem("Caption").Value
            e_list = node.SelectNodes("RPTStruct_COL")
            RPTStruct.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("RPTFields_COL")
            RPTFields.XMLLoad(e_list,LoadMode)
             Changed = true
        End sub
        Public Overrides Sub Dispose()
            RPTFields.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           on error resume next  
          node.SetAttribute("Name", Name)  
          node.SetAttribute("Caption", Caption)  
            RPTStruct.XMLSave(node,xdom)
            RPTFields.XMLSave(node,xdom)
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
            RPTStruct.BatchUpdate
            RPTFields.BatchUpdate
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
            return RPTFields
            End Select
            return nothing
        End Function
    End Class
End Namespace
