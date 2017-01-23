Option Strict Off
Option Explicit On
Friend Class frmOptions
	Inherits System.Windows.Forms.Form
	
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	Private Sub frmOptions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        chkFullText.Checked = My.Settings.FULLTEXT
        chkInit.Checked = My.Settings.INIT
        chkKernel.Checked = My.Settings.KERNEL
        chkMethods.Checked = My.Settings.METHODS
        chkProcs.Checked = My.Settings.PROCS
        chkTables.Checked = My.Settings.TABLES
        chkView.Checked = My.Settings.VIEW
        chkMaintein.Checked = My.Settings.MAINTEIN
        chkManual.Checked = My.Settings.MANUAL
        chkLite.Checked = My.Settings.LITEMODE
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
        My.Settings.FULLTEXT = chkFullText.Checked
        My.Settings.INIT = chkInit.Checked
        My.Settings.KERNEL = chkKernel.Checked
        My.Settings.METHODS = chkMethods.Checked
        My.Settings.PROCS = chkProcs.Checked
        My.Settings.TABLES = chkTables.Checked
        My.Settings.VIEW = chkView.Checked
        My.Settings.MAINTEIN = chkMaintein.Checked
        My.Settings.MANUAL = chkManual.Checked
        My.Settings.LITEMODE = chkLite.Checked
        My.Settings.Save()
		Me.Close()
	End Sub
End Class