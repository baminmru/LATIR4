<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GaugePicture
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.m_GPicture = New System.Windows.Forms.PictureBox()
        Me.m_GPBar = New System.Windows.Forms.ProgressBar()
        Me.lblName = New System.Windows.Forms.Label()
        CType(Me.m_GPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'm_GPicture
        '
        Me.m_GPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_GPicture.InitialImage = Nothing
        Me.m_GPicture.Location = New System.Drawing.Point(3, 3)
        Me.m_GPicture.Name = "m_GPicture"
        Me.m_GPicture.Size = New System.Drawing.Size(147, 134)
        Me.m_GPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.m_GPicture.TabIndex = 0
        Me.m_GPicture.TabStop = False
        '
        'm_GPBar
        '
        Me.m_GPBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_GPBar.ForeColor = System.Drawing.Color.OrangeRed
        Me.m_GPBar.Location = New System.Drawing.Point(3, 126)
        Me.m_GPBar.Name = "m_GPBar"
        Me.m_GPBar.Size = New System.Drawing.Size(147, 11)
        Me.m_GPBar.TabIndex = 1
        Me.m_GPBar.Value = 50
        '
        'lblName
        '
        Me.lblName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(3, 3)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(147, 120)
        Me.lblName.TabIndex = 2
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GaugePicture
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.m_GPBar)
        Me.Controls.Add(Me.m_GPicture)
        Me.Name = "GaugePicture"
        Me.Size = New System.Drawing.Size(153, 140)
        CType(Me.m_GPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents m_GPicture As PictureBox
    Friend WithEvents m_GPBar As ProgressBar
    Friend WithEvents lblName As Label
End Class
