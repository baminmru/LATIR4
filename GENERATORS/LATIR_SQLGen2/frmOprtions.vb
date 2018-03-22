Option Strict Off
Option Explicit On
Friend Class frmOptions
	Inherits System.Windows.Forms.Form
	
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        chkFullText.Checked = GetSetting("LATIR4", "CFG", "FULLTEXT")="True"
        chkInit.Checked = GetSetting("LATIR4", "CFG", "INIT") = "True"
        chkKernel.Checked = GetSetting("LATIR4", "CFG", "KERNEL")="True"
        chkMethods.Checked = GetSetting("LATIR4", "CFG", "METHODS") = "True"
        chkProcs.Checked = GetSetting("LATIR4", "CFG", "PROCS")="True"
        chkTables.Checked = GetSetting("LATIR4", "CFG", "TABLES") = "True"
        chkView.Checked = GetSetting("LATIR4", "CFG", "VIEW")="True"
        chkMaintein.Checked = GetSetting("LATIR4", "CFG", "MAINTEIN") = "True"
        chkManual.Checked = GetSetting("LATIR4", "CFG", "MANUAL")="True"
        chkLite.Checked = GetSetting("LATIR4", "CFG", "LITEMODE", "False") = "True"
    End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
        SaveSetting("LATIR4", "CFG", "FULLTEXT", chkFullText.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "INIT", chkInit.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "KERNEL", chkKernel.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "METHODS", chkMethods.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "PROCS", chkProcs.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "TABLES", chkTables.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "VIEW", chkView.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "MAINTEIN", chkMaintein.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "MANUAL", chkManual.Checked.ToString())
        SaveSetting("LATIR4", "CFG", "LITEMODE", chkLite.Checked.ToString())

        Me.Close()
	End Sub
End Class