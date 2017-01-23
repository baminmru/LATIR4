Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private Path As String
    'Private xdom As MSXML2.DOMDocument
    'Private e As MSXML2.IXMLDOMElement
	'UPGRADE_WARNING: Arrays in structure GenResp may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Private GenResp As LATIRGenerator.Response
    Private GenPrj As LATIRGenerator.ProjectHolder
	Private iListIndex As Integer
	Private bDontClear As Boolean
	Private DS As DataSource
	Private Log As String
	
	
	Dim n As String
	Dim cnt As Integer
	Dim i As Object
	Dim inClick As Boolean
	
	'UPGRADE_WARNING: Event chkIntegrated.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub chkIntegrated_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkIntegrated.CheckStateChanged
		If chkIntegrated.CheckState = System.Windows.Forms.CheckState.Checked Then
			txtLogin.Text = ""
			txtPassword.Text = ""
		End If
		
	End Sub
	
	'Private Sub cmdAddSite_Click()
	'  Dim frmNewName As New frmNewName
	'  Dim NewName As String
	'
	'  NewName = frmNewName.ShowModal
	'  Unload frmNewName
	'  Set frmNewName = Nothing
	'
	'  If (NewName = "") Then Exit Sub
	'  'n = InputBox("Введите имя:", "Добавление сайта")
	'  'If n = "" Then Exit Sub
	'
	'  lstSite.AddItem NewName
	'  Dim node As MSXML2.IXMLDOMNode
	'  Set node = xdom.createNode(MSXML2.NODE_ELEMENT, "SITE", "")
	'  If xdom.xml = "" Then
	'    xdom.loadXML "<root></root>"
	'  End If
	'  xdom.lastChild.appendChild node
	'  Set e = xdom.lastChild.lastChild
	'  e.setAttribute "Name", NewName
	'  cnt = xdom.lastChild.childNodes.length
	'  lstSite.ListIndex = lstSite.ListCount - 1
	'  bData = True
	'  changing
	'End Sub
	
	
	
	
	
	
	
	
	Private Sub cmdDataPath_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDataPath.Click
		Dim Path As String
		
		DlgOpen.Title = "Выберите файл с данными"
	
		DlgOpen.CheckFileExists = True
		DlgOpen.CheckPathExists = True
	
		DlgOpen.ShowReadOnly = False
		DlgOpen.DereferenceLinks = False

        DlgOpen.Filter = "XML файлы (*.xml)|*.xml"
		
		DlgOpen.FileName = ""
		
		DlgOpen.ShowDialog()
		
		If DlgOpen.FileName > "" Then
			txtData.Text = DlgOpen.FileName
		End If
		
		
	End Sub
	
    Private Sub execBlock(ByRef b As LATIRGenerator.BlockHolder, ByRef modulename As String)
        Dim s As String
        Dim lines() As String
        Dim i As Integer
        lines = Split(b.BlockCode, vbCrLf, , CompareMethod.Text)
        s = ""
        pb.Minimum = LBound(lines)
        pb.Maximum = UBound(lines)
        pb.Value = LBound(lines)
        pb.Visible = True
        For i = LBound(lines) To UBound(lines)
            pb.Value = i
            If UCase(Trim(lines(i))) = "GO" Then
                On Error GoTo err1
                If Trim(s) <> "" Then
                    DS.Execute(s)
                    System.Windows.Forms.Application.DoEvents()
                End If
                s = ""
                GoTo cont
err1:
                txtLog.Text = txtLog.Text & vbCrLf & b.BlockName & ":" & modulename & vbCrLf & s & vbCrLf & "------------------------" & vbCrLf & Err.Description
                Debug.Print(VB6.TabLayout(Err.Number, Err.Description))
                Resume err2
err2:
                s = ""
            Else
                s = s & vbCrLf & lines(i)
            End If
cont:
        Next
        pb.Visible = False


    End Sub



    Private Sub cmdGo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdGo.Click

        If txtData.Text = "" Then Exit Sub
        txtLog.Text = ""
        lstBlocks.Items.Clear()
        DS = New DataSource
        DS.Server = txtServer.Text
        DS.DataBaseName = "master"
        DS.UserName = txtLogin.Text
        DS.Password = txtPassword.Text
        DS.Integrated = (chkIntegrated.CheckState = System.Windows.Forms.CheckState.Checked)
        If Not DS.ServerLogIn Then
            MsgBox("Не удается подключиться к Microsoft SQL Server", MsgBoxStyle.Critical)
            'UPGRADE_NOTE: Object DS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            DS = Nothing
            Exit Sub
        End If

        GenResp = New LATIRGenerator.Response
        GenPrj = GenResp.Project
        GenPrj.Load(txtData.Text)

        On Error Resume Next

        DS.Execute("create database " & txtDatabase.Text & " COLLATE Cyrillic_General_CI_AS")

        If Not DS.Execute("use " & txtDatabase.Text) Then
            MsgBox("Не удается создать базу данных", MsgBoxStyle.Critical)
            'UPGRADE_NOTE: Object DS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            DS = Nothing
            'UPGRADE_NOTE: Object GenResp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            GenResp = Nothing
            'UPGRADE_NOTE: Object GenPrj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            GenPrj = Nothing
            Exit Sub
        End If


        Dim i, j As Integer
        For i = 1 To GenPrj.Modules.Count
            For j = 1 To GenPrj.Modules.Item(i).Blocks.Count
                lstBlocks.Items.Add(GenPrj.Modules.Item(i).ModuleName & ":" & GenPrj.Modules.Item(i).Blocks.Item(j).BlockName)
            Next
        Next
        Dim k As Integer
        k = 0
        For i = 1 To GenPrj.Modules.Count
            For j = 1 To GenPrj.Modules.Item(i).Blocks.Count
                'If lstBlocks.Selected(k) = True Then
                execBlock(GenPrj.Modules.Item(i).Blocks.Item(j), (GenPrj.Modules.Item(i).ModuleName))
                lstBlocks.SetItemChecked(k, True)
                k = k + 1
            Next
        Next
        If txtLog.Text = "" Then
            MsgBox("Создание базы данных завершено", MsgBoxStyle.Information)
        Else
            MsgBox("Создание базы данных завершено с ошибками", MsgBoxStyle.Critical)
        End If
        'UPGRADE_NOTE: Object DS may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        DS = Nothing
        'UPGRADE_NOTE: Object GenResp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        GenResp = Nothing
        'UPGRADE_NOTE: Object GenPrj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        GenPrj = Nothing
    End Sub
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		inClick = True
		
		txtServer.Text = ""
		txtDatabase.Text = ""
		txtLogin.Text = ""
		txtPassword.Text = ""
		Call DisableInvisibleControls()
		inClick = False
	End Sub
	
	
	'Private Sub SaveConfig()
	'  Dim root As Long
	'
	'  Path = txtConfig
	'  Set e = xdom.lastChild.childNodes.Item(1)
	'  With e
	'     .setAttribute "Server", txtServer
	'     .setAttribute "DB", txtDatabase
	'     .setAttribute "USER", txtLogin
	'     .setAttribute "PASSWORD", txtPassword
	'     .setAttribute "TIMEOUT", 100
	'     .setAttribute "PROVIDER", "sqloledb"
	'     .setAttribute "AT", "@"
	'     .setAttribute "INTEGRATED", (chkIntegrated.Value = vbChecked)
	'  End With
	'
	'  On Error GoTo errSave
	'  xdom.Save Path
	'  On Error GoTo errSettings
	'
	'  Call SaveSetting("MTZ", "CONFIG", "XMLPATH", txtConfig)
	'
	'  On Error GoTo 0
	'
	'  Exit Sub
	'errSave:
	'  Call MsgBox("Ошибка сохранения файла (" & Path & ")" & vbCrLf & Err.Number & ":" & Err.Description, vbOKOnly + vbExclamation, App.Title)
	'  Exit Sub
	'errSettings:
	'  Call MsgBox("Ошибка сохранения" & vbCrLf & Err.Number & ":" & Err.Description, vbOKOnly + vbExclamation, App.Title)
	'  Exit Sub
	'End Sub
	
	'Private Sub LoadConfig()
	'  txtConfig = GetSetting("MTZ", "CONFIG", "XMLPATH", App.Path & "\CFG\MTZ.XML")
	'  Path = txtConfig
	'  Set xdom = New MSXML2.DOMDocument
	'  xdom.async = False
	'  xdom.Load Path
	'  On Error Resume Next
	'  cnt = xdom.lastChild.childNodes.length
	'End Sub
	
	
	Private Function CheckFolder(ByRef Path As String) As Boolean
		Dim FSO As Object
		
		FSO = CreateObject("Scripting.FileSystemObject")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object FSO.FolderExists. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not FSO.FolderExists(Path) Then
			Call MsgBox("Указанный каталог не существует", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, My.Application.Info.Title)
			CheckFolder = False
		Else
			CheckFolder = True
		End If
		
		'UPGRADE_NOTE: Object FSO may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		FSO = Nothing
	End Function
	
	Private Function CheckFile(ByRef Path As String) As Boolean
		Dim FSO As Object
		
		FSO = CreateObject("Scripting.FileSystemObject")
		
		'UPGRADE_WARNING: Couldn't resolve default property of object FSO.FileExists. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not FSO.FileExists(Path) Then
			Call MsgBox("Указанный файл не существует", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, My.Application.Info.Title)
			CheckFile = False
		Else
			CheckFile = True
		End If
		
		'UPGRADE_NOTE: Object FSO may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		FSO = Nothing
	End Function
	
	
	
	
	Private Sub cmdCancel_Click()
		Me.Close()
		End
	End Sub
	
	Private Sub cmdOK_Click()
		Me.Close()
		End
	End Sub
	
	
	Private Sub DisableInvisibleControls()
		Dim i As Integer
		Dim RealLeft As Integer
		Dim RealTop As Integer
		Dim ContainerControl As Object
		Dim CurrentControl As Object
		Dim TypeNameContainer As String
		
		'UPGRADE_WARNING: Controls method Controls.Count has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		For i = 1 To Me.Controls.Count()
			On Error Resume Next
			' Определим реальные координаты относительно высоту и лево
			CurrentControl = CType(Me.Controls(i), Object)
			'UPGRADE_WARNING: Couldn't resolve default property of object CurrentControl.Left. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RealLeft = CurrentControl.Left
			'UPGRADE_WARNING: Couldn't resolve default property of object CurrentControl.Top. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RealTop = CurrentControl.Top
			'UPGRADE_WARNING: Couldn't resolve default property of object CurrentControl.Container. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ContainerControl = CurrentControl.Container
			'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			TypeNameContainer = UCase(TypeName(ContainerControl))
			If (TypeNameContainer <> "NOTHING") Then
				'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				While TypeNameContainer <> UCase(TypeName(Me)) And (RealLeft >= 0 And RealTop >= 0)
					'UPGRADE_WARNING: Couldn't resolve default property of object ContainerControl.Left. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RealLeft = RealLeft + ContainerControl.Left
					'UPGRADE_WARNING: Couldn't resolve default property of object ContainerControl.Top. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RealTop = RealTop + ContainerControl.Top
					'UPGRADE_WARNING: Couldn't resolve default property of object ContainerControl.Container. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ContainerControl = ContainerControl.Container
					'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					TypeNameContainer = UCase(TypeName(ContainerControl))
					'UPGRADE_WARNING: Couldn't resolve default property of object ContainerControl.Container. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If (ContainerControl Is ContainerControl.Container) Then
						GoTo Wexit
					End If
				End While
Wexit: 
				If (RealLeft < 0) Or (RealTop < 0) Then
					'UPGRADE_WARNING: Couldn't resolve default property of object CurrentControl.TabStop. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrentControl.TabStop = False
				Else
					'UPGRADE_WARNING: Couldn't resolve default property of object CurrentControl.TabStop. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					CurrentControl.TabStop = True
				End If
			End If
		Next 
	End Sub
End Class