Option Strict Off
Option Explicit On
Friend Class frmSaveDesc
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public TypeName_Renamed As String
	'UPGRADE_NOTE: site was upgraded to site_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public site_Renamed As String
	
	Public OK As Boolean
	Private ID As String
	Public NewObject As Object
	Private types As Collection
	
	
	
	Private Sub CancelButton_Click()
		OK = False
		'UPGRADE_NOTE: Object types may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		types = Nothing
		Me.Hide()
	End Sub
	
	
	
	
	Private Sub cmbType_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	Private Sub cmdSelAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSelAll.Click
		Dim i As Integer
		For i = 0 To cmbType.Items.Count - 1
			cmbType.SetItemChecked(i, True)
		Next 
	End Sub
	
	Private Sub cmdUnselAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnselAll.Click
		Dim i As Integer
		For i = 0 To cmbType.Items.Count - 1
			cmbType.SetItemChecked(i, False)
		Next 
	End Sub
	
	Private Sub frmSaveDesc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim rs As datatable
		Dim i As Object
		Dim n, tn As String
        rs = Manager.Session.GetRowsExDT("OBJECTTYPE", , , , " order by Name")
		Dim o As tmpInst
		types = New Collection
		'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("Name") & " (" & rs.Rows(i)("the_comment") & ")"
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")
            o.ID = rs.Rows(i)("objecttypeid")
            types.Add(o)
            cmbType.Items.Add(New VB6.ListBoxItem(o.Name, i + 1))
        Next

        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
        End If
    End Sub
	
	'UPGRADE_WARNING: Event frmSaveDesc.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub frmSaveDesc_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		On Error Resume Next
		If VB6.PixelsToTwipsY(Me.Height) < 4170 Then Me.Height = VB6.TwipsToPixelsY(4170)
		If VB6.PixelsToTwipsX(Me.Width) < 6975 Then Me.Width = VB6.TwipsToPixelsX(6975)
		
		cmdPath.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 30 - VB6.PixelsToTwipsX(cmdPath.Width))
		txtPath.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(txtPath.Left) - VB6.PixelsToTwipsX(cmdPath.Width) - 60)
		cmbType.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(pb.Height) - 60 - VB6.PixelsToTwipsY(cmbType.Top))
		cmbType.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(cmbType.Width) - VB6.PixelsToTwipsX(cmdSelAll.Width) - 60)
		
		cmbType.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(cmbType.Left) - VB6.PixelsToTwipsX(cmdSelAll.Width) - 60)
		cmdSelAll.Left = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - VB6.PixelsToTwipsX(cmdSelAll.Width) - 30)
		cmdUnselAll.Left = cmdSelAll.Left
		OKButton.Left = cmdSelAll.Left
		OKButton.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(OKButton.Height) - VB6.PixelsToTwipsY(pb.Height) - 60)
		
		pb.Left = VB6.TwipsToPixelsX(30)
		pb.Top = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - VB6.PixelsToTwipsY(pb.Height) - 30)
		pb.Width = VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.ClientRectangle.Width) - 60)
		
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye
		'If cmbType.ListIndex = -1 Then Exit Sub
		
		
		
		Dim i As Integer
		pb.Maximum = cmbType.Items.Count - 1
		pb.Minimum = 0
		pb.Value = 0
		pb.Visible = True
		For i = 0 To cmbType.Items.Count - 1
			If cmbType.GetItemChecked(i) Then
                SaveTypeXML(types.Item(i + 1).ID.ToString)
				cmbType.SetItemChecked(i, False)
			End If
			pb.Value = i
		Next 
		pb.Visible = False
		MsgBox("Сохранение завершено",  , "Сохранение описания типов")
		
bye: 
	End Sub
	
    Private Sub SaveTypeXML(ByVal ID As String)
        On Error Resume Next
        Dim item As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        item = model.OBJECTTYPE.Item(ID)
        If item Is Nothing Then Exit Sub

        Dim fn As String
        Dim xdom As System.Xml.XmlDocument
        
        On Error GoTo bye

        fn = txtPath.Text & item.Name & ".xml"
        item.LockResource(True)


        xdom = New System.Xml.XmlDocument
        xdom.LoadXml("<OBJECTTYPE></OBJECTTYPE>")
        item.XMLSave(xdom.LastChild, xdom)
        xdom.Save(fn)
        item.UnLockResource()

bye:
    End Sub
	
	
	Private Sub cmdPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath.Click
        Dim path As String = ""

        If cdlgFolder.ShowDialog() = Windows.Forms.DialogResult.OK Then
            path = cdlgFolder.SelectedPath
        End If

		
        If (path <> "") Then
            txtPath.Text = path & "\"
        End If
	End Sub
End Class