Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("MakeView_NET.MakeView")> Public Class MakeView
	
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim parent As Generator


    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LatirGenerator.Response, ByVal atid As String)

        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub

    Public Sub Run()
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim j, i As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART

        Dim SQL As Writer
        SQL = New Writer
        SQL.putBuf("create or replace view v_INSTANCE as")
        SQL.putBuf("select instance.*,objstatus.name statusname,objstatus.IsArchive")
        SQL.putBuf("from instance left join objstatus on instance.status=objstatus.objstatusid")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        o.ModuleName = "--Views"
        o.Block = "--body"
        o.out(SQL.getBuf)

        For i = 1 To m.OBJECTTYPE.Count
            ot = m.OBJECTTYPE.Item(i)
            For j = 1 To ot.PART.Count
                os = ot.PART.Item(j)
                MakeAllViews(os)
            Next
            o.Status("View for " & ot.Name, i)
        Next
    End Sub


    Friend Sub MakeAllViews(ByRef ppart As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.MakeAllViews:start " & ppart.Caption)
        Dim i As Integer
        For i = 1 To ppart.PARTVIEW.Count
            MakeViews(ppart.PARTVIEW.Item(i))
        Next
        System.Diagnostics.Debug.Print("POSTGRESGEN.MakeAllViews:children " & ppart.Caption)
        For i = 1 To ppart.PART.Count
            MakeAllViews(ppart.PART.Item(i))
        Next

    End Sub


    Friend Sub MakeViews(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW)
        System.Diagnostics.Debug.Print("POSTGRESGEN.MakeViews:start " & pv_Renamed.Name)
        Dim s As Writer
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim BP As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim refp As MTZMetaModel.MTZMetaModel.PART
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim root As MTZMetaModel.MTZMetaModel.PART
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim i, j As Integer
        Dim from, group As String
        Dim noagg As Integer
        Dim structfld As String
        On Error GoTo bye

        BP = pv_Renamed.Parent.Parent

        s = New Writer

        ' найти раздел первого уровн€ и построить цепочку пр€мых join
        root = BP
        from = " from " & BP.Name
        structfld = BP.Name & "ID"
        While TypeName(root.Parent.Parent) <> "OBJECTTYPE"
            from = from & vbCrLf & " join " & CType(root.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & " on " & CType(root.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "." & CType(root.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "ID=" & root.Name & ".ParentStructRowID "
            structfld = structfld & "," & CType(root.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Name & "ID"
            root = root.Parent.Parent
        End While

        from = from & vbCrLf & " join INSTANCE on " & root.Name & ".INSTANCEID=INSTANCE.INSTANCEID"
        from = from & vbCrLf & " left join objstatus XXXMYSTATUSXXX on instance.status=XXXMYSTATUSXXX.objstatusid"

        group = " group by " & root.Name & ".InstanceID, " & BP.Name & "." & BP.Name & "ID "

        ' стандартное начало
        s.putBuf("create or replace view V_" & pv_Renamed.the_Alias & " as ")
        s.putBuf("select   " & structfld)
        Dim fcnt As Integer
        fcnt = 0

        Dim isOK As Boolean
        For i = 1 To pv_Renamed.ViewColumn.Count
            vc = pv_Renamed.ViewColumn.Item(i)
            p = vc.FromPart
            f = vc.Field
            If Not (p Is Nothing) And Not (f Is Nothing) Then
                fcnt = fcnt + 1
                '      If fcnt > 1 Then
                s.putBuf(", ")
                '      End If
                If vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none Then
                    ft = f.FieldType
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        ' вписываем значение перечслени€
                        s.putBuf(" " & p.Name & "." & f.Name & "  ")
                        s.putBuf(vc.the_Alias & "_VAL, ")

                        ' и его расшифровку
                        s.putBuf(" ( case " & p.Name & "." & VF(f.Name) & " ")
                        For j = 1 To ft.ENUMITEM.Count
                            s.putBuf(" when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'")
                        Next
                        s.putBuf(" else '???' end) ")
                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        ' вписываем значение ссылки
                        s.putBuf(" " & p.Name & "." & f.Name & "  ")
                        s.putBuf(vc.the_Alias & "_ID, ")

                        ' и расшифрованное значение
                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                            s.putBuf("  INSTANCE_BRIEF_F(" & p.Name & "." & VF(f.Name) & ") ")
                        ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                            refp = f.RefToPart
                            s.putBuf("  " & refp.Name & "_BRIEF_F(" & p.Name & "." & VF(f.Name) & ") ")
                        Else
                            s.putBuf(p.Name & "." & VF(f.Name) & " ")
                        End If
                    Else

                        s.putBuf(p.Name & "." & VF(f.Name) & " ")
                    End If


                    noagg = noagg + 1
                    group = group & vbCrLf & "," & p.Name & "." & VF(f.Name) & " "
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MAX Then
                    s.putBuf("MAX(" & p.Name & "." & VF(f.Name) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MIN Then
                    s.putBuf("MIN(" & p.Name & "." & VF(f.Name) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_AVG Then
                    s.putBuf("AVG(" & p.Name & "." & VF(f.Name) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_SUM Then
                    s.putBuf("SUM(" & p.Name & "." & VF(f.Name) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_COUNT Then
                    s.putBuf("COUNT(" & p.Name & "." & VF(f.Name) & ") ")
                End If
                s.putBuf(vc.the_Alias & " ")
                If BP.ID = p.Parent.Parent.ID Then
                    isOK = False

                    ' провер€ем пол€, которые вход€т в раздел
                    For j = 1 To i - 1

                        If pv_Renamed.ViewColumn.Item(j).FromPart.ID = p.ID Then
                            isOK = True
                            Exit For
                        End If
                    Next

                    ' если в разделе есть пол€, то включаем его в запрос
                    If Not isOK Then
                        from = from & " left join " & p.Name & " on " & BP.Name & "." & BP.Name & "ID = " & p.Name & ".ParentStructRowID"
                    End If
                End If


                ' провер€ем верхние разделы, которые не  €вл€ютс€ непосредственными родител€ми нашего базового раздела
                If TypeName(p.Parent.Parent) = "OBJECTTYPE" And (p.ID <> root.ID) Then
                    isOK = False
                    For j = 1 To i - 1
                        If pv_Renamed.ViewColumn.Item(j).FromPart.ID = p.ID Then
                            isOK = True
                            Exit For
                        End If
                    Next
                    ' есть пол€ из верхнего раздела
                    If Not isOK Then
                        from = from & " left join " & p.Name & " ON " & p.Name & ".InstanceID=" & root.Name & ".InstanceID"
                    End If
                End If
            Else

            End If
        Next
        If fcnt > 0 Then
            s.putBuf(", " & root.Name & ".InstanceID InstanceID ")
        Else
            s.putBuf(" " & root.Name & ".InstanceID InstanceID ")
        End If

        s.putBuf(", " & BP.Name & "." & BP.Name & "ID ID ")
        s.putBuf(", '" & BP.Name & "' VIEWBASE ")
        s.putBuf(", XXXMYSTATUSXXX.Name StatusName ")
        s.putBuf(", XXXMYSTATUSXXX.objstatusid INTSANCEStatusID")

        ' if no aggregations - no group by
        If noagg = pv_Renamed.ViewColumn.Count Then group = ""

        o.ModuleName = "--Views"
        o.Block = "--body"


        o.Out(s.getBuf & " " & from & " " & group & vbCrLf & ";")
        o.OutNL("GO")
        s = Nothing
        System.Diagnostics.Debug.Print("POSTGRESGEN.MakeViews:done " & pv_Renamed.Name)
        Exit Sub
bye:

        s = Nothing

    End Sub
End Class