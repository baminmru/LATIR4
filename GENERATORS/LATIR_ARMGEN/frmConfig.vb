Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	Public OK As Boolean
	
	Private Sub cmdPath2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath2.Click
		On Error GoTo bye
		cdlgOpen.ShowDialog()
		txtGUIManager.Text = cdlgOpen.FileName
bye: 
	End Sub
	
	Private Sub cmdPath3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath3.Click
		On Error GoTo bye
		cdlgOpen.ShowDialog()
		txtControls.Text = cdlgOpen.FileName
bye: 
	End Sub
	
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
        cdlgOpen.InitialDirectory = txtPath.Text
		cdlgOpen.ShowDialog()
		txtPath.Text = cdlgOpen.FileName
bye: 
	End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error GoTo bye
        FolderBrowserDialog1.ShowDialog()
        txtLevel2.Text = FolderBrowserDialog1.SelectedPath
bye:
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class