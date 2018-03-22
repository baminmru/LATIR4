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
End Class