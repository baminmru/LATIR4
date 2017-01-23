<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmConfig
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overrides Sub Dispose(ByVal Disposing As Boolean)
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
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public cdlgOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents txtPath As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command3 = New System.Windows.Forms.Button
        Me.cdlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOutPath = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(295, 27)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(24, 20)
        Me.Command3.TabIndex = 3
        Me.Command3.Text = "..."
        Me.ToolTip1.SetToolTip(Me.Command3, "Select folder")
        Me.Command3.UseVisualStyleBackColor = False
        '
        'cdlgOpen
        '
        Me.cdlgOpen.DefaultExt = "dll"
        Me.cdlgOpen.FileName = "LTObjMan.dll"
        Me.cdlgOpen.Filter = "dll|*.dll"
        Me.cdlgOpen.InitialDirectory = "c:\"
        Me.cdlgOpen.Title = "ѕуть к MKSNManager.dll"
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(249, 104)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(70, 24)
        Me.Command2.TabIndex = 5
        Me.Command2.Text = "&Cancel"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(176, 104)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(70, 24)
        Me.Command1.TabIndex = 4
        Me.Command1.Text = "&OK"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'txtPath
        '
        Me.txtPath.AcceptsReturn = True
        Me.txtPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPath.Location = New System.Drawing.Point(8, 27)
        Me.txtPath.MaxLength = 0
        Me.txtPath.Name = "txtPath"
        Me.txtPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPath.Size = New System.Drawing.Size(284, 20)
        Me.txtPath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(241, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Object manager DLL (LTObjMan.dll):"
        '
        'txtOutPath
        '
        Me.txtOutPath.Location = New System.Drawing.Point(8, 78)
        Me.txtOutPath.Name = "txtOutPath"
        Me.txtOutPath.Size = New System.Drawing.Size(283, 20)
        Me.txtOutPath.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Output path"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(295, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 19)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmConfig
        '
        Me.AcceptButton = Me.Command1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.Command2
        Me.ClientSize = New System.Drawing.Size(321, 140)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOutPath)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Generator settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents txtOutPath As System.Windows.Forms.TextBox
#End Region
End Class