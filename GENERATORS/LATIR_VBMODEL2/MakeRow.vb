Option Strict Off
Option Explicit On
Imports LATIR2Framework.StringHelper

Module MakeRowProc

    Public Sub MakeRow(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response)
        Dim s As String = String.Empty
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim p1 As MTZMetaModel.MTZMetaModel.PART
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        s = s & vbCrLf & "Option Explicit On"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Imports System"
        s = s & vbCrLf & "Imports System.IO"
        s = s & vbCrLf & "Imports LATIR2"
        s = s & vbCrLf & "Imports System.xml"
        s = s & vbCrLf & "Imports System.Data"
        s = s & vbCrLf & "Imports System.Convert"
        s = s & vbCrLf & "Imports System.DateTime"
        s = s & vbCrLf & "Imports System.Diagnostics"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Namespace " & ot.Name

        s = s & vbCrLf & MakeComment("Реализация строки раздела " & p.Caption)
        s = s & vbCrLf & "    Public Class " & p.name
        s = s & vbCrLf & "        Inherits LATIR2.Document.DocRow_Base"
        s = s & vbCrLf & ""


        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & MakeComment("Локальная переменная для поля " & f.Caption)
                    s = s & vbCrLf & "            private m_" & f.Name & "  as " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True)
                End If
            End If
        Next

        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & MakeComment("Локальная переменная для дочернего раздела " & p1.Caption)
            s = s & vbCrLf & "        private m_" & p1.Name & " As " & p1.Name & "_col"
        Next


        'Register Tree children
        If p.PartType = 2 Then
            s = s & vbCrLf & MakeComment("Локальная переменная для дочерних записей раздела " & p.Caption)
            s = s & vbCrLf & "        private m_" & p.Name & " As " & p.Name & "_col"
        End If

        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Очистить поля раздела")
        s = s & vbCrLf & "        Public Overrides Sub CleanFields()"

        Dim lFieldsCount As Long
        lFieldsCount = 0
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "            ' m_" & f.Name & "=   "
                    lFieldsCount = lFieldsCount + 1
                End If
            End If
        Next
        s = s & vbCrLf & "        End Sub"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Количество полей в строке раздела")
        s = s & vbCrLf & "    Public Overrides ReadOnly Property Count() As Long"
        s = s & vbCrLf & "        Get"
        s = s & vbCrLf & "           Count = " + CStr(lFieldsCount)
        s = s & vbCrLf & "        End Get"
        s = s & vbCrLf & "    End Property"
        s = s & vbCrLf & ""
        Dim lNowField As Long
        lNowField = 1
        s = s & vbCrLf & MakeComment("Получить \Задать поле по номеру ")
        s = s & vbCrLf & "Public Overrides Property Value(ByVal Index As Object) As Object"
        s = s & vbCrLf & "    Get"
        s = s & vbCrLf & "        If Microsoft.VisualBasic.IsNumeric(Index) Then"
        s = s & vbCrLf & "            Dim l As Long"
        s = s & vbCrLf & "            l = CLng(Index)"
        s = s & vbCrLf & "            Select Case l"
        s = s & vbCrLf & "                Case 0"
        s = s & vbCrLf & "                    Value = ID"

        p.FIELD.Sort = "sequence"
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "                Case " + CStr(lNowField)
                    s = s & vbCrLf & "                    Value = " + f.Name
                    lNowField = lNowField + 1
                End If
            End If
        Next
        s = s & vbCrLf & "            End Select"
        s = s & vbCrLf & "        else"
        s = s & vbCrLf & "        try"
        s = s & vbCrLf & "          Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)"
        s = s & vbCrLf & "           catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "              Value=nothing"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End If"
        s = s & vbCrLf & "    End Get"


        s = s & vbCrLf & "    Set(ByVal value As Object)"
        s = s & vbCrLf & "    If Microsoft.VisualBasic.IsNumeric(Index) Then"
        s = s & vbCrLf & "        Dim l As Long"
        s = s & vbCrLf & "        l = CLng(Index)"
        s = s & vbCrLf & "        Select Case l"
        s = s & vbCrLf & "            Case 0"
        s = s & vbCrLf & "                 ID=value"

        lNowField = 1
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "                Case " + CStr(lNowField)
                    s = s & vbCrLf & "                    " + f.Name + " = value"
                    lNowField = lNowField + 1
                End If
            End If
        Next
        s = s & vbCrLf & "        End Select"
        s = s & vbCrLf & "     Else"
        s = s & vbCrLf & "        Try"
        s = s & vbCrLf & "            Try"
        s = s & vbCrLf & "                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)"
        s = s & vbCrLf & "            Catch ex As Exception"
        s = s & vbCrLf & "                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)"
        s = s & vbCrLf & "            End Try"
        s = s & vbCrLf & "        Catch ex As Exception"
        s = s & vbCrLf & "        End Try"
        s = s & vbCrLf & "     End If"
        s = s & vbCrLf & "  End Set"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "End Property"
        s = s & vbCrLf & ""
        lNowField = 1
        s = s & vbCrLf & MakeComment("Название поля по номеру")
        s = s & vbCrLf & "Public Overrides Function FieldNameByID(ByVal Index As long) As String"

        s = s & vbCrLf & "        If Microsoft.VisualBasic.IsNumeric(Index) Then"
        s = s & vbCrLf & "            Dim l As Long"
        s = s & vbCrLf & "            l = CLng(Index)"
        s = s & vbCrLf & "            Select Case l"
        s = s & vbCrLf & "                Case 0"
        s = s & vbCrLf & "                   Return ""ID"""

        p.FIELD.Sort = "sequence"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "                Case " + CStr(lNowField)
                    s = s & vbCrLf & "                    Return """ + f.Name + """"
                    lNowField = lNowField + 1
                End If
            End If
        Next
        s = s & vbCrLf & "                Case else"
        s = s & vbCrLf & "                return """" "
        s = s & vbCrLf & "            End Select"
        s = s & vbCrLf & "        End If"
        s = s & vbCrLf & "        return """" "
        s = s & vbCrLf & "End Function"
        s = s & vbCrLf & ""

        s = s & vbCrLf & MakeComment("Заполнить строку таблицы данными из полей")
        s = s & vbCrLf & "        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)"
        s = s & vbCrLf & "            Dim dr As  DataRow"
        s = s & vbCrLf & "            dr = destdatatable.NewRow"
        s = s & vbCrLf & "            try"
        s = s & vbCrLf & "            dr(""ID"") =ID"
        s = s & vbCrLf & "            dr(""Brief"") =Brief"
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If ft.Name.ToLower() = "multiref" Then
                        s = s & vbCrLf & "             dr(""" & f.Name & """) =" & f.Name
                    Else
                        s = s & vbCrLf & "             if " & f.Name & " is nothing then"
                        s = s & vbCrLf & "               dr(""" & f.Name & """) =system.dbnull.value"
                        s = s & vbCrLf & "               dr(""" & f.Name & "_ID"") =System.Guid.Empty"
                        s = s & vbCrLf & "             else"
                        s = s & vbCrLf & "               dr(""" & f.Name & """) =" & f.Name & ".BRIEF"
                        s = s & vbCrLf & "               dr(""" & f.Name & "_ID"") =" & f.Name & ".ID"
                        s = s & vbCrLf & "             end if "
                    End If

                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    s = s & vbCrLf & "             select case " & f.Name
                    For j = 1 To ft.ENUMITEM.Count
                        s = s & vbCrLf & "            case " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True) & "." & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.Name) & "_" & LATIR2Framework.FieldTypesHelper.MakeValidName(ft.ENUMITEM.Item(j).Name)
                        s = s & vbCrLf & "              dr (""" & f.Name & """)  = """ & ft.ENUMITEM.Item(j).Name & """"
                        s = s & vbCrLf & "              dr (""" & f.Name & "_VAL"")  = " & ft.ENUMITEM.Item(j).NameValue
                    Next
                    s = s & vbCrLf & "              end select '" & f.Name
                Else
                    If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                        s = s & vbCrLf & "             dr(""" & f.Name & """) =" & f.Name
                    End If
                End If
            End If
        Next
        s = s & vbCrLf & "            DestDataTable.Rows.Add (dr)"
        s = s & vbCrLf & "           catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End Sub"


        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Найти строку в коллекции по идентификатору")
        s = s & vbCrLf & "        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base"
        s = s & vbCrLf & "            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing"

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "            mFindInside = " & p.Name & ".FindObject(table,RowID)"
            s = s & vbCrLf & "            if not mFindInside is nothing then return mFindInside"
        End If
        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & "            mFindInside = " & p1.Name & ".FindObject(table,RowID)"
            s = s & vbCrLf & "            if not mFindInside is nothing then return mFindInside"
        Next

        s = s & vbCrLf & "            Return Nothing"
        s = s & vbCrLf & "        End Function"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Заполнить коллекцю именованных полей")
        s = s & vbCrLf & "        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)"

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "        If Me.Parent.Parent.GetType.name = Me.GetType.name Then"
            s = s & vbCrLf & "            nv.Add(""ParentRowID"",  Application.Session.GetProvider.ID2Param(Me.Parent.Parent.ID), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)"
            s = s & vbCrLf & "        Else"
            s = s & vbCrLf & "             nv.Add(""ParentRowID"", system.dbnull.value,  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)"
            s = s & vbCrLf & "        End If"
        End If


        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                If ft.DelayedSave = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        If ft.Name.ToLower() = "multiref" Then
                            s = s & vbCrLf & "          nv.Add(""" & f.Name & """, " & f.Name & ", " & LATIR2Framework.FieldTypesHelper.MapDBtype(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) & ")"
                        Else
                            s = s & vbCrLf & "          if m_" & f.Name & ".Equals(System.Guid.Empty) then"
                            s = s & vbCrLf & "            nv.Add(""" & f.Name & """, system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)"
                            s = s & vbCrLf & "          else"
                            s = s & vbCrLf & "            nv.Add(""" & f.Name & """, Application.Session.GetProvider.ID2Param(m_" & f.Name & "), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)"
                            s = s & vbCrLf & "          end if "
                        End If

                    Else
                        If UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "DATE" Then
                            s = s & vbCrLf & "          if " & f.Name & "=System.DateTime.MinValue then"
                            s = s & vbCrLf & "            nv.Add(""" & f.Name & """, system.dbnull.value, " & LATIR2Framework.FieldTypesHelper.MapDBtype(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) & ")"
                            s = s & vbCrLf & "          else"
                            s = s & vbCrLf & "            nv.Add(""" & f.Name & """, " & f.Name & ", " & LATIR2Framework.FieldTypesHelper.MapDBtype(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) & ")"
                            s = s & vbCrLf & "          end if "
                        Else
                            If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True) <> String.Empty Then
                                s = s & vbCrLf & "          nv.Add(""" & f.Name & """, " & f.Name & ", " & LATIR2Framework.FieldTypesHelper.MapDBtype(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) & ")"
                            End If
                        End If
                    End If
                End If
            End If

        Next
        s = s & vbCrLf & "            nv.Add(PartName() & ""id"", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)"
        s = s & vbCrLf & "        End Sub"
        s = s & vbCrLf & ""



        '

        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Заполнить поля из именованной коллекции")
        s = s & vbCrLf & "        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)"
        s = s & vbCrLf & "            try  "
        s = s & vbCrLf & "            If IsDBNull(reader.item(""SecurityStyleID"")) Then"
        s = s & vbCrLf & "                SecureStyleID = System.guid.Empty"
        s = s & vbCrLf & "            Else"
        s = s & vbCrLf & "                SecureStyleID = new Guid(reader.item(""SecurityStyleID"").ToString())"
        s = s & vbCrLf & "            End If"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "            RowRetrived = True"
        s = s & vbCrLf & "            RetriveTime = Now"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If ft.Name.ToLower = "multiref" Then
                        s = s & vbCrLf & "          If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & "=reader.item(""" & f.Name & """)"
                    Else
                        s = s & vbCrLf & "      If reader.Table.Columns.Contains(""" & f.Name & """) Then"
                        s = s & vbCrLf & "          if isdbnull(reader.item(""" & f.Name & """)) then"
                        s = s & vbCrLf & "            If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & " = System.GUID.Empty"
                        s = s & vbCrLf & "          else"
                        s = s & vbCrLf & "            If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & "= New System.Guid(reader.item(""" & f.Name & """).ToString())"
                        s = s & vbCrLf & "          end if "
                        s = s & vbCrLf & "      end if "
                    End If

                Else
                    If UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "DATE" Then
                        s = s & vbCrLf & "      If reader.Table.Columns.Contains(""" & f.Name & """) Then"
                        s = s & vbCrLf & "          if isdbnull(reader.item(""" & f.Name & """)) then"
                        s = s & vbCrLf & "            If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & " = System.DateTime.MinValue"
                        s = s & vbCrLf & "          else"
                        s = s & vbCrLf & "            If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & "=reader.item(""" & f.Name & """)"
                        s = s & vbCrLf & "          end if "
                        s = s & vbCrLf & "      end if "
                    ElseIf UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "STRING" Then
                        's = s & vbCrLf & "          m_" & f.Name & "=reader.item(""" & f.Name & """).ToString()"
                        s = s & vbCrLf & "          If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & "=reader.item(""" & f.Name & """).ToString()"
                    Else
                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & "          If reader.Table.Columns.Contains(""" & f.Name & """) Then m_" & f.Name & "=reader.item(""" & f.Name & """)"
                        End If
                    End If
                End If
            End If
        Next
        s = s & vbCrLf & "           catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End Sub"


        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    If ft.Name.ToLower() = "multiref" Then

                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & MakeComment("Доступ к полю " & f.Caption)
                            s = s & vbCrLf & "        Public Property " & f.Name & "() As " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)
                            s = s & vbCrLf & "            Get"
                            s = s & vbCrLf & "                LoadFromDatabase()"
                            s = s & vbCrLf & "                " & f.Name & " = m_" & f.Name & ""
                            s = s & vbCrLf & "                AccessTime = Now"
                            s = s & vbCrLf & "            End Get"
                            s = s & vbCrLf & "            Set(ByVal Value As " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True) & " )"
                            s = s & vbCrLf & "                LoadFromDatabase()"
                            s = s & vbCrLf & "                m_" & f.Name & " = Value"
                            s = s & vbCrLf & "                ChangeTime = Now"
                            s = s & vbCrLf & "            End Set"
                            s = s & vbCrLf & "        End Property"
                        End If

                    Else



                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
                            MsgBox("Ссыслка " & p.Name & "." & f.Name & " неверно определена")
                        Else

                            ' ссылка на строку объекта
                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                If f.RefToPart Is Nothing Then
                                    MsgBox("Неверно определена ссылка для поля '" & f.Name & "' в таблице '" & p.Name & "'")
                                Else
                                    s = s & vbCrLf & MakeComment("Доступ к полю " & f.Caption)
                                    s = s & vbCrLf & "        Public Property " & f.Name & "() As LATIR2.Document.docrow_base"
                                    s = s & vbCrLf & "            Get"
                                    s = s & vbCrLf & "                LoadFromDatabase()"
                                    'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToPart.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                                    Dim RefToPart As MTZMetaModel.MTZMetaModel.PART = f.RefToPart
                                    s = s & vbCrLf & "                " & f.Name & " = me.application.Findrowobject(""" & RefToPart.Name & """,m_" & f.Name & ")"
                                    s = s & vbCrLf & "                AccessTime = Now"
                                    s = s & vbCrLf & "            End Get"
                                    s = s & vbCrLf & "            Set(ByVal Value As LATIR2.Document.docrow_base )"
                                    s = s & vbCrLf & "                LoadFromDatabase()"
                                    s = s & vbCrLf & "                if not Value is nothing then"
                                    s = s & vbCrLf & "                    m_" & f.Name & " = Value.id"
                                    s = s & vbCrLf & "                else"
                                    s = s & vbCrLf & "                   m_" & f.Name & "=System.Guid.Empty"
                                    s = s & vbCrLf & "                end if"
                                    s = s & vbCrLf & "                ChangeTime = Now"
                                    s = s & vbCrLf & "            End Set"
                                    s = s & vbCrLf & "        End Property"
                                End If
                            End If
                        End If

                        'ссылка на объект
                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                            s = s & vbCrLf & MakeComment("Доступ к полю " & f.Caption)
                            s = s & vbCrLf & "        Public Property " & f.Name & "() As LATIR2.Document.doc_base"
                            s = s & vbCrLf & "            Get"
                            s = s & vbCrLf & "                LoadFromDatabase()"
                            s = s & vbCrLf & "                " & f.Name & " = me.application.manager.GetInstanceObject(m_" & f.Name & ")"
                            s = s & vbCrLf & "                AccessTime = Now"
                            s = s & vbCrLf & "            End Get"
                            s = s & vbCrLf & "            Set(ByVal Value As LATIR2.Document.doc_base )"
                            s = s & vbCrLf & "                LoadFromDatabase()"
                            s = s & vbCrLf & "                if not  Value is nothing then"
                            s = s & vbCrLf & "                  m_" & f.Name & " = Value.id"
                            s = s & vbCrLf & "                else"
                            s = s & vbCrLf & "                  m_" & f.Name & " =System.Guid.Empty "
                            s = s & vbCrLf & "                end if"
                            s = s & vbCrLf & "                ChangeTime = Now"
                            s = s & vbCrLf & "            End Set"
                            s = s & vbCrLf & "        End Property"
                        End If
                    End If
                Else
                    If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                        s = s & vbCrLf & MakeComment("Доступ к полю " & f.Caption)
                        s = s & vbCrLf & "        Public Property " & f.Name & "() As " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)
                        s = s & vbCrLf & "            Get"
                        s = s & vbCrLf & "                LoadFromDatabase()"
                        s = s & vbCrLf & "                " & f.Name & " = m_" & f.Name & ""
                        s = s & vbCrLf & "                AccessTime = Now"
                        s = s & vbCrLf & "            End Get"
                        s = s & vbCrLf & "            Set(ByVal Value As " & LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True) & " )"
                        s = s & vbCrLf & "                LoadFromDatabase()"
                        s = s & vbCrLf & "                m_" & f.Name & " = Value"
                        s = s & vbCrLf & "                ChangeTime = Now"
                        s = s & vbCrLf & "            End Set"
                        s = s & vbCrLf & "        End Property"
                    End If
                End If
            End If
        Next


        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & MakeComment("Доступ к дочернему разделу " & p1.Caption)
            s = s & vbCrLf & "        Public readonly Property " & p1.Name & "() As " & p1.Name & "_col"
            s = s & vbCrLf & "            Get"
            s = s & vbCrLf & "                if  m_" & p1.Name & " is nothing then"
            s = s & vbCrLf & "                  m_" & p1.Name & " = new " & p1.Name & "_col"
            s = s & vbCrLf & "                  m_" & p1.Name & ".Parent = me"
            s = s & vbCrLf & "                  m_" & p1.Name & ".Application = me.Application"
            s = s & vbCrLf & "                  m_" & p1.Name & ".Refresh"
            s = s & vbCrLf & "                end if"
            s = s & vbCrLf & "                " & p1.Name & " = m_" & p1.Name & ""
            s = s & vbCrLf & "                AccessTime = Now"
            s = s & vbCrLf & "            End Get"
            s = s & vbCrLf & "        End Property"
        Next

        'Register Tree children
        If p.PartType = 2 Then
            s = s & vbCrLf & MakeComment("Доступ к дочернему разделу " & p.Caption)
            s = s & vbCrLf & "        Public readonly Property " & p.Name & "() As " & p.Name & "_col"
            s = s & vbCrLf & "            Get"
            s = s & vbCrLf & "                if  m_" & p.Name & " is nothing then"
            s = s & vbCrLf & "                  m_" & p.Name & " = new " & p.Name & "_col"
            s = s & vbCrLf & "                  m_" & p.Name & ".Parent = me"
            s = s & vbCrLf & "                  m_" & p.Name & ".Application = me.Application"
            s = s & vbCrLf & "                  m_" & p.Name & ".Refresh"
            s = s & vbCrLf & "                end if"
            s = s & vbCrLf & "                " & p.Name & " = m_" & p.Name & ""
            s = s & vbCrLf & "                AccessTime = Now"
            s = s & vbCrLf & "            End Get"
            s = s & vbCrLf & "        End Property"
        End If

        s = s & vbCrLf & MakeComment("Заполнить поля данными из XML")
        s = s & vbCrLf & "        Protected Overrides sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)"
        s = s & vbCrLf & "          Dim e_list As XmlNodeList"
        's = s & vbCrLf & "          XMLUnpack = Nothing"
        s = s & vbCrLf & "          try "
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If ft.Name.ToLower() = "multiref" Then
                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & "            " & f.Name & " = node.Attributes.GetNamedItem(""" & f.Name & """).Value"
                        End If
                    Else
                        s = s & vbCrLf & "            m_" & f.Name & " = new system.guid(node.Attributes.GetNamedItem(""" & f.Name & """).Value)"
                    End If

                Else
                    If UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "DATE" Then
                        s = s & vbCrLf & "            m_" & f.Name & " = System.DateTime.MinValue"
                        s = s & vbCrLf & "            " & f.Name & " = m_" & f.Name & ".AddTicks( node.Attributes.GetNamedItem(""" & f.Name & """).Value)"
                    ElseIf UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "GUID" Then
                        s = s & vbCrLf & "            m_" & f.Name & " =new system.guid(node.Attributes.GetNamedItem(""" & f.Name & """).Value)"
                    ElseIf UCase(ft.Name) = "IMAGE" Or
                            UCase(ft.Name) = "FILE" _
                            Then
                        s = s & vbCrLf & "            " & f.Name & " = System.Convert.FromBase64String(node.Attributes.GetNamedItem(""" & f.Name & """).Value.ToString())"
                    Else
                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & "            " & f.Name & " = node.Attributes.GetNamedItem(""" & f.Name & """).Value"
                        End If
                    End If


                End If
            End If
        Next

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "            e_list = node.SelectNodes(""" & p.Name & "_COL"")"
            s = s & vbCrLf & "            " & p.Name & ".XMLLoad(e_list,LoadMode)"
        End If

        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & "            e_list = node.SelectNodes(""" & p1.Name & "_COL"")"
            s = s & vbCrLf & "            " & p1.Name & ".XMLLoad(e_list,LoadMode)"
        Next
        s = s & vbCrLf & "             Changed = true"
        s = s & vbCrLf & "           catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End sub"

        s = s & vbCrLf & "        Public Overrides Sub Dispose()"
        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & "            " & p1.Name & ".Dispose"
        Next
        s = s & vbCrLf & "        End Sub"

        s = s & vbCrLf & MakeComment("Записать данные раздела в XML файл")
        s = s & vbCrLf & "        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)"
        s = s & vbCrLf & "           try "
        's = s & vbCrLf & "           XLMPack = Nothing"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If ft.Name.ToLower() = "multiref" Then
                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, " & f.Name & ")  "
                        End If
                    Else
                        s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, m_" & f.Name & ".tostring)  "
                    End If


                Else
                    If UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "DATE" Then
                        s = s & vbCrLf & "          if " & f.Name & " = System.DateTime.MinValue then " & f.Name & "=System.DateTime.Parse(""12/30/1899"")"
                        s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, " & f.Name & ".Ticks)  "
                    ElseIf UCase(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, ft.ID, tid, True)) = "GUID" Then
                        s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, " & f.Name & ".ToString())  "
                    ElseIf UCase(ft.Name) = "IMAGE" Or
                        UCase(ft.Name) = "FILE" _
                        Then
                        s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, System.Convert.ToBase64String(" & f.Name & "))  "
                    Else
                        If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                            s = s & vbCrLf & "          node.SetAttribute(""" & f.Name & """, " & f.Name & ")  "
                        End If
                    End If
                End If
            End If

        Next
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "            " & p.Name & ".XMLSave(node,xdom)"
        End If
        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & "            " & p1.Name & ".XMLSave(node,xdom)"
        Next
        s = s & vbCrLf & "           catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End sub"


        s = s & vbCrLf & MakeComment("Записать изменения в базу данных")
        s = s & vbCrLf & "Public Overrides Sub BatchUpdate()"

        s = s & vbCrLf & "  If Deleted Then"
        s = s & vbCrLf & "    Delete"
        s = s & vbCrLf & "    Exit Sub"
        s = s & vbCrLf & "  End If"
        s = s & vbCrLf & "  If Changed Then Save"
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "            " & p.Name & ".BatchUpdate"
        End If
        For i = 1 To p.PART.Count
            p1 = p.PART.Item(i)
            s = s & vbCrLf & "            " & p1.Name & ".BatchUpdate"
        Next
        s = s & vbCrLf & "End Sub"


        Dim lPartRealCount As Long
        lPartRealCount = 0
        For i = 1 To p.PART.Count
            If p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                lPartRealCount = lPartRealCount + 1
            End If
        Next

        s = s & vbCrLf & MakeComment("Количество дочерних разделов")
        s = s & vbCrLf & "        Public Overrides ReadOnly Property CountOfParts() As Long"
        s = s & vbCrLf & "            Get"
        s = s & vbCrLf & "                CountOfParts = " + CStr(lPartRealCount)
        s = s & vbCrLf & "            End Get"
        s = s & vbCrLf & "        End Property"
        s = s & vbCrLf & ""

        s = s & vbCrLf & MakeComment("Доступ к дочернему разделу по номеру")
        s = s & vbCrLf & "        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base"
        s = s & vbCrLf & "            Select Case Index"
        Dim lTemp As Long
        lTemp = 1
        p.PART.Sort = "sequence"
        For i = 1 To p.PART.Count
            If p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie_s_dannimi Or _
                p.PART.Item(i).PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                s = s & vbCrLf & "         Case " + CStr(lTemp)
                s = s & vbCrLf & "            return " + p.PART.Item(i).Name
                lTemp = lTemp + 1
            End If
        Next
        s = s & vbCrLf & "            End Select"
        s = s & vbCrLf & "            return nothing"
        s = s & vbCrLf & "        End Function"


        s = s & vbCrLf & "    End Class"
        s = s & vbCrLf & "End Namespace"

        LATIR2Framework.StringHelper.SetExt(o, p.Name, "vb")
        o.Block = "code"
        o.OutNL(s)

        For i = 1 To p.PART.Count
            MakeRow(tid, m, ot, p.PART.Item(i), o)
        Next
    End Sub
End Module