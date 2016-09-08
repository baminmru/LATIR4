Public Class testForm
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

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TextBox1 As LATIR2GuiManager.TouchTextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnl As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents gc As NetronLight.GraphControl
    Friend WithEvents pg As System.Windows.Forms.PropertyGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnl = New System.Windows.Forms.Panel
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New LATIR2GuiManager.TouchTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.gc = New NetronLight.GraphControl
        Me.pg = New System.Windows.Forms.PropertyGrid
        Me.pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnl
        '
        Me.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl.Controls.Add(Me.RadioButton1)
        Me.pnl.Controls.Add(Me.TextBox1)
        Me.pnl.Controls.Add(Me.LinkLabel1)
        Me.pnl.Controls.Add(Me.Button1)
        Me.pnl.Location = New System.Drawing.Point(368, 8)
        Me.pnl.Name = "pnl"
        Me.pnl.Size = New System.Drawing.Size(216, 208)
        Me.pnl.TabIndex = 1
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(32, 168)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(112, 24)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.Text = "RadioButton1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 120)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(128, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "TextBox1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 72)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(96, 24)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(368, 224)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 24)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "<<"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(368, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 24)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = ">>"
        '
        'gc
        '
        Me.gc.Location = New System.Drawing.Point(8, 8)
        Me.gc.Name = "gc"
        Me.gc.ShowGrid = True
        Me.gc.Size = New System.Drawing.Size(297, 248)
        Me.gc.TabIndex = 4
        Me.gc.Text = "GraphControl1"
        '
        'pg
        '
        Me.pg.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.pg.Location = New System.Drawing.Point(8, 264)
        Me.pg.Name = "pg"
        Me.pg.Size = New System.Drawing.Size(288, 168)
        Me.pg.TabIndex = 5
        '
        'testForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 445)
        Me.Controls.Add(Me.pg)
        Me.Controls.Add(Me.gc)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pnl)
        Me.Name = "testForm"
        Me.Text = "testForm"
        Me.pnl.ResumeLayout(False)
        Me.pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub testForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub



    Private Sub gc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gc.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim i As Integer
        Dim ctl As Control
        Dim shape As NetronLight.ShapeBase
        gc.Shapes.Clear()
        gc.Invalidate()

        For i = 0 To pnl.Controls.Count - 1
            ctl = pnl.Controls.Item(i)
            shape = New NetronLight.ShapeBase(gc)
            shape = gc.AddShape(NetronLight.ShapeTypes.TextLabel, ctl.Location)
            shape.Text = ctl.Text
            shape.Width = ctl.Width
            shape.Height = ctl.Height

            shape.ShapeColor = System.Drawing.Color.White

        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer, j As Integer
        Dim ctl As Control
        Dim shape As NetronLight.ShapeBase
        For i = 0 To pnl.Controls.Count - 1
            ctl = pnl.Controls.Item(i)
            For j = 0 To gc.Shapes.Count - 1
                shape = gc.Shapes.Item(j)

                If shape.Text = ctl.Name Then
                    ctl.Location = shape.Location
                    ctl.Width = shape.Width
                    ctl.Height = shape.Height
                    ctl.Text = shape.Text
                End If
            Next

        Next
    End Sub

   

    Private Sub gc_OnShowProps(ByVal ent As Object) Handles gc.OnShowProps
        pg.SelectedObject = ent
    End Sub
End Class
