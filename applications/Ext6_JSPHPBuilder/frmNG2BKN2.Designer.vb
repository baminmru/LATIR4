<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNG2BKN2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNGPass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNGUsr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNGDB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNGSrv = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb = New System.Windows.Forms.ProgressBar()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.chkImport = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFirmID = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNGPass)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNGUsr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNGDB)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNGSrv)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(222, 131)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "NG Base"
        '
        'txtNGPass
        '
        Me.txtNGPass.Location = New System.Drawing.Point(73, 92)
        Me.txtNGPass.Name = "txtNGPass"
        Me.txtNGPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNGPass.Size = New System.Drawing.Size(102, 20)
        Me.txtNGPass.TabIndex = 13
        Me.txtNGPass.Text = "88514569"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Password"
        '
        'txtNGUsr
        '
        Me.txtNGUsr.Location = New System.Drawing.Point(73, 69)
        Me.txtNGUsr.Name = "txtNGUsr"
        Me.txtNGUsr.Size = New System.Drawing.Size(102, 20)
        Me.txtNGUsr.TabIndex = 11
        Me.txtNGUsr.Text = "1gb_semk"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "User"
        '
        'txtNGDB
        '
        Me.txtNGDB.Location = New System.Drawing.Point(73, 43)
        Me.txtNGDB.Name = "txtNGDB"
        Me.txtNGDB.Size = New System.Drawing.Size(102, 20)
        Me.txtNGDB.TabIndex = 9
        Me.txtNGDB.Text = "1gb_ng"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Database"
        '
        'txtNGSrv
        '
        Me.txtNGSrv.Location = New System.Drawing.Point(73, 17)
        Me.txtNGSrv.Name = "txtNGSrv"
        Me.txtNGSrv.Size = New System.Drawing.Size(102, 20)
        Me.txtNGSrv.TabIndex = 7
        Me.txtNGSrv.Text = "ms-sql-6.in-solve.ru"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Server"
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(12, 404)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(638, 24)
        Me.pb.TabIndex = 7
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(279, 15)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(114, 47)
        Me.cmdStart.TabIndex = 8
        Me.cmdStart.Text = "Старт"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'chkImport
        '
        Me.chkImport.FormattingEnabled = True
        Me.chkImport.Items.AddRange(New Object() {"Справочники", "Адресная база", "Фирмы", "Новостройки", "Вторичное жилье", "Загародное жилье", "Коммерческие объекты", "Зарубежные объекты"})
        Me.chkImport.Location = New System.Drawing.Point(15, 163)
        Me.chkImport.Name = "chkImport"
        Me.chkImport.Size = New System.Drawing.Size(218, 214)
        Me.chkImport.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(268, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Firm Id"
        '
        'txtFirmID
        '
        Me.txtFirmID.Location = New System.Drawing.Point(267, 203)
        Me.txtFirmID.Name = "txtFirmID"
        Me.txtFirmID.Size = New System.Drawing.Size(142, 20)
        Me.txtFirmID.TabIndex = 11
        Me.txtFirmID.Text = "337"
        '
        'frmNG2BKN2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 453)
        Me.Controls.Add(Me.txtFirmID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkImport)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmNG2BKN2"
        Me.Text = "frmNG2BKN2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNGPass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNGUsr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNGDB As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNGSrv As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents chkImport As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFirmID As System.Windows.Forms.TextBox
End Class
