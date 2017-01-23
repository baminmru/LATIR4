Option Strict Off
Option Explicit On
Friend Class frmTypeList
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public TypeName_Renamed As String
	'UPGRADE_NOTE: site was upgraded to site_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public site_Renamed As String
	
	Public OK As Boolean
	Private ID As String
	Public NewObject As Object
	Private types As Collection
	
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		OK = False
		'UPGRADE_NOTE: Object types may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		types = Nothing
		Me.Hide()
	End Sub
	
	
	Private Sub cmbType_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	Private Sub frmTypeList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim rs As datatable
		Dim i As Object
		Dim n, tn As String
        rs = Manager.Session.GetRows("OBJECTTYPE")
		Dim o As tmpInst
		types = New Collection
		'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("the_comment")
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")
            o.ID = rs.Rows(i)("objecttypeid")
            types.Add(o)
            cmbType.Items.Add(New VB6.ListBoxItem(o.Name, i))
        Next

        'UPGRADE_NOTE: Object rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
        End If
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye
		If cmbType.SelectedIndex = -1 Then Exit Sub
		'UPGRADE_WARNING: Couldn't resolve default property of object types.item().ObjType. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		TypeName_Renamed = types.Item(VB6.GetItemData(cmbType, cmbType.SelectedIndex)).ObjType
		'UPGRADE_WARNING: Couldn't resolve default property of object types.item().ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ID = types.Item(VB6.GetItemData(cmbType, cmbType.SelectedIndex)).ID
		OK = True
		'UPGRADE_NOTE: Object types may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		types = Nothing
		Me.Hide()
		
bye: 
	End Sub
End Class