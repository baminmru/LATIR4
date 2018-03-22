Option Strict Off
Option Explicit On
Friend Class frmLoadDesc
	Inherits System.Windows.Forms.Form

	Public TypeName_Renamed As String

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
        Dim item As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim xdom As System.Xml.XmlDocument
        Dim ID As String
        Dim package As String
        Dim packageName As String = ""
        xdom = New System.Xml.XmlDocument
        xdom.Load(txtPath.Text)

        package = xdom.LastChild.Attributes.GetNamedItem("Package").Value
        packageName = "Package for " + xdom.LastChild.Attributes.GetNamedItem("Name").Value

        ' add package name if not exists
        If model.MTZAPP.item(package) Is Nothing Then
            With CType(model.MTZAPP.Add(package), MTZMetaModel.MTZMetaModel.MTZAPP)
                .Name = packageName
                .Save()
            End With
        End If
		
		'UPGRADE_WARNING: Couldn't resolve default property of object xdom.lastChild.Attributes.getNamedItem().nodeValue. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ID = xdom.LastChild.Attributes.GetNamedItem("ID").Value
		If model.ObjectType.item(ID) Is Nothing Then
			model.ObjectType.Add(ID)
		End If
		item = model.ObjectType.item(ID)
		item.XMLLoad(xdom.lastChild, 1)
		item.BatchUpdate()
		'UPGRADE_NOTE: Object xdom may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
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
		txtpath.Text = cdlgOpen.FileName
		
		
bye: 
	End Sub
End Class