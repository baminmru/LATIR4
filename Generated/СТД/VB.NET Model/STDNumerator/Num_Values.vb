
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime

Namespace STDNumerator


''' <summary>
'''Реализация строки раздела Номера
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class Num_Values
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Значение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_Value  as long


''' <summary>
'''Локальная переменная для поля Идентификатор строки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OwnerRowID  as Guid


''' <summary>
'''Локальная переменная для поля Раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_OwnerPartName  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_Value=   
            ' m_OwnerRowID=   
            ' m_OwnerPartName=   
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
                    Value = the_Value
                Case 2
                    Value = OwnerPartName
                Case 3
                    Value = OwnerRowID
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
                    the_Value = value
                Case 2
                    OwnerPartName = value
                Case 3
                    OwnerRowID = value
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
                    Return "the_Value"
                Case 2
                    Return "OwnerPartName"
                Case 3
                    Return "OwnerRowID"
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
             dr("the_Value") =the_Value
             dr("OwnerPartName") =OwnerPartName
             dr("OwnerRowID") =OwnerRowID
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
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          nv.Add("the_Value", the_Value, dbtype.Int32)
          nv.Add("OwnerPartName", OwnerPartName, dbtype.string)
          nv.Add("OwnerRowID", OwnerRowID, dbtype.GUID)
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
          If reader.Table.Columns.Contains("the_Value") Then m_the_Value=reader.item("the_Value")
          If reader.Table.Columns.Contains("OwnerPartName") Then m_OwnerPartName=reader.item("OwnerPartName").ToString()
          If reader.Table.Columns.Contains("OwnerRowID") Then m_OwnerRowID=reader.item("OwnerRowID")
        End Sub


''' <summary>
'''Доступ к полю Значение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_Value() As long
            Get
                LoadFromDatabase()
                the_Value = m_the_Value
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_the_Value = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Раздел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OwnerPartName() As String
            Get
                LoadFromDatabase()
                OwnerPartName = m_OwnerPartName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_OwnerPartName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор строки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property OwnerRowID() As Guid
            Get
                LoadFromDatabase()
                OwnerRowID = m_OwnerRowID
                AccessTime = Now
            End Get
            Set(ByVal Value As Guid )
                LoadFromDatabase()
                m_OwnerRowID = Value
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
          on error resume next  
            the_Value = node.Attributes.GetNamedItem("the_Value").Value
            OwnerPartName = node.Attributes.GetNamedItem("OwnerPartName").Value
            m_OwnerRowID =new system.guid(node.Attributes.GetNamedItem("OwnerRowID").Value)
             Changed = true
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
           on error resume next  
          node.SetAttribute("the_Value", the_Value)  
          node.SetAttribute("OwnerPartName", OwnerPartName)  
          node.SetAttribute("OwnerRowID", OwnerRowID.ToString())  
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
