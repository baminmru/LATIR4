Option Strict Off
Option Explicit On
Friend Class frmOptions
	Inherits System.Windows.Forms.Form
	
	
	Private Sub Check1_Click()
		
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'chkFullText.Value = GetSetting(App.Title, "ORAGEN", "FULLTEXT", vbChecked)
        chkInit.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "INIT", CStr(System.Windows.Forms.CheckState.Checked)))
        chkKernel.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "KERNEL", CStr(System.Windows.Forms.CheckState.Checked)))
        chkMethods.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "METHODS", CStr(System.Windows.Forms.CheckState.Checked)))
        chkProcs.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "PROCS", CStr(System.Windows.Forms.CheckState.Checked)))
        chkTables.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "TABLES", CStr(System.Windows.Forms.CheckState.Checked)))
        chkView.CheckState = CShort(GetSetting(My.Application.Info.Title, "ORAGEN", "VIEW", CStr(System.Windows.Forms.CheckState.Checked)))
        txtSchema.Text = GetSetting(My.Application.Info.Title, "ORAGEN", "SCHEMA", "LATIR4")
        'chkMaintein.Value = GetSetting(App.Title, "ORAGEN", "MAINTEIN", vbChecked)
        'chkManual.Value = GetSetting(App.Title, "ORAGEN", "MANUAL", vbChecked)
    End Sub

    Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click

        'SaveSetting App.Title, "ORAGEN", "FULLTEXT", chkFullText.Value
        SaveSetting(My.Application.Info.Title, "ORAGEN", "INIT", CStr(chkInit.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "KERNEL", CStr(chkKernel.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "METHODS", CStr(chkMethods.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "PROCS", CStr(chkProcs.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "TABLES", CStr(chkTables.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "VIEW", CStr(chkView.CheckState))
        SaveSetting(My.Application.Info.Title, "ORAGEN", "SCHEMA", txtSchema.Text)
        'SaveSetting App.Title, "ORAGEN", "MAINTEIN", chkMaintein.Value
        'SaveSetting App.Title, "ORAGEN", "MANUAL", chkManual.Value
        Me.Close()
	End Sub
End Class