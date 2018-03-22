Public Class touchInput
    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged

    End Sub

    Private tabtip As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
    End Sub


    Private Sub txtInput_Enter(sender As Object, e As EventArgs) Handles txtInput.Enter
        If tabtip = "true" And txtInput.ReadOnly = False And txtInput.Enabled = True Then
            Dim progFiles As String = "C:\Program Files\Common Files\Microsoft Shared\ink"
            Dim onScreenKeyboardPath As String = System.IO.Path.Combine(progFiles, "TabTip.exe")
            Dim onScreenKeyboardProc As Process
            Try
                onScreenKeyboardProc = System.Diagnostics.Process.Start(onScreenKeyboardPath)
            Catch ex As Exception
                onScreenKeyboardProc = Nothing
            End Try
        End If
    End Sub

    Public Enum iMode
        Text = 0
        Number = 1
        YesNo = 2
    End Enum

    Private m_InputMode As iMode = iMode.Text

    Public Property InputMode() As iMode
        Get
            Return m_InputMode
        End Get
        Set(value As iMode)
            Dim c As Control
            m_InputMode = value
            pnlText.Visible = False
            pnlNumeric.Visible = False
            pnlYN.Visible = False

            If m_InputMode = iMode.YesNo Then
                pnlYN.Visible = True
                pnlYN.Top = 0
                pnlYN.Left = 0
                pnlYN.BringToFront()
                For Each c In pnlYN.Controls
                    c.BringToFront()
                Next
                Me.ClientSize = pnlYN.Size
            End If

            If m_InputMode = iMode.Text Then
                pnlText.Visible = True
                pnlText.Top = 0
                pnlText.Left = 0
                pnlText.BringToFront()
                For Each c In pnlText.Controls
                    c.BringToFront()
                Next
                Me.ClientSize = pnlText.Size
            End If

            If m_InputMode = iMode.Number Then
                pnlNumeric.Visible = True
                pnlNumeric.Top = 0
                pnlNumeric.Left = 0
                pnlNumeric.BringToFront()
                For Each c In pnlNumeric.Controls
                    c.BringToFront()
                Next
                Me.ClientSize = pnlNumeric.Size
            End If

        End Set


    End Property



    Public Property InputValue() As String
        Get
            If m_InputMode = iMode.YesNo Then
                If optYes.Checked Then
                    Return "Да"
                End If
                If optNo.Checked Then
                    Return "Нет"
                End If
                Return ""

            End If

            If m_InputMode = iMode.Text Then
                Return txtInput.Text
            End If

            If m_InputMode = iMode.Number Then
                Dim i As Double
                Dim s As String

                Try
                    s = txtNum.Text.Replace(",", ".")
                    If Double.TryParse(s, i) Then
                        i = Double.Parse(s)
                        Return i.ToString.Replace(",", ".")
                    Else
                        s = txtNum.Text.Replace(".", ",")
                        If Double.TryParse(s, i) Then
                            i = Double.Parse(s)
                            Return i.ToString.Replace(",", ".")
                        Else

                            Return ""
                        End If
                    End If

                Catch ex As Exception
                    Return ""
                End Try


            End If
            Return Nothing
        End Get

        Set(value As String)


            If m_InputMode = iMode.YesNo Then

                If value = "" Then
                    optNo.Checked = False
                    optYes.Checked = False
                    Return
                End If
                If value.ToLower  = "да" Or value.ToLower ="true" Then
                    optYes.Checked = True
                    optNo.Checked = False
                Else
                    optYes.Checked = False
                    optNo.Checked = True
                End If
            End If

            If m_InputMode = iMode.Text Then
                txtInput.Text = value
            End If

            If m_InputMode = iMode.Number Then
                Dim d As Double
                If value = "" Then
                    txtNum.Text = ""
                    Return
                End If

                Try
                    d = Double.Parse(value.ToString().Replace(",", "."))
                Catch ex As Exception
                    Try
                        d = Double.Parse(value.ToString().Replace(".", ","))
                    Catch ex2 As Exception
                        txtNum.Text = ""
                        Return
                    End Try

                End Try

                txtNum.Text = d.ToString.Replace(",", ".")


            End If

        End Set


    End Property


    Private Sub D_Click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button14.Click, Button13.Click, Button11.Click, Button10.Click
        Dim b As Button
        b = sender
        Add(b.Text)
    End Sub

    Private Sub Add(ByVal s As String)
        If s = "." And txtNum.Text.IndexOf(".") >= 0 Then Exit Sub
        txtNum.Text += s
    End Sub


    Private Sub C_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If txtNum.Text.Length > 0 Then
            txtNum.Text = txtNum.Text.Substring(0, txtNum.Text.Length - 1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtNum.Text.StartsWith("-") Then
            txtNum.Text = txtNum.Text.Substring(1)
        Else
            txtNum.Text = "-" & txtNum.Text
        End If
    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged
        If m_InputMode = iMode.Number Then
            Dim i As Double
            Dim s As String

            Try
                s = txtNum.Text.Replace(",", ".")
                If Double.TryParse(s, i) Then
                    txtNum.ForeColor = Color.Black
                Else
                    s = txtNum.Text.Replace(".", ",")
                    If Double.TryParse(s, i) Then
                        txtNum.ForeColor = Color.Black
                    Else

                        txtNum.ForeColor = Color.Red
                    End If
                End If

            Catch ex As Exception
                txtNum.ForeColor = Color.Black
            End Try
        Else
            txtNum.ForeColor = Color.Black
        End If
    End Sub
End Class
