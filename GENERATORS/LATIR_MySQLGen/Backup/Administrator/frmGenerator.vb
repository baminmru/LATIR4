Imports System.Collections
Imports System.Threading
Imports System.IO
Imports System.Runtime

Public Class frmGenerator
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdClearLog As System.Windows.Forms.Button
    Public WithEvents cmdFindErr As System.Windows.Forms.Button
    Public WithEvents cmdGen As System.Windows.Forms.Button
    Public WithEvents txtLog As System.Windows.Forms.RichTextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents ButtonGenSetup As System.Windows.Forms.Button
    Friend WithEvents ButtonDevEnv As System.Windows.Forms.Button
    Friend WithEvents TextBoxDevEnv As System.Windows.Forms.TextBox
    Friend WithEvents LabelDevEnv As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCompile As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonOutDlls As System.Windows.Forms.Button
    Friend WithEvents TextBoxOutDlls As System.Windows.Forms.TextBox
    Friend WithEvents LabelOutDlls As System.Windows.Forms.Label
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents textBoxOutPutFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents progressBar As System.Windows.Forms.ProgressBar
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTypes As System.Windows.Forms.CheckedListBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents cmdUnSelectAll As System.Windows.Forms.Button
    Public WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents chkGenerators As System.Windows.Forms.CheckedListBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmdNormNames As System.Windows.Forms.Button
    Public WithEvents cmdCheckModel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialogDevenv As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents FolderBrowserDialogDllOutput As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents folderBrowserDialogProjectOutput As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerator))
        Me.folderBrowserDialogProjectOutput = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClearLog = New System.Windows.Forms.Button
        Me.cmdFindErr = New System.Windows.Forms.Button
        Me.cmdGen = New System.Windows.Forms.Button
        Me.txtLog = New System.Windows.Forms.RichTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ButtonGenSetup = New System.Windows.Forms.Button
        Me.ButtonDevEnv = New System.Windows.Forms.Button
        Me.TextBoxDevEnv = New System.Windows.Forms.TextBox
        Me.LabelDevEnv = New System.Windows.Forms.Label
        Me.CheckBoxCompile = New System.Windows.Forms.CheckBox
        Me.ButtonOutDlls = New System.Windows.Forms.Button
        Me.TextBoxOutDlls = New System.Windows.Forms.TextBox
        Me.LabelOutDlls = New System.Windows.Forms.Label
        Me.button3 = New System.Windows.Forms.Button
        Me.textBoxOutPutFolder = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.progressBar = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkTypes = New System.Windows.Forms.CheckedListBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdUnSelectAll = New System.Windows.Forms.Button
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.chkGenerators = New System.Windows.Forms.CheckedListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdNormNames = New System.Windows.Forms.Button
        Me.cmdCheckModel = New System.Windows.Forms.Button
        Me.FolderBrowserDialogDevenv = New System.Windows.Forms.FolderBrowserDialog
        Me.FolderBrowserDialogDllOutput = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'folderBrowserDialogProjectOutput
        '
        Me.folderBrowserDialogProjectOutput.SelectedPath = "C:\LATIR2\Generated\"
        '
        'cmdClearLog
        '
        Me.cmdClearLog.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClearLog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearLog.Location = New System.Drawing.Point(497, 426)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClearLog.Size = New System.Drawing.Size(145, 21)
        Me.cmdClearLog.TabIndex = 66
        Me.cmdClearLog.Text = "Очистить журнал"
        Me.cmdClearLog.UseVisualStyleBackColor = False
        '
        'cmdFindErr
        '
        Me.cmdFindErr.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFindErr.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFindErr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFindErr.Location = New System.Drawing.Point(347, 426)
        Me.cmdFindErr.Name = "cmdFindErr"
        Me.cmdFindErr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFindErr.Size = New System.Drawing.Size(145, 21)
        Me.cmdFindErr.TabIndex = 65
        Me.cmdFindErr.Text = "Следующая ошибка"
        Me.cmdFindErr.UseVisualStyleBackColor = False
        '
        'cmdGen
        '
        Me.cmdGen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGen.Location = New System.Drawing.Point(569, 5)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGen.Size = New System.Drawing.Size(73, 21)
        Me.cmdGen.TabIndex = 64
        Me.cmdGen.Text = "Генерация"
        Me.cmdGen.UseVisualStyleBackColor = False
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtLog.Location = New System.Drawing.Point(3, 453)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(639, 97)
        Me.txtLog.TabIndex = 63
        Me.txtLog.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(5, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Журнал"
        '
        'ButtonGenSetup
        '
        Me.ButtonGenSetup.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonGenSetup.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonGenSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonGenSetup.Location = New System.Drawing.Point(138, 263)
        Me.ButtonGenSetup.Name = "ButtonGenSetup"
        Me.ButtonGenSetup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonGenSetup.Size = New System.Drawing.Size(153, 21)
        Me.ButtonGenSetup.TabIndex = 61
        Me.ButtonGenSetup.Text = "Настройка генератора"
        Me.ButtonGenSetup.UseVisualStyleBackColor = False
        '
        'ButtonDevEnv
        '
        Me.ButtonDevEnv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDevEnv.Location = New System.Drawing.Point(616, 373)
        Me.ButtonDevEnv.Name = "ButtonDevEnv"
        Me.ButtonDevEnv.Size = New System.Drawing.Size(26, 22)
        Me.ButtonDevEnv.TabIndex = 57
        Me.ButtonDevEnv.Text = "..."
        '
        'TextBoxDevEnv
        '
        Me.TextBoxDevEnv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDevEnv.Location = New System.Drawing.Point(134, 373)
        Me.TextBoxDevEnv.Name = "TextBoxDevEnv"
        Me.TextBoxDevEnv.Size = New System.Drawing.Size(469, 20)
        Me.TextBoxDevEnv.TabIndex = 56
        Me.TextBoxDevEnv.Text = "C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\"
        '
        'LabelDevEnv
        '
        Me.LabelDevEnv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelDevEnv.AutoSize = True
        Me.LabelDevEnv.Location = New System.Drawing.Point(12, 376)
        Me.LabelDevEnv.Name = "LabelDevEnv"
        Me.LabelDevEnv.Size = New System.Drawing.Size(89, 13)
        Me.LabelDevEnv.TabIndex = 55
        Me.LabelDevEnv.Text = "Devenv.exe path"
        '
        'CheckBoxCompile
        '
        Me.CheckBoxCompile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxCompile.AutoSize = True
        Me.CheckBoxCompile.Checked = True
        Me.CheckBoxCompile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCompile.Location = New System.Drawing.Point(16, 356)
        Me.CheckBoxCompile.Name = "CheckBoxCompile"
        Me.CheckBoxCompile.Size = New System.Drawing.Size(63, 17)
        Me.CheckBoxCompile.TabIndex = 54
        Me.CheckBoxCompile.Text = "Compile"
        Me.CheckBoxCompile.UseVisualStyleBackColor = True
        '
        'ButtonOutDlls
        '
        Me.ButtonOutDlls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOutDlls.Location = New System.Drawing.Point(616, 396)
        Me.ButtonOutDlls.Name = "ButtonOutDlls"
        Me.ButtonOutDlls.Size = New System.Drawing.Size(26, 22)
        Me.ButtonOutDlls.TabIndex = 60
        Me.ButtonOutDlls.Text = "..."
        '
        'TextBoxOutDlls
        '
        Me.TextBoxOutDlls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxOutDlls.Location = New System.Drawing.Point(134, 396)
        Me.TextBoxOutDlls.Name = "TextBoxOutDlls"
        Me.TextBoxOutDlls.Size = New System.Drawing.Size(469, 20)
        Me.TextBoxOutDlls.TabIndex = 59
        Me.TextBoxOutDlls.Text = "C:\LATIR2\Generated\Generated Dlls"
        '
        'LabelOutDlls
        '
        Me.LabelOutDlls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelOutDlls.AutoSize = True
        Me.LabelOutDlls.Location = New System.Drawing.Point(14, 401)
        Me.LabelOutDlls.Name = "LabelOutDlls"
        Me.LabelOutDlls.Size = New System.Drawing.Size(91, 13)
        Me.LabelOutDlls.TabIndex = 58
        Me.LabelOutDlls.Text = "Dlls Output Folder"
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(616, 332)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(26, 22)
        Me.button3.TabIndex = 53
        Me.button3.Text = "..."
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(134, 332)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(469, 20)
        Me.textBoxOutPutFolder.TabIndex = 52
        Me.textBoxOutPutFolder.Text = "C:\LATIR2\Generated\"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 337)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Projects Output Folder:"
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(12, 302)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(630, 17)
        Me.progressBar.TabIndex = 49
        Me.progressBar.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(12, 286)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(113, 17)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Процесс генерации"
        Me.Label1.Visible = False
        '
        'chkTypes
        '
        Me.chkTypes.CheckOnClick = True
        Me.chkTypes.FormattingEnabled = True
        Me.chkTypes.Location = New System.Drawing.Point(299, 43)
        Me.chkTypes.Name = "chkTypes"
        Me.chkTypes.Size = New System.Drawing.Size(343, 214)
        Me.chkTypes.Sorted = True
        Me.chkTypes.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(296, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(101, 17)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Типы документов"
        '
        'cmdUnSelectAll
        '
        Me.cmdUnSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnSelectAll.Location = New System.Drawing.Point(405, 263)
        Me.cmdUnSelectAll.Name = "cmdUnSelectAll"
        Me.cmdUnSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdUnSelectAll.TabIndex = 47
        Me.cmdUnSelectAll.Text = "Отменить все"
        Me.cmdUnSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectAll.Location = New System.Drawing.Point(299, 263)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.cmdSelectAll.TabIndex = 46
        Me.cmdSelectAll.Text = "Выбрать все"
        Me.cmdSelectAll.UseVisualStyleBackColor = False
        '
        'chkGenerators
        '
        Me.chkGenerators.CheckOnClick = True
        Me.chkGenerators.FormattingEnabled = True
        Me.chkGenerators.Location = New System.Drawing.Point(14, 43)
        Me.chkGenerators.Name = "chkGenerators"
        Me.chkGenerators.Size = New System.Drawing.Size(278, 214)
        Me.chkGenerators.Sorted = True
        Me.chkGenerators.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Генераторы"
        '
        'cmdNormNames
        '
        Me.cmdNormNames.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNormNames.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNormNames.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNormNames.Location = New System.Drawing.Point(126, 5)
        Me.cmdNormNames.Name = "cmdNormNames"
        Me.cmdNormNames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNormNames.Size = New System.Drawing.Size(113, 21)
        Me.cmdNormNames.TabIndex = 42
        Me.cmdNormNames.Text = "Испр. имена"
        Me.cmdNormNames.UseVisualStyleBackColor = False
        '
        'cmdCheckModel
        '
        Me.cmdCheckModel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCheckModel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCheckModel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCheckModel.Location = New System.Drawing.Point(14, 5)
        Me.cmdCheckModel.Name = "cmdCheckModel"
        Me.cmdCheckModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCheckModel.Size = New System.Drawing.Size(113, 21)
        Me.cmdCheckModel.TabIndex = 41
        Me.cmdCheckModel.Text = "Проверить модель"
        Me.cmdCheckModel.UseVisualStyleBackColor = False
        '
        'frmGenerator
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(644, 555)
        Me.Controls.Add(Me.cmdClearLog)
        Me.Controls.Add(Me.cmdFindErr)
        Me.Controls.Add(Me.cmdGen)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ButtonGenSetup)
        Me.Controls.Add(Me.ButtonDevEnv)
        Me.Controls.Add(Me.TextBoxDevEnv)
        Me.Controls.Add(Me.LabelDevEnv)
        Me.Controls.Add(Me.CheckBoxCompile)
        Me.Controls.Add(Me.ButtonOutDlls)
        Me.Controls.Add(Me.TextBoxOutDlls)
        Me.Controls.Add(Me.LabelOutDlls)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.textBoxOutPutFolder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.progressBar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkTypes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdUnSelectAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.chkGenerators)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdNormNames)
        Me.Controls.Add(Me.cmdCheckModel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(650, 580)
        Me.Name = "frmGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate sources"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Enum GeneratorType
        GeneratorTypeDll = 0
        GeneratorTypeWinForm = 1
        GeneratorTypeMSSQL = 2
    End Enum

    Private objectTypes As Hashtable
    Private generators As Hashtable
    Private allSteps As Int16
    Private currentStep As Int16
    Private model As MTZMetaModel.MTZMetaModel.Application

    Private Const VBMODELFOLDERNAME As String = "\VB.NET Model\"
    Private Const VBINTERFACEFOLDERNAME As String = "\VB.NET Interface\"
    Private Const VBSQLFOLDERNAME As String = "\Microsoft SQL Scripts\"

    Private Sub frmGenerator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As System.Data.DataTable
        Dim oID As System.Guid
        Dim i As Long
        dt = Manager.Session.GetRowsExDT("INSTANCE", "", "", "OBJTYPE='MTZMetaModel'", "")

        objectTypes = New Hashtable
        generators = New Hashtable
        oID = dt.Rows(0)("INSTANCEID")
        model = CType(Manager.GetInstanceObject(oID), MTZMetaModel.MTZMetaModel.Application)
        For i = 1 To model.OBJECTTYPE.Count
            objectTypes.Add(model.OBJECTTYPE.Item(i).Name, model.OBJECTTYPE.Item(i))
            chkTypes.Items.Add(model.OBJECTTYPE.Item(i).Name, False)
        Next

        generators.Add("NET dll", GeneratorType.GeneratorTypeDll)

        chkGenerators.Items.Add("NET dll", False)
        generators.Add("NET Win forms", GeneratorType.GeneratorTypeWinForm)
        chkGenerators.Items.Add("NET Win forms", False)
        generators.Add("Microsoft SQL Server", GeneratorType.GeneratorTypeMSSQL)
        chkGenerators.Items.Add("Microsoft SQL Server", False)

        If (Not String.IsNullOrEmpty(My.Settings.GEN_PROJECT_OUTPUT)) Then
            textBoxOutPutFolder.Text = My.Settings.GEN_PROJECT_OUTPUT
        End If
        If (Not String.IsNullOrEmpty(My.Settings.GEN_DLLSOUTPUT)) Then
            TextBoxOutDlls.Text = My.Settings.GEN_DLLSOUTPUT
        End If
        If (Not String.IsNullOrEmpty(My.Settings.GEN_DENENVFOLDER)) Then
            TextBoxDevEnv.Text = My.Settings.GEN_DENENVFOLDER
        End If
    End Sub

    Private Sub generateMSSQL()
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        targetID = New System.Guid("{0C652C58-A952-4E8F-8CB0-D266431CD24B}")
        Dim generator As LATIR_MSSQLGen.Generator = New LATIR_MSSQLGen.Generator()
        ' generator.Setup()

        WriteToLog(Environment.NewLine + "MSSQL generator started")
        Dim response As LATIRGenerator.Response
        response = New LATIRGenerator.Response()
        generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
        'Dim XmlFileName As String
        'prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        'Dim curDate As DateTime = DateTime.Now
        'XmlFileName = xmlBasePath + curDate.ToString().Replace(".", "-").Replace(":", "-") + ".xml"
        'response.Save(XmlFileName)
        prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        response.Save(projBasePath + VBSQLFOLDERNAME + "\all.xml")
        ReplaceInFile(projBasePath + VBSQLFOLDERNAME + "\all.xml", "&#xD;&#xA;", vbCrLf)
        'ReplaceInFile(projBasePath + VBSQLFOLDERNAME + "\all.xml", "&lt;", "<")
        'ReplaceInFile(projBasePath + VBSQLFOLDERNAME + "\all.xml", "&gt;", ">")

        'Convertors.MakeProjectBlocks(XmlFileName, projBasePath + VBSQLFOLDERNAME + "\" + "allNET2.xml")
        'File.Delete(XmlFileName)
        WriteToLog(Environment.NewLine + "MSSQL generator stopped")
        If (progressBar.Maximum > progressBar.Value + 1) Then
            progressBar.Value = progressBar.Value + 1
        End If
    End Sub

    Private Sub ReplaceInFile(ByVal FileName As String, ByVal Mask As String, ByVal Repl As String)
        Dim fs As FileStream = File.Open(FileName, FileMode.Open, FileAccess.Read)
        Dim sr As StreamReader = New StreamReader(fs)
        Dim filecontent As String = sr.ReadToEnd()
        filecontent = filecontent.Replace(Mask, Repl)
        sr.Close()
        fs.Close()
        File.Delete(FileName)
        fs = File.Open(FileName, FileMode.Create, FileAccess.Write)
        Dim sw As StreamWriter = New StreamWriter(fs)
        sw.Write(filecontent)
        sw.Close()
        fs.Close()
    End Sub

    Private Function generateDlls() As Boolean
        If chkTypes.CheckedIndices.Count = 0 Then
            Return False
        End If
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        targetID = New System.Guid("{AB7F302D-A483-4BB3-9CE8-016206458C47}")
        Dim generator As LATIR_VBModel.Generator
        generator = New LATIR_VBModel.Generator()
        While (String.IsNullOrEmpty(generator.LATIRManagerPath) Or Not File.Exists(generator.LATIRManagerPath))
            If (Not generator.Setup()) Then
                Return False
            End If
            If (String.IsNullOrEmpty(generator.LATIRManagerPath)) Then
                MessageBox.Show("Path to Object manager is't set", "Generator settings", MessageBoxButtons.OK)
            End If
            If (Not File.Exists(generator.LATIRManagerPath)) Then
                MessageBox.Show("Can't find Object manager dll", "Generator settings", MessageBoxButtons.OK)
            End If
        End While


        WriteToLog(Environment.NewLine + "Model generator started")
        Dim response As LATIRGenerator.Response
        Dim j As Long
        Dim TypeID As String
        Dim ObjType As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        For j = 0 To chkTypes.CheckedItems.Count - 1
            ObjType = objectTypes.Item(chkTypes.CheckedItems().Item(j))
            TypeID = ObjType.ID.ToString()

            response = New LATIRGenerator.Response()

            generator.Run(CType(model, Object), CType(response, Object), targetID.ToString, TypeID)
            Dim XmlFileName As String
            XmlFileName = xmlBasePath + ObjType.Name + ".xml"
            response.Save(XmlFileName)
            Dim _prjPath As String
            Dim pack As MTZMetaModel.MTZMetaModel.MTZAPP
            pack = ObjType.Package
            WriteToLog(Environment.NewLine + "Process " + ObjType.Name)
            prepareFolder(projBasePath + pack.Name, False)
            prepareFolder(projBasePath + pack.Name + VBMODELFOLDERNAME, False)
            _prjPath = projBasePath + pack.Name + VBMODELFOLDERNAME + ObjType.Name
            prepareFolder(_prjPath)

            'prepareFolder(_prjPath + "\bin")
            'Dim LatirName As String
            'LatirName = generator.LATIRManagerPath.Substring(generator.LATIRManagerPath.LastIndexOf("\") + 1)
            'If (File.Exists(+"\bin\" + LatirName)) Then
            '    File.Delete(_prjPath + "\bin\" + LatirName)
            'End If
            'File.Copy(generator.LATIRManagerPath, _prjPath + "\bin\" + LatirName, True)

            Convertors.MakeProjectBlocks(XmlFileName, _prjPath)

            File.Delete(XmlFileName)
            ' Compile it 
            If (CheckBoxCompile.Checked) Then
                Dim projectName As String
                projectName = _prjPath + ObjType.Name + ".vbproj"
                Dim devPath As String = TextBoxDevEnv.Text
                If (Not devPath.EndsWith("\")) Then
                    devPath = devPath + "\"
                End If
                devPath = devPath + "devenv.exe"
                LATIRFramework.VBCompilerHelper.CompileProject(devPath, projectName, True)
                'Dim DllName As String
                'DllName = _prjPath + "\bin\" + ObjType.Name + ".dll"
                'If (File.Exists(DllName)) Then
                '    Dim DestinationDllPath As String
                '    DestinationDllPath = TextBoxOutDlls.Text
                '    If (Not DestinationDllPath.EndsWith("\")) Then
                '        DestinationDllPath = DestinationDllPath + "\"
                '    End If
                '    DestinationDllPath = DestinationDllPath + ObjType.Name + ".dll"
                '    Try
                '        File.Copy(DllName, DestinationDllPath, True)
                '        WriteToLog(Environment.NewLine + ObjType.Name + " compiled and copied")
                '    Catch ex As Exception
                '        WriteToLog(Environment.NewLine + ObjType.Name + " - COPY dll ERROR")
                '    End Try
                'Else
                '    WriteToLog(Environment.NewLine + ObjType.Name + " - COMPILATION ERROR")
                'End If
            End If
            WriteToLog(Environment.NewLine + ObjType.Name + " created")
            If (progressBar.Maximum > progressBar.Value + 1) Then
                progressBar.Value = progressBar.Value + 1
            End If
        Next
        WriteToLog(Environment.NewLine + "Model generator stopped")
        Return True
    End Function

    Private Sub generateWinControls()
        If chkTypes.CheckedIndices.Count = 0 Then
            Return
        End If
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        '        targetID = New System.Guid("{8AC43DA3-1592-4634-9A96-02114F484FCB}")
        targetID = New System.Guid("{447D831E-2F59-4755-B0AB-5CB12CCF4B0A}")
        Dim generator As LATIR_WINNET2.Generator
        generator = New LATIR_WINNET2.Generator()
        ' generator.Setup()
        While (String.IsNullOrEmpty(generator.LATIRManagerPath) Or String.IsNullOrEmpty(generator.GUIControlPath) Or _
             String.IsNullOrEmpty(generator.GUIManagerPath))
            generator.Setup()

        End While
        WriteToLog(Environment.NewLine + "Win form generator started")
        Dim response As LATIRGenerator.Response
        Dim j As Long
        Dim TypeID As String
        Dim ObjType As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        For j = 0 To chkTypes.CheckedItems.Count - 1
            ObjType = objectTypes.Item(chkTypes.CheckedItems().Item(j))
            TypeID = ObjType.ID.ToString()
            response = New LATIRGenerator.Response()

            generator.Run(CType(model, Object), CType(response, Object), targetID.ToString, TypeID)
            Dim XmlFileName As String
            XmlFileName = xmlBasePath + ObjType.Name + ".xml"
            response.Save(XmlFileName)
            Dim _prjPath As String
            Dim pack As MTZMetaModel.MTZMetaModel.MTZAPP
            pack = ObjType.Package
            WriteToLog(Environment.NewLine + "Process " + ObjType.Name)
            prepareFolder(projBasePath + pack.Name, False)
            prepareFolder(projBasePath + pack.Name + VBINTERFACEFOLDERNAME, False)
            _prjPath = projBasePath + pack.Name + VBINTERFACEFOLDERNAME + ObjType.Name
            prepareFolder(_prjPath)
            'prepareFolder(_prjPath + "\bin")
            'Dim LatirName As String
            'LatirName = generator.LATIRManagerPath.Substring(generator.LATIRManagerPath.LastIndexOf("\") + 1)
            'If (File.Exists(_prjPath + "\bin\" + LatirName)) Then
            '    File.Delete(_prjPath + "\bin\" + LatirName)
            'End If
            'File.Copy(generator.LATIRManagerPath, _prjPath + "\bin\" + LatirName, True)
            'Dim GUIManagerName As String
            'GUIManagerName = generator.GUIManagerPath.Substring(generator.GUIManagerPath.LastIndexOf("\") + 1)
            'If (File.Exists(_prjPath + "\bin\" + GUIManagerName)) Then
            '    File.Delete(_prjPath + "\bin\" + GUIManagerName)
            'End If
            'File.Copy(generator.GUIManagerPath, _prjPath + "\bin\" + GUIManagerName, True)
            'Dim GUIControlName As String
            'GUIControlName = generator.GUIControlPath.Substring(generator.GUIControlPath.LastIndexOf("\") + 1)
            'If (File.Exists(_prjPath + "\bin\" + GUIControlName)) Then
            '    File.Delete(_prjPath + "\bin\" + GUIControlName)
            'End If
            'Dim CtlPath As String = generator.GUIControlPath
            'File.Copy(CtlPath, _prjPath + "\bin\" + GUIControlName, True)
            'Dim DLLName As String
            'DLLName = generator.DLLPath
            'If (Not DLLName.EndsWith("\")) Then
            '    DLLName = DLLName + "\"
            'End If
            'DLLName = DLLName + ObjType.Name + ".dll"
            'If (File.Exists(_prjPath + "\bin\" + ObjType.Name + ".dll")) Then
            '    File.Delete(_prjPath + "\bin\" + ObjType.Name + ".dll")
            'End If
            'File.Copy(DLLName, _prjPath + "\bin\" + ObjType.Name + ".dll", True)
            Convertors.MakeProjectBlocks(XmlFileName, _prjPath)
            File.Delete(XmlFileName)

            If (CheckBoxCompile.Checked) Then
                Dim projectName As String
                projectName = _prjPath + ObjType.Name + "GUI.vbproj"
                Dim devPath As String = TextBoxDevEnv.Text
                If (Not devPath.EndsWith("\")) Then
                    devPath = devPath + "\"
                End If
                devPath = devPath + "devenv.exe"
                LATIRFramework.VBCompilerHelper.CompileProject(devPath, projectName, True)
                'Dim GeneratedDllName As String = String.Empty
                'GeneratedDllName = _prjPath + "\bin\" + ObjType.Name + "GUI.dll"
                'If (File.Exists(GeneratedDllName)) Then
                '    Dim DestinationDllPath As String
                '    DestinationDllPath = TextBoxOutDlls.Text
                '    If (Not DestinationDllPath.EndsWith("\")) Then
                '        DestinationDllPath = DestinationDllPath + "\"
                '    End If
                '    DestinationDllPath = DestinationDllPath + ObjType.Name + "GUI.dll"
                '    Try
                '        File.Copy(GeneratedDllName, DestinationDllPath, True)
                '        WriteToLog(Environment.NewLine + ObjType.Name + " compiled and copied")
                '    Catch ex As Exception
                '        WriteToLog(Environment.NewLine + ObjType.Name + " - COPY GUI dll ERROR")
                '    End Try
                'Else
                '    WriteToLog(Environment.NewLine + ObjType.Name + " - COMPILATION ERROR")
                'End If
            End If
            WriteToLog(Environment.NewLine + ObjType.Name + "GUI created")
            If (progressBar.Maximum > progressBar.Value + 1) Then
                progressBar.Value = progressBar.Value + 1
                Application.DoEvents()
            End If
        Next
        WriteToLog(Environment.NewLine + "Win form generator stopped")
    End Sub

    Private Sub prepareFolder(ByVal path As String, Optional ByVal Delete As Boolean = True)
        If (Delete) Then
            If (System.IO.Directory.Exists(path)) Then
                Try
                    System.IO.Directory.Delete(path, True)
                Catch
                End Try
            End If
        End If
        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If
    End Sub

    Private Sub WriteToLog(ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.txtLog.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf WriteToLog)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.txtLog.Text = [text] + Me.txtLog.Text
            Application.DoEvents()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxOutDlls.TextChanged

    End Sub

    Private Sub ButtonGenSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenSetup.Click
        If (Not chkGenerators.SelectedItem Is Nothing) Then
            Dim li As Object = chkGenerators.SelectedItem
            If (generators(li) = GeneratorType.GeneratorTypeWinForm) Then
                Dim generator As LATIR_WINNET2.Generator = New LATIR_WINNET2.Generator()
                generator.Setup()
            ElseIf (generators(li) = GeneratorType.GeneratorTypeDll) Then
                Dim generator As LATIR_VBModel.Generator = New LATIR_VBModel.Generator()
                generator.Setup()
            ElseIf (generators(li) = GeneratorType.GeneratorTypeMSSQL) Then
                Dim generator As LATIR_MSSQLGen.Generator = New LATIR_MSSQLGen.Generator()
                generator.Setup()
            End If
        End If
    End Sub

    Private Sub CheckBoxCompile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCompile.CheckedChanged
        LabelDevEnv.Enabled = CheckBoxCompile.Checked
        TextBoxDevEnv.Enabled = CheckBoxCompile.Checked
        ButtonDevEnv.Enabled = CheckBoxCompile.Checked
        LabelOutDlls.Enabled = CheckBoxCompile.Checked
        TextBoxOutDlls.Enabled = CheckBoxCompile.Checked
        ButtonOutDlls.Enabled = CheckBoxCompile.Checked
    End Sub

    Private Sub frmGenerator_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.GEN_PROJECT_OUTPUT = textBoxOutPutFolder.Text
        My.Settings.GEN_DLLSOUTPUT = TextBoxOutDlls.Text
        My.Settings.GEN_DENENVFOLDER = TextBoxDevEnv.Text
        My.Settings.GEN_COMPILE = CheckBoxCompile.Checked
        My.Settings.Save()
    End Sub

    Private Sub ButtonOutDlls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOutDlls.Click
        FolderBrowserDialogDllOutput.SelectedPath = TextBoxOutDlls.Text
        FolderBrowserDialogDllOutput.ShowDialog()
        TextBoxOutDlls.Text = FolderBrowserDialogDllOutput.SelectedPath
    End Sub

    Private Sub LabelOutDlls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkGenerators_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGenerators.SelectedIndexChanged

    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        Dim i As Integer
        For i = 0 To chkTypes.Items.Count - 1
            chkTypes.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub cmdUnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnSelectAll.Click
        Dim i As Integer
        For i = 0 To chkTypes.Items.Count - 1
            chkTypes.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        folderBrowserDialogProjectOutput.SelectedPath = textBoxOutPutFolder.Text
        folderBrowserDialogProjectOutput.ShowDialog()
        textBoxOutPutFolder.Text = folderBrowserDialogProjectOutput.SelectedPath
    End Sub

    Private Sub ButtonDevEnv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDevEnv.Click
        FolderBrowserDialogDevenv.SelectedPath = TextBoxDevEnv.Text
        FolderBrowserDialogDevenv.ShowDialog()
        TextBoxDevEnv.Text = FolderBrowserDialogDevenv.SelectedPath
    End Sub

    Private Sub cmdCheckModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckModel.Click
        If (chkTypes.CheckedItems.Count > 0) Then
            txtLog.Text = ""
            LoadWords()
            Dim j As Integer
            progressBar.Minimum = 0
            progressBar.Maximum = chkTypes.CheckedIndices.Count
            progressBar.Value = 0
            progressBar.Visible = True
            For j = 0 To chkTypes.CheckedItems.Count
                On Error GoTo next_one
                Log("Тип документа: " & model.OBJECTTYPE.Item(GetObjID(chkTypes.CheckedItems.Item(j)).ToString()).the_Comment)
                Dim jj As Int32

                VerifyType(model.OBJECTTYPE.Item(GetObjID(chkTypes.CheckedItems.Item(j)).ToString()))
                progressBar.Value = progressBar.Value + 1
                GoTo cont
next_one:
                Resume cont
cont:
            Next
            progressBar.Visible = False
            MsgBox("Проверка завершена!" & vbCrLf & "Сморти результаты в журнале.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Проверка модели")
        Else
            MsgBox("Укажите тип объекта")
        End If
    End Sub

    Private Function IsExistObjType(ByVal ObjTypeName As String) As Boolean
        Dim dt As DataTable
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", , , "OBJTYPE='" + ObjTypeName + "'")
        If (dt.Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Private Function GetObjID(ByVal ObjTypeName As String) As Guid
        Dim dt As DataTable
        dt = guiManager.Manager.Session.GetRowsExDT("OBJECTTYPE", , , "name='" + ObjTypeName + "'")

        Dim ObjID As Guid
        If (dt.Rows.Count > 0) Then
            ObjID = New Guid(dt.Rows.Item(0).Item("OBJECTTYPEid").ToString())
            Return ObjID
        End If
        Return Guid.Empty
    End Function

    Private Sub Log(ByRef s As String)
        If txtLog.Rtf <> "" Then txtLog.Text = txtLog.Text & vbCrLf
        txtLog.Text = txtLog.Text & s
        Application.DoEvents()
    End Sub

    Private Sub cmdGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGen.Click
        Dim trueGenerate As Boolean
        trueGenerate = True
        If (chkGenerators.CheckedItems.Count > 0) Then
            If (chkTypes.CheckedItems.Count > 0) Then
                allSteps = chkGenerators.CheckedItems.Count * chkTypes.CheckedItems.Count
                progressBar.Maximum = allSteps
                progressBar.Minimum = 0
                progressBar.Value = 0
                For Each li As Object In chkGenerators.CheckedItems
                    If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypeMSSQL) Then
                        generateMSSQL()
                    End If
                    If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypeDll) Then
                        trueGenerate = generateDlls()
                    End If
            If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypeWinForm) Then
                generateWinControls()
            End If
                Next
                If trueGenerate Then
                    progressBar.Value = progressBar.Maximum
                End If
            Else
                MsgBox("Укажите тип объекта")
            End If
        Else
            MsgBox("Укажите генератор")
        End If
    End Sub

    Private Sub VerifyType(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim p As MTZMetaModel.MTZMetaModel.PART
        If ot.PART.Count = 0 Then
            Log("  ERROR-->не определен ни один раздел")
        End If

        If Not IsValidFieldName2(ot.Name) Then
            Log("  ERROR-->Имя типа " & ot.Name & " является ключевым словом, или имеет неверный формат")
        End If

        Dim i, j As Integer
        Dim dcnt As Short
        dcnt = 0
        For i = 1 To ot.OBJECTMODE.Count
            If ot.OBJECTMODE.Item(i).DefaultMode = MTZwp.MTZwp.enumBoolean.Boolean_Da Then
                dcnt = dcnt + 1
            End If
            For j = 1 To ot.OBJECTMODE.Item(i).FIELDRESTRICTION.Count
                If ot.OBJECTMODE.Item(i).FIELDRESTRICTION.Item(j).TheField Is Nothing Then
                    Log("  ERROR-->Тип: " & ot.Name & " Режим:" & ot.OBJECTMODE.Item(i).Name & "  в ограничении по полям не задано поле.")
                End If
                If ot.OBJECTMODE.Item(i).FIELDRESTRICTION.Item(j).ThePart Is Nothing Then
                    Log("  ERROR-->Тип: " & ot.Name & " Режим:" & ot.OBJECTMODE.Item(i).Name & "  в ограничении по полям не задан раздел.")
                End If
            Next

            For j = 1 To ot.OBJECTMODE.Item(i).STRUCTRESTRICTION.Count
                If ot.OBJECTMODE.Item(i).STRUCTRESTRICTION.Item(j).Struct Is Nothing Then
                    Log("  ERROR-->Тип: " & ot.Name & " Режим:" & ot.OBJECTMODE.Item(i).Name & "  в ограничении по разделам не задан раздел.")
                End If
            Next

            For j = 1 To ot.OBJECTMODE.Item(i).METHODRESTRICTION.Count
                If ot.OBJECTMODE.Item(i).METHODRESTRICTION.Item(j).Method Is Nothing Then
                    Log("  ERROR-->Тип: " & ot.Name & " Режим:" & ot.OBJECTMODE.Item(i).Name & "  в ограничении по методам не задан метод.")
                End If
            Next
        Next

        If dcnt > 1 Then
            Log("  ERROR-->Тип: " & ot.Name & "  более одного режима помечены как режимы по умолчанию.")
        End If

        dcnt = 0
        For i = 1 To ot.OBJSTATUS.Count
            If ot.OBJSTATUS.Item(i).isStartup = MTZwp.MTZwp.enumBoolean.Boolean_Da Then
                dcnt = dcnt + 1
            End If
        Next

        If ot.OBJSTATUS.Count > 0 Then
            If dcnt > 1 Then
                Log("  ERROR-->Тип: " & ot.Name & "  более одного состояния помечены как начальные.")
            End If
            If dcnt = 0 Then
                Log("  ERROR-->Тип: " & ot.Name & "  ни одно состояние не помечено как начальное.")
            End If
        End If

        ' проверяем  разделы
        For i = 1 To ot.PART.Count
            VerifyPart(ot.PART.Item(i))
        Next

        ' проверяем режимы работы

    End Sub

    Private Sub VerifyPart(ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD
        Log("  Раздел: " & p.Caption)
        If p.FIELD.Count = 0 And p.PartType <> MTZwp.MTZwp.enumPartType.PartType_Rassirenie Then
            Log("    ERROR-->не определено ни одного поля")
        End If

        If Not IsValidFieldName2(p.Name) Then
            Log("  ERROR-->Имя раздела " & p.Name & " является ключевым словом, или имеет неверный формат")
        End If

        Dim i, j As Integer
        Dim BriefCnt As Short

        BriefCnt = 0

        ' проверяем поля
        For i = 1 To p.FIELD.Count
            VerifyField(p.FIELD.Item(i))
            If p.FIELD.Item(i).IsBrief = MTZwp.MTZwp.enumBoolean.Boolean_Da Then BriefCnt = BriefCnt + 1
        Next

        If BriefCnt = 0 And p.PartType <> MTZwp.MTZwp.enumPartType.PartType_Rassirenie Then
            Log("    ERROR-->не определены поля для краткого отображения")
        End If

        Dim uc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        ' проверяем описания ограничений
        For i = 1 To p.UNIQUECONSTRAINT.Count
            uc = p.UNIQUECONSTRAINT.Item(i)
            For j = 1 To uc.CONSTRAINTFIELD.Count
                fld = uc.CONSTRAINTFIELD.Item(i).TheField
                If fld Is Nothing Then
                    Log("    ERROR-->ошибка в определении уникального ограничения")
                    Log("    поле  указывает на отсутствующий компонент")
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object fld.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If fld.Parent.Parent.ID <> p.ID Then
                        Log("    ERROR-->ошибка в определении уникального ограничения")
                        Log("    поле " & fld.Caption & " не  пренадлежит данному разделу")
                    End If
                    ft = fld.FieldType

                    If ft.Name = "Memo" Then
                        Log("    ERROR-->ошибка в определении уникального ограничения")
                        Log("    поле " & fld.Caption & " является BLOB полем")
                    End If
                    If ft.Name = "Image" Then
                        Log("    ERROR-->ошибка в определении уникального ограничения")
                        Log("    поле " & fld.Caption & " является BLOB полем")
                    End If
                    If ft.Name = "File" Then
                        Log("    ERROR-->ошибка в определении уникального ограничения")
                        Log("    поле " & fld.Caption & " является BLOB полем")
                    End If
                End If
            Next
        Next

        ' проверяем view
        Dim v As MTZMetaModel.MTZMetaModel.PARTVIEW

        For i = 1 To p.PARTVIEW.Count
            v = p.PARTVIEW.Item(i)
            VerifyView(v, p)
        Next


        ' проверяем зависимые разделы
        For i = 1 To p.PART.Count
            VerifyPart(p.PART.Item(i))
        Next
    End Sub

    Private Sub VerifyView(ByRef v As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim i As Integer
        Log("  View: " & v.Name & "(" & v.the_Alias & ")")
        If v.Name = "" Then
            Log("  ERROR-->Не определено имя ")
        End If
        If v.the_Alias = "" Then
            Log("  ERROR-->Не определен псевдоним ")
        End If

        For i = 1 To v.ViewColumn.Count
            vc = v.ViewColumn.Item(i)
            If vc.FromPart Is Nothing Then
                Log("  ERROR-->Для колонки " & vc.Name & "(" & vc.the_Alias & ") не определен раздел - источник")
            End If
            If vc.Field Is Nothing Then
                Log("  ERROR-->Для колонки " & vc.Name & "(" & vc.the_Alias & ") не определено поле - источник")
                'ElseIf vc.Field.Parent.Parent.ID <> p.ID Then
                '  Log "  ERROR-->Для колонки " & vc.Name & "(" & vc.the_Alias & ") поле - источник"
            End If

        Next

    End Sub

    Private Sub VerifyField(ByRef f As MTZMetaModel.MTZMetaModel.FIELD)
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = f.FieldType
        If f.Name = "" Then
            Log("  ERROR-->Для поля #" & f.Sequence & "  не определено имя ")
        End If
        If f.Caption = "" Then
            Log("  ERROR-->Для поля " & f.Name & "  не определен заголовок ")
        End If

        If ft Is Nothing Then
            Log("  ERROR-->Для поля " & f.Name & " не определен тип")
        End If
        If f.IsBrief And UCase(ft.Name) = "FILE" Then
            Log("  ERROR-->Поля " & f.Name & " предназначено для хранения файлов. Не может быть отображением.")
        End If

        If Not IsValidFieldName2(f.Name) Then
            Log("  ERROR-->Имя поля " & f.Name & " является ключевым словом, или имеет неверный формат")
        End If

        If ft.TypeStyle = MTZwp.MTZwp.enumTypeStyle.TypeStyle_Ssilka Then
            If f.ReferenceType = MTZwp.MTZwp.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
                Log("    Поле: " & f.Caption)
                Log("      ERROR-->Ошибка в определении поля ссылочный тип не сочетается с трактовкой: скалярное поле")
            End If

            If f.ReferenceType = MTZwp.MTZwp.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                If f.RefToPart Is Nothing Then
                    Log("    Поле: " & f.Caption)
                    Log("      ERROR-->Не определен раздел  - источник данных для поля")
                End If
            End If
        End If

        If ft.AllowSize Then
            If f.DataSize = 0 Then
                Log("    Поле: " & f.Caption)
                Log("      ERROR-->Тип данных требует задания размера")
            End If
        End If

        VerifyFieldType(f, ft)
    End Sub

    Private Sub VerifyFieldType(ByRef f As MTZMetaModel.MTZMetaModel.FIELD, ByRef ft As MTZMetaModel.MTZMetaModel.FIELDTYPE)
        If ft.TypeStyle = MTZwp.MTZwp.enumTypeStyle.TypeStyle_Viragenie Then
            Log("    Поле: " & f.Caption)
            Log("      Тип данных: " & ft.Name)
            Log("         ERROR-->ВЫРАЖЕНИЯ пока не поддерживаются")
        End If

        If ft.TypeStyle = MTZwp.MTZwp.enumTypeStyle.TypeStyle_Interval Then
            If ft.Minimum >= ft.Maximum Then
                Log("    Поле: " & f.Caption)
                Log("      Тип данных: " & ft.Name)
                Log("        ERROR-->неверно определены границы интервала")
            End If
        End If

        If ft.TypeStyle = MTZwp.MTZwp.enumTypeStyle.TypeStyle_Perecislenie Then
            If ft.ENUMITEM.Count = 0 Then
                Log("    Поле: " & f.Caption)
                Log("      Тип данных: " & ft.Name)
                Log("        ERROR-->не определены значения для перечисления")
            End If
        End If

        If ft.FIELDTYPEMAP.Count < 3 Then
            Log("  Поле: " & f.Caption)
            Log("    Тип данных: " & ft.Name)
            Log("      ERROR-->не определено отображение типа данных для генераторов ")
        End If

    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        txtLog.Clear()
    End Sub

    Private Sub cmdFindErr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindErr.Click
        Dim fres As Integer

        fres = txtLog.Find("ERROR-->", txtLog.SelectionStart, RichTextBoxFinds.MatchCase)
        If fres >= 0 Then
            txtLog.SelectionStart = fres + 5
            txtLog.ScrollToCaret()
        Else
            MsgBox("Ошибок не обнаружено", MsgBoxStyle.OkOnly)
            txtLog.SelectionStart = 0
        End If
    End Sub

    Private Sub cmdNormNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNormNames.Click
        If (chkTypes.CheckedItems.Count > 0) Then
            txtLog.Text = ""
            LoadWords()
            Dim j As Integer
            progressBar.Minimum = 0
            progressBar.Maximum = chkTypes.CheckedIndices.Count
            progressBar.Value = 0
            progressBar.Visible = True
            For j = 0 To chkTypes.CheckedItems.Count
                On Error GoTo next_one
                Log("Тип документа: " & model.OBJECTTYPE.Item(GetObjID(chkTypes.CheckedItems.Item(j)).ToString()).the_Comment)
                RenType(model.OBJECTTYPE.Item(GetObjID(chkTypes.CheckedItems.Item(j)).ToString()))
                progressBar.Value = progressBar.Value + 1
                GoTo cont
next_one:
                Resume cont
cont:
            Next
            progressBar.Visible = False
        Else
            MsgBox("Укажите тип объекта")
        End If
    End Sub

    Private Sub RenType(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Dim p As MTZMetaModel.MTZMetaModel.PART

        If ot.Name <> VF(ot.Name) Then
            ot.Name = VF(ot.Name)
            ot.Save()
        End If
        Dim i As Integer
        ' проверяем  разделы
        For i = 1 To ot.PART.Count
            RenPart(ot.PART.item(i))
        Next

        ' проверяем режимы работы

    End Sub

    Private Sub RenPart(ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim fld As MTZMetaModel.MTZMetaModel.FIELD

        If p.Name <> VF(p.Name) Then
            p.Name = VF(p.Name)
            p.Save()
        End If

        Dim i, j As Integer
        Dim BriefCnt As Short

        BriefCnt = 0

        ' проверяем поля
        For i = 1 To p.Field.Count
            RenField(p.Field.item(i))

        Next


        ' проверяем view
        Dim v As MTZMetaModel.MTZMetaModel.PARTVIEW

        For i = 1 To p.PartView.Count
            v = p.PartView.item(i)
            RenView(v, p)
        Next

        ' проверяем зависимые разделы
        For i = 1 To p.PART.Count
            RenPart(p.PART.item(i))
        Next
    End Sub

    Private Sub RenField(ByRef f As MTZMetaModel.MTZMetaModel.FIELD)
        If f.Name <> VF(f.Name) Then
            f.Name = VF(f.Name)
            f.Save()
        End If
    End Sub

    Private Sub RenView(ByRef v As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef p As MTZMetaModel.MTZMetaModel.PART)
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim i As Integer

        If v.the_Alias <> VF(v.the_Alias) Then
            v.the_Alias = VF(v.the_Alias)
            v.Save()
        End If

        For i = 1 To v.ViewColumn.Count
            vc = v.ViewColumn.item(i)
            If vc.the_Alias <> VF(vc.the_Alias) Then
                vc.the_Alias = VF(vc.the_Alias)
                vc.Save()
            End If
        Next

    End Sub

End Class
