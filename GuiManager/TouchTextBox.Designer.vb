<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TouchTextBox
    Inherits System.Windows.Forms.TextBox

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        tabtip = GetSetting("LATIR4", "CFG", "TABTIP", "true")
        AddHandler Me.Enter, AddressOf OnTouchEnter

    End Sub
    Private Sub OnTouchEnter(sender As Object, e As EventArgs)
        If tabtip = "true" And Me.ReadOnly = False And Me.Enabled = True Then
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

End Class
