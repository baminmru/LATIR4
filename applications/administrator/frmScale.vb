
Imports System.Drawing
Imports System.Windows.Forms

Class frmScale
        Inherits Form

        Public Sub New()
        Text = "Scale Setup"
        Font = New Font("Arial", 12)
        FormBorderStyle = FormBorderStyle.FixedSingle

        Dim aiPointSize As Integer() = {8, 10, 12, 16, 24, 32}

        For i As Integer = 0 To aiPointSize.Length - 1
                Dim btn As New Button()
                btn.Text = "Use " + aiPointSize(i).ToString() + "-point font"
                btn.Tag = aiPointSize(i)
                btn.Location = New Point(4, 16 + 24 * i)
                btn.Size = New Size(80, 16)
                AddHandler btn.Click, AddressOf ButtonOnClick
                Me.Controls.Add(btn)
            Next
            ClientSize = New Size(88, 16 + 24 * aiPointSize.Length)
            AutoScaleBaseSize = New Size(4, 8)

        End Sub
    Protected Overrides Sub OnPaint(pea As PaintEventArgs)
        pea.Graphics.DrawString(Text, Font, New SolidBrush(ForeColor), 0, 0)
    End Sub
    Private Sub ButtonOnClick(obj As Object, ea As EventArgs)
            Dim btn As Button = DirectCast(obj, Button)

            Dim sizefOld As SizeF = GetAutoScaleSize(Font)
            Font = New Font(Font.FontFamily, CInt(btn.Tag))
            Dim sizefNew As SizeF = GetAutoScaleSize(Font)

        Scale(sizefNew.Width / sizefOld.Width, sizefNew.Height / sizefOld.Height)
        SaveSetting("LATIR4", "CFG", "SCALE", btn.Tag)

        Me.StartPosition = FormStartPosition.Manual
        Dim SRect As Rectangle
        SRect = Screen.GetBounds(New Point(0, 0))
        Me.Left = (SRect.Width - Me.Width) / 2
        Me.Top = (SRect.Height - Me.Height) / 2
        If Me.Left < 0 Then Me.Left = 0
        If Me.Top < 0 Then Me.Top = 0




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

