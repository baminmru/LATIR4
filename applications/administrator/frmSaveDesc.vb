Option Strict Off
Option Explicit On
Friend Class frmSaveDesc
	Inherits System.Windows.Forms.Form

	Public TypeName_Renamed As String
    Public site_Renamed As String
    Public OK As Boolean
	Private ID As String
	Public NewObject As Object

	
	
	
	Private Sub CancelButton_Click()
		OK = False
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

        rs = Manager.Session.GetRowsExDT("OBJECTTYPE", "name,the_comment,issingleinstance," + Manager.Session.GetProvider.ID2Base("objecttypeid"), , , , " order by Name")
		Dim o As tmpInst


        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("Name") & " (" & rs.Rows(i)("the_comment") & ")"
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")
            o.ID = New Guid(rs.Rows(i)("objecttypeid").ToString)

            cmbType.Items.Add(o)
        Next


        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
        End If
    End Sub
	
	
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye

        Dim i As Integer
        Dim ti As tmpInst
		pb.Maximum = cmbType.Items.Count - 1
		pb.Minimum = 0
		pb.Value = 0
		pb.Visible = True
		For i = 0 To cmbType.Items.Count - 1
            If cmbType.GetItemChecked(i) Then
                ti = cmbType.Items(i)
                SaveTypeXML(ti.ID.ToString)
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