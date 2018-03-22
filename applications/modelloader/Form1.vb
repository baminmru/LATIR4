Option Strict Off
Option Explicit On
Imports System.IO
Friend Class Form1
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents buttonOpenFolder As System.Windows.Forms.Button
    Friend WithEvents textBoxOutPutFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialogFolderXML As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents CheckBoxDeleteFiles As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtDLLPath As TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.buttonOpenFolder = New System.Windows.Forms.Button()
        Me.textBoxOutPutFolder = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialogFolderXML = New System.Windows.Forms.FolderBrowserDialog()
        Me.CheckBoxDeleteFiles = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDLLPath = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'cmdLoad
        '
        Me.cmdLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLoad.Location = New System.Drawing.Point(16, 215)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLoad.Size = New System.Drawing.Size(490, 41)
        Me.cmdLoad.TabIndex = 0
        Me.cmdLoad.Text = "Load data from XML"
        Me.cmdLoad.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(489, 31)
        Me.Label1.TabIndex = 1
        '
        'buttonOpenFolder
        '
        Me.buttonOpenFolder.Location = New System.Drawing.Point(474, 15)
        Me.buttonOpenFolder.Name = "buttonOpenFolder"
        Me.buttonOpenFolder.Size = New System.Drawing.Size(31, 27)
        Me.buttonOpenFolder.TabIndex = 56
        Me.buttonOpenFolder.Text = "..."
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(89, 17)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(379, 23)
        Me.textBoxOutPutFolder.TabIndex = 55
        Me.textBoxOutPutFolder.Text = "C:\"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "XML Folder:"
        '
        'CheckBoxDeleteFiles
        '
        Me.CheckBoxDeleteFiles.AutoSize = True
        Me.CheckBoxDeleteFiles.Location = New System.Drawing.Point(17, 123)
        Me.CheckBoxDeleteFiles.Name = "CheckBoxDeleteFiles"
        Me.CheckBoxDeleteFiles.Size = New System.Drawing.Size(164, 20)
        Me.CheckBoxDeleteFiles.TabIndex = 57
        Me.CheckBoxDeleteFiles.Text = "Delete files after load"
        Me.CheckBoxDeleteFiles.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "DLL Path"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(474, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 27)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "..."
        '
        'txtDLLPath
        '
        Me.txtDLLPath.Location = New System.Drawing.Point(89, 64)
        Me.txtDLLPath.Name = "txtDLLPath"
        Me.txtDLLPath.Size = New System.Drawing.Size(379, 23)
        Me.txtDLLPath.TabIndex = 59
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(543, 324)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDLLPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBoxDeleteFiles)
        Me.Controls.Add(Me.buttonOpenFolder)
        Me.Controls.Add(Me.textBoxOutPutFolder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "LATIR XML Data loader"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Dim guiman As LATIR2GuiManager.LATIRGuiManager
    Dim m As LATIR2.Manager
    Dim s As LATIR2.Session
    Dim o As Object 'System.Application
    Dim u As Object 'UserSecurity.Application
    Dim rs As DataTable
    Dim site As String

    Private Sub LoadObjects(ByVal pathFolder As String)
        On Error Resume Next
        Dim xdom As System.Xml.XmlDocument

        Dim path As String

        Dim drs As LATIR2.Document.Doc_Base

        Dim typename As String, id As System.Guid, name As String
        m.DLLPath = txtDLLPath.Text

        path = Dir(pathFolder & "\*.xml")
        While path <> ""
            xdom = New System.Xml.XmlDocument
            xdom.Load(pathFolder & "\" & path)

            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)

            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            name = typename

            If typename.ToLower() = "mtzmetamodel" Then
                name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

                Label1.Text = "load " & typename & " " & id.ToString()
                System.Windows.Forms.Application.DoEvents()
                drs = m.GetInstanceObject(id)
                If drs Is Nothing Then
                    m.NewInstance(id, typename, name)
                End If
                drs = m.GetInstanceObject(id)
                If Not drs Is Nothing Then

                    drs.LockResource(True)

                    drs.AutoLoadPart = True

                    drs.XMLLoad(xdom.LastChild, 0)

                    drs.BatchUpdate()

                    drs.UnLockResource()
                End If
            End If

            xdom = Nothing
            path = Dir()
        End While


        path = Dir(pathFolder & "\*.xml")
        While path <> ""
            xdom = New System.Xml.XmlDocument
            xdom.Load(pathFolder & "\" & path)

            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)

            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            name = typename
            If typename.ToLower() <> "mtzmetamodel" Then
                name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

                Label1.Text = "load " & typename & " " & id.ToString()
                System.Windows.Forms.Application.DoEvents()
                drs = m.GetInstanceObject(id)
                If drs Is Nothing Then
                    m.NewInstance(id, typename, name)
                    drs = m.GetInstanceObject(id)
                End If

                If Not drs Is Nothing Then

                    drs.LockResource(True)

                    drs.AutoLoadPart = True

                    drs.XMLLoad(xdom.LastChild, 0)

                    drs.BatchUpdate()

                    drs.UnLockResource()
                End If
            End If
            xdom = Nothing
            path = Dir()
        End While
        Label1.Text = "done"
    End Sub

    Private Sub DeleteFiles(ByVal pathFolder As String)
        Dim filesInFolder() As String
        Try
            filesInFolder = Directory.GetFiles(pathFolder, "*.xml")
            Dim i As Integer
            For i = 0 To filesInFolder.Length - 1
                Try
                    File.Delete(filesInFolder(i))
                Catch
                End Try
            Next
        Catch
        End Try

    End Sub

    'Private Sub Command17_Click()
    '    rs = m.Session.GetRowsDT("INSTANCE", "", "", "ObjType='mtzmetamodel'")
    '    Dim drs As Object
    '    Dim id As Guid
    '    If rs.Rows.Count > 0 Then
    '        id = rs.Rows(0).Item("InstanceID").Value
    '    Else
    '        id = New Guid("{88DEEBA4-69B1-454A-992A-FAE3CEBFBCA1}")
    '        m.NewInstance(id, "MTZMetaModel", "MTZMetaModel")
    '    End If
    '    drs = m.GetInstanceObject(id)

    '    drs.LockResource(True)

    '    drs.AutoLoadPart = False

    '    drs.WorkOffline = True

    '    Dim xdom As System.XML.XmlDocument
    '    xdom = New System.XML.XmlDocument
    '    xdom.Load(VB6.GetPath & "\{88DEEBA4-69B1-454A-992A-FAE3CEBFBCA1}.xml")
    '    drs.XMLLoad(xdom.LastChild, 0)
    '    drs.WorkOffline = False
    '    drs.BatchUpdate()
    '    xdom = Nothing
    '    MsgBox("Model loaded")

    'End Sub

    Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        Try
            LoadObjects(textBoxOutPutFolder.Text)
            If CheckBoxDeleteFiles.Checked Then
                DeleteFiles(textBoxOutPutFolder.Text)
            End If
        Catch
        End Try
    End Sub

    Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim Params() As String
        Params = System.Environment.GetCommandLineArgs()            'System.Environment.GetCommandLineArgs()

        If Params.Length >= 2 Then
            If Params.Length >= 5 Then
                Dim userParam As String
                Dim passParam As String
                Dim siteParam As String
                Dim pathDirectoryParam As String
                Dim deleteParam As Boolean

                userParam = Params(1)
                passParam = Params(2)
                siteParam = Params(3)
                pathDirectoryParam = Params(4)

                If Directory.Exists(pathDirectoryParam) = False Then
                    End
                End If

                deleteParam = False

                If Params.Length = 6 Then
                    If Params(5) = "-d" Then
                        deleteParam = True
                    End If
                End If

                m = New LATIR2.Manager
                m.Site = siteParam
                s = m.Session
                If s.Login(userParam, passParam) Then
                    LoadObjects(pathDirectoryParam)
                    If deleteParam = True Then
                        DeleteFiles(pathDirectoryParam)
                    End If
                End If
                End
            Else
                MsgBox("Usage: " & Application.ExecutablePath & " [user password latir_site_name full_folder_path [-d]]" & vbCrLf & "-d for delete xml file from folder", MsgBoxStyle.OkOnly, "Model loader command line arguments")
                End
            End If
        Else
            guiman = New LATIR2GuiManager.LATIRGuiManager

            Dim username As String = My.Settings.LOGIN_USERNAME
            Dim sitename As String = My.Settings.LOGIN_SITENAME

            If Not guiman.Login(username, sitename) Then End

            m = guiman.Manager

            s = m.Session

            txtDLLPath.Text = GetSetting("LATIR4", "LOADERCFG", "DLLPATH", "")
            textBoxOutPutFolder.Text = GetSetting("LATIR4", "LOADERCFG", "DATAPATH", "")

            My.Settings.LOGIN_USERNAME = username
            My.Settings.LOGIN_SITENAME = sitename
            My.Settings.Save()
        End If
    End Sub

    Private Sub Form1_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        Timer1.Enabled = False
        m.Session.Logout()

        m = Nothing
    End Sub

    Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next : m.Session.Exec("SessionTouch", Nothing)
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonOpenFolder.Click
        FolderBrowserDialogFolderXML.SelectedPath = textBoxOutPutFolder.Text
        If FolderBrowserDialogFolderXML.ShowDialog() = DialogResult.OK Then
            textBoxOutPutFolder.Text = FolderBrowserDialogFolderXML.SelectedPath
            SaveSetting("LATIR4", "LOADERCFG", "DATAPATH", textBoxOutPutFolder.Text)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialogFolderXML.SelectedPath = txtDLLPath.Text
        If FolderBrowserDialogFolderXML.ShowDialog() = DialogResult.OK Then
            txtDLLPath.Text = FolderBrowserDialogFolderXML.SelectedPath
            SaveSetting("LATIR4", "LOADERCFG", "DLLPATH", txtDLLPath.Text)
        End If
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub
End Class