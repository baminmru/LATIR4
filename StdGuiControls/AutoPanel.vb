
Public Class AutoPanel
    Inherits System.Windows.Forms.Panel

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub



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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'AutoPanel
        '
        Me.AllowDrop = True
        Me.AutoScroll = True
        'Me.BackColor = System.Drawing.SystemColors.Control
        Me.Size = New System.Drawing.Size(296, 248)
        'Me.UseOsThemes = DefaultableBoolean.True

        Me.ResumeLayout(False)

    End Sub

#End Region



    Public Sub SetupPanel()
        Dim f As frmPanelSetup
        f = New frmPanelSetup

        Dim i As Integer, J As Integer
        Dim ctl As Control
        Dim shape As NetronLight.ShapeBase
        f.grc.Shapes.Clear()
        f.grc.Invalidate()

        For i = 0 To Me.Controls.Count - 1
            ctl = Me.Controls.Item(i)
            shape = New NetronLight.ShapeBase(f.grc)
            shape = f.grc.AddShape(NetronLight.ShapeTypes.Rectangular, ctl.Location)
            shape.Text = ctl.Name
            shape.Width = ctl.Width
            shape.Height = ctl.Height
            shape.ShapeColor = System.Drawing.Color.White
        Next
        If f.ShowDialog() = DialogResult.OK Then
            For i = 0 To Me.Controls.Count - 1
                ctl = Me.Controls.Item(i)
                For J = 0 To f.grc.Shapes.Count - 1
                    shape = f.grc.Shapes.Item(J)

                    If shape.Text = ctl.Name Then
                        ctl.Location = shape.Location
                        ctl.Width = shape.Width
                        ctl.Height = shape.Height
                        'ctl.Text = shape.Text
                    End If
                Next

            Next
        End If
    End Sub


    Public Overridable Function GetMaxX() As Double
        Dim i As Integer
        Dim maxX As Double, xx As Double
        Dim ctl As Control
        For i = 0 To Me.Controls.Count - 1
            ctl = Me.Controls.Item(i)
            xx = ctl.Location.X + ctl.Width
            If maxX < xx Then
                maxX = xx
            End If
        Next
        Return maxX
    End Function

    Public Overridable Function GetMaxY() As Double
        Dim i As Integer
        Dim maxX As Double, xx As Double
        Dim ctl As Control
        For i = 0 To Me.Controls.Count - 1
            ctl = Me.Controls.Item(i)
            xx = ctl.Location.Y + ctl.Height
            If maxX < xx Then
                maxX = xx
            End If
        Next
        Return maxX
    End Function

    Private Sub AutoPanel_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        'SetupPanel()
    End Sub

    Public ReadOnly Property ClientArea As Object
        Get
            Return Me
        End Get
    End Property




    Dim mouseDownPoint As Point
    Private Sub me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If (e.Button = MouseButtons.Left) Then
            Me.mouseDownPoint = Me.PointToClient(MousePosition)
        End If

    End Sub

    Private Sub me_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If (e.Button <> MouseButtons.Left) Then
            Return
        End If

        If ((mouseDownPoint.X = Me.PointToClient(MousePosition).X) _
                    AndAlso (mouseDownPoint.Y = Me.PointToClient(MousePosition).Y)) Then
            Return
        End If

        Dim currAutoS As Point = Me.AutoScrollPosition
        If (mouseDownPoint.Y > Me.PointToClient(MousePosition).Y) Then
            'finger slide UP
            If (currAutoS.Y <> 0) Then
                currAutoS.Y = (Math.Abs(currAutoS.Y) - 1)
            End If

        ElseIf (mouseDownPoint.Y < Me.PointToClient(MousePosition).Y) Then
            'finger slide down
            currAutoS.Y = (Math.Abs(currAutoS.Y) + 1)
        Else
            currAutoS.Y = Math.Abs(currAutoS.Y)
        End If

        If (mouseDownPoint.X > Me.PointToClient(MousePosition).X) Then
            'finger slide left
            If (currAutoS.X <> 0) Then
                currAutoS.X = (Math.Abs(currAutoS.X) - 1)
            End If

        ElseIf (mouseDownPoint.X < Me.PointToClient(MousePosition).X) Then
            'finger slide right
            currAutoS.X = (Math.Abs(currAutoS.X) + 1)
        Else
            currAutoS.X = Math.Abs(currAutoS.X)
        End If

        Me.AutoScrollPosition = currAutoS
        mouseDownPoint = Me.PointToClient(MousePosition)
        'IMPORTANT
    End Sub

End Class
