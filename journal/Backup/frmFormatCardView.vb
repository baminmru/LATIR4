Imports Janus.Windows.GridEX

Public Class frmFormatCardView
    Inherits System.Windows.Forms.Form

    Private mCardCaption As Font
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
    Friend WithEvents btnCardCaption As System.Windows.Forms.Button
    Friend WithEvents lblCardCaption As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAllowEdit As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllowAddNew As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents lblRowsFont As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnRowsFont As System.Windows.Forms.Button
    Friend WithEvents chkShowEmptyFields As System.Windows.Forms.CheckBox
    Friend WithEvents txtCardWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkCollapsibleCards As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCardCaption = New System.Windows.Forms.Label()
        Me.btnCardCaption = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkAllowAddNew = New System.Windows.Forms.CheckBox()
        Me.chkAllowEdit = New System.Windows.Forms.CheckBox()
        Me.lblRowsFont = New System.Windows.Forms.Label()
        Me.btnRowsFont = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCardWidth = New System.Windows.Forms.TextBox()
        Me.chkShowEmptyFields = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkCollapsibleCards = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCardCaption, Me.btnCardCaption})
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Card headings"
        '
        'lblCardCaption
        '
        Me.lblCardCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCardCaption.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblCardCaption.Location = New System.Drawing.Point(100, 28)
        Me.lblCardCaption.Name = "lblCardCaption"
        Me.lblCardCaption.Size = New System.Drawing.Size(148, 20)
        Me.lblCardCaption.TabIndex = 1
        Me.lblCardCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCardCaption
        '
        Me.btnCardCaption.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCardCaption.Location = New System.Drawing.Point(12, 28)
        Me.btnCardCaption.Name = "btnCardCaption"
        Me.btnCardCaption.Size = New System.Drawing.Size(80, 24)
        Me.btnCardCaption.TabIndex = 0
        Me.btnCardCaption.Text = "Font..."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAllowAddNew, Me.chkAllowEdit, Me.lblRowsFont, Me.btnRowsFont})
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Location = New System.Drawing.Point(8, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(424, 76)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Card body"
        '
        'chkAllowAddNew
        '
        Me.chkAllowAddNew.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkAllowAddNew.Location = New System.Drawing.Point(276, 48)
        Me.chkAllowAddNew.Name = "chkAllowAddNew"
        Me.chkAllowAddNew.Size = New System.Drawing.Size(132, 24)
        Me.chkAllowAddNew.TabIndex = 3
        Me.chkAllowAddNew.Text = "Show ""new item"" card"
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
        Me.btnRowsFont.Size = New System.Drawing.Size(80, 24)
        Me.btnRowsFont.TabIndex = 0
        Me.btnRowsFont.Text = "Font..."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkCollapsibleCards, Me.Label1, Me.txtCardWidth, Me.chkShowEmptyFields, Me.Label2})
        Me.GroupBox3.Location = New System.Drawing.Point(12, 164)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(420, 64)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Card settings"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label1.Location = New System.Drawing.Point(180, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "pixels."
        '
        'txtCardWidth
        '
        Me.txtCardWidth.Location = New System.Drawing.Point(92, 28)
        Me.txtCardWidth.Name = "txtCardWidth"
        Me.txtCardWidth.Size = New System.Drawing.Size(84, 21)
        Me.txtCardWidth.TabIndex = 4
        Me.txtCardWidth.Text = ""
        '
        'chkShowEmptyFields
        '
        Me.chkShowEmptyFields.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkShowEmptyFields.Location = New System.Drawing.Point(272, 16)
        Me.chkShowEmptyFields.Name = "chkShowEmptyFields"
        Me.chkShowEmptyFields.Size = New System.Drawing.Size(132, 24)
        Me.chkShowEmptyFields.TabIndex = 3
        Me.chkShowEmptyFields.Text = "Show empty fields"
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Card width:"
        '
        'FontDialog1
        '
        Me.FontDialog1.AllowVerticalFonts = False
        Me.FontDialog1.FontMustExist = True
        Me.FontDialog1.ShowColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(448, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(448, 48)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'chkCollapsibleCards
        '
        Me.chkCollapsibleCards.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chkCollapsibleCards.Location = New System.Drawing.Point(276, 40)
        Me.chkCollapsibleCards.Name = "chkCollapsibleCards"
        Me.chkCollapsibleCards.Size = New System.Drawing.Size(132, 24)
        Me.chkCollapsibleCards.TabIndex = 6
        Me.chkCollapsibleCards.Text = "Collapsible cards"
        '
        'frmFormatCardView
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(534, 248)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmFormatCardView"
        Me.Text = "Format Card View"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overloads Function ShowDialog(ByVal grid As GridEX, ByVal parent As Form) As System.Windows.Forms.DialogResult
        If grid.CardCaptionFormatStyle.Font Is Nothing Then
            CardCaption = grid.Font.Clone()
        Else
            CardCaption = grid.CardCaptionFormatStyle.Font.Clone()
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
        Me.chkShowEmptyFields.Checked = grid.ShowEmptyFields
        Me.txtCardWidth.Text = grid.CardWidth.ToString()
        Me.chkCollapsibleCards.Checked = grid.ExpandableCards

        Me.ShowDialog(parent)

        If Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
            If mCardCaption.Equals(grid.Font) Then
                grid.CardCaptionFormatStyle.Font = Nothing
            Else
                grid.CardCaptionFormatStyle.Font = mCardCaption
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
            grid.ShowEmptyFields = Me.chkShowEmptyFields.Checked
            grid.ExpandableCards = Me.chkCollapsibleCards.Checked
            Try
                grid.CardWidth = Int32.Parse(Me.txtCardWidth.Text)
            Catch
                MessageBox.Show("Invalid card width.", "Janus Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        Return Me.DialogResult
    End Function
    Private Property CardCaption() As Font
        Get
            Return mCardCaption
        End Get
        Set(ByVal Value As Font)
            If Value Is Nothing Then
                mCardCaption = Nothing
                Me.lblCardCaption.Text = ""
            Else
                If Not Value.Equals(mCardCaption) Then
                    mCardCaption = Value
                    Me.lblCardCaption.Font = New Font(mCardCaption.Name, Me.lblCardCaption.Font.Size, mCardCaption.Style)
                    Me.lblCardCaption.Text = mCardCaption.SizeInPoints.ToString() + " pt. " + mCardCaption.Name
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
    Private Sub btnCardCaption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCardCaption.Click
        Me.FontDialog1.Font = mCardCaption
        Me.FontDialog1.ShowColor = False
        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.CardCaption = Me.FontDialog1.Font
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnRowsFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsFont.Click
        Me.FontDialog1.Font = mRowsFont
        Me.FontDialog1.ShowColor = False
        If Me.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.RowsFont = Me.FontDialog1.Font
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
