<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournalViewIG
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmbJournals = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.jv = New LATIRJournalSTD.JournalViewSTD
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbJournals)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 348)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(522, 40)
        Me.Panel1.TabIndex = 2
        '
        'cmbJournals
        '
        Me.cmbJournals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJournals.Location = New System.Drawing.Point(12, 3)
        Me.cmbJournals.Name = "cmbJournals"
        Me.cmbJournals.Size = New System.Drawing.Size(440, 21)
        Me.cmbJournals.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.jv)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 348)
        Me.Panel2.TabIndex = 3
        '
        'jv
        '
        Me.jv.AllowAdd = True
        Me.jv.AllowDel = True
        Me.jv.AllowEdit = True
        Me.jv.AllowFilter = True
        Me.jv.AllowRun = True
        Me.jv.AutoRefresh = False
        Me.jv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.jv.Location = New System.Drawing.Point(0, 0)
        Me.jv.Name = "jv"
        Me.jv.Size = New System.Drawing.Size(522, 348)
        Me.jv.TabIndex = 1
        '
        'frmJournalViewIG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 388)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmJournalViewIG"
        Me.Text = "frmJournalViewIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbJournals As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents jv As LATIRJournalSTD.JournalViewSTD
End Class
