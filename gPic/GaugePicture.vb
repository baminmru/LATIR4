Public Class GaugePicture

    Public Data As New GaleryItem

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        lblName.Parent = m_GPicture
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function gPBar() As ProgressBar
        Return m_GPBar
    End Function

    Public Function gName() As Label
        Return lblName
    End Function

    Public Function gPicture() As PictureBox
        Return m_GPicture
    End Function

    Private Sub m_GPicture_MouseEnter(sender As Object, e As EventArgs) Handles m_GPicture.MouseEnter
        MyBase.OnMouseEnter(e)
    End Sub

    Private Sub m_GPicture_MouseLeave(sender As Object, e As EventArgs) Handles m_GPicture.MouseLeave
        MyBase.OnMouseLeave(e)
    End Sub

    Private Sub m_GPBar_MouseEnter(sender As Object, e As EventArgs) Handles m_GPBar.MouseEnter
        MyBase.OnMouseEnter(e)
    End Sub

    Private Sub m_GPBar_MouseLeave(sender As Object, e As EventArgs) Handles m_GPBar.MouseLeave
        MyBase.OnMouseLeave(e)
    End Sub

    Private Sub m_GPicture_Click(sender As Object, e As EventArgs) Handles m_GPicture.Click, m_GPBar.Click, lblName.Click
        Dim p As Point
        Dim s As Size
        p = m_GPicture.Location
        s = m_GPicture.Size
        BackColor = Color.LightSeaGreen
        m_GPicture.Size = New Size(s.Width - 10, s.Height - 10)
        m_GPicture.Location = New Point(p.X + 5, p.Y + 5)

        System.Threading.Thread.Sleep(200)
        MyBase.OnClick(e)

        m_GPicture.Location = p
        m_GPicture.Size = s
        BackColor = Color.LightGray
    End Sub

    Private Sub m_GPicture_DoubleClick(sender As Object, e As EventArgs) Handles m_GPicture.DoubleClick, lblName.DoubleClick
        MyBase.OnDoubleClick(e)
    End Sub
End Class
