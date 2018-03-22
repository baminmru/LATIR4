Public Class frmFieldCopy

    Private Sub frmFieldCopy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillTree(tvParts)
        FillTree(tvCopyTo)

    End Sub

    Private Sub FillTree(ByRef tv As TreeView)
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim i As Integer
        Dim n As TreeNode
        tv.Nodes.Clear()
        model.OBJECTTYPE.Sort = "name"
        For i = 1 To model.OBJECTTYPE.Count
            ot = model.OBJECTTYPE.Item(i)
            n = tv.Nodes.Add(ot.ID.ToString, ot.Brief)
            n.Tag = ot
            FillParts(n, ot.PART)
        Next


    End Sub

    Private Sub FillParts(ByRef np As TreeNode, parts As MTZMetaModel.MTZMetaModel.PART_col)

        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer

        Dim n As TreeNode
        parts.Sort = "sequence"
        For i = 1 To parts.Count
            p = parts.Item(i)
            n = np.Nodes.Add(p.ID.ToString, p.Brief)
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
            End If
        End If
    End Sub


    Private Sub FillList(ByRef p As MTZMetaModel.MTZMetaModel.PART, lst As Windows.Forms.ListBox)
        Dim dt As DataTable
        p.FIELD.Sort = "sequence"
        dt = p.FIELD.GetDataTable()
        'lst.Sorted = True
        lst.DisplayMember = "Brief"
        lst.ValueMember = "ID"
        Dim dv As DataView
        dv = New DataView(dt, "", "sequence", DataViewRowState.CurrentRows)
        lst.DataSource = dv

    End Sub

    Private Sub tvParts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvParts.AfterSelect

    End Sub

    Private Sub tvCopyTo_NodeMouseClick(sender As System.Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvCopyTo.NodeMouseClick
        Dim obj As LATIR2.Document.DocRow_Base
        obj = e.Node.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then
                FillList(obj, lstTo)
            End If
        End If
    End Sub

    Private Sub cmdCopy_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopy.Click

        Dim obj As LATIR2.Document.DocRow_Base
        Dim pf As MTZMetaModel.MTZMetaModel.PART
        Dim pt As MTZMetaModel.MTZMetaModel.PART
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD

        If tvParts.SelectedNode Is Nothing Then Exit Sub
        If tvCopyTo.SelectedNode Is Nothing Then Exit Sub
        obj = tvParts.SelectedNode.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then
                If lstFrom.SelectedIndex >= 0 Then
                    pf = obj
                    fld = pf.FIELD.Item(lstFrom.SelectedValue.ToString)
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        obj = tvCopyTo.SelectedNode.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then
                pt = obj
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
        CopyField(fld, pt)
    End Sub


    Private Sub CopyField(ByRef fld As MTZMetaModel.MTZMetaModel.FIELD, ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim ms As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim i As Integer
        For i = 1 To p.FIELD.Count
            f = p.FIELD.Item(i)
            If i = 1 Then
                ms = f.Sequence
            Else
                If ms < f.Sequence Then
                    ms = f.Sequence
                End If
            End If
            If fld.Name = f.Name Then
                MsgBox("Поле " & f.Name & " уже есть в разделе " & p.Name)
                Exit Sub
            End If
        Next
        f = p.FIELD.Add()
        With f
            .Sequence = ms + 1
            .Name = fld.Name
            .ReferenceType = fld.ReferenceType
            .AllowNull = fld.AllowNull
            .Caption = fld.Caption
            .DataSize = fld.DataSize
            .TabName = fld.TabName
            .FieldGroupBox = fld.FieldGroupBox
            .FieldType = fld.FieldType
            .InternalReference = fld.InternalReference
            .IsAutoNumber = fld.IsAutoNumber
            .IsBrief = fld.IsBrief
            .IsLocked = fld.IsLocked
            .IsTabBrief = fld.IsTabBrief
            .NumberDateField = fld.NumberDateField
            .RefToPart = fld.RefToPart
            .RefToType = fld.RefToType
            .shablonBrief = fld.shablonBrief
            .TheComment = fld.TheComment
            .TheMask = fld.TheMask
            .theNameClass = fld.theNameClass
            .TheNumerator = fld.TheNumerator
            .TheStyle = fld.TheStyle
            .ZoneTemplate = fld.ZoneTemplate
            .Save()
        End With
        FillList(p, lstTo)
    End Sub

    Private Sub tvCopyTo_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvCopyTo.AfterSelect

    End Sub
End Class