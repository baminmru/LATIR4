Public Class frmFind
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Строка для поиска:"
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(8, 24)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(264, 20)
        Me.txtFind.TabIndex = 1
        Me.txtFind.Text = ""
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(126, 56)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(70, 24)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "ОК"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(202, 56)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 24)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Отмена"
        '
        'frmFind
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(280, 85)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmFind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Поиск по строке"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
