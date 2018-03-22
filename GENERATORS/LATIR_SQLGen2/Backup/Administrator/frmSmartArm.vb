Option Strict Off
Option Explicit On
Friend Class frmSmartArm
	Inherits System.Windows.Forms.Form
	Dim col As Collection
	Dim ARMName As String
	
	Private Sub cmdClearAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClearAll.Click
		Dim i As Integer
		For i = 0 To lstTypes.Items.Count - 1
			lstTypes.SetItemChecked(i, False)
		Next 
	End Sub
	
	Private Sub cmdSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelAll.Click
		Dim i As Integer
		For i = 0 To lstTypes.Items.Count - 1
			lstTypes.SetItemChecked(i, True)
		Next 
	End Sub
	
	Private Sub cmdStart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStart.Click
		Dim i, j As Integer
		Dim cnt As Integer
		cnt = 0
		If chkCreateARM.CheckState = System.Windows.Forms.CheckState.Checked Then
			ARMName = InputBox("Название АРМ", "Подготовка АРМ", "АРМ " & Now)
		End If
		cnt = lstTypes.CheckedIndices.Count * 3 + 1
		
		pb.Minimum = 0
		pb.Maximum = cnt
		pb.Value = 0
		pb.Visible = True
		Label1.Visible = True
		For i = 0 To lstTypes.Items.Count - 1
			If lstTypes.GetItemChecked(i) Then
				'UPGRADE_WARNING: Couldn't resolve default property of object col.item(). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                MakeType(col.Item(i + 1))
				System.Windows.Forms.Application.DoEvents()
			End If
		Next 
		If chkCreateARM.CheckState = System.Windows.Forms.CheckState.Checked Then
			MakeArm()
		End If
		pb.Visible = False
		Label1.Visible = False
		MsgBox("Подготовка АРМа завершена")
	End Sub
	
	Private Sub frmSmartArm_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		lstTypes.Items.Clear()
		col = New Collection
		model.objectType.Sort = "Comment"
        Dim i As Integer
        Dim pn As String
		For i = 1 To model.objectType.Count
            With model.OBJECTTYPE.Item(i)

                'UPGRADE_WARNING: Couldn't resolve default property of object model.objectType.item().package.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                lstTypes.Items.Add(CType(.Package, MTZMetaModel.MTZMetaModel.MTZAPP).Name & "->" & .the_Comment)
                Call col.Add(model.OBJECTTYPE.Item(i), .ID.ToString())
                'UPGRADE_ISSUE: ListBox property lstTypes.NewIndex was not upgraded. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="F649E068-7137-45E5-AC20-4D80A3CC70AC"'
                VB6.SetItemData(lstTypes, i - 1, col.Count())
            End With
		Next 
	End Sub
	
    Private Sub MakeType(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)

        '
        pb.Value = pb.Value + 1
        Label1.Text = "Views for type " & ot.Name

        ProcessView(ot.PART)

        pb.Value = pb.Value + 1
        Label1.Text = "Journal for type " & ot.Name

        ProcessFilter(ot)


        pb.Value = pb.Value + 1
        Label1.Text = "Filter for type " & ot.Name

        ProcessJournal(ot)

    End Sub


    Private Sub ProcessFilter(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        p = JournalPart(ot)
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim fltr As MTZFltr.MTZFltr.Application
        Dim ID As Guid
        Dim fg As MTZFltr.MTZFltr.FilterFieldGroup

        For i = 1 To p.PARTVIEW.Count
            pv_Renamed = p.PARTVIEW.item(i)
            If UCase(pv_Renamed.the_Alias) = "AUTO" & UCase(p.Name) Then
                Exit For
            End If
        Next

        If pv_Renamed Is Nothing Then
            MsgBox("Ошибка получения ПартВью для объекта " & ot.Name)
            Exit Sub
        End If

        fltr = FindFilter(ot)
        If Not fltr Is Nothing Then
            Manager.DeleteInstance(fltr)
        Else
            ID = Guid.NewGuid()

        End If
        Manager.NewInstance(ID, "MTZFltr", ot.Name)
        fltr = Manager.GetInstanceObject(ID)

        With CType(fltr.Filters.Add, MTZFltr.MTZFltr.Filters)
            .Name = ot.Name
            .TheCaption = "Фильтр для " & ot.the_Comment
            .TheComment = ot.TheComment
            .Save()
        End With

        fg = fltr.FilterFieldGroup.Add
        With fg
            .Name = "fGroup"
            .Caption = p.Caption
            .Save()
        End With

        Dim seq As Integer
        seq = 0

        pv_Renamed.ViewColumn.Sort = "sequence"

        For i = 1 To pv_Renamed.ViewColumn.Count

            f = pv_Renamed.ViewColumn.item(i).Field
            ft = f.FIELDTYPE
            If ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then

                    With CType(fg.FileterField.Add, MTZFltr.MTZFltr.FileterField)
                        .sequence = seq
                        .Name = f.Name & "_GE"
                        .Caption = f.Caption & " C"
                        .FieldType = ft
                        .RefType = f.ReferenceType
                        .RefToPart = f.RefToPart
                        .RefToType = f.RefToType
                        .ValueArray = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                        .FieldSize = f.DataSize
                        seq = seq + 1
                        .Save()
                    End With

                    With CType(fg.FileterField.Add, MTZFltr.MTZFltr.FileterField)
                        .sequence = seq
                        .Name = f.Name & "_LE"
                        .Caption = f.Caption & " по"
                        .FieldType = ft
                        .RefType = f.ReferenceType
                        .RefToPart = f.RefToPart
                        .RefToType = f.RefToType
                        .ValueArray = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                        .FieldSize = f.DataSize
                        seq = seq + 1
                        .Save()
                    End With

                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    With CType(fg.FileterField.Add, MTZFltr.MTZFltr.FileterField)
                        .sequence = seq
                        .Name = f.Name & "_GE"
                        .Caption = f.Caption & " больше или равно"
                        .FieldType = ft
                        .RefType = f.ReferenceType
                        .RefToPart = f.RefToPart
                        .RefToType = f.RefToType
                        .ValueArray = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                        .FieldSize = f.DataSize
                        seq = seq + 1
                        .Save()
                    End With
                    With CType(fg.FileterField.Add, MTZFltr.MTZFltr.FileterField)
                        .sequence = seq
                        .Name = f.Name & "_LE"
                        .Caption = f.Caption & " меньше или равно"
                        .FieldType = ft
                        .RefType = f.ReferenceType
                        .RefToPart = f.RefToPart
                        .RefToType = f.RefToType
                        .ValueArray = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                        .FieldSize = f.DataSize
                        seq = seq + 1
                        .Save()
                    End With

                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    '      If ft.TypeStyle = TypeStyle_Ssilka Then
                    '
                    '      Else
                    '
                    '      End If

                    With CType(fg.FileterField.Add, MTZFltr.MTZFltr.FileterField)
                        .sequence = seq
                        .Name = f.Name
                        .Caption = f.Caption
                        .FieldType = ft
                        .RefType = f.ReferenceType
                        .RefToPart = f.RefToPart
                        .RefToType = f.RefToType
                        .ValueArray = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                        .FieldSize = f.DataSize
                        seq = seq + 1
                        .Save()
                    End With
                End If



                '    With fg.FileterField.Add
                '      .sequence = seq
                '      .Name = f.Name
                '      .Caption = f.Caption
                '      Set .FIELDTYPE = ft
                '      Set .RefType = f.ReferenceType
                '      Set .RefToPart = f.RefToPart
                '      Set .RefToType = f.RefToType
                '      .ValueArray = Boolean_Net
                '      .Rows(i)ize = f.DataSize
                '      seq = seq + 1
                '      .Save
                '    End With
            End If

        Next




    End Sub


    Private Sub ProcessJournal(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        p = JournalPart(ot)
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim jr As MTZJrnl.MTZJrnl.Application
        Dim ID As Guid
        Dim jsrc As MTZJrnl.MTZJrnl.JournalSrc
        Dim jc As MTZJrnl.MTZJrnl.JournalColumn
        Dim jcs As MTZJrnl.MTZJrnl.JColumnSource
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE


        For i = 1 To p.PARTVIEW.Count
            pv_Renamed = p.PARTVIEW.item(i)
            If UCase(pv_Renamed.the_Alias) = "AUTO" & UCase(p.Name) Then
                Exit For
            End If
        Next

        jr = FindJournal(ot)
        If Not jr Is Nothing Then
            Manager.DeleteInstance(jr)
        Else
            ID = Guid.NewGuid
        End If

        'pv.ViewColumn.item(1).the_Alias
        Manager.NewInstance(ID, "MTZJrnl", ot.Name)
        jr = Manager.GetInstanceObject(ID)
        On Error Resume Next
        With CType(jr.Journal.Add, MTZJrnl.MTZJrnl.Journal)

            .Name = ot.the_Comment
            .the_Alias = ot.the_Comment
            .TheComment = "Журнал для документов типа: " & ot.TheComment
            .Save()
        End With

        jsrc = jr.JournalSrc.Add()
        With jsrc
            .ViewAlias = pv_Renamed.the_Alias
            .PARTVIEW = pv_Renamed.ID
            .OnRun = MTZMetaModel.MTZMetaModel.enumOnJournalRowClick.OnJournalRowClick_Otkrit__dokument
            .OpenMode = ""
            .Save()
        End With

        pv_Renamed.ViewColumn.Sort = "sequence"

        For i = 1 To pv_Renamed.ViewColumn.Count
            jc = jr.JournalColumn.Add
            With jc
                .sequence = i
                f = pv_Renamed.ViewColumn.item(i).Field
                .Name = f.Caption
                ft = f.FIELDTYPE
                .ColSort = ft.GridSortType
                .ColumnAlignment = MTZMetaModel.MTZMetaModel.enumVHAlignment.VHAlignment_Left_Top
                .GroupAggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none
                .Save()
            End With
            jcs = jc.JColumnSource.Add
            With jcs
                .ViewField = pv_Renamed.ViewColumn.Item(i).the_Alias
                .SrcPartView = jsrc
                .Save()
            End With
        Next

        Dim j As Integer
        Dim LastI As Integer
        LastI = i



        For j = 1 To pv_Renamed.PARTVIEW_LNK.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.PARTVIEW_LNK.item().TheView.ViewColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            CType(pv_Renamed.PARTVIEW_LNK.Item(j).TheView, MTZMetaModel.MTZMetaModel.PARTVIEW).ViewColumn.Sort = "sequence"
            'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.PARTVIEW_LNK.item(j).TheView.ViewColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For i = 1 To CType(pv_Renamed.PARTVIEW_LNK.Item(j).TheView, MTZMetaModel.MTZMetaModel.PARTVIEW).ViewColumn.Count
                LastI = LastI + 1
                jc = jr.JournalColumn.Add
                With jc
                    .sequence = LastI
                    'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.PARTVIEW_LNK.item().TheView.ViewColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    f = CType(pv_Renamed.PARTVIEW_LNK.Item(j).TheView, MTZMetaModel.MTZMetaModel.PARTVIEW).ViewColumn.Item(i).Field
                    .name = f.Caption
                    ft = f.FieldType
                    .ColSort = ft.GridSortType
                    .ColumnAlignment = MTZMetaModel.MTZMetaModel.enumVHAlignment.VHAlignment_Left_Top
                    .GroupAggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none
                    .Save()
                End With
                jcs = jc.JColumnSource.Add
                With jcs
                    'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.PARTVIEW_LNK.item().TheView.ViewColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    .ViewField = CType(pv_Renamed.PARTVIEW_LNK.Item(j).TheView, MTZMetaModel.MTZMetaModel.PARTVIEW).ViewColumn.Item(i).the_Alias
                    .SrcPartView = jsrc
                    .Save()
                End With
            Next
        Next

    End Sub


    Private Function JournalPart(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        If ot.PART.Count = 0 Then Exit Function
        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            p = ot.PART.item(i)
            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
                JournalPart = p
                Exit Function
            End If
        Next
        JournalPart = ot.PART.item(1)
    End Function

    Private Sub ProcessView(ByRef parts As MTZMetaModel.MTZMetaModel.PART_COL)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim j, i, k As Integer
        Dim vi As ViewItems

        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim HasDefault As Boolean
        Dim AutoID As Guid
        For i = 1 To parts.Count
            p = parts.item(i)
            AutoID = Guid.Empty
            For j = 1 To p.PARTVIEW.Count
                pv_Renamed = p.PARTVIEW.item(j)
                If pv_Renamed.ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    HasDefault = True
                End If
                If UCase(pv_Renamed.the_Alias) = "AUTO" & UCase(p.Name) Then
                    AutoID = pv_Renamed.ID
                    If pv_Renamed.ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                        HasDefault = False
                    End If
                End If
            Next

            If chkbDoNotDeleteAUTO.CheckState = System.Windows.Forms.CheckState.Unchecked Then
                If AutoID.Equals(Guid.Empty) Then
                    p.PARTVIEW.Delete(AutoID)
                End If

                viCol = New Collection

                p.Field.Sort = "sequence"

                For k = 1 To p.Field.Count
                    vi = New ViewItems
                    vi.FieldID = p.FIELD.Item(k).ID.ToString
                    vi.Aggregation = ""
                    viCol.Add(vi, Guid.NewGuid.ToString)
                Next

                NewViewName = p.Caption & " авто"
                NewViewAlias = "AUTO" & p.Name

                If p.PartType <> MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                    NewForChoose = Not HasDefault
                Else
                    NewForChoose = False
                End If

                BasePart = p
                SaveView() 'AutoID
            Else
                BasePart = p
            End If

            ProcessView(p.PART)
        Next

    End Sub

    Private Sub MakeArm()
        Dim arm As MTZwp.MTZwp.Application
        Dim ID As Guid
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ID = Guid.NewGuid
        Call Manager.NewInstance(ID, "MTZwp", ARMName)
        arm = Manager.GetInstanceObject(ID)

        pb.Value = pb.Value + 1
        Label1.Text = "Combine WorkPlace "
        arm.Name = ARMName
        arm.Save()

        With CType(arm.WorkPlace.Add, MTZwp.MTZwp.WorkPlace)

            .Name = ARMName
            .Caption = ARMName
            .Save()
        End With

        Dim i As Integer
        ' добавили типы
        For i = 0 To lstTypes.Items.Count - 1
            If lstTypes.GetItemChecked(i) Then
                With CType(arm.ARMTypes.Add, MTZwp.MTZwp.ARMTypes)
                    .TheDocumentType = col.Item(VB6.GetItemData(lstTypes, i))
                    .Save()
                End With
            End If
        Next

        ' Формируем Меню

        Dim dicMenu As MTZwp.MTZwp.EntryPoints
        Dim jrnlMenu As MTZwp.MTZwp.EntryPoints

        dicMenu = arm.EntryPoints.Add
        dicMenu.Name = "mnuDictionary"
        dicMenu.TheComment = "Меню для справочников"
        dicMenu.Caption = "Справочники"
        dicMenu.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Nicego_ne_delat_
        dicMenu.Save()

        jrnlMenu = arm.EntryPoints.Add
        jrnlMenu.Name = "mnuJRNL"
        jrnlMenu.Caption = "Журналы"
        jrnlMenu.TheComment = " "
        jrnlMenu.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Nicego_ne_delat_
        jrnlMenu.Save()
        'dicmenu.

        Dim mseq As Integer
        mseq = 1
        Dim TypeMenu As MTZwp.MTZwp.EntryPoints
        Dim ii As Integer
        For i = 0 To lstTypes.Items.Count - 1
            If lstTypes.GetItemChecked(i) Then

                ot = col.Item(VB6.GetItemData(lstTypes, i))
                If ot.IsSingleInstance = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    With CType(dicMenu.EntryPoints.Add, MTZwp.MTZwp.EntryPoints)
                        .sequence = mseq
                        mseq = mseq + 1
                        .Name = "mnu" & ot.Name
                        .Caption = ot.the_Comment
                        .ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__dokument
                        .ObjectType = ot
                        .Save()
                    End With

                Else

                    ' сразу можно сделать журналы по состояниям  ???

                    If ot.OBJSTATUS.Count = 0 Then


                        With CType(jrnlMenu.EntryPoints.Add(), MTZwp.MTZwp.EntryPoints)
                            .sequence = mseq
                            mseq = mseq + 1
                            .Name = "mnu" & ot.Name
                            .Caption = ot.the_Comment
                            .ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal
                            .Journal = FindJournal(ot)
                            .TheFilter = FindFilter(ot)
                            .Save()
                        End With

                        MakeFilterMapping(jrnlMenu.EntryPoints.item(ID), ot)

                    Else

                        TypeMenu = jrnlMenu.EntryPoints.Add()

                        With TypeMenu
                            .sequence = mseq
                            mseq = mseq + 1
                            .Name = "mnu" & ot.Name
                            .Caption = ot.the_Comment
                            .ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Nicego_ne_delat_
                            .Save()
                        End With


                        With CType(TypeMenu.EntryPoints.Add(), MTZwp.MTZwp.EntryPoints)
                            .sequence = mseq
                            mseq = mseq + 1
                            .Name = "mnuAll" & ot.Name
                            .Caption = ot.the_Comment & " - все состояния"
                            .ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal
                            .Journal = FindJournal(ot)
                            .TheFilter = FindFilter(ot)
                            .Save()
                        End With
                        MakeFilterMapping(TypeMenu.EntryPoints.item(ID), ot)

                        For ii = 1 To ot.OBJSTATUS.Count

                            With CType(TypeMenu.EntryPoints.Add, MTZwp.MTZwp.EntryPoints)
                                .sequence = mseq
                                mseq = mseq + 1
                                .Name = "mnu" & ot.Name & "_" & ii
                                .Caption = ot.the_Comment & " :" & ot.OBJSTATUS.Item(ii).name
                                .ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal
                                .Journal = FindJournal(ot)
                                .TheFilter = FindFilter(ot)
                                .JournalFixedQuery = " INTSANCEStatusID='" & ot.OBJSTATUS.Item(ii).ID.ToString() & "'"
                                .Save()
                            End With
                            MakeFilterMapping(TypeMenu.EntryPoints.item(ID), ot)
                        Next
                    End If

                End If

            End If
        Next
    End Sub


    Private Sub MakeFilterMapping(ByRef ep As MTZwp.MTZwp.EntryPoints, ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        p = JournalPart(ot)
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim i As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim ID As String


        For i = 1 To p.PARTVIEW.Count
            pv_Renamed = p.PARTVIEW.Item(i)
            If UCase(pv_Renamed.the_Alias) = "AUTO" & UCase(p.Name) Then
                Exit For
            End If
        Next



        pv_Renamed.ViewColumn.Sort = "sequence"

        For i = 1 To pv_Renamed.ViewColumn.Count

            f = pv_Renamed.ViewColumn.Item(i).Field
            ft = f.FieldType

            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                    .RowSource = pv_Renamed.the_Alias
                    .FilterField = f.Name & "_GE"
                    .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & ">="" & MakeMSSQLDate(fltr.dtp" & f.Name & "_GE.value)"
                    .Save()
                End With
                With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                    .RowSource = pv_Renamed.the_Alias
                    .FilterField = f.Name & "_LE"
                    .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & "<="" & MakeMSSQLDate(fltr.dtp" & f.Name & "_LE.value)"
                    .Save()
                End With
            End If

            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                    .RowSource = pv_Renamed.the_Alias
                    .FilterField = f.Name & "_GE"
                    .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & ">="" & val(fltr.txt" & f.Name & "_GE.Text)"
                    .Save()
                End With
                With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                    .RowSource = pv_Renamed.the_Alias
                    .FilterField = f.Name & "_LE"
                    .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & "<="" & val(fltr.txt" & f.Name & "_LE.Text)"
                    .Save()
                End With
            End If

            If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pv_Renamed.the_Alias
                        .FilterField = f.Name
                        .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & "_ID='"" & fltr.txt" & f.Name & ".Tag & ""'"" "
                        .Save()
                    End With

                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pv_Renamed.the_Alias
                        .FilterField = f.Name
                        .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & "='"" & fltr.cmb" & f.Name & ".Text & ""'"" "
                        .Save()
                    End With
                ElseIf UCase(ft.Name) <> "FILE" And UCase(ft.Name) <> "ID" And UCase(ft.Name) <> "IMAGE" Then
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pv_Renamed.the_Alias
                        .FilterField = f.Name
                        .TheExpression = pv_Renamed.ViewColumn.Item(i).the_Alias & " like '%"" & fltr.txt" & f.Name & ".Text & ""%'"" "
                        .Save()
                    End With
                End If
            End If
        Next
        'доп вьюхи
        Dim j As Integer
        Dim LastI As Integer
        LastI = i

        Dim pvd As MTZMetaModel.MTZMetaModel.PARTVIEW
        For j = 1 To pv_Renamed.PARTVIEW_LNK.Count

            pvd = pv_Renamed.PARTVIEW_LNK.Item(j).TheView
            pvd.ViewColumn.Sort = "sequence"
            'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.PARTVIEW_LNK.item(j).TheView.ViewColumn. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For i = 1 To pvd.ViewColumn.Count

                LastI = LastI + 1
                f = pvd.ViewColumn.Item(i).Field
                ft = f.FieldType

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Date Then
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pvd.the_Alias
                        .FilterField = f.Name & "_GE"
                        .TheExpression = pvd.ViewColumn.Item(i).the_Alias & ">="" & MakeMSSQLDate(fltr.dtp" & f.Name & "_GE.value)"
                        .Save()
                    End With
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pvd.the_Alias
                        .FilterField = f.Name & "_LE"
                        .TheExpression = pvd.ViewColumn.Item(i).the_Alias & "<="" & MakeMSSQLDate(fltr.dtp" & f.Name & "_LE.value)"
                        .Save()
                    End With
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_Numeric Then
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pvd.the_Alias
                        .FilterField = f.Name & "_GE"
                        .TheExpression = pvd.ViewColumn.Item(i).the_Alias & ">="" & val(fltr.txt" & f.Name & "_GE.Text)"
                        .Save()
                    End With
                    With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                        .RowSource = pvd.the_Alias
                        .FilterField = f.Name & "_LE"
                        .TheExpression = pvd.ViewColumn.Item(i).the_Alias & "<="" & val(fltr.txt" & f.Name & "_LE.Text)"
                        .Save()
                    End With
                End If

                If ft.GridSortType = MTZMetaModel.MTZMetaModel.enumColumnSortType.ColumnSortType_As_String Then
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                            .RowSource = pvd.the_Alias
                            .FilterField = f.Name
                            .TheExpression = pvd.ViewColumn.Item(i).the_Alias & "_ID='"" & fltr.txt" & f.Name & ".Tag & ""'"" "
                            .Save()
                        End With

                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                            .RowSource = pvd.the_Alias
                            .FilterField = f.Name
                            .TheExpression = pvd.ViewColumn.Item(i).the_Alias & "='"" & fltr.cmb" & f.Name & ".Text & ""'"" "
                            .Save()
                        End With
                    ElseIf UCase(ft.Name) <> "FILE" And UCase(ft.Name) <> "ID" And UCase(ft.Name) <> "IMAGE" Then
                        With CType(ep.EPFilterLink.Add, MTZwp.MTZwp.EPFilterLink)
                            .RowSource = pvd.the_Alias
                            .FilterField = f.Name
                            .TheExpression = pvd.ViewColumn.Item(i).the_Alias & " like '%"" & fltr.txt" & f.Name & ".Text & ""%'"" "
                            .Save()
                        End With
                    End If
                End If
            Next
        Next
    End Sub


    Private Function FindJournal(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As MTZJrnl.MTZJrnl.Application
        Dim rs As DataTable
        Dim jr As MTZJrnl.MTZJrnl.Application = Nothing
        rs = Manager.Session.GetRowsEx("INSTANCE", , , "OBJTYPE='MTZJrnl' and Name='" & ot.Name & "'")
        If Not rs Is Nothing Then
            If rs.Rows.Count > 0 Then
                jr = Manager.GetInstanceObject(rs.Rows(0)("InstanceID"))
            End If
        End If
        FindJournal = jr
    End Function

    Private Function FindFilter(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE) As MTZFltr.MTZFltr.Application
        Dim rs As DataTable
        Dim jr As MTZFltr.MTZFltr.Application = Nothing
        rs = Manager.Session.GetRowsEx("INSTANCE", , , "OBJTYPE='MTZFltr' and Name='" & ot.Name & "'")
        If Not rs Is Nothing Then
            If rs.Rows.Count > 0 Then
                jr = Manager.GetInstanceObject(rs.Rows(0)("InstanceID"))
            End If
        End If
        FindFilter = jr
    End Function
End Class