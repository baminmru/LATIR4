Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.UserControl

Public Class ButtonUtils

    Public Shared Sub PrepareForm(ByRef ToolTip As ToolTip, ByRef Controls As ControlCollection)
        ProcessButtons(ToolTip, Controls)
        ProcessButtonPanels(Controls)
    End Sub

    Protected Shared Sub ProcessButtonPanels(ByVal ThisControls As ControlCollection)
        Dim OneControl As Control
        For Each OneControl In ThisControls
            If (TypeOf (OneControl) Is System.Windows.Forms.Panel) Then
                Dim Panel As System.Windows.Forms.Panel
                Panel = OneControl
                If (Not Panel.Controls Is Nothing And Panel.Controls.Count = 1) Then
                    If (TypeOf (Panel.Controls(0)) Is Infragistics.Win.Misc.UltraButton) Then
                        Dim Button As Infragistics.Win.Misc.UltraButton
                        Button = OneControl.Controls(0)
                        Button.Left = 2
                        Button.Top = Panel.Height - Button.Height - 2
                        If (Button.Visible) Then
                            Panel.Width = Button.Width + 4
                        Else
                            Panel.Width = 0
                        End If
                    End If
                End If
                If (Not OneControl.Controls Is Nothing) Then
                    If (TypeOf (OneControl.Controls) Is ControlCollection) Then
                        ProcessButtonPanels(OneControl.Controls)
                    End If
                End If
            End If
        Next
    End Sub


    Protected Shared Sub ProcessButtons(ByRef ToolTip As ToolTip, ByRef ThisControls As ControlCollection)

        Dim OneControl As Control
        For Each OneControl In ThisControls
            If (TypeOf (OneControl) Is Infragistics.Win.Misc.UltraButton) Then
                Dim Button As Infragistics.Win.Misc.UltraButton
                Button = OneControl
                LoadIcon(ToolTip, Button)
            End If
            If (Not OneControl.Controls Is Nothing) Then
                If (OneControl.Controls.Count > 0) Then
                    If (TypeOf (OneControl.Controls) Is ControlCollection) Then
                        ButtonUtils.ProcessButtons(ToolTip, OneControl.Controls)
                    End If
                End If
            End If
        Next
    End Sub


    Protected Shared Sub LoadIcon(ByRef ToolTip As ToolTip, ByVal Button As Infragistics.Win.Misc.UltraButton)
        Dim IcoName As String
        Dim IcoPath As String
        Dim FileName As String
        If (Button.Tag Is Nothing) Then
            Return
        End If
        IcoName = Button.Tag.ToString().Trim()
        If (IcoName = String.Empty) Then
            Return
        End If

        If (IcoName.Length > 4) Then
            If (IcoName.Substring(IcoName.Length - 4).ToLower() <> ".ico") Then
                IcoName = IcoName & ".ico"
            End If
        Else
            IcoName = IcoName & ".ico"
        End If
        IcoPath = String.Empty
        FileName = MakeFileName(IcoPath, IcoName)

        If (File.Exists(FileName)) Then
            LoadIcon(ToolTip, Button, FileName)
        Else
            IcoPath = ".\IMAGES"
            FileName = MakeFileName(IcoPath, IcoName)
            If (File.Exists(FileName)) Then
                LoadIcon(ToolTip, Button, FileName)
            End If
        End If
    End Sub

    Protected Shared Sub LoadIcon(ByRef ToolTip As ToolTip, ByVal Button As Infragistics.Win.Misc.UltraButton, ByVal FileName As String)
        Try
            If Button.ImageList Is Nothing Then
                Button.ImageList = New ImageList
            End If
            Button.ImageList.Images.Clear()
            Button.ImageList.Images.Add("main", Bitmap.FromFile(FileName))
            Button.Text = Button.Text().Substring(0, 2)
            'Button.ForeColor = Button.BackColor
            'Button.TextImageRelation = TextImageRelation.TextAboveImage
            'Button.TextAlign = ContentAlignment.BottomRight
            'Button.ImageAlign = ContentAlignment.TopRight
            Button.Appearance.Image = 0

            Button.Font = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 1, FontStyle.Regular, GraphicsUnit.Pixel)
            Button.Width = 24
        Catch
        End Try
        If (Not Button.Tag Is Nothing) Then
            If (Button.ImageList.Images.Count = 0) Then
                Button.Text = Constants.ButtonName(Button.Tag.ToString())
                Button.Font = New System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 8, FontStyle.Regular, GraphicsUnit.Point)
                Button.ForeColor = Color.Black
            End If
            If (Not ToolTip Is Nothing) Then
                Constants.ButtonToolTip(ToolTip, Button)
            End If
        End If
    End Sub

    Public Shared Function MakeFileName(ByVal FilePath As String, ByVal FileName As String) As String
        If (FilePath <> String.Empty) Then
            If (FilePath.Substring(FilePath.Length) <> "\") Then
                FilePath = FilePath & "\"
            End If
        End If
        Return FilePath & FileName
    End Function

End Class
