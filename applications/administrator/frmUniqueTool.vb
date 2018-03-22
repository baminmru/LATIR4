Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class frmUniqueTool
	Inherits System.Windows.Forms.Form
    Private P As MTZMetaModel.MTZMetaModel.PART
    Private fld As MTZMetaModel.MTZMetaModel.FIELD

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Dim uc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
        Dim i As Integer
        If lstFields.CheckedIndices.Count > 0 Then
            uc = P.UNIQUECONSTRAINT.Add
            With uc
                .Name = txtName.Text
                .TheComment = txtDesc.Text
                If chkIsGlobal.CheckState = System.Windows.Forms.CheckState.Checked Then
                    .PerParent = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net
                Else
                    .PerParent = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da
                End If
                .Save()
                For i = 0 To lstFields.Items.Count - 1
                    If lstFields.GetItemChecked(i) Then

                        With CType(uc.CONSTRAINTFIELD.Add, MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD)
                            .TheField = P.FIELD.Item(i + 1)
                            .Save()
                        End With
                    End If
                Next
            End With
        End If
    End Sub
	
	Private Sub cmdPart_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPart.Click
        Dim ID As Guid
        Dim Brief As String = "" = ""
		Dim i As Integer
        If guiManager.GetReferenceDialog("PART", "", Guid.Empty, ID, Brief) Then
            txtPart.Tag = ID
            txtPart.Text = Brief
            If Not ID.Equals(Guid.Empty) Then
                P = model.FindRowObject("PART", txtPart.Tag)
                lstFields.Items.Clear()
                P.FIELD.Sort = "Caption"
                For i = 1 To P.FIELD.Count
                    fld = P.FIELD.Item(i)
                    lstFields.Items.Add(fld.Caption)
                Next
            End If
        End If
	End Sub

    Private Sub txtPart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPart.TextChanged

    End Sub
End Class