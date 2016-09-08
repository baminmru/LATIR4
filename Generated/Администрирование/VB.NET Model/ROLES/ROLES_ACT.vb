
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace ROLES


''' <summary>
'''Реализация строки раздела Разрешенные пункты меню
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ROLES_ACT
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Меню
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_MenuName  as String


''' <summary>
'''Локальная переменная для поля Код пункта меню
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_menuCode  as String


''' <summary>
'''Локальная переменная для поля Доступность
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Accesible  as enumYesNo



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_MenuName=   
            ' m_menuCode=   
            ' m_Accesible=   
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
                    Value = Accesible
                Case 2
                    Value = MenuName
                Case 3
                    Value = menuCode
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
                    Accesible = value
                Case 2
                    MenuName = value
                Case 3
                    menuCode = value
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
                    Return "Accesible"
                Case 2
                    Return "MenuName"
                Case 3
                    Return "menuCode"
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
             select case Accesible
            case enumYesNo.YesNo_Da
              dr ("Accesible")  = "Да"
              dr ("Accesible_VAL")  = 1
            case enumYesNo.YesNo_Net
              dr ("Accesible")  = "Нет"
              dr ("Accesible_VAL")  = 0
              end select 'Accesible
             dr("MenuName") =MenuName
             dr("menuCode") =menuCode
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
          nv.Add("Accesible", Accesible, dbtype.int16)
          nv.Add("MenuName", MenuName, dbtype.string)
          nv.Add("menuCode", menuCode, dbtype.string)
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
          If reader.Table.Columns.Contains("Accesible") Then m_Accesible=reader.item("Accesible")
          If reader.Table.Columns.Contains("MenuName") Then m_MenuName=reader.item("MenuName").ToString()
          If reader.Table.Columns.Contains("menuCode") Then m_menuCode=reader.item("menuCode").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Доступность
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Accesible() As enumYesNo
            Get
                LoadFromDatabase()
                Accesible = m_Accesible
                AccessTime = Now
            End Get
            Set(ByVal Value As enumYesNo )
                LoadFromDatabase()
                m_Accesible = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property MenuName() As String
            Get
                LoadFromDatabase()
                MenuName = m_MenuName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_MenuName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Код пункта меню
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property menuCode() As String
            Get
                LoadFromDatabase()
                menuCode = m_menuCode
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_menuCode = Value
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
            Accesible = node.Attributes.GetNamedItem("Accesible").Value
            MenuName = node.Attributes.GetNamedItem("MenuName").Value
            menuCode = node.Attributes.GetNamedItem("menuCode").Value
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
          node.SetAttribute("Accesible", Accesible)  
          node.SetAttribute("MenuName", MenuName)  
          node.SetAttribute("menuCode", menuCode)  
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
