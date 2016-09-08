Public Class frmSettings

    Private Sub Command3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command3.Click
        If (txtLATIRFolder.Text <> String.Empty) Then
            FolderBrowserDialog1.RootFolder = txtLATIRFolder.Text
        End If
        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            txtLATIRFolder.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtLATIRFolder.Text = GetSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH")
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        SaveSetting("LATIR4", "CFG", "SETTINGS_LATIRDLLSPATH", txtLATIRFolder.Text)
        Close()
    End Sub

    Private Sub Command2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command2.Click
        Close()
    End Sub
End Class