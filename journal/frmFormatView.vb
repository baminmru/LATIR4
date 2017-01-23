Imports Janus.Windows.GridEX

Public Class frmFormatView
    Inherits System.Windows.Forms.Form

    Private mHeaderFont As Font
    Private mRowsFont As Font
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnHeaderFont As System.Windows.Forms.Button
    Friend WithEvents lblHeaderFont As System.Windows.Forms.Label
    Friend WithEvents chkAutoSize As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllowEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowAddNew As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGridlineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chkShadeGroupHeaders As System.Windows.Forms.CheckBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents lblRowsFont As System.Windows.Forms.Label
    Friend WithEvents btnRowsFont As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAutoSize = New System.Windows.Forms.CheckBox()
        Me.lblHeaderFont = New System.Windows.Forms.Label()
        Me.btnHeaderFont = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkAllowAddNew = New System.Windows.Forms.CheckBox()
        Me.chkAllowEdit = New System.Windows.Forms.CheckBox()
        Me.lblRowsFont = New System.Windows.Forms.Label()
        Me.btnRowsFont = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkShadeGroupHeaders = New System.Windows.Forms.CheckBox()
        Me.cboGridlineStyle = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAutoSize, Me.lblHeaderFont, Me.btnHeaderFont})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Column headings"
        '
        'chkAutoSize
        '
        Me.chkAutoSize.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkAutoSize.Location = New System.Drawing.Point(276, 24)
        Me.chkAutoSize.Name = "chkAutoSize"
        Me.chkAutoSize.Size = New System.Drawing.Size(140, 24)
        Me.chkAutoSize.TabIndex = 2
        Me.chkAutoSize.Text = "Automatic column sizing"
        '
        'lblHeaderFont
        '
        Me.lblHeaderFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeaderFont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblHeaderFont.Location = New System.Drawing.Point(100, 28)
        Me.lblHeaderFont.Name = "lblHeaderFont"
        Me.lblHeaderFont.Size = New System.Drawing.Size(148, 20)
        Me.lblHeaderFont.TabIndex = 1
        Me.lblHeaderFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnHeaderFont
        '
        Me.btnHeaderFont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHeaderFont.Location = New System.Drawing.Point(12, 28)
        Me.btnHeaderFont.Name = "btnHeaderFont"
        Me.btnHeaderFont.Size = New System.Drawing.Size(76, 24)
        Me.btnHeaderFont.TabIndex = 0
        Me.btnHeaderFont.Text = "Font..."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAllowAddNew, Me.chkAllowEdit, Me.lblRowsFont, Me.btnRowsFont})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(8, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 76)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rows"
        '
        'chkAllowAddNew
        '
        Me.chkAllowAddNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkAllowAddNew.Location = New System.Drawing.Point(276, 48)
        Me.chkAllowAddNew.Name = "chkAllowAddNew"
        Me.chkAllowAddNew.Size = New System.Drawing.Size(132, 24)
        Me.chkAllowAddNew.TabIndex = 3
        Me.chkAllowAddNew.Text = "Show ""new item"" row"
        '
        'chkAllowEdit
        '
        Me.chkAllowEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkAllowEdit.Location = New System.Drawing.Point(276, 20)
        Me.chkAllowEdit.Name = "chkAllowEdit"
        Me.chkAllowEdit.Size = New System.Drawing.Size(132, 24)
        Me.chkAllowEdit.TabIndex = 2
        Me.chkAllowEdit.Text = "Allow in-cell editing"
        '
        'lblRowsFont
        '
        Me.lblRowsFont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRowsFont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblRowsFont.Location = New System.Drawing.Point(100, 28)
        Me.lblRowsFont.Name = "lblRowsFont"
        Me.lblRowsFont.Size = New System.Drawing.Size(148, 20)
        Me.lblRowsFont.TabIndex = 1
        Me.lblRowsFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRowsFont
        '
        Me.btnRowsFont.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRowsFont.Location = New System.Drawing.Point(12, 28)
        Me.btnRowsFont.Name = "btnRowsFont"
        Me.btnRowsFont.Size = New System.Drawing.Size(76, 24)
        Me.btnRowsFont.TabIndex = 0
        Me.btnRowsFont.Text = "Font..."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkShadeGroupHeaders, Me.cboGridlineStyle, Me.Label2})
        Me.GroupBox3.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(420, 76)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Grid lines"
        '
        'chkShadeGroupHeaders
        '
        Me.chkShadeGroupHeaders.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkShadeGroupHeaders.Location = New System.Drawing.Point(272, 24)
        Me.chkShadeGroupHeaders.Name = "chkShadeGroupHeaders"
        Me.chkShadeGroupHeaders.Size = New System.Drawing.Size(132, 24)
        Me.chkShadeGroupHeaders.TabIndex = 3
        Me.chkShadeGroupHeaders.Text = "Shade group headings"
        '
        'cboGridlineStyle
        '
        Me.cboGridlineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGridlineStyle.Location = New System.Drawing.Point(96, 28)
        Me.cboGridlineStyle.Name = "cboGridlineStyle"
        Me.cboGridlineStyle.Size = New System.Drawing.Size(116, 21)
        Me.cboGridlineStyle.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Grid line style:"
        '
        'FontDialog1
        '
        Me.FontDialog1.AllowVerticalFonts = False
        Me.FontDialog1.FontMustExist = True
        Me.FontDialog1.ShowColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(448, 48)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(448, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        '
        'frmFormatView
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(538, 252)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmFormatView"
        Me.Text = "Format Table View"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Function ShowDialog(ByVal grid As GridEX, ByVal parent As Form) As Windows.Forms.DialogResult
        If grid.HeaderFormatStyle.Font Is Nothing Then
            HeaderFont = grid.Font.Clone()
        Else
            HeaderFont = grid.HeaderFormatStyle.Font.Clone()
        End If
        If grid.RowFormatStyle.Font Is Nothing Then
            RowsFont = grid.Font.Clone()
        Else
            RowsFont = grid.RowFormatStyle.Font.Clone()
        End If
        If grid.AllowAddNew = InheritableBoolean.True Then
            Me.chkAllowAddNew.Checked = True
        End If
        If grid.AllowEdit = InheritableBoolean.True Then
            Me.chkAllowEdit.Checked = True
        End If
        If grid.ColumnAutoResize Then
            Me.chkAutoSize.Checked = True
        End If

        Me.cboGridlineStyle.Items.Add("No grid lines")
        Me.cboGridlineStyle.Items.Add("Small dots")
        Me.cboGridlineStyle.Items.Add("Solid")
        If grid.GridLines = GridLines.None Then
            Me.cboGridlineStyle.SelectedIndex = 0
        Else
            If grid.GridLineStyle = GridLineStyle.SmallDots Then
                Me.cboGridlineStyle.SelectedIndex = 1
            Else
                Me.cboGridlineStyle.SelectedIndex = 2
            End If
        End If
        If grid.GroupRowFormatStyle.BackColor.Equals(SystemColors.Control) Then
            Me.chkShadeGroupHeaders.Checked = True
        End If
        Me.ShowDialog(parent)

        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            If mHeaderFont.Equals(grid.Font) Then
                grid.HeaderFormatStyle.Font = Nothing
            Else
                grid.HeaderFormatStyle.Font = mHeaderFont
            End If
            If mRowsFont.Equals(grid.Font) Then
                grid.RowFormatStyle.Font = Nothing
            Else
                grid.RowFormatStyle.Font = mRowsFont
            End If
            If Me.chkAllowAddNew.Checked Then
                grid.AllowAddNew = InheritableBoolean.True
            Else
                grid.AllowAddNew = InheritableBoolean.False
            End If
            If Me.chkAllowEdit.Checked Then
                grid.AllowEdit = InheritableBoolean.True
            Else
                grid.AllowEdit = InheritableBoolean.False
            End If
            grid.ColumnAutoResize = Me.chkAutoSize.Checked
            Select Case Me.cboGridlineStyle.SelectedIndex
                Case 0
                    grid.GridLines = GridLines.None
                Case 1
                    grid.GridLines = GridLines.Both
                    grid.GridLineStyle = GridLineStyle.SmallDots
                Case 2
                    grid.GridLines = GridLines.Both
                    grid.GridLineStyle = GridLineStyle.Solid
            End Select
            If Me.chkShadeGroupHeaders.Checked Then
                grid.ThemedAreas = grid.ThemedAreas Or ThemedArea.GroupRows
                grid.GroupRowFormatStyle.BackColor = SystemColors.Control
            Else
                grid.ThemedAreas = grid.ThemedAreas Xor ThemedArea.GroupRows
                grid.GroupRowFormatStyle.BackColor = SystemColors.Window
            End If
        End If
        Return Me.DialogResult
    End Function
    Private Property HeaderFont() As Font
        Get
            Return mHeaderFont
        End Get
        Set(ByVal Value As Font)
            If Value Is Nothing Then
                mHeaderFont = Nothing
                Me.lblHeaderFont.Text = ""
            Else
                If Not Value.Equals(mHeaderFont) Then
                    mHeaderFont = Value
                    Me.lblHeaderFont.Font = New Font(mHeaderFont.Name, Me.lblHeaderFont.Font.Size, mHeaderFont.Style)
                    Me.lblHeaderFont.Text = mHeaderFont.SizeInPoints.ToString() + " pt. " + mHeaderFont.Name
                End If
            End If
        End Set
    End Property
    Private Property RowsFont() As Font
        Get
            Return mRowsFont
        End Get
        Set(ByVal Value As Font)
            If Value Is Nothing Then
                mRowsFont = Nothing
                Me.lblRowsFont.Text = ""
            Else
                If Not Value.Equals(mRowsFont) Then
                    mRowsFont = Value
                    Me.lblRowsFont.Font = New Font(mRowsFont.Name, Me.lblRowsFont.Font.Size, mRowsFont.Style)
                    Me.lblRowsFont.Text = mRowsFont.SizeInPoints.ToString() + " pt. " + mRowsFont.Name
                End If
            End If
        End Set
    End Property
    Private Sub btnHeaderFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeaderFont.Click
        Me.FontDialog1.Font = mHeaderFont
        Me.FontDialog1.ShowColor = False
        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.HeaderFont = Me.FontDialog1.Font
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click, btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnRowsFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsFont.Click
        Me.FontDialog1.Font = mRowsFont
        Me.FontDialog1.ShowColor = False
        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.RowsFont = Me.FontDialog1.Font
        End If
    End Sub


End Class
