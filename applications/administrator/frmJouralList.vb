Option Strict Off
Option Explicit On
Friend Class frmJouralList
	Inherits System.Windows.Forms.Form
	
	Public OK As Boolean
    Public model As MTZMetaModel.MTZMetaModel.Application
	Public Result As String

	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		OK = False
		Me.Hide()
	End Sub
	
    Private Sub frmJouralList_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
        lstJournal.Items.Clear()
        OK = False
        Dim rs As DataTable
        rs = model.Manager.Session.GetRowsDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, , "OBJTYPE='mtzjrnl'")
        If rs Is Nothing Then Exit Sub
        lstJournal.DisplayMember = "Name"
        lstJournal.ValueMember = "InstanceID"
        lstJournal.DataSource = rs


    End Sub
	

	
	Private Sub lstJournal_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstJournal.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		If lstJournal.SelectedIndex >= 0 Then
			OK = True
            Result = lstJournal.SelectedValue
            Me.Hide()
		End If
	End Sub
End Class