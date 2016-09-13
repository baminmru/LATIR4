Imports System.IO
Imports System.Text

Public Class jsCompressor

    Private Sub cmdFolder_Click(sender As System.Object, e As System.EventArgs) Handles cmdFolder.Click
        If dlgFolder.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFolder.Text = dlgFolder.SelectedPath
        End If
    End Sub

    Private Sub cmdCompress_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompress.Click
        If txtFolder.Text = "" Then
            Exit Sub
        End If
        Dim di As DirectoryInfo
        Dim fi As FileInfo
        di = New DirectoryInfo(txtFolder.Text)
        For Each fi In di.GetFiles
            Tool_CompressFile(di.FullName, fi.Name)
            lblOUt.Text = fi.Name
            Application.DoEvents()
        Next
        lblOUt.Text = "Завершено"
    End Sub

    Private Sub Tool_CompressFile(ByVal path As String, ByVal fname As String)
        Dim p As String
        Dim s As String
        p = path
        If Not p.EndsWith("\") Then
            p += "\"
        End If
        s = File.ReadAllText(p & fname, System.Text.Encoding.UTF8)
        Dim jsc As Yahoo.Yui.Compressor.JavaScriptCompressor

        If fname.Contains(".js") Then
            Try
                jsc = New Yahoo.Yui.Compressor.JavaScriptCompressor
                s = jsc.Compress(s)
                p += "comp\"
                Dim di As DirectoryInfo
                di = New DirectoryInfo(p)
                If Not di.Exists Then
                    di.Create()
                End If

                File.WriteAllText(p & fname, s, System.Text.Encoding.UTF8)
            Catch ex As Exception

            End Try

        End If

    End Sub
End Class