Public Class CloseButton
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MyBase.OnClick(e)
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        MyBase.OnDoubleClick(e)
    End Sub
End Class
