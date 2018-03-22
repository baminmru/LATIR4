Option Strict Off
Option Explicit On
Friend Class frmSaveMTD
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
	
	
	
	
	Private Sub cmbType_DblClick()
		OKButton_Click(OKButton, New System.EventArgs())
	End Sub
	
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye
		
		SaveMTDTypeXML()
		
		MsgBox("Сохранение завершено",  , "Сохранение описания типов полей")
		
bye: 
	End Sub
	
	Private Sub SaveMTDTypeXML()
		On Error Resume Next
		
		Dim fn As String
        Dim xdom As System.Xml.XmlDocument


        On Error GoTo bye

        fn = txtPath.Text & "SHAREDMETHOD.xml"

        xdom = New System.Xml.XmlDocument
        xdom.LoadXml("<root><APPLICATION></APPLICATION></root>")

        
        model.SHAREDMETHOD.XMLSave(xdom.LastChild.FirstChild, xdom)
        xdom.Save(fn)


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