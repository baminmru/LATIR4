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
		'chkFullText.Value = GetSetting(App.Title, "POSTGRESGEN", "FULLTEXT", vbChecked)
		chkInit.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "INIT", CStr(System.Windows.Forms.CheckState.Checked)))
		chkKernel.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "KERNEL", CStr(System.Windows.Forms.CheckState.Checked)))
		chkMethods.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "METHODS", CStr(System.Windows.Forms.CheckState.Checked)))
		chkProcs.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "PROCS", CStr(System.Windows.Forms.CheckState.Checked)))
		chkTables.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "TABLES", CStr(System.Windows.Forms.CheckState.Checked)))
		chkView.CheckState = CShort(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "VIEW", CStr(System.Windows.Forms.CheckState.Checked)))
		'chkMaintein.Value = GetSetting(App.Title, "POSTGRESGEN", "MAINTEIN", vbChecked)
		'chkManual.Value = GetSetting(App.Title, "POSTGRESGEN", "MANUAL", vbChecked)
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		
		'SaveSetting App.Title, "POSTGRESGEN", "FULLTEXT", chkFullText.Value
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "INIT", CStr(chkInit.CheckState))
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "KERNEL", CStr(chkKernel.CheckState))
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "METHODS", CStr(chkMethods.CheckState))
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "PROCS", CStr(chkProcs.CheckState))
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "TABLES", CStr(chkTables.CheckState))
		SaveSetting(My.Application.Info.Title, "POSTGRESGEN", "VIEW", CStr(chkView.CheckState))
		'SaveSetting App.Title, "POSTGRESGEN", "MAINTEIN", chkMaintein.Value
		'SaveSetting App.Title, "POSTGRESGEN", "MANUAL", chkManual.Value
		Me.Close()
	End Sub
End Class