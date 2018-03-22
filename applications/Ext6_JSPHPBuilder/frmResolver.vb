Public Class frmResolver

    Dim WithEvents r As Resolver
    Dim total As Integer
    Dim failed As Integer

    Private Sub cmdB2S_Click(sender As System.Object, e As System.EventArgs) Handles cmdB2S.Click

        r = New Resolver
        total = 0
        failed = 0
        txtout.Text = r.ResolveAddresses(Manager.Session, "B2S_INFO")


    End Sub

    Private Sub cmdB2Z_Click(sender As System.Object, e As System.EventArgs) Handles cmdB2Z.Click

        r = New Resolver
        total = 0
        failed = 0
        txtOut.Text = r.ResolveAddresses(Manager.Session, "B2Z_INFO")
       
    End Sub

  
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        r = New Resolver
        total = 0
        failed = 0
        txtOut.Text = r.ResolveAddresses(Manager.Session, "B2P_INFO")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        r = New Resolver
        total = 0
        failed = 0
        txtOut.Text = r.ResolveAddresses(Manager.Session, "B2C_INFO")
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        r = New Resolver
        total = 0
        failed = 0
        r.ResolveAddresses(Manager.Session, "B2P_INFO")
        While r.ResolvedCount > 0
            txtOut.Text = r.ResolveAddresses(Manager.Session, "B2P_INFO")

        End While
        Application.DoEvents()
        r.ResolveAddresses(Manager.Session, "B2S_INFO")
        While r.ResolvedCount > 0
            r.ResolveAddresses(Manager.Session, "B2S_INFO")

        End While

        Application.DoEvents()
        r.ResolveAddresses(Manager.Session, "B2C_INFO")
        While r.ResolvedCount > 0
            r.ResolveAddresses(Manager.Session, "B2C_INFO")

        End While

        Application.DoEvents()
        r.ResolveAddresses(Manager.Session, "B2Z_INFO")
        While r.ResolvedCount > 0
            r.ResolveAddresses(Manager.Session, "B2Z_INFO")

        End While



    End Sub

    Private Sub r_Resolving(Addr As String, ok As Boolean) Handles r.Resolving
        total += 1
        If Not ok Then
            failed += 1
        End If
        Me.Text = "Всего:" + total.ToString + ", ошибок:" + failed.ToString + "  (" + (failed * 100.0 / total).ToString + " %)"
        txtOut.Text = Addr
        Application.DoEvents()
    End Sub
End Class