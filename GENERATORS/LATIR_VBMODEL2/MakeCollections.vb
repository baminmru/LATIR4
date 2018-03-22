Option Strict Off
Option Explicit On
Imports LATIR2Framework.StringHelper
Module MakeCollections

    Public Sub MakeColls(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response)
        Dim s As String = String.Empty
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        s = s & vbCrLf & "Option Explicit On"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Imports LATIR2"
        s = s & vbCrLf & "Imports System"
        s = s & vbCrLf & "Imports System.xml"
        s = s & vbCrLf & "Imports System.Data"
        s = s & vbCrLf & "Imports System.Diagnostics"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Namespace " & ot.Name
        s = s & vbCrLf & MakeComment("Реализация раздела " & p.Caption & "в виде коллекции")
        s = s & vbCrLf & "    Public Class " & p.name & "_col"
        s = s & vbCrLf & "        Inherits LATIR2.Document.DocCollection_Base"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Имя раздела в базе данных")
        s = s & vbCrLf & "        Public Overrides Function ChildPartName() As String"
        s = s & vbCrLf & "            ChildPartName = """ & p.name & """"
        s = s & vbCrLf & "        End Function"
        s = s & vbCrLf & ""

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & MakeComment("Признак древовидного раздела")
            s = s & vbCrLf & "        Public Overrides Function IsTree() As Boolean"
            s = s & vbCrLf & "            IsTree=true"
            s = s & vbCrLf & "        End Function"
        End If

        s = s & vbCrLf & MakeComment("Вернуть даные текущей коллекции в виде DataTable")
        s = s & vbCrLf & "        Protected Overrides Function CreateDataTable() As System.Data.DataTable"
        s = s & vbCrLf & "            Dim dt As DataTable"
        s = s & vbCrLf & "            dt = New DataTable"
        s = s & vbCrLf & "            dt.TableName=""" & p.Name & """"
        s = s & vbCrLf & "            dt.Columns.Add(""ID"", " & LATIR2Framework.FieldTypesHelper.MapSysType("GUID") & ")"
        s = s & vbCrLf & "            dt.Columns.Add(""Brief"", " & LATIR2Framework.FieldTypesHelper.MapSysType("STRING") & ")"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & "_ID"" , " & LATIR2Framework.FieldTypesHelper.MapSysType("GUID") & ")"
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIR2Framework.FieldTypesHelper.MapSysType("STRING") & ")"
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & "_VAL"" , " & LATIR2Framework.FieldTypesHelper.MapSysType("INTEGER") & ")"
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIR2Framework.FieldTypesHelper.MapSysType("STRING") & ")"
            Else
                If LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIR2Framework.FieldTypesHelper.MapSysType(LATIR2Framework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True)) & ")"
                End If
            End If
        Next

        s = s & vbCrLf & "            return dt"
        s = s & vbCrLf & "        End Function"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Создание нового элемента коллекции")
        s = s & vbCrLf & "        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base"
        s = s & vbCrLf & "            NewItem = New " & p.name & ""
        s = s & vbCrLf & "        End Function"

        s = s & vbCrLf & MakeComment("Получить элемент коллекции")
        s = s & vbCrLf & "        Public Function GetItem( vIndex as object ) As " & ot.name & "." & p.Name
        s = s & vbCrLf & "            try"
        s = s & vbCrLf & "            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(" & ot.Name & "." & p.Name & "))"
        s = s & vbCrLf & "catch ex as System.Exception"
        s = s & vbCrLf & " Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "end try"
        s = s & vbCrLf & "        End Function"

        s = s & vbCrLf & MakeComment("Получить элемент коллекции, более свежий вариант")
        s = s & vbCrLf & "        Public Shadows Function Item( vIndex as object ) As " & ot.Name & "." & p.Name
        s = s & vbCrLf & "          try"
        s = s & vbCrLf & "            return GetItem(vIndex)"
        s = s & vbCrLf & "          catch ex as System.Exception"
        s = s & vbCrLf & "              Debug.Print( ex.Message + "" >> "" + ex.StackTrace)"
        s = s & vbCrLf & "          end try"
        s = s & vbCrLf & "        End Function"


        s = s & vbCrLf & "Public Overrides Function FieldList() As String"
        s = s & vbCrLf & "    If mFieldList = ""*"" Then"
        s = s & vbCrLf & "       with application.Session.GetProvider"
        s = s & vbCrLf & "       mFieldList=.ID2Base(""" & p.Name & "ID"")"
        s = s & vbCrLf & "           mFieldList =mFieldList+"",""+.ID2Base(""SecurityStyleID"") "
        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s = s & vbCrLf & "           mFieldList =mFieldList+"",""+.ID2Base(""PARENTROWID"") "
        End If
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FieldType
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                If ft.Name <> "MULTIREF" Then
                    s = s & vbCrLf & "           mFieldList =mFieldList+"",""+.ID2Base(""" & f.Name & """) "
                Else
                    s = s & vbCrLf & "           mFieldList =mFieldList+ "", " + f.Name.ToLower + """ "
                End If



            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                s = s & vbCrLf & "           mFieldList =mFieldList+ "", " + f.Name.ToLower + """ "
            ElseIf ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                s = s & vbCrLf & "           mFieldList =mFieldList+"",""+.Date2Base(""" & f.Name & """) "
            ElseIf ft.Name.ToLower = "id" Then
                s = s & vbCrLf & "           mFieldList =mFieldList+"",""+.ID2Base(""" & f.Name & """) "
            Else
                s = s & vbCrLf & "           mFieldList =mFieldList+ "", " + f.Name.ToLower + """ "

            End If
        Next
        s = s & vbCrLf & "       end with"


        s = s & vbCrLf & "    End If"

        s = s & vbCrLf & "    Return mFieldList"
        s = s & vbCrLf & "End Function"
        s = s & vbCrLf & ""

        s = s & vbCrLf & "    End Class"



        s = s & vbCrLf & "End Namespace"


        LATIR2Framework.StringHelper.SetExt(o, p.Name & "_col", "vb")
        o.Block = "code"
        o.OutNL(s)

        For i = 1 To p.PART.Count
            If p.PART.Item(i).PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                MakeColls(tid, m, ot, p.PART.Item(i), o)
            End If
        Next

    End Sub
End Module