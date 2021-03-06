
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace MTZwp


''' <summary>
'''Реализация строки раздела Поведение журналов
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class ARMJournal
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_TheJournal  as System.Guid


''' <summary>
'''Локальная переменная для дочернего раздела Отчеты
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ARMJRNLREP As ARMJRNLREP_col


''' <summary>
'''Локальная переменная для дочернего раздела Действия
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ARMJRNLRUN As ARMJRNLRUN_col


''' <summary>
'''Локальная переменная для дочернего раздела Добавление
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_ARMJRNLADD As ARMJRNLADD_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_TheJournal=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 1
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
                    Value = TheJournal
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
                    TheJournal = value
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
                    Return "TheJournal"
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
             if TheJournal is nothing then
               dr("TheJournal") =system.dbnull.value
               dr("TheJournal_ID") =System.Guid.Empty
             else
               dr("TheJournal") =TheJournal.BRIEF
               dr("TheJournal_ID") =TheJournal.ID
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
            mFindInside = ARMJRNLREP.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = ARMJRNLRUN.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            mFindInside = ARMJRNLADD.FindObject(table,RowID)
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
          if m_TheJournal.Equals(System.Guid.Empty) then
            nv.Add("TheJournal", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("TheJournal", Application.Session.GetProvider.ID2Param(m_TheJournal), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
      If reader.Table.Columns.Contains("TheJournal") Then
          if isdbnull(reader.item("TheJournal")) then
            If reader.Table.Columns.Contains("TheJournal") Then m_TheJournal = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("TheJournal") Then m_TheJournal= New System.Guid(reader.item("TheJournal").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Журнал
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property TheJournal() As LATIR2.Document.doc_base
            Get
                LoadFromDatabase()
                TheJournal = me.application.manager.GetInstanceObject(m_TheJournal)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.doc_base )
                LoadFromDatabase()
                if not  Value is nothing then
                  m_TheJournal = Value.id
                else
                  m_TheJournal =System.Guid.Empty 
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Отчеты
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ARMJRNLREP() As ARMJRNLREP_col
            Get
                if  m_ARMJRNLREP is nothing then
                  m_ARMJRNLREP = new ARMJRNLREP_col
                  m_ARMJRNLREP.Parent = me
                  m_ARMJRNLREP.Application = me.Application
                  m_ARMJRNLREP.Refresh
                end if
                ARMJRNLREP = m_ARMJRNLREP
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Действия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ARMJRNLRUN() As ARMJRNLRUN_col
            Get
                if  m_ARMJRNLRUN is nothing then
                  m_ARMJRNLRUN = new ARMJRNLRUN_col
                  m_ARMJRNLRUN.Parent = me
                  m_ARMJRNLRUN.Application = me.Application
                  m_ARMJRNLRUN.Refresh
                end if
                ARMJRNLRUN = m_ARMJRNLRUN
                AccessTime = Now
            End Get
        End Property


''' <summary>
'''Доступ к дочернему разделу Добавление
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property ARMJRNLADD() As ARMJRNLADD_col
            Get
                if  m_ARMJRNLADD is nothing then
                  m_ARMJRNLADD = new ARMJRNLADD_col
                  m_ARMJRNLADD.Parent = me
                  m_ARMJRNLADD.Application = me.Application
                  m_ARMJRNLADD.Refresh
                end if
                ARMJRNLADD = m_ARMJRNLADD
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
            m_TheJournal = new system.guid(node.Attributes.GetNamedItem("TheJournal").Value)
            e_list = node.SelectNodes("ARMJRNLREP_COL")
            ARMJRNLREP.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("ARMJRNLRUN_COL")
            ARMJRNLRUN.XMLLoad(e_list,LoadMode)
            e_list = node.SelectNodes("ARMJRNLADD_COL")
            ARMJRNLADD.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            ARMJRNLREP.Dispose
            ARMJRNLRUN.Dispose
            ARMJRNLADD.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("TheJournal", m_TheJournal.tostring)  
            ARMJRNLREP.XMLSave(node,xdom)
            ARMJRNLRUN.XMLSave(node,xdom)
            ARMJRNLADD.XMLSave(node,xdom)
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
            ARMJRNLREP.BatchUpdate
            ARMJRNLRUN.BatchUpdate
            ARMJRNLADD.BatchUpdate
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
            return ARMJRNLADD
         Case 2
            return ARMJRNLREP
         Case 3
            return ARMJRNLRUN
            End Select
            return nothing
        End Function
    End Class
End Namespace
