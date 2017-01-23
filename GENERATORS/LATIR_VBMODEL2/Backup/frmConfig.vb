Option Strict Off
Option Explicit On
Friend Class frmConfig
    Inherits System.Windows.Forms.Form
    Public OK As Boolean

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        OK = True
        Me.Hide()
    End Sub

    Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
        OK = False
        Me.Hide()
    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
        On Error GoTo bye
        cdlgOpen.ShowDialog()
        txtPath.Text = cdlgOpen.FileName
bye:
    End Sub

    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        Me.ToolTip1.SetToolTip(Me.txtPath, Me.txtPath.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error GoTo bye
        FolderBrowserDialog1.ShowDialog()
        txtOutPath.Text = FolderBrowserDialog1.SelectedPath
bye:
    End Sub
End Class