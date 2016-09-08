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
                    If (TypeOf (Panel.Controls(0)) Is System.Windows.Forms.Button) Then
                        Dim Button As System.Windows.Forms.Button
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
            If (TypeOf (OneControl) Is System.Windows.Forms.Button) Then
                Dim Button As System.Windows.Forms.Button
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


    Protected Shared Sub LoadIcon(ByRef ToolTip As ToolTip, ByVal Button As System.Windows.Forms.Button)
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

    Protected Shared Sub LoadIcon(ByRef ToolTip As ToolTip, ByVal Button As System.Windows.Forms.Button, ByVal FileName As String)
        Try
            Button.Image = Bitmap.FromFile(FileName)
            Button.Text = String.Empty
            Button.Width = 24
        Catch
        End Try
        If (Not Button.Tag Is Nothing) Then
            If (Button.Image Is Nothing) Then
                Button.Text = Constants.ButtonName(Button.Tag.ToString())
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
