Option Strict Off
Option Explicit On
Friend Class frmJouralList
	Inherits System.Windows.Forms.Form
	
	Public OK As Boolean
    Public model As MTZMetaModel.MTZMetaModel.Application
	Public Result As String
	Dim jcl As Collection
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		OK = False
		Me.Hide()
	End Sub
	
	'UPGRADE_WARNING: Form event frmJouralList.Activate has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub frmJouralList_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		lstJournal.Items.Clear()
		jcl = New Collection
		OK = False
		Dim i As Integer
        Dim rs As DataTable
        rs = model.Manager.Session.GetRowsDT("INSTANCE", , "OBJTYPE='MTZJrnl'")
		If rs Is Nothing Then Exit Sub
        Dim ti As tmpInst
        For i = 0 To rs.Rows.Count - 1

            ti = New tmpInst
            ti.ID = rs.Rows(i)("InstanceID")
            ti.Name = rs.Rows(i)("Name")
            jcl.Add(ti, ti.ID.ToString)

            lstJournal.Items.Add(New VB6.ListBoxItem(ti.Name, jcl.Count()))
        Next
        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing
        If (lstJournal.Items.Count > 0) Then
            lstJournal.SelectedIndex = 0
        End If

        Call frmJouralList_Resize(Me, New System.EventArgs())
    End Sub
	
	'UPGRADE_WARNING: Event frmJouralList.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmJouralList_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		lstJournal.Top = VB6.TwipsToPixelsY(30)
		lstJournal.Left = VB6.TwipsToPixelsX(30)
		lstJournal.Height = Me.ClientRectangle.Height
		lstJournal.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 100 - VB6.PixelsToTwipsX(OKButton.Width))
		
		OKButton.Top = VB6.TwipsToPixelsY(50)
		OKButton.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 50 - VB6.PixelsToTwipsX(OKButton.Width))
		
		CancelButton_Renamed.Left = OKButton.Left
		CancelButton_Renamed.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(OKButton.Top) + 50 + VB6.PixelsToTwipsY(OKButton.Height))
		
	End Sub
	
	Private Sub lstJournal_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstJournal.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		If lstJournal.SelectedIndex >= 0 Then
			OK = True
			'UPGRADE_WARNING: Couldn't resolve default property of object jcl.item().ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Result = jcl.Item(VB6.GetItemData(lstJournal, lstJournal.SelectedIndex)).ID
			'UPGRADE_NOTE: Object jcl may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			jcl = Nothing
			Me.Hide()
		End If
	End Sub
End Class