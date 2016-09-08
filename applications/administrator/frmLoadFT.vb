Option Strict Off
Option Explicit On
Friend Class frmLoadFT
	Inherits System.Windows.Forms.Form
	'UPGRADE_NOTE: TypeName was upgraded to TypeName_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public TypeName_Renamed As String
	'UPGRADE_NOTE: site was upgraded to site_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public site_Renamed As String
	
	Public OK As Boolean
	Private ID As String

	Private types As Collection
	
	
	
	Private Sub CancelButton_Click()
		OK = False
		'UPGRADE_NOTE: Object types may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		types = Nothing
		Me.Hide()
	End Sub
	
	
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		On Error GoTo bye
        Dim xdom As System.Xml.XmlDocument
        xdom = New System.Xml.XmlDocument
        xdom.Load(txtPath.Text)
        Dim e_list As System.Xml.XmlNodeList
		
		e_list = xdom.lastChild.firstChild.selectNodes("FIELDTYPE_COL")
		model.FIELDTYPE.XMLLoad(e_list, 0)
		model.BatchUpdate()
		

		xdom = Nothing
		MsgBox("Загрузка завершена",  , "Загрузка описания типа")
		Exit Sub
		
bye: 
		MsgBox("Ошибка загрузки" & vbCrLf & Err.Description,  , "Загрузка описания типа")
	End Sub
	
	Private Sub cmdPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPath.Click
		On Error Resume Next
		
		On Error GoTo bye
		Dim fn As String
		
		cdlgOpen.Filter = "Документ XML |*.XML"
		cdlgOpen.DefaultExt = "XML"
		
		cdlgOpen.ShowReadOnly = False

		cdlgOpen.CheckFileExists = True
		cdlgOpen.CheckPathExists = True
		cdlgOpen.ShowDialog()
		txtPath.Text = cdlgOpen.FileName
		
		
bye: 
	End Sub
End Class