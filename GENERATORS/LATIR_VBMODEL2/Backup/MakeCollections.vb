Option Strict Off
Option Explicit On
Imports LATIRFramework.StringHelper
Module MakeCollections
	
    Public Sub MakeColls(ByRef tid As String, ByRef m As MTZMetaModel.MTZMetaModel.Application, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef o As LATIRGenerator.Response)
        Dim s As String = String.Empty
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        s = s & vbCrLf & "Option Explicit On"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Imports LATIR"
        s = s & vbCrLf & "Imports System"
        s = s & vbCrLf & "Imports System.xml"
        s = s & vbCrLf & "Imports System.Data"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "Namespace " & ot.Name
        s = s & vbCrLf & MakeComment("Реализация раздела " & p.Caption & "в виде коллекции")
        s = s & vbCrLf & "    Public Class " & p.name & "_col"
        s = s & vbCrLf & "        Inherits LATIR.Document.DocCollection_Base"
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
        s = s & vbCrLf & "            dt.Columns.Add(""ID"", " & LATIRFramework.FieldTypesHelper.MapSysType("GUID") & ")"
        s = s & vbCrLf & "            dt.Columns.Add(""Brief"", " & LATIRFramework.FieldTypesHelper.MapSysType("STRING") & ")"

        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            ft = f.FIELDTYPE
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & "_ID"" , " & LATIRFramework.FieldTypesHelper.MapSysType("GUID") & ")"
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIRFramework.FieldTypesHelper.MapSysType("STRING") & ")"
            ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & "_VAL"" , " & LATIRFramework.FieldTypesHelper.MapSysType("INTEGER") & ")"
                s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIRFramework.FieldTypesHelper.MapSysType("STRING") & ")"
            Else
                If LATIRFramework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True) <> String.Empty Then
                    s = s & vbCrLf & "            dt.Columns.Add(""" & f.Name & """, " & LATIRFramework.FieldTypesHelper.MapSysType(LATIRFramework.FieldTypesHelper.MapFieldTypeToPhysicalType(m, f.FieldType.ID, tid, True)) & ")"
                End If
            End If
        Next

        s = s & vbCrLf & "            return dt"
        s = s & vbCrLf & "        End Function"
        s = s & vbCrLf & ""
        s = s & vbCrLf & MakeComment("Создание нового элемента коллекции")
        s = s & vbCrLf & "        Protected Overrides Function NewItem() As LATIR.Document.DocRow_Base"
        s = s & vbCrLf & "            NewItem = New " & p.name & ""
        s = s & vbCrLf & "        End Function"

        s = s & vbCrLf & MakeComment("Получить элемент коллекции")
        s = s & vbCrLf & "        Public Function GetItem( vIndex as object ) As " & ot.name & "." & p.name
        s = s & vbCrLf & "            on error resume next"
        s = s & vbCrLf & "            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(" & ot.name & "." & p.name & "))"
        s = s & vbCrLf & "        End Function"

        s = s & vbCrLf & MakeComment("Получить элемент коллекции, более свежий вариант")
        s = s & vbCrLf & "        Public Shadows Function Item( vIndex as object ) As " & ot.name & "." & p.name
        s = s & vbCrLf & "            on error resume next"
        s = s & vbCrLf & "            return GetItem(vIndex)"
        s = s & vbCrLf & "        End Function"

        

        s = s & vbCrLf & ""

        s = s & vbCrLf & "    End Class"



        s = s & vbCrLf & "End Namespace"


        LATIRFramework.StringHelper.SetExt(o, p.Name & "_col", "vb")
        o.Block = "code"
        o.OutNL(s)

        For i = 1 To p.PART.Count
            If p.PART.Item(i).PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
                MakeColls(tid, m, ot, p.PART.Item(i), o)
            End If
        Next

    End Sub
End Module