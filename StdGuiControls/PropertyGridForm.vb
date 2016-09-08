Public Class PropertyGridForm
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents PropertyGrid As System.Windows.Forms.PropertyGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PropertyGridForm))
        Me.PropertyGrid = New System.Windows.Forms.PropertyGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PropertyGrid
        '
        Me.PropertyGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid.CommandsVisibleIfAvailable = True
        Me.PropertyGrid.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.PropertyGrid.LargeButtons = False
        Me.PropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.PropertyGrid.Location = New System.Drawing.Point(4, 2)
        Me.PropertyGrid.Name = "PropertyGrid"
        Me.PropertyGrid.Size = New System.Drawing.Size(300, 366)
        Me.PropertyGrid.TabIndex = 0
        Me.PropertyGrid.Text = "PropertyGrid1"
        Me.PropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window
        Me.PropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PropertyGrid)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(312, 405)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cmdCancel)
        Me.Panel2.Controls.Add(Me.cmdOK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 373)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(312, 32)
        Me.Panel2.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(152, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 24)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Отмена"
        Me.cmdCancel.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(230, 5)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(70, 24)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "ОК"
        '
        'PropertyGridForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 405)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(320, 432)
        Me.Name = "PropertyGridForm"
        Me.Text = "Свойства"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mSelectedObject As Object

    Public Property SelectedObject() As Object
        Get
            Return mSelectedObject
        End Get
        Set(ByVal Value As Object)
            mSelectedObject = Value
            If Not (mSelectedObject Is Nothing) Then
                PropertyGrid.SelectedObject = mSelectedObject
            End If
        End Set
    End Property
End Class
