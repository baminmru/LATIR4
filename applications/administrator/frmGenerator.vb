
Imports System.Collections
Imports System.Threading
Imports System.IO
Imports System.Runtime
Imports System.Text
'Imports MTZMetaModel.MTZMetaModel

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
    Friend WithEvents TextBoxDevEnv As LATIR2GuiManager.TouchTextBox
    Friend WithEvents LabelDevEnv As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCompile As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonOutDlls As System.Windows.Forms.Button
    Friend WithEvents TextBoxOutDlls As LATIR2GuiManager.TouchTextBox
    Friend WithEvents LabelOutDlls As System.Windows.Forms.Label
    Friend WithEvents button3 As System.Windows.Forms.Button
    Friend WithEvents textBoxOutPutFolder As LATIR2GuiManager.TouchTextBox
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
    Friend WithEvents cmdDoc As System.Windows.Forms.Button
    Friend WithEvents cDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents folderBrowserDialogProjectOutput As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerator))
        Me.folderBrowserDialogProjectOutput = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClearLog = New System.Windows.Forms.Button()
        Me.cmdFindErr = New System.Windows.Forms.Button()
        Me.cmdGen = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonGenSetup = New System.Windows.Forms.Button()
        Me.ButtonDevEnv = New System.Windows.Forms.Button()
        Me.LabelDevEnv = New System.Windows.Forms.Label()
        Me.CheckBoxCompile = New System.Windows.Forms.CheckBox()
        Me.ButtonOutDlls = New System.Windows.Forms.Button()
        Me.LabelOutDlls = New System.Windows.Forms.Label()
        Me.button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTypes = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdUnSelectAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.chkGenerators = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdNormNames = New System.Windows.Forms.Button()
        Me.cmdCheckModel = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogDevenv = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialogDllOutput = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdDoc = New System.Windows.Forms.Button()
        Me.cDlg = New System.Windows.Forms.SaveFileDialog()
        Me.TextBoxDevEnv = New LATIR2GuiManager.TouchTextBox()
        Me.TextBoxOutDlls = New LATIR2GuiManager.TouchTextBox()
        Me.textBoxOutPutFolder = New LATIR2GuiManager.TouchTextBox()
        Me.SuspendLayout()
        '
        'folderBrowserDialogProjectOutput
        '
        Me.folderBrowserDialogProjectOutput.SelectedPath = "C:\LATIR2\Generated\"
        '
        'cmdClearLog
        '
        Me.cmdClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearLog.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClearLog.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearLog.Location = New System.Drawing.Point(585, 477)
        Me.cmdClearLog.Name = "cmdClearLog"
        Me.cmdClearLog.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClearLog.Size = New System.Drawing.Size(174, 24)
        Me.cmdClearLog.TabIndex = 66
        Me.cmdClearLog.Text = "Очистить журнал"
        Me.cmdClearLog.UseVisualStyleBackColor = False
        '
        'cmdFindErr
        '
        Me.cmdFindErr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFindErr.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFindErr.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFindErr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFindErr.Location = New System.Drawing.Point(405, 477)
        Me.cmdFindErr.Name = "cmdFindErr"
        Me.cmdFindErr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFindErr.Size = New System.Drawing.Size(174, 24)
        Me.cmdFindErr.TabIndex = 65
        Me.cmdFindErr.Text = "Следующая ошибка"
        Me.cmdFindErr.UseVisualStyleBackColor = False
        '
        'cmdGen
        '
        Me.cmdGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdGen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdGen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdGen.Location = New System.Drawing.Point(672, 6)
        Me.cmdGen.Name = "cmdGen"
        Me.cmdGen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdGen.Size = New System.Drawing.Size(87, 24)
        Me.cmdGen.TabIndex = 64
        Me.cmdGen.Text = "Генерация"
        Me.cmdGen.UseVisualStyleBackColor = False
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtLog.Location = New System.Drawing.Point(4, 508)
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(755, 112)
        Me.txtLog.TabIndex = 63
        Me.txtLog.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 504)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(126, 20)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Журнал"
        '
        'ButtonGenSetup
        '
        Me.ButtonGenSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonGenSetup.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonGenSetup.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonGenSetup.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonGenSetup.Location = New System.Drawing.Point(166, 288)
        Me.ButtonGenSetup.Name = "ButtonGenSetup"
        Me.ButtonGenSetup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonGenSetup.Size = New System.Drawing.Size(183, 25)
        Me.ButtonGenSetup.TabIndex = 61
        Me.ButtonGenSetup.Text = "Настройка генератора"
        Me.ButtonGenSetup.UseVisualStyleBackColor = False
        '
        'ButtonDevEnv
        '
        Me.ButtonDevEnv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDevEnv.Location = New System.Drawing.Point(728, 415)
        Me.ButtonDevEnv.Name = "ButtonDevEnv"
        Me.ButtonDevEnv.Size = New System.Drawing.Size(31, 26)
        Me.ButtonDevEnv.TabIndex = 57
        Me.ButtonDevEnv.Text = "..."
        '
        'LabelDevEnv
        '
        Me.LabelDevEnv.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelDevEnv.AutoSize = True
        Me.LabelDevEnv.Location = New System.Drawing.Point(14, 419)
        Me.LabelDevEnv.Name = "LabelDevEnv"
        Me.LabelDevEnv.Size = New System.Drawing.Size(126, 17)
        Me.LabelDevEnv.TabIndex = 55
        Me.LabelDevEnv.Text = "MSBUILD.exe path"
        '
        'CheckBoxCompile
        '
        Me.CheckBoxCompile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxCompile.AutoSize = True
        Me.CheckBoxCompile.Checked = True
        Me.CheckBoxCompile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCompile.Location = New System.Drawing.Point(19, 394)
        Me.CheckBoxCompile.Name = "CheckBoxCompile"
        Me.CheckBoxCompile.Size = New System.Drawing.Size(80, 21)
        Me.CheckBoxCompile.TabIndex = 54
        Me.CheckBoxCompile.Text = "Compile"
        Me.CheckBoxCompile.UseVisualStyleBackColor = True
        '
        'ButtonOutDlls
        '
        Me.ButtonOutDlls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOutDlls.Location = New System.Drawing.Point(728, 442)
        Me.ButtonOutDlls.Name = "ButtonOutDlls"
        Me.ButtonOutDlls.Size = New System.Drawing.Size(31, 25)
        Me.ButtonOutDlls.TabIndex = 60
        Me.ButtonOutDlls.Text = "..."
        '
        'LabelOutDlls
        '
        Me.LabelOutDlls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelOutDlls.AutoSize = True
        Me.LabelOutDlls.Location = New System.Drawing.Point(17, 448)
        Me.LabelOutDlls.Name = "LabelOutDlls"
        Me.LabelOutDlls.Size = New System.Drawing.Size(122, 17)
        Me.LabelOutDlls.TabIndex = 58
        Me.LabelOutDlls.Text = "Dlls Output Folder"
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(728, 368)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(31, 25)
        Me.button3.TabIndex = 53
        Me.button3.Text = "..."
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 374)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(154, 17)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Projects Output Folder:"
        '
        'progressBar
        '
        Me.progressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressBar.Location = New System.Drawing.Point(14, 333)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(745, 20)
        Me.progressBar.TabIndex = 49
        Me.progressBar.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Процесс генерации"
        Me.Label1.Visible = False
        '
        'chkTypes
        '
        Me.chkTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTypes.CheckOnClick = True
        Me.chkTypes.FormattingEnabled = True
        Me.chkTypes.Location = New System.Drawing.Point(359, 50)
        Me.chkTypes.Name = "chkTypes"
        Me.chkTypes.Size = New System.Drawing.Size(400, 208)
        Me.chkTypes.Sorted = True
        Me.chkTypes.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(355, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(121, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Типы документов"
        '
        'cmdUnSelectAll
        '
        Me.cmdUnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnSelectAll.Location = New System.Drawing.Point(486, 288)
        Me.cmdUnSelectAll.Name = "cmdUnSelectAll"
        Me.cmdUnSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnSelectAll.Size = New System.Drawing.Size(120, 25)
        Me.cmdUnSelectAll.TabIndex = 47
        Me.cmdUnSelectAll.Text = "Отменить все"
        Me.cmdUnSelectAll.UseVisualStyleBackColor = False
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSelectAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSelectAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSelectAll.Location = New System.Drawing.Point(359, 288)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSelectAll.Size = New System.Drawing.Size(120, 25)
        Me.cmdSelectAll.TabIndex = 46
        Me.cmdSelectAll.Text = "Выбрать все"
        Me.cmdSelectAll.UseVisualStyleBackColor = False
        '
        'chkGenerators
        '
        Me.chkGenerators.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGenerators.CheckOnClick = True
        Me.chkGenerators.FormattingEnabled = True
        Me.chkGenerators.Location = New System.Drawing.Point(17, 50)
        Me.chkGenerators.Name = "chkGenerators"
        Me.chkGenerators.Size = New System.Drawing.Size(333, 208)
        Me.chkGenerators.Sorted = True
        Me.chkGenerators.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(17, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Генераторы"
        '
        'cmdNormNames
        '
        Me.cmdNormNames.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNormNames.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNormNames.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNormNames.Location = New System.Drawing.Point(151, 6)
        Me.cmdNormNames.Name = "cmdNormNames"
        Me.cmdNormNames.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNormNames.Size = New System.Drawing.Size(136, 24)
        Me.cmdNormNames.TabIndex = 42
        Me.cmdNormNames.Text = "Испр. имена"
        Me.cmdNormNames.UseVisualStyleBackColor = False
        '
        'cmdCheckModel
        '
        Me.cmdCheckModel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCheckModel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCheckModel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCheckModel.Location = New System.Drawing.Point(17, 6)
        Me.cmdCheckModel.Name = "cmdCheckModel"
        Me.cmdCheckModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCheckModel.Size = New System.Drawing.Size(135, 24)
        Me.cmdCheckModel.TabIndex = 41
        Me.cmdCheckModel.Text = "Проверить модель"
        Me.cmdCheckModel.UseVisualStyleBackColor = False
        '
        'FolderBrowserDialogDllOutput
        '
        '
        'cmdDoc
        '
        Me.cmdDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDoc.Location = New System.Drawing.Point(545, 6)
        Me.cmdDoc.Name = "cmdDoc"
        Me.cmdDoc.Size = New System.Drawing.Size(120, 24)
        Me.cmdDoc.TabIndex = 67
        Me.cmdDoc.Text = "Документация"
        Me.cmdDoc.UseVisualStyleBackColor = True
        '
        'TextBoxDevEnv
        '
        Me.TextBoxDevEnv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxDevEnv.Location = New System.Drawing.Point(161, 415)
        Me.TextBoxDevEnv.Name = "TextBoxDevEnv"
        Me.TextBoxDevEnv.Size = New System.Drawing.Size(552, 22)
        Me.TextBoxDevEnv.TabIndex = 56
        Me.TextBoxDevEnv.Text = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\"
        '
        'TextBoxOutDlls
        '
        Me.TextBoxOutDlls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxOutDlls.Location = New System.Drawing.Point(161, 442)
        Me.TextBoxOutDlls.Name = "TextBoxOutDlls"
        Me.TextBoxOutDlls.Size = New System.Drawing.Size(552, 22)
        Me.TextBoxOutDlls.TabIndex = 59
        Me.TextBoxOutDlls.Text = "C:\LATIR4\Build"
        '
        'textBoxOutPutFolder
        '
        Me.textBoxOutPutFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxOutPutFolder.Location = New System.Drawing.Point(161, 368)
        Me.textBoxOutPutFolder.Name = "textBoxOutPutFolder"
        Me.textBoxOutPutFolder.Size = New System.Drawing.Size(552, 22)
        Me.textBoxOutPutFolder.TabIndex = 52
        Me.textBoxOutPutFolder.Text = "C:\LATIR4\Generated\"
        '
        'frmGenerator
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(762, 625)
        Me.Controls.Add(Me.cmdDoc)
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
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(780, 669)
        Me.Name = "frmGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generate sources"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Enum GeneratorType
        GeneratorTypeDll = 0
        GeneratorTypeWinForm = 1
        GeneratorTypeMSSQL = 2
        GeneratorTypeMYSQL = 3
        GeneratorTypePOSTGRESQL = 4
        GeneratorTypeORACLESQL = 5

    End Enum

    Private objectTypes As Hashtable
    Private generators As Hashtable
    Private allSteps As Int16
    Private currentStep As Int16
    Private model As MTZMetaModel.MTZMetaModel.Application

    Private Const VBMODELFOLDERNAME As String = "\VB.NET Model\"
    Private Const VBINTERFACEFOLDERNAME As String = "\VB.NET Interface\"
    Private Const VBSQLFOLDERNAME As String = "\SQL_Scripts\"
    Private myResizer As LATIR2GuiManager.Resizer = New LATIR2GuiManager.Resizer


    Private Sub frmGenerator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As System.Data.DataTable
        Dim oID As System.Guid
        Dim i As Long
        dt = Manager.Session.GetRowsExDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, "", "", "OBJTYPE='mtzmetamodel'", "")

        objectTypes = New Hashtable
        generators = New Hashtable
        oID = New Guid(dt.Rows(0)("INSTANCEID").ToString())
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
        generators.Add("My SQL", GeneratorType.GeneratorTypeMYSQL)
        chkGenerators.Items.Add("My SQL", False)
        generators.Add("POSTGRESQL", GeneratorType.GeneratorTypePOSTGRESQL)
        chkGenerators.Items.Add("POSTGRESQL", False)
        generators.Add("ORACLE", GeneratorType.GeneratorTypeORACLESQL)
        chkGenerators.Items.Add("ORACLE", False)

        If (Not String.IsNullOrEmpty(GetSetting("LATIR4", "CFG", "GEN_PROJECT_OUTPUT"))) Then
            textBoxOutPutFolder.Text = GetSetting("LATIR4", "CFG", "GEN_PROJECT_OUTPUT")
        End If
        If (Not String.IsNullOrEmpty(GetSetting("LATIR4", "CFG", "GEN_DLLSOUTPUT"))) Then
            TextBoxOutDlls.Text = GetSetting("LATIR4", "CFG", "GEN_DLLSOUTPUT")
        End If
        If (Not String.IsNullOrEmpty(GetSetting("LATIR4", "CFG", "GEN_DENENVFOLDER"))) Then
            TextBoxDevEnv.Text = GetSetting("LATIR4", "CFG", "GEN_DENENVFOLDER")
        End If
        'LATIR2GuiManager.LATIRGuiManager.ScaleForm(Me)
        myResizer.FindAllControls(Me)
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
        Dim fname As String
        generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
        prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        fname = projBasePath + VBSQLFOLDERNAME + "\dbMSSQL_" + Now.ToString().Replace(":", ".").Replace(" ", "_") + ".xml"
        fname = fname.Replace("\\", "\")
        response.Save(fname)
        ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)
        WriteToLog(Environment.NewLine + "MSSQL generator stopped")
        If (progressBar.Maximum > progressBar.Value + 1) Then
            progressBar.Value = progressBar.Value + 1
        End If
    End Sub


    Private Sub generateMYSQL()
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        targetID = New System.Guid("{B29CCFC4-7344-446A-8F14-824C92DC2D30}")
        Dim generator As LATIR_MYSQLGen.Generator = New LATIR_MYSQLGen.Generator()

        WriteToLog(Environment.NewLine + "MySQL generator started")
        Dim response As LATIRGenerator.Response
        response = New LATIRGenerator.Response()
        Dim fname As String
        generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
        prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        fname = projBasePath + VBSQLFOLDERNAME + "\dbMySQL_" + Now.ToString("yyyyMMddHHmmss") + ".xml"
        response.Save(fname)
        ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)
        WriteToLog(Environment.NewLine + "MySQL generator stopped")
        If (progressBar.Maximum > progressBar.Value + 1) Then
            progressBar.Value = progressBar.Value + 1
        End If
    End Sub


    Private Sub generateORACLE()
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        targetID = New System.Guid("{C10CAD25-95ED-4518-9177-E29824F01E47}")
        Dim generator As Latir_OracleGen.Generator = New Latir_OracleGen.Generator()

        WriteToLog(Environment.NewLine + "ORACLE generator started")
        Dim response As LATIRGenerator.Response
        response = New LATIRGenerator.Response()
        Dim fname As String
        generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
        prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        fname = projBasePath + VBSQLFOLDERNAME + "\dbORACLE_" + Now.ToString("yyyyMMddHHmmss") + ".xml"
        response.Save(fname)
        ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)
        WriteToLog(Environment.NewLine + "ORACLE generator stopped")
        If (progressBar.Maximum > progressBar.Value + 1) Then
            progressBar.Value = progressBar.Value + 1
        End If
    End Sub


    Private Sub generatePOSTGRESQL()
        Dim xmlBasePath As String = Application.CommonAppDataPath
        Dim projBasePath As String = textBoxOutPutFolder.Text

        If Not xmlBasePath.EndsWith("\") Then
            xmlBasePath += "\"
        End If

        If Not projBasePath.EndsWith("\") Then
            projBasePath += "\"
        End If
        Dim targetID As System.Guid
        targetID = New System.Guid("{9D7DD39D-7A43-4EC3-AA10-1FBCED75F3CB}")
        Dim generator As LATIR_POSTGRESGEN.Generator = New LATIR_POSTGRESGEN.Generator()

        WriteToLog(Environment.NewLine + "POSTGRESQL generator started")
        Dim response As LATIRGenerator.Response
        response = New LATIRGenerator.Response()
        Dim fname As String
        generator.Run(CType(model, Object), CType(response, Object), targetID.ToString)
        prepareFolder(projBasePath + VBSQLFOLDERNAME, False)
        fname = projBasePath + VBSQLFOLDERNAME + "\dbPOSTGRE_" + Now.ToString().Replace("", ".").Replace(" ", "_") + ".xml"
        response.Save(fname)
        ReplaceInFile(fname, "&#xD;&#xA;", vbCrLf)
        WriteToLog(Environment.NewLine + "POSTGRESQL generator stopped")
        If (progressBar.Maximum > progressBar.Value + 1) Then
            progressBar.Value = progressBar.Value + 1
        End If
    End Sub


    Private Sub ReplaceInFile(ByVal FileName As String, ByVal Mask As String, ByVal Repl As String)
        FileName = FileName.Replace("\\", "\")
        FileName = FileName.Replace("\\", "\")
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
                MessageBox.Show("Path to Object manager Is't set", "Generator settings", MessageBoxButtons.OK)
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
                devPath = devPath + "MSBUILD.exe"
                LATIR2Framework.VBCompilerHelper.CompileProject(devPath, projectName, True)

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

            Convertors.MakeProjectBlocks(XmlFileName, _prjPath)
            File.Delete(XmlFileName)

            If (CheckBoxCompile.Checked) Then
                Dim projectName As String
                projectName = _prjPath + ObjType.Name + "GUI.vbproj"
                Dim devPath As String = TextBoxDevEnv.Text
                If (Not devPath.EndsWith("\")) Then
                    devPath = devPath + "\"
                End If
                devPath = devPath + "MSBUILD.exe"

                LATIR2Framework.VBCompilerHelper.CompileProject(devPath, projectName, True)

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

                Dim dinf As DirectoryInfo
                dinf = New System.IO.DirectoryInfo(path)
                For Each fi As FileInfo In dinf.GetFiles()
                    Try
                        fi.Delete()
                    Catch
                    End Try
                Next

            End If
        End If
        Dim di As DirectoryInfo
        'If (Not System.IO.Directory.Exists(path)) Then
        '    Stop
        'End If
        Dim again As Boolean
        again = True
        While (Not System.IO.Directory.Exists(path) And again)
            Try
                di = System.IO.Directory.CreateDirectory(path)

            Catch

            End Try
            If Not System.IO.Directory.Exists(path) Then
                again = (MsgBox("Ошибка создания директории :" & path & vbCrLf & "Повторить попытку создания?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes)
            End If
        End While


        'End If
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
            ElseIf (generators(li) = GeneratorType.GeneratorTypeMYSQL) Then
                Dim generator As LATIR_MYSQLGen.Generator = New LATIR_MYSQLGen.Generator()
                generator.Setup()
            ElseIf (generators(li) = GeneratorType.GeneratorTypeORACLESQL) Then
                Dim generator As Latir_OracleGen.Generator = New Latir_OracleGen.Generator()
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
        SaveSetting("LATIR4", "CFG", "GEN_PROJECT_OUTPUT", textBoxOutPutFolder.Text)
        SaveSetting("LATIR4", "CFG", "GEN_DLLSOUTPUT", TextBoxOutDlls.Text)
        SaveSetting("LATIR4", "CFG", "GEN_DENENVFOLDER", TextBoxDevEnv.Text)
        SaveSetting("LATIR4", "CFG", "GEN_COMPILE", CheckBoxCompile.Checked.ToString())

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
                Log("Тип документа:    " & model.OBJECTTYPE.Item(GetObjID(chkTypes.CheckedItems.Item(j)).ToString()).the_Comment)
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
        dt = guiManager.Manager.Session.GetRowsExDT("INSTANCE", Manager.Session.GetProvider.InstanceFieldList, , , "OBJTYPE='" + ObjTypeName + "'")
        If (dt.Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Private Function GetObjID(ByVal ObjTypeName As String) As Guid
        Dim dt As DataTable
        dt = guiManager.Manager.Session.GetRowsExDT("OBJECTTYPE", Manager.Session.GetProvider.ID2Base("OBJECTTYPEID"), , , "name='" + ObjTypeName + "'")

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
                    If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypeMYSQL) Then
                        generateMYSQL()
                    End If
                    If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypePOSTGRESQL) Then
                        generatePOSTGRESQL()
                    End If
                    If (generators.Item(li.ToString()) = GeneratorType.GeneratorTypeORACLESQL) Then
                        generateORACLE()
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
                    'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.Parent.Parent,Part). Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If CType(fld.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).ID <> p.ID Then
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
            progressBar.Maximum = chkTypes.CheckedItems.Count
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

    Private Sub FolderBrowserDialogDllOutput_HelpRequest(sender As System.Object, e As System.EventArgs) Handles FolderBrowserDialogDllOutput.HelpRequest

    End Sub

    Private Sub cmdDoc_Click(sender As System.Object, e As System.EventArgs) Handles cmdDoc.Click
        Dim fn As String
        cDlg.Filter = "Документ|*.htm"
        cDlg.DefaultExt = "htm"

        If cDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fn = cDlg.FileName

            wh_MakeContent(fn)

        End If

    End Sub


    Dim IncludeProcsToDoc As Boolean = False
    Dim IncludeStateToDoc As Boolean = False
    Dim IncludeModeToDoc As Boolean = False
    Dim DocShort As Boolean = False

    Dim wh As StringBuilder
    Dim H As Integer

    ' делаем документ
    Private Sub wh_MakeContent(ByVal fn As String)
        wh = New StringBuilder
        On Error GoTo bye
        Dim j As Long
        Dim cnt As Long

        cnt = 0
        cnt = chkTypes.CheckedItems.Count
        If cnt = 0 Then Exit Sub
        progressBar.Minimum = 0
        progressBar.Maximum = cnt + 1
        progressBar.Value = 0
        progressBar.Visible = True
        Label1.Visible = True
        'DoEvents()
        IncludeProcsToDoc = False
        wh.AppendLine("<html > <head>  <meta http-equiv=""content-type"" content=""text/html; charset=utf-8"" /></head><body>")

        If MsgBox("Включить описания типов документов?", vbYesNo, "Документация") = vbYes Then
            If MsgBox("Только краткое описание?", vbYesNo, "Документация") = vbYes Then
                DocShort = True
            Else
                DocShort = False
            End If

            If MsgBox("Включить описания процедур?", vbYesNo, "Документация") = vbYes Then
                IncludeProcsToDoc = True
            End If

            If MsgBox("Включить описания состояний?", vbYesNo, "Документация") = vbYes Then
                IncludeStateToDoc = True
            End If


            If MsgBox("Включить описания режимов?", vbYesNo, "Документация") = vbYes Then
                IncludeModeToDoc = True
            End If


            For j = 0 To chkTypes.CheckedItems.Count - 1

                ' describe object types

                ObjectTypeToHTML(objectTypes.Item(chkTypes.CheckedItems().Item(j)))
                progressBar.Value = progressBar.Value + 1

            Next
        Else
            progressBar.Value = progressBar.Value + chkTypes.CheckedItems.Count
        End If

      


        ' Вставляем описания процедур


        If IncludeProcsToDoc Then
            H = 1
            wh.AppendLine("<h" + H.ToString + ">")
            wh.Append("Стандартные процедуры для любого документа")
            wh.AppendLine("</h" + H.ToString + "><br/>")

            wh.Append("<b>")
            wh.Append("Функция вычисления краткого наименования документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("function instance_BRIEF_F  (" & vbCrLf & "</br>" & _
            "@InstanceID uniqueidentifier          /* Идентификатор объекта */" & vbCrLf & "</br>" & _
            ",@Lang varchar(25)=NULL               /* язык */" & vbCrLf & "</br>" & _
            ")returns varchar(4000)" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - краткое наименование документа" & vbCrLf & "</br>" & vbCrLf & "</br>")
            wh.Append("<b>")
            wh.Append("Процедура вычисления краткого наименования документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc instance_BRIEF  (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier          /* Идентификатор Текущей сессии */," & vbCrLf & "</br>" & _
            "@InstanceID uniqueidentifier          /* Идентификатор объекта */," & vbCrLf & "</br>" & _
            "@BRIEF varchar(4000) output           /* Краткое наименование документа */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")

            wh.Append("<b>")
            wh.Append("Процедура удаления документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Instance_DELETE (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier/*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@InstanceID uniqueidentifier                  /* Идентификатор объекта */)" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")

            wh.Append("<b>")
            wh.Append("Процедура проверки состояния блокировки дочерних строк")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Instance_HCL (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier/* Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@RowID uniqueidentifier                       /* идентификатор документа */," & vbCrLf & "</br>" & _
            "@IsLocked int out                             /* результат блокировки */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>" & _
            " Возможные значения параметра @IsLocked: " & vbCrLf & "</br>" & _
            "  @isLocked = 4 /* Заблокирован другим пользователем в режиме CheckOut */" & vbCrLf & "</br>" & _
            "  @isLocked = 2 /* Заблокирован текущим пользователем в режиме CheckOut */" & vbCrLf & "</br>" & _
            "  @isLocked = 3 /* Заблокирован другим пользователем в рамках сессии */" & vbCrLf & "</br>" & _
            "  @isLocked = 1 /* Заблокирован текущим пользователем в рамках сессии */" & vbCrLf & "</br>" & _
            "  @isLocked = 0 /* Документ не заблокирован */" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")
            wh.Append("<b>")
            wh.Append("Процедура проверки блокировки")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc INSTANCE_ISLOCKED (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier /*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@RowID uniqueidentifier  /* идентификатор документа */," & vbCrLf & "</br>" & _
            "@IsLocked integer output /* результат блокировки */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>" & _
           " Возможные значения параметра @IsLocked: " & vbCrLf & "</br>" & _
            "   @isLocked = 4 /* Заблокирован другим пользователем в режиме CheckOut */" & vbCrLf & "</br>" & _
            "   @isLocked = 2 /* Заблокирован текущим пользователем в режиме CheckOut */" & vbCrLf & "</br>" & _
            "   @isLocked = 3 /* Заблокирован другим пользователем в рамках сессии */" & vbCrLf & "</br>" & _
            "   @isLocked = 1 /* Заблокирован текущим пользователем в рамках сессии */" & vbCrLf & "</br>" & _
            "   @isLocked = 0 /* Документ не заблокирован*/" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Блокировка")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Instance_LOCK  (" & vbCrLf & "</br>" & _
            " @CURSESSION uniqueidentifier /*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            " @RowID uniqueidentifier /* идентификатор документа */," & vbCrLf & "</br>" & _
            " @LockMode integer /* Режим блокироки */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>" & vbCrLf & "</br>" & _
            " Возможные значения режима блокировки:" & vbCrLf & "</br>" & _
            "@LockMode =1  -  Блокировка в рамках текущей сессии" & vbCrLf & "</br>" & _
            "@LockMode =2  -  Блокировка в режиме CheckOut" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Определение привязки документа к строке раздела")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc INSTANCE_OWNER (  @CURSESSION uniqueidentifier /*Идентификатор Текущей сессии*/ " & vbCrLf & "</br>" & _
            ",@InstanceID uniqueidentifier /* Идентификатор объекта */," & vbCrLf & "</br>" & _
            "@OwnerPartName varchar(255) /* Название раздела владельца*/," & vbCrLf & "</br>" & _
            "@OwnerRowID uniqueidentifier /* Идентификатор строки владельца*/)" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Распространение прав на дочерние разделы и строки")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Instance_propagate (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier/*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@RowID uniqueidentifier /* идентификатор документа */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Сохранение\создание заголовка документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Instance_Save (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier/*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@InstanceID uniqueidentifier /* Идентификатор объекта */," & vbCrLf & "</br>" & _
            "@ObjType varchar(255) /* Тип объекта*/," & vbCrLf & "</br>" & _
            "@Name varchar(255) /* Краткое название объекта */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Инициализация прав по умолчанию")
            wh.Append("</b>")
            wh.Append("<br/>")

            wh.Append("instance_SINIT  (" & vbCrLf & "</br>" & _
            "@CURSESSION uniqueidentifier/*Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "@RowID uniqueidentifier /* идентификатор документа */," & vbCrLf & "</br>" & _
            "@SecurityStyleID uniqueidentifier=null /* Идентификатор дескриптора прав */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Задание состояния документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("Instance_Status(" & vbCrLf & "</br>" & _
            "  @CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            "  @InstanceID uniqueidentifier /* Идентификатор объекта */," & vbCrLf & "</br>" & _
            "  @statusid uniqueidentifier   /* Идентификатор нового состояния */)" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Разблокировка")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("Instance_UNLOCK (" & vbCrLf & "</br>" & _
            " @CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "</br>" & _
            " @RowID uniqueidentifier      /* идентификатор документа */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")

            wh.AppendLine("<h" + H.ToString + ">")
            wh.Append("Стандартные процедуры ядра")
            wh.AppendLine("</h" + H.ToString + ">")


            wh.Append("<b>")
            wh.Append("Разблокировка одного документа")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc AdminUnlock (@ID uniqueidentifier/* Идентификатор документа */ )" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Снятие всех блокировок")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc AdminUnlockAll()" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")


            wh.Append("<b>")
            wh.Append("Открытие сессии")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Login" & vbCrLf & "</br>" & _
            "(@the_SESSION uniqueidentifier = null  output /* Идентификатор новой сессии */" & vbCrLf & "</br>" & _
            ",@PWD varchar(80)                             /* Пароль */" & vbCrLf & "</br>" & _
            ",@USR VARCHAR (64)                            /* Имя пользователя */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет ")
            wh.Append("<br/>")

            wh.Append("<b>")
            wh.Append("Сохранение настроек")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc SysOptions_Save (" & vbCrLf & "</br>" & _
            "@SysOptionsid uniqueidentifier              /* ID строки настроек */," & vbCrLf & "</br>" & _
            "@Name varchar(255)                          /* Название настройки */," & vbCrLf & "</br>" & _
            "@Value varchar (255)                        /* Значение */," & vbCrLf & "</br>" & _
            "@OptionType varchar(255)                    /* Тип настройки */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")
            '

            wh.Append("<b>")
            wh.Append("Закрытие сессии")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc Logout" & vbCrLf & "</br>" & _
            "(@CURSESSION uniqueidentifier          /* Идентификатор сессии */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")



            wh.Append("<b>")
            wh.Append("Оповещение системы об активности сессии")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc SessionTouch" & vbCrLf & "</br>" & _
            "(@CURSESSION uniqueidentifier          /* Идентификатор сессии */" & vbCrLf & "</br>" & _
            ")" & vbCrLf & "</br>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "</br>" & vbCrLf & "</br>")



        End If

        If MsgBox("Включить описания типов полей?", vbYesNo, "Документация") = vbYes Then
            ' describe fieldtypes
            FieldTypeToHTML()
        End If
        progressBar.Value = progressBar.Value + 1


        '' Вставляем оглавление
        'Dim myRange As Object

        'myRange = wh.wdoc.Range(0, 0)
        'wh.wdoc.TablesOfContents.Add(Range:=myRange, _
        'UseFields:=False, UseHeadingStyles:=True, LowerHeadingLevel:=9, _
        'UpperHeadingLevel:=1)
        wh.AppendLine("</body></html>")
        File.WriteAllText(fn, wh.ToString())

        progressBar.Visible = False
        Label1.Visible = False
        MsgBox("Создание документации завершено")

        Exit Sub

bye:
        MsgBox(Err.Description, vbCritical)
        progressBar.Visible = False
        Label1.Visible = False
        Log(Err.Description)

    End Sub




    Private Sub FieldTypeToHTML()
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim s As String



        H = 1
        wh.AppendLine("<h" + H.ToString + ">")
        wh.Append("Описание типов полей")
        wh.AppendLine("</h" + H.ToString + ">")

        model.FIELDTYPE.Sort = "Name"
        Dim i As Long, j As Long, k As Long
        For i = 1 To model.FIELDTYPE.Count
            ft = model.FIELDTYPE.Item(i)
            H = H + 1
            wh.AppendLine("<h" + H.ToString + ">")
            wh.Append(ft.Name)
            wh.AppendLine("</h" + H.ToString + ">")
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
                wh.Append("Интервал в диапазоне от:" & ft.Minimum & " до:" & ft.Maximum & ".")
            End If
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                wh.Append("Перечисление:")
                Dim e As MTZMetaModel.MTZMetaModel.ENUMITEM
                wh.AppendLine("<table border=""1"">")
                s = "<tr><td>Значение" & "</td><td>" & " Название</td></tr>"
                wh.Append(s)

                ft.ENUMITEM.Sort = "NameValue"
                For j = 1 To ft.ENUMITEM.Count
                    e = ft.ENUMITEM.Item(j)
                    s = "<tr><td>" & e.NameValue & "</td><td>" & e.Name & "</td></tr>"
                    wh.Append("<i>")
                    wh.Append(s)
                    wh.Append("</i>")
                Next
                wh.AppendLine("</table>")
                'wh.MakeTable(sp, ep, ep - sp + 1, 2)
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Skalyrniy_tip Then
                wh.Append("Скалярный тип. ")
                If ft.AllowSize Then
                    wh.Append("Требует указания размера")
                End If
                If ft.AllowLikeSearch Then
                    wh.Append("Допускает текстовый поиск")
                End If
            End If
            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                wh.Append("Ссылка на ресурс или документ")
            End If

            If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Viragenie Then
                wh.Append("Вычисляемое выражение")
            End If
            Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
            Dim trg As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
            wh.Append("<br/>")
            wh.Append("<b>")
            wh.Append("Отображение типа при генерации")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.AppendLine("<table border=""1"" >")
            s = "<tr><td>Тип генерации" & "</td><td>" & "Генератор" & "</td><td>" & "Отображается на</td></tr>"
            wh.Append(s)
            For j = 1 To ft.FIELDTYPEMAP.Count
                s = "<tr><td>"
                ftm = ft.FIELDTYPEMAP.Item(j)
                trg = ftm.Target
                If trg.TargetType = MTZMetaModel.MTZMetaModel.enumTargetType.TargetType_SUBD Then
                    s = s + "База данных"
                End If
                If trg.TargetType = MTZMetaModel.MTZMetaModel.enumTargetType.TargetType_MODEL_ Then
                    s = s + "Объектная модель"
                End If
                If trg.TargetType = MTZMetaModel.MTZMetaModel.enumTargetType.TargetType_Prilogenie Then
                    s = s + "Приложение"
                End If

                s = s & "</td><td>" & trg.Name
                If ftm.FixedSize <> 0 Then
                    s = s & "</td><td>" & ftm.StoageType & "(" & ftm.FixedSize & ")"

                Else
                    s = s & "</td><td>" & ftm.StoageType

                End If
                wh.Append(s + "</td></tr>")

            Next
            wh.AppendLine("</table>")
            'wh.MakeTable(sp, ep, ep - sp + 1, 3)
            H = H - 1
        Next
        H = H - 1
    End Sub

    Private Sub ObjectTypeToHTML(ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        H = 0
        H = H + 1
        wh.AppendLine("<h" + H.ToString + ">")
        wh.Append("Описание документа: " & ot.the_Comment & " ( " & ot.Name & " )")
        wh.AppendLine("</h" + H.ToString + ">")
        If ot.TheComment <> "" Then
            wh.Append(ot.TheComment)
            wh.Append("<br/>")
        End If
        Dim p As MTZMetaModel.MTZMetaModel.PART

        Dim pkg As MTZMetaModel.MTZMetaModel.MTZAPP
        Dim sm As MTZMetaModel.MTZMetaModel.SHAREDMETHOD
        Dim i As Long, j As Long, k As Long
        pkg = ot.Package
        wh.Append("Документ входит в состав приложения: " & pkg.Name)
        wh.Append("<br/>")
        If ot.IsSingleInstance Then
            wh.Append("Допускается существование только одного документа данного типа в информационной системе")
            wh.Append("<br/>")
        End If

        If Not DocShort Then
            Dim iv As MTZMetaModel.MTZMetaModel.INSTANCEVALIDATOR
            Dim trg As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
            If ot.INSTANCEVALIDATOR.Count > 0 Then
                H = H + 1
                wh.AppendLine("<h" + H.ToString + ">")
                wh.Append("Правильность заполнения")
                wh.AppendLine("</h" + H.ToString + ">")

                For i = 1 To ot.INSTANCEVALIDATOR.Count
                    iv = ot.INSTANCEVALIDATOR.Item(i)
                    If iv.Code <> "" Then
                        trg = iv.Target
                        wh.Append("Верификатор объекта для варианта генерации:" & trg.Name)
                        wh.Append("<br/>")
                        wh.Append("<i>")
                        wh.Append("<code>" + iv.Code + "</code>")
                        wh.Append("</i>")
                        wh.Append("<br/>")
                    End If
                Next
                H = H - 1
            End If

            If ot.TYPEMENU.Count > 0 Then
                H = H + 1
                wh.AppendLine("<h" + H.ToString + ">")
                wh.Append("Операции над объектом")
                wh.AppendLine("</h" + H.ToString + ">")

                Dim tm As MTZMetaModel.MTZMetaModel.TYPEMENU
                For i = 1 To ot.TYPEMENU.Count
                    tm = ot.TYPEMENU.Item(i)
                    wh.Append("Операция: " & tm.Caption & "(" & tm.Name & ")")
                    wh.Append("<br/>")
                    sm = tm.the_Action
                    wh.Append("Операция основана на методе: " & sm.the_Comment & "(" & sm.Name & ")")
                    wh.Append("<br/>")
                Next
                H = H - 1
            End If
            On Error GoTo nxt

            If IncludeModeToDoc Then

                If ot.OBJECTMODE.Count > 0 Then
                    H = H + 1
                    wh.AppendLine("<h" + H.ToString + ">")
                    wh.Append("Режимы исполнения объекта")
                    wh.AppendLine("</h" + H.ToString + ">")
                    H = H + 1
                    Dim otm As MTZMetaModel.MTZMetaModel.OBJECTMODE
                    Dim sr As MTZMetaModel.MTZMetaModel.STRUCTRESTRICTION
                    For i = 1 To ot.OBJECTMODE.Count
                        otm = ot.OBJECTMODE.Item(i)
                        wh.AppendLine("<h" + H.ToString + ">")
                        If otm.DefaultMode = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            wh.Append("Режим '" & otm.Name & "' - основной режим работы")
                        Else
                            wh.Append("Режим '" & otm.Name & "'")
                        End If
                        wh.AppendLine("</h" + H.ToString + ">")


                        If otm.TheComment <> "" Then
                            wh.Append(otm.TheComment)
                            wh.Append("<br/>")
                        End If
                        If otm.STRUCTRESTRICTION.Count > 0 Then
                            H = H + 1
                            wh.AppendLine("<h" + H.ToString + ">")
                            wh.Append("Ограничения на разделы")
                            wh.AppendLine("</h" + H.ToString + ">")
                            H = H - 1
                            For j = 1 To otm.STRUCTRESTRICTION.Count
                                sr = otm.STRUCTRESTRICTION.Item(j)
                                If Not sr.Struct Is Nothing Then
                                    wh.Append("<b>")
                                    wh.Append("Раздел: '" & CType(sr.Struct, MTZMetaModel.MTZMetaModel.PART).Caption & "'")
                                    wh.Append("</b>")
                                    wh.Append("<br/>")
                                    If sr.AllowRead = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                                        wh.Append("Чтение запрещено")
                                        wh.Append("<br/>")
                                    End If
                                    If sr.AllowDelete = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                                        wh.Append("Удаление из раздела запрещено")
                                        wh.Append("<br/>")
                                    End If
                                    If sr.AllowEdit = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                                        wh.Append("Модификация строк запрещена")
                                        wh.Append("<br/>")
                                    End If
                                    If sr.AllowAdd = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
                                        wh.Append("Добавление строк запрещено")
                                        wh.Append("<br/>")
                                    End If
                                End If
                            Next
                        End If
                    Next
                    H = H - 1
                    H = H - 1
                End If
            End If

            If IncludeStateToDoc Then
                If ot.OBJSTATUS.Count > 0 Then
                    H = H + 1
                    wh.AppendLine("<h" + H.ToString + ">")
                    wh.Append("Состояния документа")
                    wh.AppendLine("</h" + H.ToString + ">")
                    H = H + 1
                    For i = 1 To ot.OBJSTATUS.Count
                        wh.AppendLine("<h" + H.ToString + ">")
                        wh.Append(ot.OBJSTATUS.Item(i).name)
                        wh.AppendLine("</h" + H.ToString + ">")
                        If ot.OBJSTATUS.Item(i).the_comment <> "" Then
                            wh.Append(ot.OBJSTATUS.Item(i).the_comment)
                        End If
                        If ot.OBJSTATUS.Item(i).isStartup Then
                            wh.Append("-Начальное состояние")
                            wh.Append("<br/>")
                        End If
                        If ot.OBJSTATUS.Item(i).IsArchive Then
                            wh.Append("-Конечное состояние")
                            wh.Append("<br/>")
                        End If
                        If ot.OBJSTATUS.Item(i).NEXTSTATE.Count > 0 Then
                            wh.Append("Разрешены ручные переходы в следующие состояния:")
                            wh.Append("<br/>")
                            wh.AppendLine("<ol>")
                            For j = 1 To ot.OBJSTATUS.Item(i).NEXTSTATE.Count
                                wh.Append("<li>")
                                wh.Append(CType(ot.OBJSTATUS.Item(i).NEXTSTATE.Item(j).TheState, MTZMetaModel.MTZMetaModel.OBJSTATUS).name)
                                wh.AppendLine("</li>")
                            Next
                            wh.AppendLine("</ol>")
                        End If
                    Next
                    H = H - 1
                    H = H - 1
                End If
            End If
        End If

nxt:
        '    If Err.Number > 0 Then
        '      Stop
        '      Resume
        '    End If


        ot.PART.Sort = "sequence"
        For i = 1 To ot.PART.Count
            PartToHTML(ot.PART.Item(i), ot)
        Next

        H = H - 1
    End Sub

    'Private Sub PartToHTML(ByVal p As MTZMetaModel.PART)
    '  wh.NextHeader
    '  wh.Append "Описание раздела: " & p.Caption & "(" & p.Name & ")"
    '  wh.Header
    '  wh.Append p.the_comment
    '  Dim s As String, sp As Long, ep As Long
    '  Dim f As MTZMetaModel.Field
    '  Dim ft As MTZMetaModel.FIELDTYPE
    '  Dim i As Long, j As Long, k As Long
    '  If p.PartType = PartType_Stroka Then
    '    wh.Append "Структура (коллекция с одной строкой)"
    '  End If
    '
    '  If p.PartType = PartType_Kollekciy Then
    '    wh.Append "Коллекция строк"
    '  End If
    '
    '  If p.PartType = PartType_Derevo Then
    '    wh.Append "Древовидная структура"
    '  End If
    ''  If P.the_comment <> "" Then
    ''    wh.Append P.the_comment
    ''  End If
    '  If Not DocShort Then
    '    wh.Append "Структура раздела"
    '    wh.Bold
    '    p.Field.Sort = "sequence"
    '    wh.appendline("<table>")
    '    s = "Название" & "</td><td>" & "Псевдоним" & "</td><td>" & "Тип" & "</td><td>" & "Можно не задавать" & "</td><td>" & "Кратко" & "</td><td>" & "Размер / Ссылка" & "</td><td>" & "Примечание"
    '    wh.Append s
    '    For i = 1 To p.Field.Count
    '
    '      ' skip big structs
    '      If i > 20 Then Exit For
    '
    '
    '      Set f = p.Field.item(i)
    '
    '
    '      Set ft = f.FIELDTYPE
    '
    ''      For j = 1 To ft.FIELDTYPEMAP.Count
    ''       If ft.FIELDTYPEMAP.item(j).Target.Name = "MS SQL 2000" Then
    ''          s = ft.FIELDTYPEMAP.item(j).StoageType
    ''          If ft.AllowSize = Boolean_Da Then
    ''            s = s & "(" & f.DataSize & ")"
    ''          Else
    ''            If ft.FIELDTYPEMAP.item(j).Target.FixedSize <> 0 Then
    ''             s = s & "(" & ft.FIELDTYPEMAP.item(j).Target.FixedSize & ")"
    ''            End If
    ''          End If
    ''        Exit for
    ''       End If
    ''      Next
    '
    '      s = f.Caption & "</td><td>" & f.Name
    '      s = s & "</td><td>" & ft.the_comment & "(" & ft.Name & ")"
    '      If f.AllowNull Then
    '        s = s & "</td><td>" & "Да"
    '      Else
    '        s = s & "</td><td>" & "Нет"
    '      End If
    '
    '      If f.IsBrief Then
    '        s = s & "</td><td>" & "Да"
    '      Else
    '        s = s & "</td><td>" & "Нет"
    '      End If
    '
    '      Dim rp As PART
    '      Dim rt As objectType
    '
    '      If ft.AllowSize Then
    '        s = s & "</td><td>" & f.DataSize
    '
    '      ElseIf ft.TypeStyle = TypeStyle_Ssilka Then
    '        If f.ReferenceType = ReferenceType_Na_ob_ekt_ Then
    '          s = s & "</td><td>" & "ссылка на объект "
    '
    '          Set rt = f.RefToType
    '          If Not rt Is Nothing Then
    '            s = s & "типа: " & Notabs(rt.the_comment)
    '          End If
    '        End If
    '        If f.ReferenceType = ReferenceType_Na_stroku_razdela Then
    '          s = s & "</td><td>" & "ссылка на строку раздела"
    '
    '          Set rp = f.RefToPart
    '          If Not rp Is Nothing Then
    '             Set rt = TypeForStruct(rp)
    '             s = s & ": " & Notabs(rp.Caption) & " (в документе: " & Notabs(rt.the_comment) & ")"
    '          End If
    '
    '        End If
    '      End If
    '      s = s & "</td><td>" & Notabs(f.TheComment)
    '      wh.Append s
    '      wh.Italic
    '      DoEvents
    '    Next
    '    wh.AppendLine("</table>")
    '    'wh.MakeTable sp, ep, ep - sp + 1, 7
    '
    '    If p.UNIQUECONSTRAINT.Count > 0 Then
    '      wh.Append "Уникальные сочетания полей в разделе"
    '      wh.Bold
    '      Dim unc As MTZMetaModel.UNIQUECONSTRAINT
    '      Dim uncf As MTZMetaModel.CONSTRAINTFIELD
    '      For j = 1 To p.UNIQUECONSTRAINT.Count
    '        Set unc = p.UNIQUECONSTRAINT.item(j)
    '        If unc.PerParent Then
    '          wh.Append "Ограничение №" & j & " - в рамках родительского раздела"
    '        Else
    '          wh.Append "Ограничение №" & j & " - глобальное"
    '        End If
    '        If unc.Name <> "" Then
    '          wh.Append unc.Name
    '        End If
    '        If unc.TheComment <> "" Then
    '          wh.Append unc.TheComment
    '        End If
    '
    '
    '        s = "Уникальное сочетание полей:"
    '        For k = 1 To unc.CONSTRAINTFIELD.Count
    '          Set uncf = unc.CONSTRAINTFIELD.item(k)
    '          Set f = uncf.TheField
    '          If k <> 1 Then
    '            s = s & "+"
    '          End If
    '          s = s & f.Caption
    '        Next
    '        wh.Append s
    '        wh.Italic
    '
    '      Next
    '    End If
    '  End If
    '  p.PART.Sort = "sequence"
    '  For i = 1 To p.PART.Count
    '    PartToHTML p.PART.item(i)
    '  Next
    '
    '  wh.PrevHeader
    'End Sub


    Private Sub PartToHTML(ByVal p As MTZMetaModel.MTZMetaModel.PART, ByVal ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        H = H + 1
        wh.AppendLine("<h" + H.ToString + ">")
        wh.Append("Описание раздела: " & p.Caption & "(" & p.Name & ")")
        wh.AppendLine("</h" + H.ToString + ">")
        wh.Append(p.the_Comment)


        Dim s As String, sp As Long, ep As Long
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Long, j As Long, k As Long

        If UCase(TypeName(p.Parent.Parent)) = "OBJECTTYPE" Then
            wh.Append("Раздел первого уровня документа " & ot.the_Comment)
            wh.Append("<br/>")
        Else
            wh.Append("Дочерний раздел к разделу " & CType(p.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Caption)
            wh.Append("<br/>")
        End If

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Stroka Then
            wh.Append("Структура (коллекция с одной строкой)")
            wh.Append("<br/>")
        End If

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Kollekciy Then
            wh.Append("Коллекция строк")
            wh.Append("<br/>")
        End If

        If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            wh.Append("Древовидная структура")
            wh.Append("<br/>")
        End If
        '  If P.the_comment <> "" Then
        '    wh.Append P.the_comment
        '  End If



        If Not DocShort Then
            wh.Append("<b>")
            wh.Append("Структура раздела")
            wh.Append("</b>")
            wh.Append("<br/>")
            p.FIELD.Sort = "sequence"
            wh.AppendLine("<table border=""1""><tr><td>")
            s = "Группа" & "</td><td>" & "Название" & "</td><td>" & "Псевдоним" & "</td><td>" & "Тип" & "</td><td>" & "Можно не задавать" & "</td><td>" & "Размер / Ссылка" & "</td><td>" & "Примечание" & "</td><td>" & "Модификатор" & "</td></tr>"
            wh.Append(s)




            If UCase(TypeName(p.Parent.Parent)) = "OBJECTTYPE" Then
                wh.Append("<tr><td>Системное поле</td><td>Документ" & "</td><td>" & "InstanceID" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID Документа" & "</td><td></td></tr>")
            Else
                wh.Append("<tr><td>Системное поле</td><td>ID родительской строки в " & CType(p.Parent.Parent, MTZMetaModel.MTZMetaModel.PART).Caption & "</td><td>" & "ParentStructRowID" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID Документа" & "</td><td></td></tr>")
            End If


            wh.Append("<tr><td>Системное поле</td><td>Идентификатор строки" & "</td><td>" & p.Name & "id" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "Ключевое поле таблицы " & p.Name & "</td><td></td></tr>")
            wh.Append("<tr><td>Системное поле</td><td>Дата модификации" & "</td><td>" & "ChangeStamp" & "</td><td>" & "datetime" & "</td><td>" & "Нет" & "</td><td>" & "8" & "</td><td>" & "Время последней модификации" & "</td><td></td></tr>")
            wh.Append("<tr><td>Системное поле</td><td>Дата модификации" & "</td><td>" & "TimeStamp" & "</td><td>" & "timestamp " & "</td><td>" & "Нет" & "</td><td>" & "8" & "</td><td>" & "</td></tr>")
            wh.Append("<tr><td>Системное поле</td><td>Блокировка" & "</td><td>" & "LockSessionID" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID блокирующей сессии" & "</td><td></td></tr>")
            wh.Append("<tr><td>Системное поле</td><td>CheckOut блокировка" & "</td><td>" & "LockUserID" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID блокирующего пользователя" & "</td><td></td></tr>")
            wh.Append("<tr><td>Системное поле</td><td>Права на строку" & "</td><td>" & "SecurityStyleID" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID дескриптора прав ( не используется)" & "</td><td></td></tr>")


            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                wh.Append("<tr><td>Системное поле</td><td>Родительская строка в дереве" & "</td><td>" & "ParentRowid" & "</td><td>" & "UNIQUEIDENTIFIER" & "</td><td>" & "Нет" & "</td><td>" & "16" & "</td><td>" & "ID родительской строки в дереве, либо NULL для первого уровня дерева" & "</td><td></td></tr>")
            End If

            For i = 1 To p.FIELD.Count

                ' skip big structs
                If i > 30 Then Exit For


                f = p.FIELD.Item(i)
                s = "<tr><td>" + f.FieldGroupBox + "</td><td>" + f.Caption & "</td><td>" & f.Name
                ft = f.FieldType

                s = s & "</td><td>"
                On Error Resume Next
                Dim trg As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
                For j = 1 To ft.FIELDTYPEMAP.Count
                    trg = ft.FIELDTYPEMAP.Item(j).Target
                    If trg.Name = "MS SQL 2000" Then
                        s = s & " " & ft.FIELDTYPEMAP.Item(j).StoageType
                        If ft.AllowSize = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            s = s & "(" & f.DataSize & ")"
                        Else
                            If ft.FIELDTYPEMAP.Item(j).FixedSize <> 0 Then
                                s = s & "(" & ft.FIELDTYPEMAP.Item(j).FixedSize & ")"
                            End If
                        End If
                        Exit For
                    End If
                Next


                's = s & " (" & ft.the_comment & ") "  ' & "(" & ft.Name & ")

                If f.AllowNull Then
                    s = s & "</td><td>" & "Да"
                Else
                    s = s & "</td><td>" & "Нет"
                End If

                '      If f.IsBrief Then
                '        s = s & "</td><td>" & "Да"
                '      Else
                '        s = s & "</td><td>" & "Нет"
                '      End If
                '
                Dim rp As MTZMetaModel.MTZMetaModel.PART
                Dim rt As MTZMetaModel.MTZMetaModel.OBJECTTYPE

                If ft.AllowSize Then
                    s = s & "</td><td>" & f.DataSize

                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        s = s & "</td><td>" & "ссылка на объект "

                        rt = f.RefToType
                        If Not rt Is Nothing Then
                            s = s & "типа: " & Notabs(rt.the_Comment)
                        End If
                    End If

                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        s = s & "</td><td>" & "ссылка на строку раздела"

                        rp = f.RefToPart
                        If Not rp Is Nothing Then
                            rt = LATIR2Framework.ObjectTypeHelper.TypeForStruct(rp)
                            s = s & ": " & Notabs(rp.Caption) & " (в документе: " & Notabs(rt.the_Comment) & ")"
                        End If

                    End If
                Else
                    s = s & "</td><td>"
                End If

                s = s & "</td><td>" & Notabs(ft.the_Comment) & " ( " & Notabs(f.TheComment) & " )</td>"
                s = s & "</td><td>" & Notabs(f.TheStyle)
                s = s & "</td></tr>"
                wh.Append(s)

                Application.DoEvents()
            Next
            wh.AppendLine("</table>")
            'wh.MakeTable(sp, ep, ep - sp + 1, 6)

            If p.UNIQUECONSTRAINT.Count > 0 Then
                wh.Append("Уникальные сочетания полей в разделе")
                wh.Append("<br/>")
                Dim unc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
                Dim uncf As MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD
                For j = 1 To p.UNIQUECONSTRAINT.Count
                    unc = p.UNIQUECONSTRAINT.Item(j)
                    If unc.PerParent Then
                        wh.Append("Ограничение №" & j & " - в рамках родительского раздела")
                        wh.Append("<br/>")

                    Else
                        wh.Append("Ограничение №" & j & " - глобальное")
                        wh.Append("<br/>")
                    End If
                    If unc.Name <> "" Then
                        wh.Append(unc.Name)
                    End If
                    If unc.TheComment <> "" Then
                        wh.Append(unc.TheComment)
                    End If


                    s = "Уникальное сочетание полей:"
                    For k = 1 To unc.CONSTRAINTFIELD.Count
                        uncf = unc.CONSTRAINTFIELD.Item(k)
                        f = uncf.TheField
                        If k <> 1 Then
                            s = s & "+"
                        End If
                        s = s & f.Caption
                    Next
                    wh.Append("<i>")
                    wh.Append(s)
                    wh.Append("</i>")
                    wh.Append("<br/>")

                Next
            End If
        End If
        p.PART.Sort = "sequence"

        If IncludeProcsToDoc Then
            wh.AppendLine("<p><b>")
            wh.Append(vbCrLf & "Стандартные процедуры раздела " & p.Caption & "(" & p.Name & ") документа " & ot.the_Comment & "(" & ot.Name & ")")
            wh.AppendLine("</b></p>")


            wh.Append("<b>")
            wh.Append("Функция вычисления краткого наименования")
            wh.Append("</b>")

            wh.Append("<br/>")

            wh.Append("function  " & p.Name & "_BRIEF_F  (" & vbCrLf & "<br/>" & _
            "@" & p.Name & " id uniqueidentifier /* Идентификатор строки */" & vbCrLf & "<br/>" & _
            ",@Lang varchar(25)=NULL             /* Язык */ " & vbCrLf & "<br/>" & _
           ")returns varchar(4000) " & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - краткое наименование" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Процедура вычисления краткого наименования")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_BRIEF  (" & vbCrLf & "<br/>" & _
             "@CURSESSION uniqueidentifier        /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
             "@" & p.Name & " id uniqueidentifier /* Идентификатор строки */," & vbCrLf & "<br/>" & _
             "@BRIEF varchar(4000) output         /* Краткое наименование */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Процедура удаления строки раздела")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_DELETE (" & vbCrLf & "<br/>" & _
            "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
            "@" & p.Name & "ID uniqueidentifier            /* Идентификатор строки раздела */)" & vbCrLf & "<br/>" & _
            "@InstanceID uniqueidentifier                  /* Идентификатор объекта */)" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Процедура проверки состояния блокировки дочерних строк")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_HCL (" & vbCrLf & "<br/>" & _
            "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
            "@RowID uniqueidentifier                       /* Идентификатор строки раздела */," & vbCrLf & "<br/>" & _
            "@IsLocked int out                             /* Результат блокировки */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>" & _
              " Возможные значения параметра @isLocked:" & vbCrLf & "<br/>" & _
               "@isLocked = 4 /* Заблокирован другим пользователем в режиме CheckOut */" & vbCrLf & "<br/>" & _
               "@isLocked = 2 /* Заблокирован текущим пользователем в режиме CheckOut */" & vbCrLf & "<br/>" & _
               "@isLocked = 3 /* Заблокирован другим пользователем в рамках сессии */" & vbCrLf & "<br/>" & _
               "@isLocked = 1 /* Заблокирован текущим пользователем в рамках сессии */" & vbCrLf & "<br/>" & _
               "@isLocked = 0 /* Документ не заблокирован*/" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Процедура проверки блокировки")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_ISLOCKED (" & vbCrLf & "<br/>" & _
             "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
             "@RowID uniqueidentifier      /* Идентификатор строки раздела */ ," & vbCrLf & "<br/>" & _
             "@IsLocked integer output     /* Результат блокировки */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>" & _
              " Возможные значения параметра @isLocked:" & vbCrLf & "<br/>" & _
              "@isLocked = 4 /* Заблокирован другим пользователем в режиме CheckOut */" & vbCrLf & "<br/>" & _
              "@isLocked = 2 /* Заблокирован текущим пользователем в режиме CheckOut */" & vbCrLf & "<br/>" & _
              "@isLocked = 3 /* Заблокирован другим пользователем в рамках сессии */" & vbCrLf & "<br/>" & _
              "@isLocked = 1 /* Заблокирован текущим пользователем в рамках сессии */" & vbCrLf & "<br/>" & _
              "@isLocked = 0 /* Документ не заблокирован*/" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Блокировка строки")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_LOCK  (" & vbCrLf & "<br/>" & _
             "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
             "@RowID uniqueidentifier      /* Идентификатор строки раздела */," & vbCrLf & "<br/>" & _
             "@LockMode integer            /* Тип блокировки */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>" & _
            " Возможные значения режима блокировки:" & vbCrLf & "<br/>" & _
            "@LockMode = 1 - Блокировка в рамках текущей сессии" & vbCrLf & "<br/>" & _
            "@LockMode = 2 - Блокировка в режиме CheckOut" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Распространение прав на дочерние разделы и строки")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_propagate (" & vbCrLf & "<br/>" & _
            "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии */," & vbCrLf & "<br/>" & _
            "@RowID uniqueidentifier                       /* Идентификатор строки раздела */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Сохранение\создание строки раздела")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "_Save (" & vbCrLf & "<br/>" & _
            "@CURSESSION uniqueidentifier             /* Идентификатор Текущей сессии */" & vbCrLf & "<br/>" & _
            ",@InstanceID uniqueidentifier            /* Идентификатор объекта */ =null," & vbCrLf & "<br/>")

            If UCase(TypeName(p.Parent.Parent)) = "PART" Then
                wh.Append(",@ParentStructRowID uniqueidentifier =null /* Идентификатор родительской строки в вышестоящем разделе */" & vbCrLf & "<br/>")
            End If
            If p.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                wh.Append(",@ParentRowID uniqueidentifier =null       /* Идентифыикатор родительской строки в дереве*/" & vbCrLf & "<br/>")
            End If
            wh.Append(",@" & p.Name & "id uniqueidentifier          /* Идентификатор строки раздела */<br/>")

            s = ""
            For i = 1 To p.FIELD.Count
                f = p.FIELD.Item(i)
                ft = f.FieldType
                Dim trg As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
                On Error Resume Next
                For j = 1 To ft.FIELDTYPEMAP.Count
                    trg = ft.FIELDTYPEMAP.Item(j).Target
                    If trg.Name = "MS SQL 2000" Then
                        s = ft.FIELDTYPEMAP.Item(j).StoageType
                        If ft.AllowSize = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                            s = s & "(" & f.DataSize & ")"
                        Else
                            If ft.FIELDTYPEMAP.Item(j).FixedSize <> 0 Then
                                s = s & "(" & ft.FIELDTYPEMAP.Item(j).FixedSize & ")"
                            End If
                        End If
                        Exit For
                    End If

                Next
                wh.Append(",@" & f.Name & " " & s & " " & "/* " & f.Caption & " */ <br/>")
            Next
            wh.Append(")<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Инициализация прав по умолчанию")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append(p.Name & "_SINIT  (" & vbCrLf & "<br/>" & _
            "@CURSESSION uniqueidentifier /* Идентификатор Текущей сессии */," & vbCrLf & "<br/>" & _
            "@RowID uniqueidentifier                       /* Идентификатор строки раздела */," & vbCrLf & "<br/>" & _
            "@SecurityStyleID uniqueidentifier=null        /* Идентификатор стиля защиты */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")


            wh.Append("<b>")
            wh.Append("Разблокировка")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append(p.Name & "_UNLOCK (" & vbCrLf & "<br/>" & _
             "@CURSESSION uniqueidentifier      /* Идентификатор Текущей сессии*/," & vbCrLf & "<br/>" & _
             "@RowID uniqueidentifier           /* Идентификатор строки раздела */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

            wh.Append("<b>")
            wh.Append("Вычисление параметров строки родительского объекта")
            wh.Append("</b>")
            wh.Append("<br/>")
            wh.Append("proc " & p.Name & "__PARENT  (" & vbCrLf & "<br/>" & _
             "@CURSESSION uniqueidentifier      /* Идентификатор Текущей сессии */," & vbCrLf & "<br/>" & _
             "@RowID uniqueidentifier           /* Идентификатор строки раздела */," & vbCrLf & "<br/>" & _
             "@ParentID uniqueidentifier output /* Идентификатор родительской строки  */," & vbCrLf & "<br/>" & _
             "@ParentTable varchar(255) output  /* название родительского раздела */" & vbCrLf & "<br/>" & _
            ")" & vbCrLf & "<br/>")
            wh.Append("Возвращаемый результат - нет" & vbCrLf & "<br/>" & vbCrLf & "<br/>")

        End If

        For i = 1 To p.PART.Count
            PartToHTML(p.PART.Item(i), ot)
        Next
        H = H - 1


    End Sub


    Private Function Notabs(ByVal s As String) As String
        Notabs = Replace(Replace(Replace(Replace(Replace(s, "</td><td>", " "), vbCrLf, " "), vbCr, " "), vbLf, " "), "  ", " ")
    End Function

    Private Sub frmGenerator_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        myResizer.ResizeAllControls(Me)
    End Sub
End Class
