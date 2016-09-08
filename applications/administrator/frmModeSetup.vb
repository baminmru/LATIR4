Public Class frmModeSetup

    Private lastOT As MTZMetaModel.MTZMetaModel.OBJECTTYPE
    Private lastOM As MTZMetaModel.MTZMetaModel.OBJECTMODE

    Private Sub frmModeSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillTree(tvParts)

    End Sub


    Private Sub FillTree(ByRef tv As TreeView)
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim i As Integer
        Dim n As TreeNode
        tv.Nodes.Clear()
        model.OBJECTTYPE.Sort = "name"
        For i = 1 To model.OBJECTTYPE.Count
            ot = model.OBJECTTYPE.Item(i)
            n = tv.Nodes.Add(ot.ID.ToString, ot.Name + " : " + ot.the_Comment)
            n.Tag = ot
            FillParts(n, ot.PART)
        Next


    End Sub

    Private Sub FillParts(ByRef np As TreeNode, parts As MTZMetaModel.MTZMetaModel.PART_col)

        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer

        Dim n As TreeNode
        parts.Sort = "name"
        For i = 1 To parts.Count
            p = parts.Item(i)
            n = np.Nodes.Add(p.ID.ToString, p.Name + " | " + p.Caption)
            n.Tag = p
            FillParts(n, p.PART)
        Next

    End Sub



    Private Sub tvParts_NodeMouseClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvParts.NodeMouseClick
        Dim obj As LATIR2.Document.DocRow_Base
        obj = e.Node.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then
                FillList(obj, lstFrom)

            Else
                FillModes(obj, lstMode)
                If lstMode.Items.Count > 0 Then
                    lstMode_SelectedIndexChanged(sender, e)
                End If
            End If

        End If
    End Sub


    Private Sub FillList(ByRef p As MTZMetaModel.MTZMetaModel.PART, lst As Windows.Forms.CheckedListBox)
        Dim dt As DataTable
        'p.FIELD.Sort = "Caption"

        dt = Manager.Session.GetData("select " + Manager.Session.GetProvider.ID2Base("fieldid", "ID") + ", name, Caption, fieldgroupbox,tabname  from field where parentstructrowid=" + Manager.Session.GetProvider.ID2Const(p.ID) + " order by tabname,fieldgroupbox,caption")
        lst.Items.Clear()
        For Each dr As DataRow In dt.Rows
            Dim s As String
            s = "" & dr("tabname").ToString()
            While s.Length < 10
                s += " "
            End While
            If s.Length > 8 Then
                s = s.Substring(0, 8) + ".."
            End If
            s = s & dr("fieldgroupbox")
            While s.Length < 18
                s += " "
            End While
            If s.Length > 18 Then
                s = s.Substring(0, 16) + ".."
            End If
            s = s + "|" + dr("caption")
            While s.Length < 40
                s += " "
            End While
            If s.Length > 40 Then

                s = s.Substring(0, 38) + ".."

            End If
            s += "|" + dr("name")
            While s.Length < 80
                s += " "
            End While
            s += "|" + dr("id").ToString
            lst.Items.Add(s)
        Next

    End Sub


    Private Sub FillModes(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE, lst As Windows.Forms.ListBox)
        Dim dt As DataTable
        dt = ot.OBJECTMODE.GetDataTable()
        lastOT = ot
        lst.DisplayMember = "Brief"
        lst.ValueMember = "ID"
        lst.DataSource = dt
    End Sub


    'Private Sub FillRestriction(lst As Windows.Forms.ListBox)
    '    Dim dt As DataTable
    '    dt = New DataTable
    '    dt.Columns.Add("name")
    '    Dim dr As DataRow

    '    dr = dt.NewRow
    '    dr("name") = "Read"
    '    dt.Rows.Add(dr)

    '    dr = dt.NewRow
    '    dr("name") = "Write"
    '    dt.Rows.Add(dr)

    '    dr = dt.NewRow
    '    dr("name") = "Mandatory"
    '    dt.Rows.Add(dr)

    '    dr = dt.NewRow
    '    dr("name") = "Add"
    '    dt.Rows.Add(dr)

    '    dr = dt.NewRow
    '    dr("name") = "Delete"
    '    dt.Rows.Add(dr)

    '    lst.DisplayMember = "name"
    '    lst.ValueMember = "name"
    '    lst.DataSource = dt
    'End Sub

    Private Sub cmdAddMode_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddMode.Click
        If Not lastOT Is Nothing And txtNewMode.Text <> "" Then
            With CType(lastOT.OBJECTMODE.Add, MTZMetaModel.MTZMetaModel.OBJECTMODE)
                .Name = txtNewMode.Text
                .Save()
            End With
            txtNewMode.Text = ""
            FillModes(lastOT, lstMode)
            If lstMode.Items.Count > 0 Then
                lstMode_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub lstMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstMode.SelectedIndexChanged
        If Not lastOT Is Nothing And lstMode.Text <> "" Then

            Dim i As Integer
            For i = 1 To lastOT.OBJECTMODE.Count
                If lastOT.OBJECTMODE.Item(i).Brief = lstMode.Text Then
                    lastOM = lastOT.OBJECTMODE.Item(i)
                    FillModeInfo(lastOM, gvRestriction)
                    FillModePartInfo(lastOM, gvPartRestriction)
                End If
            Next
        End If
    End Sub



    Private Sub FillModePartInfo(ByRef om As MTZMetaModel.MTZMetaModel.OBJECTMODE, lst As Windows.Forms.DataGridView)
        Dim dt As DataTable
        dt = om.STRUCTRESTRICTION.GetDataTable
        lst.DataSource = dt

        For Each col As DataGridViewColumn In lst.Columns
            col.Visible = False
            If col.Name.ToLower = "struct".ToLower Then
                col.Visible = True
                col.HeaderText = "Раздел"
                col.Width = 150
            End If

            If col.Name.ToLower = "AllowAdd".ToLower Then
                col.Visible = True
                col.HeaderText = "A"
            End If
            If col.Name.ToLower = "AllowRead".ToLower Then
                col.Visible = True
                col.HeaderText = "R"
            End If
            If col.Name.ToLower = "AllowEdit".ToLower Then
                col.Visible = True
                col.HeaderText = "W"
            End If
            If col.Name.ToLower = "AllowDelete".ToLower Then
                col.Visible = True
                col.HeaderText = "D"
            End If
        Next
    End Sub

    Private Sub FillModeInfo(ByRef om As MTZMetaModel.MTZMetaModel.OBJECTMODE, lst As Windows.Forms.DataGridView)
        Dim dt As DataTable
        dt = om.FIELDRESTRICTION.GetDataTable
        lst.DataSource = dt

        For Each col As DataGridViewColumn In lst.Columns
            col.Visible = False
            If col.Name.ToLower = "ThePart".ToLower Then
                col.Visible = True
                col.HeaderText = "Раздел"
                col.Width = 150
            End If
            If col.Name.ToLower = "TheField".ToLower Then
                col.Visible = True
                col.HeaderText = "Поле"
                col.Width = 150
            End If
            If col.Name.ToLower = "AllowRead".ToLower Then
                col.Visible = True
                col.HeaderText = "R"
            End If
            If col.Name.ToLower = "AllowModify".ToLower Then
                col.Visible = True
                col.HeaderText = "W"
            End If
            If col.Name.ToLower = "MandatoryField".ToLower Then
                col.Visible = True
                col.HeaderText = "M"
            End If
        Next



        'Dim ts As DataGridTableStyle
        'Dim cs As DataGridTextBoxColumn
        'ts = New DataGridTableStyle
        'ts.MappingName = "FIELDRESTRICTION"
        'ts.ReadOnly = True
        'ts.RowHeaderWidth = 30
        'cs = New DataGridTextBoxColumn
        'cs.ReadOnly = True
        'cs.HeaderText = "Структура, которой принадлежит поле"
        'cs.MappingName = "ThePart"
        'cs.NullText = ""
        'ts.GridColumnStyles.Add(cs)
        'cs = New DataGridTextBoxColumn
        'cs.ReadOnly = True
        'cs.HeaderText = "Поле, на которое накладывается ограничение"
        'cs.MappingName = "TheField"
        'cs.NullText = ""
        'ts.GridColumnStyles.Add(cs)
        'cs = New DataGridTextBoxColumn
        'cs.ReadOnly = True
        'cs.HeaderText = "Разрешен просмотр"
        'cs.MappingName = "AllowRead"
        'cs.NullText = ""
        'ts.GridColumnStyles.Add(cs)
        'cs = New DataGridTextBoxColumn
        'cs.ReadOnly = True
        'cs.HeaderText = "Разрешена модификация"
        'cs.MappingName = "AllowModify"
        'cs.NullText = ""
        'ts.GridColumnStyles.Add(cs)
        'cs = New DataGridTextBoxColumn
        'cs.ReadOnly = True
        'cs.HeaderText = "Обязательное поле"
        'cs.MappingName = "MandatoryField"
        'cs.NullText = ""
        'ts.GridColumnStyles.Add(cs)

        'cv.GridView.InitFields(ts)
    End Sub

    Private Sub cmdAdd_Click(sender As System.Object, e As System.EventArgs) Handles cmdAdd.Click
        Dim obj As LATIR2.Document.DocRow_Base
        Dim pf As MTZMetaModel.MTZMetaModel.PART
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Dim sf() As String

        If tvParts.SelectedNode Is Nothing Then Exit Sub

        obj = tvParts.SelectedNode.Tag
        If Not lastOM Is Nothing Then
            If Not obj Is Nothing Then
                If obj.PartName = "PART" Then

                    pf = obj
                    For Each s As String In lstFrom.CheckedItems()
                        sf = s.Split("|")
                        If sf.Length = 4 Then
                            fld = pf.FIELD.Item(sf(3))

                            If Not fld Is Nothing Then
                                Dim i As Integer
                                Dim fr As MTZMetaModel.MTZMetaModel.FIELDRESTRICTION
                                fr = Nothing
                                For i = 1 To lastOM.FIELDRESTRICTION.Count
                                    fr = lastOM.FIELDRESTRICTION.Item(i)
                                    If fr.ThePart.ID = pf.ID And fr.TheField.ID = fld.ID Then
                                        Exit For
                                    End If
                                    fr = Nothing
                                Next
                                If fr Is Nothing Then
                                    fr = lastOM.FIELDRESTRICTION.Add
                                End If
                                With fr
                                    .ThePart = pf
                                    .TheField = fld
                                    If chkEdit.Checked Then
                                        .AllowModify = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                                    Else
                                        .AllowModify = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                                    End If
                                    If chkRead.Checked Then
                                        .AllowRead = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                                    Else
                                        .AllowRead = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                                    End If
                                    If chkM.Checked Then
                                        .MandatoryField = MTZMetaModel.MTZMetaModel.enumTriState.TriState_Da
                                    Else
                                        .MandatoryField = MTZMetaModel.MTZMetaModel.enumTriState.TriState_Net
                                    End If


                                    .Save()
                                End With
                            End If

                        End If
                    Next
                    If lstFrom.CheckedItems.Count > 0 Then
                        FillModeInfo(lastOM, gvRestriction)
                    End If



                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If





        End If

    End Sub

    Private Sub tvParts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvParts.AfterSelect

    End Sub

    Private Sub cmdAddPart_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddPart.Click
        Dim obj As LATIR2.Document.DocRow_Base
        Dim pf As MTZMetaModel.MTZMetaModel.PART
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD

        If tvParts.SelectedNode Is Nothing Then Exit Sub

        obj = tvParts.SelectedNode.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then

                pf = obj
            
        Else
            Exit Sub
        End If
        Else
            Exit Sub
        End If

        If Not lastOM Is Nothing Then
            Dim i As Integer
            Dim fr As MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION
            fr = Nothing
            For i = 1 To lastOM.STRUCTRESTRICTION.Count
                fr = lastOM.STRUCTRESTRICTION.Item(i)
                If fr.Struct.ID = pf.ID Then
                    Exit For
                End If
                fr = Nothing
            Next
            If fr Is Nothing Then
                fr = lastOM.STRUCTRESTRICTION.Add
            End If
            With fr
                .Struct = pf

                If chkPartEdit.Checked Then
                    .AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                Else
                    .AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                End If
                If chkPartRead.Checked Then
                    .AllowRead = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                Else
                    .AllowRead = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                End If
                If chkPartDelete.Checked Then
                    .AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                Else
                    .AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                End If
                If chkPartAdd.Checked Then
                    .AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                Else
                    .AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                End If

                .Save()
            End With
            FillModePartInfo(lastOM, gvPartRestriction)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To lstFrom.Items.Count - 1
            lstFrom.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To lstFrom.Items.Count - 1
            lstFrom.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub cmdClearParts_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearParts.Click
        Dim obj As LATIR2.Document.DocRow_Base
        Dim pf As MTZMetaModel.MTZMetaModel.PART
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD

       

        If Not lastOM Is Nothing Then
            Dim i As Integer
            Dim fr As MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION
            fr = Nothing
            While lastOM.STRUCTRESTRICTION.Count > 0
                lastOM.STRUCTRESTRICTION.Delete(1)
            End While
            FillModePartInfo(lastOM, gvPartRestriction)
        End If
    End Sub

    Private Sub cmdClearFields_Click(sender As System.Object, e As System.EventArgs) Handles cmdClearFields.Click
       
        If Not lastOM Is Nothing Then
            
            While lastOM.FIELDRESTRICTION.Count > 0
                lastOM.FIELDRESTRICTION.Delete(1)
            End While

            FillModeInfo(lastOM, gvRestriction)

        End If
    End Sub
End Class