Public Class frmSequenceTool

    Private lastOT As MTZMetaModel.MTZMetaModel.OBJECTTYPE
    Private lastP As MTZMetaModel.MTZMetaModel.PART

    Private Sub frmSequenceTool_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
                lastP = obj
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim colTab As Collection
        Dim col As Collection
        Dim fg As String
        Dim HasUnGroupedField As Boolean = False
        Dim j As Integer
        'If lastOT Is Nothing Then Exit Sub
        If lastP Is Nothing Then Exit Sub

        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim ti As Integer

        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        ot = lastOT

        Dim fld As MTZMetaModel.MTZMetaModel.FIELD

        colTab = New Collection
        col = New Collection
        p = lastP

        P.FIELD.Sort = "sequence"
        Dim maxSeq As Integer = -1000
        Dim curSeq As Integer

        For i = 1 To p.FIELD.Count

            Try
                colTab.Add(p.FIELD.Item(i).TabName, p.FIELD.Item(i).TabName)
            Catch ex As Exception
                ' non unique
            End Try
            If maxSeq < p.FIELD.Item(i).Sequence Then
                maxSeq = p.FIELD.Item(i).Sequence
            End If
       

            If p.FIELD.Item(i).FieldGroupBox <> "" Then
                fg = p.FIELD.Item(i).FieldGroupBox
                Try
                    col.Add(fg, fg)
                Catch ex As Exception
                    ' non unique
                End Try
            Else
                HasUnGroupedField = True
            End If

        Next
        txtOut.Text = "max sequence=" + maxSeq.ToString
        Dim cnt As Integer
        cnt = col.Count
        If HasUnGroupedField Then
            cnt = cnt + 1
        End If
        curSeq = maxSeq + 10
        For ti = 1 To colTab.Count

            If HasUnGroupedField Then
                For i = 1 To p.FIELD.Count
                    If colTab.Item(ti) = p.FIELD.Item(i).TabName Then
                        If p.FIELD.Item(i).FieldGroupBox = "" Then
                            p.FIELD.Item(i).Sequence = curSeq
                            curSeq = curSeq + 10
                            p.FIELD.Item(i).Save()
                            txtOut.Text = p.FIELD.Item(i).Name + " --> " + p.FIELD.Item(i).Sequence.ToString() + vbCrLf + txtOut.Text
                        End If
                    End If
                Next
            End If

            For j = 1 To col.Count
                For i = 1 To p.FIELD.Count
                    If colTab.Item(ti) = p.FIELD.Item(i).TabName Then
                        If p.FIELD.Item(i).FieldGroupBox = col.Item(j) Then
                            p.FIELD.Item(i).Sequence = curSeq
                            curSeq = curSeq + 10
                            txtOut.Text = p.FIELD.Item(i).TabName + ":" + p.FIELD.Item(i).FieldGroupBox + ":" + p.FIELD.Item(i).Name + " --> " + p.FIELD.Item(i).Sequence.ToString() + vbCrLf + txtOut.Text
                            p.FIELD.Item(i).Save()
                        End If
                    End If
                Next
            Next
        Next
        txtOut.Text = "results "
        p.FIELD.Sort = "sequence"
        For i = 1 To p.FIELD.Count
            p.FIELD.Item(i).Sequence = p.FIELD.Item(i).Sequence - maxSeq
            txtOut.Text = p.FIELD.Item(i).TabName + ":" + p.FIELD.Item(i).FieldGroupBox + ":" + p.FIELD.Item(i).Name + " --> " + p.FIELD.Item(i).Sequence.ToString() + vbCrLf + txtOut.Text
            p.FIELD.Item(i).Save()
        Next

        MsgBox("Sequence updated")
    End Sub
End Class