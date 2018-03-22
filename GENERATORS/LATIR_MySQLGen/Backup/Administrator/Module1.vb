Module Module1
    Public Manager As LATIR.Manager
    Public guiManager As LATIRGuiManager.LATIRGuiManager
    Public model As MTZMetaModel.MTZMetaModel.Application
    Public viCol As Collection
    Public NewViewName As String
    Public NewViewAlias As String
    Public NewForChoose As Boolean
    Public NewForChooseObject As Boolean
    Public DelOtherView As Boolean
    Public CreatedView As MTZMetaModel.MTZMetaModel.PARTVIEW
    Public BasePartID As Guid
    Public BasePart As MTZMetaModel.MTZMetaModel.PART
    Public ViewForChange As MTZMetaModel.MTZMetaModel.PARTVIEW
    Public BaseType As MTZMetaModel.MTZMetaModel.OBJECTTYPE


    Public Function CountOfID(ByVal ID As String, ByVal n As System.Windows.Forms.TreeNode) As Integer
        Dim nn As System.Windows.Forms.TreeNode
        Dim cnt As Integer
        cnt = 0
        nn = n
        While Not n Is Nothing
            If Left(n.Name, 38) = ID Then
                cnt = cnt + 1
            End If
            n = n.Parent
        End While
        CountOfID = cnt
    End Function


    Public Sub ExractLevel(ByVal Key As String, ByRef ID As String, ByRef Level As String)
        ID = Left(Key, 38)
        Level = Right(Key, 38)
    End Sub

    Public Sub SaveView()
        model.LockResource(False)
        Dim i As Integer
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim vi As ViewItems
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim bReplacedView As Boolean
        Dim iid As Guid
        Dim sNM As String
        Dim sAliace As String
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        If model.IsLocked <> LATIR.Session.LockStyle.NoLock Then

            bReplacedView = False
            'UPGRADE_WARNING: Screen property Screen.MousePointer has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            BasePart.PARTVIEW.Refresh()



            If ViewForChange Is Nothing Then
                If DelOtherView Then
                    For i = BasePart.PARTVIEW.Count To 1 Step -1
                        BasePart.PARTVIEW.Item(i).Delete()
                    Next
                End If
                BasePart.PARTVIEW.Refresh()
                pv_Renamed = BasePart.PARTVIEW.Add()
                pv_Renamed.Name = NewViewName & "(" & BasePart.Caption & ")"
                pv_Renamed.the_Alias = NewViewAlias
            Else
                bReplacedView = True
                iid = ViewForChange.ID
                sNM = ViewForChange.Name
                sAliace = ViewForChange.the_Alias
                ViewForChange.Delete()
                BasePart.PARTVIEW.Refresh()

                If DelOtherView Then
                    For i = BasePart.PARTVIEW.Count To 1 Step -1
                        BasePart.PARTVIEW.Item(i).Delete()
                    Next
                End If
                BasePart.PARTVIEW.Refresh()
                pv_Renamed = BasePart.PARTVIEW.Add(iid.ToString)
                pv_Renamed.Name = sNM
                pv_Renamed.the_Alias = sAliace
            End If


            If NewForChoose Then
                pv_Renamed.ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
            Else
                pv_Renamed.ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
            End If

            pv_Renamed.Save()

            'Теперь надо ли делать для выбора объекта?
            If NewForChooseObject Then
                BaseType.ChooseView = pv_Renamed
                BaseType.Save()
            End If

            CreatedView = pv_Renamed

            For i = 1 To viCol.Count()

                On Error Resume Next
                vi = viCol.Item(i)

                fld = model.FindObject("FIELD", vi.FieldID)
                If Not fld Is Nothing Then
                    ft = fld.FIELDTYPE
                    If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then

                        vc = pv_Renamed.ViewColumn.Add()

                        If vi.Aggregation = "" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none
                        ElseIf vi.Aggregation = "COUNT" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_COUNT
                        ElseIf vi.Aggregation = "SUM" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_SUM
                        ElseIf vi.Aggregation = "AVG" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_AVG
                        ElseIf vi.Aggregation = "MIN" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MIN
                        ElseIf vi.Aggregation = "MAX" Then
                            vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MAX
                        End If
                        'UPGRADE_WARNING: Couldn't resolve default property of object fld.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        vc.Name = fld.Caption & " (" & fld.Parent.Parent.Caption & ")"
                        'UPGRADE_WARNING: Couldn't resolve default property of object fld.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        vc.the_Alias = fld.Parent.Parent.Name & "_" & fld.Name
                        'UPGRADE_WARNING: Couldn't resolve default property of object fld.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        vc.FromPart = fld.Parent.Parent
                        vc.Field = fld
                        vc.sequence = i
                        vc.Save()
                    End If

                End If
            Next

            model.UnLockResource()
        End If

    End Sub

End Module
