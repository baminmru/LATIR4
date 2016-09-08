Option Strict Off
Option Explicit On
Friend Class frmTypeList
	Inherits System.Windows.Forms.Form

	Public TypeName_Renamed As String

	Public site_Renamed As String
	
	Public OK As Boolean
	Private ID As String
	Public NewObject As Object

	
	
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		OK = False
		Me.Hide()
	End Sub
	
	
	Private Sub cmbType_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmbType.DoubleClick
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	Private Sub frmTypeList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim rs As datatable
		Dim i As Object

        rs = Manager.Session.GetRows("OBJECTTYPE", "*")
		Dim o As tmpInst
	    For i = 0 To rs.Rows.Count - 1
            o = New tmpInst
            o.Name = rs.Rows(i)("the_comment")
            o.ObjType = rs.Rows(i)("Name")
            o.IsSingle = rs.Rows(i)("IsSingleInstance")
            o.ID = rs.Rows(i)("objecttypeid")

            cmbType.Items.Add(o)
        Next


        rs = Nothing

        If cmbType.Items.Count > 0 Then
            cmbType.SelectedIndex = 0
        End If
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye
        If cmbType.SelectedIndex = -1 Then Exit Sub
        Dim ti As tmpInst
        ti = cmbType.Items(cmbType.SelectedIndex)
        TypeName_Renamed = ti.ObjType
        ID = ti.ID.ToString
		OK = True
		
		Me.Hide()
		
bye: 
	End Sub
End Class