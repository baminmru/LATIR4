
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace mtzjrnl


''' <summary>
'''Реализация строки раздела Колонки журнала
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class journalcolumn
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_sequence  as long


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Выравнивание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_columnalignment  as enumVHAlignment


''' <summary>
'''Локальная переменная для поля Сортировка колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_colsort  as enumColumnSortType


''' <summary>
'''Локальная переменная для поля Аггрегация при группировке
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_groupaggregation  as enumAggregationType


''' <summary>
'''Локальная переменная для дочернего раздела Состав колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_jcolumnsource As jcolumnsource_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_sequence=   
            ' m_name=   
            ' m_columnalignment=   
            ' m_colsort=   
            ' m_groupaggregation=   
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
                    Value = sequence
                Case 2
                    Value = name
                Case 3
                    Value = columnalignment
                Case 4
                    Value = colsort
                Case 5
                    Value = groupaggregation
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
                    sequence = value
                Case 2
                    name = value
                Case 3
                    columnalignment = value
                Case 4
                    colsort = value
                Case 5
                    groupaggregation = value
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
                    Return "sequence"
                Case 2
                    Return "name"
                Case 3
                    Return "columnalignment"
                Case 4
                    Return "colsort"
                Case 5
                    Return "groupaggregation"
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
             dr("sequence") =sequence
             dr("name") =name
             select case columnalignment
            case enumVHAlignment.VHAlignment_Right_Top
              dr ("columnalignment")  = "Right Top"
              dr ("columnalignment_VAL")  = 6
            case enumVHAlignment.VHAlignment_Right_Center
              dr ("columnalignment")  = "Right Center"
              dr ("columnalignment_VAL")  = 7
            case enumVHAlignment.VHAlignment_Right_Bottom
              dr ("columnalignment")  = "Right Bottom"
              dr ("columnalignment_VAL")  = 8
            case enumVHAlignment.VHAlignment_Center_Top
              dr ("columnalignment")  = "Center Top"
              dr ("columnalignment_VAL")  = 3
            case enumVHAlignment.VHAlignment_Left_Top
              dr ("columnalignment")  = "Left Top"
              dr ("columnalignment_VAL")  = 0
            case enumVHAlignment.VHAlignment_Center_Center
              dr ("columnalignment")  = "Center Center"
              dr ("columnalignment_VAL")  = 4
            case enumVHAlignment.VHAlignment_Left_Center
              dr ("columnalignment")  = "Left Center"
              dr ("columnalignment_VAL")  = 1
            case enumVHAlignment.VHAlignment_Center_Bottom
              dr ("columnalignment")  = "Center Bottom"
              dr ("columnalignment_VAL")  = 5
            case enumVHAlignment.VHAlignment_Left_Bottom
              dr ("columnalignment")  = "Left Bottom"
              dr ("columnalignment_VAL")  = 2
              end select 'columnalignment
             select case colsort
            case enumColumnSortType.ColumnSortType_As_String
              dr ("colsort")  = "As String"
              dr ("colsort_VAL")  = 0
            case enumColumnSortType.ColumnSortType_As_Numeric
              dr ("colsort")  = "As Numeric"
              dr ("colsort_VAL")  = 1
            case enumColumnSortType.ColumnSortType_As_Date
              dr ("colsort")  = "As Date"
              dr ("colsort_VAL")  = 2
              end select 'colsort
             select case groupaggregation
            case enumAggregationType.AggregationType_SUM
              dr ("groupaggregation")  = "SUM"
              dr ("groupaggregation_VAL")  = 3
            case enumAggregationType.AggregationType_AVG
              dr ("groupaggregation")  = "AVG"
              dr ("groupaggregation_VAL")  = 1
            case enumAggregationType.AggregationType_CUSTOM
              dr ("groupaggregation")  = "CUSTOM"
              dr ("groupaggregation_VAL")  = 6
            case enumAggregationType.AggregationType_none
              dr ("groupaggregation")  = "none"
              dr ("groupaggregation_VAL")  = 0
            case enumAggregationType.AggregationType_COUNT
              dr ("groupaggregation")  = "COUNT"
              dr ("groupaggregation_VAL")  = 2
            case enumAggregationType.AggregationType_MAX
              dr ("groupaggregation")  = "MAX"
              dr ("groupaggregation_VAL")  = 5
            case enumAggregationType.AggregationType_MIN
              dr ("groupaggregation")  = "MIN"
              dr ("groupaggregation_VAL")  = 4
              end select 'groupaggregation
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
            mFindInside = jcolumnsource.FindObject(table,RowID)
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
          nv.Add("sequence", sequence, dbtype.Int32)
          nv.Add("name", name, dbtype.string)
          nv.Add("columnalignment", columnalignment, dbtype.int16)
          nv.Add("colsort", colsort, dbtype.int16)
          nv.Add("groupaggregation", groupaggregation, dbtype.int16)
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
          If reader.Table.Columns.Contains("sequence") Then m_sequence=reader.item("sequence")
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("columnalignment") Then m_columnalignment=reader.item("columnalignment")
          If reader.Table.Columns.Contains("colsort") Then m_colsort=reader.item("colsort")
          If reader.Table.Columns.Contains("groupaggregation") Then m_groupaggregation=reader.item("groupaggregation")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Последовательность
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property sequence() As long
            Get
                LoadFromDatabase()
                sequence = m_sequence
                AccessTime = Now
            End Get
            Set(ByVal Value As long )
                LoadFromDatabase()
                m_sequence = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property name() As String
            Get
                LoadFromDatabase()
                name = m_name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_name = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Выравнивание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property columnalignment() As enumVHAlignment
            Get
                LoadFromDatabase()
                columnalignment = m_columnalignment
                AccessTime = Now
            End Get
            Set(ByVal Value As enumVHAlignment )
                LoadFromDatabase()
                m_columnalignment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Сортировка колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property colsort() As enumColumnSortType
            Get
                LoadFromDatabase()
                colsort = m_colsort
                AccessTime = Now
            End Get
            Set(ByVal Value As enumColumnSortType )
                LoadFromDatabase()
                m_colsort = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Аггрегация при группировке
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property groupaggregation() As enumAggregationType
            Get
                LoadFromDatabase()
                groupaggregation = m_groupaggregation
                AccessTime = Now
            End Get
            Set(ByVal Value As enumAggregationType )
                LoadFromDatabase()
                m_groupaggregation = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Состав колонки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property jcolumnsource() As jcolumnsource_col
            Get
                if  m_jcolumnsource is nothing then
                  m_jcolumnsource = new jcolumnsource_col
                  m_jcolumnsource.Parent = me
                  m_jcolumnsource.Application = me.Application
                  m_jcolumnsource.Refresh
                end if
                jcolumnsource = m_jcolumnsource
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
            sequence = node.Attributes.GetNamedItem("sequence").Value
            name = node.Attributes.GetNamedItem("name").Value
            columnalignment = node.Attributes.GetNamedItem("columnalignment").Value
            colsort = node.Attributes.GetNamedItem("colsort").Value
            groupaggregation = node.Attributes.GetNamedItem("groupaggregation").Value
            e_list = node.SelectNodes("jcolumnsource_COL")
            jcolumnsource.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            jcolumnsource.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("sequence", sequence)  
          node.SetAttribute("name", name)  
          node.SetAttribute("columnalignment", columnalignment)  
          node.SetAttribute("colsort", colsort)  
          node.SetAttribute("groupaggregation", groupaggregation)  
            jcolumnsource.XMLSave(node,xdom)
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
            jcolumnsource.BatchUpdate
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
            return jcolumnsource
            End Select
            return nothing
        End Function
    End Class
End Namespace
