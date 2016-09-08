Public Class frmPartCopy
    Private Sub frmPartCopy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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


    Private Sub cmdCopy_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopy.Click

        Dim obj As LATIR2.Document.DocRow_Base
        Dim pf As MTZMetaModel.MTZMetaModel.PART
        Dim pt As MTZMetaModel.MTZMetaModel.PART
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim ptcols As MTZMetaModel.MTZMetaModel.PART_col = Nothing


        If tvParts.SelectedNode Is Nothing Then Exit Sub
        If tvCopyTo.SelectedNode Is Nothing Then Exit Sub
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
        obj = tvCopyTo.SelectedNode.Tag
        If Not obj Is Nothing Then
            If obj.PartName = "PART" Then
                pt = obj
                ptcols = pt.PART
            ElseIf obj.PartName = "OBJECTTYPE" Then
                ot = obj
                ptcols = ot.PART
            End If
        Else
            Exit Sub
        End If
        CopyPart(pf, ptcols)
        FillTree(tvCopyTo)
    End Sub

    Private Sub CopyPart(pf As MTZMetaModel.MTZMetaModel.PART, pcol As MTZMetaModel.MTZMetaModel.PART_col)
        Dim pt As MTZMetaModel.MTZMetaModel.PART
        Dim imax As Integer
        Dim i As Integer
        Dim q As Integer
        imax = 0
        For i = 1 To pcol.Count
            pt = pcol.Item(i)
            If i = 1 Then imax = pt.Sequence
            If imax < pt.Sequence Then
                imax = pt.Sequence
            End If
        Next
        imax = imax + 1
        q = 1
        Dim dt As DataTable
        dt = Manager.Session.GetData("select name from part where name='" + pf.Name + "_" + q.ToString + "'")
        While dt.Rows.Count > 0
            q += 1
            dt = Manager.Session.GetData("select name from part where name='" + pf.Name + "_" + q.ToString + "'")
        End While
        pt = pcol.Add
        With pt
            .Sequence = imax
            .Name = pf.Name + "_" + q.ToString
            .PartType = pf.PartType
            .the_Comment = pf.the_Comment
            .shablonBrief = pf.shablonBrief
            .IsJormalChange = pf.IsJormalChange
            .ManualRegister = pf.ManualRegister
            .NoLog = pf.NoLog
            .ruleBrief = pf.ruleBrief
            .UseArchiving = pf.UseArchiving
            .Caption = pf.Caption
            .Save()
        End With

        If chkWithFields.Checked Then
            Dim fld As MTZMetaModel.MTZMetaModel.FIELD
            For i = 1 To pf.FIELD.Count
                fld = pf.FIELD.Item(i)
                CopyField(fld, pt)
            Next
        End If
    End Sub


    Private Sub CopyField(ByRef fld As MTZMetaModel.MTZMetaModel.FIELD, ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim ms As Integer = 0
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

    End Sub
End Class